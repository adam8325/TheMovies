using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.ViewModel
{
    public class MovieController
    {
        public ObservableCollection<Movies> MoviesList { get; set; }
        public MovieRepo repo;

        public MovieController()
        {
            repo = new MovieRepo();
            MoviesList = new ObservableCollection<Movies>();
        }

        public void AddMovie(Movies movie)
        {
            repo.InsertMovie(movie);
            MoviesList.Add(movie);
        }
    }
}
