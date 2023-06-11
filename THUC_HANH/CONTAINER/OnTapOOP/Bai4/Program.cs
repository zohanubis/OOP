using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    abstract class SanPham
    {
        private string maSP;
        private string tenSP;
        private string maLoaiSP;
        private string xuatXu;
        private double giaNhap;
        private double giaBan;
        private int soLuongTonKho;

        protected string MaSP {
            get => maSP;
            set
            {
                if (checkMaSP(value))
                    maSP = value;
                else
                    Console.WriteLine("Mã sản phẩm ko hợp lệ");
            }
        }
        private bool checkMaSP(string maSP)
        {
            if (maSP.Length != 6)
                return false;

            if (maSP.Substring(0, 2) != "SP")
                return false;

            if (!char.IsDigit(maSP[2]))
                return false;

            if (maSP[3] != 'L')
                return false;

            if (!char.IsDigit(maSP[4]) || !char.IsDigit(maSP[5]))
                return false;

            return true;
        }
        protected string TenSP { get => tenSP; set => tenSP = value; }
        protected string MaLoaiSP { get => maLoaiSP; set => maLoaiSP = value; }
        protected string XuatXu { get => xuatXu; set => xuatXu = value; }
        protected double GiaNhap
        {
            get => giaNhap;
            set
            {
                if (value > 0)
                    giaNhap = value;
                else
                    Console.WriteLine("Giá nhập phải lớn hơn 0!");
            }
        }
        protected double GiaBan
        {
            get => giaBan;
            set
            {
                if (value > giaNhap)
                    giaBan = value;
                else
                    Console.WriteLine("Giá bán phải lớn hơn giá nhập!");
            }
        }

        protected int SoLuongTonKho { get => soLuongTonKho; set => soLuongTonKho = value; }
        public SanPham()
        {
            MaSP = "SP2L40";
            TenSP = "Máy Tính";
            MaLoaiSP = "MT";
            XuatXu = "Malaysia";
            GiaNhap = 5000000;
            GiaBan = 7000000;
            SoLuongTonKho = 5;
        }

        public SanPham(string maSP, string tenSP, string maLoaiSP, string xuatXu, double giaNhap, double giaBan, int soLuongTonKho)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MaLoaiSP = maLoaiSP;
            XuatXu = xuatXu;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            SoLuongTonKho = soLuongTonKho;
        }
        public abstract double TinhLoiNhuan();

        public abstract double TinhThue();
        public static double HeSoThue()
        {
            double thue = 0.1;
            return thue;
        }
    }
    interface ITinhTroGia
    {
        double TinhTroGia();
    }
    interface ITinhPhi
    {
        double TinhPhi();
    }
    class SanPhamDienCo : SanPham, ITinhPhi
    {
        public int NamSanXuat { get; set; }

        public override double TinhLoiNhuan()
        {
            double tySoBienDong = NamSanXuat <= 2018 ? 0.8 : 0.9;
            double loiNhuan = (GiaBan - GiaNhap) * SoLuongTonKho - tySoBienDong;
            return loiNhuan;
        }

        public override double TinhThue()
        {
            double thue = GiaNhap * SoLuongTonKho * 0.1;
            return thue;
        }

        public double TinhPhi()
        {
            return 20000 * SoLuongTonKho;
        }
    }

    class SanPhamDienTu : SanPham, ITinhPhi
    {
        public int SoNamBaoHanh { get; set; }

        public override double TinhLoiNhuan()
        {
            double tySoBienDong = SoNamBaoHanh <= 2 ? 0.7 : 0.8;
            double loiNhuan = (GiaBan - GiaNhap) * SoLuongTonKho - tySoBienDong;
            return loiNhuan;
        }

        public override double TinhThue()
        {
            double thue = GiaNhap * SoLuongTonKho * 0.1;
            return thue;
        }

        public double TinhPhi()
        {
            return 12000 * SoLuongTonKho;
        }

    }
    class SanPhamMyNghe : SanPham, ITinhTroGia
    {
        public string VatLieu { get; set; }

        public override double TinhLoiNhuan()
        {
            double tySoBienDong = 0;
            if (VatLieu == "kim loại")
                tySoBienDong = 0.9;
            else if (VatLieu == "gỗ")
                tySoBienDong = 0.8;
            else
                tySoBienDong = 0.7;

            double loiNhuan = (GiaBan - GiaNhap) * SoLuongTonKho - tySoBienDong;
            return loiNhuan;
        }

        public override double TinhThue()
        {
            double thue = GiaNhap * SoLuongTonKho * 0.1;
            return thue;
        }

        public double TinhTroGia()
        {
            return 10000;
        }
    }

    class SanPhamLuongThuc : SanPham, ITinhTroGia
    {
        public string BaoBi { get; set; }

        public override double TinhLoiNhuan()
        {
            double tySoBienDong = BaoBi == "hút chân không" ? 0.85 : 0.75;
            double loiNhuan = (GiaBan - GiaNhap) * SoLuongTonKho - tySoBienDong;
            return loiNhuan;
        }

        public override double TinhThue()
        {
            double thue = GiaNhap * SoLuongTonKho * 0.1;
            return thue;
        }

        public double TinhTroGia()
        {
            return 15000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
