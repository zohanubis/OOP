
using System;
using System.Text;

public abstract class NhanVien
{
    protected string maNV;
    protected string hoTen;
    protected string maChucVu;
    protected int namVaoLam;

    public string MaNV
    {
        get { return maNV; }
        set
        {
            if (value.Length == 5 && value.Substring(0, 2)
                == "NV" && Char.IsDigit(value[2]) && value[3]
                == 'E' && Char.IsDigit(value[4]))
            {
                maNV = value;
            }
            else
            {
                Console.WriteLine("Mã NV không hợp lệ!");
            }
        }
    }

    public string HoTen
    {
        get { return hoTen; }
        set { hoTen = value; }
    }

    public string MaChucVu
    {
        get { return maChucVu; }
        set { maChucVu = value; }
    }

    public int NamVaoLam
    {
        get { return namVaoLam; }
        set
        {
            if (value > 2010 && value < 2014)
            {
                namVaoLam = value;
            }
            else
            {
                Console.WriteLine("Năm vào làm không hợp lệ!");
            }
        }
    }

    public abstract double TinhLuong();

    public virtual void HienThiThongTin()
    {
        Console.WriteLine("Mã NV: " + MaNV);
        Console.WriteLine("Họ tên: " + HoTen);
        Console.WriteLine("Mã chức vụ: " + MaChucVu);
        Console.WriteLine("Năm vào làm: " + NamVaoLam);
    }
}

public interface IHoTroLuong
{
    double TinhHoTroLuong();
}

public class NhanVienBienChe : NhanVien
{
    protected int soNgayLam;

    public NhanVienBienChe(string maNV, string hoTen, string maChucVu, int namVaoLam, int soNgayLam)
    {
        MaNV = maNV;
        HoTen = hoTen;
        MaChucVu = maChucVu;
        NamVaoLam = namVaoLam;
        this.soNgayLam = soNgayLam;
    }

    public override double TinhLuong()
    {
        double luongCoBan = 1000000;
        double luong = 0;
        int soNamLam = DateTime.Now.Year - NamVaoLam;

        double heSoLuong = 2 * (double)soNgayLam / 22;
        luong = luongCoBan * heSoLuong + soNamLam * 100000;

        return luong;
    }
}

public class NhanVienHopDong : NhanVien, IHoTroLuong
{
    protected int soBuoiLam;

    public NhanVienHopDong(string maNV, string hoTen, string maChucVu, int namVaoLam, int soBuoiLam)
    {
        MaNV = maNV;
        HoTen = hoTen;
        MaChucVu = maChucVu;
        NamVaoLam = namVaoLam;
        this.soBuoiLam = soBuoiLam;
    }

    public override double TinhLuong()
    {
        double luongCoBan = 1000000;
        double luong = 0;
        int soNamLam = DateTime.Now.Year - NamVaoLam;

        double heSoLuong = 1 * (double)soBuoiLam / 44;
        luong = luongCoBan * heSoLuong + soNamLam * 100000;

        return luong;
    }

    public double TinhHoTroLuong()
    {
        if (soBuoiLam >= 44)
        {
            return 1000000;
        }
        else
        {
            return 0;
        }
    }
}

public class NhanVienChuyenGia : NhanVien, IHoTroLuong
{
    protected int soNhomLamViec;

    public NhanVienChuyenGia(string maNV, string hoTen, string maChucVu, int namVaoLam, int soNhomLamViec)
    {
        MaNV = maNV;
        HoTen = hoTen;
        MaChucVu = maChucVu;
        NamVaoLam = namVaoLam;
        this.soNhomLamViec = soNhomLamViec;
    }

    public override double TinhLuong()
    {
        double luongCoBan = 1000000;
        double luong = 0;
        int soNamLam = DateTime.Now.Year - NamVaoLam;

        double heSoLuong = 5 * soNhomLamViec;
        luong = luongCoBan * heSoLuong + soNamLam * 100000;

        return luong;
    }

    public double TinhHoTroLuong()
    {
        if (soNhomLamViec > 3)
        {
            int soNhomVuot = soNhomLamViec - 3;
            int soTienHoTro = Math.Min(soNhomVuot * 1000000, 4000000);
            return soTienHoTro;
        }
        else
        {
            return 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        NhanVienBienChe nvBienChe = new NhanVienBienChe("NV2E4", "Tran Anh", "GD", 2011, 20);
        NhanVienHopDong nvHopDong = new NhanVienHopDong("NV3E5", "Nguyen Van A", "TP", 2013, 30);
        NhanVienChuyenGia nvChuyenGia = new NhanVienChuyenGia("NV4E6", "Le Thi B", "CG", 2012, 4);
        int choice;
        {
            do
            {
                Console.WriteLine("1. Nhân Viên Biên Chế");
                Console.WriteLine("2. Nhân Viên Hợp Đồng");
                Console.WriteLine("3. Nhân Viên Chuyên Gia");
                Console.Write("Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            nvBienChe.HienThiThongTin();
                            Console.WriteLine("Lương nhân viên biên chế: " + nvBienChe.TinhLuong());
                            break;
                        }
                    case 2:
                        {
                            nvHopDong.HienThiThongTin();
                            Console.WriteLine("Lương nhân viên hợp đồng: " + nvHopDong.TinhLuong());
                            Console.WriteLine("Hỗ trợ lương nhân viên hợp đồng: " + nvHopDong.TinhHoTroLuong());
                            break;
                        }
                    case 3:
                        {
                            nvChuyenGia.HienThiThongTin();
                            Console.WriteLine("Lương nhân viên chuyên gia: " + nvChuyenGia.TinhLuong());
                            Console.WriteLine("Hỗ trợ lương nhân viên chuyên gia: " + nvChuyenGia.TinhHoTroLuong());
                            break;
                        }
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }
            } while (choice != 0);
        }




        Console.ReadLine();
    }
}
