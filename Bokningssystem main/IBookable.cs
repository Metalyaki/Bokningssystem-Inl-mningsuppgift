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
    public class Program
    {
        public static void Main(string[] args)
        {
            Sal sal = new Sal("Aula", 10, true);
            Grupprum grupprum = new Grupprum("Grupprum 1", 10, true);

            DateTime startTid = new DateTime(2022, 11, 30, 7, 0, 0);
            DateTime slutTid = new DateTime(2023, 12, 05, 13, 0, 0);

            Bokning bokning = new Bokning(sal, startTid, slutTid);
            bokning.Boka(startTid, slutTid);

            TimeSpan bokningsLäng = slutTid - startTid;
            Console.WriteLine($"Bokningslängden: {bokningsLäng.TotalHours} timmar");
        }
    }
    public class Bokningssystem
    {
        public List<Lokal> Lokaler { get; private set; } = new List<Lokal>();
        private List<Bokning> bokningar = new List<Bokning>();

        public void LäggTillLokal(Lokal lokal)
        {
            if (!Lokaler.Any(l => l.Namn == lokal.Namn))
            {
                Lokaler.Add(lokal);
                Console.WriteLine($"Lokal {lokal.Namn} är tillagd.");
            }
            else
            {
                Console.WriteLine($"Lokal med namnet {lokal.Namn} finns redan;");
            }
        }
        public void ListaAllaLokaler()
        {
            foreach (var lokal in Lokaler)
            {
                lokal.VisaInfo();
            }
        }
        public void LäggTillBokning(Bokning bokning)
        {
            bokningar.Add(bokning);
            Console.WriteLine("Bokning tillagd.");
        }
        public void ListaAllaBokningar()
        {
            foreach (var bokning in bokningar)
            {
                Console.WriteLine($"Lokal {bokning.Lokal.Namn}, Start: {bokning.StartTid}, Slut{bokning.SlutTid}");
            }
        }
    }
}
