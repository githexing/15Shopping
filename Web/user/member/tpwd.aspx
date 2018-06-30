<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tpwd.aspx.cs" Inherits="Web.user.tpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>三级密码</title>
    <link href="../../css/indexcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<div class="box">
<div class="capositon"><%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("index")%>>><a href="javascript:void(0)"><%=GetLanguage("ThreePassword")%></a>
<!--三级密码--></div>
        <div class="operation">
                        <div align="center"><%=GetLanguage("PleaseThreePassword")%><!--请输入三级密码-->：<asp:TextBox ID="txtsecondPassword" runat="server"  class="input_select" TextMode="Password"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Button ID="btnOK" runat="server" Text="确定"  class="btn" 
                    onclick="btnOK_Click"/></div>
        </div>
        </div>
    </form>
</body>
</html>

