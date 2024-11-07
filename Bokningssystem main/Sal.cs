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
            //Tider, som jag ska använda sen genom att kolla så när startTime blir lika som endTime så ska något avslutas
            bool validBookingDate = false;
            bool validStartTime = false;
            bool validHourAndMinutes = false;
            bool validName = false;


            while (!validBookingDate)
            {
                Console.WriteLine($"Bokning av Sal: {RoomNumber}");
                Console.WriteLine("Ange datum för bokningen(dd/MM/yyyy)");
                string inputDate = Console.ReadLine();

                try
                {
                    //ParseExact försöker göra parse inputDate som en DateTime i önskat format(dd/MM/yyyy)
                    //där man har null så kan man ha speciellt format efter något land men körde null för ha default.
                    BookingDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", null);
                    if (BookingDate < DateTime.Now.AddDays(-1))
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
                    Console.WriteLine("Vänligen ange korrekt format på datumet!(dd/MM/yyyy) " + ex.Message);
                }

            }

            while (!validStartTime)
            {
                Console.WriteLine("Ange tid för bokningen(HH:mm)");
                string inputStartTime = Console.ReadLine();

                try
                {
                    //Sätter så tiden blir till svensk istället för default, med CultureInfo.GetCultureInfo("sv-SE")
                    StartTime = DateTime.ParseExact(inputStartTime, "HH:mm", CultureInfo.GetCultureInfo("sv-SE"));
                    if (StartTime < DateTime.Now && BookingDate < DateTime.Now)
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
                    Console.WriteLine("Vänligen ange korrekt format på tiden!(HH:mm) " + ex.Message);
                }
            }

            CombinedDateAndTime = BookingDate.AddHours(StartTime.Hour).AddMinutes(StartTime.Minute);

            while (!validHourAndMinutes)
            {
                try
                {
                    Console.WriteLine("Hur många timmar vill du boka?");
                    int hour = int.Parse(Console.ReadLine());
                    Console.WriteLine("Hur många minuter vill du boka?");
                    int minutes = int.Parse(Console.ReadLine());

                    validHourAndMinutes = true;

                    //här ger jag endTime värde genom att lägga till hour och minutes på CombinedDateAndTime
                    EndTime = CombinedDateAndTime.AddHours(hour).AddMinutes(minutes);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Vänligen ange ett tal, inte en bokstav eller tecken " + ex.Message);
                }
            }



            while (!validName)
            {
                Console.WriteLine("Namn?");
                string name = Console.ReadLine();

                if (name != null || name != "")
                {
                    User = name;
                    Console.WriteLine($"Bokning av Sal: {RoomNumber}");
                    Console.WriteLine($"Datum: {CombinedDateAndTime.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Start tid: {CombinedDateAndTime.ToString("HH:mm")}");
                    Console.WriteLine($"Slut tid: {EndTime.ToString("HH:mm")}");
                    Console.WriteLine($"Signerat av: {User}");
                    validName = true;
                    Console.ReadKey();

                }
            }
            //gör isAvailable till false, för det är den variabeln man kollar om man kollar om rum är lediga.
            IsAvailable = false;
            return this;

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
            BookingDate = unbookDateTime;
            StartTime = unbookDateTime;
            EndTime = unbookDateTime;

            User = null;

            return this;
        }

        public void UpdateASalBooking(List<Sal> BokadeSalar)
        {
            if (BokadeSalar.Count == 0) // Kollar om de finns nå bokningar
            {
                Console.WriteLine("Det finns inga bokade salar att uppdatera.");
                return;
            }

            Console.WriteLine("Bokade Salar: ");
            for (int i = 0; i < BokadeSalar.Count; i++)
            {
                if (!BokadeSalar[i].IsAvailable) // Visar endast bokade grupprum
                {
                    Console.WriteLine($"{i + 1}. Salnummer: {BokadeSalar[i].RoomNumber},");
                    Console.WriteLine($"Datum: {BokadeSalar[i].BookingDate:dd/MM/yyyy},");
                    Console.WriteLine($"Starttid: {BokadeSalar[i].StartTime:HH:mm},");
                    Console.WriteLine($"Sluttid: {BokadeSalar[i].EndTime:HH:mm},");
                    Console.WriteLine($"Användare: {BokadeSalar[i].User}");
                }
            }

            int selection = 0;
            bool validSelection = false;
            while (!validSelection) // loopar tills användaren ger ett svar som är godkänt
            {
                try
                {
                    Console.WriteLine("Välj numret för salen du vill uppdatera:");
                    selection = int.Parse(Console.ReadLine());

                    if (selection < 1 || selection > BokadeSalar.Count) // kollar så input är inom giltligt intervall
                    {
                        throw new FormatException("Numret finns inte med i listan var god försök igen.");
                    }

                    validSelection = true; // avbryter loopen om input är giltlig
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Felaktig val, ange ett giltligt nummer. " + ex.Message);
                }
            }

            Sal updateRoom = BokadeSalar[selection - 1]; // hämtar den valda bokningen

            bool validDate = false;
            while (!validDate) // loopar tills input är giltligt datum
            {
                try
                {
                    Console.WriteLine("Ange nytt datum för bokningen (format: dd/MM/yyyy): ");
                    updateRoom.BookingDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                    if (updateRoom.BookingDate < DateTime.Now.Date) // kollar så inte datumet varit redan
                    {
                        throw new FormatException("Du kan inte skriva in ett datum som redan varit.");
                    }

                    validDate = true;
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
 
