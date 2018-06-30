<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xdw.aspx.cs" Inherits="Web.user.finance.xdw" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员提现</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Financial")%>>><a href="javascript:void(0)">新点位管理</a>
        </div>
        <div class="operation">
            <br />
            <fieldset class="fieldset">
                <legend class="legSearch">新点位管理</legend>&nbsp;&nbsp;&nbsp;&nbsp;
              总重购币： <asp:Label ID="Label1" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;剩余重购币：<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
               &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button
                        ID="btnSubmit" runat="server" Style="margin: 0px; DISPLAY: none;" Text="添加新点位" class="btn" OnClick="btnSubmit_Click" /><span
                            style="color: #aa0000;">
            </fieldset>&nbsp;
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                       新编号
                    </th>
                    <th align="center">
                     添加时间
                    </th>
                    <th align="center">
                      是否停止
                    </th>
                    <th align="center">
                      停止时间
                    </th>
                </tr>
                <asp:Repeater ID="rpTake" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserMaleCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("AddDate")%>
                            </td>
                            <td align="center">
                                <%#Eval("IsOut").ToString() == "0" ?"否":"是" %>
                            </td>
                            <td align="center">
                                <%#Eval("OutDate")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" 
                    AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10"
                    ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
