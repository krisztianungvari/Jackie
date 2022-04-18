using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jackie
{
    class Program
    {
      static  List<Eredmenyek> eredmeny = new List<Eredmenyek>();
        static void Main(string[] args)
        {
            Beolvasas();
            Feladat03();
            Feladat04();
            Feladat04b();
            Feladat05();
            Feladat06();

            Console.WriteLine("Program vége!");
            Console.ReadKey();
        }

        private static void Feladat06()
        {
            /*Hozzon létre jackie. htmI néven UTF-8 kódolású szöveges állomanyt! Az állomány
             * szabvrányos HTML5 formátumú legyen, azza| a kitétellel' hogy a head elem tartalma üresen hagyható! Az 
             * állomanybantáb|ázatos formában jelenjen meg a versenyzés éve,
             * a versenyek és a gyóze|mek sziímal Atáblázat felett első szintű címsorral jelenjen meg
             * Jackie Stewart neve! oldja meg, hogy a táb|ázat cellái egy képpont vastag folytonos
             * fekete vonallal legyenek keretezve! */
            string html = "<!DOCTYPE html><html><head><title> 6.feladat </title><meta charset = \"UTF-8\">"
         + "<meta name = \"viewport\" content = \"width=device-width, initial-scale=1.0\">"
         + "<style>td{border: 1px solid} </style></head>"
         + "<body>"
         + "<table>"
            + "<tr><td> Év </td><td> Versenyek </td><td> Győzelmek </td></tr>";
            foreach (Eredmenyek item in eredmeny)
            {
                html += $" <tr><td> {item.Ev} </td><td> {item.Versenyek} </td><td> {item.Gyozelmek} </td></tr>";
            }
            html += "</table>  </body> </html>";
            File.WriteAllText("Jackie.html", html);

        }

        private static void Feladat05()
        {
            Console.WriteLine("\n 5. feladat: ");
            /*Határozza meg és írja
             *ki a minta szerint, hogy Jackie Stewart számára melyik évtized
             *mennyire volt sikeres a megnyert versenyek száma alapjan!Az évtized alatt az évek
             *tízes csoportját erjük(azaz például a 70 - es évek alatt az I970- től - I979.ig terjedő tartományt) */
            var gy = eredmeny.GroupBy(a => (int)a.Ev / 10).Select(b => new { evtized = b.Key, gyözelmek = b.Sum(c => c.Gyozelmek) });
            foreach (var item in gy)
            {
                Console.WriteLine($"\tAz {item.evtized}0-es évtizedben {item.gyözelmek} győzelme volt.");
            }

        }

        private static void Feladat04b()
        {
            Eredmenyek keresett = eredmeny[0];
            foreach (Eredmenyek eredmenyek in eredmeny)
            {
                if (eredmenyek.Versenyek > keresett.Versenyek)
                {
                    keresett = eredmenyek;
                }
             
            }// legnagyobb futam szám kiválasztás vége
            Console.WriteLine($"4. feladat: {keresett.Ev}");
        }

        private static void Feladat04()
        {
            /* Hatéttozza meg és írja ki a minta szerint, hogy Jackie Stewart melyik évben indult el a
            legtöbb versenyen!Feltételezheti, hogy nincs a versenyek számábanholtverseny */

            int ev = eredmeny.Max(a => a.Versenyek); //a = az egyik eleme a nagy objektumnak!! Lambda operátor (foreach)
            Console.WriteLine($"4. feladat: {eredmeny.Find(a => a.Versenyek == ev).Ev}");
        }

        private static void Beolvasas()
        {
            foreach (string eredmenyek in File.ReadAllLines("jackie.txt").Skip(1))
            {
                eredmeny.Add(new Eredmenyek(eredmenyek));
            }
        }

        private static void Feladat03()
        {
            Console.WriteLine("3. feladat: {0}", eredmeny.Count);
        }
    }
}
