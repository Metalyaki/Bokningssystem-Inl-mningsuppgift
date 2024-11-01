using System;
namespace Bokningssystem_main
{

    public class Sal : Lokal
    {
        public bool HarProjektor { get; set; }
        public Sal(string namn, int kapacitet, bool harProjektor) : base(namn, kapacitet)
        {
            HarProjektor = harProjektor;
        }
        public override void VisaInfo()
        {
            base.VisaInfo();
            Console.WriteLine($"Har Projektor: {HarProjektor}");
        }
    }
}

