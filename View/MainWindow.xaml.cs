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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button Clicked!");

            var newMovie = new Movies
            {
                Title = Titletxt.Text,
                Length = int.Parse(Lengthtxt.Text),
                Genre = Genretxt.Text,

            };

            controller.AddMovie(newMovie);

        }
    }
}
