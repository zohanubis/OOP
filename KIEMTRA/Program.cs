using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace CongTyBanHang
{
    public abstract class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }

        public abstract decimal TinhThanhTien();

        public virtual void NhapThongTin()
        {
            Console.WriteLine("Nhập mã khách hàng: ");
            MaKhachHang = Console.ReadLine();
            Console.WriteLine("Nhập tên khách hàng: ");
            TenKhachHang = Console.ReadLine();
            Console.WriteLine("Nhập số lượng: ");
            SoLuong = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhập giá bán: ");
            GiaBan = Convert.ToDecimal(Console.ReadLine());
        }

        public virtual void XuatThongTin()
        {
            Console.WriteLine("Mã khách hàng: " + MaKhachHang);
            Console.WriteLine("Tên khách hàng: " + TenKhachHang);
            Console.WriteLine("Số lượng: " + SoLuong);
            Console.WriteLine("Giá bán: " + GiaBan);
            Console.WriteLine("Thành tiền: " + TinhThanhTien());
        }
    }

    public class KhachHangCaNhan : KhachHang
    {
        public int KhoangCachGiaoHang { get; set; }

        public override decimal TinhThanhTien()
        {
            decimal thanhTien = SoLuong * GiaBan - TinhChietKhau() + TinhVat();
            return thanhTien;
        }

        private decimal TinhChietKhau()
        {
            decimal chietKhau = 0;
            if (SoLuong >= 5)
            {
                chietKhau = 0.03m * GiaBan * SoLuong;
                if (KhoangCachGiaoHang < 10)
                {
                    chietKhau += 20000 * SoLuong;
                }
            }
            return chietKhau;
        }

        private decimal TinhVat()
        {
            decimal vat = 0.1m * GiaBan * SoLuong;
            return vat;
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.WriteLine("Nhập khoảng cách giao hàng: ");
            KhoangCachGiaoHang = Convert.ToInt32(Console.ReadLine());
        }

        public override void XuatThongTin()
        {
            Console.WriteLine("Loại khách hàng: Khách hàng cá nhân");
            base.XuatThongTin();
            Console.WriteLine("Khoảng cách giao hàng: " + KhoangCachGiaoHang);
        }
    }

    public class DaiLyCap1 : KhachHang
    {
        public int ThoiGianHopTac { get; set; }

        public override decimal TinhThanhTien()
        {
            decimal thanhTien = SoLuong * GiaBan - TinhChietKhau() + TinhVat();
            return thanhTien;
        }

        private decimal TinhChietKhau()
        {
            decimal chietKhau = 0.3m * GiaBan * SoLuong;
            if (ThoiGianHopTac > 3)
            {
                int soNamVuotDinhMuc = ThoiGianHopTac - 3;
                decimal chietKhauThem = Math.Min(soNamVuotDinhMuc, 35) * 0.01m * GiaBan * SoLuong;
                chietKhau += chietKhauThem;
            }
            return chietKhau;
        }

        private decimal TinhVat()
        {
            decimal vat = 0.1m * GiaBan * SoLuong;
            return vat;
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.WriteLine("Nhập thời gian hợp tác (số năm): ");
            ThoiGianHopTac = Convert.ToInt32(Console.ReadLine());
        }

        public override void XuatThongTin()
        {
            Console.WriteLine("Loại khách hàng: Đại lý cấp 1");
            base.XuatThongTin();
            Console.WriteLine("Thời gian hợp tác: " + ThoiGianHopTac + " năm");
        }
    }

    public class KhachHangCongTy : KhachHang
    {
        public int SoLuongNhanVien { get; set; }

        public override decimal TinhThanhTien()
        {
            decimal thanhTien = SoLuong * GiaBan - TinhChietKhau() + TinhVat();
            return thanhTien;
        }

        private decimal TinhChietKhau()
        {
            decimal chietKhau = 0;
            if (SoLuongNhanVien > 1000)
            {
                chietKhau = 0.03m * GiaBan * SoLuong;
            }
            if (SoLuongNhanVien > 5000)
            {
                chietKhau = 0.05m * GiaBan * SoLuong;
            }
            return chietKhau;
        }

        private decimal TinhVat()
        {
            decimal vat = 0.1m * GiaBan * SoLuong;
            return vat;
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.WriteLine("Nhập số lượng nhân viên: ");
            SoLuongNhanVien = Convert.ToInt32(Console.ReadLine());
        }

        public override void XuatThongTin()
        {
            Console.WriteLine("Loại khách hàng: Khách hàng công ty");
            base.XuatThongTin();
            Console.WriteLine("Số lượng nhân viên: " + SoLuongNhanVien);
        }
    }

    public class CongTy
    {
        public string TenCongTy { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public List<KhachHang> DanhSachHoaDon { get; set; }

        public CongTy()
        {
            DanhSachHoaDon = new List<KhachHang>();
        }
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load("data.xml");

            XmlNode congTyNode = read.SelectSingleNode("/HoTenSinhVien");
            string tenCongTy = congTyNode.SelectSingleNode("TenCT").InnerText;
            string soDienThoai = congTyNode.SelectSingleNode("SoDT").InnerText;
            string diaChi = congTyNode.SelectSingleNode("DiaChi").InnerText;

            CongTy congTy = new CongTy
            {
                TenCongTy = tenCongTy,
                SoDienThoai = soDienThoai,
                DiaChi = diaChi
            };

            XmlNodeList hoaDonNodes = read.SelectNodes("/HoTenSinhVien/DS/HoaDon");

            foreach (XmlNode hoaDonNode in hoaDonNodes)
            {
                int loaiKhachHang = Convert.ToInt32(hoaDonNode.SelectSingleNode("Loai").InnerText);

                KhachHang khachHang;
                switch (loaiKhachHang)
                {
                    case 1:
                        khachHang = new KhachHangCaNhan();
                        break;
                    case 2:
                        khachHang = new DaiLyCap1();
                        break;
                    case 3:
                        khachHang = new KhachHangCongTy();
                        break;
                    default:
                        khachHang = null;
                        break;
                }

                if (khachHang != null)
                {
                    khachHang.MaKhachHang = hoaDonNode.SelectSingleNode("Ma").InnerText;
                    khachHang.TenKhachHang = hoaDonNode.SelectSingleNode("Ten").InnerText;
                    khachHang.SoLuong = Convert.ToInt32(hoaDonNode.SelectSingleNode("SoLuong").InnerText);
                    khachHang.GiaBan = Convert.ToDecimal(hoaDonNode.SelectSingleNode("GiaBan").InnerText);

                    if (khachHang is KhachHangCaNhan)
                    {
                        ((KhachHangCaNhan)khachHang).KhoangCachGiaoHang = Convert.ToInt32(hoaDonNode.SelectSingleNode("KhoangCach").InnerText);
                    }
                    else if (khachHang is DaiLyCap1)
                    {
                        ((DaiLyCap1)khachHang).ThoiGianHopTac = Convert.ToInt32(hoaDonNode.SelectSingleNode("ThoiGianHopTac").InnerText);
                    }
                    else if (khachHang is KhachHangCongTy)
                    {
                        ((KhachHangCongTy)khachHang).SoLuongNhanVien = Convert.ToInt32(hoaDonNode.SelectSingleNode("SoLuongNhanVien").InnerText);
                    }

                    congTy.ThemHoaDon(khachHang);
                }
            }

            congTy.XuatDanhSachHoaDon();
        }
        public void ThemHoaDon(KhachHang hoaDon)
        {
            DanhSachHoaDon.Add(hoaDon);
        }

        public void XuatDanhSachHoaDon()
        {
            Console.WriteLine("Tên công ty: " + TenCongTy);
            Console.WriteLine("Số điện thoại: " + SoDienThoai);
            Console.WriteLine("Địa chỉ: " + DiaChi);
            Console.WriteLine("Danh sách hóa đơn:");
            foreach (var hoaDon in DanhSachHoaDon)
            {
                hoaDon.XuatThongTin();
                Console.WriteLine("-------------------------");
            }
        }
        public decimal TinhTongThanhTien()
        {
            decimal tongThanhTien = 0;
            foreach (KhachHang hoaDon in DanhSachHoaDon)
            {
                tongThanhTien += hoaDon.TinhThanhTien();
            }
            return tongThanhTien;
        }

        public KhachHang TimKhachHangMuaNhieuNhat()
        {
            KhachHang khachHangMuaNhieuNhat = null;
            int soLuongMax = 0;
            foreach (KhachHang hoaDon in DanhSachHoaDon)
            {
                if (hoaDon.SoLuong > soLuongMax)
                {
                    khachHangMuaNhieuNhat = hoaDon;
                    soLuongMax = hoaDon.SoLuong;
                }
            }
            return khachHangMuaNhieuNhat;
        }

        //public decimal TongChietKhauCongTy()
        //{
        //    decimal tongChietKhau = 0;
        //    foreach (KhachHang hoaDon in DanhSachHoaDon)
        //    {
        //        if (hoaDon is KhachHangCongTy)
        //        {
        //            KhachHangCongTy khachHangCongTy = hoaDon as KhachHangCongTy;
        //            tongChietKhau += khachHangCongTy.TinhChietKhau();
        //        }
        //    }
        //    return tongChietKhau;
        //}


        public void InDanhSachDaiLyCap1()
        {
            Console.WriteLine("Danh sách khách hàng là đại lý cấp 1:");
            foreach (KhachHang hoaDon in DanhSachHoaDon)
            {
                if (hoaDon is DaiLyCap1)
                {
                    DaiLyCap1 daiLyCap1 = hoaDon as DaiLyCap1;
                    daiLyCap1.XuatThongTin();
                    Console.WriteLine("-------------------------");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding= Encoding.UTF8;
            CongTy congTy = new CongTy();

            // Gọi phương thức Input để nhập dữ liệu từ tệp tin
            congTy.Input("data.xml");

            // In ra danh sách hóa đơn
            congTy.XuatDanhSachHoaDon();

            // Tính tổng thành tiền của tất cả hóa đơn
            decimal tongThanhTien = congTy.TinhTongThanhTien();
            Console.WriteLine("Tổng thành tiền: " + tongThanhTien);

            // Tìm khách hàng mua nhiều nhất
            //KhachHang khachHangMuaNhieuNhat = congTy.TimKhachHangMuaNhieuNhat();
            //Console.WriteLine("Khách hàng mua nhiều nhất:");
            //khachHangMuaNhieuNhat.XuatThongTin();

            // Tính tổng chiết khấu của khách hàng công ty
            //decimal tongChietKhauCongTy = congTy.TongChietKhauCongTy();
            //Console.WriteLine("Tổng chiết khấu của khách hàng công ty: " + tongChietKhauCongTy);

            // In danh sách đại lý cấp 1
            congTy.InDanhSachDaiLyCap1();

            Console.ReadLine();
        }
    }
}
