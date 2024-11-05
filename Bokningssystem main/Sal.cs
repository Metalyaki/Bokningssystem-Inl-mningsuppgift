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
        throw new NotImplementedException();
    }

    public void ShowAvailableRooms()
    {
        throw new NotImplementedException();
    }

    public void ShowBookings()
    {
        throw new NotImplementedException();
    }

    public void TimerForBookings()
    {
        throw new NotImplementedException();
    }

    public Grupprum UnbookGrupprum()
    {
        throw new NotImplementedException();
    }

    public Sal UnbookSal()
    {
        throw new NotImplementedException();
    }

    public void UpdateABooking()
    {
        throw new NotImplementedException();
    }
    public void EraseBooking()
        {
            Console.WriteLine("Bokningar:");

            for (int i = 0; i < Sal.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {bokningar[i]}");
            }
            Console.WriteLine("Skriv numret för den bokning du vill ta bort. Annars 0 för att Avsluta.");

            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= bokningar.Count)
            {
                bokningar.RemoveAt(index - 1);
                Console.WriteLine("Bokningen raderad.");
            }
            else
            {
                Console.WriteLine("Felaktigt val. Kunde inte ta bort någon bokning.");
            }
        }

    }

