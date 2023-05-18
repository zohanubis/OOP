using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi6_Abstract
{

 abstract class HangHoa_Bai3
    {
        protected string maHang;
        protected string tenHang;

        public HangHoa_Bai3()
        {
            maHang = "";
            tenHang = "";
        }

        public HangHoa_Bai3(string maHang, string tenHang)
        {
            if (maHang.Length == 5 && maHang.Substring(0, 2) == "HH" && int.TryParse(maHang.Substring(2), out int number))
                this.maHang = maHang;
            else
                this.maHang = "HH001";

            this.tenHang = tenHang;
        }

        public void Xuat()
        {
            Console.WriteLine("Mã hàng: " + maHang);
            Console.WriteLine("Tên hàng: " + tenHang);
        }
        
    }

    class NuocGiaiKhat : HangHoa_Bai3
    {
        private string donViTinh;
        private int soLuong;
        private double donGia;
        public NuocGiaiKhat(string maHang, string tenHang, string donViTinh, int soLuong, double donGia)
            : base(maHang, tenHang)
        {
            if (donViTinh == "kết" || donViTinh == "thùng" || donViTinh == "chai" || donViTinh == "lon")
                this.donViTinh = donViTinh;
            else
                this.donViTinh = "kết";

            this.soLuong = soLuong;
            this.donGia = donGia;
        }
        public void NhapThongTin()
        {
            Console.Write("Nhập mã hàng: ");
            maHang = Console.ReadLine();

            Console.Write("Nhập tên hàng: ");
            tenHang = Console.ReadLine();

            Console.Write("Nhập đơn vị tính: ");
            donViTinh = Console.ReadLine();

            Console.Write("Nhập số lượng: ");
            soLuong = int.Parse(Console.ReadLine());

            Console.Write("Nhập đơn giá: ");
            donGia = double.Parse(Console.ReadLine());
        }
    
        public void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Đơn vị tính: " + donViTinh);
            Console.WriteLine("Số lượng: " + soLuong);
            Console.WriteLine("Đơn giá: " + donGia);
        }

        public double TinhTongTien(double tiLeChietKhau)
        {
            double thanhTien = 0;

            if (donViTinh == "kết" || donViTinh == "thùng")
                thanhTien = soLuong * donGia;
            else if (donViTinh == "chai")
                thanhTien = soLuong * donGia / 20;
            else if (donViTinh == "lon")
                thanhTien = soLuong * donGia / 24;

            double tongTien = thanhTien * tiLeChietKhau;
            return tongTien;
        }
        
    }
}

