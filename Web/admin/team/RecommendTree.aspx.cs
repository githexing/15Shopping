/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-14 12:10:42 
 * 文 件 名：		RecommendTree.cs 
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
using System.Text;
using Library;

namespace Web.admin.team
{
    public partial class RecommendTree : AdminPageBase//System.Web.UI.Page
    {
       private long UserID = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 3, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                uid.Value = getLoginID().ToString();
                tage.Value = "ht";
                //getTree(UserID);
                //this.TreeView1.Nodes.Add(getTree(UserID));
            }
        }

        public TreeNode getTree(long uid)
        {
            lgk.Model.tb_user userInfo = new lgk.Model.tb_user();
            if (userBLL.GetModel(uid) == null)
            {    
                return null;
            }
            userInfo = userBLL.GetModel(uid);
            TreeNode node = new TreeNode();
            string LevelName = levelBLL.GetLevelName(userInfo.LevelID);
            string dd = "";
            //是否开通
            if (userInfo.IsOpend == 0)
            {
                dd = "[<span style='color:red;'>未开通</span>]";
            }
            else if (userInfo.IsOpend == 2)
            {
                dd = "[已开通]";
            }

            if (uid == 1)
            {
                node.Text = userInfo.UserCode;
                node.ImageUrl = "../../images/ico_admin.gif";
                node.NavigateUrl = "RecommendTree.aspx?UserID=" + userInfo.UserID;
            }
            else
            {
                if (userBLL.GetLocation(userInfo.UserID) > 1)
                {
                    node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + LevelName + "]" + dd + "【团队业绩" + userInfo.User018 + "】【本金：" + userInfo.RegMoney + "】";
                    //node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + LevelName + "]" + dd + "【团队业绩" + userInfo.User018 + "】";
                }
                else
                {
                    node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + LevelName + "]" + dd + "【团队业绩" + userInfo.User018 + "】【本金：" + userInfo.RegMoney + "】";
                    //node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + LevelName + "]" + dd + "【团队业绩" + 0 + "】";
                }
               // node.Text = userInfo.UserCode + userInfo.TrueName + "[" + LevelName + "]" + dd;
                node.NavigateUrl = "RecommendTree.aspx?UserID=" + userInfo.UserID;
            }
            IList<lgk.Model.tb_user> list = userBLL.GetModelList(" RecommendID = " + userBLL.GetModel(uid).UserID);
            if (list == null)
            {
                return null;
            }
            foreach (lgk.Model.tb_user item in list)
            {
                node.ChildNodes.Add(getTree(item.UserID));
            }
            return node;
        }
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string uName = txtUserCode.Text.Trim();
        //    if (!string.IsNullOrEmpty(uName))
        //    {
        //        if (GetUserID(uName) > 0)
        //        {
        //            UserID = GetUserID(uName);
        //            //TreeView1.Nodes.Clear();
        //            //BindData();
        //            //this.TreeView1.Nodes.Add(getTree(UserID));
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您要查询的会员编号不存在!');", true);
        //        }
        //    }
        //}
    }
}
