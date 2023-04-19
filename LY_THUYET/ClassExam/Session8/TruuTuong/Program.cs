/*Thiết kế và xây dựng lớp cho chương trình tính tiền phòng hàng tháng cho một cơ sở cho thuê phòng. Biết răng mỗi phòng đều có thông tin sau :
Mã số phòng, số người , số điện và số nước. Cơ sở chia phòng ra làm 2 loại khác nhau :
-Phòng loại A: có thêm thông tin về số lần người thân thăm và ở lại qua đêm (SoNguoiThan). Tiền phòng được tính như sau :
	Tiền phòng = 1400 + 2 * Số điện  + 8 * Số nước + 50 * SoNguoiThan
- Phòng loại B : có thêm thông tin khối lượng giặt ủi (giatui) và số máy sử dụng internet(somay). Tiền phòng được tính như sau : 
	Tiền phòng = 2000 + 2 * số điện + 8 * số nước + giatui * 5 + somay * 100
*/
// Lưu ý : không thể tạo đối tượng trong lớp abstract, chỉ là lớp để các lớp khác dẫn xuất
/**/

using System;
namespace ThuePhong
{
    public abstract class Phong
    {
        public string maSoPhong { get; set; }
        public int soNguoi { get; set; }
        public int soDien { get; set; }
        public int soNuoc { get; set; }


        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ma so phong : ");
            maSoPhong = Console.ReadLine();

            Console.Write("Nhap so nguoi : ");
            soNguoi = int.Parse(Console.ReadLine());

            Console.Write("Nhap so dien : ");
            soDien = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nuoc : ");
            soNuoc = int.Parse(Console.ReadLine());
        }
        public virtual void XuatThongTin()
        {
            Console.WriteLine("Ma so phong : " + maSoPhong);
            Console.WriteLine("So nguoi : " + soNguoi);
            Console.WriteLine("So dien : " + soDien);
            Console.WriteLine("So nuoc : " + soNuoc);
        }
        public abstract int TinhTienPhong();
    }
    public class PhongLoaiA : Phong
    {
        public int soNguoiThan { get; set; }
        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap so nguoi than : ");
            soNguoiThan = int.Parse(Console.ReadLine());
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("So nguoi than : " + soNguoiThan);

        }
        public override int TinhTienPhong()
        {

            return 1400 + 2 * soDien + 8 * soNuoc + 50 * soNguoiThan;
        }
    }
    public class PhongLoaiB : Phong
    {
        public int khoiLuongGiatUi { get; set; }
        public int soMay { get; set; }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap khoi luong giat ui : ");
            khoiLuongGiatUi = int.Parse(Console.ReadLine());

            Console.Write("Nhap so may : ");
            soMay = int.Parse(Console.ReadLine());
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Khoi luong giat ui : " + khoiLuongGiatUi);
            Console.WriteLine("So may : " + soMay);
        }
        public override int TinhTienPhong()
        {
            return 2000 + 2 * soDien + 8 * soNuoc + khoiLuongGiatUi * 5 + soMay * 100;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Tinh tien phong loai A");
            Console.WriteLine("2. Tinh tien phong loai B");
            Console.Write("Lua chon cua ban : ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    PhongLoaiA phongA = new PhongLoaiA();
                    Console.WriteLine("\nNhap thong tin phong A:");
                    phongA.NhapThongTin();
                    Console.WriteLine("\n\tThong tin phong A:");
                    phongA.XuatThongTin();
                    Console.WriteLine("Tien phong A: " + phongA.TinhTienPhong());
                    break;
                case 2:
                    PhongLoaiB phongB = new PhongLoaiB();
                    Console.WriteLine("\nNhap thong tin phong B:");
                    phongB.NhapThongTin();
                    Console.WriteLine("\n\tThong tin phong B:");
                    phongB.XuatThongTin();
                    Console.WriteLine("Tien phong B: " + phongB.TinhTienPhong());
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }

            Console.ReadKey();
        }
    }

}
/*Thiết kế lớp kế thừa, lớp ABSTRACT cho chương trình tính điểm trung bình (DTB) và quy đổi điểm hệ 4 ( điếm chữ).
 * Biết rằng mỗi môn học đều có các thông tin sau :
	Mã môn học, tên môn học, tín chỉ
Các môn học được chia làm 3 loại :
- Lý thuyết : có 2 cột điểm là tiểu luận và điểm cuối kỳ.
	DTB = Điểm tiểu luận * 0.3 + Điểm cuối kì * 0.7
- Thực Hành: Có 3 cột điểm kiểm tra. DTB tính bằng trung bình cộng các bài kiểm tra.
- Đồ án : có điểm của giáo viên hướng dẫn (GVHD) và giáo viên phản biện (GVPB)
	DTB = ( điểm GVHD + điểm GVPB) /2*/
//namespace MonHoc
//{
//    using System;

//    // Lớp Môn học
//    class Subject
//    {
//        // Thuộc tính
//        protected string maMonHoc;
//        protected string tenMonHoc;
//        protected int tinChi;

//        // Phương thức
//        public virtual void NhapThongTin()
//        {
//            Console.Write("Nhap ma mon hoc: ");
//            maMonHoc = Console.ReadLine();
//            Console.Write("Nhap ten mon hoc: ");
//            tenMonHoc = Console.ReadLine();
//            Console.Write("Nhap so tin chi: ");
//            tinChi = int.Parse(Console.ReadLine());
//        }

