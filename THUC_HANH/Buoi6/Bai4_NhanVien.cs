using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6_PhamHoDangHuy_2001215828
{
    using System;

    class NhanVien
    {
        protected string maNhanVien;
        protected string tenNhanVien;
        protected double heSoLuong;
        protected double luongCoBan = 1150;

 
        public NhanVien()
        {
            maNhanVien = "NV001";
            tenNhanVien = "Họ Tên";
            heSoLuong = 2.34;
        }

    
        public NhanVien(string maNhanVien)
        {
            if (IsValidMaNhanVien(maNhanVien))
                this.maNhanVien = maNhanVien;
            else
                this.maNhanVien = "NV001";

            tenNhanVien = "Họ Tên";
            heSoLuong = 2.34;
        }

     
        private bool IsValidMaNhanVien(string maNhanVien)
        {
            return maNhanVien.Length == 5 && maNhanVien.Substring(0, 2) == "NV";
        }

        public double TinhThuNhap()
        {
            return heSoLuong * luongCoBan;
        }

   
        public void Xuat()
        {
            Console.WriteLine("Mã nhân viên: " + maNhanVien);
            Console.WriteLine("Tên nhân viên: " + tenNhanVien);
            Console.WriteLine("Hệ số lương: " + heSoLuong);
            Console.WriteLine("Thu nhập: " + TinhThuNhap());
        }
    }

 
    class CBLanhDao : NhanVien
    {
        private string chucVu;
        private int thamNienQuanLy;


        public CBLanhDao()
        {
            maNhanVien = "NV009";
            tenNhanVien = "Dieu Hien";
            heSoLuong = 4.67;
            chucVu = "Giám đốc";
            thamNienQuanLy = 10;
        }

    
        public new double TinhThuNhap()
        {
            double thuNhap = base.TinhThuNhap();

            double phuCapLanhDao;
            if (chucVu == "Giám đốc")
                phuCapLanhDao = 1500 * 7.0;
            else if (chucVu == "Trưởng phòng")
                phuCapLanhDao = 1500 * 6.0;
            else if (chucVu == "Phó phòng")
                phuCapLanhDao = 1500 * 4.5;
            else
                phuCapLanhDao = 1500 * 1.0;

            return thuNhap + phuCapLanhDao;
        }

     
        public new void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Chức vụ: " + chucVu);
        }
    }
}
