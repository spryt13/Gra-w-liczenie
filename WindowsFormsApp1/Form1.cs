using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 //ToDo Dzailanie na enterze
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

        enum Znak
        {
            Plus,
            Minus,
            Razy,
            Podzielic
        };

        private string ZnakToString(Znak znak)
        {
            switch (znak)
            {
                case Znak.Plus:
                    return "+";
                case Znak.Minus:
                    return "-";
                case Znak.Razy:
                    return "*";
                case Znak.Podzielic:
                    return "/";

                default:
                    return "";
            }
        }

        private Znak StringToZnak(string znak)
        {
            switch (znak)
            {
                case "+":
                    return Znak.Plus;
                case "-":
                    return Znak.Minus;
                case "*":
                    return Znak.Razy;
                case "/":
                    return Znak.Podzielic;

                default:
                    throw new Exception("Zamiana z niewlasciwego znaku");
            }
        }

        private Znak LosowyZnak()
        {
            return (Znak)random.Next(0, 4);
        }

        int Policz(int a, Znak znak, int b)
        {
            switch (znak)
            {
                case Znak.Plus:
                    return a + b;
                case Znak.Minus:
                    return a - b;
                case Znak.Razy:
                    return a * b;
                case Znak.Podzielic:
                    return a / b;

                default:
                    return 0;
            }
        }

        private void UtworzLosoweRownanie()
        {
            liczba1Label.Text = random.Next(1, 10).ToString();
            liczba2Label.Text = random.Next(1, 10).ToString();

            znakLabel.Text = ZnakToString(LosowyZnak());

            poprawnoscLabel.Text = "";
        }

        private bool CzyDobraOdpowiedz()
        {
            int a = Convert.ToInt32(liczba1Label.Text);
            int b = Convert.ToInt32(liczba2Label.Text);

            int wynikDzialania = Policz(a, StringToZnak(znakLabel.Text), b);
            int liczbaWpisana;

            try
            {
                liczbaWpisana = Convert.ToInt32(userInputTexBox.Text);
            }
            catch (Exception exception)
            {
                liczbaWpisana = 0;
            }

            return wynikDzialania == liczbaWpisana;
        }

        private void Sprawdzenie()
        {
            if (CzyDobraOdpowiedz())
            {
                poprawnoscLabel.Text = "Dobrze";
                pictureBox.Image = Image.FromFile("tick-512.png");
            }
            else
            {
                poprawnoscLabel.Text = "Zle";
                pictureBox.Image = Image.FromFile("cross.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtworzLosoweRownanie();
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
