using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai2
{
    public abstract class NhanVien
    {
        private string maNV;
        private string tenNV;
        private int namSinh;
        private string gioiTinh;
        private double heSoLuong;
        private int namVaoLam;

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }
        public int NamVaoLam { get => namVaoLam; set => namVaoLam = value; }

        public NhanVien(string maNV, string tenNV, int namSinh, string gioiTinh, double heSoLuong, int namVaoLam)
        {
            MaNV = maNV;
            TenNV = tenNV;
            NamSinh = namSinh;
            GioiTinh = gioiTinh;
            HeSoLuong = heSoLuong;
            NamVaoLam = namVaoLam;
        }
        public abstract double TinhLuong();
        public virtual void XuatThongTin()
        {
            Console.WriteLine("Thông tin nhân viên:");
            Console.WriteLine("Mã nhân viên: " + MaNV);
            Console.WriteLine("Tên nhân viên: " + TenNV);
            Console.WriteLine("Năm sinh: " + NamSinh);
            Console.WriteLine("Giới tính: " + GioiTinh);
            Console.WriteLine("Hệ số lương: " + HeSoLuong);
            Console.WriteLine("Năm vào làm: " + NamVaoLam);
        }

    }
}
