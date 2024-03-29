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
        public AuthPage()
        {
            InitializeComponent();

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }
            using (var db = new Entities())
            {
                var user = db.User
                .AsNoTracking()
                .FirstOrDefault(u => u.Login == tbLogin.Text && u.Password == pbPassword.Password);
                if (user != null) MessageBox.Show($"Здравствуйте, {user.Role} {user.FIO.Replace('*', ' ')}!");

                else
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
            }
        }
    }
}
