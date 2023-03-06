using System;
namespace Ex1
{
    public class Thu
    {
        static void Main()
        {
            int num;
            Console.Write("Nhap tu 2 toi 8 : ");
            num = Convert.ToInt32(Console.ReadLine());
            do
            {
                if (num == 2)
                {
                    Console.WriteLine("Thu 2");
                }
                else if (num == 3)
                {
                    Console.WriteLine("Thu 3");
                }
                else if (num == 4)
                {
                    Console.WriteLine("Thu 4");
                }
                else if (num == 5)
                {
                    Console.WriteLine("Thu 5");
                }
                else if (num == 6)
                {
                    Console.WriteLine("Thu 6");

                }
                else if (num == 7)
                {
                    Console.WriteLine("Thu 7");
                }
                else if (num == 8)
                {
                    Console.WriteLine("Chu Nhat");
                }
                else
                {
                    Console.WriteLine("So khong hop le ");
                }
            }
            while (num > 1 || num < 9);
        }
    }
}