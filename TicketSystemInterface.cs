using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    internal class TicketSystemInterface
    {
        TicketSystem system = new();

        void Print(string text) => Console.WriteLine(text);

        public void TicketMenu()
        {
            Print("---Menu---");
            Print("1. Create-Menu");
            Print("2. Read-Menu");
            Print("3. Update-Menu");
            Print("4. Delete-Menu");
            Console.Write("MenuOption: ");

            HandleInput(false, CreatingMenu, ReadingMenu, UpdateMenu, DeleteMenu);
        }

        public void HandleInput(bool shouldReturnMain,Action method1, Action? method2 = null, Action? method3 = null, Action? method4 = null)
        {
            int input;

            Console.Write("Input: ");

            var inputResult = int.TryParse(Console.ReadLine(), out input);

            if (inputResult)
            {
                switch (input)
                {
                    case 1:
                        method1?.Invoke();
                        break;
                    case 2:
                        method2?.Invoke();
                        break;
                    case 3:
                        method3?.Invoke();
                        break;
                    case 4:
                        method4?.Invoke();
                        break;
                    default:
                        Console.WriteLine(input + "  is not an option.");
                        break;
                }
            }
            if (shouldReturnMain)
            {
                TicketMenu();
            }
        }

        public void CreatingMenu()
        {
            Console.Clear();
            Print("-------Creating--------");
            Print("\t 1.Create a Movie");
            Print("\t 2.Create a room");
            Print("\t 3.Create a Ticket");
            Print("\t 4.Back To Main Menu");
            Print("-------Creating--------");

            HandleInput(true,system.CreateMovie,system.CreateRoom);
        }

        public void ReadingMenu()
        {
            Console.Clear();
            Print("-------Reading--------");
            Print("\t 1.View all Movie");
            Print("\t 2.View all room");
            Print("\t 3.View all Ticket");
            Print("\t 4.Back To Main Menu");
            Print("-------Reading--------");

            HandleInput(true, system.ShowAllMovies,system.ShowRooms);
        }

        public void UpdateMenu()
        {
            Console.Clear();
            Print("-------Update--------");
            Print("\t 1.Add Movie to Room");
            Print("\t 2.Add Movie and Seat to Ticket");
            Print("\t 4.Back To Main Menu");
            Print("-------Update--------");
        }

        public void DeleteMenu()
        {
            Console.Clear();
            Print("-------Delete--------");
            Print("\t 1.Delete a Movie");
            Print("\t 2.Delete a room");
            Print("\t 3.Delete a Ticket");
            Print("\t 4.Back To Main Menu");
            Print("-------Delete--------");

            HandleInput(true, system.DeleteMovie,system.DeleteRoom);
        }

    }
}
