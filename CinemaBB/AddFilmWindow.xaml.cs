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
    /// Логика взаимодействия для AddFilmWindow.xaml
    /// </summary>
    public partial class AddFilmWindow : Window
    {
        public AddFilmWindow()
        {
            InitializeComponent();
        }

        private void AddFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            Film film = new Film()
            {
                Name = NameTb.Text,
                genre = GenreTb.Text,
                time = timeTb.Text,
                age = ageTb.Text
            };

            App.context.Film.Add(film);
            App.context.SaveChanges();

            DialogResult = true;
        }
    }
}
