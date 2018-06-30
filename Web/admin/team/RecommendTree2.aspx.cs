using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;


namespace Web.admin.team
{
    public partial class RecommendTree2 : AdminPageBase//System.Web.UI.Page
    {
        int UserID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

            jumpMain(this, 73, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼
            if (!IsPostBack)
            {
                this.TreeView1.Nodes.Add(getTree(UserID));
            }
        }

        public TreeNode getTree(int uid)
        {
            lgk.Model.tb_user Model = new lgk.Model.tb_user();
            if (userBLL.GetModel(uid) == null)
            {
                return null;
            }
            Model = userBLL.GetModel(uid);
            TreeNode node = new TreeNode();
            string LevelName = levelBLL.GetModel(Model.LevelID).LevelName;
            string dd = "";
          //  string yeji= "";
            if (Model.IsOpend == 2)
            {
                dd = "[<span style='color:red;'>实单</span>]";
            }
            else if (Model.IsOpend==3)
            {
                dd = "[<span style='color:red;'>空单</span>]";
            }
            if (uid == 1)
            {
                node.Text = Model.UserCode + "+[团队业绩：" + Model.CenterScore + "]";
                node.ImageUrl = "../../images/ico_admin.gif";
                node.NavigateUrl = "RecommendTree2.aspx?userid=" + Model.UserID;
            }
            else
            {
                node.Text = Model.UserCode + Model.TrueName + "[" + LevelName + "]" + dd+"[团队业绩："+Model.CenterScore+"]";
                node.NavigateUrl = "RecommendTree2.aspx?userid=" + Model.UserID;
            }
            IList<lgk.Model.tb_user> list = userBLL.GetModelList(" ParentID = " + userBLL.GetModel(uid).UserID);
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string uName = txtUserCode.Text.Trim();
            if (!string.IsNullOrEmpty(uName))
            {
                if (GetUserID(uName) > 0)
                {
                    UserID = GetUserID(uName);
                    TreeView1.Nodes.Clear();
                    //BindData();
                    this.TreeView1.Nodes.Add(getTree(UserID));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('您要查询的会员编号不存在!');", true);
                }
            }
        }
    }
}
