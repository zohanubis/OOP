//Bài 4 : Xây dựng lớp để mô ta một định thức cấp 2 trong toán học 
//Với thành phần dữ liệu là một mảng 2 chiều 2 dòng, 2 cột
using System;
class MaTran
{
    private int[,] data;

    public MaTran()
    {
        data = new int[2, 2];
    }

    public MaTran(int a, int b, int c, int d)
    {
        data = new int[2, 2];
        data[0, 0] = a;
        data[0, 1] = b;
        data[1, 0] = c;
        data[1, 1] = d;
    }

    public void Input()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write("Nhap vao phan tu [{0}, {1}]: ", i, j);
                data[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void Output()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write("{0}\t", data[i, j]);
            }
            Console.WriteLine();
        }
    }

    public int TinhDinhThuc()
    {
        return data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0];
    }
}

class Program
{
    static void Main(string[] args)
    {
        MaTran mt = new MaTran();
        mt.Input();
        Console.WriteLine("Ma tran vua nhap la:");
        mt.Output();
        Console.WriteLine("Dinh thuc cua ma tran la: {0}", mt.TinhDinhThuc());
    }
}
