// Bài 5. Xây dựng lớp Time chứa các thành phần sau:
// - Các thuộc tính giờ, phút, giây (cần kiểm tra giá trị nhập vào của giờ,
// phút và giây: 0<= giờ <=23; 0<= phút <=59; 0<= giây <=59).
// - 3 phương thức khởi tạo.
// - Nhập/xuất thời gian theo dạng 24 giờ.
// - Nhập/xuất thời gian theo dạng 12 giờ (cần có thêm thông tin AM
// và PM).
// - Phương thức kiểm tra giờ có hợp lệ không? Biết rằng giờ hợp lệ là
// giờ theo hệ thống đồng hồ.25
// - Viết phương thức tăng/giảm giờ (Phương thức overload):
// + void tanggio (int sogiay); ® tăng giờ thông thường
// theo dạng giờ 24h
// + void tanggio (int sogiay, string kieuGio); ®
// kết quả ra dạng giờ 24 tiếng nếu kiểu giờ là 24, kết quả dạng
// 12h kèm AM/PM nếu kiểu giờ là 12.
// + Tương tự cho 2 phương thức giảm giờ.

using System;
namespace TimeApp
{
    class Time
{
    private int hour;
    private int minute;
    private int second;

    public Time() { 
        hour = 0; 
        minute = 0; 
        second = 0; 
    }
    public Time(int h, int m , int s)
    {
        hour = h;
        minute = m;
        second = s;
    }
    public void Input()
    {
        Console.Write("Enter hour (0-23h) : ");
        hour = int.Parse(Console.ReadLine());
        Console.Write("Enter minute (0-59) : ");
        minute = int.Parse(Console.ReadLine());
        Console.Write("Enter second (0-59) : ");
        second = int.Parse(Console.ReadLine());
    }
    public void Output24() { 
        Console.WriteLine("{0:D2}:{1:D2}:{2:D2}",hour,minute,second);
    }
    public void Output12()
    {
        string ampm = "AM";
        int h = hour;
        if (hour > 12)
        {
            h = hour - 12;
            ampm = "PM";
        }
        Console.WriteLine("{0:D2}:{1:D2}:{2:D2} {3}", h, minute, second, ampm);
        }
    public bool IsTimeValid()
    {
        if(hour < 0 || hour > 23)
            return false;
        if (minute < 0 || minute > 59)
            return false;
        if (second < 0 || second > 59)
            return false;
        return true;
    }
    public void AddSeconds(int seconds)
    {
        second += seconds;
        while(second >= 60)
        {
            second -= 60;
            minute++;
            
            if(minute >= 60)
            {
                minute = 0;
                hour++;

                if(hour >= 24) { hour = 0; }
            }
        }
    }
    public void AddSeconds(int seconds, string format)
    {
        AddSeconds(seconds);

        if(format == "12")
        {
            Output12();
        }
        else
        {
            Output24();
        }
    }
    public void SubtractSeconds(int seconds)
    {
        second -= seconds;
        while(second < 0)
        {
            second += 60;
            minute--;
            if(minute < 0) 
            { 
                minute = 59; 
                hour--; 
                if(hour < 0 ) 
                { 
                    hour = 23; 
                }
            }
        }
    }
    public void SubtractSeconds(int seconds, string format)
    {
        SubtractSeconds(seconds);
        if(format == "12")
        {
            Output12();
        }
        else
        {
            Output24();
        }
    }
}


    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            Time t = new Time(12, 30, 45);

            do
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. In thoi gian theo dang 24h");
                Console.WriteLine("2. In thoi gian theo dang 12h");
                Console.WriteLine("3. Kiem tra gio co hop le khong");
                Console.WriteLine("4. Tang gio");
                Console.WriteLine("5. Giam gio");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.Write("Chon cau ban muon : ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lua chon khong hop le, chon lai.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Thoi gian hien tai la : ");
                        t.Output24();
                        break;

                    case 2:
                        Console.WriteLine("Thoi gian hien tai la: ");
                        t.Output12();
                        break;

                    case 3:
                        if (t.IsTimeValid())
                            Console.WriteLine("Gio hop le.");
                        else
                            Console.WriteLine("Gio khong hop le.");
                        break;

                    case 4:
                        Console.Write("Nhap so giay muon tang: ");
                        int sec = int.Parse(Console.ReadLine());
                        Console.Write("Chon dinh dang (12h | 24h): ");
                        string format = Console.ReadLine();
                        t.AddSeconds(sec, format);
                        break;

                    case 5:
                        Console.Write("Nhap so giay muon giam : ");
                        sec = int.Parse(Console.ReadLine());
                        Console.Write("Chon dinh dang (12h | 24h): ");
                        format = Console.ReadLine();
                        t.SubtractSeconds(sec, format);
                        break;

                    case 0:
                        Console.WriteLine("Cam on da su dung chuong trinh");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le, chon lai.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 0);
        }
    }
}
