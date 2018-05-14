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
            get
            {
                return poziom;
            }

            private set
            {
                if (value < 1)
                {
                    poziom = 1;
                    return;
                }
                if (value > 3)
                {
                    poziom = 3;
                    return;
                }

                poziom = value;
            }
        }

        public int LiczbaPunktow { get; private set; }

        public Gracz()
        {
            LiczbaPunktow = 0;
            pomylka = false;
            poziom = 0;
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
