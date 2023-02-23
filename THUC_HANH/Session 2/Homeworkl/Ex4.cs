//Bài 4.Xây dựng lớp hình chữ nhật (HCN) có các thành phần sau:
//-Các thuộc tính mô tả chiều dài, chiều rộng
//- 3 phương thức khởi tạo: không có và có tham số
//- Phương thức tính chu vi
//- Phương thức tính diện tích
//- Phương thức tính đường chéo
//- Phương thức nhập/xuất thông tin hình chữ nhật
//- Phương thức thay đổi kích thước hình chữ nhật (viết theo dạng
//method overload):
//void changeSize(int tx, int ty, int kieu);
////kích thước (chiều dài, chiều rộng) HCN sẽ tăng lên thêm tx và ty nếu
//kiểu = 1, ngược lại chúng sẽ giảm tx, ty nếu kiểu =0
//void changeSize(HCN a, int kieu);
// kích thước HCN cộng thêm kích thước HCN a nếu kiểu=1, ngược lại
//chúng sẽ giảm nếu kiểu=0
//- Viết chương trình nhập vào kích thước 1 HCN, xuất ra chu vi, diện
//tích và đường chéo.
//- Nhập vào các kích thước để thay đổi HCN
using System;

class HCN
{
    private int length;
    private int width;

    public HCN()
    {
        length = 0;
        width = 0;
    }

    public HCN(int l, int w)
    {
        length = l;
        width = w;
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Perimeter()
    {
        return 2 * (length + width);
    }

    public int Area()
    {
        return length * width;
    }

    public double Diagonal()
    {
        return Math.Sqrt(length * length + width * width);
    }

    public void Input()
    {
        Console.Write("Enter the length: ");
        length = int.Parse(Console.ReadLine());

        Console.Write("Enter the width: ");
        width = int.Parse(Console.ReadLine());
    }

    public void Output()
    {
        Console.WriteLine("Length: {0}", length);
        Console.WriteLine("Width: {0}", width);
        Console.WriteLine("Perimeter: {0}", Perimeter());
        Console.WriteLine("Area: {0}", Area());
        Console.WriteLine("Diagonal: {0}", Diagonal());
    }

    public void changeSize(int tx, int ty, int kieu)
    {
        if (kieu == 1)
        {
            length += tx;
            width += ty;
        }
        else if (kieu == 0)
        {
            length -= tx;
            width -= ty;
        }
    }

    public void changeSize(HCN a, int kieu)
    {
        if (kieu == 1)
        {
            length += a.Length;
            width += a.Width;
        }
        else if (kieu == 0)
        {
            length -= a.Length;
            width -= a.Width;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        HCN h = new HCN();
        h.Input();
        h.Output();

        Console.WriteLine("Enter the length and width to change the size:");
        int tl = int.Parse(Console.ReadLine());
        int tw = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter 1 to increase the size, 0 to decrease the size:");
        int type = int.Parse(Console.ReadLine());

        h.changeSize(tl, tw, type);
        h.Output();

        HCN h1 = new HCN();
        h1.Input();
        h1.Output();

        Console.WriteLine("Enter 1 to add the size, 0 to subtract the size:");
        int type1 = int.Parse(Console.ReadLine());

        h.changeSize(h1, type1);
        h.Output();

        Console.ReadKey();
    }
}
