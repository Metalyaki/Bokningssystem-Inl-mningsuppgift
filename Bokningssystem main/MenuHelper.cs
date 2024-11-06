using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    internal static class MenuHelper
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║    Bokningssystem Sigmaskolan   ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Bokning                    ║");
            Console.WriteLine("║   2. Lista bokningar/lokaler    ║");
            Console.WriteLine("║   3. Inställningar              ║");
            Console.WriteLine("║   0. Avsluta                    ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");
        }

        public static void PrintBookingMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║             Bokning             ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Skapa bokning              ║");
            Console.WriteLine("║   2. Uppdatera bokning          ║");
            Console.WriteLine("║   3. Ta bort bokning            ║");
            Console.WriteLine("║   0. Backa till menyn           ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");
        }

        public static void PrintListMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║         Bokningar/Lokaler       ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Se bokningar               ║");
            Console.WriteLine("║   2. Sök bokning                ║");
            Console.WriteLine("║   3. Se lokaler                 ║");
            Console.WriteLine("║   4. Skapa lokal                ║");
            Console.WriteLine("║   0. Backa till menyn           ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");
        }

        public static void PrintSettingsMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║         Inställningar           ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Sortera bokningar          ║");
            Console.WriteLine("║   2. Ändra textfärg             ║");
            Console.WriteLine("║   0. Backa till menyn           ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");
        }

        public static string ChooseRoomType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════╗");
                Console.WriteLine("║       Välj rumstyp              ║");
                Console.WriteLine("╠═════════════════════════════════╣");
                Console.WriteLine("║   1. Sal                        ║");
                Console.WriteLine("║   2. Grupprum                   ║");
                Console.WriteLine("║   0. Backa till menyn           ║");
                Console.WriteLine("╚═════════════════════════════════╝");
                Console.Write("Välj ett alternativ: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    return "Sal";
                }
                else if (choice == "2")
                {
                    return "Grupprum";
                }
                else if (choice == "0")
                {
                    return "0";
                }
                else
                {
                    Console.WriteLine("Felaktigt val. Försök igen.");
                    Thread.Sleep(1000);
                }
            }
        }

        public static void PrintTextColorMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║            Textfärg             ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Vit                        ║");
            Console.WriteLine("║   2. Röd                        ║");
            Console.WriteLine("║   3. Grön                       ║");
            Console.WriteLine("║   4. Blå                        ║");
            Console.WriteLine("║   5. Rosa                       ║");
            Console.WriteLine("║   0. Backa till menyn           ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");

        }

        public static void PrintSortingMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║        Sortera bokningar        ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Namn Stigande              ║");
            Console.WriteLine("║   2. Namn Fallande              ║");
            Console.WriteLine("║   3. Datum Stigande             ║");
            Console.WriteLine("║   4. Datum Fallande             ║");
            Console.WriteLine("║   5. Längd Stigande             ║");
            Console.WriteLine("║   6. Längd Fallande             ║");
            Console.WriteLine("║   0. Backa till menyn           ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");

        }
    }
}
