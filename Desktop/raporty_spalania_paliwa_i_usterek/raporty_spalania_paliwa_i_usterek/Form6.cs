﻿using System;
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
    public partial class Form6 : Form
    {
        string il;
        int ilosc;
        string pi;
        string pn;
        string ip;
        int id;
        string idi;
        SQLiteConnection polaczenie = new SQLiteConnection(string.Format("Data source={0}", Path.Combine(Application.StartupPath, "baza.db")));
        SQLiteCommand komenda;
        string zapytanieSQL = "";
        string us;
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
       
        public Form6()
        {
            InitializeComponent();
            polaczenie.Open();
            zapytanieSQL = string.Format("select count(*) from pojazdy");
            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
            il = Convert.ToString(komenda.ExecuteScalar());
            ilosc = int.Parse(il);
            zapytanieSQL = string.Format("select max(id_pojazdu) from pojazdy");
            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
            idi = Convert.ToString(komenda.ExecuteScalar());
            id = int.Parse(idi);
            for (int i = 0; i < id; i++)
            {
                ip = Convert.ToString(i + 1);
                zapytanieSQL = string.Format("select NRB from pojazdy where id_pojazdu=" + ip);
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                pi = Convert.ToString(komenda.ExecuteScalar());
                if (pi == "")
                {
                    continue;
                }
                zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where id_pojazdu=" + ip);
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                pn = Convert.ToString(komenda.ExecuteScalar());
                if (pn == "")
                {
                    continue;
                }
                comboBox1.Items.Add(pn);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zmienna1 = comboBox1.Text;
            Zmienna2 = textBox2.Text;
            Zmienna3 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Zmienna4 = textBox3.Text;
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {              
                zapytanieSQL = string.Format("select nr_rejestracyjny from usterki where id_usterki=" + int.Parse(textBox3.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                comboBox1.Text = us;                
                zapytanieSQL = string.Format("select rodzaj_usterki from usterki where id_usterki=" + int.Parse(textBox3.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                textBox2.Text = us;
                zapytanieSQL = string.Format("select data_usterki from usterki where id_usterki=" + int.Parse(textBox3.Text));
                komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                us = Convert.ToString(komenda.ExecuteScalar());
                dateTimePicker1.Text = us;
         
            }
            catch
            {
                comboBox1.Text = "";
                textBox2.Text = "";

                dateTimePicker1.Text = "";
               


            }
        }
    }
}