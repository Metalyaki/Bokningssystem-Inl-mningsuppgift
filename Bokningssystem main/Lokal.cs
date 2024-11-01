using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
     public class Lokal
    {
        public string Namn { get; set; }
        public int Kapacitet { get; set; }
        public Lokal(string namn, int kapacitet)
        {
            Namn = namn;
            Kapacitet = kapacitet;
        }
        public virtual void VisaInfo()
        {
            Console.WriteLine($"Namn: {Namn}, Kapacitet: {Kapacitet}");
        }
    }
}
