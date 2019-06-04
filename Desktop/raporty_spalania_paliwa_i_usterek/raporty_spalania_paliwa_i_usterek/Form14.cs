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
    public partial class Form14 : Form
    {
        private string zmienna1;
        private string zmienna2;
        private string zmienna3;
        private string zmienna4;
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
        public string Zmienna3
        {
            get { return zmienna3; }
            set { zmienna3 = value; }
        }
        public string Zmienna4
        {
            get { return zmienna4; }
            set { zmienna4 = value; }
        }
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zmienna1 = textBox1.Text;
            Zmienna2 = textBox2.Text;
            Zmienna3 = comboBox1.Text;
            Zmienna4 = comboBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
