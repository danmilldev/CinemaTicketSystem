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
        
        int roomNumber { get; set; }

        public TicketSystem() { }

        //movies
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

        public void DeleteMovie()
        {
            Console.WriteLine("---Delete Movie Menu---");
            Console.Clear();
            ShowAllMovies();

            var result = int.TryParse(Console.ReadLine(), out int movieIndex);

            if (result)
            {
                MovieList.RemoveAt(movieIndex);
            }

            Console.WriteLine("Movie was deleted...");
            Console.WriteLine("---Delete Movie Menu---");
            Thread.Sleep(2000);
        }
        //movies

        //Ticket
        //Ticket

        //Room

        public void CreateRoom()
        {
            Console.Clear();

            ShowAllMovies();

            var result = int.TryParse(Console.ReadLine(), out int movieIndex);

            if (result)
            {
                Room newRoom = new(MovieList.ElementAt(movieIndex), roomNumber++);
                RoomList.Add(newRoom);
            }

        }

        //Room
    }
}
