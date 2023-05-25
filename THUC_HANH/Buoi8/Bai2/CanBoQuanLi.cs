using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai2
{
    public class CanBoQuanLy : NhanVien
    {
        private string chucVu;
        private double heSoPhuCapChucVu;

        public string ChucVu { get => chucVu; set => chucVu = value; }
        public double HeSoPhuCapChucVu { get => heSoPhuCapChucVu; set => heSoPhuCapChucVu = value; }

        public CanBoQuanLy(string maNV, string tenNV, int namSinh, string gioiTinh, double heSoLuong, int namVaoLam, string chucVu, double heSoPhuCapChucVu)
            : base(maNV, tenNV, namSinh, gioiTinh, heSoLuong, namVaoLam)
        {
            ChucVu = chucVu;
            HeSoPhuCapChucVu = heSoPhuCapChucVu;
        }

        public override double TinhLuong()
        {
            double phuCapChucVu = HeSoPhuCapChucVu * 1100;
            double luong = HeSoLuong * 1210 + phuCapChucVu;

            return luong;
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Chức vụ: " + ChucVu);
            double phuCapChucVu = HeSoPhuCapChucVu * 1100;
            Console.WriteLine("Hệ số phụ cấp chức vụ: " + phuCapChucVu);
        }

    }
}
