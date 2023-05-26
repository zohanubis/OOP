using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class GheLuoi : SanPham, IPhi
    {
        private double dienTich;
        public double DienTich { get => dienTich; set => dienTich = value; }
        public override double TinhThue()
        {
            return DonGia * 0.03;
        }
        public override double TinhQuangBaSanPham()
        {
            double quangBa = 0;
            if(dienTich > 10)
            {
                quangBa = 50000;
            }
            else
            {
                quangBa = 0;
            }
            return quangBa;
        }
        public double TinhPhiBaoVeMoiTruong()
        {
            return DonGia * 0.03;
        }
        public double TinhPhiTaiChe()
        {
            return DonGia * 0.02;
        }
    }
}
