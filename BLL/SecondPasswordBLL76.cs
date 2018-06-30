/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-2-6 10:09:35 
 * 文 件 名：		SecondPasswordBLL76.cs 
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
using System.Text;

namespace lgk.BLL
{
    public class SecondPasswordBLL76
    {
        public static int AdminId = 0;//管理员id，如果管理员登陆了会员前台页面，则记录管理员id
        lgk.DAL.SecondPws sps = new lgk.DAL.SecondPws();
        string[] usestr = { "SpecialAwardEdit,ShopingOver,ShareRe,ShareAccount,ShareRecording,ShareOperate,ShareList,ProductCountByMonth,ProductOrders,ShopingCarManage,OnlineProduct,EmoneyList,ChangeMoney,BonusChangeMoney,BonusTakeMoney,LookMoney,myMoney,PromotionList,FormCenter,MemberEdit,CompanyService,PublisManage,MemberEdit,PublisManage,LeaveMsg,LeaveMsg1,Message,ManageDetails,ValueView,ContactUsShow,MemberTreeView2,MemberTreeView,MemberNextList,ShopingReader,OnlineProduct,ProductOrders,ShopingCarManage,ProductHadPay,MemberPayList,MemberPayList1" };
        string[] adminstr = { "ShareManage,ShareOperate,ShareMyRecording,ShareMange2,ShareRecording,ShareRe,SharePrice2,SharePrice,ShareTime,ShareParameter,BonusSet,UserPwdEdit,CompanyService,Set,SystemBank,AdminList,backup,UserLog,ShareList,ProductCountByMonth,ProductOverallTable,ProductOrdersManage,ProductList,ValueAdd,LeaveMsg,PublisManage,ReBonus,ReceiveExpendsSeach,AddMoneyManage,ChangeMoney2,ChangeMoney,BonusTakeMoney,PrizeSearch,SystemMoney,PromotionList,DeclarationCenter,MemberTreeView2,MemberTreeView,BusinessStatistics,OpenMember_Admin,OpenMember_Admin1,DeclarationCenterOpen,ShopingReader,ProductList,ProductOrdersManage,ProductOrdersDetails,PublisManage,LeaveMsg,LeaveMsg1,Message,ManageDetails,ContactUs,ValueAdd,Set,UserManage,ChongFuXF,RechargeSet" };
        
