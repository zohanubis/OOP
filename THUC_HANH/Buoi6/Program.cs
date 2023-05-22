using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi6_PhamHoDangHuy_2001215828
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int choice;
            do {
                Console.WriteLine("---------KẾ THỪA---------");
                Console.WriteLine("Bài 3: Hàng Hóa");
                Console.WriteLine("Bài 4: Nhân Viên");
                Console.WriteLine("Bài 5 : Học Phí Đại Học");
                Console.Write("Mời nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 3:
                        NuocGiaiKhat nuocGiaiKhat = new NuocGiaiKhat("HH002", "chai", 50, 10.5);
                        nuocGiaiKhat.Xuat();

                        double tongTien = nuocGiaiKhat.TinhTongTien();
                        Console.WriteLine("Tổng tiền: " + tongTien);
                        break;
                    case 4:
                        NhanVien nhanVien = new NhanVien("NV002");
                        nhanVien.Xuat();

                        Console.WriteLine();

                        CBLanhDao cbLanhDao = new CBLanhDao();
                        cbLanhDao.Xuat();

                        break;
                    case 5:
                        SinhVien sinhVien = new SinhVien("SV001", "Đại học");
                        sinhVien.HoTen = "Nguyễn Văn A";
                        sinhVien.NgaySinh = new DateTime(2000, 1, 1);
                        sinhVien.XuatSinhVien();

                        Console.WriteLine();

                        double tongHocPhi = sinhVien.TinhTongHocPhi();
                        Console.WriteLine("Tổng học phí: " + tongHocPhi);
                        break;
                }    
            } while (choice != 0);
            Console.ReadKey();
        }
    }
}
