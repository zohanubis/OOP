using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bài 7.Viết chương trình nhập vào 1 số nguyên n.
//- Phân tích n ra thừa số nguyên tố.
//- Cho biết n có bao nhiêu chữ số
public class Prime
{
    private int num;
    public Prime(int n) { num = n; } 

    public void PhanTich() { 
        Console.Write("Phan tich "+ num + " ra thua so nguyen to : ");
        int i = 2;
        while(num > 1)
        {
            if(num % i == 0) { 
                Console.Write(i + " "); 
                num /= i;
            }
            else
            {
                i++;
            }
        }
        Console.WriteLine();
    }
    public void DemSo()
    {
        int count= 0;
        int n = num;
        while(num != 0) {
            n /= 10;
            count ++;
        }
        Console.WriteLine(num + "có" + count + "chữ số");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen n : ");
        int n = int.Parse(Console.ReadLine());

        Prime prime = new Prime(n);
        prime.PhanTich();
        prime.DemSo();
    }
}