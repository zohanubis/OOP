using System;

class TinhTienDien
{
    private string hoTenChuHo;
    private int maSoCongTo;
    private int chiSoCu;
    private int chiSoMoi;
    private int dinhMuc;
    private int donGiaDinhMuc;
    private int donGiaVuotDinhMuc;

    public TinhTienDien(string hoTenChuHo, int maSoCongTo, int chiSoCu, int chiSoMoi, int dinhMuc, int donGiaDinhMuc, int donGiaVuotDinhMuc)
    {
        this.hoTenChuHo = hoTenChuHo;
        this.maSoCongTo = maSoCongTo;
        this.chiSoCu = chiSoCu;
        this.chiSoMoi = chiSoMoi;
        this.dinhMuc = dinhMuc;
        this.donGiaDinhMuc = donGiaDinhMuc;
        this.donGiaVuotDinhMuc = donGiaVuotDinhMuc;
    }

    public string HoTenChuHo
    {
        get { return hoTenChuHo; }
        set { hoTenChuHo = value; }
    }

    public int MaSoCongTo
    {
        get { return maSoCongTo; }
        set { maSoCongTo = value; }
    }

    public int ChiSoCu
    {
        get { return chiSoCu; }
        set { chiSoCu = value; }
    }

    public int ChiSoMoi
    {
        get { return chiSoMoi; }
        set { chiSoMoi = value; }
    }

    public int DinhMuc
    {
        get { return dinhMuc; }
        set { dinhMuc = value; }
    }

    public int DonGiaDinhMuc
    {
        get { return donGiaDinhMuc; }
        set { donGiaDinhMuc = value; }
    }

    public int DonGiaVuotDinhMuc
    {
        get { return donGiaVuotDinhMuc; }
        set { donGiaVuotDinhMuc = value; }
    }

    public int SoDienSuDung
    {
        get
        {
            int soDienSuDung = chiSoMoi - chiSoCu;
            if (soDienSuDung <= dinhMuc)
            {
                return soDienSuDung;
            }
            else
            {
                int soDienVuotDinhMuc = soDienSuDung - dinhMuc;
                int tongTien = dinhMuc * donGiaDinhMuc + soDienVuotDinhMuc * donGiaVuotDinhMuc;
                return tongTien / donGiaVuotDinhMuc;
            }
        }
    }

    public double TienDien
    {
        get
        {
            double soDienSuDung = this.SoDienSuDung;
            if (soDienSuDung <= dinhMuc)
            {
                return soDienSuDung * donGiaDinhMuc;
            }
            else
            {
                double tienVuotDinhMuc = (soDienSuDung - dinhMuc) * donGiaVuotDinhMuc;
                double tienTrongDinhMuc = dinhMuc * donGiaDinhMuc;
                return tienTrongDinhMuc + tienVuotDinhMuc;
            }
        }
    }
    public void NhapThongTin()
    {
        Console.Write("Nhap ho ten chu ho: ");
        HoTenChuHo = Console.ReadLine();

        Console.Write("Nhap ma so cong to dien: ");
        MaSoCongTo = int.Parse(Console.ReadLine());

        Console.Write("Nhap chi so cu: ");
        ChiSoCu = int.Parse(Console.ReadLine());

        Console.Write("Nhap chi so moi: ");
        ChiSoMoi = int.Parse(Console.ReadLine());

        Console.Write("Nhap dinh muc: ");
        DinhMuc = int.Parse(Console.ReadLine());

        Console.Write("Nhap don gia dinh muc: ");
        DonGiaDinhMuc = int.Parse(Console.ReadLine());

        Console.Write("Nhap don gia vuot dinh muc: ");
        DonGiaVuotDinhMuc = int.Parse(Console.ReadLine());
    }


    public void HienThiThongTin()
    {
        Console.WriteLine("Ho ten chu ho: " + HoTenChuHo);
        Console.WriteLine("Ma so cong to dien: " + MaSoCongTo);
        Console.WriteLine("Chi so cu: " + ChiSoCu);
        Console.WriteLine("Chi so moi: " + ChiSoMoi);
        Console.WriteLine("So dien su dung: " + SoDienSuDung);
        Console.WriteLine("Tien dien: " + TienDien);
    }
}
class Program
{
    static void Main(string[] args)
    {
        TinhTienDien hoGiaDinh = new TinhTienDien("", 0, 0, 0, 0, 0, 0);

        Console.WriteLine("Nhap thong tin ho gia dinh:");
        hoGiaDinh.NhapThongTin();

        Console.WriteLine("\nThong tin ho gia dinh:");
        hoGiaDinh.HienThiThongTin();
    }
}