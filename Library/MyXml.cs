using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI;

namespace Library
{
    public class myxml
    {
        public myxml()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 加载所需的文字到datatable中
        /// tablename表名/类别名
        /// </summary>
        public static DataTable loadxml(string TableName)
        {
            System.Web.UI.Page p = new Page();
            DataSet ds = new DataSet();
            ds.ReadXml(p.Server.MapPath("./") + "//xml.xml");
            if (dtbool(ds, TableName))
            {
                //ds.Tables[TableName].PrimaryKey = new DataColumn[] { ds.Tables[TableName].Columns["name"]};
                return ds.Tables[TableName];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回所需文字
        /// dt内存已经存在的包含所需文字的表，name所需文字的名称
        /// </summary>
        public static string xmlword(DataTable dt, string name)
        {
            try
            {
                DataRow[] dr = dt.Select("[name] = '" + name + "'");
                return dr[0]["word"].ToString();
            }
            catch
            {
                return "未找到！";
            }
        }

        /// <summary>
        /// 返回所需文字
        /// type表名/类别名，name所需文字的名称
        /// </summary>
        public static string xmlword(string type, string name)
        {
            System.Web.UI.Page p = new Page();
            //DataRow[] dr = new DataRow();
            DataSet ds = new DataSet();
            ds.ReadXml(p.Server.MapPath("./") + "//xml.xml");
            if (dtbool(ds, type))
            {
                return ds.Tables[type].Select("name='" + name+"'")[0]["word"].ToString();
            }
            return "";
        }

        private static bool dtbool(DataSet ds1, string dtname)
        {
            for (int i = 0; i <= ds1.Tables.Count - 1; i++)
            {
                if (ds1.Tables[i].TableName == dtname)
                    return true;
            }
            return false;
        }
    }
}
