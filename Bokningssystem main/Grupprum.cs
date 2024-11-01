using System;
namespace Bokningssystem_main
{
    public class Grupprum : Lokal
    {
        public bool HarWhiteboard { get; set; }
        public Grupprum(string namn, int kapacitet, bool harWhiteboard) : base (namn, kapacitet)
        {
            HarWhiteboard = harWhiteboard;
        }
        public override void VisaInfo()
        {
            base.VisaInfo();
            Console.WriteLine($"Har Whiteboard: {HarWhiteboard}");
        }
    }

}
