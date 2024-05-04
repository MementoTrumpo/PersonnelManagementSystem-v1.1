using PersonnelManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PersonnelManagementSystem.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;

namespace PersonnelManagementSystem.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        // Fields
        private string _username;

        private SecureString _password;

        private string _errorMessage;

        private bool _isMessageVisible = true;

        private IUserRepository _userRepository;

        // Properties
        public string UserName
        {
            get => _username;
            set 
            { 
                _username = value; 
                OnPropertyChanged(nameof(UserName));
            }
        }
        public SecureString Password 
        { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage 
        { 
            get => _errorMessage; 
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsMessageVisible 
        { 
            get => _isMessageVisible;
            set
            {
                _isMessageVisible = value;
                OnPropertyChanged(nameof(IsMessageVisible));
            } 
        }

        // Commands ->
        // Команда регистрации в системе (логгирования)
        public ICommand LoginCommand { get; }

        // Команда сброса пароля
        public ICommand RecoverPasswordCommand { get; }
        
        // Команда для отображения значков открытого пароля
        public ICommand ShowPasswordCommand { get; }

        // Команда запоминания пароля для входа в аккаунт
        public ICommand RememberPasswordCommand { get; }

        // Constructors
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        private void ExecuteRecoverPasswordCommand(string userName, string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrEmpty(UserName) || UserName.Length < 3 ||
                Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(UserName, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(UserName), null);
                IsMessageVisible = false;
            }
            else
            {
                ErrorMessage = "* Неправильное Имя пользователя или Пароль";
            }
        }
    }
}
