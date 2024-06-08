using System.Configuration;
using System.Data;
using System.Windows;
using PersonnelManagementSystem.View;
using System.Threading;
using MaterialDesignThemes.Wpf;
using System.Windows.Threading;

namespace PersonnelManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();

            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    // Создаем и показываем промежуточную форму
                    var loadingView = new LoadingView();
                    loadingView.Show();

                    // Создаем таймер с интервалом в 4 секунды
                    var timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(4);
                    timer.Tick += (sender, args) =>
                    {
                        // Останавливаем таймер
                        timer.Stop();

                        // Закрываем промежуточную форму
                        loadingView.Close();

                        // Открываем главную форму
                        var mainView = new MainView();
                        mainView.Show();

                        // Закрываем форму логина
                        loginView.Close();
                    };

                    // Запускаем таймер
                    timer.Start();
                }
            };
        }

    }

}
