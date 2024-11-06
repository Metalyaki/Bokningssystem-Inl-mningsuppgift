﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bokningssystem_main
{
    internal static class DataManager
    {
        public static List<Sal> LoadSalar()
        {
            String? loadSalar = null;
            if (File.Exists("salar.json"))
            {
                loadSalar = File.ReadAllText("salar.json");
                return JsonSerializer.Deserialize<List<Sal>>(loadSalar) ?? new List<Sal>();
            }
            return new List<Sal>();
        }

        public static List<Grupprum> LoadGrupprum()
        {
            String? loadGrupprum = null;
            if (File.Exists("grupprum.json"))
            {
                loadGrupprum = File.ReadAllText("grupprum.json");
                return JsonSerializer.Deserialize<List<Grupprum>>(loadGrupprum) ?? new List<Grupprum>();
            }
            return new List<Grupprum>();
        }

        public static List<Sal> LoadBookedSal()
        {
            String? loadSalar = null;
            if (File.Exists("bokadeSalar.json"))
            {
                loadSalar = File.ReadAllText("bokadeSalar.json");
                return JsonSerializer.Deserialize<List<Sal>>(loadSalar) ?? new List<Sal>();
            }
            return new List<Sal>();
        }
        public static List<Grupprum> LoadBookedGrupprum()
        {
            String? loadGrupprum = null;
            if (File.Exists("bokadeGrupprum.json"))
            {
                loadGrupprum = File.ReadAllText("bokadeGrupprum.json");
                return JsonSerializer.Deserialize<List<Grupprum>>(loadGrupprum) ?? new List<Grupprum>();
            }
            return new List<Grupprum>();
        }

        public static void SaveData(List<Sal> allaSalar, List<Grupprum> allaGrupprum)
        {
            string jsonSalar = JsonSerializer.Serialize(allaSalar);
            string jsonGrupprum = JsonSerializer.Serialize(allaGrupprum);

            File.WriteAllText("salar.json", jsonSalar);
            File.WriteAllText("grupprum.json", jsonGrupprum);
        }

        public static void SaveBookings(List<Sal> bokadeSalar, List<Grupprum> bokadeGrupprum)
        {
            string jsonBokadeSalar = JsonSerializer.Serialize(bokadeSalar);
            string jsonBokadeGrupprum = JsonSerializer.Serialize(bokadeGrupprum);

            File.WriteAllText("bokadeSalar.json", jsonBokadeSalar);
            File.WriteAllText("bokadeGrupprum.json", jsonBokadeGrupprum);
        }
    }
}