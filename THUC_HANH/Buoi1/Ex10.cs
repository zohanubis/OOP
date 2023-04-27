using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi1_PhamHoDangHuy_2001215828
{
    class List
    {
        private List<int> list;
        public List()
        {
            list = new List<int>();
        }

        public void AddRandomNumbers(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(1, 1000));
            }
        }
        public void PrintList()
        {
            Console.WriteLine("Danh sach cac so nguyen : ");
            foreach (int num in list) Console.Write(num + " ");
            Console.WriteLine();
        }
        public void ReverseList() { list.Reverse(); }
        public bool Contains(int x) { return list.Contains(x); }

        public void PrintTwoDigitNumbers()
        {
            Console.WriteLine("Cac so co 2 chu so : ");
            foreach (int num in list)
            {
                if (num >= 10 && num < 100) Console.WriteLine(num + " ");
            }
            Console.WriteLine();
        }
        public void PrintEvenNumbers()
        {
            Console.Write("Cac so co cac chu so deu la so chan : ");
            foreach (int num in list)
            {
                bool allEven = true;
                foreach (char c in num.ToString())
                {
                    if (c % 2 != 0) { allEven = false; break; }
                }
                if (allEven) Console.Write(num + " ");
            }
        }
        public bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public void PrintPrimes()
        {
            Console.Write("Cac so nguyen to co trong danh sach : ");
            foreach (int n in list)
            {
                if (IsPrime(n)) Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        public void RemoveOddMultipleOfThree()
        {
            list.RemoveAll(num => num % 2 == 1 && num % 3 == 0);
            // Check num co chia het choa 2 3 , neu chia het cho 3 thi xoa 
        }
        public void IncreaseNeighbors()
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < list[i - 1] && list[i] < list[i + 1])
                {
                    list[i]++;
                }
            }
        }
        public void SortAscending() { list.Sort(); }
        public void SortDescending() { list.Sort((a, b) => b.CompareTo(a)); }
    }
}
