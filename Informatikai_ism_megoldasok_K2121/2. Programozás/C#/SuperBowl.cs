using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowl
{
    // 2. feladat: RomaiSorszam osztály elérhetővé tétele a csharp.txt állományból:
    class RomaiSorszam
    {
        public string RomaiSsz { get; private set; }

        private static Dictionary<char, int> RomaiMap = new Dictionary<char, int>()
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        public string ArabSsz
        {
            get
            {
                int ertek = 0;
                string romaiSzam = RomaiSsz.TrimEnd('.');
                for (int i = 0; i < romaiSzam.Length; i++)
                {
                    if (i + 1 < romaiSzam.Length && 
                        RomaiMap[romaiSzam[i]] < RomaiMap[romaiSzam[i + 1]])
                    {
                        ertek -= RomaiMap[romaiSzam[i]];
                    }
                    else
                    {
                        ertek += RomaiMap[romaiSzam[i]];
                    }
                }
                return $"{ertek}.";
            }
        }

        public RomaiSorszam(string romaiSsz)
        {
            RomaiSsz = romaiSsz.ToUpper();
        }
    }
    class Döntő
    {
        // Ssz;Dátum;Győztes;Eredmény;Vesztes;Helyszín;VárosÁllam;Nézőszám
        public RomaiSorszam Ssz { get; private set; }
        public string Dátum { get; private set; }
        public string Győztes { get; private set; }
        public string Eredmény { get; private set; }
        public string Vesztes { get; private set; }
        public string Helyszín { get; private set; }
        public string VárosÁllam { get; private set; }
        public int Nézőszám { get; private set; }
        public int GyőztesPont => int.Parse(Eredmény.Split('-')[0]);
        public int VesztesPont => int.Parse(Eredmény.Split('-')[1]);
        public int PontDiff => GyőztesPont - VesztesPont;

        public Döntő(string sor)
        {
            string[] m = sor.Split(';');
            Ssz = new RomaiSorszam(m[0]);
            Dátum = m[1];
            Győztes = m[2];
            Eredmény = m[3];
            Vesztes = m[4];
            Helyszín = m[5];
            VárosÁllam = m[6];
            Nézőszám = int.Parse(m[7]);
        }
    }
    class SuperBowl
    {
        static void Main()
        {
            // 3. feladat: Adatok beolvasása, tárolása
            List<Döntő> döntők = new List<Döntő>();
            foreach (var sor in File.ReadAllLines("SuperBowl.txt").Skip(1))
            {
                döntők.Add(new Döntő(sor));
            }

            Console.WriteLine($"4. feladat: Döntők száma: {döntők.Count}");

            // 5. feladt: Átlagos pontkülönbség
            int összDiff = 0;
            foreach (var d in döntők)
            {
                összDiff += d.PontDiff;
            }
            Console.WriteLine($"5. feladat: Átlagos pontkülönbség: {(double)összDiff / döntők.Count:f1}");

            Console.WriteLine("6. feladat: Legmagasabb nézőszám a döntők során:");
            Döntő maxNézőDöntő = döntők.First();
            foreach (var d in döntők.Skip(1))
            {
                if (d.Nézőszám > maxNézőDöntő.Nézőszám)
                {
                    maxNézőDöntő = d;
                }
            }
            Console.WriteLine($"\t Sorszám (dátum): {maxNézőDöntő.Ssz.ArabSsz} ({maxNézőDöntő.Dátum})");
            Console.WriteLine($"\t Győztes csapat: {maxNézőDöntő.Győztes}, szerzett pontok: {maxNézőDöntő.GyőztesPont}");
            Console.WriteLine($"\t Vesztes csapat: {maxNézőDöntő.Vesztes}, szerzett pontok: {maxNézőDöntő.VesztesPont}");
            Console.WriteLine($"\t Helyszín: {maxNézőDöntő.Helyszín}");
            Console.WriteLine($"\t Város, állam: {maxNézőDöntő.VárosÁllam}");
            Console.WriteLine($"\t Nézőszám: {maxNézőDöntő.Nézőszám}");

            // 7. feladat: SuperBowlNew.txt állomány készítése
            Dictionary<string, int> stat = new Dictionary<string, int>();
            List<string> ki = new List<string>();
            ki.Add("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
            foreach (var d in döntők)
            {
                // Megoldás szótárral:
                //if (stat.ContainsKey(d.Győztes)) stat[d.Győztes]++;
                //else stat.Add(d.Győztes, 1);
                //if (stat.ContainsKey(d.Vesztes)) stat[d.Vesztes]++;
                //else stat.Add(d.Vesztes, 1);
                //string győztes = $"{d.Győztes} ({stat[d.Győztes]})";
                //string vesztes = $"{d.Vesztes} ({stat[d.Vesztes]})";

                // Megoldás szótár nélkül:
                int győztesDb = 0;
                int vesztesDb = 0;
                foreach (var sor in ki)
                {
                    if (sor.Contains(d.Győztes)) győztesDb++;
                    if (sor.Contains(d.Vesztes)) vesztesDb++;
                }
                string győztes = $"{d.Győztes} ({győztesDb + 1})";
                string vesztes = $"{d.Vesztes} ({vesztesDb + 1})";

                ki.Add($"{d.Ssz.ArabSsz};{d.Dátum};{győztes};{d.Eredmény};{vesztes};{d.Nézőszám}");
            }
            File.WriteAllLines("SuperBowlNew.txt", ki, Encoding.UTF8);

            Console.ReadKey(); // Nem a megoldás része
        }
    }
}
