using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi4_PhamHoDangHuy_2001215828
{
    internal class DSGiaoVien
    {
        List<GiaoVien> lst = new List<GiaoVien>();
        public List<GiaoVien> ListGV
        {
            get { return lst; }
            set { lst = value; }

        }
        
        public void Input(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("DanhSach/GV");
            foreach ( XmlNode node in nodeList)
            {
                GiaoVien gv = new GiaoVien();
                gv.TenGV = node["Hoten"].InnerText;
                gv.Group = int.Parse(node["SoNhom"].InnerText);
                lst.Add(gv);
            }
        }

       
        public void xuat()
        {
            Console.WriteLine("Danh sách giáo viên");
            foreach (GiaoVien gv in lst)
            {
                gv.Xuat1GV();
            }
        }
        public int TongSoNhom()
        {
            int tong = 0;
            foreach (GiaoVien gv in lst)
                tong = tong + gv.Group;
            return tong;
        }
        public void SapXepTen()
        {
            lst = lst.OrderBy(gv => gv.NameTeacher).ToList();
        }
        public void SapXepGroup()
        {
            lst = lst.OrderByDescending(gv => gv.Group).ToList();
        }
        public List<GiaoVien> LocSoNhom1()
        {
            return lst.Where(t => t.Group > 1).ToList();
        }
    }
}
