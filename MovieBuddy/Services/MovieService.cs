using MovieBuddy.Helper;
using MovieBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Services
{
    public static class MovieService
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie { Name = "The Shawshank Redemption", Genres = new List<string> { "crime", "drama" }, Rating = 9.2f },
            new Movie { Name = "The Godfather", Genres = new List<string> { "crime", "drama" }, Rating = 9.2f },
            new Movie { Name = "The Dark Knight", Genres = new List<string> { "action", "crime", "drama", "thriller" }, Rating = 8.9f },
            new Movie { Name = "Pulp Fiction", Genres = new List<string> { "crime", "drama" }, Rating = 8.9f },
            new Movie { Name = "The Matrix", Genres = new List<string> { "action", "adventure", "sci-fi", "thriller" }, Rating = 8.7f },
            new Movie { Name = "Inception", Genres = new List<string> { "action", "adventure", "sci-fi", "thriller" }, Rating = 8.7f },
        };

        public static Movie Get(string genre = null, string previousMovie = null)
        {
            var length = 0;
            List<Movie> filteredList;
            if (genre.IsNull())
            {
                filteredList = _movies.Where(t => t.Name != previousMovie).ToList();
                length = _movies.Count();
            }
            else
            {
                filteredList = _movies.Where(t => t.Genres.Contains(genre) && t.Name != previousMovie).ToList();
                length = filteredList.Count();
            }
            if (length == 0)
            {
                return null;
            }
            var index = new Random().Next(0, length);
            return filteredList[index];
        }
    }
}
