using System;

namespace HonSo
{
    class HonSo
    {
        private int phanNguyen;
        private PhanSo phanSo;

        public HonSo()
        {
            phanNguyen = 0;
            phanSo = new PhanSo();
        }

        public HonSo(int phanNguyen)
        {
            this.phanNguyen = phanNguyen;
            phanSo = new PhanSo();
        }

        public HonSo(int phanNguyen, PhanSo phanSo)
        {
            this.phanNguyen = phanNguyen;
            this.phanSo = phanSo;
        }

        public int PhanNguyen
        {
            get { return phanNguyen; }
            set { phanNguyen = value; }
        }

        public PhanSo PhanSo
        {
            get { return phanSo; }
            set { phanSo = value; }
        }

        public void Nhap()
        {
            Console.Write("Nhap phan nguyen: ");
            phanNguyen = int.Parse(Console.ReadLine());
            Console.Write("Nhap phan so: ");
            phanSo.Nhap();
        }

        public void Xuat()
        {
            Console.Write("{0} ", phanNguyen);
            phanSo.Xuat();
        }

        public PhanSo ChuyenDoi()
        {
            PhanSo ketQua = new PhanSo(phanNguyen * phanSo.MauSo + phanSo.TuSo, phanSo.MauSo);
            return ketQua;
        }

        public HonSo ChuyenDoi(PhanSo phanSo)
        {
            int pNguyen = phanSo.TuSo / phanSo.MauSo;
            int pTu = phanSo.TuSo % phanSo.MauSo;
            HonSo ketQua = new HonSo(pNguyen, new PhanSo(pTu, phanSo.MauSo));
            return ketQua;
        }

        public static HonSo operator +(HonSo hs1, HonSo hs2)
        {
            HonSo ketQua = new HonSo();
            ketQua.phanNguyen = hs1.phanNguyen + hs2.phanNguyen;
            ketQua.phanSo = hs1.phanSo + hs2.phanSo;
            return ketQua;
        }

        public static HonSo operator -(HonSo hs1, HonSo hs2)
        {
            HonSo ketQua = new HonSo();
            ketQua.phanNguyen = hs1.phanNguyen - hs2.phanNguyen;
            ketQua.phanSo = hs1.phanSo - hs2.phanSo;
            return ketQua;
        }

        public static HonSo operator *(HonSo hs1, HonSo hs2)
        {
            HonSo ketQua = new HonSo();
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            PhanSo psKetQua = ps1 * ps2;
            ketQua = ketQua.ChuyenDoi(psKetQua);
            return ketQua;
        }

        public static HonSo operator /(HonSo hs1, HonSo hs2)
        {
            HonSo ketQua = new HonSo();
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            PhanSo psKetQua = ps1 / ps2;
            ketQua = ketQua.ChuyenDoi(psKetQua);
            return ketQua;
        }
        public static bool operator >(HonSo hs1, HonSo hs2)
        {
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            return ps1 > ps2;
        }

        public static bool operator <(HonSo hs1, HonSo hs2)
        {
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            return ps1 < ps2;
        }

        public static bool operator >=(HonSo hs1, HonSo hs2)
        {
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            return ps1 >= ps2;
        }

        public static bool operator <=(HonSo hs1, HonSo hs2)
        {
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            return ps1 <= ps2;
        }

        public static bool operator ==(HonSo hs1, HonSo hs2)
        {
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            return ps1 == ps2 && hs1.phanNguyen == hs2.phanNguyen;
        }

        public static bool operator !=(HonSo hs1, HonSo hs2)
        {
            PhanSo ps1 = hs1.ChuyenDoi();
            PhanSo ps2 = hs2.ChuyenDoi();
            return ps1 != ps2 || hs1.phanNguyen != hs2.phanNguyen;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HonSo hs1 = new HonSo();
            HonSo hs2 = new HonSo();

            Console.WriteLine("MENU");
            Console.WriteLine("1. Nhap hon so 1");
            Console.WriteLine("2. Nhap hon so 2");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tinh hieu");
            Console.WriteLine("5. Tinh tich");
            Console.WriteLine("6. Tinh thuong");
            Console.WriteLine("7. So sanh");
            Console.WriteLine("8. Thoat");

            int choice;
            do
            {
                Console.Write("\nNhap lua chon cua ban: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Nhap hon so 1:");
                        hs1.Nhap();
                        break;
                    case 2:
                        Console.WriteLine("Nhap hon so 2:");
                        hs2.Nhap();
                        break;
                    case 3:
                        HonSo tong = hs1 + hs2;
                        Console.Write("Tong hai hon so la: ");
                        tong.Xuat();
                        break;
                    case 4:
                        HonSo hieu = hs1 - hs2;
                        Console.Write("Hieu hai hon so la: ");
                        hieu.Xuat();
                        break;
                    case 5:
                        HonSo tich = hs1 * hs2;
                        Console.Write("Tich hai hon so la: ");
                        tich.Xuat();
                        break;
                    case 6:
                        HonSo thuong = hs1 / hs2;
                        Console.Write("Thuong hai hon so la: ");
                        thuong.Xuat();
                        break;
                    case 7:
                        Console.WriteLine("So sanh hai hon so:");
                        if (hs1 > hs2)
                        {
                            Console.WriteLine("Hon so 1 lon hon hon so 2");
                        }
                        else if (hs1 < hs2)
                        {
                            Console.WriteLine("Hon so 1 nho hon hon so 2");
                        }
                        else
                        {
                            Console.WriteLine("Hai hon so bang nhau");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Cam on ban da su dung chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long nhap lai");
                        break;
                }
            } while (choice != 8);
        }
    }
}

             

