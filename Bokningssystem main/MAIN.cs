namespace Bokningssystem_main
{
    internal class MAIN
    {
        static List<Lokal> lokaler = new List<Lokal>();
        static List<Bokning> bokningar = new List<Bokning>();

        static void Main(string[] args)
        {

            lokaler.Add(new Sal("Sal 1", 30, true));
            lokaler.Add(new Grupprum("Grupprum 1", 10, true));

            while (true) 
            {
                bool bookingMenu = true;
                bool listMenu = true;

                Console.Clear();
                PrintMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        while (bookingMenu)
                        {
                            Console.Clear();
                            PrintBookingMenu();
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "1":
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                case "0":
                                    bookingMenu = false;
                                    break;
                                default:
                                    if (userInput == null)
                                    {
                                        Console.WriteLine("Inget värde angavs. Försök igen.");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Felaktigt menyval");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                            }
                        }
                        break;

                    case "2":

                        while (listMenu)
                        {
                            Console.Clear();
                            PrintListMenu();
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "1":
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    break;
                                case "0":
                                    listMenu = false;
                                    break;
                                default:
                                    if (userInput == null)
                                    {
                                        Console.WriteLine("Inget värde angavs. Försök igen.");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Felaktigt menyval");
                                        Thread.Sleep(1000);
                                        break;
                                    }
                            }
                        }
                        break;
                        
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Programmet avslutas..");
                        Thread.Sleep(1000);
                        System.Environment.Exit(0);
                        break;
                    default:
                        if (userInput == null)
                        {
                            Console.WriteLine("Inget värde angavs. Försök igen.");
                            Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt menyval");
                            Thread.Sleep(1000);
                            break;
                        }
                }

            }
        }

        static void PrintMainMenu()
        {
            Console.WriteLine("╔═════════════════════════════════╗");
            Console.WriteLine("║      Bokningssystem Sigmaskolan ║");
            Console.WriteLine("╠═════════════════════════════════╣");
            Console.WriteLine("║   1. Bokning                    ║");
            Console.WriteLine("║   2. Lista bokningar/lokaler    ║");
            Console.WriteLine("║   0. Avsluta                    ║");
            Console.WriteLine("╚═════════════════════════════════╝");
            Console.Write("Välj ett alternativ: ");
        }

        static void PrintBookingMenu()
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

        static void PrintListMenu()
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
    }
}
