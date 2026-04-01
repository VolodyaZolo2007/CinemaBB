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
    /// Логика взаимодействия для WorkPlace.xaml
    /// </summary>
    public partial class WorkPlace : Window
    {
        List<User> users = App.context.User.ToList();
        public WorkPlace()
        {
            InitializeComponent();
           var pol = App.context.User.Where(u => u.RoleId == 1).ToList();
            UsersLb.ItemsSource = pol;
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
           
                var user = users.Where(u => u.Name.ToLower().Contains(SearchTb.Text.ToLower()) ||
                                            u.SurName.ToLower().Contains(SearchTb.Text.ToLower()));

                UsersLb.ItemsSource = user.Where(u => u.RoleId == 1).ToList();

            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();

            if (addWindow.ShowDialog() == true)
            {

                var pol = App.context.User.Where(u => u.RoleId == 1).ToList();
                UsersLb.ItemsSource = pol;

            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            User selectUser = UsersLb.SelectedItem as User;
            try
            {
                App.context.User.Remove(selectUser);
                App.context.SaveChanges();

                var pol = App.context.User.Where(u => u.RoleId == 1).ToList();
                UsersLb.ItemsSource = pol;
            }
            catch (Exception)
            {

                MessageBox.Show("Выберите пользователя для удаления");
            }
        }

        private void FilmBtn_Click(object sender, RoutedEventArgs e)
        {
            Films films = new Films();
            films.ShowDialog();
        }
    }
}
