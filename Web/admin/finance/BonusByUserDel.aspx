<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusByUserDel.aspx.cs"
    Inherits="Web.admin.finance.BonusByUserDel" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>奖金查询</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

    <style type="text/css">
     .th
     {
         text-align:left;
         padding-left:10px;
         }
    </style>
</head>
<body class="subBody">
    <form id="Form1" class="box_con" runat="server">
    <div class="box box_width">
        <div class="dataTable">

         <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search" style="padding-left:20px;"
                    PostBackUrl="Bonus.aspx">返 回 </asp:LinkButton>


            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1" style="display: none">
                <tr>
                    <th class="th">
                        直接招商津贴累计
                    </th>
                    <th class="th">
                        区域津贴累计
                    </th>
                    <th class="th">
                        管理津贴累计
                    </th>
                    <th class="th">
                        幸运津贴累计
                    </th>
                    <%--
                    <th>
                        学习津贴累计
                    </th>--%>
                    <%-- <th>
                        和谐津贴累计
                    </th>--%>
                    <th>
                        应发累计
                    </th>
                    <th>
                        综合服务费累计
                    </th>
                    <%--
                    <th>
                        返本费累计
                    </th>--%>
                    <th>
                        责任消费累计
                    </th>
                    <th>
                        市场权益累计
                    </th>
                    <th>
                        实发累计
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <%=getBonus(0,2) %><%--直接招商津贴累计 2--%>
                    </td>
                    <td align="center">
                        <%=getBonus(0,1) %>
                        <%--区域津贴累计 1--%>
                    </td>
                    <td align="center">
                        <%--管理津贴累计 4--%>
                        <%=getBonus(0,4) %>
                    </td>
                    <td align="center">
                        <%=getBonus(0,3) %>
                        <%--幸运津贴累计 3--%>
                    </td>
                    <%--
                    <td align="center">
                        <%=getBonus(0,5) %>
                    </td>--%>
                    <%--   <td align="center">
                        <%=getBonus(0,6) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusYF(0,1) %><%--应发累计 Amount--%>
                    </td>
                    <td align="center">
                        <%=getBonusFWF(0) %><%--综合服务费累计 Revenue--%>
                    </td>
                    <%--
                    <td align="center">
                        <%=getBonusFBF(0) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusCFXF(0) %><%--责任消费累计 Bonus006--%>
                    </td>
                    <td align="center">
                        <%=getBonus(0,7) %><%--市场权益累计 7--%>
                    </td>
                    <td align="center">
                        <%=getBonusSF(0) %><%--实发累计 sf--%>
                    </td>
                </tr>
            </table>
        </div>
    <div class="operation">
        <fieldset class="fieldset" style="display: none">
            <legend class="legSearch">查询</legend>结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期"
                runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
            至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <asp:Repeater ID="Repeater1" runat="server" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <th colspan="3">
                            <div style=" float:left;">用户：<%#Eval("yhm")%></div> <div style=" float:right;">日期：<%#Eval("SttleTime")%></div>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            直接招商津贴
                        </td>
                        <td align="center">
                            <%#Eval("tj")%>
                            <%--直接招商津贴 Amount 2--%>
                        </td>
                        <td>
                         <%#double.Parse(Eval("tj").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="linkBtnDel" runat="server" Visible=' <%#double.Parse(Eval("tj").ToString()) > 0 ? true : false%>' CommandArgument="2" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            区域津贴
                        </td>
                        <td align="center">
                            <%#Eval("dp")%><%--区域津贴 Amount 1--%>
                        </td>
                        <td>
                            <%#double.Parse(Eval("dp").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton1" Visible='<%#double.Parse(Eval("dp").ToString()) > 0 ? true : false%>' runat="server" CommandArgument="1" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            管理津贴
                        </td>
                        <td align="center">
                            <%#Eval("gl")%><%--管理津贴  Amount 4--%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("gl").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton3" runat="server" Visible='<%#double.Parse(Eval("gl").ToString()) > 0 ? true : false%>' CommandArgument="4" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            幸运津贴
                        </td>
                        <td align="center">
                            <%#Eval("jd")%><%--幸运津贴 Amount 3--%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("jd").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton4" Visible='<%#double.Parse(Eval("jd").ToString()) > 0 ? true : false%>' runat="server" CommandArgument="3" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            综合服务费
                        </td>
                        <td align="center">
                            <%#Eval("fwf")%><%--综合服务费 Revenue--%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("fwf").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton6" runat="server" Visible='<%#double.Parse(Eval("fwf").ToString()) > 0 ? true : false%>' CommandArgument="Revenue" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            责任消费
                        </td>
                        <td align="center">
                            <%#Eval("cfxf")%><%--责任消费 Bonus006--%>
                        </td>
                        <td>
                             <%#double.Parse(Eval("cfxf").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton7" runat="server" Visible=' <%#double.Parse(Eval("cfxf").ToString()) > 0 ? true:false%>' CommandArgument="Bonus006" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            市场权益
                        </td>
                        <td align="center">
                            <%#Eval("bd")%><%--市场权益 7 --%>
                        </td>
                        <td>
                        <%#double.Parse(Eval("bd").ToString()) > 0 ? "" : "-"%>
                            <asp:LinkButton ID="LinkButton8" runat="server" Visible='<%#double.Parse(Eval("bd").ToString())>0?true:false %>' CommandArgument="7" CommandName="delete" OnClientClick="return confirm('您确定删除该奖项吗？');">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="trBonusNull" runat="server">
                <td colspan="3" align="center">
                    <div class="NoData">
                        <span class="cBlack">
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                            抱歉！目前数据库暂无数据显示。</span></div>
                </td>
            </tr>
        </table>
        <div class="nextpage cBlack">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
