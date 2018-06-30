/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-4-14 12:17:16 
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
using Library;
using DataAccess;

namespace Web.user.team
{
    public partial class RecommendTree : PageCore//System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spd.jumpUrl(this.Page, 1);//跳转二级密码

            if (!IsPostBack)
            {
                //if (Request.QueryString["UserID"] != "" || Request.QueryString["UserID"] != null)
                //{
                //    this.TreeView1.Nodes.Add(getTree(Convert.ToInt64(Request.QueryString["UserID"])));
                //}
                uid.Value = getLoginID().ToString();
                tage.Value = "ht";
               // this.TreeView1.Nodes.Add(getTree(getLoginID()));

                //Button4.Text = GetLanguage("MemberList");//会员列表
                //Button1.Text = GetLanguage("AvailableMembers");//已开通会员
                //btnSearch.Text = GetLanguage("Search");//搜索
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
            string strLevelName = levelBLL.GetLevelName(userInfo.LevelID, GetLanguage("LoginLable"));
            //是否开通
            string dd = "";
            if (userInfo.IsOpend == 0)
            {
                if (GetLanguage("LoginLable") == "zh-cn")
                {
                    dd = "[<span style='color:red;'>未开通</span>]";
                }
                else
                {
                    dd = "[<span style='color:red;'>Not Yet Opened</span>]";
                }
            }
            else if (userInfo.IsOpend == 2)
            {
                if (GetLanguage("LoginLable") == "zh-cn")
                {
                    dd = "[已开通]";
                }
                else
                {
                    dd = "[Opened]";
                }
            }

            if (uid == 2)
            {
                node.Text = userInfo.UserCode;
                node.ImageUrl = "../../images/ico_admin.gif";
                node.NavigateUrl = "RecommendTree.aspx?UserID=" + userInfo.UserID;
            }
            else
            {
                if (GetLanguage("LoginLable") == "zh-cn")
                {
                    if (userBLL.GetLocation(userInfo.UserID) > 1)
                    {
                        
                        node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + strLevelName + "]" + dd + "【团队业绩" + userInfo.User018+ "】【本金："+ userInfo.RegMoney+"】";
                    }
                    else
                    {
                        node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + strLevelName + "]" + dd + "【团队业绩" + 0+ "】【本金：" + userInfo.RegMoney + "】";
                    }
                   
                }
                else
                {
                    if (userBLL.GetLocation(userInfo.UserID) > 1)
                    {
                        node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + strLevelName + "]" + dd + "【团队业绩" + userInfo.User018 + "】【本金：" + userInfo.RegMoney + "】";
                    }
                    else
                    {
                        node.Text = userInfo.UserCode + "[" + userInfo.TrueName + "][" + strLevelName + "]" + dd + "【团队业绩" + 0 + "】【本金：" + userInfo.RegMoney + "】";
                    }
                }
                node.NavigateUrl = "RecommendTree.aspx?UserID=" + userInfo.UserID;
            }
            int dai = LoginUser.RecommendGenera+100000;
            IList<lgk.Model.tb_user> list = userBLL.GetModelList(" RecommendGenera<"+ dai.ToString() +" AND RecommendID = " + userBLL.GetModel(uid).UserID);
            if (list == null)
            {
                return null;
            }
            foreach (lgk.Model.tb_user item in list)
            {
                node.ChildNodes.Add(getTree(Convert.ToInt32(item.UserID)));
            }
            return node;
        }

        #region 搜索
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    int UserID = getLoginID();
        //    string uName = this.txtUserCode.Text.Trim();
        //    if (UserID == 2)
        //    {
        //        if (!string.IsNullOrEmpty(uName))
        //        {
        //            if (GetUserID(uName) > 0)
        //            {
        //                UserID = GetUserID(uName);
        //                TreeView1.Nodes.Clear();
        //                this.TreeView1.Nodes.Add(getTree(UserID));
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("WantUserIsNull") + "');", true);//您要查询的会员编号不存在
        //            }
        //        }
        //    }
        //    else
        //    {

        //        if (!string.IsNullOrEmpty(uName))
        //        {
        //            if (GetUserID(uName) > 0)
        //            {
        //                if (checkName(GetUserID(uName)))
        //                {
        //                    UserID = GetUserID(uName);
        //                    TreeView1.Nodes.Clear();
        //                    this.TreeView1.Nodes.Add(getTree(UserID));
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("WantUserIsdownline") + "');window.location.href='RecommendTree.aspx'", true);//您要查询的会员编号不在您的下线
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("WantUserIsNull") + "');window.location.href='RecommendTree.aspx'", true);//您要查询的会员编号不存在
        //            }
        //        }
        //    }
        //} 
        #endregion

        private bool checkName(int p)
        {
            bool result = false;
            string strPath = DbHelperSQL.GetSingle("select RecommendPath from tb_user where UserID =" + getLoginID()).ToString();
            string strSql = string.Format("select count(0) from tb_user where RecommendPath like '%{0}%' and UserID={1}", getLoginID(), p);
            if (int.Parse(DbHelperSQL.GetSingle(strSql).ToString()) > 0)
            {
                result = true;
            }
            return result;
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            Response.Write("<script>parent.document.all('mainFrame').style.height=document.body.scrollHeight+1;</script>");
        }

    }
}