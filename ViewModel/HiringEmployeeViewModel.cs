using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Printing;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using PersonnelManagementSystem.Model;
using PersonnelManagementSystem.Repositories;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;

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
        private string _email;
        private string _adress;
        private string _telephone;
        private decimal _salary;
        private decimal _rate;
        private DateTime _dateContract = DateTime.Now;
        private DateTime _dateAppointment = DateTime.Now;
        private DateTime? _terminationDate;
        private int _codeOfWork;
        private int? _experience;
        private BitmapImage? _selectedImage = new BitmapImage(new Uri("pack://application:,,,/Images/employee_icon.png"));
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
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string? Telephone
        {
            get => _telephone;
            set
            {
                _telephone = value;
                OnPropertyChanged(nameof(Telephone));
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
        
        public decimal Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
            }
        }

        public DateTime DateContract
        {
            get { return _dateContract; }
            set
            {
                _dateContract = value;
                OnPropertyChanged(nameof(DateContract));
            }
        }

        public DateTime DateAppointment
        {
            get { return _dateAppointment; }
            set
            {
                _dateAppointment = value;
                OnPropertyChanged(nameof(DateAppointment));
            }
        }

        public DateTime? TerminationDate
        {
            get { return _terminationDate; }
            set
            {
                _terminationDate = value;
                OnPropertyChanged(nameof(TerminationDate));
            }
        }

        public int? Experience
        { 
            get { return _experience; }
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(Experience));
            }
        }
        public string? Adress
        {
            get { return _adress; }
            set
            {
                _adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        public int CodeOfWork
        {
            get { return _codeOfWork; }
            set
            {
                _codeOfWork = value;
                OnPropertyChanged(nameof(CodeOfWork));
            }
        }
        

        public BitmapImage? SelectedImage
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
        public ObservableCollection<string> TypesOfWork { get; set; }

        
        // Commands
        public ICommand LoadImageCommand { get; }
        public ICommand AddEmployeeCommand { get; }
        

        public HiringEmployeeViewModel()
        {
            _employeeRepository = new EmployeeRepository();

            LoadImageCommand = new ViewModelCommand(ExecuteLoadImageCommand);
            AddEmployeeCommand = new ViewModelCommand(ExecuteAddEmployeeCommand);

            Genders = new ObservableCollection<string> { "Мужской", "Женский" };
            Departments = new ObservableCollection<string>();
            Positions = new ObservableCollection<string>();
            MaritalStatuses = new ObservableCollection<string>();
            TypesOfWork = new ObservableCollection<string>();

            LoadDepartments();
            LoadPositions();
            LoadMaritalStatuses();
            LoadTypesOfWork();
            
        }

        // Realization Commands
        private void ExecuteLoadImageCommand(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        
        private void ExecuteAddEmployeeCommand(object obj)
        {
            try
            {
                byte[]? imageBytes = null;
                if (SelectedImage != null)
                {
                    imageBytes = ConvertImageToByteArray(SelectedImage);
                }
                                   
                var employee = new EmployeeModel
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Patronymic = this.Patronymic,
                    Gender = this.Gender,
                    Department = this.Department,
                    Position = this.Position,
                    MaritalStatus = this.MaritalStatus,
                    Email = this.Email,
                    Telephone = this.Telephone,
                    Adress = this.Adress,
                    Salary = this.Salary,
                    Rate = this.Rate,
                    CodeOfWork = this.CodeOfWork,
                    DateAppointment = this.DateAppointment,
                    DateContract = this.DateContract,
                    Experience = this.Experience,
                    Image = imageBytes,
                };

                // Добавляем запись в таблицу MANNING_TABLE
                employee.ManningTableCode = _employeeRepository.AddManningTableEntry(employee.Department, employee.Position, employee.Salary, employee.Rate);

                // Добавляем сотрудника в таблицу DETAILS_WORKER
                _employeeRepository.Add(employee);

                //// Получаем табельный номер (OFFICER_CODE) добавленного сотрудника
                //int officerCode = _employeeRepository.GetOfficerCode(employee.FirstName, employee.LastName, employee.Patronymic);

                //// Добавляем трудовой договор в таблицу LABOR_CONTRACT
                //_employeeRepository.AddLaborContract(officerCode, this.DateContract, this.DateAppointment, this.CodeOfWork, this.TerminationDate);

                // Очистка полей после успешного добавления
                ClearFields();

                // Отображение сообщения об успешном добавлении
                ShowSuccessMessage();
            } 
            
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Произошла ошибка: {ex.Message}",
                    "Ошибка", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

        }

        // Очистка полей после успешного добавления сотрудника
        private void ClearFields()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Patronymic = string.Empty;
            Gender = string.Empty;
            Department = string.Empty;
            Position = string.Empty;
            MaritalStatus = string.Empty;
            Email = string.Empty;
            Telephone = string.Empty;
            Adress = string.Empty;
            Salary = 0;
            Rate = 0;
            DateContract = DateTime.Now;
            DateAppointment = DateTime.Now;
            TerminationDate = null;
            Experience = null;
            SelectedImage = null;
        }

        // Диалог для успешного добавления сотрудника
        private void ShowSuccessMessage()
        {
            System.Windows.MessageBox.Show("Сотрудник успешно добавлен!", "Успех", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }


        private byte[] ConvertImageToByteArray(BitmapImage image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(ms);
                return ms.ToArray();
            }
        }

        // Загрузка отделов
        private void LoadDepartments()
        {
            var departments = _employeeRepository.GetDepartments();

            foreach (var depart in departments)
            {
                Departments.Add(depart);
            };
        }

        //  Загрузка должностей
        private void LoadPositions()
        {
            var positions = _employeeRepository.GetPositions();
            foreach (var pos in positions)
            {
                Positions.Add(pos);
            }
        }
        
        // Загрузка семейных статусов
        private void LoadMaritalStatuses()
        {
            var statuses = _employeeRepository.GetMaritalStatuses();
            foreach (var status in statuses)
            {
                MaritalStatuses.Add(status);
            }
        }

        // Загрузка типа работ
        private void LoadTypesOfWork()
        {
            var typesOfWork = _employeeRepository.GetTypesOfWork();
            foreach (var typeWork in typesOfWork)
            {
                TypesOfWork.Add(typeWork);
            }
        }


    }
}
