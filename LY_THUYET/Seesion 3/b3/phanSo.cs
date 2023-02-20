using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Fraction(int numerator, int denominator): Hàm khởi tạo để tạo ra một phân số với tử số numerator và mẫu số denominator. Trong trường hợp mẫu số bằng 0, nó sẽ ném ra một ngoại lệ.

/*Numerator: Thuộc tính để lấy hoặc thiết lập giá trị tử số của phân số.

Denominator: Thuộc tính để lấy hoặc thiết lập giá trị mẫu số của phân số. Nếu giá trị mẫu số được thiết lập thành 0, thì giá trị sẽ không được cập nhật.

Reduce(): Hàm để rút gọn phân số. Nó sử dụng phương pháp tìm ước chung lớn nhất (GCD) để chia tử số và mẫu số của phân số cho ước chung lớn nhất đó, sao cho phân số không thay đổi giá trị.

GCD(int a, int b): Hàm để tính ước chung lớn nhất (GCD) của hai số nguyên dương a và b. Hàm sử dụng phương pháp Euclid để tìm GCD của hai số.

operator+, operator-, operator*, và operator/: Các toán tử để thực hiện các phép tính toán cộng, trừ, nhân và chia giữa hai phân số.

ToString(): Hàm để chuyển đổi giá trị phân số thành chuỗi ký tự để có thể hiển thị cho người dùng. Hàm trả về tử số của phân số nếu mẫu số bằng 1 và chuỗi "numerator/denominator" trong trường hợp khác.

Main(): Hàm chính của chương trình, sử dụng để tạo các đối tượng phân số và thực hiện các phép tính cộng, trừ, nhân và chia giữa chúng.*/
namespace PhânSố
{
    using System;

    public class Fraction
    {
        private int _numerator;
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }

            _numerator = numerator;
            _denominator = denominator;
            Reduce();
        }

        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; Reduce(); }
        }

        public int Denominator
        {
            get { return _denominator; }
            set { if (value != 0) _denominator = value; Reduce(); }
        }

        public void Reduce()
        {
            int gcd = GCD(_numerator, _denominator);
            _numerator /= gcd;
            _denominator /= gcd;
            if (_denominator < 0)
            {
                _numerator *= -1;
                _denominator *= -1;
            }
        }

        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int numerator = (f1.Numerator * f2.Denominator) + (f2.Numerator * f1.Denominator);
            int denominator = f1.Denominator * f2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int numerator = (f1.Numerator * f2.Denominator) - (f2.Numerator * f1.Denominator);
            int denominator = f1.Denominator * f2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Numerator;
            int denominator = f1.Denominator * f2.Denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator;
            int denominator = f1.Denominator * f2.Numerator;
            return new Fraction(numerator, denominator);
        }

        public override string ToString()
        {
            if (_denominator == 1)
            {
                return _numerator.ToString();
            }
            else
            {
                return _numerator + "/" + _denominator;
            }
        }
    }
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public Fraction Add(Fraction other)
        {
            int resultNumerator = this.numerator * other.denominator + other.numerator * this.denominator;
            int resultDenominator = this.denominator * other.denominator;
            return new Fraction(resultNumerator, resultDenominator);
        }

        // Thêm phương thức ToString để hiển thị phân số dưới dạng chuỗi
        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(3, 4);

            Fraction f3 = f1 + f2;
            Console.WriteLine("{0} + {1} = {2}", f1, f2, f3);

            Fraction f4 = f1 - f2;
            Console.WriteLine("{0} - {1} = {2}", f1, f2, f4);

            Fraction f5 = f1 * f2;
            Console.WriteLine("{0} * {1} = {2}", f1, f2, f5);

            Fraction f6 = f1 / f2;
            Console.WriteLine("{0} / {1} = {2}", f1, f2, f6);
        }

    }
}