/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-5-16 9:35:28 
 * 文 件 名：		index.cs 
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;

namespace Web.admin
{
    public partial class index : AdminPageBase//System.Web.UI.Page
    {
        protected string strUserName = "";
        protected string strTrueName = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strUserName = adminBLL.GetModel(getLoginID()).UserName;
                strTrueName = adminBLL.GetModel(getLoginID()).TrueName;
               
                lgk.Model.tb_admin adminInfo = new lgk.BLL.tb_admin().GetModel(getLoginID());
                if (adminInfo.Limits != null && adminInfo.Limits != "")
                {
                    BindData("id in(" + adminInfo.Limits + ") and parentid =0 and (select count(*) from tb_power where parentid=p.id and id in ("
                        + adminInfo.Limits + "))>0");
                }
            }
        }

        public string GetList(object id)
        {
            int i = 1;
            string strLimits = "";
            lgk.Model.tb_admin adminInfo = new lgk.BLL.tb_admin().GetModel(getLoginID());
            strLimits = adminInfo.Limits;
            string htmlli = "";
            List<lgk.Model.tb_power> powerInfo = info_prower.GetModelList("id in (" + strLimits + ") and parentid=" + id.ToString());
            foreach (lgk.Model.tb_power item in powerInfo)
            {
                htmlli += "<a href=\"" + item.URL + "\"  target=\"win\">" + item.MenuName + "</a>";
                if (i != powerInfo.Count()) { htmlli += "<span>|</span>"; } i++;
            }
            return htmlli;
        }

        private void BindData(string str)
        {
            bind_repeater(info_prower.GetPowerList(str), Repeater1, "id ", null);
        }

        /// <summary>
        /// 嵌套二级链接
        /// </summary>
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，HeaderTemplate，，ItemTemplate，SeparatorTemplate）
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("Repeater2") as Repeater;//找到里层的repeater對象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分類Repeater关联的數据项 
                lgk.Model.tb_admin item_admin1 = new lgk.BLL.tb_admin().GetModel(getLoginID());
                if (item_admin1 != null)
                {
                    string aas = " and MenuName not IN ('消费管理','报单奖金')";
                    //过滤申请提现菜单16 和奖金明细44 商品管理36 报单奖金15
                    DataSet ds = info_prower.GetList("id in (" + item_admin1.Limits + ") and parentid=" + rowv["ID"].ToString().Trim() + aas);//获取填充子類的id 
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rep.DataSource = ds;
                        rep.DataBind();
                    }
                }
            }
        }
    }
}
