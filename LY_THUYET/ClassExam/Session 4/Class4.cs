using System;
public class HinhTron
{
    //data
    private double r;
    //Properties
    public double R
    {
        get { return r; }
        set { 
            if(value < 0)
            {
                Console.Write("Error");
                r = 0;
            }
            else
            {
                r = value;
            }
        }
    }
    //Constructor
    public HinhTron()
    {
        this.r = 0;
    }
    public HinhTron(double r)
    {
        this.r = r;
    }
    public void Input()
    {
        Console.Write("Nhap ban kinh : ");
        this.r = double.Parse(Console.ReadLine());
    }
    public void Output()
    {
        Console.WriteLine("Hinh tron co ban kinh : {0:0.00}, Chu vi {1:0.00}, Dien tich {2:0.00}", r, ChuVi(), DienTich());
    }
    public double ChuVi()
    {
        return this.r * 2 * Math.PI;
    }
    public double DienTich()
    {
        return Math.Pow(this.r, 2) * Math.PI;
    }
}
class Program
{
    static void Main(string[] args)
    {
        HinhTron a = new HinhTron();
        a.Input();
        a.Output();

        HinhTron b = new HinhTron(5.0f);

        Console.WriteLine("Chu vi hinh tron b : {0:0.00}", b.ChuVi());
        Console.WriteLine("Dien tich hinh tron b : {0:0.00}", b.DienTich());
        Console.ReadLine();
    }
}