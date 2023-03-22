using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class Room
    {

        public int Seats { get; set; }
        public string Movie { get; set; }
        public int RoomNumber { get; set; }

        public Room(int seats, string movie, int roomNumber)
        {
            this.Seats = seats;
            this.Movie = movie;
            this.RoomNumber = roomNumber;
        }

    }
}
