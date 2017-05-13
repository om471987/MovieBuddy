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
            new Movie { Name = "The Shawshank Redemption", Genre = new List<string> { "crime", "drama" } },
            new Movie { Name = "The Godfather", Genre = new List<string> { "crime", "drama" } },
            new Movie { Name = "The Dark Knight", Genre = new List<string> { "action", "crime", "drama", "thriller" } },
            new Movie { Name = "Pulp Fiction", Genre = new List<string> { "crime", "drama" } },
            new Movie { Name = "The Matrix", Genre = new List<string> { "action", "adventure", "sci-fi", "thriller" } },
            new Movie { Name = "Inception", Genre = new List<string> { "action", "adventure", "sci-fi", "thriller" } },
        };

        public static string Get(string genre = null)
        {
            if (genre.IsNull())
            {
                var length = _movies.Count();
                var index = new Random().Next(0, length);
                return _movies[index].Name;
            }
            else
            {
                var filteredList = _movies.Where(t => t.Genre.Contains(genre)).ToList();
                var length = filteredList.Count();
                if (length == 0)
                {
                    return null;
                }
                var index = new Random().Next(0, length);
                return filteredList[index].Name;
            }
        }
    }
}
