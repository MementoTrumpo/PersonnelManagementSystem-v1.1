using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonnelManagementSystem.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        // Устанавливаем свойство для зависимости между моделью и представлением
        public static readonly DependencyProperty PasswordProperty = 
            DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

        // Свойство представления для инкапсуляции 
        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty);}
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
            textBoxUserPassword.PasswordChanged += OnPasswordChanged;
        }

        // Возникает при изменении значения поля пароля
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = textBoxUserPassword.SecurePassword;
        }
    }
}
