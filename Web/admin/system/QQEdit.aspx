<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QQEdit.aspx.cs" Inherits="Web.admin.system.QQEdit" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑客服QQ</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../../Js/jquery.provincesBank.js" type="text/javascript"></script>
    <script src="../../Js/provincesdata.js" type="text/javascript"></script>
    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="contentpanel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">设置</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">客服名称:</label>
                                <input id="txtName" type="text" runat="server" class="form-control" size="20" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">客服号码:</label>
                                <input id="txtQQNumber" type="text" runat="server" class="form-control" />
                            </div>
                            <%--<div class="form-group mt10">
                                <label class="control-label">类型:</label>
                                <div class="form-control nopadding noborder">
                                    <input id="chkGroup" type="checkbox" runat="server" />选中则是输入微信群号码，不选为微信号
                                </div>
                            </div>--%>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-ok" OnClick="btnSave_Click"> 设 置 </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

