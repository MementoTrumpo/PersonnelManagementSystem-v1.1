using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Repositories
{
    public class RepositoryEmployeeBase
    {
        private readonly string _connectionString;

        public RepositoryEmployeeBase()
        {
            _connectionString = "Server=DESKTOP-GVD6PAR; Database=dbEmployees; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
