using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bài 4. Viết chương trình biện luận và giải phương trình bậc 1
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap he so a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap he so b: ");
        double b = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                Console.WriteLine("Phuong trinh vo so nghiem");
            }
            else
            {
                Console.WriteLine("Phuong trinh vo nghiem");
            }
        }
        else
        {
            double x = -b / a;
            Console.WriteLine("Nghiem cua phuong trinh la: {0}", x);
        }
    }
}