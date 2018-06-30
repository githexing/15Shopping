<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="lgk.Web.tb_Link.Add"
    Title="增加页" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <style type="text/css">
        .tbs tr {
            border: 1px solid #A4BED4;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <form action="#" class="form-horizontal form-bordered">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title"></h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">图片预览：</label>
                            <div class="col-sm-6" id="preview">
                                <asp:Image ID="Image1" runat="server" class="img-profile" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">选择图片：</label>
                            <div class="col-sm-6">
                                <asp:FileUpload ID="FileUpload1" runat="server" class="files" />
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnupimg_Click" class="btn btn-primary">上传</asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">链接名称：</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtLinkName" runat="server" Width="200px" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">链接地址：</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtLinkUrl" runat="server" Width="200px" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">排序号：</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtSort" runat="server" Width="200px" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label"></label>
                            <div class="col-sm-6">
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnSave_Click" class="btn btn-primary">提交</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="javascript:history.go(-1);"
                                    class="btn btn-dark">返回</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </form>
</body>
</html>
