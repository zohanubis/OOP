using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi8_Interface_Bai1
{
    class DatTrong : BatDongSan
    {
        public DatTrong(string maSo, double chieuDai, double chieuRong) : base(maSo, chieuDai, chieuRong)
        {
        }

        public override double GiaBan()
        {
            return ChieuDai * ChieuRong * 10000;
        }
    }
}
