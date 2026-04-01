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
    /// Логика взаимодействия для Films.xaml
    /// </summary>
    public partial class Films : Window
    {
         List<Film> _films ; 
        public Films()
        {
            InitializeComponent();

            LoadedData();
        }

        public void LoadedData()
        {

            _films = App.context.Film.ToList();
            FilmLb.ItemsSource = _films;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchBox.Text.ToLower();

            FilmLb.ItemsSource = _films.Where(f => f.Name.ToLower().Contains(search)).ToList();

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Film selectFilm = FilmLb.SelectedItem as Film;
            try
            {
                App.context.Film.Remove(selectFilm);
                App.context.SaveChanges();

                LoadedData();
            }
            catch (Exception)
            {

                MessageBox.Show("Выберите Фильм для удаления");
            }
        }

        private void AddFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            AddFilmWindow addFilmWindow = new AddFilmWindow();
            addFilmWindow.ShowDialog();

            LoadedData();
        }
    }
}
