using System.Text.Json;

namespace Bokningssystem_main
{
    internal class MAIN
    {

        static void Main(string[] args)
        {
            List<Grupprum> BokadeGrupprum = new List<Grupprum>();
            List<Grupprum> AllaGrupprum = new List<Grupprum>();
            List<Sal> BokadeSalar = new List<Sal>();
            List<Sal> AllaSalar = new List<Sal>();

            if (File.Exists("salar.json"))
            {
                String loadSalar = File.ReadAllText("salar.json");
                AllaSalar = JsonSerializer.Deserialize<List<Sal>>(loadSalar) ?? new List<Sal>();
            }

            if (File.Exists("grupprum.json"))
            {
                String loadGrupprum = File.ReadAllText("grupprum.json");
                AllaGrupprum = JsonSerializer.Deserialize<List<Grupprum>>(loadGrupprum) ?? new List<Grupprum>();
            }

            if (AllaGrupprum.Count <= 3 && AllaSalar.Count <= 3)
            {
                AllaGrupprum.Add(new Grupprum { RoomNumber = "301" });
                AllaGrupprum.Add(new Grupprum { RoomNumber = "302" });
                AllaGrupprum.Add(new Grupprum { RoomNumber = "303" });

                AllaSalar.Add(new Sal { RoomNumber = "201" });
                AllaSalar.Add(new Sal { RoomNumber = "202" });
                AllaSalar.Add(new Sal { RoomNumber = "203" });

                SaveData(AllaSalar,AllaGrupprum);
            }

            bool mainMenu = true;
            while (mainMenu)
            {

                foreach (var grupprum in AllaGrupprum)
                {
                    grupprum.TimerForBookings();
                }

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
                                    Console.Clear();
                                    string roomChoice = ChooseRoomType();

                                    if (roomChoice == "Sal")
                                    {
                                        // Metod för bokning av sal
                                    }
                                    else if (roomChoice == "Grupprum")
                                    {
                                        //Loopar kollar vilka rum som är lediga
                                        foreach(var grupprum in AllaGrupprum)
                                        {
                                            if (grupprum.IsAvailable)
                                            {
                                                Console.WriteLine(grupprum.ToString());
                                                Console.WriteLine();
                                            }
                                        }
                                        
                                        //Bokar rummet genom att köra bookroom metoden()
                                        Console.WriteLine("Ange Gruppnummer: ");
                                        string nameOfGrupprumToBook = Console.ReadLine();

                                        foreach(var grupprum in AllaGrupprum)
                                        {
                                            if(nameOfGrupprumToBook == grupprum.RoomNumber)
                                            {
                                                BokadeGrupprum.Add(grupprum.BookGrupprum());
                                            }
                                        }



                                    }
                                    Thread.Sleep(1000);
                                    break;
                                case "2":
                                    Console.Clear();
                                    roomChoice = ChooseRoomType();

                                    if (roomChoice == "Sal")
                                    {
                                        // Metod för uppdater bokning av sal
                                    }
                                    else if (roomChoice == "Grupprum")
                                    {
                                        // Metod för uppdatera bokning av grupprum
                                    }
                                    Thread.Sleep(1000);
                                    break;
                                case "3":
                                    Console.Clear();
                                    roomChoice = ChooseRoomType();

                                    if (roomChoice == "Sal")
                                    {
                                        // Metod för ta bort bokning av sal
                                    }
                                    else if (roomChoice == "Grupprum")
                                    {
                                        // Metod för ta bort bokning av grupprum
                                    }
                                    Thread.Sleep(1000);
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
                                    Console.Clear();
                                    string roomChoice = ChooseRoomType();

                                    if (roomChoice == "Sal")
                                    {
                                        // Metod för se alla bokningar av salar
                                    }
                                    else if (roomChoice == "Grupprum")
                                    {
                                        foreach(var grupprum in BokadeGrupprum)
                                        {
                                            if (!grupprum.IsAvailable)
                                            {
                                                grupprum.ShowBookings();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Det finns inga bokningar");
                                            }
                                        }
                                    }
                                    Thread.Sleep(1000);
                                    break;
                                case "2":
                                    Console.Clear();
                                    roomChoice = ChooseRoomType();

                                    if (roomChoice == "Sal")
                                    {
                                        // Metod för lista bokningar av salar från specifikt år
                                    }
                                    else if (roomChoice == "Grupprum")
                                    {
                                        Console.WriteLine("Vilket år vill du söka efter?");
                                        int year = int.Parse(Console.ReadLine());

                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (year == grupprum.StartTime.Year)
                                            {
                                                grupprum.ShowBookings();
                                                Console.ReadLine();
                                            }

                                        }
                                    }
                                    Thread.Sleep(1000);
                                    break;
                                case "3":
                                    Console.Clear();
                                    roomChoice = ChooseRoomType();

                                    if (roomChoice == "Sal")
                                    {
                                        // Metod för se alla salar
                                    }
                                    else if (roomChoice == "Grupprum")
                                    {
                                        Console.WriteLine("[Lediga Grupprum]");
                                        // Metod för se alla grupprum
                                        foreach (var grupprum in AllaGrupprum)
                                        {
                                            grupprum.ShowAvailableRooms();
                                        }
                                        Console.ReadLine();
                                    }
                                    Thread.Sleep(1000);
                                    break;
                                case "4":
                                    // Metod för att skapa sal
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
        static void SaveData(List<Sal> allaSalar, List<Grupprum> allaGrupprum)
        {
            string jsonSalar = JsonSerializer.Serialize(allaSalar);
            string jsonGrupprum = JsonSerializer.Serialize(allaGrupprum);

            File.WriteAllText("salar.json", jsonSalar);
            File.WriteAllText("grupprum.json", jsonGrupprum);
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

        static string ChooseRoomType()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════╗");
                Console.WriteLine("║       Välj rumstyp              ║");
                Console.WriteLine("╠═════════════════════════════════╣");
                Console.WriteLine("║   1. Sal                        ║");
                Console.WriteLine("║   2. Grupprum                   ║");
                Console.WriteLine("╚═════════════════════════════════╝");
                Console.Write("Välj ett alternativ (1 eller 2): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    return "Sal";
                }
                else if (choice == "2")
                {
                    return "Grupprum";
                }
                else
                {
                    Console.WriteLine("Felaktigt val. Försök igen.");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
