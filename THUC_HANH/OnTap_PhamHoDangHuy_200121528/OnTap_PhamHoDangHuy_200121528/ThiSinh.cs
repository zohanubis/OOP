using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap_PhamHoDangHuy_200121528
{
    class ThiSinh
    {
        private string maThiSinh;
        private string hoTen;
        private string gioiTinh;
        private float diemLyThuyet;
        private float diemThucHanh;
        // Property
        public string MaThiSinh
        {
            get { return maThiSinh; }
            set { maThiSinh = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        public float DiemLyThuyet
        {
            get { return diemLyThuyet; }
            set { diemLyThuyet = value; }
        }
        public float DiemThucHanh
        {
            get { return diemThucHanh; }
            set { diemThucHanh = value; }
        }
        // Khởi tạo mặc định
        public ThiSinh()
        {

        }
        // Khởi tạo 1 tham số
        public ThiSinh(ThiSinh ts)
        {
            this.MaThiSinh = ts.MaThiSinh;
            this.HoTen = ts.HoTen;
            this.GioiTinh = ts.GioiTinh;
            this.DiemLyThuyet = ts.DiemLyThuyet;
            this.DiemThucHanh = ts.DiemThucHanh;
        }
        // Khởi tạo 5 tham số
        public ThiSinh(string maThiSinh, string hoTen, string gioiTinh, float diemLyThuyet, float diemThucHanh)
        {
            this.MaThiSinh = maThiSinh;
            this.HoTen = hoTen;
            this.GioiTinh = gioiTinh;
            this.DiemLyThuyet = diemLyThuyet;
            this.DiemThucHanh = diemThucHanh;
        }
        public double TinhDiemTongKet()
        {
            return (DiemLyThuyet + DiemThucHanh) / 2;
        }
        public string XetTuyen()
        {
            if (TinhDiemTongKet() >= 5 && DiemThucHanh >= 5 && DiemLyThuyet >= 5)
                return "Đậu";
            else 
                return "Rớt";
        }
        public void NhapThongTin()
        {
            Console.WriteLine("Nhập mã thí sinh: ");
            MaThiSinh = Console.ReadLine();

            Console.WriteLine("Nhập họ tên: ");
            HoTen = Console.ReadLine();

            Console.WriteLine("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();

            Console.WriteLine("Nhập điểm lý thuyết: ");
            DiemLyThuyet = float.Parse(Console.ReadLine());

            Console.WriteLine("Nhập điểm thực hành: ");
            DiemThucHanh = float.Parse(Console.ReadLine());
        }
        public void XuatThongTin()
        {
            Console.WriteLine("Mã thí sinh: " + MaThiSinh);
            Console.WriteLine("Họ tên: " + HoTen);
            Console.WriteLine("Giới tính: " + GioiTinh);
            Console.WriteLine("Điểm lý thuyết: " + DiemLyThuyet);
            Console.WriteLine("Điểm thực hành: " + DiemThucHanh);
            Console.WriteLine("Điểm tổng kết: " + TinhDiemTongKet());
            Console.WriteLine("Kết quả xét tuyển: " + XetTuyen());
        }
    }
}
