// Pham Ho Dang Huy - 2001215828
using System;
/*Công ty du lịch ABC quản lí thông tin 2 loại chuyến xe gồm:
- Chuyến xe nội thành : Mã số chuyến, Họ tên tài xé, số xe, số tuyến, số km đi được, doanh thu.
- Chuyến xe ngoại thành : Mã số chuyến , Họ tên tài xế, số xe, nơi đến, số ngày đi được, doanh thu
Yêu cầu : Xây dựng các lớp với chức năng kế thừa ( với các method: khởi tạo mặc định, khởi tạo đầy đủ tham số, nhập, xuất)*/
namespace Buoi8_KeThua
{
    // Mặt Hàng, Mặt Hàng Gia Dụng,Lương Thực
    class MatHang
    {
        public string MaMatHang { get; set; }
        public string Ten { get; set; }

    }
    class MHLuongThuc : MatHang
    {
        public float KhoiLuong { get; set; }
    }
    class MHGiaDung : MatHang
    {
        public int SoLuong { get; set; }
    }
    // Chuyến xe, nội thành và ngoại thành
    class ChuyenXe
    {
        public string MaSoChuyen { get; set; }
        public string HoTenTaiXe { get; set; }
        public string SoXe { get; set; }
        public double DoanhThu { get; set; }
        public ChuyenXe()
        {
            //Khoi tao mac dinh        
        }
        public ChuyenXe(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu)
        {
            MaSoChuyen = maSoChuyen;
            HoTenTaiXe = hoTenTaiXe;
            SoXe = soXe;
            DoanhThu = doanhThu;
        }
        public virtual void NhapThongTin()
        {
            Console.Write("Ma so chuyen : ");
            MaSoChuyen = Console.ReadLine();
            Console.Write("Ho ten tai xe : ");
            HoTenTaiXe = Console.ReadLine();
            Console.Write("Nhap so xe : ");
            SoXe = Console.ReadLine();
        }
        public virtual void XuatThongTin()
        {
            Console.WriteLine("Ma so chuyen xe : {0}", MaSoChuyen);
            Console.WriteLine("Ho ten tai xe : {0}", HoTenTaiXe);
            Console.WriteLine("So xe : {0}", SoXe);
            Console.WriteLine("Doanh thu : {0}", DoanhThu);
        }
    }
    class ChuyenXeNoiThanh : ChuyenXe
    {
        public string SoTuyen { get; set; }
        public double SoKmDiDuoc { get; set; }
        public ChuyenXeNoiThanh() { }
        public ChuyenXeNoiThanh(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu, string soTuyen, double soKmDiDuoc) : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            SoTuyen = soTuyen;
            SoKmDiDuoc = soKmDiDuoc;
        }
        public override void NhapThongTin()
        {
            base.NhapThongTin();

            Console.Write("Nhap so tuyen : ");
            SoTuyen = Console.ReadLine();

            Console.Write("Nhap so km di duoc : ");
            SoKmDiDuoc = double.Parse(Console.ReadLine());
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();

            Console.WriteLine("Loai chuyen xe : Noi thanh ");
            Console.WriteLine("So tuyen : {0}", SoTuyen);
            Console.WriteLine("So km di duoc : {0}", SoKmDiDuoc);
        }
    }

    class ChuyenXeNgoaiThanh : ChuyenXe
    {
        public string NoiDen { get; set; }
        public int SoNgayDiDuoc { get; set; }
        public ChuyenXeNgoaiThanh() { }
        public ChuyenXeNgoaiThanh(string maSoChuyen, string hoTenTaiXe, string soXe, double doanhThu, string noiDen, int soNgayDiDuoc) : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
        {
            NoiDen = noiDen;
            SoNgayDiDuoc = soNgayDiDuoc;
        }
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap noi den : ");
            NoiDen = Console.ReadLine();
            Console.Write("Nhap so ngay di : ");
            SoNgayDiDuoc = int.Parse(Console.ReadLine());
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();

            Console.WriteLine("Loai chuyen xe : Ngoai Thanh ");
            Console.WriteLine("So tuyen : {0}", NoiDen);
            Console.WriteLine("So km di duoc : {0}", SoNgayDiDuoc);
        }
    }
    class KeThua
    {
        static void Main()
        {
            //Tạo 2 mặt hàng lương thực và gia dụng

            MHLuongThuc matHangLuongThuc = new MHLuongThuc()
            {
                MaMatHang = "LT001",
                Ten = "product_LT",
                KhoiLuong = 2.5f
            };
            MHGiaDung matHangGiaDung = new MHGiaDung()
            {
                MaMatHang = "GD001",
                Ten = "product_GD",
                SoLuong = 10
            };
            // In ra MaMatHang và khối lượng của MHLuongThuc
            Console.WriteLine("Ma mat hang luong thuc {0}", matHangLuongThuc.MaMatHang);
            Console.WriteLine("Khoi luong mat hang luong thuc {0}", matHangLuongThuc.KhoiLuong);
            // In ra MaMatHang và số lượng của MHGiaDung
            Console.WriteLine("Ma mat hang gia dung {0}", matHangGiaDung.MaMatHang);
            Console.WriteLine("So luong mat hang gia dung {0}", matHangGiaDung.SoLuong);
            Console.Write("-----------------------------------------------------------------");
            Console.WriteLine("Bai Chuyen Xe ");

            ChuyenXeNoiThanh chuyenXeNoiThanh = new ChuyenXeNoiThanh();
            Console.WriteLine("Nhap thong tin chuyen xe noi thanh ");
            chuyenXeNoiThanh.NhapThongTin();

            ChuyenXeNgoaiThanh chuyenXeNgoaiThanh = new ChuyenXeNgoaiThanh();
            Console.WriteLine("Nhap thong tin chuyen xe ngoai thanh");
            chuyenXeNgoaiThanh.NhapThongTin();

            Console.WriteLine("\n\n\tThong tin chuyen xe noi thanh ");
            chuyenXeNoiThanh.XuatThongTin();
            Console.WriteLine("\tThong tin chuyen xe ngoai thanh");
            chuyenXeNgoaiThanh.XuatThongTin();
            Console.ReadKey();

        }
    }


}
