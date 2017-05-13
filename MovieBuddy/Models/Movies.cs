using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public float Rating { get; set; }
    }
}
