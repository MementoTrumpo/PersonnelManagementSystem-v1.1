using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data.SqlClient;

namespace PersonnelManagementSystem.View
{
    /// <summary>
    /// Логика взаимодействия для HiringEmployeeView.xaml
    /// </summary>
    public partial class HiringEmployeeView : UserControl
    {
        private SqlConnection _connection;
        public HiringEmployeeView()
        {
            InitializeComponent();

            // Подключение к SQL Server
            //_connection = new SqlConnection("Data Source=localhost;Initial Catalog=MyDatabase;Integrated Security=True");
            //_connection.Open();

            // Заполнение ComboBox данными из таблицы
            FillComboBoxWithTableData();

        }

        private void FillComboBoxWithTableData()
        {
          
        }

      
    }
}
