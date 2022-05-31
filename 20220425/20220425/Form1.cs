using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20220425
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<labda> labdalista = new List<labda>();
        labda jatekos = new labda(100, 100, 0, 0, 10);
        int egerx = 100;
        int egery = 100;
        Random r = new Random();
        private void button2_Click(object sender, EventArgs e)
        {
            randomlabda();
        }

        public void randomlabda()
        {
            int veletlenx = r.Next(1, pictureBox1.Width - 10);
            int veletleny = r.Next(1, pictureBox1.Height - 10);
            int veletleniranyx = r.Next(-6, 6);
            int veletleniranyy = r.Next(-6, 6);
            labda l = new labda(veletlenx, veletleny, veletleniranyx, veletleniranyy, 10);
            labdalista.Add(l);
            label1.Text = labdalista.Count.ToString();

        }

        long frame = 0;
        int pont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            frame++;
            label1.Text = frame.ToString();
            //létrehozás
            BufferedGraphicsContext currentContext;
            BufferedGraphics myBuffer;
            currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(pictureBox1.CreateGraphics(), this.DisplayRectangle);
            Random rand = new Random();
            Brush br = new SolidBrush(Color.Red);
            Brush br2 = new SolidBrush(Color.White);
            myBuffer.Graphics.Clear(Color.Green);
            //100frame alatt ne csináljon semmit:
            if(frame < 50)
            {
                Font f = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
                myBuffer.Graphics.DrawString("Hamarosan kezdődik a játék", f, br, 100, 100);
            }
            else
            {
                //itt működik a játék

                /*for (int i = 0; i < labdalista.Count; i++)
                {
                    if (jatekos.talalat(labdalista[i].x, labdalista[i].y))
                    {
                        labdalista[i].iranyx *= -1;
                        labdalista[i].iranyy *= -1;
                    }
                }*/
                //pattanás
                for (int i = 0; i < labdalista.Count; i++)
            {
                //jobb szél
                if (labdalista[i].x>pictureBox1.Width)
                {
                    labdalista[i].iranyx *= -1;
                }
                //bal szél
                if (labdalista[i].x<0)
                {
                    labdalista[i].iranyx *= -1;
                }
                //alsó
                if (labdalista[i].y>pictureBox1.Height)
                {
                    labdalista[i].iranyy *= -1;
                }
                //felső
                if (labdalista[i].y<0)
                {
                    labdalista[i].iranyy *= -1;
                }

                    for (int j = i + 1; j < labdalista.Count; j++)
                    {
                        if (labdalista[i].talalat(labdalista[j]))
                        {
                            int elozox = labdalista[i].x - labdalista[i].iranyx;
                            int elozoy = labdalista[i].y - labdalista[i].iranyy;
                            int elozox2 = labdalista[j].x - labdalista[j].iranyx;
                            int elozoy2 = labdalista[j].y - labdalista[j].iranyy;
                            if (elozoy != labdalista[j].y)
                            {
                                labdalista[i].iranyy *= -1;
                                labdalista[j].iranyy *= -1;
                            }
                            if (elozoy != labdalista[j].x)
                            {
                                labdalista[i].iranyx *= -1;
                                labdalista[j].iranyx *= -1;
                            }

                        }
                    }
            }
                for (int i = 0; i < labdalista.Count; i++)
                {
                    labdalista[i].x += labdalista[i].iranyx;
                    labdalista[i].y += labdalista[i].iranyy;
                }

                jatekos.x = (egerx + 19 * jatekos.x) / 20;
                jatekos.y = (egery + 19 * jatekos.y) / 20;
                //mozgás
                for (int i = 0; i < labdalista.Count; i++)
                {
                    if (jatekos.talalat(labdalista[i]))
                    {

                        jatekos.meret += labdalista[i].meret / 2;

                        if (labdalista.Count > 0)
                        {
                            pont++;
                            labdalista.RemoveAt(i);
                        }
                        label2.Text = "Pont: " + pont;
                        if (pont == 25)
                        {
                            MessageBox.Show("Jól lakott!!!");
                            this.Close();
                        }
                        // labdalista[i].iranyx *= -1;
                        //labdalista[i].iranyy *= -1;


                    }
                }
                if (labdalista.Count <= 0)
                {
                    for (int i = 0; i < r.Next(1, 10); i++)
                    {
                        randomlabda();
                    }
                }
                //kirajzol
                for (int i = 0; i < labdalista.Count; i++)
            {
                myBuffer.Graphics.FillEllipse(br, labdalista[i].x, labdalista[i].y, labdalista[i].meret, labdalista[i].meret);
            }
            myBuffer.Graphics.FillEllipse(br2, jatekos.x - jatekos.meret / 2, jatekos.y - jatekos.meret / 2, jatekos.meret, jatekos.meret);
            }
            myBuffer.Render();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Üdvözöllek a játékomban!\nA jaték során körök mozgásával lehet foglalkozni.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A játékot a labda gomb megnyomásával lehet elindítani.\nA gomb további lenyomásával újabb és újabb labdákat helyezhetsz a képernyőre melyek még látványosabbá teszik a játékot a felhasználó számára.\nA játék során egy éhes felshasználót irányíthatunk aki nagyon szeret enni ezért képes a falon is átmenni.\nMivel kis barátunk szereti a kihívásokat ezért képes újból meg és meg újjulni, hogy újjabb kihívások keressen magának.\nA játékhoz jó sroakozást de siess h minél előbb jól lakjon!!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labdalista.Clear();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            int sebesseg = 10;
            switch (e.KeyCode)
            {
                case Keys.A:
                    jatekos.x -= sebesseg;
                    break;
                case Keys.W:
                    jatekos.y -= sebesseg; ;
                    break;
                case Keys.D:
                    jatekos.x += sebesseg;
                    break;
                case Keys.S:
                    jatekos.y += sebesseg;
                    break;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
                       
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_DragOver(object sender, DragEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_DragOver(object sender, DragEventArgs e)
        {
            for (int i = 0; i < labdalista.Count; i++)
            {
                if (labdalista[i].x < 79 && labdalista[i].y < 321)
                {
                    pont++;
                    label2.Text = "Pont: " + pont;
                }

                if (labdalista[i].x < 567 && labdalista[i].y < 321)
                {
                    pont++;
                    label2.Text = "Pont: " + pont;
                }

                if (labdalista[i].x < 79 && labdalista[i].y < 15)
                {
                    pont++;
                    label2.Text = "Pont: " + pont;
                }

                if (labdalista[i].x < 79 && labdalista[i].y < 23)
                {
                    pont++;
                    label2.Text = "Pont: " + pont;
                }

            }
            //label2.Text = "Pont: " + pont
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            egerx = e.X;
            egery = e.Y;
        }
    }
}
