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
    public partial class Form18 : Form
    {
        private string zmienna1;
        private string zmienna2;
        private string zmienna3;
        private string zmienna4;
        private string zmienna5;
        private string zmienna6;
        private string zmienna7;
        private string zmienna8;
        SQLiteConnection polaczenie = new SQLiteConnection(string.Format("Data source={0}", Path.Combine(Application.StartupPath, "baza.db")));
        SQLiteCommand komenda;
        string zapytanieSQL = "";
        string us;
        string im;
        string na;
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
        public string Zmienna7
        {
            get { return zmienna7; }
            set { zmienna7 = value; }
        }
        public string Zmienna8
        {
            get { return zmienna8; }
            set { zmienna8 = value; }
        }
        public Form18()
        {
            InitializeComponent();
            polaczenie.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zmienna1 = textBox1.Text;
            Zmienna2 = textBox2.Text;
            Zmienna3 = textBox3.Text;
            Zmienna4 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Zmienna5 = dateTimePicker2.Value.ToString("HH:mm tt");
            Zmienna6 = dateTimePicker3.Value.ToString("yyyy-MM-dd");
            Zmienna7 = dateTimePicker4.Value.ToString("HH:mm tt");
            Zmienna8 = textBox4.Text;
         
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zapytanieSQL = string.Format("select Id_pracownika from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                im = Convert.ToString(komenda.ExecuteScalar());
                zapytanieSQL = string.Format("select imie from pracownicy where Id=" + int.Parse(im));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox1.Text = us;
                zapytanieSQL = string.Format("select Id_pracownika from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                na = Convert.ToString(komenda.ExecuteScalar());
                zapytanieSQL = string.Format("select nazwisko from pracownicy where Id=" + int.Parse(na));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox2.Text = us;
                zapytanieSQL = string.Format("select rodzaj_wydanej_odzieży from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox3.Text = us;
                zapytanieSQL = string.Format("select data_wydania_odzieży from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                dateTimePicker1.Text= us;
                zapytanieSQL = string.Format("select godzina_wydania_odzieży from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                dateTimePicker2.Text = us;
                zapytanieSQL = string.Format("select data_oddania_odzieży from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                dateTimePicker3.Text = us;
                zapytanieSQL = string.Format("select godzina_oddania_odzieży from wydawanie_odzieży where Id=" + int.Parse(textBox4.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                dateTimePicker4.Text = us;

            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
                dateTimePicker3.Text = "";
                dateTimePicker4.Text = "";


            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Text==dateTimePicker3.Text)
            {
                dateTimePicker4.MinDate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second);
            }
        }
    }
}
