//Bài 9. Nhập vào 1 ngày tháng năm. Cho biết ngày trước đó và ngày hôm sau là ngày mấy.
using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhap vao ngay thang nam : ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        DateTime yesterday = date.AddDays(-1);
        DateTime tomorrow = date.AddDays(1);

        Console.WriteLine("Ngay hom truoc : " + yesterday.ToString("dd/MM/yyyy"));
        Console.WriteLine("Ngay hom sau : " + tomorrow.ToString("dd/MM/yyyy"));

    }
}