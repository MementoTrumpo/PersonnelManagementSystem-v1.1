using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Model
{
    public class EmployeeModel : Person
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
        public string Post { get; set; }
        public string Department { get; set; }
        public string HireDate { get; set; }
        public string? DateOfLeaving { get; set; }
        public decimal Salary { get; set; }
        public string? CellPhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }
        public byte[]? Image { get; set; }

    }
}
