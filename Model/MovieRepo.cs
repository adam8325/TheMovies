using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class MovieRepo
    {
        Movies movie = new Movies();

        private string _connectionstring;

        public MovieRepo()
        {
            _connectionstring = DataAccesHelper.CNNString("MyConnection");
        }
        public List<Movies> InsertMovie(Movies movie)
        {
            List<Movies> movies = new List<Movies>();


            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = $"INSERT INTO [DB_F23_TEAM_07].[dbo].[tm_Movies] (Title, Length, Genre) VALUES (@Title, @Length, @Genre)";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", movie.Title);
                        command.Parameters.AddWithValue("@Length", movie.Length);
                        command.Parameters.AddWithValue("@Genre", movie.Genre);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return movies;
        }

    }
}
