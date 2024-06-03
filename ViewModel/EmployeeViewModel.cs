using PersonnelManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonnelManagementSystem.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        // Private fileds
        private string _id;
        private string _name;
        private string _surname;
        private string _middleName;
        private string _email;
        private string _phoneNumber;
        private string _textBoxText;

        private IEmployeeRepository _employeeRepository;

        // Properties
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }

        }
        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string TextBoxText
        {
            get => _textBoxText;
            set
            {
                _textBoxText = value;
                OnPropertyChanged(nameof(TextBoxText));
            }
        }

        // Commands
        public ICommand ClearTextBoxTextCommand { get; }

       // Constructor
       public EmployeeViewModel()
        {
            ClearTextBoxTextCommand = new ViewModelCommand(ExecuteClearTextBoxTextCommand);
        }

        // Realizations

        private void ExecuteClearTextBoxTextCommand(object obj)
        {
            TextBoxText = string.Empty;
        }

    }
}
