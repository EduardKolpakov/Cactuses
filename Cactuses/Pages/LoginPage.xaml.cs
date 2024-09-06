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
using Cactuses.DB;

namespace Cactuses.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow _mainWindow;
        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            var user = ConnectionClass.db.Logins.FirstOrDefault(log => log.Login == login && log.Password == password);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            MessageBox.Show("Пользователь найден!");

        }
    }
}
