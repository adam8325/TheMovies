using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TheMovies.ViewModel;

namespace TheMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovieController controller = new MovieController();
        public MainWindow()
        {
            DataContext = controller;
            InitializeComponent();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newMovie = new Movies
            {
                Title = Titletxt.Text,
                Length = int.Parse(Lengthtxt.Text),
                Genre = Genretxt.Text,

            };

            controller.AddMovie(newMovie);
            Titletxt.Clear();
            Lengthtxt.Clear();
            Genretxt.Clear();

        }

        private void Titletxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Tilføjbtn.IsEnabled = !string.IsNullOrWhiteSpace(Titletxt.Text);
            //Since Title cannot be null, the Button "Tilføj film" can't be clicked unless a title is added
        }

        private void Lengthtxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))       //Method makes it impossible for end user to add letter or words, and only accepts an integer
            {
                e.Handled = true;
                Errortxt.Visibility = Visibility.Visible;
            }
            else
            {
                Errortxt.Visibility = Visibility.Collapsed;
            }
        }
    }
}
