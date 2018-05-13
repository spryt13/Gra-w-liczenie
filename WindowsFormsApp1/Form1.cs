using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 //Todo Zrobić obiektowo
{
    public partial class Form1 : Form
    {
        private Random random;
        private Rownanie aktualneRownanie;
        //private Rownanie[] rownania;
        private Dictionary<int, List<Rownanie>> rownania;
        private Gracz gracz;

        public Form1()
        {
            InitializeComponent();
            
            gracz = new Gracz();
            random = new Random();
            rownania = new Dictionary<int, List<Rownanie>>();
            rownania.Add(0, new List<Rownanie>());
            rownania.Add(1, new List<Rownanie>());
            rownania.Add(2, new List<Rownanie>());
            rownania.Add(3, new List<Rownanie>());

            WczytajRownania(@"../../dane.txt"); //Dane sa dwa foldery wyrzej
            //WczytajRownaniaXML("dane.xml");

            poziomLabel.Text = gracz.Poziom.ToString();
            PrzypiszNoweRowanie();
        }

        void WczytajRownania(string nazwaPliku)
        {
            try
            {
                string[] linie = File.ReadAllLines(nazwaPliku);

                for (int i = 0; i < linie.Length; i++)
                {
                    string linia = linie[i];
                    Rownanie rownanie = new Rownanie(linia);

                    rownania[rownanie.Trudnosc].Add(rownanie);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udalo sie wczytac rownan z pliku");
            }
        }

        //void WczytajRownaniaXML(string nazwaPliku)
        //{
        //    ////Test
        //    //{
        //    //    XmlDocument daneXML = new XmlDocument();
        //    //    daneXML.Load("dane.xml");
        //    //    Console.WriteLine(daneXML.GetElementsByTagName("Rownanie").Count);
        //    //}

        //    try
        //    {
        //        XmlDocument daneXML = new XmlDocument();
        //        daneXML.Load(nazwaPliku);

        //        int liczbaRownan = daneXML.GetElementsByTagName("Rownanie").Count;
        //        rownania = new Rownanie[liczbaRownan];
                
        //        for (int i=0; i<liczbaRownan; i++)
        //        {
        //            int a = 0;
        //            if (!Int32.TryParse(daneXML.GetElementsByTagName("Rownanie").Item(i).ChildNodes.Item(0).Value, out a))
        //                throw new Exception();

        //            int b;
        //            if (!Int32.TryParse(daneXML.GetElementsByTagName("Rownanie").Item(i).ChildNodes.Item(2).Value, out b))
        //                throw new Exception();

        //            Znak znak = new Znak(daneXML.GetElementsByTagName("Rownanie").Item(i).ChildNodes.Item(1).Value);

        //            rownania[i] = new Rownanie(a, znak, b);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Nie udało się wczytać równań z bazy");
        //    }
        //}

        private void WyswietlRownanie(Rownanie rownanie)
        {
            liczba1Label.Text = rownanie.A.ToString();
            liczba2Label.Text = rownanie.B.ToString();
            znakLabel.Text = rownanie.ZnakRownania.ToString();
        }

        private bool CzyDobraOdpowiedz()
        {
            int liczbaWpisana;

            try
            {
                liczbaWpisana = Convert.ToInt32(userInputTexBox.Text);
            }
            catch (Exception)
            {
                return false;
            }

            return aktualneRownanie.Oblicz() == liczbaWpisana;
        }

        private void Sprawdzenie()
        {
            if (CzyDobraOdpowiedz())
            {
                gracz.Dobrze(aktualneRownanie.Trudnosc);

                poprawnoscLabel.Text = "Dobrze";
                pictureBox.Image = Properties.Resources.tick;
                pictureBox.Visible = true;
            }
            else
            {
                gracz.Zle();

                poprawnoscLabel.Text = "Zle";
                pictureBox.Image = Properties.Resources.cross;
                pictureBox.Visible = true;
            }

            poziomLabel.Text = gracz.Poziom.ToString();
            pictureBox.Visible = true;
        }

        private void WyczyscStareRownanie()
        {
            userInputTexBox.Text = "";
            pictureBox.Visible = false;
            poprawnoscLabel.Text = "";
        }

        void PrzypiszNoweRowanie()
        { 
            try
            {
                List<Rownanie> rownaniaOdpowiednegoPoziomu = rownania[gracz.Poziom];

                aktualneRownanie = rownaniaOdpowiednegoPoziomu[random.Next(0, rownaniaOdpowiednegoPoziomu.Count)];
            }
            catch (Exception)
            {
                aktualneRownanie = Rownanie.LosoweRownanie(); //Dane nie zostaly wczytane
                }

            WyczyscStareRownanie();
            WyswietlRownanie(aktualneRownanie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrzypiszNoweRowanie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Visible == false)
                Sprawdzenie();
        }

        private void userInputTexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Sprawdzenie();
        }
    }
}
