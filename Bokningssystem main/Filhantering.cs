using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    public class Filhantering
    {
        private const string Filnamn = "lokaler.txt";

        public void SparaLokaler(List<Lokal> lokaler)
        {
            using (StreamWriter writer = new StreamWriter(Filnamn))
            {
                foreach (var lokal in lokaler)
                {
                    writer.WriteLine($"{lokal.GetType().Name}, {lokal.Namn}, {lokal.Kapacitet}");
                }
            }
        }
        public List<Lokal> LäsInLokaler()
        {
            List<Lokal> lokaler = new List<Lokal>();

            if (File.Exists(Filnamn))
            {
                using (StreamReader reader = new StreamReader(Filnamn))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        if (data[0] == nameof(Sal))
                        {
                            lokaler.Add(new Sal(data[1], int.Parse(data[2]), bool.Parse(data[3])));
                        }
                        else if (data[0] == nameof(Grupprum))
                        {
                            lokaler.Add(new Grupprum(data[1], int.Parse(data [2]), bool.Parse(data[3])));

                        }
                    }
                }
            }
            return lokaler;
        }
    }
}
