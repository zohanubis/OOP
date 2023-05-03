using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap1
{
    class SanPham
    {
        private string maSanPham;
        private string tenSanPham;
        private int namSanXuat;
        private double donGia;
        private char loaiSanPham;
        private int soLuongBan;
        public string MaSanPham
        {
            get { return maSanPham; }
            set
            {
                if (value.StartsWith("SP") && value.Length == 6)
                    maSanPham = value;
                else
                    maSanPham = "SP0001";
            }
        }
        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }
        public int NamSanXuat
        {
            get { return namSanXuat; }
            set { namSanXuat = value; }
        }
        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        public char LoaiSanPham
        {
            get { return loaiSanPham; }
            set { loaiSanPham = value; }
        }
        public int SoLuongBan
        {
            get { return soLuongBan; }
            set { soLuongBan = value; }
        }
        public SanPham()
        {
            MaSanPham = "SP0003";
            TenSanPham = "Xe Toyota Camry";
            NamSanXuat = 2021;
            DonGia = 30000;
            LoaiSanPham = 'A';
        }
        public SanPham(string maSanPham, string tenSanPham,int namSanXuat, double donGia, char loaiSanPham)
        {
            this.MaSanPham = maSanPham;
            this.TenSanPham = tenSanPham;
            this.NamSanXuat = namSanXuat;
            this.DonGia = donGia;
            this.LoaiSanPham = loaiSanPham;
        }
        public double TinhTien(int sl)
        {
              
            double thue = 0.1;
            double thanhtien = sl * DonGia * (1 + thue);
            return thanhtien; 
        }
        public void XuatThongTin()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Mã sản phẩm: {0}", MaSanPham);
            Console.WriteLine("Tên sản phẩm: {0}", TenSanPham);
            Console.WriteLine("Năm sản xuất: {0}", NamSanXuat);
            Console.WriteLine("Đơn giá: {0}", DonGia);
            Console.WriteLine("Loại sản phẩm: {0}", LoaiSanPham);
            Console.WriteLine("Số lượng bán được : {0}", soLuongBan);
            
        }
        public int DemSoLuongBan()
        {
            Random rd = new Random();
            int sl = rd.Next(1, 100);
            SoLuongBan = sl;
            return sl;
        }
    }

}
