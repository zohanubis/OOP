using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai3
{
    public class GheXoay : SanPham,IPhi
    {
        public override double TinhThue()
        {
            return DonGia * 0.1;
        }
        public override double TinhQuangBaSanPham()
        {
            double quangBa = 0;
            if(TenSanPham == "Ghế xoay cho trẻ em")
            {
                quangBa = 0;
            }else if(TenSanPham == "Ghế xoay cho nhân viên")
            {
                quangBa = 20000;
            }
            else if (TenSanPham == "Ghế xoay cho giám đốc")
            {
                quangBa = 40000;
            }
            return quangBa;
        }
        public double TinhPhiBaoVeMoiTruong()
        {
            return DonGia * 0.05;
        }
        public double TinhPhiTaiChe()
        {
            return DonGia * 0.04;
        }
    }
}