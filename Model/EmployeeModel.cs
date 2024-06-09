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
        public string MaritalStatus { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }
        public decimal Salary { get; set; }
        public decimal Rate { get; set; }
        public DateTime DateContract { get; set; }
        public DateTime DateAppointment { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int ManningTableCode { get; set; }
        public int CodeOfWork { get; set; }
        public int? Experience { get; set; }
        public byte[]? Image { get; set; }

    }
}
