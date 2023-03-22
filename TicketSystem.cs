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
    }
}
