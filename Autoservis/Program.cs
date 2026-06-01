using System;
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
                    case "2": ZobrazZakazky(); break;
                    case "3": OpravVozidlo(); break;
                    case "4": DokonciZakazku(); break;
                    case "5": ZobrazFinance(); break;
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
        static void ZobrazZakazky()
        {
            Console.Clear();
            Console.WriteLine("=== AKTUÁLNÍ ZAKÁZKY ===");
            if (zakazky.Count == 0)
            {
                Console.WriteLine("Žádné zakázky k zobrazení.");
            }
            else
            {
                for (int i = 0; i < zakazky.Count; i++)
                {
                    Zakazka z = zakazky[i];
                    string stav = z.JeDokoncena ? "DOKONČENA" : "V ŘEŠENÍ";
                    Console.WriteLine($"{i + 1}. #{z.Id} | {z.Vozidlo.Znacka} {z.Vozidlo.Model} ({z.Vozidlo.Spz}) | {z.Porucha} | {z.TypOpravy ?? "Nezahájeno"} | {stav}");
                }
            }
            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }
        static void OpravVozidlo()
        {
            Console.Clear();
            Console.WriteLine("=== OPRAVA VOZIDLA ===");
            if (zakazky.Count == 0)
            {
                Console.WriteLine("Žádné zakázky k opravě.");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < zakazky.Count; i++)
            {
                if (!zakazky[i].JeDokoncena)
                {
                    Console.WriteLine($"{i + 1}. Zakázka #{zakazky[i].Id} - {zakazky[i].Vozidlo.Znacka} {zakazky[i].Vozidlo.Model}");
                }
            }
            Console.Write("Zadejte číslo zakázky: ");
            if (!int.TryParse(Console.ReadLine(), out int cislo) || cislo < 1 || cislo > zakazky.Count)
            {
                Console.WriteLine("Chyba: Neplatné číslo zakázky!");
                Console.ReadKey();
                return;
            }
            Zakazka vybrana = zakazky[cislo - 1];
            if (vybrana.JeDokoncena)
            {
                Console.WriteLine("Tato zakázka je již dokončena.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Vyberte typ opravy:");
            Console.WriteLine("1. Běžná údržba (500 Kč)");
            Console.WriteLine("2. Střední oprava (2500 Kč)");
            Console.WriteLine("3. Velká oprava (8000 Kč)");
            Console.WriteLine("4. Generální oprava (15000 Kč)");
            Console.Write("Vaše volba: ");
            string volba = Console.ReadLine();
            double cena = 0;
            string typ = "";
            switch (volba)
            {
                case "1": cena = 500; typ = "Běžná údržba"; break;
                case "2": cena = 2500; typ = "Střední oprava"; break;
                case "3": cena = 8000; typ = "Velká oprava"; break;
                case "4": cena = 15000; typ = "Generální oprava"; break;
                default:
                    Console.WriteLine("Neplatná volba typu opravy!");
                    Console.ReadKey();
                    return;
            }
            double konecnaCena = VypocitejCenuOpravy(cena, vybrana.Vozidlo.RokVyroby);
            vybrana.CenaOpravy = konecnaCena;
            vybrana.TypOpravy = typ;
            Console.WriteLine($"Oprava provedena. Cena: {konecnaCena:F2} Kč");
            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }
        static double VypocitejCenuOpravy(double zakladniCena, int rokVyroby)
        {
            int stari = DateTime.Now.Year - rokVyroby;
            double prirazka = 1.0;
            if (stari > 20) prirazka = 1.5;
            else if (stari > 10) prirazka = 1.2;
            else if (stari > 5) prirazka = 1.1;
            return zakladniCena * prirazka;
        }
        static void DokonciZakazku()
        {
            Console.Clear();
            Console.WriteLine("=== DOKONČENÍ ZAKÁZKY ===");
            if (zakazky.Count == 0)
            {
                Console.WriteLine("Žádné zakázky k dokončení.");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < zakazky.Count; i++)
            {
                if (!zakazky[i].JeDokoncena && !string.IsNullOrEmpty(zakazky[i].TypOpravy))
                {
                    Console.WriteLine($"{i + 1}. Zakázka #{zakazky[i].Id} - {zakazky[i].Vozidlo.Znacka} {zakazky[i].Vozidlo.Model} - {zakazky[i].CenaOpravy:F2} Kč");
                }
            }
            Console.Write("Zadejte číslo zakázky k dokončení: ");
            if (!int.TryParse(Console.ReadLine(), out int cislo) || cislo < 1 || cislo > zakazky.Count)
            {
                Console.WriteLine("Chyba: Neplatné číslo zakázky!");
                Console.ReadKey();
                return;
            }
            Zakazka vybrana = zakazky[cislo - 1];
            if (vybrana.JeDokoncena)
            {
                Console.WriteLine("Zakázka je již dokončena.");
                Console.ReadKey();
                return;
            }
            if (string.IsNullOrEmpty(vybrana.TypOpravy))
            {
                Console.WriteLine("Zakázka nemá provedenou opravu!");
                Console.ReadKey();
                return;
            }
            vybrana.JeDokoncena = true;
            celkovyZisk += vybrana.CenaOpravy;
            aktualniFinance += vybrana.CenaOpravy;
            Console.WriteLine($"Zakázka #{vybrana.Id} dokončena. Připsáno: {vybrana.CenaOpravy:F2} Kč");
            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }
        static void ZobrazFinance()
        {
            Console.Clear();
            Console.WriteLine("=== FINANČNÍ EVIDENCE ===");
            Console.WriteLine($"Aktuální stav financí: {aktualniFinance:F2} Kč");
            Console.WriteLine($"Celkový zisk: {celkovyZisk:F2} Kč");
            Console.WriteLine($"Počet dokončených zakázek: {zakazky.Count(z => z.JeDokoncena)}");
            Console.WriteLine($"Počet aktivních zakázek: {zakazky.Count(z => !z.JeDokoncena)}");
            Console.WriteLine("Stiskněte libovolnou klávesu...");
            Console.ReadKey();
        }
    }
}