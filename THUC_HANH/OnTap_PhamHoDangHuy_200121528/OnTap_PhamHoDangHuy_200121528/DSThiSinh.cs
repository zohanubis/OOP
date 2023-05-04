using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnTap_PhamHoDangHuy_200121528
{
    internal class DSThiSinh
    {
        private List<ThiSinh> DSTS = new List<ThiSinh>();
        internal List<ThiSinh> DSTS1 { get => DSTS; set => DSTS = value; } // xài này

        public void ThemThiSinh(ThiSinh ts)
        {
            DSTS1.Add(ts);
        }

        public void XoaThiSinh(ThiSinh ts)
        {
            DSTS1.Remove(ts);
        }

        public ThiSinh TimThiSinh(string maTS)
        {
            return DSTS1.Find(ts => ts.MaThiSinh == maTS);
        }

        public void XuatDanhSach()
        {
            foreach (ThiSinh ts in DSTS1)
            {
                ts.XuatThongTin();
                Console.WriteLine("---------------------------------------");
            }
        }

        public int DemSoLuongThiSinh()
        {
            return DSTS1.Count;
        }
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("DSThiSinh/ThiSinh");
            foreach (XmlNode node in nodeList)
            {
                ThiSinh ts = new ThiSinh();
                ts.MaThiSinh = node["MaTS"].InnerText;
                ts.HoTen = node["HoTen"].InnerText;
                ts.GioiTinh = node["GioiTinh"].InnerText;
                ts.DiemLyThuyet = float.Parse(node["DLyThuyet"].InnerText);
                ts.DiemThucHanh = float.Parse(node["DThucHanh"].InnerText);

                DSTS1.Add(ts);
            }
        }

        //In danh sách các thí sinh đạt kết quả đậu trong đợt thi.

        public void OutputDau()
        {
            foreach (ThiSinh ts in DSTS1)
            {
                if (ts.TinhDiemTongKet() >= 5.0f)
                {
                    ts.XuatThongTin();

                }
            }
        }
        //Tính tổng số thí sinh đậu, số thí sinh rớt.
        public int DemSoLuongThiSinhDau()
        {
            return DSTS1.Count(ts => ts.TinhDiemTongKet() >= 0.5f);
        }
        public int DemSoLuongThiSinhRot()
        {
            return DSTS1.Count(ts => ts.TinhDiemTongKet() < 0.5f);
        }
        //Cho mã thí sinh, in ra màn hình thông tin của thí sinh với mã cần tìm, nếu không tìm thấy thông báo
        //" Không tìm thấy thông tin".
        public void InThongTinThiSinh(string maTS)
        {
            ThiSinh ts = TimThiSinh(maTS);
            if (ts != null)
                ts.XuatThongTin();
            else
                Console.WriteLine("Không tìm thấy thông tin");
        }
        //Sắp xếp danh sách thí sinh theo thứ tự giảm dần của điểm tổng kết.
        public void XuatDanhSachSapXep()
        {
            List<ThiSinh> dsSapXep = DSTS1.OrderByDescending(ts => ts.TinhDiemTongKet()).ToList();
            foreach (ThiSinh ts in dsSapXep)
            {
                ts.XuatThongTin();
                Console.WriteLine("---------------------------------------");
            }
        }
        // Sắp xếp tăng dần theo tên Thí Sinh
        public void DanhSachSapXepTheoTen()
        {
            List<ThiSinh> dsSapXep = DSTS1.OrderBy(ts => ts.HoTen).ToList();
            foreach(ThiSinh ts in dsSapXep)
            {
                ts.XuatThongTin();
                Console.WriteLine("---------------------------------------------------");

            }

        }
        // Xuất thông tin 3 thí sinh có điểm cao nhất
        public void XuatThong3TSCoDiemCaoNhat()
        {
            List<ThiSinh> dsSapXep = DSTS1.OrderByDescending(ts => ts.TinhDiemTongKet()).ToList();
            Console.WriteLine("Xuất 3 thông tin thí sinh có điểm cao nhất");
            int count = 0;
            foreach(ThiSinh ts in dsSapXep)
            {
                ts.XuatThongTin();
                count++;
                if(count == 3) {
                    break;
                }
            }    
        }
    }
}
