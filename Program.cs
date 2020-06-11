using System;

namespace Uzduotys
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo status;
            while (true)
            {
                Console.Title = "Andriejus Gorbunovas";
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                string pasirinkimas = @"
*********************************************************
*                                                       *
*     Pasirinkite kokia uzduoti noretumete atlikti:     *
*                                                       *
*       1.  Gimimo data                                 *
*       2.  Mokykla (nepadarytas)                       *
*       3.  Knygu Lentyna                               *
*                                                       *
*********************************************************
";
                Console.WriteLine(pasirinkimas);
                Console.ResetColor();
                ConsoleKey consoleKey = Console.ReadKey().Key;
                Console.WriteLine();

                if (consoleKey == ConsoleKey.D1 || consoleKey == ConsoleKey.NumPad1)
                {
                    // 1.Metodas, kuris skaičiuoja asmens amžių šiai dienai ir išveda į amžių ekraną(tik pilnus metus).Vartotojas įveda
                    // datą formatu YYYY-MM - DD.Pvz.: įvedus 2000 - 02 - 05 gauname 20.

                    Console.Clear();
                    string year, month, day = string.Empty;
                    Console.WriteLine("Iveskite savo gimimo metus:");
                    Console.WriteLine("Metai :");
                    year = Console.ReadLine();
                    Console.WriteLine("Menuo :");
                    month = Console.ReadLine();
                    Console.WriteLine("Diena :");
                    day = Console.ReadLine();
                    try
                    {
                        DateTime date = Convert.ToDateTime(year + "-" + month + "-" + day);
                        var bday = float.Parse(date.ToString("yyyy.MMdd"));
                        var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                        if (now < bday)
                        {
                            Console.WriteLine("Ivestas blogas datos formatas");
                            Console.ReadLine();
                        }
                        Console.WriteLine("Jusu amzius " + (String.Format("{0:00}", (now - bday))));
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.ReadLine();
                    }
                }
                else if (consoleKey == ConsoleKey.D2 || consoleKey == ConsoleKey.NumPad2)
                {
                    //2.Mokykloje yra penkios dviliktokų klasės, kuriose atitinkamai yra 20,22,24,25,22 mokiniai.Paskaičiuoti kiekvienos klasės vidurkį
                    // ir bendrą klasių vidurkį. Atsakymą išvesti su ir be kablelio formatu:
                    //            Galutinis 9(8, 5 tarpinis)
                    //Klasių galutinis 8(8, 49 tarpinis)
                    //T.y.jei yra 3 klasės su pažymiais:
                    //            12A: 10,9,8,9 - vidurkis 9
                    //12B: 6,5,7 - vidurkis 6
                    //12C: 5,7,4,8 - vidurkis 6
                    //Bendras klasių vidurkis(9 + 6 + 6) / 3 = 7,00
                    //Nebūtina suvedinėti duomenų, galima naudotis paruoštais masyvais -stubais.
                    //char[] raides = { 'A', 'B', 'C' };
                    Console.Clear();
                    Console.WriteLine("Sita uzduotis dar neatlikta");
                }
                else if (consoleKey == ConsoleKey.D3 || consoleKey == ConsoleKey.NumPad3)
                {
                    // 3.Turime vartotojo knygų Top 5(Pavadinimas, Autorius, Leidimo metai, Kaina knygyne).Pagal vartotojo pageidavimą išvesti į ekraną
                    // knygų sąrašą, surūšiuotą didėjimo tvarka pagal leidimo metus ar kainą. Išvesti naujausią/ seniausią, pigiausią / brangiausią knygą
                    // (ar visas, jei yra tokių kelios).Nenaudoti LINQ.                

                    Console.Clear();
                    Console.WriteLine();

                    KnyguLentyna knyguLentyna = new KnyguLentyna();

                    VartotojoMeniu();

                    void Meniu()
                    {
                        Console.WriteLine("Suveskite teksta: ");
                        Console.WriteLine("'Ivesti' jei norite ivesti nauja knyga");
                        Console.WriteLine("'Sarasas' jei norite perziureti knygu sarasa");
                        Console.WriteLine("'Iseiti' jei norite pabaigti darba");
                    }

                    void DarbasSuKnyguLentyna(string vartotojoIvestis)
                    {
                        string knygosPavadinimas = "";
                        string knygosAutorius = "";
                        //DateTime knygosIsleidimoMetai;
                        //int knygosKaina = 0;

                        switch (vartotojoIvestis)
                        {
                            case "Ivesti":
                                Console.WriteLine("Iveskite knygos pavadinima: ");
                                knygosPavadinimas = Console.ReadLine();
                                switch (knygosPavadinimas)
                                {
                                    case "Iseiti":
                                        break;

                                    default:
                                        Console.WriteLine("Iveskite knygos autoriu: ");
                                        knygosAutorius = Console.ReadLine();
                                        
                                        knyguLentyna.IdetiIrasa(knygosPavadinimas, knygosAutorius);
                                        break;
                                }
                                break;

                            case "Sarasas":
                                Console.WriteLine(knyguLentyna.PerziuretiIrasus());
                                break;
                        }
                    }

                    void VartotojoMeniu()
                    {
                        Meniu();
                        string vartotojoIvestis = "";
                        while (vartotojoIvestis != "Iseiti")
                        {
                            Console.WriteLine("Ka Jus norite daryti?");
                            vartotojoIvestis = Console.ReadLine();
                            DarbasSuKnyguLentyna(vartotojoIvestis);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Atleiskite, bet tokia uzduotis nerasta.");
                }

                Console.WriteLine("\n\n Ar norite testi? Jei taip, spauskite: (Y/y) arba Esc. Jei ne - (N/n)");
                status = Console.ReadKey();
                if (status.Key == ConsoleKey.Y)
                {
                    continue;
                }
                else if (status.Key == ConsoleKey.N || status.Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}