
using System.Text;
using System.Collections.Generic;
namespace Buoi4_PhamHoDangHuy_2001215828
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding= Encoding.UTF8;
            int choice, choice1;
            do
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. Bài tập trên lớp");
                Console.WriteLine("2. Bai tập về nhà");
                Console.Write("Nhập lựa chọn : "); choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                       {
                            do
                            {
                                Console.WriteLine("1. Giáo Viên");
                                Console.WriteLine("2. Thí Sinh");
                                Console.WriteLine("3. ");
                                Console.Write("Nhập lựa chọn : "); choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {
                                            DSGiaoVien ds = new DSGiaoVien();
                                            ds.Input("GV.xml");
                                            ds.xuat();
                                            Console.WriteLine("Tổng số nhóm của tất cả gv la " + ds.TongSoNhom());
                                            Console.WriteLine("DANH SACH GIAO VIEN SAP THEO NHOM GIAM DAN");
                                            ds.SapXepGroup();
                                            ds.xuat();

                                            List<GiaoVien> dsloc = ds.LocSoNhom1();
                                            Console.WriteLine("DANH SACH GIAO VIEN DAY HON 1 NHOM LA");
                                            foreach (GiaoVien gv in dsloc) { gv.Xuat1GV(); }
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 2:
                                        {
                                            int choicebt;
                                                CandidateList dsts = new CandidateList();
                                            List <Candidate> ts = dsts.GetPassedCandidates();
                                            do
                                            {
                                                Console.WriteLine("Chon chuc nang:");
                                                Console.WriteLine("1. Nhập danh sách thí sinh từ bàn phím");
                                                Console.WriteLine("2. Nhập danh sách thí sinh từ file XML");
                                                Console.WriteLine("3. In ra danh sách thi sinh");
                                                Console.WriteLine("4. Sắp xếp danh sách thí sinh theo tổng điểm tăng dần");
                                                Console.WriteLine("5. Sắp xếp thí sinh tăng dần theo họ tên, nếu trùng nhau thì thí sinh nào có điểm toán đứng trên");
                                                Console.WriteLine("6. Lấy danh sách các thí sinh có kết quả Đậu");
                                                Console.WriteLine("7. Lấy ra sinh viên có năm sinh > 1995 hoặc điểm toán từ 9 trở lên");
                                                Console.WriteLine("0. Thoat");
                                                Console.Write("Nhap lua chon : ");
                                                choicebt = int.Parse(Console.ReadLine());

                                                switch (choicebt)
                                                {
                                                    case 1:
                                                        dsts.Input();
                                                        dsts.PrintCandidates();
                                                        break;

                                                    case 2:
                                                        dsts.ImportFromXml("ThiSinh.xml");
                                                        dsts.PrintCandidates();
                                                        break;


                                                    case 3:
                                                        dsts.PrintCandidates();
                                                        break;

                                                    case 4:
                                                        Console.WriteLine("Tổng điểm tăng dần");
                                                        dsts.SortByTotalScoreDescending();
                                                        dsts.PrintCandidates();
                                                        break;

                                                    case 5:
                                                        Console.WriteLine("Sắp xếp thí sinh tăng dần theo họ tên, nếu trùng nhau thì thí sinh nào có điểm toán đứng trên");
                                                        dsts.SortByNameAscendingThenByMathScoreDescending();
                                                        dsts.PrintCandidates();
                                                        break;
                                                    case 6:
                                                        Console.WriteLine("Lấy danh sách các thí sinh có kết quả Đậu");
                                                        foreach (Candidate c in ts)
                                                        { c.Display(); }    
                                                        dsts.GetPassedCandidates();
                                                        dsts.PrintCandidates();
                                                        //
                                                        List<Candidate> passedCandidates = dsts.GetPassedCandidates();

                                                        // In danh sách các thí sinh đã đậu
                                                        Console.WriteLine("\nDANH SÁCH THÍ SINH ĐÃ ĐẬU:");
                                                        foreach (Candidate candidate in passedCandidates)
                                                        {
                                                            candidate.Display();
                                                        }
                                                        break;
                                                    case 7:
                                                        Console.WriteLine("Lấy ra sinh viên có năm sinh > 1995 hoặc điểm toán từ 9 trở lên");
                                                        dsts.GetCandidatesByYearOfBirthAndMathScore();
                                                        dsts.PrintCandidates();

                                                        break;

                                                    default:
                                                        Console.WriteLine("Chuc nang khong hop le!");
                                                        break;
                                                }
                                            }
                                            while (choicebt != 0);
                                            break;
                                        }
                                }
                                break;
                            } while (choice1 != 0);
                            break;
                        }
                    case 2:
                        break;

                    default:
                        break;
                }
            }while(choice != 0);
            
        }
    }
}