using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_PhamHoDangHuy_2001215828
{
    class TinhTienDien
    {
        private string hoTen;
        private int maSoCongToDien;
        private int chiSoCu;
        private int chiSoMoi;
        private int dinhMuc;
        private int donGiaDinhMuc;

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public int MaSoCongToDien
        {
            get { return maSoCongToDien; }
            set { maSoCongToDien = value; }
        }

        public int ChiSoCu
        {
            get { return chiSoCu; }
            set { chiSoCu = value; }
        }

        public int ChiSoMoi
        {
            get { return chiSoMoi; }
            set { chiSoMoi = value; }
        }

        public int DinhMuc
        {
            get { return dinhMuc; }
            set { dinhMuc = value; }
        }

        public int DonGiaDinhMuc
        {
            get { return donGiaDinhMuc; }
            set { donGiaDinhMuc = value; }
        }

        public int SoDienSuDung
        {
            get { return chiSoMoi - chiSoCu; }
        }

        public double TienDien
        {
            get
            {
                int soDienVuotDinhMuc = SoDienSuDung - dinhMuc;
                if (soDienVuotDinhMuc <= 0)
                {
                    return SoDienSuDung * donGiaDinhMuc;
                }
                else
                {
                    return dinhMuc * donGiaDinhMuc + soDienVuotDinhMuc * donGiaDinhMuc * 1.5;
                }
            }
        }
        public void NhapThongTin()
        {
            Console.Write("Họ tên chủ hộ: ");
            hoTen = Console.ReadLine();

            Console.Write("Mã số công tơ điện: ");
            maSoCongToDien = int.Parse(Console.ReadLine());

            Console.Write("Chỉ số cũ: ");
            chiSoCu = int.Parse(Console.ReadLine());

            Console.Write("Chỉ số mới: ");
            chiSoMoi = int.Parse(Console.ReadLine());

            Console.Write("Định mức: ");
            dinhMuc = int.Parse(Console.ReadLine());

            Console.Write("Đơn giá định mức: ");
            donGiaDinhMuc = int.Parse(Console.ReadLine());
        }
        //public static void NhapThongTinTuFile(string filePath, TinhTienDien tinhTienDien)
        //{
        //    // Mở file để đọc dữ liệu
        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        // Đọc từng dòng trong file
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            // Tách các giá trị từ dòng dữ liệu
        //            string[] values = line.Split(',');

        //            // Gán giá trị vào thuộc tính tương ứng của đối tượng TinhTienDien
        //            tinhTienDien.HoTen = values[0];
        //            tinhTienDien.MaSoCongToDien = int.Parse(values[1]);
        //            tinhTienDien.ChiSoCu = int.Parse(values[2]);
        //            tinhTienDien.ChiSoMoi = int.Parse(values[3]);
        //            tinhTienDien.DinhMuc = int.Parse(values[4]);
        //            tinhTienDien.DonGiaDinhMuc = int.Parse(values[5]);
        //        }
        //    }
        //}

        public void XuatThongTin()
        {
            Console.WriteLine("Họ tên chủ hộ: {0}", hoTen);
            Console.WriteLine("Mã số công tơ điện: {0}", maSoCongToDien);
            Console.WriteLine("Chỉ số cũ: {0}", chiSoCu);
            Console.WriteLine("Chỉ số mới: {0}", chiSoMoi);
            Console.WriteLine("Số điện sử dụng: {0}", SoDienSuDung);
            Console.WriteLine("Tiền điện: {0} đồng", TienDien);
        }
    }
}
