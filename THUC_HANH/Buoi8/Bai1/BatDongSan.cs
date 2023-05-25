using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi8_Interface_Bai1
{ 

    abstract class BatDongSan
    {
        private string maSo;
        private double chieuDai;
        private double chieuRong;

        protected string MaSo { get => maSo; set => maSo = value; }
        protected double ChieuDai { get => chieuDai; set => chieuDai = value; }
        protected double ChieuRong { get => chieuRong; set => chieuRong = value; }

        public BatDongSan(string maSo, double chieuDai, double chieuRong)
        {
            this.MaSo = maSo;
            this.ChieuDai = chieuDai;
            this.ChieuRong = chieuRong;
        }

        public abstract double GiaBan();

        public virtual void XuatThongTin()
        {
            Console.WriteLine("Mã số: " + MaSo);
            Console.WriteLine("Diện tích: " + (ChieuDai * ChieuRong));
            Console.WriteLine("Giá bán: " + GiaBan());
        }
    }
   
}

