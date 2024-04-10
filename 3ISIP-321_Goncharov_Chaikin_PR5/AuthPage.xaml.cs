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

namespace _3ISIP_321_Goncharov_Chaikin_PR5
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public int currentAttemptsCount { get; set; }
        public AuthPage()
        {
            InitializeComponent();

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            if (Auth(tbLogin.Text, pbPassword.Password) == false)
            {
                currentAttemptsCount++;
            }
            else
            {
                currentAttemptsCount = 0;
            }

            if (currentAttemptsCount == 3)
            {
                NavigationService.Navigate(new CaptchaPage());
            }
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }
            using (var db = new Entities())
            {
                var user = db.User
                .AsNoTracking()
                .FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return false;
                    
                }
                MessageBox.Show($"Здравствуйте, {user.Role} {user.FIO.Replace('*', ' ')}!");
                tbLogin.Clear();
                pbPassword.Clear();
                return true;
            }


        }
    }
}
