using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai1
{
    class KhachSan : BatDongSan, IPhi
    {
        private int soSao;

        public KhachSan(string maSo, double chieuDai, double chieuRong, int soSao) : base(maSo, chieuDai, chieuRong)
        {
            this.SoSao = soSao;
        }

        protected int SoSao { get => soSao; set => soSao = value; }

        public override double GiaBan()
        {
            return 100000 + SoSao * 50000;
        }

        public double PhiKinhDoanh()
        {
            return ChieuDai * 5000;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Số sao: " + SoSao);
            Console.WriteLine("Phí kinh doanh: " + PhiKinhDoanh());
        }
    }
}
