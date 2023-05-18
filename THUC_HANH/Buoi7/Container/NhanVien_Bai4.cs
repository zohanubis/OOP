using System;

namespace Buoi6_Abstract
{
    abstract class NhanVien_Bai4
    {
        protected string maNhanVien;
        protected string tenNhanVien;
        protected double heSoLuong;

        public NhanVien_Bai4()
        {
            maNhanVien = "NV001";
            tenNhanVien = "Họ Tên Sinh Viên";
            heSoLuong = 2.34;
        }

        public NhanVien_Bai4(string maNV, string tenNV, double heSo)
        {
            if (maNV.Length >= 2 && maNV.Substring(0, 2) == "NV")
            {
                maNhanVien = maNV;
            }
            else
            {
                maNhanVien = "NV001";
            }

            tenNhanVien = tenNV;
            heSoLuong = heSo;
        }

        public abstract double TinhThuNhap();

        public void Xuat()
        {
            Console.WriteLine("Mã nhân viên: " + maNhanVien);
            Console.WriteLine("Tên nhân viên: " + tenNhanVien);
            Console.WriteLine("Hệ số lương: " + heSoLuong);
            Console.WriteLine("Thu nhập: " + TinhThuNhap());
        }
        public virtual void Nhap()
        {
            Console.Write("Nhập mã nhân viên: ");
            maNhanVien = Console.ReadLine();

            Console.Write("Nhập tên nhân viên: ");
            tenNhanVien = Console.ReadLine();

            Console.Write("Nhập hệ số lương: ");
            heSoLuong = Convert.ToDouble(Console.ReadLine());
        }
    }

    class CBLanhDao : NhanVien_Bai4
    {
        private string chucVu;
        private int thamNienQuanLy;

        public CBLanhDao() : base()
        {
            maNhanVien = "NV009";
            tenNhanVien = "Dieu Hien";
            heSoLuong = 4.67;
            chucVu = "Giám đốc";
            thamNienQuanLy = 10;
        }

        public override double TinhThuNhap()
        {
            double luongCoBan = 1150;
            double phuCapLanhDao;

            if (chucVu == "Giam doc")
            {
                phuCapLanhDao = 1500 * 7.0;
            }
            else if (chucVu == "Truong phong")
            {
                phuCapLanhDao = 1500 * 6.0;
            }
            else if (chucVu == "Pho phong")
            {
                phuCapLanhDao = 1500 * 4.5;
            }
            else
            {
                phuCapLanhDao = 1500 * 1.0;
            }

            return heSoLuong * luongCoBan + phuCapLanhDao;
        }

        public void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Chức vụ: " + chucVu);
            Console.WriteLine("Thâm niên quản lý: " + thamNienQuanLy + " năm");
        }
        public override void Nhap()
        {
            base.Nhap();

            Console.Write("Nhập chức vụ: ");
            chucVu = Console.ReadLine();

            Console.Write("Nhập thâm niên quản lý (số năm): ");
            thamNienQuanLy = Convert.ToInt32(Console.ReadLine());
        }
    }
    class NhanVienThucTe : NhanVien_Bai4
    {
        public NhanVienThucTe(string maNV, string tenNV, double heSo) : base(maNV, tenNV, heSo)
        {
        }
        public NhanVienThucTe (){
            maNhanVien = "";
            tenNhanVien = "";
            heSoLuong = 2.34;
            }
        public override double TinhThuNhap()
        {
            double luongCoBan = 1150;
            return heSoLuong * luongCoBan;
        }
    }

}
