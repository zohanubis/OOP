using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Bội số của 5 sử dụng while 
// Nhập số không phải bội 5 thì nhập lại cho đến khi đúng thì dừng
namespace Ex2
{
    public class Boi5
    {
        static void Main()
        {
            int n;
            Console.Write("Nhap n : ");
            n = Convert.ToInt32(Console.ReadLine());
            while (n % 5 != 0)
            {
                Console.Write("Nhap lai n :");
                n = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Boi so cua 5 : " + n);
        }
    }
}
