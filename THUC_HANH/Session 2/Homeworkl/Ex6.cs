//Bài 6.Xây dựng lớp chứa thông tin của các vận động viên chạy đua
//trong 1 cuộc đua maraton, gồm những thuộc tính và thành phần sau:
//-Mã số, họ tên, số áo, thời gian bắt đầu (kiểu Giờ của bài 5), thời
//gian kết thúc (kiểu Giờ của bài 5).
//-Ngoài ra còn có thành tích chuẩn (1:30:00): thời gian qui định thành
//tích phải <= thành tích chuẩn này, nếu chạy chậm hơn thì coi như
//không đạt trong cuộc thi. Giá trị này áp dụng cho tất cả các vận
//động viên.
//- 3 Phương thức khởi tạo.
//- Phương thức nhập/xuất thông tin vận động viên.
//- Phương thức tính thành tích (= thời gian kết thúc – thời gian bắt
//đầu), đổi ra dạng giờ:phút: giây
//- Phương thức kiểm tra thời gian nhập vào bắt đầu và kết thúc có hợp
//lệ không? Giờ hợp lệ là giờ thuộc hệ thống giờ trên đồng hồ (loại
//24h).
//-Viết chương trình nhập/xuất thông tin vận động viên. Lưu ý: không
//nhập thành tích vì thuộc tính này lấy kết quả từ thời gian bắt đầu và
//kết thúc
using System;
using System.Globalization;
using System.IO;

namespace Homework.Ex6
{
    class Runner
    {
        private int id;
        private string name;
        private int bibNumber;
        private DateTime startTime;
        private DateTime endTime;
        private static readonly TimeSpan standardTime = new TimeSpan(1, 30, 0); // Thoi gian chuan

        public Runner(int id, string name, int bibNumber, DateTime startTime, DateTime endTime)
        {
            this.id = id;
            this.name = name;
            this.bibNumber = bibNumber;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public Runner(int id, string name, int bibNumber)
        {
            this.id = id;
            this.name = name;
            this.bibNumber = bibNumber;
            startTime = new DateTime();
            endTime = new DateTime();
        }

        public Runner()
        {
            id = 0;
            name = "";
            bibNumber = 0;
            startTime = new DateTime();
            endTime = new DateTime();
        }
        public static Runner[] ReadFromFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                Runner[] runners = new Runner[lines.Length - 1];
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    int id = int.Parse(fields[0]);
                    string name = fields[1];
                    int bibNumber = int.Parse(fields[2]);
                    DateTime startTime = DateTime.ParseExact(fields[3], "HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime endTime = DateTime.ParseExact(fields[4], "HH:mm:ss", CultureInfo.InvariantCulture);
                    runners[i - 1] = new Runner(id, name, bibNumber, startTime, endTime);
                }
                return runners;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        public void NhapThongTin()
        {
            Console.WriteLine("Nhap thong tin cua van dong vien:");
            Console.Write("Ma so: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Ho ten: ");
            name = Console.ReadLine();
            Console.Write("So ao: ");
            bibNumber = int.Parse(Console.ReadLine());
            Console.Write("Thoi gian bat dau (HH:mm:ss): ");
            startTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Thoi gian ket thuc (HH:mm:ss): ");
            endTime = DateTime.Parse(Console.ReadLine());
        }

        public void XuatThongTin()
        {
            //Console.WriteLine("{0,-10}{1,-20}{2,-10}{3,-15}{4,-15}{5,-10}",
            //    "Ma so", "Ho ten", "So ao", "Thoi gian BD", "Thoi gian KT", "Thanh tich");
            Console.WriteLine("{0,-10}{1,-20}{2,-10}{3,-15}{4,-15}{5,-10}",
                id, name, bibNumber, startTime.ToString("HH:mm:ss"),
                endTime.ToString("HH:mm:ss"), GetThanhTich());
        }

        public TimeSpan GetThanhTich()
        {
            TimeSpan performance = endTime.Subtract(startTime);
            if (performance.CompareTo(standardTime) <= 0)
            {
                return performance;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }

        public bool IsValidTime()
        {
            return startTime.Hour >= 0 && startTime.Hour <= 23
                && startTime.Minute >= 0 && startTime.Minute <= 59
                && startTime.Second >= 0 && startTime.Second <= 59;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Runner[] runners = null;

            int choice;
            do
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Nhap thong tin van dong vien tu file");
                Console.WriteLine("2. Nhap thong tin van dong vien");
                Console.WriteLine("3. Xuat thong tin van dong vien");
                Console.WriteLine("4. Thoat");
                Console.Write("Nhap lua chon cua ban (1-3): ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        runners = Runner.ReadFromFile("vdv.txt");
                        if (runners != null)
                        {
                            foreach (Runner runner in runners)
                            {
                                runner.XuatThongTin();
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Nhap so van dong vien: ");
                        int n = int.Parse(Console.ReadLine());
                        Runner[] newRunners = new Runner[n];

                        for (int i = 0; i < n; i++)
                        {
                            newRunners[i] = new Runner();
                            newRunners[i].NhapThongTin();
                        }

                        runners = runners.Concat(newRunners).ToArray();
                        break;

                    case 3:
                        Console.WriteLine("{0,-10}{1,-20}{2,-10}{3,-15}{4,-15}{5,-10}", "Ma so", "Ho ten", "So ao", "Thoi gian BD", "Thoi gian KT", "Thanh tich");
                        foreach (Runner runner in runners)
                        {
                            runner.XuatThongTin();
                        }
                        break;

                    case 4:
                        Console.WriteLine("Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 3);
        }
    }
}

