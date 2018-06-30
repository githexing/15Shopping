<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockBonus.aspx.cs" Inherits="Web.admin.Stock.StockBonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">查询</legend>
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="">
                <tr>
                    <td>
                        选择下拉：<asp:DropDownList ID="dropType" runat="server">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">会员编号</asp:ListItem>
                            <asp:ListItem Value="2">会员姓名</asp:ListItem>
                        </asp:DropDownList>
                        <input name="txtName" id="txtName" class="input_select" runat="server" type="text" />&nbsp;&nbsp;&nbsp;&nbsp;结算日期：<asp:TextBox
                            ID="txtStar" tip="输入开通日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                        至<asp:TextBox ID="txtEnd" tip="输入开通日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="btnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                            OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th align="center">
                    会员编号
                </th>
                <th align="center">
                    会员姓名
                </th>
                <th align="center">
                    本金
                </th>
                <th align="center">
                    当前持股数
                </th>
                <th align="center">
                    购买价格
                </th>
                <th align="center">
                    可提现余额
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:Literal ID="ltUserCode" runat="server"></asp:Literal>
                        </td>
                        <td align="center">
                            <asp:Literal ID="ltTrueName" runat="server"></asp:Literal>
                        </td>
                        <td align="center">
                            <%#Eval("Amount")%>
                        </td>
                        <td align="center">
                            <%#Eval("Number")%>
                        </td>
                        <td align="center">
                            <%#Eval("Price")%>
                        </td>
                        <td align="center">
                            <asp:Literal ID="ltProfit" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="tr1" runat="server">
                <td colspan="7" align="center">
                    <div class="NoData">
                        <span class="cBlack">
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                            抱歉！目前数据库暂无数据显示。</span></div>
                </td>
            </tr>
        </table>
        <div class="nextpage cBlack">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
