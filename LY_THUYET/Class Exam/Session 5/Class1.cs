using System;

namespace StudentManagement
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public double Diem { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine());

            SinhVien[] students = new SinhVien[n];

            // Nhập danh sách sinh viên
            Console.WriteLine("Nhap danh sach sinh vien:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap sinh vien thu {0}: ", i + 1);

                students[i] = new SinhVien();

                Console.Write("Nhap ma sinh vien: ");
                students[i].MaSV = Console.ReadLine();

                Console.Write("Nhap ho ten: ");
                students[i].HoTen = Console.ReadLine();

                Console.Write("Nhap diem: ");
                students[i].Diem = double.Parse(Console.ReadLine());
            }

            // Xuất danh sách sinh viên
            Console.WriteLine("{0,-15}{1,-30}{2,-10}", "Ma SV", "Ho ten", "Diem");
            foreach (SinhVien student in students)
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-10}", student.MaSV, student.HoTen, student.Diem);
            }

            // Xuất thông tin sinh viên có điểm lớn hơn 9
            Console.WriteLine("Sinh vien co diem > 9:");
            Console.WriteLine("{0,-15}{1,-30}{2,-10}", "Ma SV", "Ho ten", "Diem");
            foreach (SinhVien student in students)
            {
                if (student.Diem > 9)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-10}", student.MaSV, student.HoTen, student.Diem);
                }
            }

            // Tìm kiếm sinh viên
            Console.Write("Nhap ma hoac ho ten sinh vien can tim: ");
            string searchString = Console.ReadLine();
            FindStudent(students, searchString);

            Console.ReadLine();
        }

        static void FindStudent(SinhVien[] students, string searchString)
        {
            Console.WriteLine("Ket qua tim kiem:");

            Console.WriteLine("{0,-15}{1,-30}{2,-10}", "Ma SV", "Ho ten", "Diem");
            foreach (SinhVien student in students)
            {
                if (student.MaSV == searchString || student.HoTen == searchString)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-10}", student.MaSV, student.HoTen, student.Diem);
                }
            }
        }
    }

    
}
