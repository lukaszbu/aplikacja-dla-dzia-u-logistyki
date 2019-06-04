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
using System.Data.OleDb;
using System.Data.SQLite;

namespace raporty_spalania_paliwa_i_usterek
{
    public partial class Form26 : Form
    {
        private bool prawda = false;
        private string zmienna1;
        private string zmienna2;
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
        public Form26()
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
            Zmienna2 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Prawda = true;
        }
    }
}
