using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raporty_spalania_paliwa_i_usterek
{
    public partial class Form31 : Form
    {
        private bool prawda = false;
        private string zmienna1;
        private string zmienna2;      
        public string Zmienna1
        {
            get { return zmienna1; }
            set { zmienna1 = value; }
        }
        public string Zmienna2
        {
            get { return zmienna2; }
            set { zmienna2 = value; }
        }       
        public bool Prawda
        {
            get { return prawda; }
            set { prawda = value; }
        }
        public Form31()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zmienna1 = textBox1.Text;
            Zmienna2 = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prawda = true;
        }
    }
}
