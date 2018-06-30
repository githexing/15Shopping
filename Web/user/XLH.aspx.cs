using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.user
{
    public partial class XLH : AllCore
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Text1.Value = Request["UserCode"] == null ? "" : Request["UserCode"].ToString();
            }
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {


            lgk.Model.tb_user user = userBLL.GetModel(GetUserID(Text1.Value.Trim()));
            if (user==null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名不正确');", true);
                return;
            }
            if (user.IsLock > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户被冻结！');", true);
                return;
            }
            string a = Luodian();
            if (a == "")
            {
                MessageBox.ShowBox(this.Page, "", "落点失败！", Library.Enums.ModalTypes.error);//注册失败
                return;
            }
            string[] ID = a.Split('-');//ID[0]=UserID ID[1]=Location ID[2]=ParentID ID[3]=ParentCode  ID[4]=Layer
            var l = userBLL.GetModel(int.Parse(ID[2]));
            //user.RecommendPath = model_1.RecommendPath + "-" + user.UserID.ToString();
            user.ParentID = int.Parse(ID[2]);//父节点ID
            user.ParentCode = ID[3];//父节点編號
            user.UserPath = l.UserPath+"-"+user.UserID;
            user.Layer = int.Parse(ID[4]);//属于多少层
            user.Location = int.Parse(ID[1]);
            user.OpenTime = DateTime.Now;
            //检验序列号
            string xlh = PageValidate.GetMd5(user.UserID.ToString()).ToUpper();
            if (Phone.Value.ToUpper().Trim()!= xlh)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('序列号不正确');", true);
                return;
            }
            user.IsOpend = 2;
           
            var aa =user.RecommendPath.Split('-');
            int UID = 0;
            for (int i = 0; i < aa.Count(); i++)
            {
                UID = int.Parse(aa[aa.Count() - i - 1]);
                if (userBLL.IsAgent(UID))
                {
                    
                    user.User006 = userBLL.GetUserCode(UID);
                    user.AgentsID = agentBLL.GetAgentsID(user.User006);
                }
                continue;
            }


            userBLL.Update(user);
            string UserName = this.Phone.Value.Trim();
            UserUtil.Login(UserName, "A128076_user", false);
            //放入cookie
            HttpCookie UserCookie = new HttpCookie("A128076_user");
            UserCookie["Id"] = user.UserID.ToString();
            UserCookie["name"] = UserName;
            Response.AppendCookie(UserCookie);
            //HttpCookie CultureCookie = new HttpCookie("Culture");
            //CultureCookie.Value = "zh-cn";//中文
            //Response.AppendCookie(CultureCookie);
            HttpCookie Culture;

            if (HttpContext.Current.Request.Cookies["Culture"] == null)
                Culture = new HttpCookie("Culture");
            else
                Culture = HttpContext.Current.Request.Cookies["Culture"];

           
                Culture.Value = "zh-cn";//中文 
            Response.AppendCookie(Culture);

            //登录系统
            Response.Redirect("/user/index.aspx");
        }

        private string Luodian()
        {

            lgk.Model.tb_user user = userBLL.GetModel(GetUserID(Text1.Value.Trim()));
            if (user == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户名不正确');", true);
                return "";
            }
            if (user.IsLock > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "info", "alert('用户被冻结！');", true);
                return "";
            }

            string UserID = user.RecommendID == 1 ? "1-" : "-" + user.RecommendID + "-";
            var model = userBLL.GetModel(user.RecommendID);//推荐人
            //string sconn = System.Configuration.ConfigurationManager.AppSettings["SocutDataLink"];
            string sql = " select count(userid)Count from tb_user ;";
            DataTable dt = userBLL.getData_Chaxun(sql, "").Tables[0];
            int Count = int.Parse(dt.Rows[0]["Count"].ToString());//总人数 

            var Gender = model.Gender;//点位方向
            if (Gender==0)
            { 
                UpdateAccount("Gender", model.UserID, 2, 1);//修改
                return model.UserID + "-1-" + model.UserID + "-" + model.UserCode + "-"+ (model.Layer+1); 
            } 
            else  if (Gender==1)//放左边
            {
                var mUserID = model.UserID;//推荐人UserID
             
                for (int i = 0; i < Count; i++)
                {
                   
                    var model1 = userBLL.GetList(" Location=1 and ParentID='" + mUserID + "'").Tables[0];//查Location=1的伞下会员 
                    if (model1.Rows.Count > 0)//大于0 说明有人
                    {
                      
                        mUserID = int.Parse(model1.Rows[0]["UserID"].ToString());
                        continue;
                    }
                    else//说明没人了 就落这个点位
                    {
                        model1 = userBLL.GetList(" UserID="+ mUserID + "").Tables[0];//查询上个会员

                        long  userID = long.Parse(model1.Rows[0]["UserID"].ToString());//落在这个下边
                        string UserCode = model1.Rows[0]["UserCode"].ToString(); //落在这个下边的名字 
                        int Layer= int.Parse(model1.Rows[0]["Layer"].ToString());
                        Layer += 1;
                        
                        //ID[0]=UserID ID[1]=Location ID[2]=ParentID ID[3]=ParentCode  ID[4]=UserPath ID[5]=Layer 
                        UpdateAccount("Gender", model.UserID,1,1);//修改
                        return userID + "-1-" + userID+"-"+ UserCode+"-"+ Layer;
                        //break;
                    }  
                }

            }
            else// 放右边，先找该会员右边的人， 在找Location=1的人
            {
                var mUserID = model.UserID;//推荐人UserID
                var model2 = userBLL.GetList(" Location=2 and ParentID='" + mUserID + "'").Tables[0]; 
                if (model2.Rows.Count==0)//该会员右边的人（第一个）
                {
                    model2 = userBLL.GetList(" UserID=" + mUserID + "").Tables[0];//查询上个会员
                    long userID = long.Parse(model2.Rows[0]["UserID"].ToString());
                    string UserCode = model2.Rows[0]["UserCode"].ToString();
                   
                    int Layer = int.Parse(model2.Rows[0]["Layer"].ToString());
                    Layer += 1; 
                    UpdateAccount("Gender", model.UserID, 1, 0);//修改
                    //string sql1 = " select userid from tb_user where RecommendID=" + mUserID + " ;";
                    //DataTable dt1 = userBLL.getData_Chaxun(sql1, "").Tables[0];
                    //if (dt1.Rows.Count == 0)
                    //{
                    //    return userID + "-1-" + userID + "-" + UserCode + "-" + Layer;
                    //}
                    //else
                    //{
                        return userID + "-2-" + userID + "-" + UserCode + "-" + Layer;
                    //}
                }
                //重新赋值
                mUserID = int.Parse(model2.Rows[0]["UserID"].ToString());
               
                for (int i = 0; i < Count; i++)
                {
                 
                    model2 = userBLL.GetList(" Location=1 and ParentID='" + mUserID + "'").Tables[0];//找右边会员 方向向左边的会员
                    if (model2.Rows.Count > 0)//大于0 说明有人
                    {
                      
                        mUserID = int.Parse(model2.Rows[0]["UserID"].ToString());
                        continue;
                    }
                    else//说明没人了 就落这个点位
                    {
                        model2 = userBLL.GetList(" UserID=" + mUserID + "").Tables[0];//查询上个会员
                        long userID = long.Parse(model2.Rows[0]["UserID"].ToString());
                        string UserCode = model2.Rows[0]["UserCode"].ToString();
                       
                        int Layer = int.Parse(model2.Rows[0]["Layer"].ToString());
                        Layer += 1;
                      
                        //ID[0]=UserID ID[1]=Location ID[2]=ParentID ID[3]=ParentCode  ID[4]=UserPath ID[5]=Layer 
                        UpdateAccount("Gender", model.UserID, 1, 0);//修改
                        //string sql1 = " select userid from tb_user where RecommendID=" + mUserID + " ;";
                        //DataTable dt1 = userBLL.getData_Chaxun(sql1, "").Tables[0];  
                        //if (dt1.Rows.Count==0)
                        //{
                            return userID + "-1-" + userID + "-" + UserCode + "-" + Layer;
                        //}
                        //else
                        //{
                        //    return userID + "-2-" + userID + "-" + UserCode + "-" + Layer;
                        //}
                      
                        //break;
                    }
                }
            }
            return "";
            ////小公排
            //string sql_1 = "select count(UserID) RS from tb_user ;";
            //DataTable dt_1 = userBLL.getData_Chaxun(sql_1, "").Tables[0];
            //int RS = int.Parse(dt_1.Rows[0]["RS"].ToString());
            //for (int i = 1; i <= RS; i++)
            //{
            //    //第一层
            //    string sql = "select count(UserID) RS from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i) + " ;";
            //    DataTable dt = userBLL.getData_Chaxun(sql, "").Tables[0];
            //    int count = int.Parse(dt.Rows[0]["RS"].ToString());
            //    if (count == i * 2)//人数满了 就回去 下一层
            //    {
            //        continue;
            //    }

            //    //否则 按这上层来找
            //    if (model.Layer + i - 1 == 1)
            //    {
            //        UserID = "1";
            //        sql = "select UserID from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i - 1) + " ;";
            //    }
            //    else
            //    {
            //        sql = "select UserID from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i - 1) + " ;";
            //    }

            //    dt = userBLL.getData_Chaxun(sql, "").Tables[0];
            //    //if (dt.Rows.Count==0)//如果下一层没有人的处理
            //    //{
            //    //    sql = "select min(UserID)UserID from tb_user where UserPath like '%" + UserID + "%' and Layer=" + (model.Layer + i-1) + " ;";
            //    //    dt = userBLL.getData_Chaxun(sql, "").Tables[0];
            //    //    long Userid = long.Parse(dt.Rows[0]["UserID"].ToString());
            //    //    return Userid + "-" + 1;

            //    //}
            //    for (int ii = 0; ii < i * 2; ii++)
            //    {
            //        long Userid = long.Parse(dt.Rows[ii]["UserID"].ToString());
            //        string sql2 = "select UserID RS from tb_user where ParentID = " + Userid + " ";
            //        DataTable dt2 = userBLL.getData_Chaxun(sql2, "").Tables[0];
            //        if (dt2.Rows.Count == 2) //人数满了 就回去 下一位
            //        {
            //            continue;
            //        }
            //        else if (dt2.Rows.Count == 0)
            //        {
            //            return Userid + "-" + 1;
            //        }
            //        else if (dt2.Rows.Count == 1)
            //        {
            //            return Userid + "-" + 2;
            //        }
            //    }
            //}
            //return "";
        }
    }
}