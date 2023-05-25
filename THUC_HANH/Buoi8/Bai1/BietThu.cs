using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai1
{
    class BietThu : BatDongSan, IPhi
    {
        public BietThu(string maSo, double chieuDai, double chieuRong) : base(maSo, chieuDai, chieuRong)
        {
        }

        public override double GiaBan()
        {
            return ChieuDai * ChieuRong * 400000;
        }

        public double PhiKinhDoanh()
        {
            return ChieuDai * 1000;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Phí kinh doanh: " + PhiKinhDoanh());
        }
    }
}
