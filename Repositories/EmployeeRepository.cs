using PersonnelManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Repositories
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public void Add(EmployeeModel employee)
        {
            
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
