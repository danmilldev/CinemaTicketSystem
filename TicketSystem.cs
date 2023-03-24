using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class TicketSystem
    {
        public List<Ticket> TicketList { get; set; } = new();
        public List<Room> RoomList { get; set; } = new();
        public List<Movie> MovieList { get; set; } = new();

        public TicketSystem() { }

        public void CreateMovie()
        {
            Movie movie = new Movie();

            Console.WriteLine("Name Of the Movie: ");
            Console.Write("Name: ");
            string movieName = Console.ReadLine();

            Console.Write("MovieDuration:");
            int movieDurationInMinuts = int.Parse(Console.ReadLine());
            int movieDurationFinalMinutes = movieDurationInMinuts % 60;
            int movieDurationFinalHours = movieDurationInMinuts / 60;
            TimeSpan movieDuration = new TimeSpan(movieDurationFinalHours,movieDurationFinalMinutes,0);

            movie.MovieName = movieName ?? "NoMovieNameSet";
            movie.Duration = movieDuration;

            MovieList.Add(movie);
        }

        public void ShowAllMovies()
        {
            int index = 0;
            Console.WriteLine("---Movies---");
            foreach (var movies in MovieList)
            {
                Console.WriteLine(index++ + ". Name: " + movies.MovieName + " | Duration: " + movies.Duration.Hours + " h " + movies.Duration.Minutes + " min");
            }
            Console.WriteLine("---Movies---");
        }
    }
}
