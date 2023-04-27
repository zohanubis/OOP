
using System;
using System.Text;

namespace Buoi2_PhamHoDangHuy_2001215828
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            int choicemenu;
            do
            {
                Console.WriteLine("----------------------------------------------|");
                Console.WriteLine("1. Bài Tập Trên Lớp ");
                Console.WriteLine("2. Bài Tập Về Nhà");
                Console.WriteLine("----------------------------------------------|");
                Console.Write("Nhập lựa chọn menu bài tập : ");
                choicemenu = int.Parse(Console.ReadLine());
                switch (choicemenu)
                {
                    case 1:
                        {
                            int choicetl;
                            do
                            {
                                Console.WriteLine("----------------------------------------------|");
                                Console.WriteLine("1. Xây dựng lớp hình tròn");
                                Console.WriteLine("2. Xây dựng lớp Nhân Viên");
                                Console.WriteLine("3. Xây dựng lớp Nước");
                                Console.WriteLine("----------------------------------------------|");
                                Console.Write("Nhập lựa chọn bài tập trên lớp : ");

                                choicetl = int.Parse(Console.ReadLine());
                                switch (choicetl)
                                {
                                    case 1:
                                        {
                                            HinhTron a = new HinhTron();
                                            a.input();
                                            a.output();
                                            HinhTron b = new HinhTron(5.0f);
                                            Console.WriteLine("Chu vi : {0:0.00}", b.tinhChuVi());
                                            Console.WriteLine("Diện tích : {0:0.00}", b.tinhDienTich());
                                            break;
                                        }
                                    case 2:

                                        {
                                            NhanVien nv = new NhanVien();
                                            nv.input();
                                            nv.output();
                                            Console.WriteLine("Luong cua nhan vien : " + nv.tinhLuong());
                                            Console.WriteLine("Luong thuong cua nhan vien : " +nv.tinhThuong());
                                            break;
                                        }
                                    case 3:
                                        {
                                            NuocGiaiKhat nuoc1 = new NuocGiaiKhat("Coca", "chai", 50, 10000);
                                            NuocGiaiKhat nuoc2 = new NuocGiaiKhat("Pepsi", "lon", 20, 15000);

                                            nuoc1.XuatThongTin();
                                            nuoc2.XuatThongTin();

                                            Console.WriteLine("Thanh tien nuoc 1: " + nuoc1.TinhThanhTien());
                                            Console.WriteLine("Thanh tien nuoc 2: " + nuoc2.TinhThanhTien());

                                            nuoc1.XuatFile("nuoc1.txt");
                                            nuoc2.XuatFile("nuoc2.txt");

                                            Console.WriteLine("Doc file nuoc1.txt:");
                                            nuoc1.DocFile("nuoc1.txt");
                                            Console.WriteLine("Doc file nuoc2.txt:");
                                            nuoc2.DocFile("nuoc2.txt");

                                            //Console.WriteLine("Nhap du lieu nuoc3:");
                                            //NuocGiaiKhat nuoc3 = new NuocGiaiKhat();
                                            //nuoc3.NhapFile("nuoc3.txt");

                                            //Console.WriteLine("Xuat du lieu nuoc3:");
                                            //nuoc3.XuatFile("nuoc3.txt");
                                            break;
                                        }
                                }

                            } while (choicetl != 0);
                            break;
                        }
                    case 2:
                        {
                            int choicetl;
                            do
                            {
                                Console.WriteLine("----------------------------------------------|");
                                Console.WriteLine("4. Xây dựng lớp hình chữ nhật");
                                Console.WriteLine("5. Xây dựng lớp Time");
                                Console.WriteLine("6. Xây dựng lớp vận động viên");
                                Console.WriteLine("----------------------------------------------|");
                                Console.Write("Nhập lựa chọn bài tập về nhà : ");
                                choicetl = int.Parse(Console.ReadLine());
                                switch (choicetl)
                                {

                                    case 4:
                                        {
                                            HCN h = new HCN();
                                            h.Input();
                                            h.Output();

                                            Console.WriteLine("Enter the length and width to change the size:");
                                            int tl = int.Parse(Console.ReadLine());
                                            int tw = int.Parse(Console.ReadLine());

                                            Console.WriteLine("Enter 1 to increase the size, 0 to decrease the size:");
                                            int type = int.Parse(Console.ReadLine());

                                            h.changeSize(tl, tw, type);
                                            h.Output();

                                            HCN h1 = new HCN();
                                            h1.Input();
                                            h1.Output();

                                            Console.WriteLine("Enter 1 to add the size, 0 to subtract the size:");
                                            int type1 = int.Parse(Console.ReadLine());

                                            h.changeSize(h1, type1);
                                            h.Output();
                                            break;
                                        }
                                    case 5:
                                        {
                                            int choice = 0;

                                            Time t = new Time(12, 30, 45);

                                            do
                                            {
                                                Console.WriteLine("MENU");
                                                Console.WriteLine("1. In thoi gian theo dang 24h");
                                                Console.WriteLine("2. In thoi gian theo dang 12h");
                                                Console.WriteLine("3. Kiem tra gio co hop le khong");
                                                Console.WriteLine("4. Tang gio");
                                                Console.WriteLine("5. Giam gio");
                                                Console.WriteLine("0. Thoat chuong trinh");
                                                Console.Write("Chon cau ban muon : ");

                                                try
                                                {
                                                    choice = Convert.ToInt32(Console.ReadLine());
                                                }
                                                catch (FormatException)
                                                {
                                                    Console.WriteLine("Lua chon khong hop le, chon lai.");
                                                    continue;
                                                }

                                                switch (choice)
                                                {
                                                    case 1:
                                                        Console.WriteLine("Thoi gian hien tai la : ");
                                                        t.Output24();
                                                        break;

                                                    case 2:
                                                        Console.WriteLine("Thoi gian hien tai la: ");
                                                        t.Output12();
                                                        break;

                                                    case 3:
                                                        if (t.IsTimeValid())
                                                            Console.WriteLine("Gio hop le.");
                                                        else
                                                            Console.WriteLine("Gio khong hop le.");
                                                        break;

                                                    case 4:
                                                        Console.Write("Nhap so giay muon tang: ");
                                                        int sec = int.Parse(Console.ReadLine());
                                                        Console.Write("Chon dinh dang (12h | 24h): ");
                                                        string format = Console.ReadLine();
                                                        t.AddSeconds(sec, format);
                                                        break;

                                                    case 5:
                                                        Console.Write("Nhap so giay muon giam : ");
                                                        sec = int.Parse(Console.ReadLine());
                                                        Console.Write("Chon dinh dang (12h | 24h): ");
                                                        format = Console.ReadLine();
                                                        t.SubtractSeconds(sec, format);
                                                        break;

                                                    case 0:
                                                        Console.WriteLine("Cam on da su dung chuong trinh");
                                                        break;

                                                    default:
                                                        Console.WriteLine("Lua chon khong hop le, chon lai.");
                                                        break;
                                                }

                                                Console.WriteLine();
                                            } while (choice != 0);
                                            break;
                                        }
                                    case 6:
                                        {
                                            Runner[] runners = null;

                                            int choice;
                                            do
                                            {
                                                Console.WriteLine("===== MENU =====");
                                                Console.WriteLine("1. Nhap thong tin van dong vien tu file");
                                                Console.WriteLine("2. Nhap thong tin van dong vien");
                                                Console.WriteLine("3. Xuat thong tin van dong vien");
                                                Console.WriteLine("4. Thoat");
                                                Console.Write("Nhap lua chon cua ban (1-3): ");
                                                choice = int.Parse(Console.ReadLine());

                                                switch (choice)
                                                {
                                                    case 1:
                                                        runners = Runner.ReadFromFile("vdv.txt");
                                                        if (runners != null)
                                                        {
                                                            foreach (Runner runner in runners)
                                                            {
                                                                runner.XuatThongTin();
                                                            }
                                                        }
                                                        break;
                                                    case 2:
                                                        if (runners == null) runners = new Runner[0];

                                                        Console.Write("Nhap so van dong vien: ");
                                                        int n = int.Parse(Console.ReadLine());
                                                        Runner[] newRunners = new Runner[n];

                                                        for (int i = 0; i < n; i++)
                                                        {
                                                            newRunners[i] = new Runner();
                                                            newRunners[i].NhapThongTin();
                                                        }

                                                        if (runners == null) runners = new Runner[0];
                                                        runners = runners.Concat(newRunners).ToArray();

                                                        break;

                                                    case 3:
                                                        Console.WriteLine("{0,-10}{1,-20}{2,-10}{3,-15}{4,-15}{5,-10}", "Ma so", "Ho ten", "So ao", "Thoi gian BD", "Thoi gian KT", "Thanh tich");
                                                        foreach (Runner runner in runners)
                                                        {
                                                            runner.XuatThongTin();
                                                        }
                                                        break;

                                                    case 4:
                                                        Console.WriteLine("Tam biet!");
                                                        break;

                                                    default:
                                                        Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                                                        break;
                                                }

                                                Console.WriteLine();
                                            } while (choice != 3);
                                            break;
                                        }
                                }

                            } while (choicetl != 0);
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            } while (choicemenu != 0);

        }
    }
}