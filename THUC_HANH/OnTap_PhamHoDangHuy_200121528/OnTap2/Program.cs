using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            DSKhoaHoc dskh = new DSKhoaHoc();
            int choice;
            do
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("1. Đọc file XML");
                Console.WriteLine("2. Tổng số tiền trung tâm");
                Console.WriteLine("3. Tổng số lớp trung tâm");
                Console.WriteLine("4. Danh sách các khóa học có số học viên từ 15 trở lên");
                Console.WriteLine("5. Số khóa học của giáo viên có tên X");
                Console.WriteLine("6. Danh sách các khóa học sắp xếp theo học phí giảm");
                Console.WriteLine("7. Khóa học có tên x");
                Console.WriteLine("8. In danh sách giờ học theo giờ");
                Console.Write("Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------");
                switch (choice)
                {
                    case 1:
                        dskh.Input("DSKH.xml");
                        dskh.XuatDanhSach();
                        break;
                    case 2:
                        Console.WriteLine("\nTổng số tiền trung tâm đang có : " + dskh.TinhTongTien());
                        break;
                    case 3:
                        Console.WriteLine("\n Tổng số lớp hiện có của trung tâm :  " + dskh.TinhTongSoLop());
                        break;
                    case 4:
                        Console.WriteLine("Danh sách các khóa học có 15 học viên trở lên");
                        List<KhoaHoc> dsKHLonHon15 = dskh.TimKhoaHocLonHon15();
                        foreach (KhoaHoc kh in dsKHLonHon15) { kh.XuatThongTin(); }
                        break;
                    case 5:
                        Console.Write("Nhập tên giáo viên giảng dạy cần tìm : ");
                        string x = Console.ReadLine();
                        Console.WriteLine("Số khóa học của giáo viên có tên {0} : {1}", x, dskh.SoKhoaHocGVX(x));
                        break;
                    case 6:
                        Console.WriteLine("Danh sách khóa học sắp xếp theo học phí giảm dần ");
                        dskh.SapXepHocPhiGiam();
                        dskh.XuatDanhSach();
                        break;
                    case 7:
                        Console.WriteLine("Nhập tên khóa học cần tìm : ");
                        string n = Console.ReadLine();
                        dskh.TimInKHTheoTen(n);
                        break;
                    case 8:
                        Console.WriteLine("Danh sách khóa học theo giờ học :");
                        dskh.XuatDanhSachTheoGioHoc();
                        break;
                    default: Console.WriteLine("Lỗi");
                        break;
                }
            } while (choice != 0);
        }
    }
}
