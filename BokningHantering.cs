using System;
using System.Collections.Generic;

public class BokningsHantering
{
    private List<Bokning> bokningar;

    public BokningsHantering(List<Bokning> bokningar) // konstruktor som tar emot bokningslistan
    {
        this.bokningar = bokningar;
    }

    public void ListaTidigareBokningar(int år, string rumstyp) // metod för listning av bokningar för året man söker och rumstyp.
    {
        Console.WriteLine($"Tidigare bokningar för {rumstyp} för året {år}:");

        List<Bokning> tidigareBokningar = new List<Bokning>(); // lista för lagring av matchande bokningar

        foreach (Bokning bokning in bokningar) // går igenom bokningar för hitta matchningar.
        {
            if (bokning.StartTid.Year == år && ((rumstyp == "Sal" && bokning.Lokal is Sal) || (rumstyp == "Grupprum" && bokning.Lokal is Grupprum))) // kollar om bokningens år och typ av rum matchar.
            {
                tidigareBokningar.Add(bokning); // lägger till i listan om bokningen matchar
            }
        }
        if (tidigareBokningar.Count == 0) // kollar om några bokningar hittades och skriver sedan ut resultatet.
        {
            Console.WriteLine("Tyvärr, kunde inte hitta några bokningar från det året.");
        }
        else
        {
            foreach (Bokning bokning in tidigareBokningar) // skriver ut varje matchande bokning.
            {
                Console.WriteLine($"Lokal: {bokning.Lokal.Namn}, Starttid: {bokning.StartTid}, Sluttid: {bokning.SlutTid}");
            }
        }
    }

    public void RaderaBokning()
    {
        Console.WriteLine("Bokningar:");

        for (int i = 0; i < bokningar.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {bokningar[i]}");
        }
        Console.WriteLine("Skriv numret för den bokning du vill ta bort. Annars 0 för att Avsluta.");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= bokningar.Count)
        {
            bokningar.RemoveAt(index - 1);
            Console.WriteLine("Bokningen raderad.");
        }
        else
        {
            Console.WriteLine("Felaktigt val. Kunde inte ta bort någon bokning.");
        }
    }
}
// Sen behöver man skicka köra BokningsHantering i main och skicka in bokningslistan
// BokningsHantering bokningshantering =  new BokningsHantering(bokningar);

// case "2":
//Console.Clear();
//roomChoice = ChooseRoomType();

//if (roomChoice == "Sal" || roomChoice == "Grupprum")
//{
//    Console.WriteLine("Ange år för att visa bokningar:");
//    if (int.TryParse(Console.ReadLine(), out int år))
//    {
//        bokningsHantering.ListaTidigareBokningar(år, roomChoice);
//    }

// case "3":
//Console.Clear();
//bokningsHantering.RaderaBokning();
//Thread.Sleep(1000);
//break;