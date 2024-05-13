using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Model
{
    public class Employee : Person
    {
        public Gender Gender { get; set; }
        public MartialStatus MartialStatus { get; set; }
        public string Post { get; set; }
        public string Department { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string CellPhoneNumber { get; set; }
        public string? HomeNumber { get; set; }
        public string? Email { get; set; }
        public string Adress { get; set; }
        public byte[]? Photo { get; set; }

    }
}
