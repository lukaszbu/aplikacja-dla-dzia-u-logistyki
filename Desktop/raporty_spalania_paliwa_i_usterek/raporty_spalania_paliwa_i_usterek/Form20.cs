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
    public partial class Form20 : Form
    {
        private string zmienna1;
        private string zmienna2;
        private string zmienna3;
        private string zmienna4;
        private string zmienna5;
        private string zmienna6;
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
        public Form20()
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
            Zmienna3 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Zmienna4 = dateTimePicker2.Value.ToString("HH:mm tt");
            Zmienna5 = dateTimePicker3.Value.ToString("yyyy-MM-dd");
            Zmienna6 = dateTimePicker4.Value.ToString("HH:mm tt");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text == dateTimePicker3.Text)
            {
                dateTimePicker4.MinDate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second);
            }
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                zapytanieSQL = string.Format("select imie from pracownicy where Id=" + int.Parse(textBox3.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox1.Text = us;
                zapytanieSQL = string.Format("select nazwisko from pracownicy where Id=" + int.Parse(textBox3.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox2.Text = us;

            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";




            }
        }
    }
}
