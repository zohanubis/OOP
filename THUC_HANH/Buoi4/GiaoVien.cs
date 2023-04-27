using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4_PhamHoDangHuy_2001215828
{
    internal class GiaoVien
    {
        public string TenGV;
        public string NameTeacher
        {
            get
            { return TenGV;}
            set { TenGV = value; }
        }
        private int sonhom;
    public int Group
        {
            get { return sonhom; }
            set { sonhom = value; }
        }
        public GiaoVien()
        {
            TenGV= "";
            sonhom= 0;
        }

        public void Xuat1GV()
        {
            Console.WriteLine("{0} \t {1}", TenGV, sonhom);
        }
    }
    
}
    
