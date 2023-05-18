using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap1
{
    class Program
    {
        static void Main(string[] args)
        {
            SanPham sp = new SanPham();
            KhoSanPham ksp = new KhoSanPham();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            int choice;

            do
            {
                Console.Write("Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        {
                            ksp.Input("KSP.xml");
                            ksp.Output();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Sản phẩm bán nhiều nhất : ");
                            ksp.SanPhamBanNhieuNhat().XuatThongTin();
                            
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Danh sách sản phẩm sau khi sắp xếp tăng dần theo đơn giá");
                            ksp.SapXepTheoDonGia();
                            ksp.Output();
                            break;

                        }
                    default: Console.WriteLine("Lỗi");
                        break;
                }    
            } while (choice != 0);

        }
    }
}
