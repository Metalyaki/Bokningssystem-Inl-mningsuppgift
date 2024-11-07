using Bokningssystem_main;
using System;
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

        public Grupprum BookGrupprum()
        {
            throw new NotImplementedException();
        }

        public Sal BookSal()
        {
            if (IsAvailable)
            {
            IsAvailable = false;
            Console.WriteLine("Ange användarnamn:");
            User = Console.ReadLine();
            Console.WriteLine("Ange starttid (yyyy-mm-dd:nn):");
            StartTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ange sluttid (yyyy-mm-dd:mm):");
            EndTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"Sal {RoomNumber} har bokats av {User} från {StartTime} till {EndTime}");
            }
            else
            {
                Console.WriteLine($"Sal {RoomNumber} är redan bokad.");
            }
            return this;
        }

        public void ShowAvailableRooms()
        {
            if (IsAvailable)
            {
                Console.WriteLine($"Sal {RoomNumber} är tillgängligt.");
            }
            else
            {
                Console.WriteLine($"Sal {RoomNumber} är bokad.");
            }
        }

        public void ShowBookings()
        {
            if (!IsAvailable)
            {

                Console.WriteLine($"Sal {RoomNumber} är bokat av {User}.");
                Console.WriteLine($"Bokningens starttid: {StartTime}");
                Console.WriteLine($"Bokningens sluttid: {EndTime}");
            }
            else
            {
                Console.WriteLine($"Sal {RoomNumber} är inte bokad.");
            }
        }

        public void TimerForBookings()
        {
            if (!IsAvailable && DateTime.Now > EndTime)
            {
                IsAvailable = true;
                Console.WriteLine($"Bokningen för sal {RoomNumber} har avslutats.");
            }
        }

        public Grupprum UnbookGrupprum()
        {
            throw new NotImplementedException();
        }

        public Sal UnbookSal()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                Console.WriteLine($"Bokningen för sal {RoomNumber} har avbokats.");
            }
            else
            {
                Console.WriteLine($"Sal {RoomNumber} är inte bokad.");
            }
            return this;
        }

        public void UpdateABooking()
        {
            if (!IsAvailable)
            {
                Console.WriteLine("Ange ny starttid (yyyy-mm-dd:mm):");
                StartTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ange ny sluttid (yyyy-mm-dd:mm):");
                EndTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine($"Bookning för Sal {RoomNumber} har uppdaterats.");
            }
            else
            {
                Console.WriteLine($"Sal {RoomNumber} är inte bokad.");
            }
        }

    }
}
 
