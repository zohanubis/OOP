using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2_PhamHoDangHuy_2001215828
{
    class Time
    {
        private int hour;
        private int minute;
        private int second;

        public Time()
        {
            hour = 0;
            minute = 0;
            second = 0;
        }
        public Time(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }
        public void Input()
        {
            Console.Write("Enter hour (0-23h) : ");
            hour = int.Parse(Console.ReadLine());
            Console.Write("Enter minute (0-59) : ");
            minute = int.Parse(Console.ReadLine());
            Console.Write("Enter second (0-59) : ");
            second = int.Parse(Console.ReadLine());
        }
        public void Output24()
        {
            Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        }
        public void Output12()
        {
            string ampm = "AM";
            int h = hour;
            if (hour > 12)
            {
                h = hour - 12;
                ampm = "PM";
            }
            Console.WriteLine("{0:D2}:{1:D2}:{2:D2} {3}", h, minute, second, ampm);
        }
        public bool IsTimeValid()
        {
            if (hour < 0 || hour > 23)
                return false;
            if (minute < 0 || minute > 59)
                return false;
            if (second < 0 || second > 59)
                return false;
            return true;
        }
        public void AddSeconds(int seconds)
        {
            second += seconds;
            while (second >= 60)
            {
                second -= 60;
                minute++;

                if (minute >= 60)
                {
                    minute = 0;
                    hour++;

                    if (hour >= 24) { hour = 0; }
                }
            }
        }
        public void AddSeconds(int seconds, string format)
        {
            AddSeconds(seconds);

            if (format == "12")
            {
                Output12();
            }
            else
            {
                Output24();
            }
        }
        public void SubtractSeconds(int seconds)
        {
            second -= seconds;
            while (second < 0)
            {
                second += 60;
                minute--;
                if (minute < 0)
                {
                    minute = 59;
                    hour--;
                    if (hour < 0)
                    {
                        hour = 23;
                    }
                }
            }
        }
        public void SubtractSeconds(int seconds, string format)
        {
            SubtractSeconds(seconds);
            if (format == "12")
            {
                Output12();
            }
            else
            {
                Output24();
            }
        }
    }
}
