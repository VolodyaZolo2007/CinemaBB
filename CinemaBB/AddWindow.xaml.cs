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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                SurName = SurNameTb.Text,
                Name = SurNameTb.Text,
                Login = LoginTb.Text,
                Password = PasswordTb.Text,
                email = emailTb.Text,
                RoleId = 1
            };

            App.context.User.Add(user);
            App.context.SaveChanges();
            MessageBox.Show("Пользователь добавлен");
            DialogResult = true;
        }
    }
}
