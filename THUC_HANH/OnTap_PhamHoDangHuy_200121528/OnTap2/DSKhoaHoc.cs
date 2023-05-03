using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace OnTap2
{
    class DSKhoaHoc
    {
        private List<KhoaHoc> dskh = new List<KhoaHoc>();

        internal List<KhoaHoc> Dskh { get => dskh; set => dskh = value; }

        public KhoaHoc TimGiaoVien (string tenGV)
        {
            return Dskh.Find(kh => kh.GiaoVienGiangDay == tenGV);
        }
        public void XuatDanhSach()
        {
            foreach(KhoaHoc kh in Dskh)
            {
                kh.XuatThongTin();
            }    
        }
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("KhoaHocs/KhoaHoc");
            foreach(XmlNode node in nodeList)
            {
                KhoaHoc kh = new KhoaHoc();
                kh.MaKhoaHoc = node["MaKhoaHoc"].InnerText;
                kh.TenKhoaHoc = node["TenKhoaHoc"].InnerText;
                kh.SoTietHoc = int.Parse(node["SoTietHoc"].InnerText);
                kh.GioHoc = node["GioHoc"].InnerText;
                kh.SoHocVien = int.Parse(node["SLHocVien"].InnerText);
                kh.GiaoVienGiangDay = node["GVGiangDay"].InnerText;
                Dskh.Add(kh);
            }
        }
        // Tính tổng tiền trung tâm đang có
        public double TinhTongTien()
        {
            double TongTien = 0;
            foreach (KhoaHoc kh in Dskh)
            {
                TongTien += kh.TinhThuLao();
            }
            return TongTien;
        }
        // Tổng số lớp mà trung tâm đang có
        public int TinhTongSoLop()
        {
            return Dskh.Count();
        }
        // Lấy ra danh sách các khóa học có số lượng học viên từ 15 trở lên
        public List<KhoaHoc> TimKhoaHocLonHon15()
        {
            return Dskh.FindAll(kh => kh.SoHocVien >= 15);
        }
        // Cho biết hiện tại giáo viên có tên x đang dạy bao nhiêu khóa học
        public int SoKhoaHocGVX (string tenGV)
        {
            return Dskh.Count(kh => kh.GiaoVienGiangDay == tenGV);
        }
        // Sắp xếp danh sách học phí giảm dần
        public void SapXepHocPhiGiam()
        {
            Dskh.Sort((kh1, kh2) => kh2.HocPhi.CompareTo(kh1.HocPhi));
        }
        public void TimInKHTheoTen(string tenKH)
        {
            List<KhoaHoc> dsKHTheoTen = Dskh.FindAll(kh => kh.TenKhoaHoc == tenKH);
            foreach (KhoaHoc kh in dsKHTheoTen)
                kh.XuatThongTin();
        }
        // Xuất danh sách theo giờ học
        public void XuatDanhSachTheoGioHoc()
        {
            Console.WriteLine("Cac khoa hoc co gio hoc la '2,4,6':");
            foreach (KhoaHoc kh in Dskh)
            {
                if (kh.GioHoc == "2,4,6")
                {
                    kh.XuatThongTin();
                }
            }
            Console.WriteLine("Cac khoa hoc co gio hoc la '3,5,7':");
            foreach (KhoaHoc kh in Dskh)
            {
                if (kh.GioHoc == "3,5,7")
                {
                    kh.XuatThongTin();
                }
            }
            Console.WriteLine("Cac khoa hoc co gio hoc la '7,CN':");
            foreach (KhoaHoc kh in Dskh)
            {
                if (kh.GioHoc == "7,CN")
                {
                    kh.XuatThongTin();
                }
            }

        }
    }
}
