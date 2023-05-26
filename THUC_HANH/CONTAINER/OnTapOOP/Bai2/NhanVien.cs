using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    abstract class NhanVien
    {
        private string maNhanVien;
        private string hoTen;
        private DateTime ngaySinh;
        private double heSoLuong;
        private DateTime ngayVaoLam;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }

        // Khởi tạo mặc định
        public NhanVien()
        {
            MaNhanVien = "NV0001";
            HoTen = "Phạm Thanh Bình";
            NgaySinh = new DateTime(1996, 3, 15);
            HeSoLuong = 2.34;
            NgayVaoLam = DateTime.Now;
        }
        // Khởi tạo có tham số
        public NhanVien(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            HeSoLuong = heSoLuong;
            NgayVaoLam = ngayVaoLam;
        }
        public abstract double TinhLuong();
        public double LuongCoBan()
        {
            return 1400;
        }
    }
}
