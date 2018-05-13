using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ToDo Wczytywanie działań z pliku
//ToDo Działania mają mieć stopień trudności
//ToDo Dynamiczne dobieranie równań do tego jak idzie graczowi
//ToDO Sprawdzanie poprawnosci pliku

namespace WindowsFormsApp1 //Todo Zrobić obiektowo
{
    public partial class Form1 : Form
    {
        private Random random;
        private Rownanie rownanie;

        public Form1()
        {
            InitializeComponent();

            random = new Random();
            rownanie = Rownanie.LosoweRownanie();
            WyswietlRownanie();
            poprawnoscLabel.Text = "";
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
