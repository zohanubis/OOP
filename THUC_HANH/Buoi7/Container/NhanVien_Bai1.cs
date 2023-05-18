using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6_Abstract
{
    public class NhanVien
    {
        private string ma;
        private string ten;
        private int namVL;
        private int soNgayNghi;
        private double heSoLuong;

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public int NamVL { get => namVL; set => namVL = value; }
        public int SoNgayNghi { get => soNgayNghi; set => soNgayNghi = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }

        public NhanVien()
        {
            Ma = "NV01";
            Ten = "Ho ten SV";
            NamVL = 2006;
            SoNgayNghi = 1;
            HeSoLuong = 3.0;
        }

        public NhanVien(string ma, string hoten, double heSoLuong)
        {
            Ma = ma;
            Ten = hoten;
            HeSoLuong = heSoLuong;
            NamVL = DateTime.Today.Year;
            SoNgayNghi = 0;
        }

        public NhanVien(string ma, string hoten, double heSoLuong, int nvl, int nghi)
        {
            this.Ma = ma;
            this.Ten = hoten;
            this.HeSoLuong = heSoLuong;
            this.NamVL = nvl;
            this.SoNgayNghi = nghi;
        }

        static int LuongCoBan = 1150;

        public double PhuCapThamNien()
        {
            int thamnien = DateTime.Today.Year - NamVL;
            if (thamnien >= 5)
                return thamnien * NhanVien.LuongCoBan / 100.0;
            return 0;
        }

        public char XepLoai()
        {
            if (SoNgayNghi <= 1) return 'A';
            if (SoNgayNghi <= 3) return 'B';
            return 'C';
        }

        public double Luong()
        {
            double hsThiDua = 0.5;
            char xl = XepLoai();
            if (xl == 'A') hsThiDua = 1.0;
            if (xl == 'B') hsThiDua = 0.75;
            return NhanVien.LuongCoBan * HeSoLuong * hsThiDua * PhuCapThamNien();
        }

        public void Nhap()
        {
            Console.Write("Nhập mã nhân viên: ");
            Ma = Console.ReadLine();

            Console.Write("Nhập tên nhân viên: ");
            Ten = Console.ReadLine();

            Console.Write("Nhập hệ số lương: ");
            HeSoLuong = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập năm vào làm: ");
            NamVL = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhập số ngày nghỉ: ");
            SoNgayNghi = Convert.ToInt32(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("Mã nhân viên: " + Ma);
            Console.WriteLine("Tên nhân viên: " + Ten);
            Console.WriteLine("Hệ số lương: " + HeSoLuong);
            Console.WriteLine("Thu nhập: " + Luong());
            Console.WriteLine("Xếp loại: " + XepLoai());
        }
    }
}
