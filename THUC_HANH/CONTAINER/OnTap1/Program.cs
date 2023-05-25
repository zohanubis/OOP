
using System;

class NhanVien
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

    // Phương thức khởi tạo
    public NhanVien(string maNhanVien, string tenNhanVien, string trinhDo, string noiDaoTao, double heSoLuong, int soLoiViPham)
    {
        MaNhanVien = maNhanVien;
        this.tenNhanVien = tenNhanVien;
        this.trinhDo = trinhDo;
        NoiDaoTao = noiDaoTao;
        this.heSoLuong = heSoLuong;
        this.soLoiViPham = soLoiViPham;
    }

    // Phương thức sao chép
    public NhanVien(NhanVien other)
    {
        MaNhanVien = other.MaNhanVien;
        tenNhanVien = other.tenNhanVien;
        trinhDo = other.trinhDo;
        NoiDaoTao = other.NoiDaoTao;
        heSoLuong = other.heSoLuong;
        soLoiViPham = other.soLoiViPham;
    }

    // Phương thức tính lương
    public double TinhLuong()
    {
        double luongCoBan = 1500000;
        double thuNhapThem = 0;

        if (trinhDo == "Ban Giám Đốc")
        {
            thuNhapThem = heSoLuong * luongCoBan;
        }
        else
        {
            double phanTramHoaHong = 0.05; // Ví dụ 5% hoa hồng
            thuNhapThem = phanTramHoaHong * 5000000;
        }

        return heSoLuong * luongCoBan + thuNhapThem;
    }

    // Phương thức tính thực lãnh
    public double TinhThucLanh()
    {
        double luong = TinhLuong();
        double heSoThiDua = 0;

        if (trinhDo == "Ban Giám Đốc")
        {
            heSoThiDua = 1.0;
        }
        else if (soLoiViPham == 0)
        {
            heSoThiDua = 1.0;
        }
        else if (soLoiViPham == 1)
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
    public double TinhMucHoTroChiPhi()
    {
        double luongCoBan = 1500000;
        double mucHoTro = 0;

        if (noiDaoTao == "Nước Ngoài")
        {
            mucHoTro = luongCoBan * 2.0;
        }

        return mucHoTro;
    }
}

class Program
{
    static void Main(string[] args)
    {
        NhanVien nhanVien = new NhanVien("01-001", "Nguyễn Văn A", "Nhân Viên", "Việt Nam", 1.2, 2);

        Console.WriteLine("Mã nhân viên: " + nhanVien.MaNhanVien);
        Console.WriteLine("Nơi đào tạo: " + nhanVien.NoiDaoTao);
        Console.WriteLine("Lương: " + nhanVien.TinhLuong());
        Console.WriteLine("Thực lãnh: " + nhanVien.TinhThucLanh());
        Console.WriteLine("Mức hỗ trợ chi phí: " + nhanVien.TinhMucHoTroChiPhi());
    }
}
