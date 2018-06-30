<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdBonus.aspx.cs" Inherits="Web.user.finance.AdBonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>广告分红</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="">
    <form id="Form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            当前位置：财务中心>><a href="javascript:void(0)">广告分红</a>
        </div>
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th colspan="10">
                        广告分红累计
                    </th>
                </tr>
                <tr>
                    <th>
                        广告分红总额
                    </th>
                    <th>
                        实发分红总额
                    </th>
                </tr>
                <tr>
                    <%--<td align="center">
                        <%=getBonus(getLoginID(),1) %>
                    </td>--%>
                    <%--<td align="center">
                        <%=getBonus(getLoginID(), 2)%>
                    </td>--%>
                </tr>
            </table>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td>
                            结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期" runat="server" onfocus="WdatePicker()"
                                class="input_select"></asp:TextBox>
                            至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        分红金额
                    </th>
                    <th>
                        实发金额
                    </th>
                    <th>
                        奖金生成时间
                    </th>
                    <th>
                        是否结算
                    </th>
                    <th>
                        奖金备注
                    </th>
                    <th>
                        结算时间
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("Amount")%><%--奖金金额 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("sf")%><%--实发奖金金额 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("AddTime")%><%--奖金生成时间 3--%>
                            </td>
                            <td align="center">
                                <%#Eval("IsSettled")%><%--是否结算(0-未结算，1-已结算) 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("Source")%><%--奖金备注 5--%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--结算日期 6--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt=""/>
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
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