//        public virtual void XuatThongTin()
//        {
//            Console.WriteLine("Ma mon hoc: " + maMonHoc);
//            Console.WriteLine("Ten mon hoc: " + tenMonHoc);
//            Console.WriteLine("So tin chi: " + tinChi);
//        }
//    }

//    // Lớp Lý thuyết kế thừa từ lớp Môn học
//    class Theory : Subject
//    {
//        // Thuộc tính
//        private double diemTieuLuan;
//        private double diemCuoiKy;

//        // Phương thức
//        public override void NhapThongTin()
//        {
//            base.NhapThongTin();
//            Console.Write("Nhap diem tieu luan: ");
//            diemTieuLuan = double.Parse(Console.ReadLine());
//            Console.Write("Nhap diem cuoi ky: ");
//            diemCuoiKy = double.Parse(Console.ReadLine());
//        }

//        public override void XuatThongTin()
//        {
//            base.XuatThongTin();
//            Console.WriteLine("Diem tieu luan: " + diemTieuLuan);
//            Console.WriteLine("Diem cuoi ky: " + diemCuoiKy);
//        }

//        public double TinhDTB()
//        {
//            return diemTieuLuan * 0.3 + diemCuoiKy * 0.7;
//        }
//    }

//    // Lớp Thực hành kế thừa từ lớp Môn học
//    class Practice : Subject
//    {
//        // Thuộc tính
//        private double[] diemKiemTra = new double[3];

//        // Phương thức
//        public override void NhapThongTin()
//        {
//            base.NhapThongTin();
//            for (int i = 0; i < 3; i++)
//            {
//                Console.Write("Nhap diem kiem tra " + (i + 1) + ": ");
//                diemKiemTra[i] = double.Parse(Console.ReadLine());
//            }
//        }

//        public override void XuatThongTin()
//        {
//            base.XuatThongTin();
//            Console.Write("Diem kiem tra: ");
//            foreach (double diem in diemKiemTra)
//            {
//                Console.Write(diem + " ");
//            }
//            Console.WriteLine();
//        }

//        public double TinhDTB()
//        {
//            double tongDiem = 0;
//            foreach (double diem in diemKiemTra)
//            {
//                tongDiem += diem;
//            }
//            return tongDiem / 3;
//        }
//    }

//    // Lớp Đồ án kế thừa từ lớp Môn học
//    class Project : Subject
//    {
//        // Thuộc tính
//        private double diemGVHD;
//        private double diemGVPB;

//        // Phương thức
//        public override void NhapThongTin()
//        {
//            base.NhapThongTin();
//            Console.Write("Nhap diem GVHD: ");
//            diemGVHD = double.Parse(Console.ReadLine());
//            Console.Write("Nhap diem GVPB: ");
//            diemGVPB = double.Parse(Console.ReadLine());
//        }

//        public override void XuatThongTin()
//        {
//            base.XuatThongTin();
//            Console.WriteLine("Diem GVHD: " + diemGVHD);
//            Console.WriteLine("Diem GVPB: " + diemGVPB);
//        }

//        public double TinhDTB()
//        {
//            return (diemGVHD + diemGVPB) / 2;
//        }
//    }



//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int choice;
//            do
//            {
//                Console.WriteLine("Nhap lua chon:");
//                Console.WriteLine("1. Mon hoc Ly thuyet");
//                Console.WriteLine("2. Mon hoc Thuc hanh");
//                Console.WriteLine("3. Mon hoc Do an");
//                Console.WriteLine("0. Thoat");

//                choice = int.Parse(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Theory lyThuyet = new Theory();
//                        Console.WriteLine("Nhap thong tin mon hoc Ly thuyet:");
//                        lyThuyet.NhapThongTin();
//                        Console.WriteLine("Thong tin mon hoc Ly thuyet:");
//                        lyThuyet.XuatThongTin();
//                        Console.WriteLine("Diem trung binh cua mon hoc Ly thuyet: " + lyThuyet.TinhDTB());
//                        break;
//                    case 2:
//                        Practice thucHanh = new Practice();
//                        Console.WriteLine("\nNhap thong tin mon hoc Thuc hanh:");
//                        thucHanh.NhapThongTin();
//                        Console.WriteLine("Thong tin mon hoc Thuc hanh:");
//                        thucHanh.XuatThongTin();
//                        Console.WriteLine("Diem trung binh cua mon hoc Thuc hanh: " + thucHanh.TinhDTB());
//                        break;
//                    case 3:
//                        Project doAn = new Project();
//                        Console.WriteLine("\nNhap thong tin mon hoc Do an:");
//                        doAn.NhapThongTin();
//                        Console.WriteLine("Thong tin mon hoc Do an:");
//                        doAn.XuatThongTin();
//                        Console.WriteLine("Diem trung binh cua mon hoc Do an: " + doAn.TinhDTB());
//                        break;
//                    case 0:
//                        Console.WriteLine("Thoat chuong trinh!");
//                        break;
//                    default:
//                        Console.WriteLine("Lua chon khong hop le!");
//                        break;
//                }

//            } while (choice != 0);
//        }

//    }

//}

