using System;
using System.Collections.Generic;
using System.Xml;

namespace ABCCompany
{
    // Interface IKhachHang
    public interface IKhachHang
    {
        decimal TinhChietKhau();
    }

    // Lớp HoaDon
    public class HoaDon
    {
        public string MaKhachHang;
        public string TenKhachHang;
        public int SoLuong;
        public decimal GiaBan;
        public decimal ThanhTien;

        public HoaDon() { }

        public HoaDon(string maKhachHang, string tenKhachHang, int soLuong, decimal giaBan)
        {
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            SoLuong = soLuong;
            GiaBan = giaBan;
            ThanhTien = 0;
        }

        public virtual void TinhThanhTien()
        {
            decimal chietKhau = 0; // Chiết khấu cần tính
            decimal vat = (SoLuong * GiaBan) * 0.1m; // Thuế VAT
            ThanhTien = (SoLuong * GiaBan) - chietKhau + vat;
        }
    }

    // Lớp KhachHangCaNhan
    public class KhachHangCaNhan : HoaDon, IKhachHang
    {
        public int KhoangCachGiaoHang { get; set; }

        public KhachHangCaNhan() : base() { }

        public KhachHangCaNhan(string maKhachHang, string tenKhachHang, int soLuong, decimal giaBan, int khoangCachGiaoHang)
            : base(maKhachHang, tenKhachHang, soLuong, giaBan)
        {
            KhoangCachGiaoHang = khoangCachGiaoHang;
        }

        public override void TinhThanhTien()
        {
            decimal chietKhau = SoLuong < 5 ? 0 : GiaBan * SoLuong * 0.03m;
            if (KhoangCachGiaoHang < 10)
            {
                chietKhau += 20000 * SoLuong;
            }
            decimal vat = (SoLuong * GiaBan) * 0.1m;
            ThanhTien = (SoLuong * GiaBan) - chietKhau + vat;
        }

        public decimal TinhChietKhau()
        {
            decimal chietKhau = SoLuong < 5 ? 0 : GiaBan * SoLuong * 0.03m;
            if (KhoangCachGiaoHang < 10)
            {
                chietKhau += 20000 * SoLuong;
            }
            return chietKhau;
        }
    }

    // Lớp DaiLyCap1
    public class DaiLyCap1 : HoaDon, IKhachHang
    {
        public int ThoiGianHopTac { get; set; }

        public DaiLyCap1() : base() { }

        public DaiLyCap1(string maKhachHang, string tenKhachHang, int soLuong, decimal giaBan, int thoiGianHopTac)
            : base(maKhachHang, tenKhachHang, soLuong, giaBan)
        {
            ThoiGianHopTac = thoiGianHopTac;
        }

        public override void TinhThanhTien()
        {
            decimal chietKhau = GiaBan * SoLuong * 0.3m;
            if (ThoiGianHopTac > 3)
            {
                int additionalDiscount = Math.Min(ThoiGianHopTac - 3, 35);
                chietKhau += GiaBan * SoLuong * (additionalDiscount / 100m);
            }
            decimal vat = (SoLuong * GiaBan) * 0.1m;
            ThanhTien = (SoLuong * GiaBan) - chietKhau + vat;
        }

        public decimal TinhChietKhau()
        {
            decimal chietKhau = GiaBan * SoLuong * 0.3m;
            if (ThoiGianHopTac > 3)
            {
                int additionalDiscount = Math.Min(ThoiGianHopTac - 3, 35);
                chietKhau += GiaBan * SoLuong * (additionalDiscount / 100m);
            }
            return chietKhau;
        }
    }

    // Lớp KhachHangCongTy
    public class KhachHangCongTy : HoaDon, IKhachHang
    {
        public int SoLuongNhanVien { get; set; }

        public KhachHangCongTy() : base() { }

        public KhachHangCongTy(string maKhachHang, string tenKhachHang, int soLuong, decimal giaBan, int soLuongNhanVien)
            : base(maKhachHang, tenKhachHang, soLuong, giaBan)
        {
            SoLuongNhanVien = soLuongNhanVien;
        }

        public override void TinhThanhTien()
        {
            decimal chietKhau = SoLuongNhanVien > 5000 ? GiaBan * SoLuong * 0.05m : SoLuongNhanVien > 1000 ? GiaBan * SoLuong * 0.03m : 0;
            decimal vat = (SoLuong * GiaBan) * 0.1m;
            ThanhTien = (SoLuong * GiaBan) - chietKhau + vat;
        }

        public decimal TinhChietKhau()
        {
            decimal chietKhau = SoLuongNhanVien > 5000 ? GiaBan * SoLuong * 0.05m : SoLuongNhanVien > 1000 ? GiaBan * SoLuong * 0.03m : 0;
            return chietKhau;
        }
    }

