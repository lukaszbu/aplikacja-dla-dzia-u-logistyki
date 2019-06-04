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
using System.Data.SQLite;
using System.Diagnostics;

namespace raporty_spalania_paliwa_i_usterek
{
    public partial class Form1 : Form
    {
        SQLiteConnection polaczenie = new SQLiteConnection(string.Format("Data source={0}", Path.Combine(Application.StartupPath, "baza.db")));
        SQLiteCommand komenda;
        string zapytanieSQL = "";
        string us;
        string us1;
        string ilosc;
        string rejestracja="";
        string min;
        string max;
        int j,k;
        int dystans;
        double spalanie;
        bool czywyswietlone1 = false;
        bool czywyswietlone2 = false;
        bool czywyswietlone3 = false;
        bool czywyswietlone4 = false;
        bool czywyswietlone5 = false;
        bool czywyswietlone6 = false;
        bool czywyswietlone7 = false;
        int suma = 0;
        string suma1;
        public Form1()
        {
            InitializeComponent();
            polaczenie.Open();
        }
        private SQLiteDataAdapter DB, DB1,DB2,DB3,DB4,DB5,DB6;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private DataSet DS1 = new DataSet();
        private DataTable DT1 = new DataTable();
        private DataSet DS2 = new DataSet();
        private DataTable DT2 = new DataTable();
        private DataSet DS3 = new DataSet();
        private DataTable DT3 = new DataTable();
        private DataSet DS4 = new DataSet();
        private DataTable DT4 = new DataTable();
        private DataSet DS5 = new DataSet();
        private DataTable DT5 = new DataTable();
        private DataSet DS6 = new DataSet();
        private DataTable DT6 = new DataTable();

