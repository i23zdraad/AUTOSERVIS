AUTOSERVIS 🚗🔧
Konzolová aplikace pro správu zakázek v autoservisu napsaná v C#.
📋 Popis
Tento program slouží jako jednoduchý informační systém pro malý autoservis. Umožňuje evidovat zakázky, provádět opravy vozidel, sledovat jejich stav a spravovat finance servisu.
✨ Funkce
Table
Funkce	Popis
Přijetí zakázky	Zadání vozidla (značka, model, SPZ, rok výroby) s automatickou diagnostikou poruchy
Přehled zakázek	Zobrazení všech zakázek se stavem (v řešení / dokončena)
Oprava vozidla	Výběr typu opravy s dynamickou cenou podle stáří vozidla
Dokončení zakázky	Uzavření zakázky a připsání výnosu do financí
Finanční evidence	Přehled aktuálních financí, celkového zisku a počtu zakázek
🚀 Spuštění
Požadavky
.NET SDK (6.0 nebo novější)
Kompilace a spuštění
bash
dotnet build
dotnet run
🎮 Ovládání
Po spuštění se zobrazí hlavní menu:
plain
=== SPRÁVA AUTOSERVISU ===
1. Přijmout novou zakázku
2. Zobrazit aktuální zakázky
3. Opravit vozidlo
4. Dokončit zakázku
5. Zobrazit finance
6. Ukončit program
Vaše volba:
Výběr se provádí zadáním čísla a potvrzením klávesou Enter.
🧮 Ceník oprav
Table
Typ opravy	Základní cena
Běžná údržba	500 Kč
Střední oprava	2 500 Kč
Velká oprava	8 000 Kč
Generální oprava	15 000 Kč
Poznámka: Konečná cena se vypočítává podle stáří vozidla:
0–5 let: bez přirážky
6–10 let: +10 %
11–20 let: +20 %
20+ let: +50 %
🏗️ Struktura projektu
plain
Autoservis/
├── Program.cs          # Hlavní logika aplikace
└── Autoservis.csproj   # Projektový soubor
Třídy
Vozidlo – reprezentuje vozidlo (značka, model, SPZ, rok výroby)
Zakazka – reprezentuje servisní zakázku (ID, vozidlo, porucha, typ opravy, cena, stav)
📊 Finance
Výchozí stav financí: 50 000 Kč
Celkový zisk: automaticky se sčítá z dokončených zakázek
Aktuální finance: výchozí stav + všechny výnosy
📝 Poznámky
Program používá statické proměnné pro uchování dat – po ukončení se data neukládají.
Diagnostika poruch je generována náhodně ze 7 předdefinovaných typů závad.
Rok výroby je validován (1900 – aktuální rok).
👤 Autor
i23zdraad
⚠️ Tento projekt vznikl jako školní/výukový program pro práci s konzolovou aplikací v C#.
