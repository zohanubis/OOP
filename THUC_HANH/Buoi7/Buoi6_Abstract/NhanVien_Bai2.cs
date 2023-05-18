using System;

namespace Buoi6_Abstract
{
    public abstract class NhanVien_Bai2
    {
        protected string ma;
        protected string ten;
        protected int namVL;
        protected int soNgayNghi;
        protected double heSoLuong;

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public int NamVL { get => namVL; set => namVL = value; }
        public int SoNgayNghi { get => soNgayNghi; set => soNgayNghi = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }

        public NhanVien_Bai2()
        {
            Ma = "NV01";
            Ten = "Ho ten SV";
            NamVL = 2006;
            SoNgayNghi = 1;
            HeSoLuong = 3.0;
        }

        public NhanVien_Bai2(string ma, string hoten, double heSoLuong)
        {
            Ma = ma;
            Ten = hoten;
            HeSoLuong = heSoLuong;
            NamVL = DateTime.Today.Year;
            SoNgayNghi = 0;
        }

        public NhanVien_Bai2(string ma, string hoten, double heSoLuong, int nvl, int nghi)
        {
            this.Ma = ma;
            this.Ten = hoten;
            this.HeSoLuong = heSoLuong;
            this.NamVL = nvl;
            this.SoNgayNghi = nghi;
        }

        protected static int LuongCoBan = 1150;

        public abstract double PhuCapThamNien();

        public abstract char XepLoai();

        public abstract double Luong();

        public abstract void Nhap();

        public abstract void Xuat();
        public virtual void NhapNV()
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
        public virtual void XuatNV()
        {
            Console.WriteLine("Mã nhân viên: " + Ma);
            Console.WriteLine("Tên nhân viên: " + Ten);
            Console.WriteLine("Hệ số lương: " + HeSoLuong);
            Console.WriteLine("Thu nhập: " + Luong());
            Console.WriteLine("Xếp loại: " + XepLoai());
        }
    }

    public class CanBo : NhanVien_Bai2
    {
        private string chucVu;
        private string phongBan;
        private double heSoLanhDao;

        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string PhongBan { get => phongBan; set => phongBan = value; }
        public double HeSoLanhDao { get => heSoLanhDao; set => heSoLanhDao = value; }

        public CanBo() : base()
        {
            ChucVu = "Truong phong";
            PhongBan = "Phong hanh chinh";
            HeSoLanhDao = 5.0;
        }

        public CanBo(string ma, string ten, double heSoLuong, string chucVu, string phongBan, double heSoLanhDao)
            : base(ma, ten, heSoLuong)
        {
            ChucVu = chucVu;
            PhongBan = phongBan;
            HeSoLanhDao = heSoLanhDao;
            SoNgayNghi = 1;
        }

        public CanBo(string ma, string ten, double heSoLuong, int nvl, int nghi, string chucVu, string phongBan, double heSoLanhDao)
            : base(ma, ten, heSoLuong, nvl, nghi)
        {
            ChucVu = chucVu;
            PhongBan = phongBan;
            HeSoLanhDao = heSoLanhDao;
        }

        public override double PhuCapThamNien()
        {
            int thamnien = DateTime.Today.Year - NamVL;
            if (thamnien >= 5)
                return thamnien * NhanVien_Bai2.LuongCoBan / 100.0;
            return 0;
        }

        public override char XepLoai()
        {
            return 'A';
        }

        public override double Luong()
        {
            double hsThiDua = 1.0;
            return NhanVien_Bai2.LuongCoBan * HeSoLuong * hsThiDua + PhuCapThamNien();
        }
        public override void Nhap()
        {
            base.NhapNV();
            Console.Write("Nhập chức vụ: ");
            ChucVu = Console.ReadLine();

            Console.Write("Nhập phòng ban: ");
            PhongBan = Console.ReadLine();

            Console.Write("Nhập hệ số lãnh đạo: ");
            HeSoLanhDao = Convert.ToDouble(Console.ReadLine());
        }


        public override void Xuat()
        {
            base.XuatNV();
            Console.WriteLine("Chức vụ: " + ChucVu);
            Console.WriteLine("Phòng ban: " + PhongBan);
        }
    }
}
