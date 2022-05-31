using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2025bestof
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<labda> labdalista = new List<labda>();
        labda jatekos = new labda(100,100,0,0,50);
        int egerx = 100;
        int egery = 100;
        Random r = new Random();
        private void button2_Click(object sender, EventArgs e)
        {

            randomlabda();
        }

        public void randomlabda() {
            int veletlenx = r.Next(1, pictureBox1.Width - 10);
            int veletleny = r.Next(1, pictureBox1.Height - 10);
            int veletleniranyx = r.Next(-6, 6);
            int veletleniranyy = r.Next(-6, 6);
            labda l = new labda(veletlenx, veletleny, veletleniranyx, veletleniranyy, 10);
            labdalista.Add(l);
            label1.Text = labdalista.Count.ToString();

        }

        long frame = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            frame++;
            label1.Text = frame.ToString();
            //létrehozom az eszközöket, vászon, ecset stb
            BufferedGraphicsContext currentContext;
            BufferedGraphics myBuffer;
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(pictureBox1.CreateGraphics(), this.DisplayRectangle);
            Brush br = new SolidBrush(Color.White);
            Brush br2 = new SolidBrush(Color.Blue);
            myBuffer.Graphics.Clear(Color.SeaGreen);
            //pattanás
            for (int i = 0; i < labdalista.Count; i++)
            {
                //jobb szél:
                if (labdalista[i].x>pictureBox1.Width)
                {
                    labdalista[i].iranyx *= -1;
                }

                //bal szél:
                if (labdalista[i].x < 0)
                {
                    labdalista[i].iranyx *= -1;
                }

                //alsó szél:
                if (labdalista[i].y > pictureBox1.Height)
                {
                    labdalista[i].iranyy *= -1;
                }

                //felső szél:
                if (labdalista[i].y < 0)
                {
                    labdalista[i].iranyy *= -1;
                }

                for (int j = i+1; j < labdalista.Count; j++)
                {
                    if (labdalista[i].talalat(labdalista[j].x,labdalista[j].y))
                    {
                        labdalista[i].iranyx *= -1;
                        labdalista[i].iranyy *= -1;
                        labdalista[j].iranyx *= -1;
                        labdalista[j].iranyy *= -1;
                    }

                }
            }


            //mozgatok
            for (int i = 0; i < labdalista.Count; i++)
            {
                labdalista[i].x += labdalista[i].iranyx;
                labdalista[i].y += labdalista[i].iranyy;
            }
            
              //  jatekos.x = (egerx + 19 * jatekos.x) / 20;
              //  jatekos.y = (egery + 19 * jatekos.y) / 20;
           
           

            //jatékos találat
            for (int i = 0; i < labdalista.Count; i++)
            {
                if (jatekos.talalat(labdalista[i].x, labdalista[i].y))
                {
                    /*
                   jatekos.meret += labdalista[i].meret;
                    if (labdalista.Count>0)
                    {
                        labdalista.RemoveAt(i);
                    }
                   */
                    labdalista[i].iranyx *= -1;
                    labdalista[i].iranyy *= -1;


                }
            }

            if (labdalista.Count<=0)
            {
                for (int i = 0; i < r.Next(1,10); i++)
                {
                    randomlabda();
                }
            }
            //kirajzolok
            for (int i = 0; i < labdalista.Count; i++)
            {
                myBuffer.Graphics.FillEllipse(br, labdalista[i].x, labdalista[i].y, labdalista[i].meret, labdalista[i].meret);
            }
            myBuffer.Graphics.FillEllipse(br2, jatekos.x - jatekos.meret/2, jatekos.y- jatekos.meret / 2, jatekos.meret, jatekos.meret);
            myBuffer.Render();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 50;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            egerx = e.X;
            egery = e.Y;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            int sebesseg = 10;
            switch (e.KeyCode)
            {
                case Keys.A:
                    jatekos.x -= sebesseg ;
                    break;
                case Keys.W:
                    jatekos.y -= sebesseg; ;
                    break;
                case Keys.D:
                    jatekos.x+=sebesseg;
                    break;
                case Keys.S:
                    jatekos.y+=sebesseg;
                    break;

            }
        }
    }
}
