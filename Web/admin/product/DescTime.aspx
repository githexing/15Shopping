<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DescTime.aspx.cs" Inherits="Web.admin.product.DescTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <style type="text/css">
    .txtBox{ width:70px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="operation">
        <fieldset class="fieldset">
        <legend class="legSearch">倒计时</legend>
            <asp:TextBox ID="txtNian" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp;年&nbsp;&nbsp;
            <asp:TextBox ID="txtYue" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp;月&nbsp;&nbsp;
            <asp:TextBox ID="txtDay" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp;日&nbsp;&nbsp;
            <asp:TextBox ID="txtHour" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp;时&nbsp;&nbsp;
            <asp:TextBox ID="txtMinute" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp;分&nbsp;&nbsp;
            <asp:TextBox ID="txtSecond" runat="server" CssClass="txtBox"></asp:TextBox>&nbsp;秒<br /><br />
            <asp:LinkButton ID="btn_btnAdd" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                OnClick="btnAdd_Click"> 提 交 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-back"
                OnClick="btnSearch_Click"> 返 回 </asp:LinkButton>
        </fieldset>
        </div>
    </form>
</body>
</html>
