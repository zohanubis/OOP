using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_PhamHoDangHuy_2001215828
{

    class DinhThucCap2
    {
        private int[,] matrix = new int[2, 2];

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public DinhThucCap2()
        {
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrix[i, j] = random.Next(-50, 51);
                }
            }
        }

        public DinhThucCap2(int[,] inputMatrix)
        {
            if (inputMatrix.GetLength(0) != 2 || inputMatrix.GetLength(1) != 2)
            {
                throw new ArgumentException("Input matrix must be of size 2x2.");
            }
            matrix = inputMatrix;
        }

        public void Xuat()
        {
            Console.WriteLine("{0,4} {1,4}", matrix[0, 0], matrix[0, 1]);
            Console.WriteLine("{0,4} {1,4}", matrix[1, 0], matrix[1, 1]);
        }

        public int TinhDet()
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        public static DinhThucCap2 Cong(DinhThucCap2 a, DinhThucCap2 b)
        {
            DinhThucCap2 c = new DinhThucCap2();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }

        public static DinhThucCap2 operator +(DinhThucCap2 a, DinhThucCap2 b)
        {
            return Cong(a, b);
        }

        public static DinhThucCap2 Nhan(DinhThucCap2 a, int scalar)
        {
            DinhThucCap2 b = new DinhThucCap2();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    b[i, j] = a[i, j] * scalar;
                }
            }
            return b;
        }

        public static DinhThucCap2 operator *(DinhThucCap2 a, int scalar)
        {
            return Nhan(a, scalar);
        }
    }

}
