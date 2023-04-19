using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    public class Ex5
    {
        static void Main(string[] args)
        {
            int[] arr;
            arr = new int[] { 10, 20, 30, 40, 50, 60};
            int sum = 0;
            arr.ToString();
            foreach (int i in arr) { 
                sum += i;
            }
            Console.WriteLine("Tong mang : " + sum.ToString());
        }
    }
}