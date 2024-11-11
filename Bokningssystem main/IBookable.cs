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
