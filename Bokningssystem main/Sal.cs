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

    }
}
 
