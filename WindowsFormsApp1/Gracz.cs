using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Gracz
    {
        private bool pomylka;
        private int poziom;

        public int Poziom
        {
            get => poziom;

            protected set
            {
                if (value < 1)
                    poziom = 1;
                if (value > 3)
                    poziom = 3;
            }
        }

        public int LiczbaPunktow { get; protected set; }

        public Gracz()
        {
            LiczbaPunktow = 0;
            pomylka = false;
            poziom = 1;
        }

        public void Dobrze(int trudnosc = 0)
        {
            LiczbaPunktow += trudnosc == 0 ? 1 : trudnosc;
            pomylka = false;
            Poziom++;
        }

        public void Zle()
        {
            if (!pomylka)
            {
                pomylka = true;
                return;
            }

            Poziom--;
            pomylka = false;
        }
    }
}
