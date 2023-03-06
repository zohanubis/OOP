using System;
//Bài 3 : Xây dựng lớp NgayThang lưu trữ ngày tháng năm năm với các phương thức 
//- Phương thức khởi tạo mặc định, phương thức khởi tạo 3 tham số
//- Kiếm tra năm nhuận, xác định ngày hôm sau của đổi tượng hiện hành
public class NgayThang
{
    private int ngay;
    private int thang;
    private int nam;

    public NgayThang()
    {
        ngay = 1;
        thang = 1;
        nam = 2000;
    }

    public NgayThang(int ngay, int thang, int nam)
    {
        this.ngay = ngay;
        this.thang = thang;
        this.nam = nam;
    }

    public bool LaNamNhuan()
    {
        if ((nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0)
        { // nam chia hết cho 4 và ko chia hết cho 100 hoặc chia hết cho 400 thi la năm nhuận
            return true;
        }
        else
        {
            return false;
        }
    }

    public NgayThang NgayHomSau()
    {
        int soNgayTrongThang = 0;
        switch (thang)
        {
            case 2:
                if (LaNamNhuan())
                {
                    soNgayTrongThang = 29;
                }
                else
                {
                    soNgayTrongThang = 28;
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                soNgayTrongThang = 30;
                break;
            default:
                soNgayTrongThang = 31;
                break;
        }

        NgayThang ngayHomSau = new NgayThang();
        if (ngay == soNgayTrongThang)
        {
            if (thang == 12)
            {
                ngayHomSau.ngay = 1;
                ngayHomSau.thang = 1;
                ngayHomSau.nam = nam + 1;
            }
            else
            {
                ngayHomSau.ngay = 1;
                ngayHomSau.thang = thang + 1;
                ngayHomSau.nam = nam;
            }
        }
        else
        {
            ngayHomSau.ngay = ngay + 1;
            ngayHomSau.thang = thang;
            ngayHomSau.nam = nam;
        }

        return ngayHomSau;
    }

    public override string ToString()
    {
        return ngay.ToString() + "/" + thang.ToString() + "/" + nam.ToString();
    }

    public void Nhap()
    {
        Console.Write("Nhap ngay: ");
        ngay = int.Parse(Console.ReadLine());

        Console.Write("Nhap thang: ");
        thang = int.Parse(Console.ReadLine());

        Console.Write("Nhap nam: ");
        nam = int.Parse(Console.ReadLine());
    }
}

class Program
{
    static void Main(string[] args)
    {
        NgayThang ngay = new NgayThang();
        ngay.Nhap();
        Console.WriteLine("Nam " + (ngay.LaNamNhuan() ? "" : "khong ") + "la nam nhuan.");
        Console.WriteLine("Ngay hom sau la: " + ngay.NgayHomSau().ToString());
    }
}
