using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game2025bestof
{
    class labda
    {
        public int x;
        public int y;
        public int iranyx;
        public int iranyy;
        public int meret;

        public labda(int x, int y, int iranyx, int iranyy, int meret)
        {
            this.x = x;
            this.y = y;
            this.iranyx = iranyx;
            this.iranyy = iranyy;
            this.meret = meret;
        }
        public bool talalat(int x, int y) {
            
            if (Math.Abs(this.x-x)<this.meret/2 && Math.Abs(this.y - y) < this.meret/2)
            {
                return true;
            }
            else
            {
                return false;
            }      
        }
    }

}
