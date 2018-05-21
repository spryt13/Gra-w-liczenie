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
    public partial class Form1 : Form //Test ciekawe co sie stanie
    {
        private Random random;
        private Rownanie aktualneRownanie;
        private Dictionary<int, List<Rownanie>> rownania; //Slownik <Poziom Trudnosci, Lista Rownan o danym poziomie trudnosci>
        private Dictionary<int, List<string>> templates;
        private Gracz gracz;

        public Form1()
        {
            InitializeComponent();
            
            gracz = new Gracz();
            random = new Random();
            
            WczytajRownania(@"../../dane.txt"); //Dane sa dwa foldery wyzej

            poziomLabel.Text = gracz.Poziom.ToString();
            PrzypiszNoweRowanie();
        }

        void WczytajRownania(string nazwaPliku)
        {
            /*rownania = new Dictionary<int, List<Rownanie>>
            {
                {0, new List<Rownanie>()},
                {1, new List<Rownanie>()},
                {2, new List<Rownanie>()},
                {3, new List<Rownanie>()}
            };*/

            templates = new Dictionary<int, List<string>>
            {
                {0, new List<string>()},
                {1, new List<string>()},
                {2, new List<string>()},
                {3, new List<string>()},
                {4, new List<string>()}
            };

            try
            {
                string[] linie = File.ReadAllLines(nazwaPliku);

                for (int i = 0; i < linie.Length; i++)
                {
                    string linia = linie[i];
                    /*Rownanie rownanie = new Rownanie(linia);

                    rownania[rownanie.Trudnosc].Add(rownanie);*/

                    templates[Convert.ToInt32(linia[linia.Length-1])].Add(linia);
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
                /*List<Rownanie> rownaniaOdpowiednegoPoziomu = rownania[gracz.Poziom];

                aktualneRownanie = rownaniaOdpowiednegoPoziomu[random.Next(0, rownaniaOdpowiednegoPoziomu.Count)];*/

                List<string> wzory = templates[gracz.Poziom];

                aktualneRownanie = new Rownanie(wzory[random.Next(0,wzory.Count)]);
            }
            catch (Exception)
            {
                aktualneRownanie = Rownanie.LosoweRownanie(); //Dane nie zostaly wczytane
            }

            Wyczysc();
            WyswietlRownanie(aktualneRownanie);
        }

        private void button1_Click(object sender, EventArgs e) //Nastepne dzialanie
        {
            if (pictureBox.Visible == true)
                PrzypiszNoweRowanie();
        }

        private void button2_Click(object sender, EventArgs e) //Sprawdzenie
        {
            if (pictureBox.Visible == false) //Jesli pictureBox jest widoczny to rownanie zostalo juz sprawdzone
                Sprawdzenie();
        }

        private void userInputTexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && pictureBox.Visible == false)
                Sprawdzenie();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
