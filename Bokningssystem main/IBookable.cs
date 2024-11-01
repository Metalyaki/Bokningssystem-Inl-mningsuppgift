using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    public interface IBookable
    {
        void Boka(DateTime startTid, DateTime slutTid);
        void Avboka();
        void VisaBokningar();
    }
    public class Bokning : IBookable
    {
        public Lokal Lokal { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public Bokning(Lokal lokal, DateTime startTid, DateTime slutTid)
        {
            Lokal = lokal;
            StartTid = startTid;
            SlutTid = slutTid;
        }
        public void Boka(DateTime startTid, DateTime slutTid)
        {
            StartTid = startTid;
            SlutTid = slutTid;
            Console.WriteLine($"Bokning skapad för {Lokal.Namn} från {StartTid} till {SlutTid}");
        }
        public void Avboka()
        {
            Console.WriteLine($"Bokning för {Lokal.Namn} avboka.");
        }
        public void VisaBokningar()
        {
            Console.WriteLine($"Bokning: {Lokal.Namn}, Start: {StartTid}, Slut: {SlutTid}");
        }
    }
} 