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
        public string Movie { get; set; }
        public int RoomNumber { get; set; }

        public Room(string movie, int roomNumber)
        {
            CreateSeats();
            this.Movie = movie;
            this.RoomNumber = roomNumber;
        }

        void CreateSeats()
        {
            for (int i = 0; i < 200; i++)
            {
                Seats?.Add(i, false);
            }
            Console.WriteLine("Seats where created for the room...");
            Thread.Sleep(1000);
        }

    }
}