        private void button4_Click(object sender, EventArgs e)
        {
            
            zapytanieSQL = string.Format("select * from pojazdy order by nr_rejestracyjny");
            DB = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            czywyswietlone1 = true;
            this.dataGridView1.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if((f.Zmienna1=="") || (f.Zmienna2=="") || (f.Zmienna3=="") || (f.Zmienna4=="") || (f.Zmienna5=="") || (f.Zmienna6 == ""))
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                        {
                        zapytanieSQL = string.Format("insert into pojazdy(nr_rejestracyjny,NRB,marka_pojazdu,kategoria_pojazdu,ilość_spalania_w_litrach_na_100_km,rodzaj_paliwa)values('" + f.Zmienna1 + "','" + f.Zmienna6 + "','" + f.Zmienna2 + "','" + f.Zmienna3 + "'," + int.Parse(f.Zmienna4) + ",'"+f.Zmienna5+"')");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        komenda.ExecuteNonQuery();
                    }
                   
                    
                    
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            polaczenie.Close();
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 g = new Form3();
            {
                if (g.ShowDialog() == DialogResult.OK)
                {
                    if(g.Zmienna1=="")
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='"+g.Zmienna1+"'");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if(us=="")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("delete from pojazdy where nr_rejestracyjny='" + g.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteNonQuery();
                        }
                        
                    }
                    

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 h = new Form4();
            {
                if (h.ShowDialog() == DialogResult.OK)
                {
                    if((h.Zmienna1=="") || (h.Zmienna2=="") || (h.Zmienna3=="") || (h.Zmienna4=="") || (h.Zmienna5=="") || (h.Zmienna6 == ""))
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='" + h.Zmienna1 + "'");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if(us=="")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("update pojazdy set NRB='" + h.Zmienna2 + "',marka_pojazdu='" + h.Zmienna3 + "', kategoria_pojazdu='" + h.Zmienna4 + "',ilość_spalania_w_litrach_na_100_km=" + int.Parse(h.Zmienna6) + ",rodzaj_paliwa='" + h.Zmienna5 + "' where nr_rejestracyjny='" + h.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteNonQuery();
                        }
                        
                    }
                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 i = new Form5();
            {
                if (i.ShowDialog() == DialogResult.OK)
                {
                    if ((i.Zmienna1 == "") || (i.Zmienna2 == "") || (i.Zmienna3 == ""))
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='" + i.Zmienna1 + "'");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("insert into usterki(nr_rejestracyjny,rodzaj_usterki,data_usterki)values('" + i.Zmienna1 + "','" + i.Zmienna2 + "','" + i.Zmienna3 + "')");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 j = new Form6();
            {
                if (j.ShowDialog() == DialogResult.OK)
                {
                    if ((j.Zmienna1 == "") || (j.Zmienna2 == "") || (j.Zmienna3 == "") || (j.Zmienna4 == ""))
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='" + j.Zmienna1 + "'");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {                
                            zapytanieSQL = string.Format("update usterki set nr_rejestracyjny='" + j.Zmienna1 + "', rodzaj_usterki='" + j.Zmienna2 + "',data_usterki='" + j.Zmienna3 + "' where id_usterki=" + int.Parse(j.Zmienna4));
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteNonQuery();
                        }
                    }
                  

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 k = new Form7();
            {
                if (k.ShowDialog() == DialogResult.OK)
                {
                    if ((k.Zmienna1 == "") || (k.Zmienna2 == "") || (k.Zmienna3 == ""))
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {

                        zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='" + k.Zmienna1 + "'");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("insert into naprawy(nr_rejestracyjny,data,informacje_o_naprawie)values('" + k.Zmienna1 + "','" + k.Zmienna2 + "','" + k.Zmienna3 + "')");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteNonQuery();
                        }
                    }
                    

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 l = new Form8();
            {
                if (l.ShowDialog() == DialogResult.OK)
                {
                    if (l.Zmienna1 == "" || l.Zmienna2 == "" || l.Zmienna3 == "" || l.Zmienna4 == "")
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select id_naprawy from naprawy where id_naprawy=" + int.Parse(l.Zmienna1));
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak naprawy o podanym id");
                        }
                        else
                        {                         
                            zapytanieSQL = string.Format("update naprawy set nr_rejestracyjny='" + l.Zmienna2 + "', data='" + l.Zmienna3 + "', informacje_o_naprawie='" + l.Zmienna4 + "' where id_naprawy=" + int.Parse(l.Zmienna1) + "");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteNonQuery();
                        }
                    }

                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form26 d = new Form26();
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (d.Prawda == true)
                    {
                        zapytanieSQL = string.Format("select * from naprawy");
                        DB1 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS1.Reset();
                        DB1.Fill(DS1);
                        DT1 = DS1.Tables[0];
                        dataGridView2.DataSource = DT1;
                        czywyswietlone2 = true;
                        this.dataGridView2.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView2.MultiSelect = false;
                    }
                    else
                    {
                        if (d.Zmienna1 == "")
                        {
                            zapytanieSQL = string.Format("select Id_naprawy from naprawy where nr_rejestracyjny='" + d.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                           
                                zapytanieSQL = string.Format("select nr_rejestracyjny,data from naprawy where data='" + d.Zmienna2 +"'");
                                DB1 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS1.Reset();
                                DB1.Fill(DS1);
                                DT1 = DS1.Tables[0];
                                dataGridView2.DataSource = DT1;
                                czywyswietlone2 = true;
                                this.dataGridView2.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView2.MultiSelect = false;
                            }
                        else
                        {
                            zapytanieSQL = string.Format("select Id_naprawy from naprawy where nr_rejestracyjny='" + d.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());

                            zapytanieSQL = string.Format("select nr_rejestracyjny,data from naprawy where data='" + d.Zmienna2 + "'");
                            DB1 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                            DS1.Reset();
                            DB1.Fill(DS1);
                            DT1 = DS1.Tables[0];
                            dataGridView2.DataSource = DT1;
                            czywyswietlone2 = true;
                            this.dataGridView2.SelectionMode =
DataGridViewSelectionMode.FullRowSelect;
                            this.dataGridView2.MultiSelect = false;
                        }
                        }
                
                    

                }
            }            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form9 m = new Form9();
            {
                if (m.ShowDialog() == DialogResult.OK)
                {
                    if (m.Prawda == true)
                    {
                        zapytanieSQL = string.Format("select Id_spalania, nr_rejestracyjny,data,data_zakończenia,dystans_przejechany," +
                       "ilość_spalonego_paliwa,imie,nazwisko from spalanie_paliwa,pracownicy where spalanie_paliwa.id_pracownika=pracownicy.Id");
                        DB2 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS2.Reset();
                        DB2.Fill(DS2);
                        DT2 = DS2.Tables[0];
                        dataGridView3.DataSource = DT2;
                        czywyswietlone3 = true;
                        this.dataGridView3.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView3.MultiSelect = false;
                    }
                    else
                    {
                        if (m.Zmienna1 == "")
                        {
                            zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='" + m.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                            
                                zapytanieSQL = string.Format("select Id_spalania, nr_rejestracyjny,data,data_zakończenia,dystans_przejechany,ilość_spalonego_paliwa,imie,nazwisko from spalanie_paliwa,pracownicy where spalanie_paliwa.id_pracownika=pracownicy.Id and data='" + m.Zmienna2 + "'");
                                DB2 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS2.Reset();
                                DB2.Fill(DS2);
                                DT2 = DS2.Tables[0];
                                dataGridView3.DataSource = DT2;
                                czywyswietlone3 = true;
                                this.dataGridView3.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView3.MultiSelect = false;
                            
                        }
                        else
                        {
                            zapytanieSQL = string.Format("select Id_spalania, nr_rejestracyjny,data,data_zakończenia,dystans_przejechany,ilość_spalonego_paliwa,imie,nazwisko from spalanie_paliwa,pracownicy where spalanie_paliwa.id_pracownika=pracownicy.Id and nr_rejestracyjny='" + m.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                            if (us == "")
                            {
                                MessageBox.Show("brak pojazdu o podanej rejestracji");
                            }
                            else
                            {
                                zapytanieSQL = string.Format("select Id_spalania, nr_rejestracyjny,data,data_zakończenia,dystans_przejechany,ilość_spalonego_paliwa,imie,nazwisko from spalanie_paliwa,pracownicy where spalanie_paliwa.id_pracownika=pracownicy.Id and data='" + m.Zmienna2 + "' and nr_rejestracyjny='" + m.Zmienna1 + "'");
                                DB2 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS2.Reset();
                                DB2.Fill(DS2);
                                DT2 = DS2.Tables[0];
                                dataGridView3.DataSource = DT2;
                                czywyswietlone3 = true;
                                this.dataGridView3.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView3.MultiSelect = false;
                            }
                        }

                    }
                    
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form10 n = new Form10();
            {
                if(n.ShowDialog()==DialogResult.OK)
                {
                    if (n.Zmienna1 == "" || n.Zmienna2 == "" || n.Zmienna3 == "")
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        for (int i = 0; i < n.Zmienna1.Length; i++)
                        {
                            if (n.Zmienna1[i] == '/')
                            {
                                break;
                            }
                            else
                            {
                                rejestracja = rejestracja + n.Zmienna1[i];
                            }
                        }
                        zapytanieSQL = string.Format("select nr_rejestracyjny from pojazdy where nr_rejestracyjny='" + rejestracja + "'");
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                            MessageBox.Show(rejestracja);
                        }
                        else
                        {
                           
                            zapytanieSQL = string.Format("select ilość_spalania_w_litrach_na_100_km from pojazdy where nr_rejestracyjny='" + n.Zmienna1 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            ilosc = Convert.ToString(komenda.ExecuteScalar());
                            spalanie = (Convert.ToDouble(ilosc) * (Convert.ToDouble(n.Zmienna4)-Convert.ToDouble(n.Zmienna3))) / 100.00;
                            zapytanieSQL = string.Format("select min(Id_spalania) from spalanie_paliwa");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            min = Convert.ToString(komenda.ExecuteScalar());
                            zapytanieSQL = string.Format("select max(Id_spalania) from spalanie_paliwa");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            max = Convert.ToString(komenda.ExecuteScalar());
                            
                            zapytanieSQL = string.Format("insert into spalanie_paliwa(nr_rejestracyjny,data,data_zakończenia,dystans_przejechany,ilość_spalonego_paliwa,id_pracownika)values('" + rejestracja + "','" + n.Zmienna2 + "','" +n.Zmienna6 +"'," + (int.Parse(n.Zmienna4)-int.Parse(n.Zmienna3)) + ",'" + spalanie + "',"+n.Zmienna5 +")");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteScalar();
                            rejestracja = "";
                        }
                    }
                }
            }           
        }

        private void button17_Click(object sender, EventArgs e)
        {
           
            Form11 o = new Form11();
            {
                if (o.ShowDialog() == DialogResult.OK)
                {
                    if (o.Zmienna1 == "")
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select id_naprawy from naprawy where id_naprawy=" + int.Parse(o.Zmienna1));
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {                            
                            zapytanieSQL = string.Format("delete from naprawy where id_naprawy=" + int.Parse(o.Zmienna1) + "");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteScalar();
                        }
                    }
                }
            }
        }
        Bitmap bm;
        private void button11_Click(object sender, EventArgs e)
        {
            if (czywyswietlone1 == false)
            {
                MessageBox.Show("prosze wyświetlić liste pojazdów");
            }
            else
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView1.Width, dataGridView1.Height));
                dataGridView1.Height = height;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (czywyswietlone2 == false)
            {
                MessageBox.Show("prosze wyświetlić usterki lub naprawy");
            }
            else
            {
                int height = dataGridView2.Height;
                dataGridView2.Height = dataGridView2.RowCount * dataGridView2.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView2.Width, dataGridView2.Height);
                dataGridView2.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView2.Width, dataGridView2.Height));
                dataGridView2.Height = height;
                printPreviewDialog2.ShowDialog();
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (czywyswietlone3 == false)
            {
                MessageBox.Show("prosze wyświetlić raport");
            }
            else
            {
                int height = dataGridView3.Height;
                dataGridView3.Height = dataGridView3.RowCount * dataGridView3.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView3.Width, dataGridView3.Height);
                dataGridView3.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView3.Width, dataGridView3.Height));
                dataGridView3.Height = height;
                printPreviewDialog3.ShowDialog();
            }
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form12 p = new Form12();
            {
                if(p.ShowDialog()==DialogResult.OK)
                {
                    if (p.Zmienna1 == "")
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select id_usterki from usterki where id_usterki=" + int.Parse(p.Zmienna1));
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak pojazdu o podanej rejestracji");
                        }
                        else
                        {                            
                            zapytanieSQL = string.Format("delete from usterki where id_usterki=" + int.Parse(p.Zmienna1));
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteScalar();
                        }
                    }
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form13 r = new Form13();
            {
                if(r.ShowDialog()==DialogResult.OK)
                {
                    if (r.Zmienna1 == "")
                    {
                        MessageBox.Show("brak niektórych danych");
                    }
                    else
                    {
                        zapytanieSQL = string.Format("select Id_spalania from spalanie_paliwa where Id_spalania=" + int.Parse(r.Zmienna1));
                        komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                        us = Convert.ToString(komenda.ExecuteScalar());
                        if (us == "")
                        {
                            MessageBox.Show("brak raportu o podanym Id");
                        }
                        else
                        {                          
                            zapytanieSQL = string.Format("delete from spalanie_paliwa where Id_spalania=" + int.Parse(r.Zmienna1));
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            komenda.ExecuteScalar();
                        }
                    }
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form25 c = new Form25();
            {
                if (c.ShowDialog() == DialogResult.OK)
                {                    
                    zapytanieSQL = String.Format("delete from obecności where Id=" + int.Parse(c.Zmienna1));
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            polaczenie.Close();
            this.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form14 s = new Form14();
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = string.Format("insert into pracownicy(imie,nazwisko,status,stanowisko)values('" + s.Zmienna1 + "','" + s.Zmienna2 + "','"+s.Zmienna3+"','"+s.Zmienna4+"')");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteNonQuery();
                }
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form15 t = new Form15();
            {
                if (t.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = string.Format("delete from pracownicy where Id=" + t.Zmienna1);
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteNonQuery();
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form16 u = new Form16();
            {
                if (u.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = string.Format("update pracownicy set imie='" + u.Zmienna2 + "', nazwisko='" + u.Zmienna3 + "' where Id="+int.Parse(u.Zmienna1) );
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteNonQuery();
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            
               
                  
                        zapytanieSQL = string.Format("select * from pracownicy");
                        DB3 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS3.Reset();
                        DB3.Fill(DS3);
                        DT3 = DS3.Tables[0];
                        dataGridView4.DataSource = DT3;
                        czywyswietlone4 = true;
            this.dataGridView4.SelectionMode =
DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.MultiSelect = false;



        }

        private void button32_Click(object sender, EventArgs e)
        {
            Form17 v = new Form17();
            {
                if(v.ShowDialog()==DialogResult.OK)
                {
                    zapytanieSQL=String.Format("select Id from pracownicy where imie='"+v.Zmienna1+"' and nazwisko='"+v.Zmienna2+"'");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    us = Convert.ToString(komenda.ExecuteScalar());
                    zapytanieSQL=String.Format("insert into wydawanie_odzieży(Id_pracownika,rodzaj_wydanej_odzieży,data_wydania_odzieży,godzina_wydania_odzieży,data_oddania_odzieży,godzina_oddania_odzieży)values(" + int.Parse(us) + ",'" + v.Zmienna3 + "','" + v.Zmienna4 + "','" + v.Zmienna5 + "','" + v.Zmienna6 + "','" + v.Zmienna7 + "')");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                    
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Form18 w = new Form18();
            {
                if (w.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = String.Format("select Id from pracownicy where imie='" + w.Zmienna1 + "' and nazwisko='" + w.Zmienna2 + "'");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    us = Convert.ToString(komenda.ExecuteScalar());
                    zapytanieSQL = String.Format("update wydawanie_odzieży set Id_pracownika="+int.Parse(us)+ ",rodzaj_wydanej_odzieży='"+w.Zmienna3+ "',data_wydania_odzieży='"+w.Zmienna4+ "',godzina_wydania_odzieży='"+w.Zmienna5+ "',data_oddania_odzieży='"+w.Zmienna6+ "',godzina_oddania_odzieży='"+w.Zmienna7+"' where Id="+int.Parse(w.Zmienna8));
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();

                }
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Form19 x = new Form19();
            {
                if(x.ShowDialog()==DialogResult.OK)
                {                  
                    zapytanieSQL = String.Format("delete from wydawanie_odzieży where Id="+int.Parse(x.Zmienna1));
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form20 y = new Form20();
            {
                if (y.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = String.Format("select Id from pracownicy where imie='" + y.Zmienna1 + "' and nazwisko='" + y.Zmienna2 + "'");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    us = Convert.ToString(komenda.ExecuteScalar());
                    zapytanieSQL = String.Format("insert into referencje(Id_pracownika,data_rozpoczęcia,godzina_rozpoczęcia,data_zakończenia,godzina_zakończenia)values(" + int.Parse(us) + ",'" + y.Zmienna3 + "','" + y.Zmienna4 + "','" + y.Zmienna5 + "','" + y.Zmienna6 + "')");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form21 z = new Form21();
            {
                if (z.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = String.Format("select Id from pracownicy where imie='" + z.Zmienna1 + "' and nazwisko='" + z.Zmienna2 + "'");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    us = Convert.ToString(komenda.ExecuteScalar());
                    zapytanieSQL = String.Format("update referencje set Id_pracownika="+us+",data_rozpoczęcia='"+z.Zmienna3+ "', godzina_rozpoczęcia='"+z.Zmienna4+ "', data_zakończenia='"+z.Zmienna5+ "', godzina_zakończenia='"+z.Zmienna6+"' where Id="+z.Zmienna7);
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form22 q = new Form22();
            {
                if (q.ShowDialog() == DialogResult.OK)
                {                   
                    zapytanieSQL = String.Format("delete from referencje where Id="+int.Parse(q.Zmienna1));
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form24 b = new Form24();
            {
                if (b.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = String.Format("select Id from pracownicy where imie='" + b.Zmienna1 + "' and nazwisko='" + b.Zmienna2 + "'");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    us = Convert.ToString(komenda.ExecuteScalar());
                    zapytanieSQL = String.Format("update obecności set dzień='" + b.Zmienna3 + "', status='"+b.Zmienna4+ "' where Id=" + int.Parse(b.Zmienna5));
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Form30 h = new Form30();
            {
                if (h.ShowDialog() == DialogResult.OK)
                {
                    if (h.Prawda == true)
                    {
                        zapytanieSQL = string.Format("select wydawanie_odzieży.Id,imie,nazwisko,rodzaj_wydanej_odzieży,data_wydania_odzieży,godzina_wydania_odzieży,data_oddania_odzieży,godzina_oddania_odzieży from wydawanie_odzieży,pracownicy where wydawanie_odzieży.Id_pracownika=pracownicy.Id");
                        DB6 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS6.Reset();
                        DB6.Fill(DS6);
                        DT6 = DS6.Tables[0];
                        dataGridView5.DataSource = DT6;
                        czywyswietlone5 = true;
                        this.dataGridView5.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView5.MultiSelect = false;
                    }
                    else
                    {
                        if (h.Zmienna1 == "" || h.Zmienna2 == "" || h.Zmienna3 == "")
                        {
                            MessageBox.Show("brak niektórych danych");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("select wydawanie_odzieży.Id,imie,nazwisko,rodzaj_wydanej_odzieży,data_wydania_odzieży,godzina_wydania_odzieży,data_oddania_odzieży,godzina_oddania_odzieży from wydawanie_odzieży,pracownicy where wydawanie_odzieży.Id_pracownika=pracownicy.Id and imie='" + h.Zmienna1 + "' and nazwisko='" + h.Zmienna2 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                            if (us == "")
                            {
                                MessageBox.Show("brak osoby o podanych danych");
                            }
                            else
                            {
                                zapytanieSQL = string.Format("select wydawanie_odzieży.Id,imie,nazwisko,rodzaj_wydanej_odzieży,data_wydania_odzieży,godzina_wydania_odzieży,data_oddania_odzieży,godzina_oddania_odzieży from wydawanie_odzieży,pracownicy where wydawanie_odzieży.Id_pracownika=pracownicy.Id and wydawanie_odzieży.data_wydania_odzieży='" + h.Zmienna3 + "' and wydawanie_odzieży.Id_pracownika="+int.Parse(us));
                                DB6 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS6.Reset();
                                DB6.Fill(DS6);
                                DT6 = DS6.Tables[0];
                                dataGridView5.DataSource = DT6;
                                czywyswietlone5 = true;
                                this.dataGridView5.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView5.MultiSelect = false;
                            }
                        }

                    }

                }
            }          
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Form28 f = new Form28();
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.Prawda == true)
                    {
                        zapytanieSQL = string.Format("select obecności.Id,imie,nazwisko,dzień,obecności.status from obecności,pracownicy where obecności.Id_pracownika=pracownicy.Id");
                        DB4 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS4.Reset();
                        DB4.Fill(DS4);
                        DT4 = DS4.Tables[0];
                        dataGridView6.DataSource = DT4;
                        czywyswietlone6 = true;
                        this.dataGridView6.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView6.MultiSelect = false;
                    }
                    else
                    {
                        if (f.Zmienna1 == "" || f.Zmienna2 == "" || f.Zmienna3 == "")
                        {
                            MessageBox.Show("brak niektórych danych");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("select obecności.Id,imie,nazwisko,dzień,obecności.status from obecności,pracownicy where obecności.Id_pracownika=pracownicy.Id and imie='" + f.Zmienna1 + "' and nazwisko='" + f.Zmienna2 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                            if (us == "")
                            {
                                MessageBox.Show("brak osoby o podanych danych");
                            }
                            else
                            {
                                zapytanieSQL = string.Format("select obecności.Id,imie,nazwisko,dzień,obecności.status from obecności,pracownicy where obecności.Id_pracownika=pracownicy.Id and obecności.dzień='" + f.Zmienna3 + "' and obecności.Id_pracownika=" + int.Parse(us));
                                DB4 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS4.Reset();
                                DB4.Fill(DS4);
                                DT4 = DS4.Tables[0];
                                dataGridView6.DataSource = DT4;
                                czywyswietlone6 = true;
                                this.dataGridView6.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView6.MultiSelect = false;
                            }
                        }

                    }

                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Form29 g = new Form29();
            {
                if (g.ShowDialog() == DialogResult.OK)
                {
                    if (g.Prawda == true)
                    {
                        zapytanieSQL = string.Format("select referencje.Id,imie,nazwisko,data_rozpoczęcia,godzina_rozpoczęcia,data_zakończenia,godzina_zakończenia from referencje,pracownicy where referencje.Id_pracownika=pracownicy.Id");
                        DB5 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS5.Reset();
                        DB5.Fill(DS5);
                        DT5 = DS5.Tables[0];
                        dataGridView7.DataSource = DT5;
                        czywyswietlone7 = true;
                        this.dataGridView7.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView7.MultiSelect = false;
                    }
                    else
                    {
                        if (g.Zmienna1 == "" || g.Zmienna2 == "" || g.Zmienna3 == "")
                        {
                            MessageBox.Show("brak niektórych danych");
                        }
                        else
                        {
                            zapytanieSQL = string.Format("select referencje.Id,imie,nazwisko,data_rozpoczęcia,godzina_rozpoczęcia,data_zakończenia,godzina_zakończenia from referencje,pracownicy where referencje.Id_pracownika=pracownicy.Id and imie='" + g.Zmienna1 + "' and nazwisko='" + g.Zmienna2 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                            if (us == "")
                            {
                                MessageBox.Show("brak osoby o podanych danych");
                            }
                            else
                            {
                                zapytanieSQL = string.Format("select referencje.Id,imie,nazwisko,data_rozpoczęcia,godzina_rozpoczęcia,data_zakończenia,godzina_zakończenia from referencje,pracownicy where referencje.Id_pracownika=pracownicy.Id and referencje.data_rozpoczęcia='" + g.Zmienna3 + "' and referencje.Id_pracownika=" + int.Parse(us));
                                DB5 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS5.Reset();
                                DB5.Fill(DS5);
                                DT5 = DS5.Tables[0];
                                dataGridView7.DataSource = DT5;
                                czywyswietlone7 = true;
                                this.dataGridView7.SelectionMode =
                                 DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView7.MultiSelect = false;
                            }
                        }

                    }

                }
            }           
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (czywyswietlone6 == false)
            {
                MessageBox.Show("prosze wyświetlić liste obecności");
            }
            else
            {
                int height = dataGridView6.Height;
                dataGridView6.Height = dataGridView6.RowCount * dataGridView6.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView6.Width, dataGridView6.Height);
                dataGridView6.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView6.Width, dataGridView6.Height));
                dataGridView6.Height = height;
                printPreviewDialog6.ShowDialog();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (czywyswietlone7 == false)
            {
                MessageBox.Show("prosze wyświetlić liste nadgodzin");
            }
            else
            {
                int height = dataGridView7.Height;
                dataGridView7.Height = dataGridView7.RowCount * dataGridView7.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView7.Width, dataGridView2.Height);
                dataGridView7.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView7.Width, dataGridView7.Height));
                dataGridView7.Height = height;
                printPreviewDialog7.ShowDialog();
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (czywyswietlone5 == false)
            {
                MessageBox.Show("prosze wyświetlić liste");
            }
            else
            {
                int height = dataGridView5.Height;
                dataGridView5.Height = dataGridView5.RowCount * dataGridView5.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView5.Width, dataGridView5.Height);
                dataGridView5.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView5.Width, dataGridView5.Height));
                dataGridView5.Height = height;
                printPreviewDialog5.ShowDialog();
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (czywyswietlone4 == false)
            {
                MessageBox.Show("prosze wyświetlić liste pracowników");
            }
            else
            {
                int height = dataGridView4.Height;
                dataGridView4.Height = dataGridView4.RowCount * dataGridView4.RowTemplate.Height * 2;
                bm = new Bitmap(dataGridView4.Width, dataGridView4.Height);
                dataGridView4.DrawToBitmap(bm, new System.Drawing.Rectangle(1, 2, dataGridView4.Width, dataGridView4.Height));
                dataGridView4.Height = height;
                printPreviewDialog4.ShowDialog();
            }
        }

        private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printDocument5_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printDocument6_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void printDocument7_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {
            

        }

        private void button45_Click(object sender, EventArgs e)
        {
          
        }

        private void button30_Click(object sender, EventArgs e)
        {
            polaczenie.Close();
            this.Close();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            polaczenie.Close();
            this.Close();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            polaczenie.Close();
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form23 a = new Form23();
            {
                if (a.ShowDialog() == DialogResult.OK)
                {
                    zapytanieSQL = String.Format("select Id from pracownicy where imie='" + a.Zmienna1 + "' and nazwisko='" + a.Zmienna2 + "'");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    us = Convert.ToString(komenda.ExecuteScalar());
                    zapytanieSQL = String.Format("insert into obecności(Id_pracownika,dzień,status)values(" + int.Parse(us) + ",'" + a.Zmienna3 + "','" + a.Zmienna4 + "')");
                    komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                    komenda.ExecuteScalar();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form27 d = new Form27();
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    if (d.Prawda == true)
                    {
                        zapytanieSQL = string.Format("select * from usterki");
                        DB1 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                        DS1.Reset();
                        DB1.Fill(DS1);
                        DT1 = DS1.Tables[0];
                        dataGridView2.DataSource = DT1;
                        czywyswietlone2 = true;
                        this.dataGridView2.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                        this.dataGridView2.MultiSelect = false;
                    }
                    else
                    {
                        if (d.Zmienna1 == "")
                        {
                            zapytanieSQL = string.Format("select id_usterki from usterki where nr_rejestracyjny='" + d.Zmienna1 + "' and data_usterki='" + d.Zmienna2 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                          
                                zapytanieSQL = string.Format("select * from usterki where data_usterki='" + d.Zmienna2 + "' and nr_rejestracyjny='" + d.Zmienna1 + "'");
                                DB1 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS1.Reset();
                                DB1.Fill(DS1);
                                DT1 = DS1.Tables[0];
                                dataGridView2.DataSource = DT1;
                                czywyswietlone2 = true;
                                this.dataGridView2.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView2.MultiSelect = false;
                            
                        }
                        else
                        {
                            zapytanieSQL = string.Format("select id_usterki from usterki where data_usterki='" + d.Zmienna2 + "'");
                            komenda = new SQLiteCommand(zapytanieSQL, polaczenie);
                            us = Convert.ToString(komenda.ExecuteScalar());
                            if (us == "")
                            {
                                MessageBox.Show("brak usterki o podanym Id");
                            }
                            else
                            {
                                zapytanieSQL = string.Format("select * from usterki where data_usterki='" + d.Zmienna2 + "' and nr_rejestracyjny='" + d.Zmienna1 + "'");
                                DB1 = new SQLiteDataAdapter(zapytanieSQL, polaczenie);
                                DS1.Reset();
                                DB1.Fill(DS1);
                                DT1 = DS1.Tables[0];
                                dataGridView2.DataSource = DT1;
                                czywyswietlone2 = true;
                                this.dataGridView2.SelectionMode =
    DataGridViewSelectionMode.FullRowSelect;
                                this.dataGridView2.MultiSelect = false;
                            }
                        }

                    }

                }
            }   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
