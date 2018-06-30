using DataAccess;
using Library;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.system
{
    public partial class AddCity : AdminPageBase
    {
        lgk.BLL.tb_TicketCity cotybll = new lgk.BLL.tb_TicketCity();
        protected void Page_Load(object sender, EventArgs e)
        {
            jumpMain(this, 66, getLoginID());//权限
            spd.jumpAdminUrl(this.Page, 1);//跳转二级密碼

            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            bind_repeater(cotybll.GetList(""), rpBank, "ID desc", trNull, anpCity);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if(textName.Value == "")
            {
                MessageBox.Show(this.Page, "机场名称不能为空");
                return;
            }
            if (textCode.Value == "")
            {
                MessageBox.Show(this.Page, "三字代码不能为空");
                return;
            }
            lgk.Model.tb_TicketCity model = new lgk.Model.tb_TicketCity();
            model.Name = textName.Value;
            model.Code = textCode.Value;
            model.City = city.Value;
            lgk.Model.tb_TicketCity ischeck = cotybll.GetModel(" Name='" + textName.Value + "'");
            if (ischeck == null)
            {
                cotybll.Add(model);
            }
            else
            {
                MessageBox.Show(this.Page, "该机场已存在");
            }
           
        }

        protected void rpBank_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "del")
            {
                if (cotybll.Delete(Convert.ToInt32(ID)))
                {
                    MessageBox.Show(this.Page, "删除成功!");
                }
                else
                {
                    MessageBox.Show(this.Page, "删除失败");
                }
            }
            BindData();
        }
        #region 导入exl
        protected void daoru_Click(object sender, EventArgs e)
        {
            //存放文件路径
            String filepath = "";

            //存放文件扩展名
            string fileExtName = "";
            //文件名
            string mFileName = "";
            //服务器上的相对路径
            string mPath = "";

            if (fu_excel.PostedFile.FileName != "")
            {
                //取得文件路径
                filepath = fu_excel.PostedFile.FileName;
                //取得文件扩展名
                fileExtName = filepath.Substring(filepath.LastIndexOf(".") + 1);
                //取得服务器上的相对路径
                mPath = this.Request.PhysicalApplicationPath + "UpLoadFiles\\Excel\\";
                //取得文件名
                mFileName = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                //保存文件到指定目录
                if (!Directory.Exists(mPath))
                {
                    try
                    {
                        Directory.CreateDirectory(mPath);
                    }
                    catch
                    {
                        MessageBox.Show(this.Page, "服务器创建存放目录失败");
                    }
                }
                //如果文件已经存在则删除原来的文件
                if (File.Exists(mPath + mFileName))
                {
                    try
                    {
                        File.Delete(mPath + mFileName);
                    }
                    catch
                    {
                        MessageBox.Show(this.Page, "服务器上存在相同文件，删除失败。");
                    }
                }

                #region 判断文件扩展名
                //判断上传文件格式
                Boolean fileOK = false;

                if (fu_excel.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(fu_excel.FileName).ToLower();
                    String[] allowedExtensions = { ".xls" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }
                #endregion

                #region 判断文件是否上传成功

                //判断文件是否上传成功
                bool fileUpOK = false;
                if (fileOK)
                {
                    try
                    {
                        //文件上传到服务器
                        fu_excel.PostedFile.SaveAs(mPath + mFileName);

                        fileUpOK = true;
                    }
                    catch
                    {
                        MessageBox.Show(this.Page, "文件上传失败！请确认文件内容格式符合要求！");
                    }
                }
                else
                {

                    MessageBox.Show(this.Page, "上传文件的格式错误，应为.xls格式！");

                }
                #endregion

                #region 将Excel填充到数据集

                //将Excel填充到数据集
                if (fileUpOK)
                {
                    System.Data.DataTable dt_User = new System.Data.DataTable();
                    try
                    {
                        //获取Excel表中的内容
                        dt_User = GetList(mPath + mFileName);
                        if (dt_User == null)
                        {
                            MessageBox.Show(this.Page, "获取Excel内容失败！");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this.Page, "获取Excel内容失败！");
                    }
                    int rowNum = 0;
                    try
                    {
                        rowNum = dt_User.Rows.Count;
                    }
                    catch
                    {
                        MessageBox.Show(this.Page, "Excel表获取失败！");
                    }
                    if (rowNum == 0)
                    {
                        MessageBox.Show(this.Page, "Excel为空表，无数据！");
                    }
                    else
                    {
                        //数据保存
                        SaveToDataBase(dt_User);
                    }
                }

                #endregion
            }

        }
        /// <summary>
        /// 根据Excel文件路径读取Excel表中第一个表的内容
        /// </summary>
        /// <param name="FilePath">Excel文件的物理路径</param>
        /// <returns>DataSet</returns>
        public System.Data.DataTable GetList(string FilePath)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + FilePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes; IMEX=1'";
            string strSql = string.Empty;
            string workSheetName = "Sheet1";
            if (workSheetName != "")
            {
                strSql = "select  * from [" + workSheetName + "$]";
                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    conn.Open();
                    OleDbDataAdapter myCommand = null;
                    myCommand = new OleDbDataAdapter(strSql, connectionString);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    myCommand.Fill(dt);
                    conn.Close();
                    conn.Dispose();
                    return dt;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        #region 将数据保存到数据库
        /// <summary>
        /// 将数据保存到数据库
        /// </summary>
        /// <param name="dt_user"></param>
        protected void SaveToDataBase(System.Data.DataTable dt_user)
        {
            //创建事务s
            SqlTransaction trans_user = null;
            SqlConnection con = new SqlConnection(PubConstant.ConnectionString);
            con.Open();
            //事务开始
            trans_user = con.BeginTransaction();
            try
            {
                
                for (int i = 0; i < dt_user.Rows.Count; i++)
                {
                    string sql = "";
                    lgk.Model.tb_TicketCity city = cotybll.GetModel("Name='"+ dt_user.Rows[i][0].ToString() + "'");
                    if (city == null)
                    {
                        sql = "insert into tb_TicketCity (Name,Code,City) values ('" + dt_user.Rows[i][0].ToString() + "','" + dt_user.Rows[i][1].ToString() + "','" + dt_user.Rows[i][2].ToString() + "')";
                    }
                    else
                    {
                        sql = "update tb_TicketCity set Code='" + dt_user.Rows[i][1].ToString() + "' where Name='"+ dt_user.Rows[i][0].ToString() + "'";
                    }
                    
                    object obj = DbHelperSQL.GetSingle(sql.ToString());
                }
                trans_user.Commit();
                //flagOk = true;
                MessageBox.Show(this.Page, "数据导入成功！");
            }
            catch (Exception ex)
            {
                trans_user.Rollback();

                MessageBox.Show(this.Page, "数据导入失败！" + ex.ToString().Substring(0, ex.ToString().IndexOf("。") + 1) + " <br />请检查文件内容后重新导入！");
            }
            finally
            {
                con.Close();
                trans_user = null;
            }
        }
        #endregion
        #endregion
        protected void anpCity_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}