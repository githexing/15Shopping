<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberTree.aspx.cs" Inherits="web.user.team.MemberTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系谱图</title>
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <script src="../../JS/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.draggable.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <!--左侧菜单 star-->
        <div class="left">
            <div class="menu_t">系谱图</div>
            <div class="menu_x">
                <ul>
                    <li><a href="RecommendTree.aspx" target="fMain">推荐网络</a></li>
                    <li><a href="MemberTree.aspx" target="fMain" class="cur2">系谱图</a></li>
                    <li><a href="../../Registers.aspx" target="fMain">会员注册</a></li>
                    <li><a href="../member/PersonalInfo.aspx" target="fMain">会员资料</a></li>
                    <li><a href="../member/ModifyPassWord.aspx" target="fMain">修改密码</a></li>
                    <li><a href="Agent.aspx" target="fMain">中心申请</a></li>
                </ul>
            </div>
        </div>
        <div class="right">
            <div class="title">
                <span>当前位置：<a href="../default.aspx" class="hui">首页</a> &gt; 会员管理</span><h2>系谱图</h2>
            </div>
            <div class="right_nr">
                <div class="box">
                    <div class="operation">
                        <fieldset class="fieldset">
                            <legend class="legSearch"><%=GetLanguage("Query")%></legend><%=GetLanguage("MembershipNumber")%>:<asp:TextBox ID="txtUserCode" tip="输入会员编号"
                                runat="server" class="input_select"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Button ID="btnSearch" runat="server" Text="跳 转" class="btn" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnMy" runat="server" Text="我的系谱图" class="btn" OnClick="btnMy_Click" />&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="上一级" class="btn" OnClick="Button1_Click" />&nbsp;&nbsp;
                            <asp:Button ID="Button2" runat="server" Text="下一级" class="btn" OnClick="Button2_Click" />&nbsp;&nbsp;
                            <br />
                        </fieldset>
                    </div>
                    <div class="operation">
                        <fieldset class="fieldset">
                            <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/000.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                <%=GetLanguage("NoOpen")%><!--未开通--></div>
                             <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/001.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                VIP</div>
                            <%--<div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/003.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                <%=GetLanguage("Silver")%><!--银卡会员--></div>
                            <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/006.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                <%=GetLanguage("Gold")%><!--金卡会员--></div>
                            <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/005.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                <%=GetLanguage("Drill")%><!--钻卡会员--></div>
                            <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/004.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                <%=GetLanguage("Partner")%><!--创业合伙人--></div>
                            <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/002.jpg');
                                text-align: center; line-height: 20px; font-weight: bold;">
                                <%=GetLanguage("Sixth")%><!--创业合伙人--></div>--%>
                        </fieldset>
                    </div>
                    <div class="dataTable" style="clear: both; text-align: center; overflow: auto; margin-left: auto;
                        margin-right: auto; float: inherit; width: 800px;">
                        <table style="width: 100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    </form>
</body>
</html>
