using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HinhTron
{
    class HinhTron
    {
        private double banKinh;

        public HinhTron(double banKinh)
        {
            this.banKinh = banKinh;
        }

        public double TinhChuVi()
        {
            return 2 * Math.PI * banKinh;
        }

        public double TinhDienTich()
        {
            return Math.PI * Math.Pow(banKinh, 2);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            HinhTron ht = new HinhTron(5.0);
            Console.WriteLine("Chu vi hinh tron: " + ht.TinhChuVi());
            Console.WriteLine("Dien tich hinh tron: " + ht.TinhDienTich());
        }
    }
}
