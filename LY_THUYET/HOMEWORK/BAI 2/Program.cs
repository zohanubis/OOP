//Bài tập 1.
//Xây dựng phương thức get/set cho thuộc tính bán kính của lớp hình tròn. Xây dựng phương thức trả về  chu vi, diện tích hình tròn.
//Bài tập 2.
//Xây dựng lớp hình tam giác có thuộc tính là độ dài 3 cạnh. Xây dựng phương thức trả về chu vi và diện tích của tam giác.
//Bài tập 3: 
//Xây dựng lớp NgayThang lưu trữ ngày, tháng, năm với các phươngt hức:Phương thức khởi tạo mặc định,
//phương thức khởi tạo 3 tham số, kiểm tra năm nhuận, xác định ngày hôm trước, xác định ngày hôm sau của đối tượng hiện hành.
//Bài tập 4: 
//Xây dựng lớp để mô tả một định thức cấp 2 trong toán học. Với thành phần dữ liệu là một mảng 2 chiều 2 dòng, 2 cột.
using System;

class HinhTron
{
    //data
    private double r;
    //Properties
    public double R
    {
        get { return r; }
        set
        {
            if (value < 0)
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
        bool validInput = false;
        do
        {
            Console.Write("Nhap ban kinh : ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double radius) && radius >= 0)
            {
                this.r = radius;
                validInput = true;
            }
            else
            {
                Console.WriteLine("Ban kinh khong hop le. Vui long nhap lai.");
            }
        } while (!validInput);
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
class HinhTamGiac {
    private double canh1;
    private double canh2;
    private double canh3;

    public HinhTamGiac(double canh1, double canh2, double canh3)
    {
        this.canh1 = canh1;
        this.canh2 = canh2;
        this.canh3 = canh3;
    }

    public double ChuVi()
    {
        return canh1 + canh2 + canh3;
    }

    public double DienTich()
    {
        double p = ChuVi() / 2 ;
        return Math.Sqrt(p * (p - canh1) * (p - canh2) * (p - canh3));
    }
}
public class RightLadder
{
    public int day;
    public int month;
    public int year;

    public RightLadder()
    {
        // Default constructor sets date to today's date
        DateTime today = DateTime.Today;
        this.day = today.Day;
        this.month = today.Month;
        this.year = today.Year;
    }

    public RightLadder(int day, int month, int year)
    {
        // Constructor with parameters
        this.day = day;
        this.month = month;
        this.year = year;
    }

    public bool IsLeapYear()
    {
        // Check if the year is a leap year
        return DateTime.IsLeapYear(this.year);
    }

    public RightLadder PreviousDay()
    {

        DateTime date = new DateTime(this.year, this.month, this.day);
        date = date.AddDays(-1);
        return new RightLadder(date.Day, date.Month, date.Year);
    }

    public RightLadder NextDay()
    {

        DateTime date = new DateTime(this.year, this.month, this.day);
        date = date.AddDays(1);
        return new RightLadder(date.Day, date.Month, date.Year);
    }
    
}
//Hàm AddDays trong đoạn code trên là một phương thức của lớp DateTime trong C#,
//nó cho phép thêm một số nguyên đại diện cho số ngày vào một đối tượng DateTime hiện tại và
//trả về một đối tượng DateTime mới mà có giá trị ngày tháng năm sau khi đã thêm số ngày được chỉ định.

//Ví dụ, nếu bạn có một đối tượng DateTime biểu diễn ngày 1/1/2022 
//    và muốn tìm đối tượng DateTime biểu diễn ngày tiếp theo, 
//    bạn có thể sử dụng phương thức AddDays(1) để thêm một ngày và 
//    trả về một đối tượng DateTime biểu diễn ngày 2/1/2022. 
//    Tương tự, để tìm ngày trước đó, bạn có thể sử dụng phương thức AddDays(-1).

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
        HinhTron ht = new HinhTron();
        
        int choice = 0,choiceD=0;
        do
        {
            Console.WriteLine("-----Menu-----");
            Console.WriteLine("Cau 1 : Tinh chu vi va dien tich hinh tron");
            Console.WriteLine("Cau 2 : Tinh chu vi va dien tich hinh tam giac");
            Console.WriteLine("Cau 3 : Kiem tra nam nhuan, kiem tra hom truoc hom sau ");
            Console.WriteLine("Cau 4 : Tinh dinh thuc cap 2");
            Console.Write("Lua chon cua ban : ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException)
            {
                Console.WriteLine("Lua chon khong hop le, chon lai");
                continue;
            }
            switch(choice)
            {
                case 1: 
                    ht.Input(); 
                    ht.Output();

                    HinhTron ht2 = new HinhTron(5.0f);

                    Console.WriteLine("Chu vi hinh tron : {0:0.00}", ht2.ChuVi());
                    Console.WriteLine("Dien tich hinh tron : {0:0.00}", ht2.DienTich());
                    break;
                case 2:
                    Console.Write("Nhap gia tri a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Nhap gia tri b: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Nhap gia tri c: ");
                    double c = double.Parse(Console.ReadLine());

                    HinhTamGiac tg = new HinhTamGiac(a, b, c);
                    Console.WriteLine("Chu vi cua tam giac: {0}", tg.ChuVi());
                    Console.WriteLine("Dien tich cua tam giac: {0}", tg.DienTich());
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("\n-------Menu NgayThang-----");
                        Console.WriteLine("1. Ngay thang hien tai : kiem tra nam nhuan, ngay hom truoc va ngay hom sau");
                        Console.WriteLine("2. Ngay thang (nhap tu ban phim) : kiem tra nam nhuan, ngay hom truoc va ngay hom sau");
                        Console.Write("Lua chon cua ban :");
                        try
                        {
                            choiceD= Convert.ToInt32(Console.ReadLine());
                        }catch(FormatException)
                        {
                            Console.WriteLine("Lua chon khong hop le, chon lai");
                            continue;
                        }
                        switch(choiceD)
                        {
                            case 1:
                                RightLadder today = new RightLadder();

                                Console.WriteLine("Hom nay la {0}/{1}/{2}",today.day,today.month,today.year);

                               Console.WriteLine("{0} co phai la nam nhuan ? : {1}",today.year,today.IsLeapYear());

                                RightLadder previousToDay = today.PreviousDay();
                                Console.WriteLine("Hom truoc la {0}/{1}/{2}", previousToDay.day, previousToDay.month, previousToDay.year);
                                RightLadder nextDayToDay = today.NextDay();
                                Console.WriteLine("Hom sau la {0}/{1}/{2}",nextDayToDay.day,nextDayToDay.month,nextDayToDay.year);
                                break;
                            case 2:
                                RightLadder userDate = InputDate();
                                Console.WriteLine("Ngay thang nam vua nhap: {0}/{1}/{2}", userDate.day, userDate.month, userDate.year);
                                Console.WriteLine("Nam {0} co phai la nam nhuan? {1}", userDate.year, userDate.IsLeapYear());
                                RightLadder previousUser = userDate.PreviousDay();
                                Console.WriteLine("Hom truoc {0}/{1}/{2}", previousUser.day, previousUser.month, previousUser.year);
                                RightLadder nextDayUser = userDate.NextDay();
                                Console.WriteLine("Hom sau {0}/{1}/{2}", nextDayUser.day, nextDayUser.month, nextDayUser.year);


                                break;
                        }
                    } while (choiceD <= 4);
                    break; 
                case 4:
                    MaTran mt = new MaTran();
                    mt.Input();
                    Console.WriteLine("Ma tran vua nhap la:");
                    mt.Output();
                    Console.WriteLine("Dinh thuc cua ma tran la: {0}", mt.TinhDinhThuc());
                    break;
            }
        } while (choice <= 4);
    }
    public static RightLadder InputDate()
    {
        int day, month, year;
        while (true)
        {
            Console.Write("Nhap ngay: ");
            if (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
            {
                Console.WriteLine("Ngay nhap khong hop le, vui long nhap lai (1-31).");
                continue;
            }

            Console.Write("Nhap thang: ");
            if (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
            {
                Console.WriteLine("Thang nhap khong hop le, nhap lai (1-12).");
                continue;
            }

            Console.Write("Nhap nam: ");
            if (!int.TryParse(Console.ReadLine(), out year) || year < 1)
            {
                Console.WriteLine("Nam nhap khong hop le.");
                continue;
            }
            try
            {
                return new RightLadder(day, month, year);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("ERROR.");
            }
        }
    }
}