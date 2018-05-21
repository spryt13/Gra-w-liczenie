using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Rownanie
    {
        private int a = 0;
        private int b = 0;
        private Znak znak;
        private int trodnosc;
        private static Random random = new Random();

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
            if (dane.Length > 4 || dane.Length < 3)
                throw new Exception("Bledna liczba danych w linii");

            LosujDzialanie(dane);
            
            trodnosc = dane.Length == 3 ? 0 : Convert.ToInt32(dane[3]);
        }

        public void LosujDzialanie(string[] dane)
        {
            int liczbaCyfr;
            for(int cycle = 0; cycle < 3; cycle++)
            {
                try
                {
                    if (cycle == 1)
                        znak = new Znak(dane[1]);
                    else
                    {
                        liczbaCyfr = Convert.ToInt32(dane[cycle]);
                        while (liczbaCyfr > 0)
                        {
                            if (cycle == 0)
                                a += random.Next(1, 10) * Potega(10, liczbaCyfr - 1);
                            if (cycle == 2)
                                //if (znak != Znak.Podzielic())
                                    b += random.Next(1, 10) * Potega(10, liczbaCyfr - 1);
                                //else
                                    //SzukanieDzielnej(a, liczbaCyfr);
                                
                            liczbaCyfr--;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Blad losowania");
                }
            }

        }
        public int A
        {
            get => a;
            protected set => a = value;
        }

        public int B
        {
            get => b;
            protected set => b = value;
        }

        public Znak ZnakRownania
        {
            get => znak;
            protected set => znak = value;
        }

        public int Trudnosc
        {
            get => trodnosc;
            protected set
            {
                if (value < 0 || value > 3)
                    return;
                trodnosc = value;
            }
        }

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

        private static int Potega(int a, int potega)
        {
            int wynik = 1;

            for (int i = 0; i < potega; i++)
            {
                wynik *= a;
            }

            return wynik;
        }
        private int SzukanieDzielnej(int a, int liczbaCyfr)
        {
            {
                // najprosciej
                b = a + 1;
                while (a % b != 0)
                    b = random.Next(1, a / 2) * Potega(10, liczbaCyfr - 1);
                return b;
                
                /*a = ((a + 1) / 2) * 2;
                List<int> dzielne = new List<int>();
                for(int dzielna = 2; a != 1; dzielna = 2)
                {
                    if (a % dzielna == 0)
                        dzielne.Add(dzielna);
                }
                b += random.Next(2, a / 10) * Potega(10, liczbaCyfr);
                return b;*/
            }
        }
    }
}
