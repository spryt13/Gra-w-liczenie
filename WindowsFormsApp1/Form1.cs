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

//ToDo Dynamiczne dobieranie równań do tego jak idzie graczowi

namespace WindowsFormsApp1 //Todo Zrobić obiektowo
{
    public partial class Form1 : Form
    {
        //private Random random;
        private Rownanie rownanie;
        private Rownanie[] rownania;

        public Form1()
        {
            InitializeComponent();

            WczytajRownania(@"../../dane.txt"); //Dane sa dwa foldery wyrzej
            //WczytajRownaniaXML("dane.xml");

            //random = new Random();
            rownanie = Rownanie.LosoweRownanie();
            WyswietlRownanie();

            poprawnoscLabel.Text = "";
        }

        void WczytajRownania(string nazwaPliku)
        {
            try
            {
                string[] linie = File.ReadAllLines(nazwaPliku);
                rownania = new Rownanie[linie.Length];

                for (int i = 0; i < linie.Length; i++)
                {
                    string linia = linie[i];
                    rownania[i] = new Rownanie(linia);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udalo sie wczytac rownan z pliku");
            }
        }

        void WczytajRownaniaXML(string nazwaPliku)
        {
            ////Test
            //{
            //    XmlDocument daneXML = new XmlDocument();
            //    daneXML.Load("dane.xml");
            //    Console.WriteLine(daneXML.GetElementsByTagName("Rownanie").Count);
            //}

            try
            {
                XmlDocument daneXML = new XmlDocument();
                daneXML.Load(nazwaPliku);

                int liczbaRownan = daneXML.GetElementsByTagName("Rownanie").Count;
                rownania = new Rownanie[liczbaRownan];
                
                for (int i=0; i<liczbaRownan; i++)
                {
                    int a = 0;
                    if (!Int32.TryParse(daneXML.GetElementsByTagName("Rownanie").Item(i).ChildNodes.Item(0).Value, out a))
                        throw new Exception();

                    int b;
                    if (!Int32.TryParse(daneXML.GetElementsByTagName("Rownanie").Item(i).ChildNodes.Item(2).Value, out b))
                        throw new Exception();

                    Znak znak = new Znak(daneXML.GetElementsByTagName("Rownanie").Item(i).ChildNodes.Item(1).Value);

                    rownania[i] = new Rownanie(a, znak, b);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się wczytać równań z bazy");
            }
        }

        private void WyswietlRownanie()
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

            return rownanie.Oblicz() == liczbaWpisana;
        }

        private void Sprawdzenie()
        {
            if (CzyDobraOdpowiedz())
            {
                poprawnoscLabel.Text = "Dobrze";
                pictureBox.Image = Properties.Resources.tick;
                pictureBox.Visible = true;
            }
            else
            {
                poprawnoscLabel.Text = "Zle";
                pictureBox.Image = Properties.Resources.cross;
                pictureBox.Visible = true;
            }

            pictureBox.Visible = true;
        }

        private void WyczyscStareRownanie()
        {
            userInputTexBox.Text = "";
            pictureBox.Visible = false;
            poprawnoscLabel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rownanie = Rownanie.LosoweRownanie();
            WyswietlRownanie();
            WyczyscStareRownanie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sprawdzenie();
        }

        private void userInputTexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Sprawdzenie();
        }
    }
}
