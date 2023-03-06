using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TamGiac
{
    private double a, b, c;

    public TamGiac(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public TamGiac() { a = 0; b = 0; c = 0; }
    public double ChuVi()
    {
        return a + b + c;
    }
    public double DienTich()
    {
        double p = ChuVi() / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap gia tri a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhap gia tri b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Nhap gia tri c: ");
        double c = double.Parse(Console.ReadLine());

        TamGiac tg = new TamGiac(a, b, c);
        Console.WriteLine("Chu vi cua tam giac: {0}", tg.ChuVi());
        Console.WriteLine("Dien tich cua tam giac: {0}", tg.DienTich());
    }
}
