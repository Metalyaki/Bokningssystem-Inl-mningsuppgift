using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Bokningssystem_main
{
    internal class MAIN
    {

        static void Main(string[] args)
        {
            List<Grupprum> BokadeGrupprum = DataManager.LoadBookedGrupprum();
            List<Grupprum> AllaGrupprum = DataManager.LoadGrupprum();
            List<Sal> BokadeSalar = DataManager.LoadBookedSal();
            List<Sal> AllaSalar = DataManager.LoadSalar();

            if (AllaGrupprum.Count < 3 && AllaSalar.Count < 3)
            {
                AllaGrupprum.Add(new Grupprum { RoomNumber = "301", Capacity = 6, HasProjector = false, HasWhiteBoard = true, IsAvailable = true});
                AllaGrupprum.Add(new Grupprum { RoomNumber = "302", Capacity = 8, HasProjector = false, HasWhiteBoard = false, IsAvailable = true });
                AllaGrupprum.Add(new Grupprum { RoomNumber = "303", Capacity = 12, HasProjector = true, HasWhiteBoard = true, IsAvailable = true });
                                                                                                                             
                AllaSalar.Add(new Sal { RoomNumber = "201", Capacity = 33, HasProjector = true, HasWhiteBoard = false, IsAvailable = true });
                AllaSalar.Add(new Sal { RoomNumber = "202", Capacity = 40, HasProjector = true, HasWhiteBoard = true , IsAvailable = true });
                AllaSalar.Add(new Sal { RoomNumber = "203", Capacity = 28, HasProjector = false, HasWhiteBoard = true , IsAvailable = true });

                DataManager.SaveData(AllaSalar,AllaGrupprum);
            }

            bool mainMenu = true;
            while (mainMenu)
            {
                bool settingsMenu = true;
                //Loop som kollar när de bokade grupprum/salar blir lediga när tiden går ut 
                foreach (var grupprum in BokadeGrupprum)
                {
                    grupprum.TimerForBookings();
                }
                foreach (var sal in BokadeSalar)
                {
                    sal.TimerForBookings();
                }

                Console.Clear();
                MenuHelper.PrintMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        bool bookingMenu = true;
                        while (bookingMenu)
                        {
                            Console.Clear();
                            MenuHelper.PrintBookingMenu();
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "1":
                                    Console.Clear();
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        // Metod för bokning av sal
                                        //Loopar kollar vilka rum som är lediga
                                        Console.WriteLine("[Lediga Salar]");
                                        foreach (var sal in AllaSalar)
                                        {
                                            if (sal.IsAvailable == true)
                                            {
                                                Console.WriteLine(sal.ToString());
                                                Console.WriteLine();
                                            }
                                        }

                                        //Bokar rummet genom att köra bookroom metoden()
                                        Console.WriteLine("Ange rumsnummer:");
                                        string nameOfSalToBook = Console.ReadLine();
                                        bool foundFreeSal = false;

                                        foreach (var sal in AllaSalar)
                                        {
                                            if (nameOfSalToBook == sal.RoomNumber)
                                            {
                                                foundFreeSal = true;
                                                BokadeSalar.Add(sal.BookSal());
                                            }
                                            
                                        }
                                        if (!foundFreeSal)
                                        {
                                            Console.WriteLine($"Hitta ingen lediga sal med rumsnummer: {nameOfSalToBook}");
                                            Console.ReadLine();
                                        }

                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för bokning av Grupprum
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
                                        Console.WriteLine("Ange rumsnummer:");
                                        bool foundFreeGrupprum = false;
                                        string nameOfGrupprumToBook = Console.ReadLine();

                                        foreach (var grupprum in AllaGrupprum)
                                        {
                                            if(nameOfGrupprumToBook == grupprum.RoomNumber)
                                            {
                                                foundFreeGrupprum = true;
                                                BokadeGrupprum.Add(grupprum.BookGrupprum());
                                            }
                                            
                                        }
                                        if (!foundFreeGrupprum)
                                        {
                                            Console.WriteLine($"Hitta ingen lediga sal med rumsnummer: {nameOfGrupprumToBook}");
                                            Console.ReadLine();
                                        }

                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        // Metod för uppdatera bokning av sal
                                        var sal = new Sal();
                                        sal.UpdateASalBooking(BokadeSalar);
                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för uppdatera bokning av grupprum

                                        var grupprum = new Grupprum();
                                        grupprum.UpdateABooking(BokadeGrupprum);
                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    Thread.Sleep(1000);
                                    break;
                                case "3":
                                    Console.Clear();
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        // Metod för att ta bort bokning av sal
                                        //Loopar kollar vilka rum som är bokade och av vem
                                        Console.WriteLine("[Bokade Salar]");
                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (sal.IsAvailable == false)
                                            {
                                                sal.ShowBookings();
                                                Console.WriteLine();
                                            }
                                        }

                                        
                                        Console.WriteLine("Ange rumsnummer:");
                                        string unbookSal = Console.ReadLine();

                                        Console.WriteLine("Ange namn:");
                                        string name = Console.ReadLine();

                                        bool foundSal = false;
                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (unbookSal == sal.RoomNumber && name == sal.User)
                                            {
                                                foundSal = true;
                                                sal.UnbookSal();
                                                Console.WriteLine($"Avbokade Grupprum: {unbookSal}");
                                            }

                                        }
                                        if (!foundSal)
                                        {
                                            Console.WriteLine($"Hittade inga grupprumsnummer: {unbookSal} under namnet: {name}");
                                            Console.ReadLine();
                                        }
                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för att ta bort bokning av grupprum
                                        //Loopar kollar vilka rum som är bokade och av vem
                                        Console.WriteLine("[Bokade Grupprum]");
                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (grupprum.IsAvailable == false)
                                            {
                                                grupprum.ShowBookings();
                                                Console.WriteLine();
                                            }
                                        }

                                        
                                        Console.WriteLine("Ange rumsnummer:");
                                        string unbookGrupprum = Console.ReadLine();

                                        Console.WriteLine("Ange namn:");
                                        string name = Console.ReadLine();

                                        bool foundGrupprum = false;
                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (unbookGrupprum == grupprum.RoomNumber && name == grupprum.User)
                                            {
                                                foundGrupprum = true;
                                                grupprum.UnbookGrupprum();
                                                Console.WriteLine($"Avbokade Grupprum: {unbookGrupprum}");
                                            }

                                        }
                                        if (!foundGrupprum)
                                        {
                                            Console.WriteLine($"Hittade inga grupprumsnummer: {unbookGrupprum} under namnet: {name}");
                                            Console.ReadLine();
                                        }

                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
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

                        bool listMenu = true;
                        while (listMenu)
                        {
                            Console.Clear();
                            MenuHelper.PrintListMenu();
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "1":
                                    Console.Clear();
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        bool foundBookedSal = false;
                                        // Metod för se alla bokningar av salar
                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (!sal.IsAvailable)
                                            {
                                                foundBookedSal = true;
                                                sal.ShowBookings();
                                                Console.WriteLine();
                                            }
                                            
                                            
                                        }
                                        if (!foundBookedSal)
                                        {
                                            Console.WriteLine("Det finns inga bokade Salar");
                                            
                                        }
                                        Console.ReadLine();
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för se alla bokningar av Grupprum
                                        bool foundBookedGrupprum = false;
                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (!grupprum.IsAvailable)
                                            {
                                                foundBookedGrupprum = true;
                                                grupprum.ShowBookings();
                                                Console.WriteLine();
                                            }
                                            
                                        }
                                        if (!foundBookedGrupprum)
                                        {
                                            Console.WriteLine("Det finns inga bokade Grupprum");
                                            
                                        }
                                        Console.ReadLine();
                                    }
                                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn");
                                    Console.ReadKey();
                                    Thread.Sleep(1000);
                                    break;
                                case "2":
                                    Console.Clear();
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        // Metod för lista bokningar av salar från specifikt år

                                        Console.WriteLine("Vilket år vill du söka efter?");
                                        int year = int.Parse(Console.ReadLine());

                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (year == sal.StartTime.Year)
                                            {
                                                sal.ShowBookings();
                                            }
                                        }
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för lista bokningar av Grupprum från specifikt år
                                        Console.WriteLine("Vilket år vill du söka efter?");
                                        int year = int.Parse(Console.ReadLine());

                                        foreach (var grupprum in BokadeGrupprum)
                                        {
                                            if (year == grupprum.StartTime.Year)
                                            {
                                                grupprum.ShowBookings();
                                            }
                                           

                                        }
                                    }
                                    Console.WriteLine("Tryck valfri tangent för att återgå till menyn");
                                    Console.ReadKey();
                                    Thread.Sleep(1000);
                                    break;
                                case "3":
                                    Console.Clear();
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        Console.WriteLine("[Lediga Salar]");
                                        // Metod för se alla grupprum
                                        foreach (var sal in AllaSalar)
                                        {
                                            sal.ShowAvailableRooms();
                                        }
                                        Console.ReadLine();
                                    }
                                    else if (userInput == "Grupprum")
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
                                    DataManager.SaveData(AllaSalar, AllaGrupprum);
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
                    case "3":
                        settingsMenu = true;
                        while (settingsMenu)
                        {
                            Console.Clear();
                            MenuHelper.PrintSettingsMenu();
                            userInput = Console.ReadLine();
                            switch (userInput)
                            {
                                case "1":

                                    bool sortingMenu = true;
                                    while (sortingMenu)
                                    {
                                        Console.Clear();
                                        MenuHelper.PrintSortingMenu();
                                        userInput = Console.ReadLine();

                                        switch (userInput)
                                        {
                                            case "1":
                                                BokadeGrupprum = BokadeGrupprum.OrderBy(gr => gr.User).ToList();
                                                BokadeSalar = BokadeSalar.OrderBy(sal => sal.User).ToList();
                                                Console.WriteLine("Bokningslista sorterad");
                                                Thread.Sleep(1000);
                                                break;
                                            case "2":
                                                BokadeGrupprum = BokadeGrupprum.OrderByDescending(gr => gr.User).ToList();
                                                BokadeSalar = BokadeSalar.OrderByDescending(sal => sal.User).ToList();
                                                Console.WriteLine("Bokningslista sorterad");
                                                Thread.Sleep(1000);
                                                break;
                                            case "3":
                                                BokadeGrupprum = BokadeGrupprum.OrderBy(gr => gr.StartTime).ToList();
                                                BokadeSalar = BokadeSalar.OrderBy(sal => sal.StartTime).ToList();
                                                Console.WriteLine("Bokningslista sorterad");
                                                Thread.Sleep(1000);
                                                break;
                                            case "4":
                                                BokadeGrupprum = BokadeGrupprum.OrderByDescending(gr => gr.StartTime).ToList();
                                                BokadeSalar = BokadeSalar.OrderByDescending(sal => sal.StartTime).ToList();
                                                Console.WriteLine("Bokningslista sorterad");
                                                Thread.Sleep(1000);
                                                break;
                                            case "5":
                                                BokadeGrupprum = BokadeGrupprum.OrderBy(gr => gr.CombinedDateAndTime).ToList();
                                                BokadeSalar = BokadeSalar.OrderBy(sal => sal.CombinedDateAndTime).ToList();
                                                Console.WriteLine("Bokningslista sorterad");
                                                Thread.Sleep(1000);
                                                break;
                                            case "6":
                                                BokadeGrupprum = BokadeGrupprum.OrderByDescending(gr => gr.CombinedDateAndTime).ToList();
                                                BokadeSalar = BokadeSalar.OrderByDescending(sal => sal.CombinedDateAndTime).ToList();
                                                Console.WriteLine("Bokningslista sorterad");
                                                Thread.Sleep(1000);
                                                break;
                                            case "0":
                                                sortingMenu = false;
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

                                    bool inColorMenu = true;
                                    while (inColorMenu)
                                    {
                                        Console.Clear();
                                        MenuHelper.PrintTextColorMenu();
                                        userInput = Console.ReadLine();

                                        switch (userInput)
                                        {
                                            case "1":
                                                Console.ForegroundColor = ConsoleColor.White;
                                                continue;
                                            case "2":
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                continue;
                                            case "3":
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                break;
                                            case "4":
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                break;
                                            case "5":
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                break;
                                            case "0":
                                                inColorMenu = false;
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
                                    settingsMenu = false;
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

    }
}
