using Bokningssystem_main;
using System;
using System.Globalization;
namespace Bokningssystem_main
{

    public class Sal : Lokal, IBookable
    {
        public string RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CombinedDateAndTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string User { get; set; }


        public Sal BookSal()
        {
            //Skapar en ny instans av rummet så att man kan skapa flera tider på samma rum
            //annars blir det att man skriver över tidigare data om man förösker skapa ny tid på ett rum
            //Sätter newBooking framför variabler så de vet att det är nytt och inte skriver över gamla
            Sal newBooking = new Sal()
            {
                RoomNumber = this.RoomNumber,
                IsAvailable = false // Markera som bokad när bokningen är klar
            };


            bool validBookingDate = false;
            bool validStartTime = false;
            bool validHourAndMinutes = false;
            bool validName = false;

            while (!validBookingDate)
            {
                Console.WriteLine($"Bokning av Sal: {newBooking.RoomNumber}");
                Console.WriteLine("Ange datum för bokningen (dd/MM/yyyy)");
                string inputDate = Console.ReadLine();

                try
                {
                    newBooking.BookingDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", null);
                    if (newBooking.BookingDate < DateTime.Now.AddDays(-1))
                    {
                        validBookingDate = false;
                        Console.WriteLine("Kan inte boka bakåt i tiden");
                    }
                    else
                    {
                        validBookingDate = true;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Vänligen ange korrekt format på datumet (dd/MM/yyyy) " + ex.Message);
                }
            }

            while (!validStartTime)
            {
                Console.WriteLine("Ange tid för bokningen (HH:mm)");
                string inputStartTime = Console.ReadLine();

                try
                {
                    //Parse exakt den tid jag vill ha och istället för null/default så vill jag ha svensk tid
                    newBooking.StartTime = DateTime.ParseExact(inputStartTime, "HH:mm", CultureInfo.GetCultureInfo("sv-SE"));
                    if (newBooking.StartTime < DateTime.Now && newBooking.BookingDate < DateTime.Now)
                    {
                        validStartTime = false;
                        Console.WriteLine("Kan inte boka bakåt i tiden");
                    }
                    else
                    {
                        validStartTime = true;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Vänligen ange korrekt format på tiden (HH:mm) " + ex.Message);
                }
            }

            newBooking.CombinedDateAndTime = newBooking.BookingDate.AddHours(newBooking.StartTime.Hour).AddMinutes(newBooking.StartTime.Minute);

            while (!validHourAndMinutes)
            {
                try
                {
                    Console.WriteLine("Hur många timmar vill du boka?");
                    int hour = int.Parse(Console.ReadLine());
                    Console.WriteLine("Hur många minuter vill du boka?");
                    int minutes = int.Parse(Console.ReadLine());

                    validHourAndMinutes = true;

                    // Ger endTime värde genom att lägga till hour och minutes på CombinedDateAndTime
                    newBooking.EndTime = newBooking.CombinedDateAndTime.AddHours(hour).AddMinutes(minutes);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Vänligen ange ett tal" + ex.Message);
                }
            }

            while (!validName)
            {
                Console.WriteLine("Namn?");
                string name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    newBooking.User = name;
                    Console.WriteLine($"Bokning av Sal: {newBooking.RoomNumber}");
                    Console.WriteLine($"Datum: {newBooking.CombinedDateAndTime:dd/MM/yyyy}");
                    Console.WriteLine($"Start tid: {newBooking.CombinedDateAndTime:HH:mm}");
                    Console.WriteLine($"Slut tid: {newBooking.EndTime:HH:mm}");
                    Console.WriteLine($"Signerat av: {newBooking.User}");
                    validName = true;
                    Console.ReadKey();
                }
            }
            if (RoomNumber == newBooking.RoomNumber && StartTime == newBooking.StartTime)
            {
                Console.WriteLine("Detta rum är redan bokat under den önskade tiden.");
                return null; // Avsluta bokningen om tiden är upptagen
            }


            // Markera rummet som bokat
            newBooking.IsAvailable = false;
            return newBooking;
        }


        public void ShowAvailableRooms()
        {
            if (IsAvailable == true)
            {
                Console.WriteLine($"Sal: {RoomNumber}" +
                $"\n Kapacitet: {Capacity}" +
                $"\n Projektor: {HasProjector}" +
                $"\n Whiteboard: {HasWhiteBoard}");
            }
        }

        public void ShowBookings()
        {
            Console.WriteLine($"Bokning av Sal: {RoomNumber}");
            Console.WriteLine($"Datum: {CombinedDateAndTime.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Start tid: {CombinedDateAndTime.ToString("HH:mm")}");
            Console.WriteLine($"Slut tid: {EndTime.ToString("HH:mm")}");
            Console.WriteLine($"Signerat av: {User}");
            Console.WriteLine();
        }

        public void TimerForBookings()
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime >= EndTime)
            {
                IsAvailable = true;
            }
            else
            {
                IsAvailable = false;
            }
        }


