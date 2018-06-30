<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DayBonus.aspx.cs" Inherits="Web.user.finance.DayBonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>每日奖金</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="">
    <form id="Form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            当前位置：财务中心>><a href="javascript:void(0)">每日奖金</a>
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
                    <th colspan="10">
                        每日奖金明细
                    </th>
                </tr>
                <tr>
                    <th>
                        奖金类型编号
                    </th>
                    <th>
                        奖金金额
                    </th>
                    <th>
                        实发奖金金额
                    </th>
                    <th>
                        奖金生成时间
                    </th>
                    <th>
                        是否结算(0-未，1-已)
                    </th>
                    <th>
                        奖金备注
                    </th>
                    <th>
                        结算时间
                    </th>
                    <th>
                        奖金来源用户ID
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("TypeID")%><%--奖金类型编号 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%><%--奖金金额 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("sf")%><%--实发奖金金额 3--%>
                            </td>
                            <td align="center">
                                <%#Eval("AddTime")%><%--奖金生成时间 4--%>
                            </td>
                            <td align="center">
                                <%#Eval("IsSettled")%><%--是否结算(0-未结算，1-已结算) 5--%>
                            </td>
                            <td align="center">
                                <%#Eval("Source")%><%--奖金备注 6--%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--结算时间 3--%>
                            </td>
                            <td align="center">
                                <%#Eval("FromUserID")%><%--奖金来源用户id 4--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
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
