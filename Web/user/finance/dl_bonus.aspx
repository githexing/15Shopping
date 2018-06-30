<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dl_bonus.aspx.cs" Inherits="Web.user.finance.dl_bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            当前位置：代理商管理>><a href="javascript:void(0)">代理奖金</a>
            <asp:Button ID="Button1" runat="server" Text="账户查询" class="btn" PostBackUrl="dl_JournalAccount.aspx" />
           
            <asp:Button ID="Button3" runat="server" Text="我要充值" class="btn" PostBackUrl="Remit.aspx" />
            <asp:Button ID="Button4" runat="server" Text="账户转账" class="btn" PostBackUrl="TransferToEmoney.aspx" />
        </div>
        <fieldset class="fieldset">
            累计报单奖金：<span style=" color:Red;"><%=getBonus(getLoginID(), 4)%></span>
        </fieldset>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期"
                    runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        报单费
                    </th>
                    <th>
                        结算日期
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("bd")%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#Eval("SttleTime","dl_BonusDetail.aspx?SttleTime={0}") %>'>查看明细</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
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
