using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class Room
    {

        public Dictionary<int,bool> Seats { get; set; } = new();
        public Movie Movie { get; set; }
        public int RoomNumber { get; set; }

        public Room(Movie movie, int roomNumber, int numberOfSeats)
        {
            CreateSeats(numberOfSeats);
            this.Movie = movie;
            this.RoomNumber = roomNumber;
        }

        void CreateSeats(int numberOFSeats)
        {
            for (int i = 0; i < numberOFSeats; i++)
            {
                Seats?.Add(i, false);
            }
            Console.WriteLine("Seats where created for the room...");
            Thread.Sleep(1000);
        }

    }
}
