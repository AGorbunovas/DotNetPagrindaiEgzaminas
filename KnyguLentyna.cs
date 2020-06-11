using System;

namespace Uzduotys
{
    public class KnyguLentyna
    {
        public readonly Knyga[] knygos;

        public KnyguLentyna()
        {
            knygos = new Knyga[5];
        }

        //public bool IdetiIrasa(string knygosPavadinimas, string knygosAutorius, DateTime knygosIsleidimoMetai, int knygosKaina)
        //{
        //    Knyga PridetiKnyga = new Knyga(knygosPavadinimas, knygosAutorius, knygosIsleidimoMetai, knygosKaina);
        //    for (int i = 0; i < knygos.Length; i++)
        //    {
        //        if (knygos[i] == null)
        //        {
        //            knygos[i] = PridetiKnyga;
        //            Console.WriteLine($"Knyga buvo prideta: {knygosPavadinimas}");
        //        }
        //    }
        //}

        public bool IdetiIrasa(string knygosPavadinimas, string knygosAutorius)
        {
            Knyga PridetiKnyga = new Knyga(knygosPavadinimas, knygosAutorius);
            for (int i = 0; i < knygos.Length; i++)
            {
                if (knygos[i] == null)
                {
                    knygos[i] = PridetiKnyga;
                    Console.WriteLine($"Knyga buvo prideta: {knygosPavadinimas}, {knygosAutorius}");
                }
            }
        }

        public int GautiKnygosIndeksa(string knygosPavadinimas)
        {
            for (int i = 0; i < knygos.Length; i++)
            {
                if (knygos[i] != null && knygos[i].KnygosPavadinimas == knygosPavadinimas)
                {
                    return i;
                }
            }
        }

        public string PerziuretiIrasus()
        {
            string knyguSarasas = "";
            foreach (Knyga knyga in knygos)
            {
                if (knyga == null)
                {
                    continue;
                }
                knyguSarasas += String.Format($"Pavadinimas: {knyga.KnygosPavadinimas}" + Environment.NewLine);
            }
            return (knyguSarasas != String.Empty) ? knyguSarasas : "Knygu lentyna tuscia.";
        }
    }
}
