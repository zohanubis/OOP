using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class PhatTrienPhanMem : NhanVien, ILuongNgoaiGio
    {
        private int modul;
        private int soGioTangCa;

        public int Modul { get => modul; set => modul = value; }
        public int SoGioTangCa { get => soGioTangCa; set => soGioTangCa = value; }

        public PhatTrienPhanMem()
        {
            Modul = 0;
            SoGioTangCa = 0;
        }
        public PhatTrienPhanMem(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam, int modul, int soGioTangCa) 
            : base (maNhanVien, hoTen, ngaySinh, heSoLuong,ngayVaoLam)
        {
            Modul = modul;
            SoGioTangCa = soGioTangCa;
        }
        
        public override double TinhLuong()
        {
            double thuongTheoMoDul = (Modul > 15) ? Modul * 500 : Modul * 300;
            double luongPhanMem = LuongCoBan() * HeSoLuong + thuongTheoMoDul;
            return luongPhanMem;
        }
        public double TinhLuongNgoaiGio()
        {
            double luongNgoaiGio = (SoGioTangCa > 20) ? (200 * 20) + ((SoGioTangCa - 20) * 100) : SoGioTangCa * 200;
            //tổng của 20 giờ đầu tiên (20 * 200) và số giờ còn lại (SoGioTangCa - 20) nhân với mức lương ngoài giờ thứ 2 (100)
            return luongNgoaiGio;
        }
    }
}
