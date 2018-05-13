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
//ToDo Klasa Dzialanie
//ToDo Działania mają mieć stopień trudności
//ToDo Dynamiczne dobieranie równań do tego jak idzie graczowi
//ToDO Sprawdzanie poprawnosci pliku

namespace WindowsFormsApp1 //Todo Zrobić obiektowo
{
    public partial class Form1 : Form
    {
        private Random random;
        public Form1()
        {
            InitializeComponent();

            random = new Random();
            UtworzLosoweRownanie();
        }

        int Policz(int a, Znak znak, int b)
        {
            if (znak == Znak.Plus())
                return a + b;
            if (znak == Znak.Minus())
                return a - b;
            if (znak == Znak.Podzielic())
                return a / b;
            if (znak == Znak.Razy())
                return a * b;

            return 0;
        }

        private void UtworzLosoweRownanie()
        {
            liczba1Label.Text = random.Next(1, 10).ToString();
            liczba2Label.Text = random.Next(1, 10).ToString();

            znakLabel.Text = Znak.LosowyZnak().ToString();

            poprawnoscLabel.Text = "";
        }

        private bool CzyDobraOdpowiedz()
        {
            int a = Convert.ToInt32(liczba1Label.Text);
            int b = Convert.ToInt32(liczba2Label.Text);

            int wynikDzialania = Policz(a, new Znak(znakLabel.Text), b);
            int liczbaWpisana;

            try
            {
                liczbaWpisana = Convert.ToInt32(userInputTexBox.Text);
            }
            catch (Exception)
            {
                return false;
            }

            return wynikDzialania == liczbaWpisana;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtworzLosoweRownanie();
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
