using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class TicketSystemInterface
    {


        void Print(string text) => Console.WriteLine(text);

        public void TicketMenu()
        {
            Print("---Menu---");
            Print("1. Create-Menu");
            Print("1. Read-Menu");
            Print("1. Update-Menu");
            Print("1. Delete-Menu");
        }

        public void CreatingMenu()
        {
            Console.Clear();
            Print("-------Creating--------");
            Print("\t 1.Create a Movie");
            Print("\t 2.Create a room");
            Print("\t 3.Create a Ticket");
            Print("-------Creating--------");
        }

        public void ReadingMenu()
        {
            Console.Clear();
            Print("-------Reading--------");
            Print("\t 1.View all Movie");
            Print("\t 2.View all room");
            Print("\t 3.View all Ticket");
            Print("-------Reading--------");
        }

        public void UpdateMenu()
        {
            Console.Clear();
            Print("-------Update--------");
            Print("\t 1.Add Movie to Room");
            Print("\t 2.Add Movie and Seat to Ticket");
            Print("-------Update--------");
        }

        public void DeleteMenu()
        {
            Console.Clear();
            Print("-------Delete--------");
            Print("\t 1.Delete a Movie");
            Print("\t 2.Delete a room");
            Print("\t 3.Delete a Ticket");
            Print("-------Delete--------");
        }

    }
}
