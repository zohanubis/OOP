using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            // Tạo một đối tượng Nhân Viên
            NhanVien nhanVien = new NhanVien("01NV", "Nguyễn Văn A", "Nhân Viên", "Việt Nam", 1.5, 0);

            // In thông tin của Nhân Viên
            Console.WriteLine("Thông tin Nhân Viên:");
            Console.WriteLine("Mã Nhân Viên: " + nhanVien.MaNhanVien);
            Console.WriteLine("Tên Nhân Viên: " + nhanVien.TenNhanVien);
            Console.WriteLine("Trình Độ: " + nhanVien.TrinhDo);
            Console.WriteLine("Nơi Đào Tạo: " + nhanVien.NoiDaoTao);
            Console.WriteLine("Hệ Số Lương: " + nhanVien.HeSoLuong);
            Console.WriteLine("Số Lỗi Vi Phạm: " + nhanVien.SoLoiViPham);

            // Tính và in lương của Nhân Viên
            double luong = nhanVien.TinhLuong();
            Console.WriteLine("Lương: " + luong);

            // Tính và in lương thực lãnh của Nhân Viên
            double thucLanh = nhanVien.TinhThucLanh();
            Console.WriteLine("Lương Thực Lãnh: " + thucLanh);

            Console.ReadLine();
        }
    }

}
