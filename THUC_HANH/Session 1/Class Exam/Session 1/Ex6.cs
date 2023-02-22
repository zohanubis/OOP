//Bài 6. Viết chương trình nhập vào giá Ngay/tháng/năm của một Ngay
//trong một năm bất kỳ. Cho biết Ngay đó thứ mấy. Biết rằng công thứ
//tính thứ của một Ngay/tháng/năm như sau:
//Điều kiện:
//Tháng < 3: tháng = tháng + 12; năm = năm – 1
//Tháng >= 3
//n = (Ngay + 2 * tháng + (3 * (tháng + 1)) / 5 + năm + (năm / 4)) % 7
//với n la kết quả thứ theo thứ tự: 0 la chủ nhật, 1 la thứ 2, …, 6 la thứ 7

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap ngay: ");
        int ngay = int.Parse(Console.ReadLine());

        Console.Write("Nhap thang: ");
        int thang = int.Parse(Console.ReadLine());

        Console.Write("Nhap nam: ");
        int nam = int.Parse(Console.ReadLine());

        if (thang < 3)
        {
            thang += 12;
            nam--;
        }

        int n = (ngay + 2 * thang + (3 * (thang + 1)) / 5 + nam + (nam / 4) - (nam / 100) + (nam / 400)) % 7;

        switch (n)
        {
            case 0:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay chu nhat", ngay, thang, nam);
                break;
            case 1:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu hai", ngay, thang, nam);
                break;
            case 2:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu 3", ngay, thang, nam);
                break;
            case 3:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu tu", ngay, thang, nam);
                break;
            case 4:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu nam", ngay, thang, nam);
                break;
            case 5:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu sau", ngay, thang, nam);
                break;
            case 6:
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu bay", ngay, thang, nam);
                break;
        }
    }
}