        /// <summary>
        /// 验证是否要跳转，是则跳转到代理商密码输入页面
        /// </summary>
        /// <param name="p"></param>
        public void jumpUrl(System.Web.UI.Page p, int type)
        {
            if (AdminId > 0)
            {
                return;//如果是管理员登陆会员前台页面，则不验证权限
            }
            //如果是从二级密码输入页面跳转过来的则不做处理
            try
            {
                string str2 = p.Request.Path;
                str2 = str2.Substring(str2.LastIndexOf("/") + 1);
                str2 = str2.Substring(0, str2.IndexOf('.'));
                if (p.Request.Path.Contains("/user/"))
                {
                    foreach (string tempstr in usestr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["purl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                if (p.Request.Path.Contains("/admin/"))
                {
                    foreach (string tempstr in adminstr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["purl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                //如果是登录过二次密码的就不用再输入
                if (System.Web.HttpContext.Current.Session["purl"].ToString() == str2)
                {
                    return;
                }
            }
            catch
            { }
            //读设置，是否要跳转二级密码页面
            //
            if (!sps.sfpws(type))
            {
                return;
            }
            string _purl = p.Request.Url.ToString();
            string strNewUrl = _purl.ToString().Replace("/user/finance/", "/user/").Replace("/user/info/", "/user/").Replace("/user/business/", "/user/").Replace("/user/member/", "/user/").Replace("/user/team/", "/user/").Replace("/user/Cash/", "/user/").Replace("/user/Stock/", "/user/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);
            p.Response.Redirect(strNewUrl + "SecondPassword.aspx?purl=" + _purl);
        }

        public void jumpUrl1(System.Web.UI.Page p, int type)
        {
            if (AdminId > 0)
            {
                return;//如果是管理员登陆会员前台页面，则不验证权限
            }
            //如果是从二级密码输入页面跳转过来的则不做处理
            try
            {
                string str2 = p.Request.Path;
                str2 = str2.Substring(str2.LastIndexOf("/") + 1);
                str2 = str2.Substring(0, str2.IndexOf('.'));
                if (p.Request.Path.Contains("/user/"))
                {
                    foreach (string tempstr in usestr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["tpurl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                if (p.Request.Path.Contains("/admin/"))
                {
                    foreach (string tempstr in adminstr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["tpurl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                //如果是登录过二次密码的就不用再输入
                if (System.Web.HttpContext.Current.Session["tpurl"].ToString() == str2)
                {
                    return;
                }
            }
            catch
            { }
            //读设置，是否要跳转二级密码页面
            //
            if (!sps.sfpws(type))
            {
                return;
            }
            string _purl = p.Request.Url.ToString();
            string strNewUrl = _purl.ToString().Replace("/user/finance/", "/user/").Replace("/user/info/", "/user/").Replace("/user/business/", "/user/").Replace("/user/member/", "/user/").Replace("/user/Stock/", "/user/").Replace("/user/Cash/", "/user/").Replace("/user/team/", "/user/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);
            p.Response.Redirect(strNewUrl + "tpwd.aspx?tpurl=" + _purl);
        }

        /// <summary>
        /// 验证是否要跳转，是则跳转到管理员密码输入页面
        /// </summary>
        /// <param name="p"></param>
        public void jumpAdminUrl(System.Web.UI.Page p, int type)
        {
            //如果是从二级密码输入页面跳转过来的则不做处理
            try
            {
                string str2 = p.Request.Path;
                str2 = str2.Substring(str2.LastIndexOf("/") + 1);
                str2 = str2.Substring(0, str2.IndexOf('.'));
                if (p.Request.Path.Contains("/user/"))
                {
                    foreach (string tempstr in usestr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["purl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                if (p.Request.Path.Contains("/admin/"))
                {
                    foreach (string tempstr in adminstr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["purl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                //如果是登录过二次密码的就不用再输入
                if (System.Web.HttpContext.Current.Session["purl"].ToString() == str2)
                {
                    return;
                }
            }
            catch
            { }
            //读设置，是否要跳转二级密码页面
            //
            if (!sps.sfpws(type))
            {
                return;
            }

            string _purl = p.Request.Url.ToString();
            string strNewUrl = p.Request.Url.ToString().Replace("/admin/finance/", "/admin/").Replace("/admin/business/", "/admin/").Replace("/admin/info/", "/admin/").Replace("/admin/Cash/", "/admin/").Replace("/admin/system/", "/admin/").Replace("/admin/team/", "/admin/").Replace("/admin/tb_link/", "/admin/").Replace("/admin/Stock/", "/admin/").Replace("/admin/cash/", "/admin/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径

            p.Response.Redirect(strNewUrl + "SecondPassword.aspx?purl=" + _purl);
        }

        public void jumpAdminUrl1(System.Web.UI.Page p, int type)
        {
            //如果是从二级密码输入页面跳转过来的则不做处理
            try
            {
                string str2 = p.Request.Path;
                str2 = str2.Substring(str2.LastIndexOf("/") + 1);
                str2 = str2.Substring(0, str2.IndexOf('.'));
                if (p.Request.Path.Contains("/user/"))
                {
                    foreach (string tempstr in usestr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["tpurl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                if (p.Request.Path.Contains("/admin/"))
                {
                    foreach (string tempstr in adminstr)
                    {
                        if (tempstr.Contains(System.Web.HttpContext.Current.Session["tpurl"].ToString()))
                        {
                            if (tempstr.Contains(str2))
                            {
                                return;
                            }
                        }
                    }
                }
                //如果是登录过二次密码的就不用再输入
                if (System.Web.HttpContext.Current.Session["tpurl"].ToString() == str2)
                {
                    return;
                }
            }
            catch
            { }
            //读设置，是否要跳转二级密码页面
            //
            if (!sps.sfpws(type))
            {
                return;
            }

            string _purl = p.Request.Url.ToString();
            string strNewUrl = p.Request.Url.ToString().Replace("/admin/finance/", "/admin/").Replace("/admin/licai/", "/admin/").Replace("/admin/business/", "/admin/").Replace("/admin/info/", "/admin/").Replace("/admin/system/", "/admin/").Replace("/admin/team/", "/admin/").Replace("/admin/Stock/", "/admin/").Replace("/admin/cash/", "/admin/");//取得当前的外网
            strNewUrl = strNewUrl.Substring(0, strNewUrl.LastIndexOf("/") + 1);//当前页面的根路径

            p.Response.Redirect(strNewUrl + "tpwd.aspx?tpurl=" + _purl);
        }

        /// <summary>
        /// 验证密码是否正确，正确则跳转会原页面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="psw"></param>
        /// <param name="type"></param>
        public void rejumpUrl(System.Web.UI.Page p, string psw, int type)
        {
            //验证密码是否正确
            int re = sps.findpws(psw, type);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["purl"] != "" && p.Request.QueryString["purl"] != null)
            {
                str = p.Request.QueryString["purl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["purl"] = str2;
            p.Response.Redirect(str);

        }

        /// <summary>
        /// 验证密码管理员三级密码是否正确，正确则跳转会原页面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="psw"></param>
        /// <param name="type"></param>
        public void rejumpUrl_admin(System.Web.UI.Page p, string psw, int aid)
        {
            //验证密码是否正确
            int re = sps.findpws_admin1(psw, aid);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["tpurl"] != "" && p.Request.QueryString["tpurl"] != null)
            {
                str = p.Request.QueryString["tpurl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;//p.Request.Path;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["tpurl"] = str2;
            p.Response.Redirect(str);
        }
        /// <summary>
        /// 验证管理员高级密码是否正确，正确则跳转会原页面 09.11.15
        /// </summary>
        /// <param name="p"></param>
        /// <param name="psw"></param>
        /// <param name="type"></param>
        public void rejumpUrl_byAdmin06(System.Web.UI.Page p, string admin06, int admin01)
        {
            //验证密码是否正确
            int re = sps.findpws_admin(admin06, admin01);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["purl"] != "" && p.Request.QueryString["purl"] != null)
            {
                str = p.Request.QueryString["purl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["purl"] = str2;
            p.Response.Redirect(str);

        }

        /// <summary>
        /// 验证管理员二级密码
        /// </summary>
        /// <param name="p"></param>
        /// <param name="admin06"></param>
        /// <param name="admin01"></param>
        public void rejumpUrl_byAdmin06(System.Web.UI.Page p, string admin06, string admin01)
        {
            //验证密码是否正确
            int re = sps.findpws_admin(admin06, admin01);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["purl"] != "" && p.Request.QueryString["purl"] != null)
            {
                str = p.Request.QueryString["purl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["purl"] = str2;
            p.Response.Redirect(str);

        }

        /// <summary>
        /// 验证密码管理员三级密码是否正确，正确则跳转会原页面
        /// </summary>
        /// <param name="p"></param>
        /// <param name="psw"></param>
        /// <param name="type"></param>
        public void rejumpUrl(System.Web.UI.Page p, string psw, string aid)
        {
            //验证密码是否正确
            int re = sps.findpws1(psw, aid);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["tpurl"] != "" && p.Request.QueryString["tpurl"] != null)
            {
                str = p.Request.QueryString["tpurl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["tpurl"] = str2;
            p.Response.Redirect(str);
        }

        /// <summary>
        /// 查询二级代理商密码
        /// </summary>
        /// <param name="p"></param>
        /// <param name="psw"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        public void rejumpUrl(System.Web.UI.Page p, string strPwd, int type, long iUserID)
        {
            //验证密码是否正确
            int re = sps.findpws(strPwd, type, iUserID);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["purl"] != "" && p.Request.QueryString["purl"] != null)
            {
                str = p.Request.QueryString["purl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["purl"] = str2;
            p.Response.Redirect(str);

        }

        /// <summary>
        /// 查询代理商三级密码
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public void rejumpUrl1(System.Web.UI.Page p, string strPwd, int type, long iUserID)
        {
            //验证密码是否正确
            int re = sps.findpwsCount(strPwd, type, iUserID);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["tpurl"] != "" && p.Request.QueryString["tpurl"] != null)
            {
                str = p.Request.QueryString["tpurl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["tpurl"] = str2;
            p.Response.Redirect(str);

        }

        public void rejumpUrl(System.Web.UI.Page p, string psw, int type, string ubh)
        {
            //验证密码是否正确
            int re = sps.findpws(psw, type, ubh);
            if (re == 0)
            {
                return;// "密码不正确!";
            }
            string str = "";
            if (p.Request.QueryString["purl"] != "" && p.Request.QueryString["purl"] != null)
            {
                str = p.Request.QueryString["purl"].ToString();
            }
            else
            {
                //p.Response.Redirect();
                //跳转到错误链接页面
                //return;
            }

            //跳转回原来页面
            string str2 = str;
            str2 = str2.Substring(str2.LastIndexOf("/") + 1);
            str2 = str2.Substring(0, str2.IndexOf('.'));
            System.Web.HttpContext.Current.Session["purl"] = str2;
            p.Response.Redirect(str);

        }

        /// <summary>
        /// 验证二级密码是否正确
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool sfpws(string admin06, int admin01)
        {
            int re = sps.findpws(admin06, admin01);
            if (re > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更改二级密码
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool uppws(string pws, int type)
        {
            return sps.uppws(pws, type);
        }

        /// <summary>
        /// 判断二级密码是否开启
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool sfopenpws(int type)
        {
            return sps.sfpws(type);
        }

        /// <summary>
        /// 开启关闭二级密码
        /// </summary>
        /// <param name="c"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool openclosepws(int c, int type)
        {
            return sps.openclosepws(c, type);
        }

        public void jumpUrl(System.Web.UI.Page p, int type, string users02)
        {
            //如果是从三级密码输入页面跳转过来的则不做处理
            try
            {
                string str2 = p.Request.Path;
                str2 = str2.Substring(str2.LastIndexOf("/") + 1);
                str2 = str2.Substring(0, str2.IndexOf('.'));
                if (System.Web.HttpContext.Current.Session["tpurl"].ToString() == str2)
                {
                    return;
                }
            }
            catch
            { }
            //读设置，是否要跳转三级密码页面
            //
            if (!sps.sfpws(type))
            {
                return;
            }
            string str = p.Request.Url.ToString();
            p.Response.Redirect("SecondP1.aspx?purl=" + str + "&users02=" + users02);
        }

        /// <summary>
        /// 查询三级密码 用的userid
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int findpwsCount(string strPassword, int iType, long iUserID)
        {
            int re = sps.findpwsCount(strPassword, iType, iUserID);
            return re;
        }

        /// <summary>
        /// 查询二级密码 用的userid
        /// 
        /// </summary>
        /// <param name="pws"></param>
        /// <param name="type"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int findSecondpws(string SecondPassword, int type, long UserID)
        {
            return sps.findpws(SecondPassword, type, UserID);
        }
    }
}
