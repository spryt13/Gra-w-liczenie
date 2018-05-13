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

        public Rownanie(int a, Znak znak, int b)
        {
            this.a = a;
            this.znak = znak;
            this.b = b;
        }

        public int A => a;
        public int B => B;
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
