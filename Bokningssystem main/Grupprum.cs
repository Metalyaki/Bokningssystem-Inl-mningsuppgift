using Bokningssystem_main;
using System;
using System.Globalization;

public class Grupprum: Lokal, IBookable//Namn på de som jobbat med detta: Anders,
{
    public string RoomNumber { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime BookingDate {  get; set; }
    public DateTime CombinedDateAndTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string User { get; set; }
    public Grupprum()
	{

	}

    public Grupprum BookGrupprum()//Skapade Av Anders
    {
        
        Grupprum newBooking = new Grupprum()
        {
            RoomNumber = this.RoomNumber,
            IsAvailable = false
        };

        
        bool validBookingDate = false;
        bool validStartTime = false;
        bool validHourAndMinutes = false;
        bool validName = false;

        while (!validBookingDate)
        {
            Console.WriteLine($"Bokning av Grupprum: {newBooking.RoomNumber}");
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
                Console.WriteLine($"Bokning av Grupprum: {newBooking.RoomNumber}");
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


    public void ShowAvailableRooms()//Skapade Av Anders
    { 
        if (IsAvailable == true)
        {
            Console.WriteLine($"Grupprum: {RoomNumber}" +
            $"\n Kapacitet: {Capacity}" +
            $"\n Projektor: {HasProjector}" +
            $"\n Whiteboard: {HasWhiteBoard}");
        }
    }

    public void ShowBookings()//Skapade Av Anders
    {
        Console.WriteLine($"Bokning av Grupprum: {RoomNumber}");
        Console.WriteLine($"Datum: {CombinedDateAndTime.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Start tid: {CombinedDateAndTime.ToString("HH:mm")}");
        Console.WriteLine($"Slut tid: {EndTime.ToString("HH:mm")}");
        Console.WriteLine($"Signerat av: {User}");
    }

    public Grupprum UnbookGrupprum()//Skapade Av Anders
    {
        IsAvailable = true;
        DateTime unbookDateTime = new DateTime();
        CombinedDateAndTime = unbookDateTime;
        BookingDate = unbookDateTime;
        StartTime = unbookDateTime;
        EndTime = unbookDateTime;
        User = "";

        return this;
    }

    public void UpdateABooking(List<Grupprum> BokadeGrupprum)//Pontus
    {
        if (BokadeGrupprum.Count == 0) // Kontroll om det finns några bokningar
        {
            Console.WriteLine("Det finns inga bokade grupprum att uppdatera.");
            return;
        }

        Console.WriteLine("Bokade Grupprum: ");
        for (int i = 0; i < BokadeGrupprum.Count; i++)
        {
            if (!BokadeGrupprum[i].IsAvailable) // Visar endast bokade grupprum
            {
                Console.WriteLine($"{i + 1}. Rumsnummer: {BokadeGrupprum[i].RoomNumber},");
                Console.WriteLine($"Datum: {BokadeGrupprum[i].BookingDate:dd/MM/yyyy},");
                Console.WriteLine($"Starttid: {BokadeGrupprum[i].StartTime:HH:mm},");
                Console.WriteLine($"Sluttid: {BokadeGrupprum[i].EndTime:HH:mm},");
                Console.WriteLine($"Användare: {BokadeGrupprum[i].User}");
            }
        }

        int selection = 0;
        bool validSelection = false;
        while (!validSelection) // Loopar tills användaren ger ett giltigt svar
        {
            try
            {
                Console.WriteLine("Välj numret för grupprummet du vill uppdatera:");
                selection = int.Parse(Console.ReadLine());

                if (selection < 1 || selection > BokadeGrupprum.Count) // Kollar om input är inom giltigt intervall
                {
                    throw new FormatException("Numret finns inte med i listan. Försök igen.");
                }

                validSelection = true; // Avbryter loopen om input är giltig
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Felaktigt val, ange ett giltigt nummer. " + ex.Message);
            }
        }

        Grupprum updateRoom = BokadeGrupprum[selection - 1]; // Hämtar den valda bokningen

        bool validDate = false;
        while (!validDate) // Loopar tills input är ett giltigt datum
        {
            try
            {
                Console.WriteLine("Ange nytt datum för bokningen (format: dd/MM/yyyy): ");
                updateRoom.BookingDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                if (updateRoom.BookingDate < DateTime.Now.Date) // Korrekt kontroll för att förhindra datum bakåt i tiden
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

        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till menyn.");
        Console.ReadKey();
    }

    public void TimerForBookings()//Skapade Av Anders
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

    public override string ToString()//Skapade Av Anders
    {
        //Skriver ut vad rummen innehåller
        return $"Grupprum: {RoomNumber}" +
            $"\n Kapacitet: {Capacity}" +
            $"\n Projektor: {HasProjector}" +
            $"\n Whiteboard: {HasWhiteBoard}";
            
    }
    public Sal BookSal()
    {
        throw new NotImplementedException();
        
    }
    
    public Sal UnbookSal()
    {
        throw new NotImplementedException();
    }

}
