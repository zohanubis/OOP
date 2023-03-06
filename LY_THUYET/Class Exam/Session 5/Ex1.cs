using System;

class NhanVien
{
    private string maNhanVien;
    private string hoTen;
    private double heSoLuong;
    private int namVaoLam;

    private static double mucLuongToiThieu;

    public NhanVien(string maNhanVien, string hoTen, double heSoLuong, int namVaoLam)
    {
        this.maNhanVien = maNhanVien;
        this.hoTen = hoTen;
        this.heSoLuong = heSoLuong;
        this.namVaoLam = namVaoLam;
    }

    public double TinhLuong()
    {
        int namHienTai = DateTime.Now.Year;
        double hspctn = (namHienTai - namVaoLam) / 100.0;
        double luongCoBan = heSoLuong * mucLuongToiThieu;
        double luong = luongCoBan * hspctn;
        return luong;
    }

    public void NhapThongTin()
    {
        Console.Write("Nhap ma nhan vien: ");
        maNhanVien = Console.ReadLine();

        Console.Write("Nhap ho ten nhan vien: ");
        hoTen = Console.ReadLine();

        Console.Write("Nhap he so luong: ");
        heSoLuong = double.Parse(Console.ReadLine());

        Console.Write("Nhap nam vao lam: ");
        namVaoLam = int.Parse(Console.ReadLine());
    }

    public void XuatThongTin()
    {
        Console.WriteLine("Ma nhan vien: {0}", maNhanVien);
        Console.WriteLine("Ho ten: {0}", hoTen);
        Console.WriteLine("He so luong: {0}", heSoLuong);
        Console.WriteLine("Nam vao lam: {0}", namVaoLam);
        Console.WriteLine("Luong: {0}", TinhLuong());
    }

    public static double MucLuongToiThieu
    {
        get { return mucLuongToiThieu; }
        set { mucLuongToiThieu = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Nhập giá trị cho mức lương tối thiểu
        Console.Write("Nhap muc luong toi thieu: ");
        double mucLuong = double.Parse(Console.ReadLine());
        NhanVien.MucLuongToiThieu = mucLuong;

        // Nhập thông tin cho nhân viên
        NhanVien nhanVien = new NhanVien("", "", 0, 0);
        nhanVien.NhapThongTin();

        // In thông tin và lương của nhân viên
        Console.WriteLine("Thong tin nhan vien:");
        nhanVien.XuatThongTin();

        Console.ReadKey();
    }
}
