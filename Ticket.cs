using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class Ticket
    {
        public string BuyerName { get; set; }
        public int SeatNumber { get; set; }
        public Movie MovieToWatch { get; set; }
        public int RoomNumber { get; set; }
    
        public Ticket(string buyerName, int seatNumber,Movie movieToWatch,int roomNumber)
        {
            BuyerName = buyerName;
            SeatNumber = seatNumber;
            MovieToWatch = movieToWatch;
            RoomNumber = roomNumber;
        }
    }
}
