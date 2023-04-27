using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_PhamHoDangHuy_2001215828
{
    class HCN
    {
        private int length;
        private int width;

        public HCN()
        {
            length = 0;
            width = 0;
        }

        public HCN(int l, int w)
        {
            length = l;
            width = w;
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Perimeter()
        {
            return 2 * (length + width);
        }

        public int Area()
        {
            return length * width;
        }

        public double Diagonal()
        {
            return Math.Sqrt(length * length + width * width);
        }

        public void Input()
        {
            Console.Write("Enter the length: ");
            length = int.Parse(Console.ReadLine());

            Console.Write("Enter the width: ");
            width = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Perimeter: {0}", Perimeter());
            Console.WriteLine("Area: {0}", Area());
            Console.WriteLine("Diagonal: {0}", Diagonal());
        }

        public void changeSize(int tx, int ty, int kieu)
        {
            if (kieu == 1)
            {
                length += tx;
                width += ty;
            }
            else if (kieu == 0)
            {
                length -= tx;
                width -= ty;
            }
        }

        public void changeSize(HCN a, int kieu)
        {
            if (kieu == 1)
            {
                length += a.Length;
                width += a.Width;
            }
            else if (kieu == 0)
            {
                length -= a.Length;
                width -= a.Width;
            }
        }
    }
}
