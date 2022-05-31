using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dominoForm

{
    public partial class Form1 : Form
    {
        class domino
        {
            public string sor1;
            public string sor2;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("domino.txt");
            richTextBox1.Text = sr.ReadToEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += textBox2.Text+" "+textBox1.Text;
            if (textBox2.Text==" " || textBox1.Text==" ")
            {
                MessageBox.Show("Nincs megadva dominó");
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Nincsennek beolvasva a dominók");
            }
        }
    }
}
