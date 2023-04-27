using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Lớp MixedNumber bao gồm hai thuộc tính: phần nguyên và phần phân số (FractionalPart).
//    Lớp FractionalPart bao gồm hai thuộc tính: tử số(numerator) và mẫu số (denominator), 
//    cùng với các phương thức để rút gọn phân số và xuất phân số dưới dạng chuỗi.

//Lớp Fraction cũng bao gồm hai thuộc tính: tử số và mẫu số,
//    cùng với các phương thức để rút gọn phân số và xuất phân số dưới dạng chuỗi.

//Lớp MixedNumber cũng cung cấp các phương thức để chuyển đổi giữa hỗn số và phân số. 
//    Phương thức ToFraction() chuyển đổi hỗn số thành phân số,
//    trong khi phương thức FromFraction() chuyển đổi phân số thành hỗn số.
namespace Buoi3_PhamHoDangHuy_2001215828
{

    public class MixedNumber
    {
        private int wholePart;
        private FractionalPart fractionalPart;

        // Properties
        public int WholePart
        {
            get { return wholePart; }
            set { wholePart = value; }
        }

        public FractionalPart FractionalPart
        {
            get { return fractionalPart; }
            set { fractionalPart = value; }
        }

        // Constructors
        public MixedNumber()
        {
            wholePart = 0;
            fractionalPart = new FractionalPart(0, 1);
        }

        public MixedNumber(int wholePart)
        {
            this.wholePart = wholePart;
            fractionalPart = new FractionalPart(0, 1);
        }

        public MixedNumber(int wholePart, int numerator, int denominator)
        {
            this.wholePart = wholePart;
            fractionalPart = new FractionalPart(numerator, denominator);
        }

        // Methods
        public void Display()
        {
            Console.WriteLine("{0} {1}", wholePart, fractionalPart.ToString());
        }

        public void Input()
        {
            Console.Write("Enter the whole part: ");
            wholePart = int.Parse(Console.ReadLine());

            Console.Write("Enter the numerator: ");
            int numerator;
            while (!int.TryParse(Console.ReadLine(), out numerator))
            {
                Console.WriteLine("Invalid input! Please enter an integer.");
                Console.Write("Enter the numerator: ");
            }

            Console.Write("Enter the denominator: ");
            int denominator;
            while (!int.TryParse(Console.ReadLine(), out denominator))
            {
                Console.WriteLine("Invalid input! Please enter an integer.");
                Console.Write("Enter the denominator: ");
            }

            fractionalPart = new FractionalPart(numerator, denominator);
        }


        public Fraction ToFraction()
        {
            int numerator = (wholePart * fractionalPart.Denominator) + fractionalPart.Numerator;
            return new Fraction(numerator, fractionalPart.Denominator);
        }

        public static MixedNumber FromFraction(Fraction fraction)
        {
            int wholePart = fraction.Numerator / fraction.Denominator;
            int numerator = fraction.Numerator % fraction.Denominator;
            int denominator = fraction.Denominator;
            return new MixedNumber(wholePart, numerator, denominator);
        }
        // Toán tử
        //public static MixedNumber operator +(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    Fraction result = f1 + f2;
        //    return MixedNumber.FromFraction(result);
        //}

        //public static MixedNumber operator -(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    Fraction result = f1 - f2;
        //    return MixedNumber.FromFraction(result);
        //}

        //public static MixedNumber operator *(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    Fraction result = f1 * f2;
        //    return MixedNumber.FromFraction(result);
        //}

        //public static MixedNumber operator /(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    Fraction result = f1 / f2;
        //    return MixedNumber.FromFraction(result);
        //}

        //public static bool operator >(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    return f1 > f2;
        //}

        //public static bool operator <(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    return f1 < f2;
        //}

        //public static bool operator >=(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    return f1 >= f2;
        //}

        //public static bool operator <=(MixedNumber a, MixedNumber b)
        //{
        //    Fraction f1 = a.ToFraction();
        //    Fraction f2 = b.ToFraction();
        //    return f1 <= f2;
        //}

        public static bool operator ==(MixedNumber a, MixedNumber b)
        {
            Fraction f1 = a.ToFraction();
            Fraction f2 = b.ToFraction();
            return f1 == f2;
        }

        public static bool operator !=(MixedNumber a, MixedNumber b)
        {
            Fraction f1 = a.ToFraction();
            Fraction f2 = b.ToFraction();
            return f1 != f2;
        }

        //public static MixedNumber operator ++(MixedNumber a)
        //{
        //    return a + new MixedNumber(1);
        //}

        //public static MixedNumber operator --(MixedNumber a)
        //{
        //    return a - new MixedNumber(1);
        //}

        public static explicit operator double(MixedNumber a)
        {
            return (double)a.WholePart + ((double)a.FractionalPart.Numerator / (double)a.FractionalPart.Denominator);
        }

        public static explicit operator MixedNumber(double d)
        {
            int wholePart = (int)Math.Floor(d);
            double fraction = d - wholePart;
            int numerator = (int)(fraction * 1000);
            int denominator = 1000;
            return new MixedNumber(wholePart, numerator, denominator);
        }

    }

    public class FractionalPart
    {
        private int numerator;
        private int denominator;

        // Properties
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }

        // Constructors
        public FractionalPart()
        {
            numerator = 0;
            denominator = 1;
        }

        public FractionalPart(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        // Methods
        public void Simplify()
        {
            int gcd = Gcd(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
        }

        private int Gcd(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            return Gcd(b, a % b);
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
    }

    public class Fraction
    {
        private int numerator;
        private int denominator;

        // Properties
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set { denominator = value; }
        }
        // Constructors
        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }

            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        // Methods
        private void Simplify()
        {
            int gcd = Gcd(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
        }

        private int Gcd(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            return Gcd(b, a % b);
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }

    }
}