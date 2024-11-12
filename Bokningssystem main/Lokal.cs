using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    public abstract class Lokal
    {
        public int Capacity { get; set; }
        public bool HasWhiteBoard { get; set; }
        public bool HasProjector { get; set; }


    }


}