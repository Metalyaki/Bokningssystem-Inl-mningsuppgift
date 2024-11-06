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

            //Test grupprum
            Grupprum grupprum1 = new Grupprum();
            grupprum1.RoomNumber = "301";
            grupprum1.Capacity = 9;
            grupprum1.HasProjector = false;
            grupprum1.HasWhiteBoard = true;
            grupprum1.IsAvailable = true;

            Grupprum grupprum2 = new Grupprum();
            grupprum2.RoomNumber = "302";
            grupprum2.Capacity = 10;
            grupprum2.HasProjector = false;
            grupprum2.HasWhiteBoard = true;
            grupprum2.IsAvailable = true;

            Grupprum grupprum3 = new Grupprum();
            grupprum3.RoomNumber = "303";
            grupprum3.Capacity = 11;
            grupprum3.HasProjector = false;
            grupprum3.HasWhiteBoard = true;
            grupprum3.IsAvailable = true;
            
            AllaGrupprum.Add(grupprum1);
            AllaGrupprum.Add(grupprum2);
            AllaGrupprum.Add(grupprum3);



            bool mainMenu = true;

            while (true)
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
                                        Console.WriteLine("[Lediga Grupprum]");
                                        foreach(var grupprum in AllaGrupprum)
                                        {
                                            if (grupprum.IsAvailable == true)
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
                                        Console.WriteLine("[Bokade Grupprum]");
                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (grupprum.IsAvailable == false)
                                            {
                                                Console.WriteLine(grupprum.ToString());
                                                Console.WriteLine();
                                            }
                                        }


                                        Console.WriteLine("Ange Gruppnummer: ");
                                        string nameOfGrupprumToUnBook = Console.ReadLine();

                                        foreach (var grupprum in AllaGrupprum)
                                        {
                                            if (nameOfGrupprumToUnBook == grupprum.RoomNumber)
                                            {
                                                BokadeGrupprum.Remove(grupprum.UnbookGrupprum());
                                            }

                                        }
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

                                        // Metod för se alla bokningar av Grupprum
                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (BokadeGrupprum.Count == 0)
                                            {
                                                Console.WriteLine("Det finns inga bokningar");
                                            }
                                            else
                                            {
                                                if (!grupprum.IsAvailable)
                                                {
                                                    grupprum.ShowBookings();
                                                    
                                                }
                                                Console.ReadLine();
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
                                        // Metod för lista bokningar av Grupprum från specifikt år
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
