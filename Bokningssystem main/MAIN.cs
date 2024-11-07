﻿using System.Reflection.Metadata.Ecma335;
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
                AllaGrupprum.Add(new Grupprum { RoomNumber = "301", Capacity = 6, HasProjector = false, HasWhiteBoard = true });
                AllaGrupprum.Add(new Grupprum { RoomNumber = "302", Capacity = 8, HasProjector = false, HasWhiteBoard = false });
                AllaGrupprum.Add(new Grupprum { RoomNumber = "303", Capacity = 12, HasProjector = true, HasWhiteBoard = true });

                AllaSalar.Add(new Sal { RoomNumber = "201", Capacity = 33, HasProjector = true, HasWhiteBoard = false });
                AllaSalar.Add(new Sal { RoomNumber = "202", Capacity = 40, HasProjector = true, HasWhiteBoard = true });
                AllaSalar.Add(new Sal { RoomNumber = "203", Capacity = 28, HasProjector = false, HasWhiteBoard = true });

                DataManager.SaveData(AllaSalar,AllaGrupprum);
            }

            bool mainMenu = true;
            while (mainMenu)
            {
                bool settingsMenu = true;
                foreach (var grupprum in AllaGrupprum)
                {
                    grupprum.TimerForBookings();
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
                                        foreach (var sal in AllaSalar)
                                        {
                                            if (sal.IsAvailable)
                                            {
                                                Console.WriteLine(sal.ToString());
                                                Console.WriteLine();
                                            }
                                        }

                                        // Bokar rummet genom att köra BookSal metoden
                                        Console.WriteLine("Ange rumsnummer:");
                                        string nameOfSalToBook = Console.ReadLine();

                                        foreach (var sal in AllaSalar)
                                        {
                                            if (nameOfSalToBook == sal.RoomNumber)
                                            {
                                                BokadeSalar.Add(sal.BookSal());
                                            }
                                        }
                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    else if (userInput == "Grupprum")
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
                                        Console.WriteLine("Ange rumsnummer:");
                                        string nameOfGrupprumToBook = Console.ReadLine();

                                        foreach(var grupprum in AllaGrupprum)
                                        {
                                            if(nameOfGrupprumToBook == grupprum.RoomNumber)
                                            {
                                                BokadeGrupprum.Add(grupprum.BookGrupprum());
                                            }
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
                                        // Metod för uppdater bokning av sal
                                        Console.WriteLine("Ange rumsnummer för bokningen du vill uppdatera:");
                                        string roomNumberToUpdate = Console.ReadLine();

                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (roomNumberToUpdate == sal.RoomNumber)
                                            {

                                                Console.WriteLine("Ange ny starttid (yyyy-mm-dd:mm):");
                                                sal.StartTime = DateTime.Parse(Console.ReadLine());
                                                Console.WriteLine("Ange ny sluttid (yyyy-mm-dd:mm):");
                                                sal.EndTime = DateTime.Parse(Console.ReadLine());
                                                Console.WriteLine("Bokningen har uppdaterats.");
                                            }
                                        }

                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för uppdatera bokning av grupprum
                                        Console.WriteLine("Ange rumsnummer för bokningen du vill uppdatera:");
                                        string roomNumberToUpdate = Console.ReadLine();

                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (roomNumberToUpdate == sal.RoomNumber)
                                            {
                                                Console.WriteLine("Ange ny starttid (yyyy-mm-dd:mm):");
                                                sal.StartTime = DateTime.Parse(Console.ReadLine());
                                                Console.WriteLine("Ange nu sluttid (yyyy-mm-dd:mm):");
                                                sal.EndTime = DateTime.Parse(Console.ReadLine());
                                            }
                                        }

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
                                        // Metod för ta bort bokning av sal
                                        Console.WriteLine("Ange rumsnummer för bokningen du vill ta bort");
                                        string roomNumberToRemove = Console.ReadLine();

                                        for (int i = 0; i < BokadeSalar.Count; i++)
                                        {
                                            if (roomNumberToRemove == BokadeSalar[i].RoomNumber)
                                            {
                                                BokadeSalar[i].IsAvailable = true;
                                                BokadeSalar.RemoveAt(i);
                                                Console.WriteLine("Bokningen har tagits bort.");
                                                break;
                                            }
                                        }

                                        DataManager.SaveBookings(AllaSalar, AllaGrupprum);
                                    }
                                    else if (userInput == "Grupprum")
                                    {
                                        // Metod för ta bort bokning av grupprum
                                        Console.WriteLine("Ange rumsnummer för bokningen du vill ta bort:");
                                        string roomNumberToRemove = Console.ReadLine();

                                        for (int i = 0; i < BokadeGrupprum.Count; i++)
                                        {
                                            if (roomNumberToRemove == BokadeGrupprum[i].RoomNumber)
                                            {
                                                BokadeGrupprum[i].IsAvailable = true;
                                                BokadeGrupprum.RemoveAt(i);
                                                Console.WriteLine("Bokningen har tagits bort.");
                                                break;
                                            }
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
                                        foreach (var sal in BokadeSalar)
                                        {
                                            if (!sal.IsAvailable)
                                            {
                                                sal.ShowBookings();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Det finns inga bokningar");
                                            }
                                        }
                                    }
                                    else if (userInput == "Grupprum")
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
                                                Console.ReadLine();
                                            }
                                        }
                                    }
                                    else if (userInput == "Grupprum")
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
                                    userInput = MenuHelper.ChooseRoomType();

                                    if (userInput == "0")
                                    {
                                        break;
                                    }
                                    else if (userInput == "Sal")
                                    {
                                        // Metod för se alla salar
                                        foreach (var sal in AllaSalar)
                                        {
                                            sal.ShowAvailableRooms();
                                        }
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
