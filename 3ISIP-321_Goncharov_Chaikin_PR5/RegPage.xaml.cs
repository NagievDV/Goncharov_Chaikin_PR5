using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            cbRole.ItemsSource = new Roles[]
            {
                new Roles { Name = "Менеджер А"},
                new Roles { Name = "Менеджер С"},
                new Roles { Name = "Администратор"},
            };
        }
        public class Roles
        {
            public string Name { get; set; } = "";
            public override string ToString() => $"{Name}";
        }
        public bool Registrate(string fio, string login, string password, string password_repeat, string role, string phone, string photo, string gender)
        {
            if (!string.IsNullOrEmpty(fio) && !string.IsNullOrEmpty(login)
               && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(password_repeat)
               && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(photo))
            {

                if (phone.Length == 11)
                {
                    bool isphone = true;
                    for (int i = 0; i < 11; i++)
                    {
                        if (!Char.IsDigit(phone[i]))
                        {
                            isphone = false;
                            break;
                        }
                    }
                    if (isphone)
                    {
                        if (password == password_repeat)
                        {
                            var db = new Entities();
                            var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == login);
                            if (user == null)
                            {
                                User _user = new User
                                {
                                    FIO = fio,
                                    Login = login,
                                    Password = password,
                                    Role = role,
                                    Gender = gender,
                                    Phone = phone,
                                    Photo = photo
                                };
                                db.User.Add(_user);
                                db.SaveChanges();
                                MessageBox.Show($"Регистрация прошла успешно!");

                                NavigationService.Navigate(new AuthPage());
                                return true;
                            }
                            else
                            {
                                MessageBox.Show($"Пожалуйста, выберите другой логин");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль отличается от подтверждения пароля!");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат номера телефона!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат номера телефона!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return false;
            }
        }

        private void btnRegistrate_Click(object sender, RoutedEventArgs e)
        {
            if ((rbGenderMale.IsChecked == true || rbGenderFemale.IsChecked == true) && !(cbRole.SelectedIndex == -1))
            {
                string gender = "";
                if (rbGenderMale.IsChecked == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }

                Registrate(tbFIO.Text, tbLogin.Text, pbPassword.Password, pbPasswordRepeat.Password, cbRole.Text, tbPhoneNumber.Text, tbPhoto.Text, gender);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
