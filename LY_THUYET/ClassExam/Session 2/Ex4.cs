using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Nhập mảng , tính tổng mảng
namespace Ex4
{
    public class Ex4
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu cua mang : ");
            int n = Convert.ToInt32(Console.ReadLine());    
            int[]arr= new int[n];
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                Console.Write("Nhap gia tri thu {0} : ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
            }
            Console.WriteLine("Tong cac phan tu trong mang : " + sum);
        }
    }
}
