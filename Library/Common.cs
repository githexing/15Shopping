using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Library
{
    public class Common
    {
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns>位数</returns>
        public string GetRandom(int length)
        {
            string radstr = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int a = random.Next(10);
                radstr += a.ToString();
            }
            return radstr;
        }

        /// <summary>
        /// 把DataRow[] 转为DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtRowList"></param>
        /// <returns></returns>
        public static DataTable DataRowListToDataTable(DataTable dt, DataRow[] dtRowList)
        {
            DataTable newdt = dt.Clone();
            for (int i = 0; i < dtRowList.Length; i++)
            {
                newdt.ImportRow((DataRow)dtRowList[i]);
            }
            return newdt;
        }

    }
}
