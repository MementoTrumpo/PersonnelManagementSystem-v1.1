using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PersonnelManagementSystem.Model;

namespace PersonnelManagementSystem.ViewModel
{
    public class HiringEmployeeViewModel : ViewModelBase
    {
        // Fields
        private EmployeeModel _employee;


        //Properties
        public string FirstName
        {
            get { return _employee.FirstName; }
            set
            {
                _employee.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _employee.LastName; }
            set
            {
                _employee.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string? MiddleName
        {
            get { return _employee.MiddleName; }
            set
            {
                _employee.MiddleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string Gender
        {
            get { return _employee.Gender; }
            set
            {
                _employee.Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string? Adress
        {
            get { return _employee.Adress; }
            set
            {
                _employee.Adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        public string? PhoneNumber
        {
            get { return _employee.CellPhoneNumber; }
            set
            {
                _employee.CellPhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string? Email
        {
            get { return _employee.Email; }
            set
            {
                _employee.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public IEnumerable<Gender> GenderValues
        {
            get { return Enum.GetValues(typeof(Gender)); }
        }

        public HiringEmployeeViewModel()
        {
            SelectedGender = Gender.Male;
        }



        
    }
}
