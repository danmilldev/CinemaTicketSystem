using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class Movie
    {
        public string MovieName { get; set; }
        public TimeSpan Duration { get; set; } = new();
    }
}
