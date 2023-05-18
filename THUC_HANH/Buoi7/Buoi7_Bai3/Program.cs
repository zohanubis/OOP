using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

// Lớp trừu tượng đại diện cho một môn học
public abstract class MonHoc
{
    public string Ma { get; set; }
    public string Ten { get; set; }
    public int SoTc { get; set; }

    public abstract double TinhHocPhi();
    public abstract double TinhDiemTrungBinh();
}

// Lớp con đại diện cho môn học lý thuyết
public class MonLyThuyet : MonHoc
{
    public double DiemTieuLuan { get; set; }
    public double DiemGiuaKy { get; set; }
    public double DiemCuoiKy { get; set; }

    public override double TinhHocPhi()
    {
        return 250000 * SoTc;
    }

    public override double TinhDiemTrungBinh()
    {
        return DiemTieuLuan * 0.2 + DiemGiuaKy * 0.3 + DiemCuoiKy * 0.5;
    }
}

// Lớp con đại diện cho môn học thực hành
public class MonThucHanh : MonHoc
{
    public List<double> DiemKiemTra { get; set; }

    public override double TinhHocPhi()
    {
        return 350000 * SoTc + 100000;
    }

    public override double TinhDiemTrungBinh()
    {
        return DiemKiemTra.Average();
    }
}

// Lớp con đại diện cho môn học đồ án
public class MonDoAn : MonHoc
{
    public double DiemGVHD { get; set; }
    public double DiemGVPB { get; set; }

    public override double TinhHocPhi()
    {
        return 2000000;
    }

    public override double TinhDiemTrungBinh()
    {
        return (DiemGVHD * 2 + DiemGVPB) / 3;
    }
}

// Lớp chứa các phương thức chính để tính học phí và điểm trung bình
public class ChuongTrinhTinhHocPhi
{
    public static double TinhHocPhiMonHoc(MonHoc monHoc)
    {
        return monHoc.TinhHocPhi();
    }

    public static double TinhDiemTrungBinhMonHoc(MonHoc monHoc)
    {
        return monHoc.TinhDiemTrungBinh();
    }

    public static double TinhDiemTichLuy(List<MonHoc> monHocList)
    {
        double diemTichLuy = 0;
        int soTinChi = 0;

        foreach (var monHoc in monHocList)
        {
            diemTichLuy += monHoc.TinhDiemTrungBinh() * monHoc.SoTc;
            soTinChi += monHoc.SoTc;
        }

        return diemTichLuy / soTinChi;
    }
}

// Lớp chính
public class Program
{
    public static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        XDocument doc = XDocument.Load("data.xml");

        var monHocList = doc.Descendants("MH").Select(element =>
        {
            string loai = element.Element("Loai").Value;
            MonHoc monHoc;

            switch (loai)
            {
                case "LyThuyet":
                    monHoc = new MonLyThuyet()
                    {
                        Ma = element.Element("Ma").Value,
                        Ten = element.Element("Ten").Value,
                        SoTc = int.Parse(element.Element("SoTc").Value),
                        DiemTieuLuan = double.Parse(element.Element("DiemTieuLuan").Value),
                        DiemGiuaKy = double.Parse(element.Element("DiemGiuaKy").Value),
                        DiemCuoiKy = double.Parse(element.Element("DiemCuoiKy").Value)
                    };
                    break;

                case "ThucHanh":
                    monHoc = new MonThucHanh()
                    {
                        Ma = element.Element("Ma").Value,
                        Ten = element.Element("Ten").Value,
                        SoTc = int.Parse(element.Element("SoTc").Value),
                        DiemKiemTra = element.Element("DiemKiemTra").Elements("Diem").Select(e => double.Parse(e.Value)).ToList()
                    };
                    break;

                case "DoAn":
                    monHoc = new MonDoAn()
                    {
                        Ma = element.Element("Ma").Value,
                        Ten = element.Element("Ten").Value,
                        SoTc = int.Parse(element.Element("SoTc").Value),
                        DiemGVHD = double.Parse(element.Element("DiemGVHD").Value),
                        DiemGVPB = double.Parse(element.Element("DiemGVPB").Value)
                    };
                    break;

                default:
                    throw new ArgumentException($"Loại môn học không hợp lệ: {loai}");
            }

            return monHoc;
        }).ToList();

        // Tính học phí từng môn và tổng học phí
        double tongHocPhi = 0;
        foreach (var monHoc in monHocList)
        {
            double hocPhi = ChuongTrinhTinhHocPhi.TinhHocPhiMonHoc(monHoc);
            tongHocPhi += hocPhi;

            Console.WriteLine($"Môn học: {monHoc.Ten}");
            Console.WriteLine($"Học phí: {hocPhi}");
            Console.WriteLine();
        }

        Console.WriteLine($"Tổng học phí: {tongHocPhi}");
        Console.WriteLine();

        // Tính điểm trung bình mỗi môn và điểm trung bình tích lũy
        foreach (var monHoc in monHocList)
        {
            double diemTrungBinh = ChuongTrinhTinhHocPhi.TinhDiemTrungBinhMonHoc(monHoc);

            Console.WriteLine($"Môn học: {monHoc.Ten}");
            Console.WriteLine($"Điểm trung bình: {diemTrungBinh}");
            Console.WriteLine();
        }

        double diemTichLuy = ChuongTrinhTinhHocPhi.TinhDiemTichLuy(monHocList);
        Console.WriteLine($"Điểm trung bình tích lũy: {diemTichLuy}");
    }
}
