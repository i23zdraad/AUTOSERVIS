// Adam Zdráhal, 3.C, Programování a vývoj aplikací, Autoservis
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autoservis
{
    class Vozidlo
    {
        public string Znacka { get; set; }
        public string Model { get; set; }
        public string Spz { get; set; }
        public int RokVyroby { get; set; }
    }
    class Zakazka
    {
        public int Id { get; set; }
        public Vozidlo Vozidlo { get; set; }
        public string Porucha { get; set; }
        public string TypOpravy { get; set; }
        public double CenaOpravy { get; set; }
        public bool JeDokoncena { get; set; }
        public DateTime DatumVytvoreni { get; set; }
    }
    class Program
    {
        static List<Zakazka> zakazky = new List<Zakazka>();
        static double celkovyZisk = 0;
        static double aktualniFinance = 50000;
        static int dalsiId = 1;
        static Random random = new Random();
        static void Main(string[] args)
        {
            bool bezi = true;
            while (bezi)
            {
                ZobrazMenu();
                string volba = Console.ReadLine();
                switch (volba)
                {
                    case "1": PrijmiZakazku(); break;
                    case "2": //ZobrazZakazky(); break;
                    case "3": //OpravVozidlo(); break;
                    case "4": //DokonciZakazku(); break;
                    case "5": //ZobrazFinance(); break;
                    case "6": bezi = false; break;
                    default: Console.WriteLine("Neplatná volba!"); break;
                }
            }
        }
        static void ZobrazMenu()
        {
            Console.Clear();
            Console.WriteLine("=== SPRÁVA AUTOSERVISU ===");
            Console.WriteLine("1. Přijmout novou zakázku");
            Console.WriteLine("2. Zobrazit aktuální zakázky");
            Console.WriteLine("3. Opravit vozidlo");
            Console.WriteLine("4. Dokončit zakázku");
            Console.WriteLine("5. Zobrazit finance");
            Console.WriteLine("6. Ukončit program");
            Console.Write("Vaše volba: ");
        }
        static void PrijmiZakazku()
        {
            Console.Clear();
            Console.WriteLine("=== PŘIJETÍ NOVÉ ZAKÁZKY ===");
            Vozidlo vozidlo = new Vozidlo();
            Console.Write("Značka vozidla: ");
            vozidlo.Znacka = Console.ReadLine();
            Console.Write("Model vozidla: ");
            vozidlo.Model = Console.ReadLine();
            Console.Write("SPZ vozidla: ");
            vozidlo.Spz = Console.ReadLine();
            Console.Write("Rok výroby: ");
            if (!int.TryParse(Console.ReadLine(), out int rok) || rok < 1900 || rok > DateTime.Now.Year)
            {
                Console.WriteLine("Chyba: Neplatný rok výroby!");
                return;
            }
            vozidlo.RokVyroby = rok;
            string porucha = GenerujPoruchu();
            Console.WriteLine($"Diagnostika: {porucha}");
            Zakazka zakazka = new Zakazka
            {
                Id = dalsiId++,
                Vozidlo = vozidlo,
                Porucha = porucha,
                JeDokoncena = false,
                DatumVytvoreni = DateTime.Now
            };
            zakazky.Add(zakazka);
            Console.WriteLine($"Zakázka #{zakazka.Id} byla vytvořena.");
            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }
        static string GenerujPoruchu()
        {
            string[] poruchy = { "Vadná brzdová soustava", "Porucha motoru", "Defekt převodovky", "Závada elektroinstalace", "Unikající chladicí kapalina", "Opotřebená spojka", "Porucha palivového systému" };
            return poruchy[random.Next(poruchy.Length)];
        }
    }
}