    // Lớp CongTyABC
    public class CongTyABC
    {
        public string TenCongTy { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public List<HoaDon> DanhSachHoaDon { get; set; }

        public CongTyABC()
        {
            DanhSachHoaDon = new List<HoaDon>();
        }

        public void ThemHoaDon(HoaDon hoaDon)
        {
            DanhSachHoaDon.Add(hoaDon);
        }

        public decimal TinhTongThanhTien()
        {
            decimal tongThanhTien = 0;
            foreach (HoaDon hoaDon in DanhSachHoaDon)
            {
                hoaDon.TinhThanhTien();
                tongThanhTien += hoaDon.ThanhTien;
            }
            return tongThanhTien;
        }

        public HoaDon TimKhachHangMuaNhieuNhat()
        {
            HoaDon khachHangMuaNhieuNhat = null;
            int maxSoLuong = 0;
            foreach (HoaDon hoaDon in DanhSachHoaDon)
            {
                if (hoaDon.SoLuong > maxSoLuong)
                {
                    maxSoLuong = hoaDon.SoLuong;
                    khachHangMuaNhieuNhat = hoaDon;
                }
            }
            return khachHangMuaNhieuNhat;
        }

        public decimal TinhTongChietKhauCongTy()
        {
            decimal tongChietKhau = 0;
            foreach (HoaDon hoaDon in DanhSachHoaDon)
            {
                if (hoaDon is KhachHangCongTy)
                {
                    KhachHangCongTy khachHangCongTy = hoaDon as KhachHangCongTy;
                    tongChietKhau += khachHangCongTy.TinhChietKhau();
                }
            }
            return tongChietKhau;
        }

        public List<DaiLyCap1> TimDaiLyCap1()
        {
            List<DaiLyCap1> danhSachDaiLyCap1 = new List<DaiLyCap1>();
            foreach (HoaDon hoaDon in DanhSachHoaDon)
            {
                if (hoaDon is DaiLyCap1)
                {
                    DaiLyCap1 daiLyCap1 = hoaDon as DaiLyCap1;
                    danhSachDaiLyCap1.Add(daiLyCap1);
                }
            }
            return danhSachDaiLyCap1;
        }
    }

    // Lớp chứa phương thức chính để chạy chương trình
    public class Program
    {
        public static void Main(string[] args)
        {
            CongTyABC congTy = new CongTyABC();
            // Thực hiện đọc dữ liệu từ file XML và thêm vào danh sách hóa đơn của công ty
            DocDuLieuTuFileXML(congTy);

            // Tính tổng thành tiền của tất cả các hóa đơn
            decimal tongThanhTien = congTy.TinhTongThanhTien();
            Console.WriteLine("Tổng thành tiền của tất cả các hóa đơn: " + tongThanhTien);

            // Tìm khách hàng có số lượng mua nhiều nhất
            HoaDon khachHangMuaNhieuNhat = congTy.TimKhachHangMuaNhieuNhat();
            if (khachHangMuaNhieuNhat != null)
            {
                Console.WriteLine("Khách hàng mua nhiều nhất là: " + khachHangMuaNhieuNhat.TenKhachHang);
            }
            else
            {
                Console.WriteLine("Không có khách hàng nào.");
            }

            // Tính tổng chiết khấu của khách hàng công ty
            decimal tongChietKhauCongTy = congTy.TinhTongChietKhauCongTy();
            Console.WriteLine("Tổng chiết khấu của khách hàng công ty: " + tongChietKhauCongTy);

            // Tìm danh sách đại lý cấp 1
            List<DaiLyCap1> danhSachDaiLyCap1 = congTy.TimDaiLyCap1();
            Console.WriteLine("Danh sách đại lý cấp 1:");
            foreach (DaiLyCap1 daiLyCap1 in danhSachDaiLyCap1)
            {
                Console.WriteLine("Mã khách hàng: " + daiLyCap1.MaKhachHang);
                Console.WriteLine("Tên khách hàng: " + daiLyCap1.TenKhachHang);
                Console.WriteLine("Số lượng: " + daiLyCap1.SoLuong);
                Console.WriteLine("Giá bán: " + daiLyCap1.GiaBan);
                Console.WriteLine("Thời gian hợp tác: " + daiLyCap1.ThoiGianHopTac);
                Console.WriteLine("Thành tiền: " + daiLyCap1.ThanhTien);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public static void DocDuLieuTuFileXML(CongTyABC congTy)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DuLieuHoaDon.xml");
            XmlNodeList nodes = doc.SelectNodes("/HoaDon");

            foreach (XmlNode node in nodes)
            {
                string maKhachHang = node.SelectSingleNode("MaKhachHang").InnerText;
                string tenKhachHang = node.SelectSingleNode("TenKhachHang").InnerText;
                int soLuong = int.Parse(node.SelectSingleNode("SoLuong").InnerText);
                decimal giaBan = decimal.Parse(node.SelectSingleNode("GiaBan").InnerText);
                string loaiKhachHang = node.SelectSingleNode("LoaiKhachHang").InnerText;

                if (loaiKhachHang == "KhachHangCaNhan")
                {
                    int khoangCachGiaoHang = int.Parse(node.SelectSingleNode("KhoangCachGiaoHang").InnerText);
                    KhachHangCaNhan khachHangCaNhan = new KhachHangCaNhan(maKhachHang, tenKhachHang, soLuong, giaBan, khoangCachGiaoHang);
                    congTy.ThemHoaDon(khachHangCaNhan);
                }
                else if (loaiKhachHang == "DaiLyCap1")
                {
                    int thoiGianHopTac = int.Parse(node.SelectSingleNode("ThoiGianHopTac").InnerText);
                    DaiLyCap1 daiLyCap1 = new DaiLyCap1(maKhachHang, tenKhachHang, soLuong, giaBan, thoiGianHopTac);
                    congTy.ThemHoaDon(daiLyCap1);
                }
                else if (loaiKhachHang == "KhachHangCongTy")
                {
                    int soLuongNhanVien = int.Parse(node.SelectSingleNode("SoLuongNhanVien").InnerText);
                    KhachHangCongTy khachHangCongTy = new KhachHangCongTy(maKhachHang, tenKhachHang, soLuong, giaBan, soLuongNhanVien);
                    congTy.ThemHoaDon(khachHangCongTy);
                }
            }
        }
    }
}
