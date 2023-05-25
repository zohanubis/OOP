using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai2
{
    public class NhanVienKinhDoanh : NhanVien, IXepLoaiThiDua
    {
        private double doanhSoBanHang;
        public double DoanhSoBanHang { get => doanhSoBanHang; set => doanhSoBanHang = value; }

        public NhanVienKinhDoanh(string maNV, string tenNV, int namSinh, string gioiTinh, double heSoLuong, int namVaoLam, double doanhSoBanHang)
            : base(maNV, tenNV, namSinh, gioiTinh, heSoLuong, namVaoLam)
        {
            DoanhSoBanHang = doanhSoBanHang;
        }
        public override double TinhLuong()
        {
            double hoaHong = 0.15 * DoanhSoBanHang * 500;
            double luong = HeSoLuong * 1210 + hoaHong;

            return luong;
        }

        public string XepLoaiThiDua()
        {
            double doanhSoToiThieu = 1000;
            if (DoanhSoBanHang >= 2.0 * doanhSoToiThieu)
                return "A";
            else if (DoanhSoBanHang >= doanhSoToiThieu)
                return "B";
            else if (DoanhSoBanHang >= 0.5 * doanhSoToiThieu)
                return "C";
            else
                return "D";
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Doanh số bán hàng: " + DoanhSoBanHang);
            Console.WriteLine("Xếp loại: " + XepLoaiThiDua());
            double hoaHong = 0.15 * DoanhSoBanHang * 500;
            Console.WriteLine("Hoa hồng: " + hoaHong);
        }

    }
}
