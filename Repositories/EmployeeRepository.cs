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
        public void Add(EmployeeModel employee)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                //connection.Open();
                //command.Connection = connection;
                //command.CommandText = "INSERT INTO DETAILS_WORKER " +
                //    "(MAR_STATUS_CODE,MANNING_TABDLE_CODE, GENDER," +
                //    " LAST_NAME, FIRST_NAME, PATREONYMIC, LastName, Image) VALUES (@FirstName, @LastName, @Image)"; ";
                //command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                //command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                //validUser = command.ExecuteScalar() == null ? false : true;
            }
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
