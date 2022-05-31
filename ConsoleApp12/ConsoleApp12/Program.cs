using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp12
{
    class Program
    {

        static List<nevek> tanuloklista = new List<nevek>();
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("nevek.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darabok = sor.Split(';');
                nevek n = new nevek();
                n.ev = darabok[0];
                n.osztaly = darabok[1];
                n.nev = darabok[2];
                tanuloklista.Add(n);
            }
            sr.Close();

            //3. hány tanuló van?
            int db = 0;
            foreach (var item in tanuloklista)
            {
                db++;
            }
            Console.WriteLine(tanuloklista.Count);
            Console.WriteLine(db);

            //4. a leghosszabb név
            int maxhossz = 0;
            nevek maxnev=tanuloklista[0];
            foreach (var item in tanuloklista)
            {
                int hossz = item.nev.Replace(" ","").Length;
                if (hossz >maxhossz)
                {
                    maxhossz = hossz;
                    maxnev = item;
                }
            }
            Console.WriteLine(maxnev.nev);

            //5. feladat
            
                Console.WriteLine(tanuloklista[0].azonosito());
            Console.WriteLine(tanuloklista[tanuloklista.Count-1].azonosito());

            //6. feladat
            bool joe = false;
            Console.WriteLine("Kérek egy azonosítót? ");
            string azonositobekert = Console.ReadLine();
            foreach (var item in tanuloklista)
            {
                if (azonositobekert == item.azonosito())
                {
                    Console.WriteLine(item.ev);
                    Console.WriteLine(item.osztaly);
                    Console.WriteLine(item.nev);
                    joe = true;
                }
            }
            if (!joe)
            {
                Console.WriteLine("Nincs megfeleló tanuló!");
            }

            //7. feladat
            Random r = new Random();
            JelszóGeneráló jg = new JelszóGeneráló(r);
            Console.Write(tanuloklista[0].nev+" ");
            Console.Write(jg.Jelszó(4));
            Console.ReadLine();
        }
    }
}
