using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220425
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

        public bool talalat(labda l)
        {
            //találat
            if (Math.Abs(this.x - l.x) < this.meret / 2 && Math.Abs(this.y - l.y) < this.meret / 2)
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
