using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class NhanVien
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string trinhDo;
        private string noiDaoTao;
        private double heSoLuong;
        private int soLoiViPham;

        public NhanVien(string maNhanVien, string tenNhanVien, string trinhDo, string noiDaoTao, double heSoLuong, int soLoiViPham)
        {
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
            TrinhDo = trinhDo;
            NoiDaoTao = noiDaoTao;
            HeSoLuong = heSoLuong;
            SoLoiViPham = soLoiViPham;
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                // Kiểm tra nếu mã không đúng định dạng "01"
                if (value.Length == 2 && value.StartsWith("01"))
                    maNhanVien = value;
                else
                    Console.WriteLine("Mã Nhân Viên sai định dạng");
            }
        }

        public string NoiDaoTao
        {
            get { return noiDaoTao; }
            set
            {
                // Kiểm tra nếu không phải là "Việt Nam" hoặc "Nước Ngoài"
                if (value == "Việt Nam" || value == "Nước Ngoài")
                    noiDaoTao= value;
                else
                    throw new ArgumentException("Nơi Đào Tạo không hợp lệ.");
            }
        }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public int SoLoiViPham { get => soLoiViPham; set => soLoiViPham = value; }

        public NhanVien(NhanVien other)
        {
            MaNhanVien = other.MaNhanVien;
            TenNhanVien = other.TenNhanVien;
            TrinhDo = other.TrinhDo;
            NoiDaoTao = other.NoiDaoTao;
            HeSoLuong = other.HeSoLuong;
            SoLoiViPham = other.SoLoiViPham;
        }

        public double TinhLuong()
        {
            double luongCoBan = 1500000;
            double thuNhapThem = 0;

            if (TrinhDo == "Nhân Viên")
            {
                // Tính thu nhập tăng thêm dựa trên phần trăm hoa hồng
                double phanTramHoaHong = 0.0; // Thiết lập phần trăm hoa hồng tùy theo yêu cầu
                thuNhapThem = phanTramHoaHong * 5000000;
            }
            else if (TrinhDo == "Ban Giám Đốc")
            {
                // Tính thu nhập tăng thêm dựa trên hệ số chức vụ
                double heSoChucVu = 0.0; // Thiết lập hệ số chức vụ tùy theo yêu cầu
                thuNhapThem = heSoChucVu * luongCoBan;
            }

            return HeSoLuong * luongCoBan + thuNhapThem;
        }

        public double TinhThucLanh()
        {
            double heSoThiDua = 0;

            if (SoLoiViPham == 0)
                heSoThiDua = 1.0;
            else if (SoLoiViPham == 1)
                heSoThiDua = 0.75;
            else
                heSoThiDua = 0.5;

            if (TrinhDo == "Ban Giám Đốc")
                heSoThiDua = 1.0;

            double luong = TinhLuong();
            return luong * heSoThiDua;
        }
    }

}
