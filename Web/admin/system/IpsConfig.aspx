<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IpsConfig.aspx.cs" Inherits="Web.admin.system.IpsConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>环讯设置</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">环讯配置</legend>
                <table width="99%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" align="left" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="0" Selected="True">测试环境</asp:ListItem>
                                <asp:ListItem Value="1">正式环境</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td>商户账号：<asp:TextBox ID="txtAccount" runat="server" Width="250"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>商户证书：<asp:TextBox ID="txtCertificate" runat="server" Width="250"></asp:TextBox></td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
