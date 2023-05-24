using System;

abstract class NhanVien
{
    private string maNhanVien;
    private string tenNhanVien;
    private string trinhDo;
    private string noiDaoTao;
    private double heSoLuong;
    private int soLoiViPham;

    public string MaNhanVien
    {
        get { return maNhanVien; }
        set { maNhanVien = value; }
    }

    public string NoiDaoTao
    {
        get { return noiDaoTao; }
        set
        {
            if (value == "Việt Nam" || value == "Nước Ngoài")
                noiDaoTao = value;
            else
                throw new ArgumentException("Nơi đào tạo không hợp lệ!");
        }
    }

    // Phương thức tính lương trừu tượng
    public abstract double TinhLuong();

    // Phương thức tính thực lãnh trừu tượng
    public abstract double TinhThucLanh();

    // Phương thức tính mức hỗ trợ chi phí trừu tượng
    public abstract double TinhMucHoTroChiPhi();
}

// Lớp Nhân viên văn phòng kế thừa từ lớp NhanVien
class NhanVienVanPhong : NhanVien
{
    private const double LuongCoBan = 1500000;

    // Phương thức tính lương
    public override double TinhLuong()
    {
        double thuNhapThem = HeSoLuong * LuongCoBan;

        return HeSoLuong * LuongCoBan + thuNhapThem;
    }

    // Phương thức tính thực lãnh
    public override double TinhThucLanh()
    {
        double luong = TinhLuong();
        double heSoThiDua = 0;

        if (SoLoiViPham == 0)
        {
            heSoThiDua = 1.0;
        }
        else if (SoLoiViPham == 1)
        {
            heSoThiDua = 0.75;
        }
        else
        {
            heSoThiDua = 0.5;
        }

        return luong * heSoThiDua;
    }

    // Phương thức tính mức hỗ trợ chi phí
    public override double TinhMucHoTroChiPhi()
    {
        double mucHoTro = 0;

        if (NoiDaoTao == "Nước Ngoài")
        {
            mucHoTro = LuongCoBan * 2.0;
        }

        return mucHoTro;
    }
}

class Program
{
    static void Main(string[] args)
    {
        NhanVienVanPhong nhanVien = new NhanVienVanPhong()
        {
            MaNhanVien = "01-001",
            TenNhanVien = "Nguyễn Văn A",
            TrinhDo = "Nhân Viên",
            NoiDaoTao = "Việt Nam",
            HeSoLuong = 1.2,
            SoLoiViPham = 2
        };

        Console.WriteLine("Mã nhân viên: " + nhanVien.MaNhanVien);
        Console.WriteLine("Nơi đào tạo: " + nhanVien.NoiDaoTao);
        Console.WriteLine("Lương: " + nhanVien.TinhLuong());
        Console.WriteLine("Thực lãnh: " + nhanVien.TinhThucLanh());
        Console.WriteLine("Mức hỗ trợ chi phí: " + nhanVien.TinhMucHoTroChiPhi());
    }
}
