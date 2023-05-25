using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai1
{
    class Nha : BatDongSan
    {
        private int soLau;

        public Nha(string maSo, double chieuDai, double chieuRong, int soLau) : base(maSo, chieuDai, chieuRong)
        {
            this.SoLau = soLau;
        }

        protected int SoLau { get => soLau; set => soLau = value; }

        public override double GiaBan()
        {
            return ChieuDai * ChieuRong * 10000 + SoLau * 100000;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Số lầu: " + SoLau);
        }
    }
}
