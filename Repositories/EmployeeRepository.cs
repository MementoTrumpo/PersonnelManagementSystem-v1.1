using PersonnelManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Repositories
{
    public class EmployeeRepository : RepositoryEmployeeBase, IEmployeeRepository
    {
        // Добавление сотрудника
        public void Add(EmployeeModel employee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                INSERT INTO dbo.DETAILS_WORKER (FIRST_NAME, LAST_NAME, PATRONYMIC, GENDER, MANNING_TABLE_CODE, MAR_STATUS_CODE, EMAIL, TELEPHONE, ADDRESS_EMP, EXPERIENCE, IMAGE)
                VALUES (@FirstName, @LastName, @Patronymic, @Gender, @ManningTableCode, 
                (SELECT MAR_STATUS_CODE FROM dbo.MAR_STATUS WHERE MAR_STATUS_VALUE = @MaritalStatus), @Email, @Telephone, @Adress, @Experience, @Image)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", employee.LastName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Patronymic", employee.Patronymic ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Gender", employee.Gender ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ManningTableCode", employee.ManningTableCode);
                    command.Parameters.AddWithValue("@MaritalStatus", employee.MaritalStatus);
                    command.Parameters.AddWithValue("@Email", employee.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Telephone", employee.Telephone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Adress", employee.Adress ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Experience", employee.Experience ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Image", employee.Image ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Transfer(int id)
        {
            throw new NotImplementedException();
        }

        public void AddLaborContract(int officerCode, DateTime dateContract, DateTime dateAppointment, int codeOfWork, DateTime? terminationDate = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                INSERT INTO dbo.LABOR_CONTRACT (OFFICER_CODE, DATE_CONTRACT, DATE_APPOINTMENT, CODE_OF_WORK, TERMINATION_DATE)
                VALUES (@OfficerCode, @DateContract, @DateAppointment, @CodeOfWork, @TerminationDate)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OfficerCode", officerCode);
                    command.Parameters.AddWithValue("@DateContract", dateContract);
                    command.Parameters.AddWithValue("@DateAppointment", dateAppointment);
                    command.Parameters.AddWithValue("@CodeOfWork", codeOfWork);
                    command.Parameters.AddWithValue("@TerminationDate", terminationDate.HasValue ? (object)terminationDate.Value : DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int AddManningTableEntry(string department, string position, decimal salary, decimal rate)
        {
            
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                DECLARE @departCode INT;
                DECLARE @curPostCode INT;

                SET @departCode = (SELECT TOP 1 DEPART_CODE FROM dbo.STRUCTURAL_DIVISION WHERE DEPART = @Department);
                SET @curPostCode = (SELECT TOP 1 CUR_POST_CODE FROM dbo.POST WHERE CUR_POST = @Position);

                INSERT INTO dbo.MANNING_TABLE (DEPART_CODE, CUR_POST_CODE, SALARY, RATE)
                OUTPUT INSERTED.MANNING_TABLE_CODE
                VALUES (@departCode, @curPostCode, @Salary, @Rate)"; 
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Position", position);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Rate", rate);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public EmployeeModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<string> GetDepartments()
        {
            var departments = new List<string>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT DEPART FROM dbo.STRUCTURAL_DIVISION";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return departments;
        }

        public List<string> GetMaritalStatuses()
        {
            var maritalStatuses = new List<string>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT MAR_STATUS_VALUE FROM dbo.MAR_STATUS";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maritalStatuses.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return maritalStatuses;
        }

        public int GetOfficerCode(string firstName, string lastName, string patronymic)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                SELECT OFFICER_CODE 
                FROM dbo.DETAILS_WORKER 
                WHERE FIRST_NAME = @FirstName AND LAST_NAME = @LastName AND PATRONYMIC = @Patronymic";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Patronymic", patronymic);

                    return (int)command.ExecuteScalar();
                }
            }
        }
    

        public List<string> GetPositions()
        {
            var positions = new List<string>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT CUR_POST FROM dbo.POST";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positions.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return positions;
        }

        public List<string> GetTypesOfWork()
        {
            var typesOfWork = new List<string>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT TYPE_OF_WORK FROM dbo.TYPE_WORK";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            typesOfWork.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return typesOfWork;
        }


    }
}
