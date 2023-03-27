using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal partial class TicketSystem
    {
        public List<Ticket> TicketList { get; set; } = new();
        public List<Room> RoomList { get; set; } = new();
        public List<Movie> MovieList { get; set; } = new();

        int RoomNumber { get; set; } = 0;

        int TicketNumber { get; set; } = 0;

        public TicketSystem() { }
    }

    internal partial class TicketSystem
    {
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

        public void ChangeMovieInRoom()
        {
            throw new NotImplementedException();
        }

        //movies
    }

    internal partial class TicketSystem
    {
        //Ticket

        public int TakeSeat(Room room)
        {
            var searchRoom = RoomList.ElementAt(room.RoomNumber - 1);

            var seat = new Random().Next(0, searchRoom.Seats.Count);

            if (searchRoom.Seats[seat] is not true)
            {
                searchRoom.Seats[seat] = true;
            }
            else
            {
                TakeSeat(room);
                Console.WriteLine("Searching free seat...");
            }

            return seat;
        }

        public void CreateTicket()
        {
            ShowAllMovies();
            Console.Write("Movie Number: ");


            if (MovieList.Any())
            {
                var result = int.TryParse(Console.ReadLine(), out int movieIndex);
                var searchedRoom = RoomList.Where(room => room.Movie.MovieName == MovieList.ElementAt(movieIndex).MovieName).FirstOrDefault();

                var seat = 0;

                if (searchedRoom is not null)
                {
                    seat = TakeSeat(searchedRoom);
                    Console.Clear();
                }

                Console.WriteLine("-----NEW TICKET-----");
                Console.WriteLine("TicketNumber: " + ++TicketNumber + " MovieName: " + searchedRoom.Movie.MovieName + "RoomNumber "+ searchedRoom.RoomNumber +  " SeatNumber: " + seat);

                Ticket ticket = new(seat,searchedRoom.Movie,searchedRoom.RoomNumber);

                TicketList.Add(ticket);
            }
            else
            {
                Console.WriteLine("No Movies Playing so you cant make a Room");
            }
        }


        public void ShowAllTickets()
        {
            Console.WriteLine("-----TICKETLIST-----");

            foreach (var Ticket in TicketList)
            {
                Console.WriteLine("TicketNumber: " + Ticket.TicketNumber + " Movie: " + Ticket.MovieToWatch.MovieName + " SeatNumber: " 
                    + Ticket.SeatNumber + " RoomNumber: " + Ticket.RoomNumber);
            }

            Console.WriteLine("-----TICKETLIST-----");
        }

        public void DeleteTicket()
        {
            Console.WriteLine("-----TICKET DELETION-----");


            if(TicketList.Any())
            {
                ShowAllTickets();
                Console.Write("Ticket To Delete: ");

                var result = int.TryParse(Console.ReadLine(), out int ticketNumberLookingFor);

                if (result)
                {
                    var searchedTicket = TicketList.Where(ticket => ticket.TicketNumber == ticketNumberLookingFor).FirstOrDefault();
                    
                    if(searchedTicket is not null)
                    {
                        TicketList.Remove(searchedTicket);
                    }
                }
                else
                {
                    Console.WriteLine("Not an applicable Ticket");
                    DeleteTicket();
                }
            }
            else
            {
                Console.WriteLine("There are no Tickets to delete.");
            }

            Console.WriteLine("-----TICKET DELETION-----");
        }

        //Ticket
    }


    internal partial class TicketSystem
    {
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
                        Room newRoom = new(MovieList.ElementAt(movieIndex), ++RoomNumber, numOfSeats);
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

            var result = int.TryParse(Console.ReadLine(), out int roomNumber);

            if (result)
            {
                var searchedRoom = RoomList.Where(room => room.RoomNumber == roomNumber).FirstOrDefault();

                if (searchedRoom is not null)
                {
                    RoomList.Remove(searchedRoom);
                    Console.WriteLine("Room " + searchedRoom.RoomNumber + " was deleted!");
                }
            }
            roomNumber--;
        }

        //Room
    }
}
