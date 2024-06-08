using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Repositories
{
    public abstract class RepositoryUserBase
    {
        private readonly string _connectionString;

        public RepositoryUserBase()
        {
            _connectionString = "Server=DESKTOP-GVD6PAR; Database=dbUsers; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
