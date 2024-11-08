using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    internal interface IBookable
    {
        public Grupprum BookGrupprum();
        public Sal BookSal();
        public Grupprum UnbookGrupprum();
        public Sal UnbookSal();
        public void ShowBookings();
        public void ShowAvailableRooms();
        public void TimerForBookings();
        
    }
} 