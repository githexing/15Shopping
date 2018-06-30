/*********************************************************************************
*Copyright(c) 	2012 RJ.COM
 * 创建日期：		2012-6-5 12:05:33
 * 文 件 名：		AdminEdit.cs
 * CLR 版本:		2.0.50727.3053
 * 创 建 人：		
 * 文件版本：		1.0.0.0
 * 修 改 人： 
 * 修改日期： 
 * 備注描述： 
**********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Library;
namespace Web.admin.system
{
    public partial class AdminEdit : AdminPageBase
    {
        lgk.BLL.tb_power powerBLL = new lgk.BLL.tb_power();//权限
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 32, getLoginID());//权限
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            tvAdminTree.Attributes.Add("onclick", "postBackByObject()");
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
                {
                    lblPrompt.Text = "密碼为空则是不修改";
                    txtUserCode.ReadOnly = true;
                    BindInfo(Request.QueryString["id"]);
                }
                else
                {
                    txtUserCode.ReadOnly = false;
                }
                getDataSource();
                BindTree();
            }
        }

        protected void BindInfo(string id)
        {
            lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(id));
            txtUserCode.Text = admin.UserName;
            txtName.Text = admin.TrueName;
        }
        void getDataSource()
        {

            DataTable dt = powerBLL.GetList("").Tables[0];
            ViewState["dt"] = dt;
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null && Request.QueryString["id"] != "1")
            {
                lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(Request.QueryString["id"]));

                if (admin.Limits != null && admin.Limits != "")
                {
                    ViewState["limits"] = admin.Limits.Split(',');
                }
                else
                {
                    ViewState["limits"] = new string[] { "0" };
                }
            }
            else
            {
                ViewState["limits"] = new string[] { "0" };
            }


        }
        DataTable dt_allPower
        {
            get
            {
                return ViewState["dt"] as DataTable;
            }
        }
        string[] str_limits
        {
            get
            {
                return (string[])ViewState["limits"];
            }
        }
        public void BindTree()
        {
            InitTreeView(dt_allPower);
        }

        /// <summary>
        /// 初始化树形圖
        /// </summary>
        /// <param name="dt"></param>
        private void InitTreeView(DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {
                return;
            }

            //TreeNode rootNode = new TreeNode("Root");

            DataTable powers = powerBLL.GetList(string.Format("ParentID = {0}", 0)).Tables[0];
            for (int i = 0; i < powers.Rows.Count; i++)
            {
                int id = int.Parse(powers.Rows[i]["ID"].ToString());
                string text = powers.Rows[i]["MenuName"].ToString();
                TreeNode childNode = new TreeNode(text, id.ToString());
                childNode.ShowCheckBox = true;
                if (isChecked(id.ToString()))
                {
                    childNode.Checked = true;
                }
                if (childNode != null)
                {
                    AddChilds(childNode, id);
                }
                //rootNode.ChildNodes.Add(childNode);
                tvAdminTree.Nodes.Add(childNode);
            }
            //tvAdminTree.Nodes.Add(rootNode);
        }

        private void AddChilds(TreeNode pNode, int pid)
        {
            DataTable powers = powerBLL.GetList(string.Format("ParentID = {0}", pid)).Tables[0];
            if (powers != null)
            {
                for (int i = 0; i < powers.Rows.Count; i++)
                {
                    string text = powers.Rows[i]["MenuName"].ToString();
                    string id = powers.Rows[i]["ID"].ToString();
                    TreeNode childNode = new TreeNode(text, id);
                    childNode.ShowCheckBox = true;

                    if (isChecked(id))
                    {
                        childNode.Checked = true;
                    }
                    pNode.ChildNodes.Add(childNode);
                }
            }
        }

        private bool isChecked(string id)
        {
            for (int i = 0; i < str_limits.Length; i++)
            {
                if (id == str_limits[i])
                {
                    return true;
                }
            }
            return false;
        }
        ///// <summary>
        /////递归添加子节点
        ///// </summary>
        ///// <param name="node"></param>
        ///// <param name="dt"></param>
        //private void AddChildNodes(TreeNode node, DataTable dt)
        //{
        //    if (node.Value.ToString() == "0")
        //    {
        //        return;
        //    }
        //    DataRow[] drList = dt.Select("ParentID =" + node.Value);
        //    foreach (DataRow dr in drList)
        //    {
        //        TreeNode cNode = new BLL.LimitsTreeNodeBLL(dr, str_limits);
        //        node.ChildNodes.Add(cNode);
        //        AddChildNodes(cNode, dt);
        //    }

        //}


        private void AddReg(TreeNode tn, DataTable dt)
        {
            if (tn.Value.ToString() == "0")
            {
                return;
            }
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            spd.jumpAdminUrl1(this.Page, 1);//跳转三级密码

            string limitsid = "";
            foreach (TreeNode node in tvAdminTree.Nodes)
            {
                if (node.Checked == true)
                {
                    limitsid += node.Value;
                    limitsid += ",";
                }
                foreach (TreeNode childNode in node.ChildNodes)
                {
                    if (childNode.Checked == true)
                    {
                        limitsid += childNode.Value;
                        limitsid += ",";
                    }
                }
            }
            if (limitsid.Length > 0)
            {
                limitsid = limitsid.Substring(0, limitsid.Length - 1);
            }
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null && Request.QueryString["id"] != "1")
            {
                if (ValidateUpdate())//更新
                {
                    lgk.Model.tb_admin admin = adminBLL.GetModel(int.Parse(Request.QueryString["id"]));
                    admin.TrueName = txtName.Text;
                    if (txtPass.Text.Trim().Length > 0)
                    {
                        admin.Password = PageValidate.GetMd5(txtPass.Text);
                    }
                    if (txtSecondPass.Text.Trim().Length > 0)
                    {
                        admin.SecondPassword = PageValidate.GetMd5(txtSecondPass.Text);
                    }
                    if (txtThirdPass.Text.Trim().Length > 0)
                    {
                        admin.ThirdPassword = PageValidate.GetMd5(txtThirdPass.Text);
                    }
                    admin.Limits = limitsid;
                    if (adminBLL.Update(admin))
                    {
                        MessageBox.ShowAndRedirect(this, "修改成功!", "AdminManage.aspx");
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "succeed", "alert('修改成功!')window.location='AdminManage.aspx'", true);
                        //Response.Redirect("AdminManage.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this, "修改失败!");
                        return;
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "fail", "alert('修改失败!')", true);
                    }
                }

            }
            else
            {

                if (ValidateAdd())//添加
                {
                    lgk.Model.tb_admin admin = new lgk.Model.tb_admin();
                    admin.UserName = txtUserCode.Text.Trim();
                    admin.TrueName = txtName.Text.Trim();
                    admin.Password = PageValidate.GetMd5(txtPass.Text.Trim());
                    admin.SecondPassword = PageValidate.GetMd5(txtSecondPass.Text.Trim());
                    admin.Limits = limitsid;
                    admin.AddDate = DateTime.Now;
                    admin.ThirdPassword = PageValidate.GetMd5(this.txtThirdPass.Text.Trim());
                    if (adminBLL.Add(admin) > 0)
                    {
                        MessageBox.ShowAndRedirect(this, "管理员添加成功!", "AdminManage.aspx");
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "succeed", "alert('管理员添加成功!');window.location='AdminManage.aspx'", true);
                    }
                    else
                    {
                        MessageBox.Show(this, "管理员添加失败!");
                        return;
                        //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "fail", "alert('管理员添加失败!')", true);
                    }
                }

            }
        }

        /// <summary>
        /// 验证添加
        /// </summary>
        /// <returns></returns>
        public bool ValidateAdd()
        {
            if (txtUserCode.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "管理员编号不能为空");
                return false;
            }

            lgk.Model.tb_admin admin = adminBLL.GetModel(txtUserCode.Text);
            if (admin != null)
            {
                MessageBox.Show(this, "已存在的管理员编号");
                return false;
            }

            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "管理员姓名不能为空");
                return false;
            }

            if (txtPass.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "登录密码不能为空");
                return false;
            }

            if (txtPass.Text != txtRPass.Text)
            {
                MessageBox.Show(this, "两次输入的登录密码不一致");
                return false;
            }

            if (txtSecondPass.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "二级密码不能为空");
                return false;
            }

            if (txtSecondPass.Text != txtRSecondPass.Text)
            {
                MessageBox.Show(this, "两次输入的二级密码不一致");
                return false;
            }
            if (txtThirdPass.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "三级密码不能为空");
                return false;
            }

            if (txtThirdPass.Text != txtRThirdPass.Text)
            {
                MessageBox.Show(this, "两次输入的三级密码不一致");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证更新
        /// </summary>
        /// <returns></returns>
        public bool ValidateUpdate()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "管理员姓名不能为空");
                return false;
            }
            if (txtPass.Text != txtRPass.Text)
            {
                MessageBox.Show(this, "两次输入的登录密码不一致");
                return false;
            }

            if (txtSecondPass.Text != txtRSecondPass.Text)
            {
                MessageBox.Show(this, "两次输入的二级密码不一致");
                return false;
            }
            if (txtThirdPass.Text != txtRThirdPass.Text)
            {
                MessageBox.Show(this, "两次输入的三级密码不一致");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAdminTree.Nodes)
            {
                foreach (TreeNode childNode in node.ChildNodes)
                {
                    childNode.Checked = ckCheck.Checked;
                }
                node.Checked = ckCheck.Checked;
            }
            ckUnCheck.Checked = false;
        }
        /// <summary>
        /// 反选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ckUnCheck_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAdminTree.Nodes)
            {
                foreach (TreeNode childNode in node.ChildNodes)
                {
                    if (childNode.Checked == true)
                    {
                        childNode.Checked = false;
                    }
                    else
                    {
                        childNode.Checked = true;
                    }
                }

                if (node.Checked == true)
                {
                    node.Checked = false;
                }
                else
                {
                    node.Checked = true;
                }
            }
            ckCheck.Checked = false;
        }

        /// <summary>
        /// 父节点全选子节点也全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tvAdminTree_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            //if (e.Node.Value == "0")
            //{
            //    foreach (TreeNode node in e.Node.ChildNodes)
            //    {
            //        node.Checked = e.Node.Checked;
            //    }
            //}
            bool isChecked = e.Node.Checked;
            if (e.Node.ChildNodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.ChildNodes)
                {
                    node.Checked = isChecked;
                }
            }
            bool ischeck = false;
            TreeNodeCollection vNodes; // 所在节点列表
            if (e.Node.Parent != null) // 最顶层节点
            {
                vNodes = e.Node.Parent.ChildNodes;
                foreach (TreeNode node in vNodes)
                {
                    if (node.Checked == true)
                    {
                        ischeck = true;
                        break;
                    }
                }
                e.Node.Parent.Checked = ischeck;
            }

        }

        protected void tvAdminTree_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert('ok');</script>",true);
            //ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "", "setTopLoad()", true);
            ScriptManager.RegisterClientScriptBlock(this, typeof(string), "tishi", "setTopLoad()", true);
        }
    }
}
