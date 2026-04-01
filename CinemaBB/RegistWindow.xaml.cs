using CinemaBB.Model;
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
using System.Windows.Shapes;

namespace CinemaBB
{
    /// <summary>
    /// Логика взаимодействия для RegistWindow.xaml
    /// </summary>
    public partial class RegistWindow : Window
    {
        public RegistWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void RegBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text) ||
               string.IsNullOrEmpty(SurNameTb.Text) ||
               string.IsNullOrEmpty(LoginTb.Text) ||
               string.IsNullOrEmpty(PasswordPb.Password) ||
               string.IsNullOrEmpty(PasswordAccessPb.Password))
            {
                MessageBox.Show("Заполните все данные", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (PasswordAccessPb.Password == PasswordPb.Password)
                {
                    User user = new User()
                    {
                        Name = NameTb.Text,
                        SurName = SurNameTb.Text,
                        Login = LoginTb.Text,
                        Password = PasswordPb.Password,
                        email = emailTb.Text,
                        RoleId = 2
                        
                    };
                    App.context.User.Add(user);
                    App.context.SaveChanges();
                    MessageBox.Show("Запись добавлена", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);

                    WorkPlace workPlace = new WorkPlace();
                    workPlace.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }
    }
}
