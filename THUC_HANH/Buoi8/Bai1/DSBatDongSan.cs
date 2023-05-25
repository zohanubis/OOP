using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi8_Interface_Bai1
{
    public class DSBatDongSan
    {
        private List<BatDongSan> ds = new List<BatDongSan>();

        internal List<BatDongSan> Ds { get => ds; set => ds = value; }
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("/BDSs/BDS");
            foreach (XmlNode node in nodeList)
            {
                BatDongSan bds;
                int loai = Convert.ToInt32(node["Loai"].InnerText);
                string ma = node["Ma"].InnerText;
                double dai = Convert.ToDouble(node["Dai"].InnerText);
                double rong = Convert.ToDouble(node["Rong"].InnerText);
                if (loai == 1)
                {
                    int soLau = Convert.ToInt32(node["SoLau"].InnerText);
                    bds = new Nha(ma, dai, rong, soLau);
                }
                else if (loai == 2)
                {
                    bds = new DatTrong(ma, dai, rong);
                }
                else if (loai == 3)
                {
                    bds = new BietThu(ma, dai, rong);
                }
                else
                {
                    int soSao = Convert.ToInt32(node["SoSao"].InnerText);
                    bds = new KhachSan(ma, dai, rong, soSao);
                }

                ds.Add(bds);
            }
        }
        public void Output()
        {
            foreach (BatDongSan bds in Ds)
            {
                bds.XuatThongTin();
            }
        }
        public double TongGiaTri()
        {
            double tong = 0;
            foreach (BatDongSan bds in Ds)
            {
                tong = tong + bds.GiaBan();
            }
            return tong;
        }
        public double TongThue()
        {
            double tong = 0;
            foreach (BatDongSan bds in Ds)
            {
                if (bds is IPhi)
                {
                    IPhi t = (IPhi)bds;
                    tong = tong + t.PhiKinhDoanh();
                }
            }
            return tong;
        }
    }
}
