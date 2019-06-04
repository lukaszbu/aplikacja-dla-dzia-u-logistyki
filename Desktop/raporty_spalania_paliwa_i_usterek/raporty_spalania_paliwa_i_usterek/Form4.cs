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
    public partial class Form4 : Form
    {
        SQLiteConnection polaczenie = new SQLiteConnection(string.Format("Data source={0}", Path.Combine(Application.StartupPath, "baza.db")));
        SQLiteCommand komenda;
        string zapytanieSQL = "";
        string us;
        private string zmienna1;
        private string zmienna2;
        private string zmienna3;
        private string zmienna4;
        private string zmienna5;
        private string zmienna6;
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
        public string Zmienna5
        {
            get { return zmienna5; }
            set { zmienna5 = value; }
        }
        public string Zmienna6
        {
            get { return zmienna6; }
            set { zmienna6 = value; }
        }
        public Form4()
        {
            InitializeComponent();
            polaczenie.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zmienna1 = textBox1.Text;           
            Zmienna3 = textBox3.Text;
            Zmienna4 = textBox4.Text;
            Zmienna5 = comboBox1.Text;
            Zmienna6 = textBox5.Text;
            Zmienna2 = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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
                zapytanieSQL = string.Format("select marka_pojazdu from pojazdy where nr_rejestracyjny='" + textBox1.Text + "'");
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox3.Text = us;
                zapytanieSQL = string.Format("select kategoria_pojazdu from pojazdy where nr_rejestracyjny='" + textBox1.Text + "'");
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox4.Text = us;
                zapytanieSQL = string.Format("select ilość_spalania_w_litrach_na_100_km from pojazdy where nr_rejestracyjny='" + textBox1.Text + "'");
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox5.Text = us;
                zapytanieSQL = string.Format("select rodzaj_paliwa from pojazdy where nr_rejestracyjny='" + textBox1.Text + "'");
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                comboBox1.Text = us;

            }
            catch
            {
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";

            }
        }
    }
}
