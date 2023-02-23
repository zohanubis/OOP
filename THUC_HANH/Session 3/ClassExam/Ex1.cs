using System;

namespace Fraction
{
    class PS
    {
        private int numerator;  // tử số
        private int denominator; // mẫu số

        // Phương thức khởi tạo
        public PS()
        {
            numerator = 0;
            denominator = 1;
        }

        public PS(int num, int den)
        {
            numerator = num;
            denominator = den;
        }

        public PS(int num)
        {
            numerator = num;
            denominator = 1;
        }

        //Thuộc Tính
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value != 0)
                {
                    denominator = value;
                }
                else
                {
                    throw new ArgumentException("denominator cannot be zero.");
                }
            }
        }

        public void Input()
        {
            Console.Write("Enter numerator: ");
            numerator = int.Parse(Console.ReadLine());
            Console.Write("Enter denominator: ");
            denominator = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine("{0}/{1}", numerator, denominator);
        }
        public static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            else if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        // Rút gọn phan so
        public void Simplify()
        {
            int gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }
        // Cong 2 phan so
        public PS Add(PS other)
        {
            int num = numerator * other.denominator + other.numerator * denominator;
            int den = denominator * other.denominator;
            PS result = new PS(num, den);
            result.Simplify();
            return result;
        }
        // Tru 2 phan so
        public PS Subtract(PS other)
        {
            int num = numerator * other.denominator - other.numerator * denominator;
            int den = denominator * other.denominator;
            PS result = new PS(num, den);
            result.Simplify();
            return result;
        }
        // Nhan 2 phan so
        public PS Multiply(PS other)
        {
            int num = numerator * other.numerator;
            int den = denominator * other.denominator;
            PS result = new PS(num, den);
            result.Simplify();
            return result;
        }
        // Chia 2 phan so
        public PS Divide(PS other)
        {
            int num = numerator * other.denominator;
            int den = denominator * other.numerator;
            PS result = new PS(num, den);
            result.Simplify();
            return result;
        }
        // So sanh 2 phan so
        public int CompareTo(PS other)
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
        public static PS operator +(PS p1, PS p2)
        {
            return p1.Add(p2);
        }

        public static PS operator -(PS p1, PS p2)
        {
            return p1.Subtract(p2);
        }

        public static PS operator *(PS p1, PS p2)
        {
            return p1.Multiply(p2);
        }
        public static PS operator /(PS p1, PS p2)
        {
            return p1.Divide(p2);
        }

        public static bool operator >(PS p1, PS p2)
        {
            return p1.CompareTo(p2) > 0;
        }

        public static bool operator <(PS p1, PS p2)
        {
            return p1.CompareTo(p2) < 0;
        }

        public static bool operator >=(PS p1, PS p2)
        {
            return p1.CompareTo(p2) >= 0;
        }

        public static bool operator <=(PS p1, PS p2)
        {
            return p1.CompareTo(p2) <= 0;
        }

        public static bool operator ==(PS p1, PS p2)
        {
            if (ReferenceEquals(p1, null))
            {
                return ReferenceEquals(p2, null);
            }
            return p1.Equals(p2);
        }

        public static bool operator !=(PS p1, PS p2)
        {
            return !(p1 == p2);
        }

        public static PS operator ++(PS p)
        {
            return p + new PS(1);
        }

        public static PS operator --(PS p)
        {
            return p - new PS(1);
        }

        public static explicit operator int(PS p)
        {
            return p.ToInt();
        }

        public static explicit operator double(PS p)
        {
            return p.ToDouble();
        }

        public static implicit operator PS(int num)
        {
            return new PS(num);
        }
        // Chuyen doi double sang phan so
        public static implicit operator PS(double num)
        {
            int den = 1;
            while (Math.Round(num * den) != num * den)
            {
                den *= 10;
            }
            // Tim duoc so nguyen chuyen double sang INT
            int numInt = (int)(num * den);
            return new PS(numInt, den);
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
                // Find the nearest integer
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
        public void ToMixedNumber(out int whole, out PS properFraction)
        {
            whole = ToInt();
            properFraction = new PS(numerator % denominator, denominator);
            properFraction.Simplify();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PS p1 = new PS();
            PS p2 = new PS();
            PS result;
            int choice;

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
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Nhap phan so 1:");
                        p1.Input();
                        Console.WriteLine("Nhap phan so 2:");
                        p2.Input();
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
                        Console.WriteLine("Phan so 1 chyyen sang so nguyen: {0} , {1}", p1.ToInt(),p2.ToInt());
                        break;
                    case 9:
                        Console.WriteLine("Phan so 1 va 2 chuyen sang thap phan: {0} , {1}", p1.ToDouble(),p2.ToDouble());
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
                        PS properFraction;
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
            } while (choice != 15);
        }
    }
}
