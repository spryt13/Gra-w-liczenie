using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Znak : IEquatable<Znak>
    {
        private enum Znaki
        {
            Plus,
            Minus,
            Razy,
            Podzielic
        };
        private Znaki znak;

        private Znak(Znaki znak)
        {
            this.znak = znak;
        }

        public Znak(string znak)
        {
            switch (znak)
            {
                case "+":
                    this.znak = Znaki.Plus;
                    break;
                case "-":
                    this.znak = Znaki.Minus;
                    break;
                case "*":
                    this.znak = Znaki.Razy;
                    break;
                case "/":
                    this.znak = Znaki.Podzielic;
                    break;

                default:
                    throw new Exception("Niewlasciwy znak");
            }
        }

        public override string ToString()
        {
            switch (znak)
            {
                case Znaki.Plus:
                    return "+";
                case Znaki.Minus:
                    return "-";
                case Znaki.Razy:
                    return "*";
                case Znaki.Podzielic:
                    return "/";

                default:
                    return "";
            }
        }

        public static bool operator==(Znak a, Znak b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Znak a, Znak b)
        {
            return !a.Equals(b);
        }

        public static Znak LosowyZnak()
        {
            Random random = new Random();

            return new Znak((Znaki)random.Next(0, 4));
        }

        public static Znak Plus()
        {
            return new Znak(Znaki.Plus);
        }

        public static Znak Minus()
        {
            return new Znak(Znaki.Minus);
        }

        public static Znak Podzielic()
        {
            return new Znak(Znaki.Podzielic);
        }

        public static Znak Razy()
        {
            return new Znak(Znaki.Razy);
        }

        public bool Equals(Znak other)
        {
            return this.znak == other.znak;
        }
    }
}
