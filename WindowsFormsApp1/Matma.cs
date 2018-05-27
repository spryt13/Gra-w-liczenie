using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Matma
    {
        private static Random random = new Random();

        public static int LiczbaNCyfrowa(int n)
        {
            if (n < 1)
                throw new ArgumentException("Liczba cyfr nie moze byc mniejsza niz 1");

            int dol = Potega(10, n - 1);
            int gora = Potega(10, n);

            return random.Next(dol, gora);
        }

        public static int Potega(int liczba, int potega)
        {
            int wynik = 1;

            for (int i = 0; i < potega; i++)
            {
                wynik *= liczba;
            }

            return wynik;
        }

        public static List<int> Dzielniki(int liczba)
        {
            List<int> dzielniki = new List<int>();

            for (int i = 1; i <= liczba; i++)
            {
                if (liczba % i == 0)
                    dzielniki.Add(i);
            }

            return dzielniki;
        }

        public static int LosowyDzielnik(int liczba)
        {
            if (liczba == 1)
                return 1;

            List<int> dzielniki = Dzielniki(liczba);
            
            if (dzielniki.Count > 2) //Staramy sie uniknac dzielenia przez sama siebie
                return dzielniki[random.Next(1, dzielniki.Count - 1)];
            else
                return dzielniki[random.Next(1, dzielniki.Count - 1)];
        }
    }
}
