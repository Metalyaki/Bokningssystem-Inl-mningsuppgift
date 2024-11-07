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

    public Grupprum BookGrupprum()//Anders
    {
        //Tider, som jag ska använda sen genom att kolla så när startTime blir lika som endTime så ska något avslutas
        bool validBookingDate = false;
        bool validStartTime = false;
        bool validHourAndMinutes = false;
        bool validName = false;
        

        while (!validBookingDate)
        {
            Console.WriteLine($"Bokning av Grupprum: {RoomNumber}");
            Console.WriteLine("Ange datum för bokningen(dd/MM/yyyy)");
            string inputDate = Console.ReadLine();

            try
            {
                //ParseExact försöker göra parse inputDate som en DateTime i önskat format(dd/MM/yyyy)
                //där man har null så kan man ha speciellt format efter något land men körde null för ha default.
                BookingDate = DateTime.ParseExact(inputDate, "dd/MM/yyyy", null);
                if(BookingDate < DateTime.Now.AddDays(-1))
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
                if(StartTime < DateTime.Now && BookingDate < DateTime.Now)
                {
                    validStartTime = false;
                    Console.WriteLine("Kan inte boka bakåt i tiden");
                }
                else
                {
                    validStartTime = true;
                    
                }
                
            }
            catch(FormatException ex)
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

            if( name != null || name != "")
            {
                User = name;
                Console.WriteLine($"Bokning av Grupprum: {RoomNumber}");
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
            Console.WriteLine($"Grupprum: {RoomNumber}" +
            $"\n Kapacitet: {Capacity}" +
            $"\n Projektor: {HasProjector}" +
            $"\n Whiteboard: {HasWhiteBoard}");
        }
    }

    public void ShowBookings()
    {
        Console.WriteLine($"Bokning av Grupprum: {RoomNumber}");
        Console.WriteLine($"Datum: {CombinedDateAndTime.ToString("dd/MM/yyyy")}");
        Console.WriteLine($"Start tid: {CombinedDateAndTime.ToString("HH:mm")}");
        Console.WriteLine($"Slut tid: {EndTime.ToString("HH:mm")}");
        Console.WriteLine($"Signerat av: {User}");
    }

    public Grupprum UnbookGrupprum()
    {
        IsAvailable = true;
        DateTime unbookDateTime = new DateTime();
        BookingDate = unbookDateTime;
        StartTime = unbookDateTime;
        EndTime = unbookDateTime;

    public void UpdateABooking(List<Grupprum> BokadeGrupprum)
    {
        if (BokadeGrupprum.Count == 0) // KOllar om de finns nå bokningar
        {
            Console.WriteLine("Det finns inga bokade grupprum att uppdatera.");
            return;
        }
        User = null;

        return this;
    }

    public void UpdateABooking()
    {
        throw new NotImplementedException();
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

    public override string ToString()
    {
        //Skriver ut vad rummen innehåller
        return $"Grupprum: {RoomNumber}" +
            $"\n Kapacitet: {Capacity}" +
            $"\n Projektor: {HasProjector}" +
            $"\n Whiteboard: {HasWhiteBoard}" +
            $"\n Signatur: {User}";
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
