using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3_PhamHoDangHuy_2001215828
{
    class Point2D
    {
        private int x;
        private int y;

        // Hàm truy cập get/set
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        // 3 hàm khởi tạo & hàm hủy.
        public Point2D()
        {
            x = 0;
            y = 0;
        }

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D(Point2D other)
        {
            this.x = other.x;
            this.y = other.y;
        }

        ~Point2D()
        {
            // Hàm hủy (nếu có)
        }

        // Hàm nhập/xuất điểm.
        public void NhapDiem()
        {
            Console.Write("Nhap hoanh do x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Nhap tung do y: ");
            y = int.Parse(Console.ReadLine());
        }

        public void XuatDiem()
        {
            Console.WriteLine("({0}, {1})", x, y);
        }

        // Hàm kiểm tra điểm có thuộc trung Ox (hoặc Oy) không?
        public bool ThuocTrucOx()
        {
            return y == 0;
        }

        public bool ThuocTrucOy()
        {
            return x == 0;
        }

        // Hàm thay đổi vị trí điểm trên mặt phẳng:
        public void ThayDoiViTri(int tx, int ty)
        {
            x += tx;
            y += ty;
        }

        public void ThayDoiViTri(Point2D a)
        {
            x += a.x;
            y += a.y;
        }

        // Hàm tính khoảng cách giữa 2 điểm:
        public float TinhKhoangCach()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float TinhKhoangCach(Point2D a)
        {
            int dx = x - a.x;
            int dy = y - a.y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Hàm tìm điểm đối xứng của điểm hiện hành qua trục Ox.
        public Point2D TimDiemDoiXungOx()
        {
            return new Point2D(x, -y);
        }

        // Hàm tìm điểm đối xứng của điểm hiện hành qua trục Oy.
        public Point2D TimDiemDoiXungOy()
        {
            return new Point2D(-x, y);
        }

        // Hàm kiểm tra xem đoạn thẳng tạo bởi 2 điểm A(xA, yA) và B(xB, yB) có song song với trục Ox không?
        public bool SongSongTrucOx(Point2D b)
        {
            return y == b.y;
        }

        // Hàm kiểm tra xem đoạn thẳng tạo bởi 2 điểm A(xA, yA) và B(xB, yB) có song song với trục Oy không?
        public bool SongSongTrucOy(Point2D b)
        {
            return x == b.x;
        }
        // Hàm kiểm tra xem đoạn thẳng tạo bởi 2 điểm A(xA, yA) và B(xB, yB) có đi qua gốc tọa độ O(0,0) không?
        public bool DiQuaGocToaDo(Point2D b)
        {
            return x * b.y - y * b.x == 0;
        }

    }
}
