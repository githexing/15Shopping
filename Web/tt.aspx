<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tt.aspx.cs" Inherits="Web.tt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtip" runat="server"></asp:TextBox>
        <input  placeholder="text" onfocus="this.blur()" />
    <asp:Button ID="btnParse" runat="server" OnClick="btnParse_Click" Text="解析" />
    </div>
    </form>
</body>
</html>
