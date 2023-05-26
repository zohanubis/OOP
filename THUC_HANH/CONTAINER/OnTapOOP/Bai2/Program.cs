using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            NhanVienHanhChinh nvHanChinh = new NhanVienHanhChinh("NV0002", "Nguyễn Văn A", new DateTime(1990, 5, 10), 1.8, DateTime.Now, 2);
            PhatTrienPhanMem nvPhatTrien = new PhatTrienPhanMem("NV0003", "Trần Thị B", new DateTime(1992, 8, 20), 2.5, DateTime.Now, 10, 25);
            KiemThuPhanMem nvKiemThu = new KiemThuPhanMem("NV0004", "Lê Văn C", new DateTime(1988, 11, 5), 2.0, DateTime.Now, 8, 60);

            double luongNhanVienHanChinh = nvHanChinh.TinhLuong();
            double luongNhanVienPhatTrien = nvPhatTrien.TinhLuong();
            double luongNhanVienKiemThu = nvKiemThu.TinhLuong();

            Console.WriteLine("Lương nhân viên hành chính: " + luongNhanVienHanChinh);
            Console.WriteLine("Lương nhân viên phát triển phần mềm: " + luongNhanVienPhatTrien);
            Console.WriteLine("Lương nhân viên kiểm thử phần mềm: " + luongNhanVienKiemThu);

            ILuongNgoaiGio nvPhatTrien1 = new PhatTrienPhanMem("NV0005", "Nguyễn Thị D", new DateTime(1995, 3, 8), 2.2, DateTime.Now, 20, 30);
            ILuongNgoaiGio nvKiemThu1 = new KiemThuPhanMem("NV0006", "Trần Văn E", new DateTime(1993, 9, 15), 1.7, DateTime.Now, 60, 10);

            double luongNgoaiGioNhanVienPhatTrien = nvPhatTrien1.TinhLuongNgoaiGio();
            double luongNgoaiGioNhanVienKiemThu = nvKiemThu1.TinhLuongNgoaiGio();

            Console.WriteLine("Lương ngoài giờ nhân viên phát triển phần mềm: " + luongNgoaiGioNhanVienPhatTrien);
            Console.WriteLine("Lương ngoài giờ nhân viên kiểm thử phần mềm: " + luongNgoaiGioNhanVienKiemThu);

            Console.ReadLine();
        }
    }
}
