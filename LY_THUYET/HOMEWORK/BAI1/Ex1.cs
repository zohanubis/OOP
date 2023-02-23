// Phạm Hồ Đăng Huy - 2001215828
//Bài tập 1: Xây dựng điểm trong không gian 2 chiều Oxy với phương thức tính khoảng các từ điểm
//đó tới gốc tọa độ.
//Bài tập 2: Viết hàm xây dựng lớp phân số trong toán học với các phương thức nhập, xuất, rút gọn.
//Bài tập 3: Một thí sinh dự thi chứng chỉ Tin học gồm có các thông tin họ và tên, số báo danh,
//năm sinh, điểm thi lý thuyết, điểm thi thực hành. Thí sinh sẽ có kết quả đậu
//nếu tổng điểm lớn hơn 10 và không có môn nào dưới 2. Hãy xây dựng lớp Thí  sinh.
using System;
using System.Runtime.Intrinsics.Arm;

class Point
{
    public int x; public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public double DistanceToOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }
}
class PhanSo
{
    private int numerator;
    private int denominator;

    public PhanSo()
    {
        numerator = 0;
        denominator = 0;
    }
    public PhanSo(int tuSo, int mauSo)
    {
        numerator = tuSo;
        denominator = mauSo;
    }
    public PhanSo(int tuSo)
    {
        numerator = tuSo;
        denominator = 1;
    }
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }
    public int Denominator 
    { get 
        { return denominator; } 
        set
        {
            if(value != 0)
            {
                denominator = value;
            }
            else
            {
                throw new ArgumentException("Mau so khong the bang 0 ");
            }
        }
    }
    public void Input()
    {
        Console.Write("Nhap tu so : ");
        numerator = int.Parse(Console.ReadLine());
        Console.Write("Nhap mau so : ");
        denominator = int.Parse(Console.ReadLine());
    }
    public void Output()
    {
        Console.WriteLine("{0}/{1}", numerator,denominator);
    }
    public static int GCD(int a, int b)
    {
        if (a == 0) return b;
            else if(b == 0) return a;
                else return GCD(b,a % b);
    }
    public void Simplify()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }
    // Cong 2 phan so
    public PhanSo Add(PhanSo other)
    {
        int num = numerator * other.denominator + other.numerator * denominator;
        int den = denominator * other.denominator;
        PhanSo result = new PhanSo(num, den);
        result.Simplify();
        return result;
    }
    // Tru 2 phan so
    public PhanSo Subtract(PhanSo other)
    {
        int num = numerator * other.denominator - other.numerator * denominator;
        int den = denominator * other.denominator;
        PhanSo result = new PhanSo(num, den);
        result.Simplify();
        return result;
    }
    // Nhan 2 phan so
    public PhanSo Multiply(PhanSo other)
    {
        int num = numerator * other.numerator;
        int den = denominator * other.denominator;
        PhanSo result = new PhanSo(num, den);
        result.Simplify();
        return result;
    }
    // Chia 2 phan so
    public PhanSo Divide(PhanSo other)
    {
        int num = numerator * other.denominator;
        int den = denominator * other.numerator;
        PhanSo result = new PhanSo(num, den);
        result.Simplify();
        return result;
    }
    // So sanh 2 phan so
    public int CompareTo(PhanSo other)
    {
        int num1 = numerator * other.denominator;
        int num2 = other.numerator * denominator;
        return num1.CompareTo(num2);
    }
    // Chuyen phan so thanh so nguyen
    public int ToInt()
    {
        return numerator / denominator;
    }
    // Chuyen phan so thanh so thap phan
    public double ToDouble()
    {
        return (double)numerator / denominator;
    }
    // Operator + - * / nạp chồng các toán tử số học để tính toán 2 phan so
    public static PhanSo operator +(PhanSo p1, PhanSo p2)
    {
        return p1.Add(p2);
    }

    public static PhanSo operator -(PhanSo p1, PhanSo p2)
    {
        return p1.Subtract(p2);
    }

    public static PhanSo operator *(PhanSo p1, PhanSo p2)
    {
        return p1.Multiply(p2);
    }
    public static PhanSo operator /(PhanSo p1, PhanSo p2)
    {
        return p1.Divide(p2);
    }

    public static bool operator >(PhanSo p1, PhanSo p2)
    {
        return p1.CompareTo(p2) > 0;
    }

    public static bool operator <(PhanSo p1, PhanSo p2)
    {
        return p1.CompareTo(p2) < 0;
    }

    public static bool operator >=(PhanSo p1, PhanSo p2)
    {
        return p1.CompareTo(p2) >= 0;
    }

    public static bool operator <=(PhanSo p1, PhanSo p2)
    {
        return p1.CompareTo(p2) <= 0;
    }

    public static bool operator ==(PhanSo p1, PhanSo p2)
    {
        if (ReferenceEquals(p1, null))
        {
            return ReferenceEquals(p2, null);
        }
        return p1.Equals(p2);
    }

    public static bool operator !=(PhanSo p1, PhanSo p2)
    {
        return !(p1 == p2);
    }

    public static PhanSo operator ++(PhanSo p)
    {
        return p + new PhanSo(1);
    }

    public static PhanSo operator --(PhanSo p)
    {
        return p - new PhanSo(1);
    }

    public static explicit operator int(PhanSo p)
    {
        return p.ToInt();
    }

    public static explicit operator double(PhanSo p)
    {
        return p.ToDouble();
    }

    public static implicit operator PhanSo(int num)
    {
        return new PhanSo(num);
    }
    // Chuyen doi double sang phan so
    public static implicit operator PhanSo(double num)
    {
        int den = 1;
        while (Math.Round(num * den) != num * den)
        {
            den *= 10;
        }
        // Tim duoc so nguyen chuyen double sang INT
        int numInt = (int)(num * den);
        return new PhanSo(numInt, den);
    }

    public void Power(int n)
    {
        // Tinh luy thua cua phan so
        numerator = (int)Math.Pow(numerator, n);
        denominator = (int)Math.Pow(denominator, n);
        Simplify();
    }
    // Chuyen phan so hien tai thanh so nguyen gan nhat
    public int ToNearestInt()
    {
        int quotient = numerator / denominator;    // Phan nguyen
        int remainder = numerator % denominator; // modulo remainder (phan du)
        if (remainder == 0)
        {
            return quotient;
        }
        else
        {
            int nearestInt;
            // So sanh gia tri cua 2 phan du
            if (Math.Abs(remainder * 2) < Math.Abs(denominator))
            {
                nearestInt = quotient;
            }
            else if (numerator > 0)
            {
                // numerator >> 1 cong them 1 voi gia tri ban dau
                nearestInt = quotient + 1;
            }
            else
            {
                // numerator < 1 giam gia tri ban dau
                nearestInt = quotient - 1;
            }
            return nearestInt;
        }
    }
    // Chuyen phan so thanh hon so 
    public void ToMixedNumber(out int whole, out PhanSo properFraction)
    {
        whole = ToInt();
        properFraction = new PhanSo(numerator % denominator, denominator);
        properFraction.Simplify();
    }
}
class ThiSinh
{
    public string HoTen { get; set; }
    public string SoBaoDanh { get; set; }
    public int NamSinh { get; set; }
    public double DiemLyThuyet { get; set; }
    public double DiemThucHanh {  get; set; }
    public ThiSinh()
    {

    }
    public ThiSinh(string hoTen, string soBaoDanh, int namSinh, double diemLyThuyet, double diemThucHanh)
    {
        this.HoTen = hoTen;
        this.SoBaoDanh = soBaoDanh;
        this.NamSinh = namSinh;
        this.DiemLyThuyet = diemLyThuyet;
        this.DiemThucHanh = diemThucHanh;
    }
    public double TinhTongDiem()
    {
        return this.DiemLyThuyet + this.DiemThucHanh;
    }
    public bool KiemTraDau()
    {
        if(this.TinhTongDiem() >= 10 && this.DiemLyThuyet >= 2 && this.DiemThucHanh >= 2)
        { return true; }
        return false;
    }
    public void NhapThongTin()
    {
        Console.Write("Nhap ho ten: ");
        this.HoTen = Console.ReadLine();

        Console.Write("Nhap so bao danh: ");
        this.SoBaoDanh = Console.ReadLine();

        Console.Write("Nhap nam sinh: ");
        this.NamSinh = int.Parse(Console.ReadLine());

        Console.Write("Nhap diem ly thuyet: ");
        this.DiemLyThuyet = double.Parse(Console.ReadLine());

        Console.Write("Nhap diem thuc hanh: ");
        this.DiemThucHanh = double.Parse(Console.ReadLine());
    }

}
class Program
{
    static void Main(string[] args)
    {
        ThiSinh ts = new ThiSinh();
        int choice = 0;
        int choicePS = 0;
        PhanSo p1 = new PhanSo();
        PhanSo p2 = new PhanSo();
        PhanSo result;
        do
        {
            Console.WriteLine("1. Tinh khoang cach cua 2 diem toa do Oxy ");
            Console.WriteLine("2. Phan so");
            Console.WriteLine("3. Thi sinh");
            Console.WriteLine("0. Thoat chuong trinh");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Lua chon khong hop le , chon lai");
                continue;
            } 
            switch (choice)
            {
                case 1:
                    Console.Write("Nhap gia tri x : ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Nhap gia tri y : ");
                    int y = int.Parse(Console.ReadLine());

                    Point p = new Point(x, y);
                    double distance = p.DistanceToOrigin();
                    Console.WriteLine("Khoang cach den cac diem : " + distance);
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("\n------ MENU ------");
                        Console.WriteLine("1. Nhap phan so 1 va 2");
                        Console.WriteLine("2. Rut gon phan so 1 va 2");
                        Console.WriteLine("3. Cong hai phan so");
                        Console.WriteLine("4. Tru hai phan so");
                        Console.WriteLine("5. Nhan hai phan so");
                        Console.WriteLine("6. Chia hai phan so");
                        Console.WriteLine("7. So sánh hai phan so");
                        Console.WriteLine("8. Chuyen phan so 1 thanh so nguyen");
                        Console.WriteLine("9. Chuyen phan so 2 thanh so thap phan");
                        Console.WriteLine("10. Tinh phan so 1 thanh luy thua n");
                        Console.WriteLine("11. Chuyen phan so 1 thanh so nguyen gan nhat");
                        Console.WriteLine("12. Chuyen phan so 2 thanh phan so hon hop");
                        Console.WriteLine("13. Thoat");
                        Console.Write("Nhap lua chon: ");
                        choicePS = int.Parse(Console.ReadLine());

                        switch (choicePS)
                        {
                            case 1:
                                Console.WriteLine("Nhap phan so 1:");
                                p1.Input();
                                Console.WriteLine("Nhap phan so 2:");
                                p2.Input();
                                Console.WriteLine("2 Phan so vua nhap ");
                                p1.Output();
                                p2.Output();
                                break;
                            case 2:
                                Console.WriteLine("Phan so truoc khi rut gon:");
                                p1.Output();
                                p1.Simplify();
                                Console.WriteLine("Phan so 1 sau khi rut gon:");
                                p1.Output();
                                Console.WriteLine("Phan so 2 truoc khi rut gon:");
                                p2.Output();
                                p2.Simplify();
                                Console.WriteLine("Phan so 2 sau khi rut gon:");
                                p2.Output();
                                break;
                            case 3:
                                result = p1 + p2;
                                Console.Write("Ket qua cong 2 phan so: ");
                                result.Output();
                                break;
                            case 4:
                                result = p1 - p2;
                                Console.Write("Ket qua tru 2 phan so: ");
                                result.Output();
                                break;
                            case 5:
                                result = p1 * p2;
                                Console.Write("Ket qua nhan 2 phan so: ");
                                result.Output();
                                break;
                            case 6:
                                result = p1 / p2;
                                Console.Write("Ket qua chia 2 phan so: ");
                                result.Output();
                                break;
                            case 7:
                                int cmp = p1.CompareTo(p2);
                                if (cmp == 0)
                                {
                                    Console.WriteLine("2 phan so bang nhau.");
                                }
                                else if (cmp < 0)
                                {
                                    Console.WriteLine("Phan so 1 < phan so 2.");
                                }
                                else
                                {
                                    Console.WriteLine("Phan so 1 > phan so 2");
                                }
                                break;
                            case 8:
                                Console.WriteLine("Phan so 1 chyyen sang so nguyen: {0} , {1}", p1.ToInt(), p2.ToInt());
                                break;
                            case 9:
                                Console.WriteLine("Phan so 1 va 2 chuyen sang thap phan: {0} , {1}", p1.ToDouble(), p2.ToDouble());
                                break;
                            case 10:
                                int n;
                                Console.Write("Nhap luy thua n: ");
                                n = int.Parse(Console.ReadLine());
                                p1.Power(n);
                                p2.Power(n);
                                Console.Write("Ket qua luy thua n cua phan so 1 :");
                                p1.Output();
                                Console.Write("Ket qua luy thua n cua phan so 2 :");
                                p2.Output();
                                break;
                            case 11:
                                int nearestInt = p1.ToNearestInt();
                                Console.WriteLine("Chuyen phan so 1 va 2 ve so nguyen gan no nhat: {0} , {1} ", nearestInt, p2.ToNearestInt());
                                break;
                            case 12:
                                int whole;
                                PhanSo properFraction;
                                p2.ToMixedNumber(out whole, out properFraction);
                                Console.WriteLine("Chuyen 2 phan so thanh hon so: {0} va {1}", whole, properFraction);
                                break;
                            case 13:
                                Console.WriteLine("Thoat chuong trinh");
                                break;
                            default:
                                Console.WriteLine("Vui long nhap lai.");
                                break;
                        }
                    } while (choicePS != 14);
                    break;
                case 3:
                    Console.WriteLine("Nhap thong tin thi sinh : ");
                    ts.NhapThongTin();

                    if(ts.KiemTraDau())
                    {
                        Console.WriteLine("Thi sinh " + ts.HoTen + "da dau");
                    }
                    else
                    {
                        Console.WriteLine("Thi sinh " + ts.HoTen + "khong dau");
                    }
                    Console.ReadLine();
                    break;
            }

        } while (choice != 0 && choice <= 3);
    }
}