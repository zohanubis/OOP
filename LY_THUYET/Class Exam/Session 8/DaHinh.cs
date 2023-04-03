using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaHinh
{
    /*1. Xây dựng class NhanVien với các thông tin : mã nhân viên, tên nhân viên, hệ số lương, phòng ban, số ngày làm việc; 
     * Method : Xếp loại, Tính Thu Nhập , Nhập xuất thông tin
    Biết răng : Nếu số ngày làm việc > 25 loại A, nếu số ngày làm việc > 22 loại B, còn lại loại C
	Lương = 1210 * hệ số lương * hệ số thi đua
Trong đó hệ số thi đua là 1.00;0,75 và 0.5 tương ứng với loại thi đua là A,B,C.
2. Xây dựng lớp Cán Bộ Quản Lý. Biết răng cán bộ quản lý cũng là một nhân viên nhưng có thêm các đặc điểm sau:
Mỗi cán bộ quản lý sẽ có thêm thuộc tính chức vụ và hệ số chức vụ
	Lương = hệ số lương * 1210 * hệ số thi đua + hệ số chức vụ * 1100*/

    class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public double HeSoLuong { get; set; }
        public string PhongBan { get; set; }
        public int SoNgayLamViec { get; set; }

        public NhanVien()
        {
            MaNV = "";
            TenNV = "";
            HeSoLuong = 0.0;
            PhongBan = "";
            SoNgayLamViec = 0;
        }

        public NhanVien(string maNV, string tenNV, double heSoLuong, string phongBan, int soNgayLamViec)
        {
            MaNV = maNV;
            TenNV = tenNV;
            HeSoLuong = heSoLuong;
            PhongBan = phongBan;
            SoNgayLamViec = soNgayLamViec;
        }
        public virtual void XepLoai()
        {
            if (SoNgayLamViec > 25) { Console.WriteLine("Loai A"); }
            else if (SoNgayLamViec > 22) { Console.WriteLine("Loai B"); }
            else { Console.WriteLine("Loai C"); }
        }
        public virtual double TinhLuong()
        {
            double heSoThiDua = 0.0;
            if (SoNgayLamViec > 25)
            {
                heSoThiDua = 1.0;
            }
            else if (SoNgayLamViec > 22)
            {
                heSoThiDua = 0.75;
            }
            else
            {
                heSoThiDua = 0.5;
            }
            return 1210 * HeSoLuong * heSoThiDua;
        }
        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ma nhan vien : ");
            MaNV = Console.ReadLine();

            Console.Write("Nhap ten nhan vien : ");
            TenNV = Console.ReadLine();

            Console.Write("Nhap he so luong : ");
            HeSoLuong = double.Parse(Console.ReadLine());

            Console.Write("Nhap phong ban : ");
            PhongBan = Console.ReadLine();
            Console.Write("Nhap so ngay lam viec: ");
            SoNgayLamViec = int.Parse(Console.ReadLine());
        }
        public virtual void XuatThongTin()
        {
            Console.WriteLine("Ma nhan vien : " + MaNV);
            Console.WriteLine("Ten Nhan vieen : " + TenNV);
            Console.WriteLine("He so luong : " + HeSoLuong);
            Console.WriteLine("So ngay lam viec: " + SoNgayLamViec);
            Console.WriteLine("Thu Nhap: " + TinhLuong());
            Console.Write("Xep loai: ");
            XepLoai();
        }
    }
    class CanBoQuanLy : NhanVien
    {
        public string ChucVu { get; set; }
        public double HeSoChucVu { get; set; }
        public CanBoQuanLy() : base() { ChucVu = ""; HeSoChucVu = 0.0; }

        public CanBoQuanLy(string maNV, string tenNV, double heSoLuong, string phongBan, int soNgayLamViec, string chucVu, double heSoChucVu) : base(maNV, tenNV, heSoLuong, phongBan, soNgayLamViec)
        {
            ChucVu = chucVu;
            HeSoChucVu = heSoChucVu;
        }
        public override double TinhLuong()
        {
            double heSoThiDua = base.TinhLuong() / (1210 * HeSoLuong); // tính HeSoThiDua từ class NhanVien
            SoNgayLamViec = base.SoNgayLamViec; // gán giá trị SoNgayLamViec từ class NhanVien

            double luong = HeSoLuong * 1210 * heSoThiDua + HeSoChucVu * 1100;
            return luong;
        }
        public override void XepLoai()
        {
            base.XepLoai();
            if (SoNgayLamViec > 25)
            {
                Console.WriteLine("Can bo quan ly {0} - {1} thuoc loai A", MaNV, TenNV);
            }
            else if (SoNgayLamViec > 22)
            {
                Console.WriteLine("Can bo quan ly {0} - {1} thuoc loai B", MaNV, TenNV);
            }
            else
            {
                Console.WriteLine("Can bo quan ly {0} - {1} thuoc loai C", MaNV, TenNV);
            }
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();

            Console.WriteLine("Ma Nhan Vien:\t\t{0}", MaNV);
            Console.WriteLine("Ten Nhan Vien:\t\t{0}", TenNV);
            Console.WriteLine("He So Luong:\t\t{0}", HeSoLuong);
            Console.WriteLine("Phong ban:\t\t{0}", PhongBan);
            Console.WriteLine("So ngay lam viec:\t{0}", SoNgayLamViec);
            Console.WriteLine("Chuc vu:\t\t\t{0}", ChucVu);
            Console.WriteLine("He so chuc vu:\t\t{0}", HeSoChucVu);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NhanVien nv = new NhanVien();

            Console.WriteLine("Nhap thong tin nhan vien");
            nv.NhapThongTin();

            Console.WriteLine("\n\n\t\tThong tin nhan vien: ");
            nv.XuatThongTin();

            CanBoQuanLy cbql = new CanBoQuanLy();
            Console.WriteLine("Nhap thong tin can bo quan li : ");
            cbql.NhapThongTin();
            Console.WriteLine("\n\n\t\t\tThong tin Can Bo quan li: ");
            cbql.XuatThongTin();
        }
    }
}

