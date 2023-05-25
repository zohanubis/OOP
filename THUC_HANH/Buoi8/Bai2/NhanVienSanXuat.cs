using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai2
{
    public class NhanVienSanXuat : NhanVien, IXepLoaiThiDua
    {
        private int soNgayNghi;
        public int SoNgayNghi { get => soNgayNghi; set => soNgayNghi = value; }
        public NhanVienSanXuat(string maNV, string tenNV, int namSinh, string gioiTinh, double heSoLuong, int namVaoLam, int soNgayNghi)
            : base(maNV, tenNV, namSinh, gioiTinh, heSoLuong, namVaoLam)
        {
            SoNgayNghi = soNgayNghi;
        }
        public override double TinhLuong()
        {
            double phuCapNangNhoc = 0.1 * HeSoLuong * 1210;
            double luong = HeSoLuong * 1210 * (1 + phuCapNangNhoc);

            return luong;
        }

        public string XepLoaiThiDua()
        {
            if (SoNgayNghi <= 1)
                return "A";
            else if (SoNgayNghi <= 3)
                return "B";
            else if (SoNgayNghi <= 5)
                return "C";
            else
                return "D";
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Số ngày nghỉ: " + SoNgayNghi);
            Console.WriteLine("Xếp loại: " + XepLoaiThiDua());
            double phuCapNangNhoc = 0.1 * HeSoLuong * 1210;
            Console.WriteLine("Phụ cấp : " + phuCapNangNhoc);
        }


    }
}
