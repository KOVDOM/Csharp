using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dominoerettsegi
{
    class domino
    {
        public string sor1;
        public string sor2;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<domino> lista = new List<domino>();
            StreamReader sr = new StreamReader("domino.txt");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] darabok = sor.Split(' ');
                domino d = new domino();
                d.sor1 = darabok[0];
                d.sor2 = darabok[1];
                lista.Add(d);
            }
            sr.Close();

            foreach (var item in lista)
            {
                Console.Write(item.sor1+" ");
                Console.WriteLine(item.sor2);
            }

            //3. feladat2
            int sorok = 0;
            foreach (var item in lista)
            {
                sorok = lista.Count();
            }
            Console.WriteLine("Sorok száma: "+sorok+"db");

            //4. feladat
            Console.Write("Sorszám: ");
            string sorszam = Console.ReadLine();
            foreach (var item in lista)
            {
                int szamol = lista.Count();
                if (//ezt nem tudtam)
                {
                    Console.WriteLine("A(z)" + sorszam + ". megfelelő dominó: " + item.sor1 + " " + item.sor2);
                }
            }
            //5. feladat
            int dupla = 0;
            foreach (var item in lista)
            {
                if (item.sor1==item.sor2)
                {
                    dupla++;
                }
            }
            Console.WriteLine("Dupla dominók száma: "+dupla);

            //6. feladat
            bool szabalyos = false;
            if (szabalyos == true)
            {
                Console.WriteLine("Szabályosak az illesztések!");
            }
            else
            {
                Console.WriteLine("Nem szabályosak az illesztések!");
            }
            Console.ReadKey();
        }
    }
}
