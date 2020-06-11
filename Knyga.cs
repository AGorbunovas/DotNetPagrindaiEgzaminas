using System;
using System.Collections.Generic;
using System.Text;

namespace Uzduotys
{
    public class Knyga
    {
        public Knyga(string knygosPavadinimas, string knygosAutorius, DateTime knygosIsleidimoMetai, int knygosKaina)
        {
            KnygosPavadinimas = knygosPavadinimas;
            KnygosAutorius = knygosAutorius;
            KnygosIsleidimoMetai = knygosIsleidimoMetai;
            KnygosKaina = knygosKaina;
        }

        public string KnygosPavadinimas { get; set; }
        public string KnygosAutorius { get; set; }
        public DateTime KnygosIsleidimoMetai { get; set; }
        public int KnygosKaina { get; set; }


    }
}
