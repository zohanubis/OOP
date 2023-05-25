using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi8_Interface_Bai2
{
    public class DSNhanVien
    {
        private List<NhanVien> dsnv = new List<NhanVien>();
        internal List<NhanVien> Dsnv { get => dsnv; set => dsnv = value; }
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("/CongTy/NhanVien");
            foreach (XmlNode node in nodeList)
            {
                NhanVien nv;
                string loaiNhanVien = node.Attributes["LoaiNhanVien"].InnerText;

                if (loaiNhanVien == "SanXuat")
                {
                    string maNV = node.SelectSingleNode("MaNV").InnerText;
                    string tenNV = node.SelectSingleNode("TenNV").InnerText;
                    int namSinh = int.Parse(node.SelectSingleNode("NamSinh").InnerText);
                    string gioiTinh = node.SelectSingleNode("GioiTinh").InnerText;
                    double heSoLuong = double.Parse(node.SelectSingleNode("HeSoLuong").InnerText);
                    int namVaoLam = int.Parse(node.SelectSingleNode("NamVaoLam").InnerText);
                    int soNgayNghi = int.Parse(node.SelectSingleNode("SoNgayNghi").InnerText);

                    NhanVienSanXuat nvSanXuat = new NhanVienSanXuat(maNV, tenNV, namSinh, gioiTinh, heSoLuong, namVaoLam, soNgayNghi);
                    Dsnv.Add(nvSanXuat);
                }
                else if (loaiNhanVien == "KinhDoanh")
                {
                    string maNV = node.SelectSingleNode("MaNV").InnerText;
                    string tenNV = node.SelectSingleNode("TenNV").InnerText;
                    int namSinh = int.Parse(node.SelectSingleNode("NamSinh").InnerText);
                    string gioiTinh = node.SelectSingleNode("GioiTinh").InnerText;
                    double heSoLuong = double.Parse(node.SelectSingleNode("HeSoLuong").InnerText);
                    int namVaoLam = int.Parse(node.SelectSingleNode("NamVaoLam").InnerText);
                    double doanhSoBanHang = double.Parse(node.SelectSingleNode("DoanhSoBanHang").InnerText);

                    NhanVienKinhDoanh nvKinhDoanh = new NhanVienKinhDoanh(maNV, tenNV, namSinh, gioiTinh, heSoLuong, namVaoLam, doanhSoBanHang);
                    Dsnv.Add(nvKinhDoanh);
                }
                else if (loaiNhanVien == "QuanLy")
                {
                    string maNV = node.SelectSingleNode("MaNV").InnerText;
                    string tenNV = node.SelectSingleNode("TenNV").InnerText;
                    int namSinh = int.Parse(node.SelectSingleNode("NamSinh").InnerText);
                    string gioiTinh = node.SelectSingleNode("GioiTinh").InnerText;
                    double heSoLuong = double.Parse(node.SelectSingleNode("HeSoLuong").InnerText);
                    int namVaoLam = int.Parse(node.SelectSingleNode("NamVaoLam").InnerText);
                    string chucVu = node.SelectSingleNode("ChucVu").InnerText;
                    double heSoPhuCapChucVu = double.Parse(node.SelectSingleNode("HeSoPhuCapChucVu").InnerText);

                    CanBoQuanLy canBoQuanLy = new CanBoQuanLy(maNV, tenNV, namSinh, gioiTinh, heSoLuong, namVaoLam, chucVu, heSoPhuCapChucVu);
                    Dsnv.Add(canBoQuanLy);
                }
            }
        }
        public void DemSoNhanVien()
        {
            int soNhanVienABC = 0;
            int soNhanVienBCD = 0;

            foreach (NhanVien nv in Dsnv)
            {
                if (nv is NhanVienSanXuat || nv is NhanVienKinhDoanh || nv is CanBoQuanLy)
                {
                    soNhanVienABC++;
                }
                else
                {
                    soNhanVienBCD++;
                }
            }

            Console.WriteLine("Số nhân viên của công ty ABC: " + soNhanVienABC);
            Console.WriteLine("Số nhân viên của công ty BCD: " + soNhanVienBCD);
        }

        // Tính tổng số nhân viên của công ty T có "Năng lực tốt"
        public void TinhTongSoNhanVienCoNangLucTot()
        {
            int tongSoNhanVienCoNangLucTot = 0;

            foreach (NhanVien nv in Dsnv)
            {
                if (nv is IXepLoaiThiDua xepLoaiThiDua)
                {
                    if (xepLoaiThiDua.XepLoaiThiDua() == "A")
                    {
                        tongSoNhanVienCoNangLucTot++;
                    }
                }
            }

            Console.WriteLine("Tổng số nhân viên có năng lực tốt của công ty T: " + tongSoNhanVienCoNangLucTot);
        }

        // Tính tổng lương phải trả cho công ty con (ABC và BCD)
        public void TinhTongLuongCongTyCon()
        {
            double tongLuongABC = 0;
            double tongLuongBCD = 0;

            foreach (NhanVien nv in Dsnv)
            {
                if (nv is NhanVienSanXuat || nv is NhanVienKinhDoanh || nv is CanBoQuanLy)
                {
                    tongLuongABC += nv.TinhLuong();
                }
                else
                {
                    tongLuongBCD += nv.TinhLuong();
                }
            }

            Console.WriteLine("Tổng lương phải trả cho công ty ABC: " + tongLuongABC);
            Console.WriteLine("Tổng lương phải trả cho công ty BCD: " + tongLuongBCD);
        }
        public void XuatThongTinNhanVienKinhDoanh()
        {
            Console.WriteLine("=== Thông tin nhân viên kinh doanh ===");
            foreach (NhanVien nv in Dsnv)
            {
                if (nv is NhanVienKinhDoanh nhanVienKinhDoanh)
                {
                    nhanVienKinhDoanh.XuatThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void XuatThongTinNhanVienSanXuat()
        {
            Console.WriteLine("=== Thông tin nhân viên sản xuất ===");
            foreach (NhanVien nv in Dsnv)
            {
                if (nv is NhanVienSanXuat nhanVienSanXuat)
                {
                    nhanVienSanXuat.XuatThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void XuatThongTinCanBoQuanLy()
        {
            Console.WriteLine("=== Thông tin cán bộ quản lý ===");
            foreach (NhanVien nv in Dsnv)
            {
                if (nv is CanBoQuanLy canBoQuanLy)
                {
                    canBoQuanLy.XuatThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void XuatThongTinNhanVienChuaDuocXetThiDua()
        {
            Console.WriteLine("Danh sách nhân viên chưa được xét thi đua ở công ty BCD:");
            foreach (NhanVien nv in Dsnv)
            {
                if (!(nv is IXepLoaiThiDua))
                {
                    nv.XuatThongTin();
                    Console.WriteLine();
                }
            }
        }

        public void XuatThongTinNhanVienLaoDongTienTien()
        {
            Console.WriteLine("Danh sách nhân viên lao động tiên tiến của công ty ABC:");
            foreach (NhanVien nv in Dsnv)
            {
                if (nv is NhanVienSanXuat || nv is NhanVienKinhDoanh)
                {
                    nv.XuatThongTin();
                    Console.WriteLine();
                }
            }
        }

    }
}
