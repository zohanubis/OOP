using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_PhamHoDangHuy_2001215828
{
    class HinhTron
    {
        private double r;
        private double R
        {
            get { return r; }
            set
            {
                if (value < 0)
                {
                    Console.Write("Du lieu bi loi");
                    r = 0;
                }
                else
                {
                    r = value;
                }
            }
        }
        public HinhTron() { this.r = 0; }
        public HinhTron(double r) { this.r = r; }
        public void input()
        {
            Console.Write("Nhập bán kính : ");
            this.r = double.Parse(Console.ReadLine());
        }
        public double tinhChuVi()
        {
            return this.r * 2 * Math.PI;
        }
        public double tinhDienTich()
        {
            return Math.Pow(this.r, 2) * Math.PI;
        }
        public void output()
        {
            Console.WriteLine("Hình tròn có bán kính :{0:0.00}", r);
            Console.WriteLine("Chu vi : {0:0.00}", tinhChuVi());
            Console.WriteLine("Diện tích : {0:0.00}", tinhDienTich());

        }
    }
}
