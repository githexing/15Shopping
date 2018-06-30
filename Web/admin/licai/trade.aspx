<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trade.aspx.cs" Inherits="Web.admin.licai.trade" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>交易量</title>
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
    <form id="form1" runat="server" class="box_con" >
<div class="box box_width">
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch"></legend>交易时间：<asp:TextBox ID="txtStar" tip="输入交易时间" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
            交易量：<input name="Add_sscFd7" id="txtNum"  runat="server" type="text" class="easyui-numberbox input_select" precision="2" tip="输入交易量" />&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-add" onclick="btnSearch_Click" > 提 交 </asp:LinkButton>
        </fieldset>
        </div>
        <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th >
                    交易时间
                </th>
                <th >
                    交易量
                </th>
                <th >
                    操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" 
                onitemcommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Convert.ToDateTime(Eval("BusinessTime")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td align="center">
                            <%#Eval("BusinessAmount")%>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-edit"  CommandName="edi" CommandArgument='<%#Eval("ID") %>'>编 辑</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-no"  CommandName="del" CommandArgument='<%#Eval("ID") %>'>删 除</asp:LinkButton>
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
                    SubmitButtonClass="pagebutton" UrlPaging="false" 
                    pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" 
                    textbeforepageindexbox="转到 " onpagechanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
