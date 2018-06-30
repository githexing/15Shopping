<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chaifenDetails.aspx.cs"
    Inherits="Web.admin.licai.chaifenDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拆分明细</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="box box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>用户名：
                <input name="Add_sscFd7" id="txtUserCode" tip="输入用户名" class="input_select" runat="server"
                    type="text" />&nbsp;&nbsp;&nbsp; 拆分时间：<asp:TextBox ID="txtStar" tip="输入拆分时间" runat="server"
                        class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入拆分时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-back"
                    OnClick="LinkButton1_Click"> 返 回 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th width="11%">
                        用户名
                    </th>
                    <th width="11%">
                        拆分时间
                    </th>
                    <th width="11%">
                        拆分前股票数量
                    </th>
                    <th width="9%">
                        拆分获赠股票
                    </th>
                    <th width="11%">
                        拆分后股票数量
                    </th>
                    <th width="11%">
                        剩余天数
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitStockTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitQStock")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitSStock")%>
                            </td>
                            <td align="center">
                                <%#Eval("SplitHStock")%>
                            </td>
                            <td align="center">
                                <%#Eval("Split02")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="nextpage cBlack">
            <ul>
                <li style="float: right; width: 100%;">
                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager2_PageChanged">
                    </webdiyer:AspNetPager>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
