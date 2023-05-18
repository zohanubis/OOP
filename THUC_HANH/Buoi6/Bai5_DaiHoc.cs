using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi6_PhamHoDangHuy_2001215828
{
    using System;

    class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        public Nguoi()
        {
            GioiTinh = "nam";
        }

        public Nguoi(string gioiTinh)
        {
            if (gioiTinh.ToLower() == "nam" || gioiTinh.ToLower() == "nữ")
                GioiTinh = gioiTinh.ToLower();
            else
                GioiTinh = "nam";
        }

        public void Xuat()
        {
            Console.WriteLine("Họ tên: " + HoTen);
            Console.WriteLine("Ngày sinh: " + NgaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Giới tính: " + GioiTinh);
        }
    }

    class SinhVien : Nguoi
    {
        public string MaSV { get; set; }
        public string HeDaoTao { get; set; }
        public int TongSoTinChi { get; set; }

        public SinhVien(string maSV, string heDaoTao)
        {
            MaSV = maSV;
            HeDaoTao = heDaoTao;

            switch (heDaoTao.ToLower())
            {
                case "đại học":
                    TongSoTinChi = 150;
                    break;
                case "cao đẳng":
                    TongSoTinChi = 100;
                    break;
                case "cao đẳng nghề":
                    TongSoTinChi = 130;
                    break;
                default:
                    HeDaoTao = "đại học";
                    TongSoTinChi = 150;
                    break;
            }
        }

        public void XuatSinhVien()
        {
            Xuat();
            Console.WriteLine("Mã số sinh viên: " + MaSV);
            Console.WriteLine("Hệ đào tạo: " + HeDaoTao);
            Console.WriteLine("Tổng số tín chỉ: " + TongSoTinChi);
        }

        public double TinhTongHocPhi()
        {
            double hocPhiTinChi;

            switch (HeDaoTao.ToLower())
            {
                case "đại học":
                    hocPhiTinChi = 200000;
                    break;
                case "cao đẳng":
                    hocPhiTinChi = 150000;
                    break;
                case "cao đẳng nghề":
                    hocPhiTinChi = 120000;
                    break;
                default:
                    hocPhiTinChi = 200000;
                    break;
            }

            return TongSoTinChi * hocPhiTinChi;
        }
    }

}
