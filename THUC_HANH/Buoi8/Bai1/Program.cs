using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Buoi8_Interface_Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            DSBatDongSan dsBatDongSan = new DSBatDongSan();

            string inputFile = "data.xml";
            dsBatDongSan.Input(inputFile);

            dsBatDongSan.Output();

            double tongGiaTri = dsBatDongSan.TongGiaTri();
            Console.WriteLine("Tổng giá trị: " + tongGiaTri);

            double tongThue = dsBatDongSan.TongThue();
            Console.WriteLine("Tổng thuế: " + tongThue);

            Console.ReadLine();
        }
    }
}
