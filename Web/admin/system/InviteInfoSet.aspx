<%@ Page Language="C#" ValidateRequest="false"  AutoEventWireup="true" CodeBehind="InviteInfoSet.aspx.cs" Inherits="Web.admin.system.InviteInfoSet" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>邀请信息设置</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />


    <script type="text/javascript" src="../../JS/jquery-1.11.3.min.js"></script>

    <script type="text/javascript" src="../../js/superValidator.js"></script>
     <script src="../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">信息设置</h4>
            </div>
            <div class="panel-body">
                 
                    <div class="form-bordered">
                        <div class="form-group mt10">
                            <label class="control-label">邀请信息:</label>
                            <br />
                            {昵称}{邀请码}{APP下载链接}{推广链接}
                            <asp:TextBox TextMode="MultiLine" ID="txtInviteInfo" runat="server" class="form-control" MaxLength="300"></asp:TextBox>
                            <br />
                            例如：我是{昵称}，邀请您加入释放币，邀请码：{邀请码}，赶快加入噢～{APP下载链接}
                            <br />
                            效果：我是xx，邀请您加入释放币，邀请码：YYYY，赶快加入噢～http://www.yuntunetwork.com
                        </div>
                        <div class="form-group mt10">
                            <label class="control-label">规则:</label>
                            <textarea runat="server" id="txtInviteRule" class="form-control" rows="5" cols="40"></textarea>
                            <script>
                                CKEDITOR.replace('txtInviteRule');
                            </script>
                        </div>
                        <div class="form-group mt10">
                            <label class="control-label">介绍:</label>
                            <asp:TextBox TextMode="MultiLine" ID="txtIntro" runat="server" class="form-control" MaxLength="300"></asp:TextBox>
                        </div>
                        <%--<div class="form-group mt10">
                            <label class="control-label">APP下载链接:</label>
                            <asp:TextBox ID="txtAppdownurl" runat="server" class="form-control" MaxLength="300"></asp:TextBox>
                        </div>--%>
                        <div class="form-group mt10">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success mr5" OnClientClick="getdata()"
                                iconcls="icon-ok" OnClick="btnSave_Click"><i class="fa fa-check"></i>保存 </asp:LinkButton>
                        </div>
                    </div>
                
            </div>
        </div>
        <script>
            function getdata() {
                var data = CKEDITOR.instances.textPubContext.getData();
                $('#txtInviteRule').val(data);
            }
            CKEDITOR.instances.textPubContext.setData($('#txtInviteRule').val());
        </script>
    </form>
</body>
</html>

