using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    public class Bai3
    {
        static void Main(string[] args)
        {
            int n, sum = 0;
            do
            {
                Console.Write("Nhap n : ");
                n = Convert.ToInt32(Console.ReadLine());
                sum += n;
            } while (n != 0);
            Console.WriteLine("Tong cac so vua nhap : " + sum);
        }
    }
}
