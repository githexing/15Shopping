/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-11-30 14:51:00 
 * 文 件 名：		jiesuan.cs 
 * CLR 版本: 		2.0.50727.3643 
 * 创 建 人：		King
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 备注描述：         
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using Library;

namespace Web.admin.system
{
    public partial class jiesuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.GetSingle("exec proc_datebonus");
                MessageBox.Show(this, "日结成功!");
            }
            catch 
            {
                MessageBox.Show(this, "错误!");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.GetSingle("exec proc_monthbonus");
                MessageBox.Show(this, "月发成功!");
            }
            catch
            {
                MessageBox.Show(this, "错误!");
            }
        }
    }
}
