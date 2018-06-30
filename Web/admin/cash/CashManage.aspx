<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashManage.aspx.cs" Inherits="Web.admin.cash.CashManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>交易平台设置</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contentpanel">
            <div class="form-horizontal form-bordered">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title">交易平台设置</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">交易平台状态：</label>
                            <div class="col-sm-6">
                                <div class="radio">
                                    <label>
                                        <asp:RadioButton ID="rdoEnabled" runat="server" Text="启用" GroupName="state" Checked="True" /></label></div>
                                <div class="radio">
                                    <label>
                                        <asp:RadioButton ID="rdoClose" runat="server" GroupName="state" Text="关闭" /></label></div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">关闭提示信息：</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtMsgContent" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label"></label>
                            <div class="col-sm-6">
                                <asp:LinkButton ID="btnSave" runat="server" class="btn btn-success" iconcls="icon-ok"
                                    OnClick="btnSave_Click"><i class="fa fa-check"></i> 设 置 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
