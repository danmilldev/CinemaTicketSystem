using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class Ticket
    {
        public int TicketNumber { get; set; } = 0;
        public int SeatNumber { get; set; }
        public Movie MovieToWatch { get; set; }
        public int RoomNumber { get; set; }
    
        public Ticket(int seatNumber,Movie movieToWatch,int roomNumber)
        {
            SeatNumber = seatNumber;
            MovieToWatch = movieToWatch;
            RoomNumber = roomNumber;
            TicketNumber++;
        }
    }
}