        public Sal UnbookSal()
        {
            IsAvailable = true;
            DateTime unbookDateTime = new DateTime();
            CombinedDateAndTime = unbookDateTime;
            BookingDate = unbookDateTime;
            StartTime = unbookDateTime;
            EndTime = unbookDateTime;

            User = null;

            return this;
        }

        public void UpdateASalBooking(List<Sal> BokadeSalar) // Pontus
        {
            if (BokadeSalar.Count == 0) // Kollar om de finns nå bokningar
            {
                Console.WriteLine("Det finns inga bokade salar att uppdatera.");
                return;
            }

            Console.WriteLine("Bokade Salar: ");
            int displayIndex = 1; // Här gör jag så numreringen börjar från 1
            for (int i = 0; i < BokadeSalar.Count; i++)
            {
                if (!BokadeSalar[i].IsAvailable) // Visar endast bokade salar
                {
                    Console.WriteLine($"{displayIndex}. Salnummer: {BokadeSalar[i].RoomNumber},");
                    Console.WriteLine($"Datum: {BokadeSalar[i].BookingDate:dd/MM/yyyy},");
                    Console.WriteLine($"Starttid: {BokadeSalar[i].StartTime:HH:mm},");
                    Console.WriteLine($"Sluttid: {BokadeSalar[i].EndTime:HH:mm},");
                    Console.WriteLine($"Användare: {BokadeSalar[i].User}");
                    displayIndex++;
                }
            }

            int selection = 0;
            bool validSelection = false;
            while (!validSelection) // loopar tills användaren ger ett svar som är godkänt
            {
                try
                {
                    Console.WriteLine("Välj numret för salen du vill uppdatera (annars tryck 0 för att gå tillbaka i menyn):");
                    selection = int.Parse(Console.ReadLine());

                    if (selection == 0)
                    {
                        Console.WriteLine("Återgår till föregående meny.");
                        return;
                    }

                    if (selection < 1 || selection > BokadeSalar.Count)
                    {
                        throw new FormatException("Numret finns inte med i listan var god försök igen.");
                    }

                    validSelection = true; // stoppar loopen om inputen är giltlig
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Felaktig val, ange ett giltligt nummer. " + ex.Message);
                }
            }

            Sal updateRoom = BokadeSalar[selection - 1]; // hämtar den valda bokningen

            bool validDate = false;
            while (!validDate) // Loop för få ett detum input som är giltligt
            {
                try
                {
                    Console.WriteLine("Ange nytt datum för bokningen (format: dd/MM/yyyy): ");
                    updateRoom.BookingDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    if (updateRoom.BookingDate < DateTime.Now.Date) // kollar så inte datumet varit redan
                    {
                        throw new FormatException("Du kan inte skriva in ett datum som redan varit.");
                    }

                    validDate = true; // stoppar loopen om datumet är giltligt.
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Felaktigt datum. " + ex.Message);
                }
            }

            bool validStartTime = false;
            while (!validStartTime)
            {
                try
                {
                    Console.WriteLine("Ange ny starttid: (format: HH:mm): ");
                    updateRoom.StartTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
                    validStartTime = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ogiltlig tid. " + ex.Message);
                }
            }

            try
            {
                Console.WriteLine("Hur många timmar vill du boka?");
                int hours = int.Parse(Console.ReadLine());
                Console.WriteLine("Hur många minuter vill du boka?");
                int minutes = int.Parse(Console.ReadLine());

                updateRoom.EndTime = updateRoom.StartTime.AddHours(hours).AddMinutes(minutes);  // Beräknar sluttiden baserat på starttid och användarens inmatning
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ange ett tal. " + ex.Message);
            }

            Console.WriteLine("Ange namn för den som ska stå på bokningen:");
            string newUser = Console.ReadLine().Trim();
            updateRoom.User = newUser;

            updateRoom.IsAvailable = false; // Markerar bokningen som upptagen
            Console.WriteLine("Bokningen har uppdaterats.");
        }

        public override string ToString()
        {
            //Skriver ut vad rummen innehåller
            return $"Sal: {RoomNumber}" +
                $"\n Kapacitet: {Capacity}" +
                $"\n Projektor: {HasProjector}" +
                $"\n Whiteboard: {HasWhiteBoard}";
        }
        public Grupprum BookGrupprum()
        {
            throw new NotImplementedException();
        }
        public Grupprum UnbookGrupprum()
        {
            throw new NotImplementedException();
        }

    }
}
 
