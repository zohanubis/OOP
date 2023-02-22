// Viết chương trình cho nhập vào số phải là số chính phương, xuất số chính phường ra ngoài màn hình
using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhap so chinh phuong : ");
        int n = int.Parse(Console.ReadLine());

        int squareRoot = (int)Math.Sqrt(n);
        if (squareRoot * squareRoot == n)
        {
            Console.WriteLine("So nhap nhap la so chinh phuong");
        }
        else
        {
            Console.WriteLine("So nhap khong phai la so chinh phuong");
        }
    }
}