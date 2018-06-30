<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemitVoucher.aspx.cs" Inherits="Web.admin.finance.RemitVoucher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image runat="server" ID="remitimg" />
        </br>
        <asp:LinkButton ID="lbtnVerify" runat="server" class="btn btn-info" iconcls="icon-ok" CommandName="verify" OnClick="lbtnVerify_Click">返回</asp:LinkButton>
    </div>
    </form>
</body>
</html>
