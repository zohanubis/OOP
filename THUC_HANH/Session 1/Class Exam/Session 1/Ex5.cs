using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap he so  a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap he so  b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhap he so  c: ");
        double c = double.Parse(Console.ReadLine());

        double delta = b * b - 4 * a * c;

        if (delta < 0)
        {
            Console.WriteLine("Phuong trinh vo nghiem");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("Phuong trinh co nghiem kep: {0}", x);
        }
        else
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine("Phuong trinh co 2 nghiem phan biet:");
            Console.WriteLine("x1 = {0}", x1);
            Console.WriteLine("x2 = {0}", x2);
        }
    }
}