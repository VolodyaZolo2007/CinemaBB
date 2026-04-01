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

namespace CinemaBB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text)||
                string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Заполните данными", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                App.currentUser = App.context.User.FirstOrDefault(u => u.Login == LoginTb.Text && u.Password == PasswordPb.Password);
                if (App.currentUser != null)
                {
                    WorkPlace workPlace = new WorkPlace();
                    workPlace.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверные данными", "Информация", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistWindow registWindow = new RegistWindow();
            registWindow.Show();
            this.Close();
        }
    }
}
