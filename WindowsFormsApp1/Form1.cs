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
        private Dictionary<int, List<Rownanie>> rownania; //Slownik <Poziom Trudnosci, Lista Rownan o danym poziomie trudnosci>
        private Dictionary<int, List<Szablon>> szablony;
        private Gracz gracz;

        public Form1()
        {
            InitializeComponent();
            
            gracz = new Gracz();
            random = new Random();
            
            WczytajRownania(@"../../rownania.txt"); //Dane sa dwa foldery wyzej

            poziomLabel.Text = gracz.Poziom.ToString();
            PrzypiszNoweRowanie();
        }

        void WczytajSzablony(string nazwaPliku)
        {
            szablony = new Dictionary<int, List<Szablon>>
            {
                {0, new List<Szablon>()},
                {1, new List<Szablon>()},
                {2, new List<Szablon>()},
                {3, new List<Szablon>()}
            };

            try
            {
                string[] linie = File.ReadAllLines(nazwaPliku);

                foreach (string linia in linie)
                {
                    Szablon szablon = new Szablon(linia);

                    szablony[szablon.Trodnosc].Add(szablon);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udalo sie wczytac szablonow z pliku");
            }
        }

        void WczytajRownania(string nazwaPliku)
        {
            rownania = new Dictionary<int, List<Rownanie>>
            {
                {0, new List<Rownanie>()},
                {1, new List<Rownanie>()},
                {2, new List<Rownanie>()},
                {3, new List<Rownanie>()}
            };

            try
            {
                string[] linie = File.ReadAllLines(nazwaPliku);

                foreach (string linia in linie)
                {
                    Rownanie rownanie = new Rownanie(linia);

                    rownania[rownanie.Trodnosc].Add(rownanie);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udalo sie wczytac rownan z pliku");
            }
        }

        private void WyswietlRownanie(Rownanie rownanie)
        {
            liczba1Label.Text = rownanie.A.ToString();
            liczba2Label.Text = rownanie.B.ToString();
            znakLabel.Text = rownanie.Znak.ToString();
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
                gracz.Dobrze(aktualneRownanie.Trodnosc);

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

        private void Wyczysc()
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

            Wyczysc();
            WyswietlRownanie(aktualneRownanie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrzypiszNoweRowanie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Visible == false) //Jesli pictureBox jest widoczny to rownanie zostalo juz sprawdzone
                Sprawdzenie();
        }

        private void userInputTexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && pictureBox.Visible == false)
                Sprawdzenie();
        }
    }
}
