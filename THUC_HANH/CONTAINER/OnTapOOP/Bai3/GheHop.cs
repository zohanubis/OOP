using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class GheHop : SanPham
    {
        private double canNang;
        public double CanNang { get => canNang; set => canNang = value; }
        public override double TinhThue()
        {
            return DonGia * 0.05;
        }
        public override double TinhQuangBaSanPham()
        {
            double quangBa = 0;
            if (CanNang < 5)
                quangBa = 0;
            else
                quangBa = 60000;
            return quangBa;
        }
    }
}
