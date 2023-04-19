using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTBac2
{
    class QuadraticEquation
    {
        private double a, b, c;

        public QuadraticEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double C
        {
            get { return c; }
            set { c = value; }
        }

        public int CountRoots()
        {
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                return 2;
            }
            else if (delta == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class Program
    {

        public static void Main(string[] args)
        {
            QuadraticEquation eq = new QuadraticEquation(1, -5, 6);
            int count = eq.CountRoots();
            Console.WriteLine("So nghiem cua phuong trinh la {0}.", count);

        }
    }
}
