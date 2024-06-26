﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;
using PersonnelManagementSystem.Model;
using PersonnelManagementSystem.Repositories;
using PersonnelManagementSystem.View;

namespace PersonnelManagementSystem.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        // Properties
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(UserAccountModel));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // Commands

        /// <summary>
        /// Отображение формы информации всех сотрудников
        /// </summary>
        public ICommand ShowEmployeeViewCommand { get; }
        /// <summary>
        /// Отображение карточки с информацией о сотруднике
        /// </summary>
        public ICommand ShowPersonalCardViewCommand { get; }
        /// <summary>
        /// Отображение формы добавление сотрудника
        /// </summary>
        public ICommand ShowHiringEmployeeViewCommand { get; }

        
        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            // Initialize Commands
            ShowEmployeeViewCommand = new ViewModelCommand(ExecuteShowEmployeeViewCommand);
            ShowPersonalCardViewCommand = new ViewModelCommand(ExecuteShowPersonalCardViewCommand);
            ShowHiringEmployeeViewCommand = new ViewModelCommand(ExecuteHiringEmployeeViewCommand);
            // Default View
            ExecuteShowEmployeeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteHiringEmployeeViewCommand(object obj)
        {
            CurrentChildView = new HiringEmployeeViewModel();
            Caption = "Приём";
            Icon = IconChar.AddressBook;
        }

        private void ExecuteShowPersonalCardViewCommand(object obj)
        {
            CurrentChildView = new PersonalCardViewModel();
            Caption = "Личная карточка";
            Icon = IconChar.IdCard;
         
        }

        private void ExecuteShowEmployeeViewCommand(object obj)
        {
            CurrentChildView = new EmployeeViewModel();
            Caption = "Сотрудники";
            Icon = IconChar.Users;
        }

        private void LoadCurrentUserData()
        {
            UserModel user = userRepository.GetByUserName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.UserName;
                CurrentUserAccount.DisplayName = $"{user.LastName} {user.FirstName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Такого пользователя не существует";
            }
        }
    }
}
