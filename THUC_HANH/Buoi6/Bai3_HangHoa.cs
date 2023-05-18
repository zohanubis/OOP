using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6_PhamHoDangHuy_2001215828
{
    using System;


    class HangHoa
    {
        protected string maHang;
        protected string tenHang;

 
        public HangHoa()
        {
            maHang = "";
            tenHang = "";
        }

   
        public HangHoa(string maHang)
        {
            if (IsValidMaHang(maHang))
                this.maHang = maHang;
            else
                this.maHang = "HH001";

            tenHang = "";
        }


        private bool IsValidMaHang(string maHang)
        {
            if (maHang.Length == 5 && maHang.Substring(0, 2) == "HH")
            {
                string soHang = maHang.Substring(2);
                int so;
                if (int.TryParse(soHang, out so))
                    return true;
            }

            return false;
        }


        public void Xuat()
        {
            Console.WriteLine("Mã hàng: " + maHang);
            Console.WriteLine("Tên hàng: " + tenHang);
        }
    }


    class NuocGiaiKhat : HangHoa
    {
        private string donViTinh;
        private int soLuong;
        private double donGia;
        private double tiLeChietKhau = 0.9; 


        public NuocGiaiKhat(string maHang, string donViTinh, int soLuong, double donGia)
            : base(maHang)
        {
            if (IsValidDonViTinh(donViTinh))
                this.donViTinh = donViTinh;
            else
                this.donViTinh = "kết";

            this.soLuong = soLuong;
            this.donGia = donGia;
        }

     
        private bool IsValidDonViTinh(string donViTinh)
        {
            return donViTinh == "kết" || donViTinh == "thùng" || donViTinh == "chai" || donViTinh == "lon";
        }


        public new void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Đơn vị tính: " + donViTinh);
            Console.WriteLine("Số lượng: " + soLuong);
            Console.WriteLine("Đơn giá: " + donGia);
        }

        
        public double TinhTongTien()
        {
            double thanhTien;

            if (donViTinh == "kết" || donViTinh == "thùng")
            {
                thanhTien = soLuong * donGia;
            }
            else if (donViTinh == "chai")
            {
                thanhTien = soLuong * donGia / 20;
            }
            else if (donViTinh == "lon")
            {
                thanhTien = soLuong * donGia / 24;
            }
            else
            {
                thanhTien = 0;
            }

            return thanhTien * tiLeChietKhau;
        }
    }


}
