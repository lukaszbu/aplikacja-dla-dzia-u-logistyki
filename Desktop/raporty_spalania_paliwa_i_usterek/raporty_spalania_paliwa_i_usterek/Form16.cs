using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace raporty_spalania_paliwa_i_usterek
{
    public partial class Form16 : Form
    {
        private string zmienna1;
        private string zmienna2;
        private string zmienna3;
        SQLiteConnection polaczenie = new SQLiteConnection(string.Format("Data source={0}", Path.Combine(Application.StartupPath, "baza.db")));
        SQLiteCommand komenda;
        string zapytanieSQL = "";
        string us;
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
        public Form16()
        {
            InitializeComponent();
            polaczenie.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zmienna1 = textBox1.Text;
            Zmienna2 = textBox2.Text;
            Zmienna3 = textBox3.Text;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zapytanieSQL = string.Format("select imie from pracownicy where Id=" + int.Parse(textBox1.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox2.Text = us;
                zapytanieSQL = string.Format("select nazwisko from pracownicy where Id=" + int.Parse(textBox1.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox3.Text = us;
                zapytanieSQL = string.Format("select status from pracownicy where Id=" + int.Parse(textBox1.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                comboBox1.Text = us;
                zapytanieSQL = string.Format("select stanowisko from pracownicy where Id=" + int.Parse(textBox1.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                comboBox2.Text = us;

            }
            catch
            {
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
        }
    }
}
