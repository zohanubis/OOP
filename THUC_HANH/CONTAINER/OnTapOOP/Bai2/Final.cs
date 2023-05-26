using System;

abstract class NhanVien
{
    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public double HeSoLuong { get; set; }
    public DateTime NgayVaoLam { get; set; }

    public NhanVien()
    {
        MaNhanVien = "NV0001";
        HoTen = "Phạm Thanh Bình";
        NgaySinh = new DateTime(1996, 3, 15);
        HeSoLuong = 2.34;
        NgayVaoLam = DateTime.Now;
    }

    public NhanVien(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam)
    {
        MaNhanVien = maNhanVien;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        HeSoLuong = heSoLuong;
        NgayVaoLam = ngayVaoLam;
    }

    public abstract double TinhLuong();

    public double TinhLuongCoBan()
    {
        return 1400;
    }
}

interface ILuongNgoaiGio
{
    double TinhLuongNgoaiGio();
}

class NhanVienHanChinh : NhanVien
{
    public int SoLanViPham { get; set; }

    public NhanVienHanChinh()
    {
        SoLanViPham = 0;
    }

    public NhanVienHanChinh(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam, int soLanViPham)
        : base(maNhanVien, hoTen, ngaySinh, heSoLuong, ngayVaoLam)
    {
        SoLanViPham = soLanViPham;
    }

    public override double TinhLuong()
    {
        double luong = TinhLuongCoBan() * HeSoLuong - SoLanViPham * 50;
        return luong;
    }
}

class NhanVienPhatTrienPhanMem : NhanVien, ILuongNgoaiGio
{
    public int SoModul { get; set; }
    public int SoGioTangCa { get; set; }

    public NhanVienPhatTrienPhanMem()
    {
        SoModul = 0;
        SoGioTangCa = 0;
    }

    public NhanVienPhatTrienPhanMem(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam, int soModul, int soGioTangCa)
        : base(maNhanVien, hoTen, ngaySinh, heSoLuong, ngayVaoLam)
    {
        SoModul = soModul;
        SoGioTangCa = soGioTangCa;
    }

    public override double TinhLuong()
    {
        double thuongTheoModul = (SoModul > 15) ? SoModul * 500 : SoModul * 300;
        double luong = TinhLuongCoBan() * HeSoLuong + thuongTheoModul;
        return luong;
    }

    public double TinhLuongNgoaiGio()
    {
        double luongNgoaiGio = (SoGioTangCa > 20) ? (20 * 200) + ((SoGioTangCa - 20) * 100) : SoGioTangCa * 200;
        return luongNgoaiGio;
    }
}

class NhanVienKiemThuPhanMem : NhanVien, ILuongNgoaiGio
{
    public int SoLoiNgoaiGio { get; set; }
    public int SoLoiQuanTrong { get; set; }

    public NhanVienKiemThuPhanMem()
    {
        SoLoiNgoaiGio = 0;
        SoLoiQuanTrong = 0;
    }

    public NhanVienKiemThuPhanMem(string maNhanVien, string hoTen, DateTime ngaySinh, double heSoLuong, DateTime ngayVaoLam, int soLoiNgoaiGio, int soLoiQuanTrong)
        : base(maNhanVien, hoTen, ngaySinh, heSoLuong, ngayVaoLam)
    {
        SoLoiNgoaiGio = soLoiNgoaiGio;
        SoLoiQuanTrong = soLoiQuanTrong;
    }

    public override double TinhLuong()
    {
        double thuongTheoLoi = (SoLoiNgoaiGio > 5) ? SoLoiNgoaiGio * 300 : SoLoiNgoaiGio * 200;
        double luong = TinhLuongCoBan() * HeSoLuong + thuongTheoLoi;
        return luong;
    }

    public double TinhLuongNgoaiGio()
    {
        double luongNgoaiGio = (SoLoiNgoaiGio > 50) ? (50 * 50) + ((SoLoiNgoaiGio - 50) * 30) : SoLoiNgoaiGio * 50;
        return luongNgoaiGio;
    }
}

class Program
{
    static void Main(string[] args)
    {
        NhanVienHanChinh nvHanChinh = new NhanVienHanChinh("NV0002", "Nguyễn Văn A", new DateTime(1990, 5, 10), 1.8, DateTime.Now, 2);
        NhanVienPhatTrienPhanMem nvPhatTrien = new NhanVienPhatTrienPhanMem("NV0003", "Trần Thị B", new DateTime(1992, 8, 20), 2.5, DateTime.Now, 10, 25);
        NhanVienKiemThuPhanMem nvKiemThu = new NhanVienKiemThuPhanMem("NV0004", "Lê Văn C", new DateTime(1988, 11, 5), 2.0, DateTime.Now, 8, 60);

        double luongNhanVienHanChinh = nvHanChinh.TinhLuong();
        double luongNhanVienPhatTrien = nvPhatTrien.TinhLuong();
        double luongNhanVienKiemThu = nvKiemThu.TinhLuong();

        Console.WriteLine("Lương nhân viên hành chính: " + luongNhanVienHanChinh);
        Console.WriteLine("Lương nhân viên phát triển phần mềm: " + luongNhanVienPhatTrien);
        Console.WriteLine("Lương nhân viên kiểm thử phần mềm: " + luongNhanVienKiemThu);

        ILuongNgoaiGio nvPhatTrien1 = new NhanVienPhatTrienPhanMem("NV0005", "Nguyễn Thị D", new DateTime(1995, 3, 8), 2.2, DateTime.Now, 20, 30);
        ILuongNgoaiGio nvKiemThu1 = new NhanVienKiemThuPhanMem("NV0006", "Trần Văn E", new DateTime(1993, 9, 15), 1.7, DateTime.Now, 60, 10);

        double luongNgoaiGioNhanVienPhatTrien = nvPhatTrien1.TinhLuongNgoaiGio();
        double luongNgoaiGioNhanVienKiemThu = nvKiemThu1.TinhLuongNgoaiGio();

        Console.WriteLine("Lương ngoài giờ nhân viên phát triển phần mềm: " + luongNgoaiGioNhanVienPhatTrien);
        Console.WriteLine("Lương ngoài giờ nhân viên kiểm thử phần mềm: " + luongNgoaiGioNhanVienKiemThu);

        Console.ReadLine();
    }
}
