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

    public string MaNhanVien
    {
        get { return maNhanVien; }
        set { maNhanVien = value; }
    }

    public string HoTen
    {
        get { return hoTen; }
        set { hoTen = value; }
    }

    public double HeSoLuong
    {
        get { return heSoLuong; }
        set { heSoLuong = value; }
    }

    public int NamVaoLam
    {
        get { return namVaoLam; }
        set { namVaoLam = value; }
    }

    public static double MucLuongToiThieu
    {
        get { return mucLuongToiThieu; }
        set { mucLuongToiThieu = value; }
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
        Console.WriteLine("Ho ten nhan vien: {0}", hoTen);
        Console.WriteLine("He so luong: {0}", heSoLuong);
        Console.WriteLine("Nam vao lam: {0}", namVaoLam);
        Console.WriteLine("Luong: {0}", TinhLuong());
    }
}

class DanhSachNhanVien
{
    private NhanVien[] danhSach;
    private int soLuong;

    public DanhSachNhanVien(int soLuong)
    {
        danhSach = new NhanVien[soLuong];
        this.soLuong = 0;
    }

    public void ThemNhanVien(NhanVien nhanVien)
    {
        if (soLuong < danhSach.Length)
        {
            danhSach[soLuong] = nhanVien;
            soLuong++;
        }
        else
        {
            Console.WriteLine("Danh sach da day, khong the them nhan vien.");
        }
    }
    
    public void NhapDanhSach()
    {
        Console.WriteLine("Nhap thong tin danh sach nhan vien:");
        for (int i = 0; i < danhSach.Length; i++)
        {
            Console.WriteLine("Nhap thong tin nhan vien thu {0}:", i + 1);
            NhanVien nhanVien = new NhanVien("", "", 0, 0);
            nhanVien.NhapThongTin();
            ThemNhanVien(nhanVien);
        }
    }
    public void XuatDanhSach()
    {
        Console.WriteLine("Danh sach nhan vien:");
        foreach (NhanVien nhanVien in danhSach)
        {
            nhanVien.XuatThongTin();
            Console.WriteLine();
        }
    }

    public double TinhTongLuong()
    {
        double tongLuong = 0;
        foreach (NhanVien nhanVien in danhSach)
        {
            tongLuong += nhanVien.TinhLuong();
        }
        return tongLuong;
    }

    public NhanVien TimNhanVienLuongCaoNhat()
    {
        NhanVien nhanVienLuongCaoNhat = danhSach[0];
        foreach (NhanVien nhanVien in danhSach)
        {
            if (nhanVien.TinhLuong() > nhanVienLuongCaoNhat.TinhLuong())
            {
                nhanVienLuongCaoNhat = nhanVien;
            }
        }
        return nhanVienLuongCaoNhat;
    }

    public void SapXepTheoNamVaoLam()
    {
        for (int i = 0; i < soLuong - 1; i++)
        {
            for (int j = i + 1; j < soLuong; j++)
            {
                if (danhSach[i].NamVaoLam > danhSach[j].NamVaoLam)
                {
                    NhanVien temp = danhSach[i];
                    danhSach[i] = danhSach[j];
                    danhSach[j] = temp;
                }
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {

        Console.Write("Nhap so luong nhan vien: ");
        int soLuong = int.Parse(Console.ReadLine());
        Console.Write("Nhap muc luong toi thieu : ");
        double mucLuong= double.Parse(Console.ReadLine());
        NhanVien.MucLuongToiThieu = mucLuong;
        DanhSachNhanVien danhSachNhanVien = new DanhSachNhanVien(soLuong);
            
        NhanVien.MucLuongToiThieu = 1000000;
        danhSachNhanVien.NhapDanhSach();
        Console.WriteLine("Danh sach nhan vien:");
        danhSachNhanVien.XuatDanhSach();
        Console.WriteLine("Tong luong nhan vien: {0}", danhSachNhanVien.TinhTongLuong());
        NhanVien nhanVienLuongCaoNhat = danhSachNhanVien.TimNhanVienLuongCaoNhat();
        Console.WriteLine("Thong tin nhan vien co luong cao nhat:");
        nhanVienLuongCaoNhat.XuatThongTin();
        danhSachNhanVien.SapXepTheoNamVaoLam();
        Console.WriteLine("Danh sach nhan vien sau khi sap xep theo nam vao lam:");
        danhSachNhanVien.XuatDanhSach();
    }
}
