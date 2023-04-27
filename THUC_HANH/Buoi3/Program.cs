using System;
using System.Text;

namespace Buoi3_PhamHoDangHuy_2001215828
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            // Tạo hỗn số mới và nhập giá trị từ bàn phím
            MixedNumber mixedNumber = new MixedNumber();
            mixedNumber.Input();

            // Hiển thị hỗn số vừa nhập
            Console.WriteLine("Mixed Number:");
            mixedNumber.Display();

            // Chuyển đổi hỗn số thành phân số và hiển thị kết quả
            Fraction fraction = mixedNumber.ToFraction();
            Console.WriteLine("\nEquivalent Fraction:");
            Console.WriteLine(fraction.ToString());

            // Rút gọn phân số và hiển thị kết quả
            FractionalPart part = new FractionalPart();
            part.Simplify();
            Console.WriteLine("\nSimplified Fraction:");
            Console.WriteLine(fraction.ToString());

            // Chuyển đổi phân số thành hỗn số và hiển thị kết quả
            MixedNumber newMixedNumber = MixedNumber.FromFraction(fraction);
            Console.WriteLine("\nMixed Number from Simplified Fraction:");
            newMixedNumber.Display();
            // Chuyển hỗn số thành số thực 
            double d = (double)mixedNumber;
            Console.WriteLine(d);

            double x = 2.5;
            MixedNumber n = (MixedNumber)x;
            Console.WriteLine(n.ToString());

            TinhTienDien hoGiaDinh = new TinhTienDien();

            // Nhập thông tin hộ gia đình
            hoGiaDinh.NhapThongTin();
            //DangHuy,123456,100,150,150,3000
            // Tính tiền điện và xuất ra màn hình
            Console.WriteLine("Hộ gia đình {0}:", hoGiaDinh.HoTen);
            hoGiaDinh.XuatThongTin();

            // Bài 4
            // Tạo điểm p1 và nhập xuất thông tin điểm
            Point2D p1 = new Point2D(2, 3);
            Console.WriteLine("Thong tin diem p1:");
            p1.XuatDiem();
            // Tạo điểm p2 và nhập xuất thông tin điểm
            Point2D p2 = new Point2D();
            Console.WriteLine("Nhap thong tin diem p2:");
            p2.NhapDiem();
            Console.WriteLine("Thong tin diem p2:");
            p2.XuatDiem();

            // Thay đổi vị trí của p1
            Console.WriteLine("Thay doi vi tri cua diem p1");
            p1.ThayDoiViTri(1, 1);
            p1.XuatDiem();

            // Tính khoảng cách giữa 2 điểm p1 và p2
            Console.WriteLine("Khoang cach giua 2 diem p1 va p2: {0}", p1.TinhKhoangCach(p2));

            // Tìm điểm đối xứng của p1 qua trục Ox
            Console.Write("Diem doi xung cua p1 qua truc Ox: ");
            Point2D px = p1.TimDiemDoiXungOx();
            px.XuatDiem();

            // Tìm điểm đối xứng của p1 qua trục Oy
            Console.Write("Diem doi xung cua p1 qua truc Oy: ");
            Point2D py = p1.TimDiemDoiXungOy();
            py.XuatDiem();

            // Kiểm tra đoạn thẳng tạo bởi 2 điểm p1 và p2 có đi qua gốc tọa độ không
            if (p1.DiQuaGocToaDo(p2))
                Console.WriteLine("Doan thang p1-p2 di qua goc toa do");
            else
                Console.WriteLine("Doan thang p1-p2 khong di qua goc toa do");

            // Bài 5
            // Khởi tạo định thức cấp 2 với giá trị ngẫu nhiên
            DinhThucCap2 dt1 = new DinhThucCap2();

            // Khởi tạo định thức cấp 2 với giá trị được nhập từ bàn phím
            Console.WriteLine("Nhap cac phan tu cua ma tran:");
            int[,] matrix = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            DinhThucCap2 dt2 = new DinhThucCap2(matrix);

            // Xuất định thức và giá trị định thức
            Console.WriteLine("Dinh thuc 1:");
            dt1.Xuat();
            Console.WriteLine("Det: {0}", dt1.TinhDet());
            Console.WriteLine();

            Console.WriteLine("Dinh thuc 2:");
            dt2.Xuat();
            Console.WriteLine("Det: {0}", dt2.TinhDet());
            Console.WriteLine();

            // Tính tổng hai định thức
            Console.WriteLine("Tong hai dinh thuc:");
            DinhThucCap2 dt3 = dt1 + dt2;
            dt3.Xuat();
            Console.WriteLine();

            // Nhân định thức với một số nguyên
            Console.WriteLine("Nhan dinh thuc voi 2:");
            DinhThucCap2 dt4 = dt2 * 2;
            dt4.Xuat();
            Console.WriteLine();
        }
    }
}
