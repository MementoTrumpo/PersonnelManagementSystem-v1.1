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
        public void Transfer(int id);
        public EmployeeModel GetById(int id);
        public EmployeeModel GetByName(string name);
        public List<string> GetDepartments();
        public List<string> GetPositions();
        public List<string> GetMaritalStatuses();
        public List<string> GetTypesOfWork();
        public int AddManningTableEntry(string department, string position, decimal salary, decimal rate);
        public void AddLaborContract(int officerCode, DateTime dateContract,
            DateTime dateAppointment, int codeOfWork, DateTime? terminationDate = null);
        public int GetOfficerCode(string firstName, string lastName, string patronymic);



    }
}
