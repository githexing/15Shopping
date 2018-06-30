/*********************************************************************************
* Copyright(c)  	2012 RJ.COM
 * 创建日期：		2012-1-12 14:00:23 
 * 文 件 名：		UserView.cs 
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
using System.Data;
using System.Collections;
using lgk.Model;

namespace lgk.BLL
{
    public class UserView
    {
        public RowView use = new RowView();
        public readonly lgk.BLL.tb_user us = new lgk.BLL.tb_user();
        public readonly lgk.BLL.tb_flag flagBLL = new lgk.BLL.tb_flag();

     //   DataTable dt;
        DataTable ndt;
        private long _ViewID;
        private int _a;
        private int _b;
        private int _c;
        private int _isht;

        private string cnen = "zh-cn";//默认语言版本中文

        public UserView(long ViewID, int a, int b, int c, int isht,string lang)
        {
            this._ViewID = ViewID;
            this._a = a;
            this._b = b;
            this._c = c;
            this._isht = isht;

            cnen = lang;
        }

        /// <summary>
        ///  输出Table
        /// </summary>
        /// <param name="a">分支，输入2为二叉树</param>
        /// <param name="b">级数，输入2显示2级</param>
        /// <returns></returns>
        public string AddTable()
        {
            nodedt(this._ViewID, this._b);
            //dt = LevelBLL.GetListByCache("UserView");
            int a = this._a;
            int b = this._b;
            int cs = flagBLL.NodeNun(_ViewID);
            use.AddRange(us.GetModelList(string.Format(" Layer>{0} and Layer<{1}", (cs - 1), (cs + _b), this._c)));
            string Tabele = "";
            Tabele += top(a, b);
            ArrayList alist = new ArrayList();
            ArrayList blist = new ArrayList();
            alist.Add("0," + _ViewID);
            int type;
            for (int i = 0; i < b; i++)
            {
                int x = Convert.ToInt32(Math.Pow(a, i));
                int y = Convert.ToInt32(Math.Pow(a, b)) / (a * x);
                if (i == 0)
                {
                    type = 0;
                }
                else if (i == b - 1)
                {
                    type = 2;
                }
                else
                {
                    type = 1;
                }
                Tabele += addTr(type, x, y, a, alist, out blist);
                alist = blist;
            }
            Tabele += Ends();
            return Tabele;
        }

        /// <summary>
        /// 输出TR
        /// </summary>
        /// <param name="Wtype"></param>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="alist"></param>
        /// <param name="blist"></param>
        /// <returns></returns>
        private string addTr(int Wtype, int id, int x, int a, ArrayList alist, out ArrayList blist)
        {
            ArrayList clist = new ArrayList();
            List<lgk.Model.tb_user> li = new List<lgk.Model.tb_user>();
            for (int i = 0; i < id; i++)
            {
                string[] fx = alist[i].ToString().Split(',');
                lgk.Model.tb_user fd = us.GetModel(int.Parse(fx[1]));
                if (fd != null)
                {
                    fd.User005 = x.ToString();
                    li.Add(fd);
                    for (int j = 1; j < a + 1; j++)
                    {
                        int Myid;
                        if (use.Exist(int.Parse(fx[1]), j, out Myid))
                        {
                            clist.Add("0," + Myid.ToString());
                        }
                        else
                        {
                            if (fd.IsOpend >= 2)
                                clist.Add("0,-1," + fx[1] + "," + j);
                            else if (fd.IsOpend == 0 || fd.IsOpend == 1)
                                clist.Add("2,-1," + fx[1] + "," + j);
                        }
                    }
                }
                else
                {
                    if (fx[0] == "0")//父节点已开通
                    {
                        if (us.GetModel(" isopend>=2 and Location=1 and ParentID=" + int.Parse(fx[2])) == null)
                        {
                            if (int.Parse(fx[3]) == 2)
                            {
                                fd = new lgk.Model.tb_user();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                li.Add(fd);
                            }
                            else
                            {
                                //fd = new lgk.Model.tb_user();
                                //fd.User005 = x.ToString();
                                //fd.UserCode = "[注册]";
                                //fd.ParentID = int.Parse(fx[2]);
                                //fd.Location = int.Parse(fx[3]);
                                //li.Add(fd);
                                fd = new lgk.Model.tb_user();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                li.Add(fd);
                            }
                        }
                        else
                        {
                            //fd = new lgk.Model.tb_user();
                            //fd.User005 = x.ToString();
                            //fd.UserCode = "[注册]";
                            //fd.ParentID = int.Parse(fx[2]);
                            //fd.Location = int.Parse(fx[3]);
                            //li.Add(fd);
                            fd = new lgk.Model.tb_user();
                            fd.User005 = x.ToString();
                            fd.UserCode = "[空位]";
                            li.Add(fd);
                        }
                    }
                    else
                    {
                        if (fx[0] == "2")//父节点未开通
                        {
                            if (int.Parse(fx[3]) == 2)
                            {
                                fd = new lgk.Model.tb_user();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                li.Add(fd);
                            }
                            else
                            {
                                //fd = new lgk.Model.tb_user();
                                //fd.User005 = x.ToString();
                                //fd.UserCode = "[注册]";
                                //fd.ParentID = int.Parse(fx[2]);
                                //fd.Location = int.Parse(fx[3]);
                                //li.Add(fd);
                                fd = new lgk.Model.tb_user();
                                fd.User005 = x.ToString();
                                fd.UserCode = "[空位]";
                                li.Add(fd);
                            }
                        }
                        else
                        {
                            fd = new lgk.Model.tb_user();
                            fd.User005 = x.ToString();
                            fd.UserCode = "[空位]";
                            li.Add(fd);
                        }
                    }
                    for (int j = 0; j < a; j++)
                    {
                        clist.Add("1,-1");
                    }
                }
            }
            blist = clist;
            return Aid(li, Wtype, a);
        }

        /// <summary>
        /// 输出顶部
        /// </summary>
        /// <returns></returns>
        private string top(int a, int b)
        {
            int Wid = 0;
            switch (a)
            {
                case 2:
                    Wid = Convert.ToInt32(Math.Pow(a, b));//
                    break;
                case 3:
                    Wid = Convert.ToInt32(Math.Pow(a, b)) / 2;
                    break;
                case 4:
                    Wid = Convert.ToInt32(Math.Pow(a, b)) / 4;
                    break;
                default:
                    break;
            }
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("<table align=\"center\" id=\"treeTable\" style=\"width:" + Wid * 78 + "px\">");
            return sbContent.ToString();
        }

        /// <summary>
        /// 输出底部
        /// </summary>
        /// <returns></returns>
        private string Ends()
        {
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("</table>");
            return sbContent.ToString();
        }

        /// <summary>
        /// 输出会员节点
        /// </summary>
        /// <param name="sd">记录股东内容的实体</param>
        /// <returns></returns>
        private string TTable(lgk.Model.tb_user sd)
        {
            StringBuilder sbContent = new StringBuilder();
            List<string> nodeli = new List<string>();
            if (sd.UserCode == "[注册]")
            {
                sbContent.Append("<table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"map05\">");
                sbContent.Append("<tr>");
                sbContent.Append("<td width=\"102\" height=\"26\"   colspan=\"2\"  class=\"cBlack\">");
                if (cnen == "zh-cn")
                {
                    sbContent.Append("<a href=\"../../Registers.aspx?state=" + sd.ParentID + "," + sd.Location + "," + this._isht + "," + this._ViewID + "\">注册</a>");
                }
                else
                {
                    sbContent.Append("<a href=\"../../Registers.aspx?state=" + sd.ParentID + "," + sd.Location + "," + this._isht + "," + this._ViewID + "\">regist</a>");
                }
                //sbContent.Append("空位");
                sbContent.Append("</td></tr>");
                sbContent.Append("</table>");
            }
            else if (sd.UserCode == "[空位]")
            {
                if (cnen == "zh-cn")
                {
                    sbContent.Append("<table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"map06\"><tr><td width=\"102\" height=\"26\"   colspan=\"2\" class=\"cBlack\">空位</td></tr></table>");
                }
                else
                {
                    sbContent.Append("<table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"map06\"><tr><td width=\"102\" height=\"26\"   colspan=\"2\" class=\"cBlack\">empty</td></tr></table>");
                }
            }
            else
            {
                string map = "";
              //  string kaitong = "";
                if (sd.IsOpend == 0 || sd.IsOpend == 1)
                {
                   // kaitong = "<span style='color:red;'>[未开通]</span>";
                    map = "image0";
                }
                else
                {
                  //  kaitong = "[已开通]";
                    if (int.Parse(sd.LevelID.ToString()) == 1)
                    {
                        map = "image1";// 普卡会员
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 2)
                    {
                        map = "image3"; // 银卡会员 
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 3)
                    {
                        map = "image6";// 金卡会员
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 4)
                    {
                        map = "image5"; // 钻卡会员
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 5)
                    {
                        map = "image4";//  创业合伙人
                    }
                    if (int.Parse(sd.LevelID.ToString()) == 6)
                    {
                        map = "image2";//  创业合伙人
                    }
                }
                string jibie = new tb_level().GetModel(sd.LevelID).LevelName;

                if (cnen == "zh-cn")
                {
                    sbContent.Append(" <table height=\"100px\"  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"" + map + "\">" +
                        "<tr height=\"5px\"><td align=\"center\"  colspan=\"3\" class=\"th\"><b><a style=\" color:White;\" href=\"MemberTree.aspx?tt=" + sd.UserID + "\">" + sd.UserCode + "</a></b></td></tr>" +
                        "<tr  align=\"center\" height=\"5px\"><td align=\"center\"  colspan=\"3\" class=\"th\">" + sd.TrueName + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftScore).ToString() + "</td><td>总</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightScore).ToString() + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftBalance).ToString() + "</td><td>余</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightBalance).ToString() + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftNewScore).ToString() + "</td><td>新</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightNewScore).ToString() + "</td></tr>" +
                        "</table>");
                }
                else
                {
                    sbContent.Append(" <table height=\"100px\"  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"  class=\"" + map + "\">" +
                        "<tr height=\"5px\"><td align=\"center\"  colspan=\"3\" class=\"th\"><b><a style=\" color:White;\" href=\"MemberTree.aspx?tt=" + sd.UserID + "\">" + sd.UserCode + "</a></b></td></tr>" +
                        "<tr  align=\"center\" height=\"5px\"><td align=\"center\"  colspan=\"3\" class=\"th\">" + sd.TrueName + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftScore).ToString() + "</td><td>total</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightScore).ToString() + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftBalance).ToString() + "</td><td>balance</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightBalance).ToString() + "</td></tr>" +
                        "<tr height=\"5px\"><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.LeftNewScore).ToString() + "</td><td>new</td><td width=\"50\" align=\"center\" >" + Convert.ToDouble(sd.RightNewScore).ToString() + "</td></tr>" +
                        "</table>");
                }

            }
            return sbContent.ToString();
        }

        /// <summary>
        /// 输出一行内的所有TD
        /// </summary>
        /// <param name="fd"></param>
        /// <returns></returns>
        private string Aid(List<lgk.Model.tb_user> fd, int Wtype, int a)
        {
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append("<tr  align=\"center\" >");
            foreach (lgk.Model.tb_user ad in fd)
            {
                sbContent.Append("<td colspan=\"" + ad.User005 + "\" align=\"center\" >");
                sbContent.Append(TTable(ad));
                sbContent.Append("</td>");
            }

            sbContent.Append("</tr>");



            if (Wtype == 2)
            {
                return sbContent.ToString();
            }

            foreach (lgk.Model.tb_user ad in fd)
            {
                switch (a)
                {
                    case 1:

                        sbContent.Append("<td  align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\"><img alt=\"父节点\" width=\"10\" height=\"30\" src=\"../../images/t_tree_mind.gif\" /></td>");
                        break;
                    case 2:

                        sbContent.Append("<td  align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\"><img alt=\"height=30\" src=\"../../images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" width=\"10\" height=\"30\" src=\"../../images/t_tree_mid.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"../../images/t_tree_line.gif\" width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"../../images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    case 3:
                        sbContent.Append("<td  align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\"><img alt=\"height=30\" src=\"../../images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" height=\"30\" src=\"../../images/t_tree_mind.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"../../images/t_tree_line.gif\" width=\"" + (((78 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"../../images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    case 4:
                        sbContent.Append("<td align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\">");
                        sbContent.Append("<img alt=\"height=30\" src=\"../../images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((55 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"../../images/t_tree_bottom_l.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"../../images/t_tree_line.gif\" width=\"" + (((27 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" height=\"30\" src=\"../../images/t_tree_mid.gif\"");
                        sbContent.Append("width=\"10\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\" width=\"" + (((27 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\"");
                        sbContent.Append("src=\"../../images/t_tree_bottom_r.gif\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((55 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"../../images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    case 5:
                        sbContent.Append("<td align=\"center\" colspan=\"" + ad.User005 + "\" valign=\"top\">");
                        sbContent.Append("<img alt=\"height=30\" src=\"../../images/t_tree_bottom_l.gif\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"../../images/t_tree_bottom_l.gif\" /><img height=\"30\"");
                        sbContent.Append("src=\"../../images/t_tree_line.gif\" width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"父节点\" height=\"30\" src=\"../../images/t_tree_mind.gif\"");
                        sbContent.Append("width=\"10\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\" width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\"");
                        sbContent.Append("src=\"../../images/t_tree_bottom_r.gif\" /><img height=\"30\" src=\"../../images/t_tree_line.gif\"");
                        sbContent.Append("width=\"" + (((43 * int.Parse(ad.User005)) / 2) - 10) + "\" /><img alt=\"height=30\" src=\"../../images/t_tree_bottom_r.gif\" /></td>");
                        break;
                    default:
                        break;
                }

            }
            sbContent.Append("</tr>");
            return sbContent.ToString();
        }

        /// <summary>
        /// 获得显示出来的节点的总节点，新节点
        /// </summary>
        /// <returns></returns>
        private DataTable nodedt(long id, int b)
        {
            //lgk.DAL.UserView uv =new lgk.DAL.UserView();
            //ndt = uv.nodetb(id, b);
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ubh"></param>
        /// <returns></returns>
        private List<string> getgs(string ubh)
        {
            List<string> list = new List<string>();
            DataRow[] drs = ndt.Select("UserCode='" + ubh + "'");
            for (int n = 0; n <= 3; n++)
            {
                list.Add("0");
            }
            for (int i = 0; i <= drs.Length - 1; i++)
            {
                if (drs[i]["UsersNode03"].ToString() == "1")
                {
                    list[0] = drs[i]["UsersNode02"].ToString();
                    list[1] = drs[i]["UsersNode05"].ToString();
                }
                else
                {
                    list[2] = drs[i]["UsersNode02"].ToString();
                    list[3] = drs[i]["UsersNode05"].ToString();
                }
            }
            return list;
        }

    }
}