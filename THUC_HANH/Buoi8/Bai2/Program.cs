using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int choice;
            DSNhanVien dsnv = new DSNhanVien();
            dsnv.Input("data.xml");

            do {
                Console.WriteLine("========================================================");
                Console.WriteLine("1. Xuất thông tin Nhân Viên trong Cty");
                Console.WriteLine("2. Đếm số nhân viên");
                Console.WriteLine("3. Tổng số nhân viên có năng lực tốt");
                Console.WriteLine("4. Tổng lương công ty con");
                Console.WriteLine("5. Thông tin nhân viên chưa được xét thi đua");
                Console.WriteLine("6. Thông tin nhân viên lao động tiên tiến");
                Console.Write("Nhập lưa chọn : ");
                

                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("========================================================");
                switch (choice)
                {
                    case 1:
                        {
                            dsnv.XuatThongTinNhanVienKinhDoanh();
                            dsnv.XuatThongTinNhanVienSanXuat();
                            dsnv.XuatThongTinCanBoQuanLy();
                            break;
                        }
                    case 2:
                        {
                            dsnv.DemSoNhanVien();
                            break;
                        }
                    case 3:
                        {
                            dsnv.TinhTongLuongCongTyCon();
                            break;
                        }
                    case 4:
                        {
                            dsnv.TinhTongSoNhanVienCoNangLucTot();
                            break;
                        }
                    case 5:
                        {
                            dsnv.XuatThongTinNhanVienChuaDuocXetThiDua();
                            break;
                        }
                    case 6:
                        {
                            dsnv.XuatThongTinNhanVienLaoDongTienTien();
                            break;
                        }

                    default:Console.WriteLine("Lỗi lựa chọn");
                        break;
                }
            } while (choice != 0);
            Console.ReadLine();
        }
    }
}
