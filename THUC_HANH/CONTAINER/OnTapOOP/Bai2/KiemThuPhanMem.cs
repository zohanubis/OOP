using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class KiemThuPhanMem : NhanVien, ILuongNgoaiGio
    {
        private int soLoiNgoaiGio;
        private int soLoiQuanTrong;

        public int SoLoiNgoaiGio { get => soLoiNgoaiGio; set => soLoiNgoaiGio = value; }
        public int SoLoiQuanTrong { get => soLoiQuanTrong; set => soLoiQuanTrong = value; }
        public KiemThuPhanMem()
        {
            SoLoiNgoaiGio = 0;
            SoLoiQuanTrong = 0;
        }
        public KiemThuPhanMem(string maNhanVien,string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam, int soLoiNgoaiGio, int soLoiQuanTrong)
            : base(maNhanVien, hoTen, ngaySinh, heSoLuong, ngayVaoLam)
        {
            SoLoiNgoaiGio = soLoiNgoaiGio;
            SoLoiQuanTrong = soLoiQuanTrong;
        }
        public override double TinhLuong()
        {
            double thuongTheoLoi = (SoLoiQuanTrong > 5) ? SoLoiQuanTrong * 300 : SoLoiQuanTrong * 200;
            double luongKiemThu = LuongCoBan() * HeSoLuong * thuongTheoLoi;
            return luongKiemThu;
        }
        public double TinhLuongNgoaiGio()
        {
            double luongNgoaiGio = (SoLoiNgoaiGio > 50) ? (SoLoiNgoaiGio * 50) + ((SoLoiNgoaiGio - 50) * 30) : SoLoiNgoaiGio * 50;
            return luongNgoaiGio;
        }
    }
}
