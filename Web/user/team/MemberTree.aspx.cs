/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-1-12 13:55:20 
 * 文 件 名：		MemberTree.cs 
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
using lgk.Model;
using lgk.BLL;
using Library;
using DataAccess;

namespace web.user.team
{
    public partial class MemberTree : PageCore
    {
        private long x = 1;
        private int y = 2;
        private int z = 2;//3;
        private static int _selectPlatform = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            spd.jumpUrl(this.Page, 1);//跳转二级密码
            //spd.jumpUrl1(this.Page, 1);//跳转3级密码
            if (!IsPostBack)
            {
                BindTreeRe();
                x = GetUserID();
                ViewState["x"] = x;
                ViewState["y"] = y;
                ViewState["z"] = z;
            }
            else
            {
                x = int.Parse(ViewState["x"].ToString());
                y = int.Parse(ViewState["y"].ToString());
                z = int.Parse(ViewState["z"].ToString());
            }
            btnSearch.Text = GetLanguage("GoTo");//挑转
            btnMy.Text = GetLanguage("MyPedigree");//我的系谱图
            Button1.Text = GetLanguage("pre");//上一级
            Button2.Text = GetLanguage("next");//下一级
        }

        private void BindTreeRe()
        {
            long iUID = GetUserID();

            lgk.BLL.UserView uview = new UserView(iUID, y, z, _selectPlatform, 0, GetLanguage("LoginLable"));
            Literal1.Text = uview.AddTable();
        }

        private long GetUserID()
        {
            if (getIntRequest("tt") != 0)
            {
                return getLongRequest("tt");
            } return getLoginID();
        }

        private void BindTree()
        {
            UserView uview = new UserView(x, y, z, _selectPlatform, 0, GetLanguage("LoginLable"));
            Literal1.Text = uview.AddTable();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtUserCode.Text != "")
            {
                int xNode = GetUserID(txtUserCode.Text);
                if (xNode != 0)
                {

                    if (!getli(txtUserCode.Text))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NoLuck") + "');window.location.href='MemberTree.aspx?tt=0," + getLoginID() + "'", true);//没有查看权限
                    }
                    else
                    {
                        x = xNode;
                        ViewState["x"] = x;
                        BindTree();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('" + GetLanguage("NoSuchUser") + "');", true);//没有这个用户
                    BindTree();
                }
            }
        }

        private bool getli(string p)
        {
            string str = DbHelperSQL.GetSingle("select UserPath from tb_user where UserCode='" + p + "'").ToString();
            string[] strs = str.Split('-');
            //int uid = Convert.ToInt32(Request.Cookies["user"].Values["ID"]);
            for (int i = 0; i <= strs.Length - 1; i++)
            {
                if (strs[i] == getLoginID().ToString())
                {
                    return true;
                }
            }
            return false;
        }

        protected void btnMy_Click(object sender, EventArgs e)
        {
            x = getLoginID();
            ViewState["x"] = x;
            BindTree();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            z = z - 1;
            if (z < 2) z = 2;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            z = z + 1;
            ViewState["z"] = z;
            BindTree();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "11", "parent.document.all('mainFrame').style.height=document.body.scrollHeight;", true);
        }

        //protected void ddlG_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    UserView uview = new UserView(GetUserID(), Convert.ToInt32(ddlG.SelectedValue), z, _selectPlatform);
        //    Literal1.Text = uview.AddTable();
        //}

        /// <summary>
        /// 移动数据验证
        /// </summary>
        //private bool CheckMove()
        //{
        //    if (txtMoveUser.Text.Trim() == "")
        //    {
        //        MessageBox.Show(this, "请输入要移动用户名");
        //        return false;
        //    }
        //    if (txtTargetUser.Text.Trim() == "")
        //    {
        //        MessageBox.Show(this, "请输入目标用户名");
        //        return false;
        //    }
        //    int loca = 0;
        //    int.TryParse(ddlLocation.SelectedValue.Trim(), out loca);
        //    if (loca <= 0 || loca > 2)
        //    {
        //        MessageBox.Show(this, "请输入要放入的位置");
        //        return false;
        //    }
        //    return true;
        //}

        /// <summary>
        /// 移动会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void BtnMove_Click(object sender, EventArgs e)
        //{
        //    if (CheckMove())
        //    {
        //        if (LoginUser == null)
        //        {
        //            return;
        //        }
        //        List<long> idList = new List<long>();
        //        if (!string.IsNullOrEmpty(LoginUser.UserPath))
        //        {
        //            string whereCondition = "'-'+CAST(UserPath AS NVARCHAR(2000))+'-' LIKE '%-"+LoginUser.UserID+"-%'";
        //            var userList= userBLL.GetModelList(whereCondition);
        //            foreach (var item in userList)
        //            {
        //                idList.Add(item.UserID);
        //            }
        //        }
        //        var moveUser = userBLL.GetModel(" userCode='" + txtMoveUser.Text.Trim() + "'");
        //        if (moveUser == null)
        //        {
        //            MessageBox.Show(this, "要移动的用户不存在");
        //            return;
        //        }
        //        var targetUser = userBLL.GetModel(" userCode='" + txtTargetUser.Text.Trim() + "'");
        //        if (targetUser == null)
        //        {
        //            MessageBox.Show(this, "目标用户不存在");
        //            return;
        //        }
        //        if (!idList.Contains(moveUser.UserID))
        //        {
        //            MessageBox.Show(this,"要移动会员不在您的系谱图中无法移动");
        //            return;
        //        }
        //        if (!idList.Contains(targetUser.UserID))
        //        {
        //            MessageBox.Show(this, "目标会员不在您的系谱图中无法移动");
        //            return;
        //        }
        //        bool IsMoveUserHasChildren = userBLL.HasChildren(moveUser.UserID);
        //        var locationNode = userBLL.GetModel(" parentID=" + targetUser.UserID + " and Location=" + ddlLocation.SelectedValue);
        //        int hasChild = locationNode == null ? 0 : 1;
        //        if (IsMoveUserHasChildren && hasChild == 1)
        //        {
        //            MessageBox.Show(this, "该位置已有会员，网络图无法插入到已有会员的位置");
        //            return;
        //        }
        //        bool flag = false;
        //        if (IsMoveUserHasChildren)//移动网络
        //        {
        //            flag = flag_InsertUserNet(txtMoveUser.Text.Trim(), txtTargetUser.Text.Trim(), int.Parse(ddlLocation.SelectedValue)) > 0;
        //        }
        //        else//移动单个会员
        //        {
        //            flag = flag_InsertUser(txtMoveUser.Text.Trim(), txtTargetUser.Text.Trim(), int.Parse(ddlLocation.SelectedValue)) > 0;
        //        }
        //        if (flag)
        //        {
        //            MessageBox.Show(this, "插入成功");
        //        }
        //    }
        //    //绑定树
        //    BindTreeRe();
        //    x = GetUserID();
        //    ViewState["x"] = x;
        //    ViewState["y"] = y;
        //    ViewState["z"] = z;
        //}

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Session["reg_usercode"] = LoginUser.UserCode;
            Response.Redirect("/Registers.aspx");
        }

    }
}