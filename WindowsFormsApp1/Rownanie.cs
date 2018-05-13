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

        public Rownanie(string napis)
        {
            string[] dane = napis.Split(' ');
            if (dane.Length > 4 || dane.Length<3)
                throw new Exception("Bledna liczba danych w linii");

            int a = 0;
            if (!Int32.TryParse(dane[0], out a))
                throw new Exception();

            Znak znak = new Znak(dane[1]);

            int b;
            if (!Int32.TryParse(dane[2], out b))
                throw new Exception();

            this.a = a;
            this.znak = znak;
            this.b = b;

            if (dane.Length == 3)
            { 
                this.trodnosc = 0;
            }
            else
            {
                int trudnosc;
                if (!Int32.TryParse(dane[3], out trudnosc))
                    throw new Exception();

                this.trodnosc = trudnosc;
            }
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
