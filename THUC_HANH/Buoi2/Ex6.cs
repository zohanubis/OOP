using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_PhamHoDangHuy_2001215828
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
}
