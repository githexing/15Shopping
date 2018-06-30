<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dl_bonus.aspx.cs" Inherits="Web.admin.finance.dl_bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
    <div class="box box_width">
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        报单费累计
                    </th>
                  <%--  <th>
                        加盟分流累计
                    </th>--%>
                    <th>
                        应发累计
                    </th>
                </tr>
                <tr>
                    <td align="center">
                        <%=getBonus(0,7) %>
                    </td>
                   <%-- <td align="center">
                        <%=getBonus(0,8) %>
                    </td>--%>
                    <td align="center">
                        <%=getBonusYF(0,2) %>
                    </td>
                </tr>
            </table>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期"
                    runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        报单费
                    </th>
                  <%--  <th>
                        加盟分流
                    </th>--%>
                    <th>
                        应发
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
                           <%-- <td align="center">
                                <%#Eval("fl")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("yf")%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                    PostBackUrl='<%#Eval("SttleTime","dl_BonusDetail.aspx?SttleTime={0}") %>'>查看明细</asp:LinkButton>
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
