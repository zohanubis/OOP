using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public abstract class SanPham
    {
        private string maSanPham;
        private string tenSanPham;
        private int soLuong;
        private double donGia;
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia= value; }
        
        public SanPham()
        {
            MaSanPham = "SP01";
            TenSanPham = "Ghế lưới đa năng văn phòng";
            SoLuong = 0;
            DonGia = 0;
        }
        public SanPham(string maSanPham ="SP019", string tenSanPham = "Ghế họp thông thường")
        {
            MaSanPham = maSanPham;
            TenSanPham = tenSanPham;
            SoLuong = soLuong;
            DonGia = donGia;
        }
        public SanPham(SanPham sp)
        {
            MaSanPham = sp.MaSanPham;
            TenSanPham = sp.TenSanPham;
            SoLuong = sp.SoLuong;
            DonGia = sp.DonGia;
        }
        public abstract double TinhThue();
        public abstract double TinhQuangBaSanPham();
        public double TinhThanhTien()
        {
            double thue = TinhThue();
            double quangBa = TinhQuangBaSanPham();
            double thanhtien = DonGia * SoLuong;
            return thue + quangBa + thanhtien;
        }
        public double SoTienDongThue()
        {
            double soTienPhaiDong = TinhThanhTien() + TinhThue() * 0.1;
            return soTienPhaiDong;
        }
    }
}
