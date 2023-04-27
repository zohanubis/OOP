using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_PhamHoDangHuy_2001215828
{
    class NhanVien
    {
        string ms, ht;
        public string Ms
        {
            get { return ms; }
            set { ms = value; }
        }
        public string Ht
        {
            get { return ht; }
            set { ht = value; }
        }
        int nc;
        public int Nc
        {
            get { return nc; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Dữ liệu sai");
                    nc = 0;
                }
                else
                {
                    nc = value;
                }
            }
        }
        public char Xl
        {
            get
            {
                if (nc >= 26) return 'A';
                else if (nc >= 22) return 'B';
                else return 'C';
            }

        }
        public static int LuongNgay = 200000;
        public NhanVien()
        {
            Ms = Ht = "";
            Nc = 0;
        }
        public NhanVien(string ht, string ms, int nc)
        {
            this.Ht = ht;
            this.Ms = ms;
            this.Nc = nc;
        }
        public NhanVien(NhanVien a)
        {
            this.Ht = a.Ht;
            this.Ms = a.Ms;
            this.Nc = a.Nc;
        }
        ~NhanVien() { }
        public void input()
        {
            Console.Write("Nhap ma so :");
            Ms = Console.ReadLine();
            Console.Write("Nhap ho ten :");
            Ht = Console.ReadLine();
            Console.Write("Nhap so ngay cong :");
            Nc = int.Parse(Console.ReadLine());
        }
        public void output()
        {
            Console.WriteLine("{0},{1},{2},{3},{4}", ms, ht, nc, Xl, tinhLuong());
        }
        public int tinhLuong() { return nc * LuongNgay; }
        public float tinhThuong()
        {
            if (Xl == 'A') return tinhLuong() * 5 / 100;
            else if (Xl == 'B') return tinhThuong() * 2 / 100;
            else return 0;
        }
    }
}
