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

namespace egyszamjatekGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = textBox2.Text.Count(c => c != ' ') +" db";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter szamos = new StreamWriter("egyszamjatek2.txt"))
                {
                    szamos.Write(string.Format(textBox1.Text),
                        textBox2.Text);
                }
            }
            catch (DirectoryNotFoundException exc)
            {
                MessageBox.Show("Directory Could Not Be Found");
            }
        }
    }
}
