using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
   
        class Program
        {
            static void Main(string[] args)
            {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
                // Tạo một đối tượng Ghế xoay
                GheXoay gheXoay = new GheXoay();
                gheXoay.MaSanPham = "SP01";
                gheXoay.TenSanPham = "Ghế xoay cho nhân viên";
                gheXoay.SoLuong = 3;
                gheXoay.DonGia = 100000;

                // Tính thành tiền và số tiền phải đóng thuế
                double thanhTienGheXoay = gheXoay.TinhThanhTien();
                double tienDongThueGheXoay = gheXoay.SoTienDongThue();

                // Hiển thị thông tin và kết quả
                Console.WriteLine("Thông tin Ghế xoay:");
                Console.WriteLine("Mã sản phẩm: " + gheXoay.MaSanPham);
                Console.WriteLine("Tên sản phẩm: " + gheXoay.TenSanPham);
                Console.WriteLine("Số lượng: " + gheXoay.SoLuong);
                Console.WriteLine("Đơn giá: " + gheXoay.DonGia);
                Console.WriteLine("Thành tiền: " + thanhTienGheXoay);
                Console.WriteLine("Số tiền phải đóng thuế: " + tienDongThueGheXoay);

                Console.WriteLine();

                // Tạo một đối tượng Ghế lưới
                GheLuoi gheLuoi = new GheLuoi();
                gheLuoi.MaSanPham = "SP02";
                gheLuoi.TenSanPham = "Ghế lưới văn phòng";
                gheLuoi.SoLuong = 2;
                gheLuoi.DonGia = 150000;
                gheLuoi.DienTich = 12;

                // Tính thành tiền và số tiền phải đóng thuế
                double thanhTienGheLuoi = gheLuoi.TinhThanhTien();
                double tienDongThueGheLuoi = gheLuoi.SoTienDongThue();

                // Hiển thị thông tin và kết quả
                Console.WriteLine("Thông tin Ghế lưới:");
                Console.WriteLine("Mã sản phẩm: " + gheLuoi.MaSanPham);
                Console.WriteLine("Tên sản phẩm: " + gheLuoi.TenSanPham);
                Console.WriteLine("Số lượng: " + gheLuoi.SoLuong);
                Console.WriteLine("Đơn giá: " + gheLuoi.DonGia);
                Console.WriteLine("Thành tiền: " + thanhTienGheLuoi);
                Console.WriteLine("Số tiền phải đóng thuế: " + tienDongThueGheLuoi);


            // Tạo một đối tượng Ghế lưới
            GheHop gheHop = new GheHop();
            gheHop.MaSanPham = "SP03";
            gheHop.TenSanPham = "Ghế họp văn phòng";
            gheHop.SoLuong = 2;
            gheHop.DonGia = 150000;
            gheHop.CanNang = 12;

            // Tính thành tiền và số tiền phải đóng thuế
            double thanhTienGheHop = gheHop.TinhThanhTien();
            double tienDongThueGheHop = gheHop.SoTienDongThue();

            // Hiển thị thông tin và kết quả
            Console.WriteLine("Thông tin Ghế họp:");
            Console.WriteLine("Mã sản phẩm: " + gheHop.MaSanPham);
            Console.WriteLine("Tên sản phẩm: " + gheHop.TenSanPham);
            Console.WriteLine("Số lượng: " + gheHop.SoLuong);
            Console.WriteLine("Đơn giá: " + gheHop.DonGia);
            Console.WriteLine("Thành tiền: " + thanhTienGheHop);
            Console.WriteLine("Số tiền phải đóng thuế: " + tienDongThueGheHop);
            Console.ReadLine();
            }
        }
    }
