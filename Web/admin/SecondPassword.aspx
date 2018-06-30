<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPassword.aspx.cs"
    Inherits="Web.admin.SecondPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>二级密码</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />


    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
</head>
<body style="background-color:#E8E8FF">
    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">二级密码</h4>
            </div>
            <div class="panel-body">
                <form class="form-inline" action="#">
                    <div class="form-group">
                        <label class="control-label">请输入二级密码:</label>
                        <asp:TextBox ID="txtsecondPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:LinkButton ID="btn_s" runat="server" class="btn btn-primary mr5"
                        OnClick="btn_s_Click"><i class="fa fa-search"></i> 确 定 </asp:LinkButton>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
