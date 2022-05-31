using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EgyszamjatekKonzol
{
    class adatok
    {
        public string nev;
        public int szam1;
        public int szam2;
        public int szam3;
        public int szam4;
    }
    class Program
    {
        private static object szam1;

        static void Main(string[] args)
        {
            List < adatok > jatek1= new List<adatok>();
            StreamReader sr = new StreamReader("egyszamjatek1.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darabok = sor.Split(' ');
                adatok e = new adatok();
                e.nev = darabok[0];
                e.szam1 = Convert.ToInt32(darabok[1]);
                e.szam2 = Convert.ToInt32(darabok[2]);
                e.szam3 = Convert.ToInt32(darabok[3]);
                e.szam4 = Convert.ToInt32(darabok[4]);
                jatek1.Add(e);
            }
            sr.Close();

            //3. feladat
            int jatekos1 = 0;
            foreach (var item in jatek1)
            {
                jatekos1 = jatek1.Count();
            }
            Console.WriteLine($"3. feladat: {jatekos1} fő.");

            //4. feladat
            Console.Write("4. feladat: Kérem a forduló sorszámát: ");
            int sorszam = Convert.ToInt32(Console.ReadLine());

            //5. feladat
            double atlag = 0;
            double ossz1 = 0;
            switch (sorszam)
            {
                case 1:
                    foreach (var item in jatek1)
                    {
                        ossz1 += item.szam1;
                        atlag = ossz1 / jatek1.Count();
                    }
                    Console.WriteLine($"5. feladat: A keresett foduló átlaga: {Math.Round(atlag,2)}");
                    break;
                case 2:
                    foreach (var item in jatek1)
                    {
                        ossz1 += item.szam2;
                        atlag = ossz1 / jatek1.Count();                        
                    }
                    Console.WriteLine($"5. feladat: A keresett foduló átlaga: {Math.Round(atlag, 2)}");
                    break;
                case 3:
                    foreach (var item in jatek1)
                    {
                        ossz1 += item.szam3;
                        atlag = ossz1 / jatek1.Count();                        
                    }
                    Console.WriteLine($"5. feladat: A keresett foduló átlaga: {Math.Round(atlag, 2)}");
                    break;
                case 4:
                    foreach (var item in jatek1)
                    {
                        ossz1 += item.szam4;
                        atlag = ossz1 / jatek1.Count();                        
                    }
                    Console.WriteLine($"5. feladat: A keresett foduló átlaga: {Math.Round(atlag, 2)}");
                    break;
            }
            Console.ReadLine();
        }
    }
}
