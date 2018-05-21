using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Szablon
    {
        private int trodnosc;

        public int Trodnosc
        {
            get => trodnosc;
            protected set
            {
                if (value < 0 || value > 3)
                    return;
                trodnosc = value;
            }
        }

        public int LiczbaCyfrA { get; private set; }
        public Znak Znak { get; private set; }
        public int LiczbaCyfrB { get; private set; }

        public Szablon(string napis)
        {
            string[] dane = napis.Split(' ');
            if (dane.Length > 4 || dane.Length < 3)
                throw new Exception("Bledna liczba danych w linii");

            LiczbaCyfrA = Convert.ToInt32(dane[0]);
            Znak = new Znak(dane[1]);
            LiczbaCyfrB = Convert.ToInt32(dane[2]);

            Trodnosc = dane.Length == 3 ? 0 : Convert.ToInt32(dane[3]);
        }
    }
}
