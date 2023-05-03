using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap2
{
    class KhoaHoc
    {
        private string maKhoaHoc;
        private string tenKhoaHoc;
        private int soTietHoc;
        private string gioHoc;
        private int soHocVien;
        private string giaoVienGiangDay;

        private const int HocPhiMotTietHoc = 20;

        private const int ThuLaoMotTietHoc = 100;

        private double heSoGioHoc
        {
            get
            {
                if (GioHoc == "3,5,7" || GioHoc == "2,4,6")
                    return 1.0;
                else if (GioHoc == "7,CN")
                    return 1.2;
                else
                    return 1.0;
            }
        }

        public string MaKhoaHoc
        {
            get { return maKhoaHoc; }
            set { maKhoaHoc = value; }
        }
        public string TenKhoaHoc
        {
            get { return tenKhoaHoc; }
            set { tenKhoaHoc = value; }
        }
        public int SoTietHoc
        {
            get { return soTietHoc; }
            set { soTietHoc = value; }
        }
        public string GioHoc
        {
            get { return gioHoc; }
            set { gioHoc = value; }
        }
        public int SoHocVien
        {
            get { return soHocVien; }
            set { soHocVien = value; }
        }
        public string GiaoVienGiangDay
        {
            get { return giaoVienGiangDay; }
            set { giaoVienGiangDay = value; }
        }
        public int HocPhi
        {
            get { return SoTietHoc * HocPhiMotTietHoc * (int)(heSoGioHoc); }
        }
        public int ThuLao
        {
            get
            {
                int tietDay = SoHocVien / 10;
                int thuLao = tietDay * ThuLaoMotTietHoc;
                if (tietDay > 0)
                    thuLao += 2 * ThuLaoMotTietHoc;
                return thuLao;
            }
        }
        public double TinhThuLao()
        {
            int soTietVuot = 0;
            if (soHocVien > 10)
            {
                soTietVuot = (soHocVien - 10) / 5;
            }
            return SoTietHoc * (ThuLaoMotTietHoc + soTietVuot * 2);
        }

        // Toán tử + một khóa học vơi 1 số nguyên n để tạo ra một khóa học mới có số giờ học so với khóa học cũ n tiết học
        public static KhoaHoc operator +(KhoaHoc kh, int n)
        {
            KhoaHoc khNew = new KhoaHoc(kh.MaKhoaHoc, kh.TenKhoaHoc, kh.SoTietHoc + n, kh.gioHoc, kh.SoHocVien, kh.GiaoVienGiangDay);
            return khNew;
        }

        public KhoaHoc()
        {
            MaKhoaHoc = "TH023";
            TenKhoaHoc = "Android Programming";
            SoTietHoc = 48;
            GioHoc = "2,4,6";
            SoHocVien = 13;
            GiaoVienGiangDay = "Zohanubis";
            if (GioHoc != "3,5,7" && GioHoc != "2,4,6" && GioHoc != "7,CN")
            {
                GioHoc = "3,5,7";
            }
        }
        public KhoaHoc(string maKhoaHoc, string tenKhoaHoc,int SoTietHoc, string gioHo, int soHocVien, string giaoVienGiangDay)
        {
            this.MaKhoaHoc = maKhoaHoc;
            this.TenKhoaHoc = tenKhoaHoc;
            this.SoTietHoc = soTietHoc;
            this.SoHocVien = soHocVien;
            this.GiaoVienGiangDay = giaoVienGiangDay;
            if (GioHoc != "3,5,7" && GioHoc != "2,4,6" && GioHoc != "7,CN")
            {
                GioHoc = "3,5,7";
            }

        }
        public void XuatThongTin()
        {
            Console.WriteLine("Mã Khóa Học : " +MaKhoaHoc);
            Console.WriteLine("Tên Khóa Học : " +TenKhoaHoc);
            Console.WriteLine("Số Tiết Học : " +SoTietHoc);
            Console.WriteLine("Số Học Viên : " + SoHocVien);
            Console.WriteLine("Giáo Viên Giảng Dạy : " + GiaoVienGiangDay);
            Console.WriteLine("Giờ Học : " + GioHoc);
            Console.WriteLine("Tiền thù lao trên mỗi khóa học của giáo viên : " + TinhThuLao());
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
