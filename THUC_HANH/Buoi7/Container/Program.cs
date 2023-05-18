using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi6_Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            NhanVienThucTe nhanVien = new NhanVienThucTe();
            CBLanhDao cbLanhDao = new CBLanhDao();
            NuocGiaiKhat nuocGiaiKhat = new NuocGiaiKhat("HH002", "Nước suối", "thùng", 10, 20.5);
            double tiLeChietKhau = 0.9;
            double tongTien = nuocGiaiKhat.TinhTongTien(tiLeChietKhau);
            int choice,choice1;
            do {
                Console.WriteLine("|------------------BÀI TẬP MẪU----------------------|");
                Console.WriteLine("|Bài 1 : Nhân Viên                                  |");
                Console.WriteLine("|Bài 2 : Nhân Viên : Cán Bộ Lãnh Đạo Công ty ABC    |");
                Console.WriteLine("|-----------------BÀI TẬP TRÊN LỚP------------------|");
                Console.WriteLine("|Bài 3 : Nước Giải Khát : Hàng Hóa                  |");
                Console.WriteLine("|----------------BÀI TẬP VỀ NHÀ---------------------|");
                Console.WriteLine("|Bài 4 : Nhân Viên : Cán Bộ Lãnh Đạo                |");
                Console.WriteLine("|---------------------------------------------------|");

                Console.Write("Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            NhanVien NhanVien = new NhanVien();
                            Console.WriteLine("Nhập thông tin nhân viên:");
                            NhanVien.Nhap();
                            Console.WriteLine();
                            Console.WriteLine("Thông tin nhân viên:");
                            NhanVien.Xuat();
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            CanBo canBo = new CanBo();
                            canBo.Nhap();
                            canBo.Xuat();

                            Console.WriteLine("Lương: " + canBo.Luong());
                            break;
                        }
                    case 3:
                        {
                            nuocGiaiKhat.NhapThongTin();
                            nuocGiaiKhat.Xuat();
                            Console.WriteLine("Tổng tiền: " + tongTien);
                            break;
                        }
                    case 4:
                        {
                            do {
                                Console.WriteLine("1. Nhập xuất nhân viên");
                                Console.WriteLine("2. Nhập xuất Cán Bộ Lãnh Đạo");
                                Console.Write("Nhập lựa chọn : ");
                                choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("\t\tThông tin nhân viên:");
                                            nhanVien.Nhap();
                                            nhanVien.Xuat();
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Nhập thông tin cán bộ lãnh đạo:");
                                            cbLanhDao.Nhap();
                                            Console.WriteLine("=========================================");
                                            Console.WriteLine("\n\tThông tin cán bộ lãnh đạo:");
                                            cbLanhDao.Xuat();
                                            Console.WriteLine("=========================================");
                                            break;
                                        }

                                }    
                            } while (choice1 != 0);

                            break;
                        }
                    default: Console.WriteLine("Lựa chọn sai, chọn lại");
                        break;
                }
                    
            } while (choice != 0);
            Console.ReadLine();
        }
    }
}
