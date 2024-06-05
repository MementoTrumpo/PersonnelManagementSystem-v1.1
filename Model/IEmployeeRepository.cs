using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Model
{
    public interface IEmployeeRepository
    {
        public void Add(EmployeeModel employee);
        public void Remove(int id);
        
    }
}
