//using PersonnelManagementSystem.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PersonnelManagementSystem.Services
//{
//    public class SickLeaveService
//    {
//        private readonly IEmployeeRepository _employeeRepository;

//        public SickLeaveService(IEmployeeRepository employeeRepository)
//        {
//            _employeeRepository = employeeRepository;
//        }

//        public void CreateSickLeave(int employeeId, DateTime startDate, DateTime endDate, string reason)
//        {
//            var employee = _employeeRepository.GetById(employeeId);
//            if (employee == null)
//            {
//                throw new ArgumentException("Сотрудник не найден.");
//            }

//            var sickLeave = new SickLeave
//            {
//                EmployeeId = employeeId,
//                StartDate = startDate,
//                EndDate = endDate,
//                Reason = reason
//            };

//            // Сохранение информации о больничном в базе данных
//            _employeeRepository.AddSickLeave(sickLeave);
//        }
//    }
//}
