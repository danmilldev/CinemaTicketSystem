using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class Ticket
    {

        public string BuyerName { get; set; } = "NoBuyerNBameSet";
        public int SeatNumber { get; set; } = 0;
        public string MovieName { get; set; } = "NoMovieNameSet";
        public int RoomNumber { get; set; } = 0;
    
        public Ticket()
        {

        }
    }
}
