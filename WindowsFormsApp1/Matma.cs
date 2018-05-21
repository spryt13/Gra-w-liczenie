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
            int gora = SameDziewiatki(n);

            return random.Next(dol, gora + 1);
        }

        private static int SameDziewiatki(int iloscDziewiatek)
        {
            if (iloscDziewiatek < 1)
                throw new ArgumentException("Liczba dziewiatek nie moze byc mniejsza niz 1");

            int wynik = 9;

            for (int i = 1; i < iloscDziewiatek; i++)
            {
                wynik += 9 * Potega(10, i - 1);
            }

            return wynik;
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
    }
}
