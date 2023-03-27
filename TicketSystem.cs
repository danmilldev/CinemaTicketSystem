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

        int roomNumber { get; set; } = 0;

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
            TimeSpan movieDuration = new TimeSpan(movieDurationFinalHours, movieDurationFinalMinutes, 0);

            movie.MovieName = movieName;
            movie.Duration = movieDuration;

            MovieList.Add(movie);
        }

        public void ShowAllMovies()
        {
            int index = 0;
            Console.WriteLine("---Movies---");

            if (MovieList.Any())
            {
                foreach (var movies in MovieList)
                {
                    Console.WriteLine(index++ + ". Name: " + movies.MovieName + " | Duration: " + movies.Duration.Hours + " h " + movies.Duration.Minutes + " min");
                }
            }
            else
            {
                Console.WriteLine("There are currently no Movies Available.");
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

            //Check if any Movies even exist
            if (MovieList.Any())
            {
                var result = int.TryParse(Console.ReadLine(), out int movieIndex);

                if (result)
                {
                    Console.WriteLine("How many Seats do you want?");
                    Console.Write("Amount: ");

                    var result2 = int.TryParse(Console.ReadLine(), out int numOfSeats);

                    if (result2)
                    {
                        Room newRoom = new(MovieList.ElementAt(movieIndex), ++roomNumber, numOfSeats);
                        RoomList.Add(newRoom);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Movies Playing so you cant make a Room");
            }

        }

        public void ShowRooms()
        {
            Console.WriteLine("-----ROOMS-----");
            foreach (var room in RoomList)
            {
                Console.WriteLine("RoomNumber: " + room.RoomNumber + " | " + " Movie: " + room.Movie.MovieName + " SeatAmount: " + room.Seats.Where(seat => seat.Value == false).Count());
            }
            Console.WriteLine("-----ROOMS-----");
        }

        public void DeleteRoom()
        {
            Console.WriteLine("---Delete Movie Menu---");
            Console.Clear();
            ShowRooms();

            var result = int.TryParse(Console.ReadLine(),out int roomNumber);

            if(result)
            {
                var searchedRoom = RoomList.Where(room => room.RoomNumber == roomNumber).FirstOrDefault();

                if(searchedRoom is not null)
                {
                    RoomList.Remove(searchedRoom);
                    Console.WriteLine("Room " + searchedRoom.RoomNumber + " was deleted!");
                }
            }
        }

        //Room


    }
}
