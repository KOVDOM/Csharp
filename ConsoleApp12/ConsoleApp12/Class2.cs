using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    class nevek
    {
        public string ev;
        public string osztaly;
        public string nev;


        public string azonosito()
        {
            string azonosito = (ev[3]+osztaly+nev.Substring(0,3)+nev.Substring(nev.IndexOf(' ')+1,3)).ToLower();
 
            return azonosito;

        }



    }

 
}
