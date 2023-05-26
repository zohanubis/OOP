using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class NhanVienHanhChinh : NhanVien
    {
        private int soLanViPham;

        public int SoLanViPham {
            get => soLanViPham;
            set => soLanViPham = value;
        }
        public NhanVienHanhChinh(){
            SoLanViPham = 0;
        }
        public NhanVienHanhChinh(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, 
            DateTime ngayVaoLam, int soLanViPham) : base (maNhanVien, hoTen,ngaySinh, heSoLuong, ngayVaoLam)
        {
            SoLanViPham = soLanViPham;
        }
        public override double TinhLuong()
        {
            double luongHanhChinh = LuongCoBan() * HeSoLuong - SoLanViPham * 50;
            return luongHanhChinh;
        }
    }
}
