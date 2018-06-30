using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library
{
    public class UserCode
    {
        private string GetNumCode(int num)
        {
            switch (num)
            {
                case 0:
                    return "a";
                case 1:
                    return "b";
                case 2:
                    return "c";
                case 3:
                    return "d";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "g";
                case 7:
                    return "h";
                case 8:
                    return "i";
                case 9:
                    return "j";
                case 10:
                    return "k";
                case 11:
                    return "m";
                case 12:
                    return "n";
                case 13:
                    return "p";
                case 14:
                    return "r";
                case 15:
                    return "s";
                case 16:
                    return "t";
                case 17:
                    return "w";
                case 18:
                    return "x";
            }
            return "y";
        }

        private int Sum(int num)
        {
            if (num > 9)
            {
                string first = num.ToString().Substring(0, 1);
                string last = num.ToString().Substring(1, 1);
                int n = Convert.ToInt32(first) + Convert.ToInt32(last);
                return n;
            }
            return num;
        }

        private string GetSumCode(int num)
        {
            return GetNumCode(num);
        }

        private string GetAnyCode()
        {
            int year = DateTime.Now.Year - 2000;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            string y = GetSumCode(Sum(year));
            string mon = GetSumCode(Sum(month));
            string d = GetSumCode(Sum(day));
            string h = GetSumCode(Sum(hour));
            string m = GetSumCode(Sum(minute));

            Random ran = new Random();
            
            int yran = ran.Next(0, 18);
            string ycode = GetSumCode(yran);
            int monran = ran.Next(0, 18);
            string moncode = GetSumCode(monran);
            int dran = ran.Next(0, 18);
            string dcode = GetSumCode(dran);
            int hran = ran.Next(0, 18);
            string hcode = GetSumCode(hran);
            if (second > 9)
            {
                return ycode + moncode + dcode + hcode + m + second.ToString();
            }
            int r = ran.Next(0, 9);
            return ycode + moncode + dcode + hcode + m + second.ToString() + r.ToString();
        }

        public string GetCode()
        {
            return GetNumber7();
        }

        private string GetNumber7()
        {
            Random ran = new Random();
            int index = 1;
            string num = "";
            while (index < 8)
            {
                num += ran.Next(0, 9);
                index++;
            }
            return num;
        }
    }
}