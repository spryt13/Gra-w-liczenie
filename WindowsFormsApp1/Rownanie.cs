using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Rownanie
    {
        private int a;
        private int b;
        private Znak znak;
        private int trodnosc;

        public Rownanie(int a, Znak znak, int b, int trodnosc = 0)
        {
            this.a = a;
            this.znak = znak;
            this.b = b;
            this.trodnosc = trodnosc;
        }

        //Rownanie mozna wczytac zarowno z poziomem trudnosci jak i bez. W przypadku braku poziomu trudnosci jest on ustawiany na 0
        public Rownanie(string napis)
        {
            string[] dane = napis.Split(' ');
            if (dane.Length > 4 || dane.Length<3)
                throw new Exception("Bledna liczba danych w linii");

            a = Convert.ToInt32(dane[0]);
            znak = new Znak(dane[1]);
            b = Convert.ToInt32(dane[2]);

            trodnosc = dane.Length == 3 ? 0 : Convert.ToInt32(dane[3]);
        }

        public int A => a;
        public int B => b;
        public Znak ZnakRownania => znak;

        public int Oblicz()
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

        public static Rownanie LosoweRownanie(int maksymalnaWielkoscLiczb = 10)
        {
            if (maksymalnaWielkoscLiczb < 1)
                throw new Exception("maksymalnaWielkoscLiczb musi byc >= 1");
            Random random = new Random();

            int a = random.Next(1, maksymalnaWielkoscLiczb);
            int b = random.Next(1, maksymalnaWielkoscLiczb);

            return new Rownanie(a, Znak.LosowyZnak(), b);
        }
    }
}
