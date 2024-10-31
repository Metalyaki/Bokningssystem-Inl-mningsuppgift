using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    internal interface IBookable
    {
        public void BookRoom();
        public void UnbookRoom();
        public void ShowBookings();
        public void ShowAvailableRooms();
        public void UpdateABooking();
        
    }
}
