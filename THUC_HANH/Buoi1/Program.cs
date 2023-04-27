using System;
using System.Collections.Generic;
using System.Text;

namespace Buoi1_PhamHoDangHuy_2001215828
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            int choice;

            do
            {
                Console.WriteLine("--------------------------------------------------------------------|");
                Console.WriteLine("Menu bài tập trên lớp:");
                Console.WriteLine("1. Nhập 2 số tính tổng tích thương");
                Console.WriteLine("2. Nhập thông tin một sinh viên ");
                Console.WriteLine("3. Tạo n phần tử số nguyên và in ra màn hình");
                Console.WriteLine("4. Chương trình giải bậc  1");
                Console.WriteLine("5. Chương trình giải bậc  2");
                Console.WriteLine("6. Cho biết ngày nhập là thứ mấy ?");
                Console.WriteLine("7. Phan tich n ra thua so nguyen to / Cho biet n co bao nhieu chu so");
                Console.WriteLine("------------------------------------------------------------------|");
                Console.WriteLine("Menu bài tập về nhà :");
                Console.WriteLine("8. Cho nhập so phai la so chinh phuong, xuat so vua nhập");
                Console.WriteLine("9. Nhập ngay thang nam, cho biet ngay truoc va sau la ngay may");
                Console.WriteLine("10. Tạo dãy số nguyên random 20 số và in ra màn hình");
                Console.WriteLine("11. Thông tin cá nhân");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("------------------------------------------------------------------|");
                Console.Write("Nhập lua chon: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Nhập so thu nhat: ");
                            int a = int.Parse(Console.ReadLine());

                            Console.WriteLine("Nhập so thu hai: ");
                            int b = int.Parse(Console.ReadLine());

                            int tong = a + b;
                            int hieu = a - b;
                            int tich = a * b;
                            double thuong = (double)a / b;

                            Console.WriteLine("Tong cua hai so la: " + tong);
                            Console.WriteLine("Hieu cua hai so la: " + hieu);
                            Console.WriteLine("Tich cua hai so la: " + tich);
                            Console.WriteLine("Thuong cua hai so la: " + thuong);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("ID Sinh Vien:");
                            string maSV = Console.ReadLine();

                            Console.Write("Ho Ten:");
                            string hoTen = Console.ReadLine();

                            Console.Write("Diem TB Sinh Vien:");
                            float diemTB = float.Parse(Console.ReadLine());

                            string xepLoai;

                            if (diemTB >= 8.0)
                            {
                                xepLoai = "Gioi";
                            }
                            else if (diemTB >= 6.5)
                            {
                                xepLoai = "Kha";
                            }
                            else if (diemTB >= 5.0)
                            {
                                xepLoai = "Trung Binh";
                            }
                            else
                            {
                                xepLoai = "Yeu";
                            }

                            Console.WriteLine("THONG TIN SINH VIEN:");
                            Console.WriteLine("ID : " + maSV);
                            Console.WriteLine("Ho Ten: " + hoTen);
                            Console.WriteLine("Diem Trung Binh: " + diemTB);
                            Console.WriteLine("Rank: " + xepLoai);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Nhập so phan tu day so : ");
                            int n = int.Parse(Console.ReadLine());

                            int[] arr = new int[n];

                            Random rand = new Random();

                            for (int i = 0; i < n; i++)
                            {
                                arr[i] = rand.Next(-100, 101); // Tạo số ngẫu nhiên trong khoảng từ -100 đến 100
                            }

                            Console.WriteLine("Day so so ngau nhien co " + n + " phan tu:");
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            // Xuất số toàn là số dương
                            //Console.WriteLine("Nhập so phan tu day so: ");
                            //int n = int.Parse(Console.ReadLine());

                            //int[] arr = new int[n];

                            //Random rand = new Random();

                            //for (int i = 0; i < n; i++)
                            //{
                            //    arr[i] = rand.Next(-100, 101); // Tạo số ngẫu nhiên trong khoảng từ -100 đến 100
                            //}

                            //Console.WriteLine("Day so so ngau nhien co " + n + " phan tu:");

                            //for (int i = 0; i < n; i++)
                            //{
                            //    if (arr[i] > 0)
                            //    {
                            //        Console.Write(arr[i] + " ");
                            //    }
                            //}
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Nhập he so a: ");
                            double a = double.Parse(Console.ReadLine());

                            Console.Write("Nhập he so b: ");
                            double b = double.Parse(Console.ReadLine());

                            if (a == 0)
                            {
                                if (b == 0)
                                {
                                    Console.WriteLine("Phuong trinh vo so nghiem");
                                }
                                else
                                {
                                    Console.WriteLine("Phuong trinh vo nghiem");
                                }
                            }
                            else
                            {
                                double x = -b / a;
                                Console.WriteLine("Nghiem cua phuong trinh la: {0}", x);
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("Nhập he so  a: ");
                            double a = double.Parse(Console.ReadLine());

                            Console.Write("Nhập he so  b: ");
                            double b = double.Parse(Console.ReadLine());

                            Console.Write("Nhập he so  c: ");
                            double c = double.Parse(Console.ReadLine());

                            double delta = b * b - 4 * a * c;

                            if (delta < 0)
                            {
                                Console.WriteLine("Phuong trinh vo nghiem");
                            }
                            else if (delta == 0)
                            {
                                double x = -b / (2 * a);
                                Console.WriteLine("Phuong trinh co nghiem kep: {0}", x);
                            }
                            else
                            {
                                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                                Console.WriteLine("Phuong trinh co 2 nghiem phan biet:");
                                Console.WriteLine("x1 = {0}", x1);
                                Console.WriteLine("x2 = {0}", x2);
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Write("Nhập ngay: ");
                            int ngay = int.Parse(Console.ReadLine());

                            Console.Write("Nhập thang: ");
                            int thang = int.Parse(Console.ReadLine());

                            Console.Write("Nhập nam: ");
                            int nam = int.Parse(Console.ReadLine());

                            if (thang < 3)
                            {
                                thang += 12;
                                nam--;
                            }

                            int n = (ngay + 2 * thang + (3 * (thang + 1)) / 5 + nam + (nam / 4) - (nam / 100) + (nam / 400)) % 7;

                            switch (n)
                            {
                                case 0:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay chu nhat", ngay, thang, nam);
                                    break;
                                case 1:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu hai", ngay, thang, nam);
                                    break;
                                case 2:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu 3", ngay, thang, nam);
                                    break;
                                case 3:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu tu", ngay, thang, nam);
                                    break;
                                case 4:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu nam", ngay, thang, nam);
                                    break;
                                case 5:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu sau", ngay, thang, nam);
                                    break;
                                case 6:
                                    Console.WriteLine("Ngay {0}/{1}/{2} la ngay thu bay", ngay, thang, nam);
                                    break;
                            }
                            break;
                        }
                    case 7:
                        {
                            int choice1;
                            do
                            {
                                Console.Write("Nhập so nguyen n: ");
                                int n = int.Parse(Console.ReadLine());
                                Console.WriteLine("1. Phan tich n ra thua so nguyen to");
                                Console.WriteLine("2. Cho biet n co bao nhieu chu so");
                                Console.WriteLine("0. Thoat");
                                Console.Write("Nhập lua chon: ");
                                choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {


                                            Console.Write("Phan tich " + n + " ra thua so nguyen to: ");

                                            for (int i = 2; i <= n; i++)
                                            {
                                                while (n % i == 0)
                                                {
                                                    Console.Write(i + " ");
                                                    n /= i;
                                                }
                                            }
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 2:
                                        {
                                            int count = 0;
                                            int temp = n;

                                            while (temp != 0)
                                            {
                                                temp /= 10;
                                                count++;
                                            }

                                            Console.WriteLine("So nguyen {0} co {1} chu so.", n, count);
                                            break;
                                        }
                                }

                            } while (choice1 != 0);
                            break;
                        }
                    case 8:
                        {
                            Console.Write("Nhập so chinh phuong : ");
                            int n = int.Parse(Console.ReadLine());

                            int squareRoot = (int)Math.Sqrt(n);
                            if (squareRoot * squareRoot == n)
                            {
                                Console.WriteLine("So nhập la so chinh phuong");
                            }
                            else
                            {
                                Console.WriteLine("So nhập khong phai la so chinh phuong");
                            }
                            break;
                        }
                    case 9:
                        {
                            Console.Write("Nhập vao ngay thang nam : ");
                            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                            DateTime yesterday = date.AddDays(-1);
                            DateTime tomorrow = date.AddDays(1);

                            Console.WriteLine("Ngay hom truoc : " + yesterday.ToString("dd/MM/yyyy"));
                            Console.WriteLine("Ngay hom sau : " + tomorrow.ToString("dd/MM/yyyy"));
                            break;
                        }
                    case 10:
                        {
                            List myList = new List();
                            int choice2;
                            do
                            {
                                Console.WriteLine("------------------------------------------------------------------|");
                                Console.WriteLine("1. Them so nguyen vao danh sach");
                                Console.WriteLine("2. In ra danh sach");
                                Console.WriteLine("3. Dao nguoc danh sach");
                                Console.WriteLine("4. Tim kiem so trong danh sach");
                                Console.WriteLine("5. In ra cac so co 2 chu so");
                                Console.WriteLine("6. In ra cac so co cac chu so deu la so chan");
                                Console.WriteLine("7. In ra cac so nguyen to trong danh sach");
                                Console.WriteLine("8. Sap xep danh sach");
                                Console.WriteLine("0. Thoat");
                                Console.Write("Nhập lua chon: ");
                                choice2 = int.Parse(Console.ReadLine());
                                switch (choice2)
                                {
                                    case 1:
                                        {
                                            Console.Write("Nhập so luong so nguyen can them vao danh sach: ");
                                            int count = int.Parse(Console.ReadLine());
                                            myList.AddRandomNumbers(count);
                                            break;
                                        }
                                    case 2:
                                        myList.PrintList();
                                        break;
                                    case 3:
                                        myList.ReverseList();
                                        Console.WriteLine("Danh sach sau khi dao nguoc:");
                                        myList.PrintList();
                                        break;
                                    case 4:
                                        Console.Write("Nhập so can tim: ");
                                        int x = int.Parse(Console.ReadLine());
                                        if (myList.Contains(x))
                                        {
                                            Console.WriteLine("So {0} co trong danh sach", x);
                                        }
                                        else
                                        {
                                            Console.WriteLine("So {0} khong co trong danh sach", x);
                                        }
                                        break;
                                    case 5:
                                        myList.PrintTwoDigitNumbers();
                                        break;
                                    case 6:
                                        myList.PrintEvenNumbers();
                                        break;
                                    case 7:
                                        myList.PrintPrimes();
                                        break;
                                    case 8:
                                        Console.WriteLine("1. Sap xep tang dan");
                                        Console.WriteLine("2. Sap xep giam dan");
                                        Console.Write("Nhập lua chon cua ban: ");
                                        int sortChoice = int.Parse(Console.ReadLine());
                                        if (sortChoice == 1)
                                        {
                                            myList.SortAscending();
                                            Console.WriteLine("Danh sach sau khi sap xep tang dan:");
                                        }
                                        else if (sortChoice == 2)
                                        {
                                            myList.SortDescending();
                                            Console.WriteLine("Danh sach sau khi sap xep giam dan:");
                                        }
                                        myList.PrintList();
                                        break;
                                    case 9:
                                        Console.WriteLine("Tam biet!");
                                        break;
                                }
                            } while (choice2 != 0);
                            break;

                        }
                    case 11:
                        {
                            Console.WriteLine("Phạm Hồ Đăng Huy");
                            Console.WriteLine("2001215828");
                            string name;
                            Console.Write("Nhap ho ten : ");
                            name = Console.ReadLine();
                            int day, month, year;
                            Console.Write("Nhập ngày : ");
                            day = int.Parse(Console.ReadLine());
                            Console.Write("Nhập tháng : ");
                            month = int.Parse(Console.ReadLine());
                            Console.Write("Nhập năm : ");
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Họ tên : " + name);
                            Console.Write("Năm sinh : {0}/{1}/{2}", day, month, year);

                            break;
                        }
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }


}