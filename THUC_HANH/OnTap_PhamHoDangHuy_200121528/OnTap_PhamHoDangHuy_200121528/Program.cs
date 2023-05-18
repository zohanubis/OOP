using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OnTap_PhamHoDangHuy_200121528
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            ThiSinh ts2 = new ThiSinh();
            DSThiSinh dsts = new DSThiSinh();
            int choice, choice1;

            do
            {
                Console.Write("Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            do
                            {
                                
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("1. Nhập xuất mặc định ");
                                Console.WriteLine("2. Nhập xuất thông tin (input keyboard)");
                                Console.WriteLine("3. Nhập file XML");
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("4. In ra danh sách đạt kết quả đậu trong đợt thi ");
                                Console.WriteLine("5. Tổng số thí sinh đậu và rớt");
                                Console.WriteLine("6. Cho mã, in thông tin thí sinh");
                                Console.WriteLine("7. Sắp xếp ds giảm dần của điểm tổng kết");
                                Console.WriteLine("8. Xuất thông tin 3 thí sinh có điểm cao nhất");
                                Console.WriteLine("9. Sắp xếp ds tăng dần theo tên");
                                Console.WriteLine("---------------------------------------------------");

                                Console.Write("Nhập lựa chọn : ");
                                choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {
                                            // Khởi tạo đối tượng Thí Sinh thông qua phương thức khởi tạo có 5 tham số
                                            ThiSinh ts1 = new ThiSinh("TS001", "Nguyễn Văn A", "Nam", 8.5f, 7.5f);
                                            // Xuất thông tin đối tượng ts1
                                            ts1.XuatThongTin();
                                            break;
                                        }
                                    case 2:
                                        {
                                            ts2.NhapThongTin();
                                            ts2.XuatThongTin();

                                            break;
                                        }
                                    case 3:
                                        {
                                            dsts.Input("DSThiSinh.xml");
                                            dsts.XuatDanhSach();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Danh sách thí sinh đậu trong đợt thi : ");
                                            dsts.OutputDau();
                                            break;
                                        }
                                    case 5:
                                        {
                                            int slDau = dsts.DemSoLuongThiSinhDau();
                                            int slRot = dsts.DemSoLuongThiSinhRot();
                                            Console.WriteLine("Số lượng thí sinh đậu : {0}" , slDau);
                                            Console.WriteLine("Số lượng thí sinh rớt: {0}" , slRot);

                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Write("Nhập mã thí sinh cần tìm : ");
                                            string maTS = Console.ReadLine();
                                            dsts.InThongTinThiSinh(maTS);
                                            
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.WriteLine("Danh sách thí sinh giảm dần theo điểm tổng kết : ");
                                            dsts.XuatDanhSachSapXep();
                                            break;
                                        }
                                    case 8:
                                        {
                                            dsts.XuatThong3TSCoDiemCaoNhat();
                                            break;
                                        }
                                    case 9:
                                        {
                                            Console.WriteLine("Sắp xếp danh sách tăng theo tên");
                                            dsts.DanhSachSapXepTheoTen();
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Lỗi");
                                        break;
                                }

                            } while (choice1 != 0);
                            break;
                        }
                    default: Console.WriteLine("Lỗi ");
                        break;
                }
            } while (choice != 0);
        }
    }
}
