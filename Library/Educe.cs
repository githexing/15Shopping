/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-1-13 17:30:26 
 * 文 件 名：		Educe.cs 
 * CLR 版本: 		2.0.50727.3053 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Data.SqlClient;
using Library;

namespace Library
{
    public class Educe
    {
        public List<string> Tname(string s)
        {
            List<string> list = new List<string>();
            DataSet ds = new DataSet();
            ds.ReadXml(s);

            for (int i = 0; i <= ds.Tables.Count - 1; i++)
            {
                list.Add(ds.Tables[i].TableName);
            }
            return list;
        }

        public List<string> TCboxlist(string s, string name)
        {
            List<string> list = new List<string>();
            DataSet ds = new DataSet();
            ds.ReadXml(s);
            for (int i = 0; i <= ds.Tables[name].Rows.Count - 1; i++)
            {
                list.Add(ds.Tables[name].Rows[i]["word"].ToString());
            }
            return list;
        }

        public string Sbox(System.Web.UI.WebControls.CheckBoxList boxlist, int a)
        {
            string str = a + ",,";
            for (int i = 0; i <= boxlist.Items.Count - 1; i++)
            {
                if (boxlist.Items[i].Selected == true)
                {
                    str += i.ToString() + ",";
                }

            }
            return str;
        }

        public List<string> reTime(int a)
        {

            switch (a)
            {
                case 1:
                case 2:
                case 3:
                    return reTime1();
                case 4:
                    return reTime2();
                case 5:
                    return reTime3();
            }
            List<string> li = new List<string>();
            return li;
        }

        private List<string> reTime1()//结算周期时间
        {
            List<string> list = new List<string>();
            SqlDataReader dr = DbHelperSQL.ExecuteReader("select balancelist02 from balancelist");
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            dr.Close();
            return list;
        }

        private List<string> reTime2()//周结算周期时间
        {
            List<string> li = new List<string>();
            SqlDataReader dr = DbHelperSQL.ExecuteReader("select weekbalance02 from weekbalance");
            while (dr.Read())
            {
                li.Add(dr[0].ToString());
            }
            dr.Close();
            return li;
        }

        private List<string> reTime3()//出账的周期
        {
            List<string> li = new List<string>();
            SqlDataReader dr = DbHelperSQL.ExecuteReader("select Accounts02 from Accounts");
            while (dr.Read())
            {
                li.Add(dr[0].ToString());
            }
            dr.Close();
            return li;
        }
        /// <summary>
        /// ec2页面显示已经选择的字段
        /// </summary>
        /// <param name="a"></param>
        /// <param name="str"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<string> restr(int a, string str, string path)
        {
            string[] ss = str.Remove(str.Length - 1).Split(',');
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            List<string> list = new List<string>();
            if (ds.Tables.Count > 0)
            {

                for (int i = 0; i <= ss.Length - 1; i++)
                {
                    list.Add(ds.Tables[a - 1].Rows[Convert.ToInt32(ss[i])]["word"].ToString());
                }
            }
            return list;

        }


        public string daochu(DataTable dt, System.Collections.Hashtable htb, string path, string title)
        {
            string ExcelFolder = "File";
            string FilePath = path + "\\" + ExcelFolder + "\\";
            DataToExcel dte = new DataToExcel();
            string filename = "";
            try
            {
                if (dt.Rows.Count > 0)
                {
                    filename = dte.DataExcel(dt, title, FilePath, htb);
                }
            }
            catch (Exception er)
            {
                //dte.KillExcelProcess();
                return er.ToString();
            }

            //if (filename != "")
            //{
            //    Response.Redirect("../" + ExcelFolder + "\\" + filename, true);
            //}
            return ExcelFolder + "\\" + filename;
        }
    }
}
