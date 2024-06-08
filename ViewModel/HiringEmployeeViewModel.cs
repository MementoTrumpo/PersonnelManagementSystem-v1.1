using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PersonnelManagementSystem.Model;

namespace PersonnelManagementSystem.ViewModel
{
    public class HiringEmployeeViewModel : ViewModelBase
    {
        // Fields
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private string _gender;
        private string _department;
        private string _position;
        private string _maritalStatus;
        private string? _email;
        private string? _telephone;
        private string? _experience;
        private string? _adress;
        private BitmapImage _selectedImage;

        private IEmployeeRepository _employeeRepository;


        //Properties
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public string MaritalStatus
        {
            get => _maritalStatus;
            set
            {
                _maritalStatus = value;
                OnPropertyChanged(nameof(MaritalStatus));
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
        public string Telephone
        {
            get => _telephone;
            set
            {
                _telephone = value;
                OnPropertyChanged(nameof(Telephone));
            }
        }
        public BitmapImage SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                if(_selectedImage != value)
                {
                    _selectedImage = value;
                    OnPropertyChanged(nameof(SelectedImage));
                }
            }
        }

        // Collections for displaying tables in ComboBox
        public ObservableCollection<string> Genders { get; set; }
        public ObservableCollection<string> Departments { get; set; }
        public ObservableCollection<string> Positions { get; set; }
        public ObservableCollection<string> MaritalStatuses { get; set; }

        
        // Commands
        public ICommand LoadImageCommand { get; }
        public ICommand SaveEmployeeCommand { get; }
        public ICommand AddEmployeeCommand { get; }

        public HiringEmployeeViewModel()
        {
            Genders = new ObservableCollection<string>(new List<string> { "Мужской", "Женский" });

            LoadImageCommand = new ViewModelCommand(ExecuteLoadImageCommand);
            SaveEmployeeCommand = new ViewModelCommand(ExecuteSaveEmployeeCommand);
            AddEmployeeCommand = new ViewModelCommand(ExecuteAddEmployeeCommand);

        }

        // Realization Commands
        private void ExecuteLoadImageCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteSaveEmployeeCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteAddEmployeeCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
