﻿using System;
using System.IO;
class NuocGiaiKhat
{
    private string tenHang;
    private string donViTinh;
    private int soLuong;
    private float donGia;
    private float thueVAT;

    public string TenHang
    {
        get { return tenHang; }
        set { tenHang = value; }
    }

    public string DonViTinh
    {
        get { return donViTinh; }
        set
        {
            if (value == "ket" || value == "thung" || value == "chai" || value == "lon")
            {
                donViTinh = value;
            }
            else
            {
                donViTinh = "két";
            }
        }
    }

    public int SoLuong
    {
        get { return soLuong; }
        set
        {
            if (value > 0)
            {
                soLuong = value;
            }
            else
            {
                Console.WriteLine("So luong phai lon hon 0!");
            }
        }
    }

    public float DonGia
    {
        get { return donGia; }
        set
        {
            if (value > 0)
            {
                donGia = value;
            }
            else
            {
                Console.WriteLine("Don gia phai lon hon 0!");
            }
        }
    }
    public void XuatFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Ten hang: " + tenHang);
            writer.WriteLine("Don vi tinh: " + donViTinh);
            writer.WriteLine("So luong: " + soLuong);
            writer.WriteLine("Don gia: " + donGia);
            writer.WriteLine("Thue VAT: " + thueVAT);
            writer.WriteLine("Thanh Tien: " + TinhThanhTien());
        }
    }

    public void DocFile(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    public void NhapFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            Console.Write("Ten hang: ");
            tenHang = Console.ReadLine();
            writer.WriteLine("Ten hang: " + tenHang);

            Console.Write("Don vi tinh (ket, thung, chai, lon): ");
            DonViTinh = Console.ReadLine();
            writer.WriteLine("Don vi tinh: " + donViTinh);

            Console.Write("So luong: ");
            int.TryParse(Console.ReadLine(), out int sl);
            SoLuong = sl;
            writer.WriteLine("So luong: " + soLuong);

            Console.Write("Don gia: ");
            float.TryParse(Console.ReadLine(), out float dg);
            DonGia = dg;
            writer.WriteLine("Don gia: " + donGia);

            writer.WriteLine("Thue VAT: " + thueVAT);
            writer.WriteLine("Thanh Tien: " + TinhThanhTien());
        }
    }
    public float ThueVAT
    {
        get { return thueVAT; }
        set { thueVAT = value; }
    }

    public NuocGiaiKhat()
    {
        tenHang = "NuocGiaiKhat";
        donViTinh = "ket";
        soLuong = 0;
        donGia = 0;
        thueVAT = 0.1f;
    }

    public float TinhThanhTien()
    {
        float thanhTien = 0;
        if (donViTinh == "ket" || donViTinh == "thung")
        {
            thanhTien = soLuong * donGia + soLuong * donGia * thueVAT;
        }
        else if (donViTinh == "chai")
        {
            thanhTien = soLuong * (donGia / 20) + soLuong * (donGia / 20) * thueVAT;
        }
        else if (donViTinh == "lon")
        {
            thanhTien = soLuong * (donGia / 24) + soLuong * (donGia / 24) * thueVAT;
        }
        return thanhTien;
    }

    public void XuatThongTin()
    {
        Console.WriteLine("Ten hang: " + tenHang);
        Console.WriteLine("Don vi tinh: " + donViTinh);
        Console.WriteLine("So luong: " + soLuong);
        Console.WriteLine("Don gia: " + donGia);
        Console.WriteLine("Thue VAT: " + thueVAT);
        Console.WriteLine("Thanh Tien: " + TinhThanhTien());
    }
    public NuocGiaiKhat(string tenHang, string donViTinh, int soLuong, float donGia)
    {
        this.tenHang = tenHang;
        this.donViTinh = donViTinh;
        this.soLuong = soLuong;
        this.donGia = donGia;
        this.thueVAT = 0.1f;
    }

}
class Program
    {
        static void Main(string[] args)

        {

            NuocGiaiKhat nuoc1 = new NuocGiaiKhat("Coca", "chai", 50, 10000);
            NuocGiaiKhat nuoc2 = new NuocGiaiKhat("Pepsi", "lon", 20, 15000);

            nuoc1.XuatThongTin();
            nuoc2.XuatThongTin();

            Console.WriteLine("Thanh tien nuoc 1: " + nuoc1.TinhThanhTien());
            Console.WriteLine("Thanh tien nuoc 2: " + nuoc2.TinhThanhTien());

            nuoc1.XuatFile("nuoc1.txt");
            nuoc2.XuatFile("nuoc2.txt");

            Console.WriteLine("Doc file nuoc1.txt:");
            nuoc1.DocFile("nuoc1.txt");
            Console.WriteLine("Doc file nuoc2.txt:");
            nuoc2.DocFile("nuoc2.txt");

            //Console.WriteLine("Nhap du lieu nuoc3:");
            //NuocGiaiKhat nuoc3 = new NuocGiaiKhat();
            //nuoc3.NhapFile("nuoc3.txt");

            //Console.WriteLine("Xuat du lieu nuoc3:");
            //nuoc3.XuatFile("nuoc3.txt");
    }
    }
