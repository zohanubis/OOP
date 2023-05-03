using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace OnTap1
{
    class KhoSanPham
    {
        private string tenKho;
        private string diaChiKho;
        private List<SanPham> dssp = new List<SanPham>();

        internal List<SanPham> Dssp { get => dssp; set => dssp = value; }
        public string TenKho { get => tenKho; set => tenKho = value; }
        public string DiaChiKho { get => diaChiKho; set => diaChiKho = value; }
        
        public KhoSanPham()
        {
            TenKho = "Zohanubis";
            DiaChiKho = "HCM";
        }
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("SanPhams/SanPham");
            foreach(XmlNode node in nodeList)
            {
                SanPham sp = new SanPham();
                sp.MaSanPham = node["maSanPham"].InnerText;
                sp.TenSanPham = node["tenSanPham"].InnerText;
                sp.DonGia = double.Parse(node["donGia"].InnerText);
                sp.NamSanXuat = int.Parse(node["namSanXuat"].InnerText);
                sp.LoaiSanPham = char.Parse(node["loaiSanPham"].InnerText);
                sp.SoLuongBan = int.Parse(node["soLuongBan"].InnerText);
                Dssp.Add(sp);
            }
        }
        public double TinhTongTien(SanPham sp)
        {
            return sp.DonGia;
        }

        public double TinhTongTienKho()
        {
            double tongTien = 0;
            foreach (SanPham sp in Dssp)
            {
                tongTien += TinhTongTien(sp);
            }
            return tongTien;
        }
        public void Output()
        {
            Console.WriteLine("Tên Kho : {0}", TenKho);
            Console.WriteLine("Địa chỉ kho : {0}", DiaChiKho);
            Console.WriteLine("Danh sách sản phẩm:");
            foreach (SanPham sp in Dssp)
            {
                sp.XuatThongTin();
            }
            Console.WriteLine("Tổng tiền của tất cả các sản phẩm: {0}", TinhTongTienKho());
        }
        // Sản phẩm bán được nhiều nhất
        public SanPham SanPhamBanNhieuNhat()
        {
            SanPham spBanNhieuNhat = null;
            int max = -1;
            foreach(SanPham sp in Dssp)
            {
                if (sp.SoLuongBan > max)
                {
                    spBanNhieuNhat = sp;
                    max = sp.SoLuongBan;
                }    
                
            }
            return spBanNhieuNhat;
        }
        // Sắp xếp danh sách sản phẩm tăng dần theo đơn giá
        public void SapXepTheoDonGia()
        {
            Dssp.Sort((sp1, sp2) => sp1.DonGia.CompareTo(sp2.DonGia));
        }
    }
}
