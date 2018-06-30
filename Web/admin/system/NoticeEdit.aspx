<%@ Page Language="C#" ValidateRequest="false"  AutoEventWireup="true" CodeBehind="NoticeEdit.aspx.cs" Inherits="web.admin.system.NoticeEdit" %>

<%--<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
   <%-- <link rel="stylesheet" type="text/css" href="../style/select2.css" />--%>
<%--    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />--%>
    <link rel="stylesheet" type="text/css" href="../css/wysiwyg-color.css" />
    <script src="../../JS/jquery-1.11.3.min.js"></script>
    <%--<script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>--%>
   <%-- <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>--%>
    <%--<script src="../Scripts/main-layout.js" type="text/javascript"></script>--%>
    <script type="text/javascript"  src="../../JS/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <asp:Label ID="lbltitle" runat="server" Text=""></asp:Label></h4>
                </div>
                <div class="panel-body">
                    <div  class="form-bordered">
                        <div class="form-group mt15">
                            <label class="control-label">主题:</label>
                            <asp:TextBox ID="txtTitle" runat="server" tip="输入公告主题" class="form-control" style="width: 20%;" ></asp:TextBox>
                        </div>
                        <div class="form-group mt10">
                            <label class="control-label">选择下拉:</label>
                            <div class="form-control nopadding noborder">
                                <asp:DropDownList ID="dropNewType" runat="server" class="form-control" style="width: 10%;">
                                    <asp:ListItem Value="0">-请选择-</asp:ListItem>
                                    <asp:ListItem Value="1" Selected="True">系统公告</asp:ListItem>
                                 <%--   <asp:ListItem Value="2">关于释放币</asp:ListItem>
                                     <asp:ListItem Value="3">释放币帮助</asp:ListItem>--%>
                                    <%--<asp:ListItem Value="3">新闻中心</asp:ListItem>
                                    <asp:ListItem Value="4">疑问解答</asp:ListItem>
                                    <asp:ListItem Value="5">商城公告</asp:ListItem>
                                    <asp:ListItem Value="6">关于MDD易购</asp:ListItem>
                                    <asp:ListItem Value="7">新手指南</asp:ListItem>
                                    <asp:ListItem Value="8">配送安装</asp:ListItem>
                                    <asp:ListItem Value="9">售后服务</asp:ListItem>
                                    <asp:ListItem Value="10">购物保障</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label">内容:</label>
                           <%-- <CKEditor:CKEditorControl ID="textPubContext" runat="server" class="form-control"></CKEditor:CKEditorControl>style="height: 200px; width: 60%;" --%>
                           <%-- <asp:TextBox ID="textPubContext" runat="server" ></asp:TextBox>--%>
                            <textarea runat="server" id="textPubContext" class="form-control" rows="5" cols="40"></textarea>
                            <script>
                                CKEDITOR.replace('textPubContext');
                            </script>
                        </div>
                        <div class="form-group">
                            <label class="control-label">发布时间:</label>
                            <asp:TextBox ID="txtTime" tip="请输入发布时间" runat="server" style="width: 20%;" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" class="form-control datepicker"></asp:TextBox>
                        </div>
                        <div class="form-group" style="display:none;">
                            <label class="control-label">发布类型:</label>
                            <div class="form-control noborder nopadding mt10">
                                <label for="cn">
                                    <input type="radio" id="rdoZH" runat="server" name="rdo" />中文公告</label>
                                <label for="en">
                                    <input type="radio" id="rdoEn" runat="server" name="rdo" />英文公告</label>
                            </div>
                        </div>
                        <script>
                            function getdata() {
                                var data = CKEDITOR.instances.textPubContext.getData();
                                $('#textPubContext').val(data);
                            }
                            CKEDITOR.instances.textPubContext.setData($('#textPubContext').val());
                        </script>
                        <div class="form-group">
                            <asp:LinkButton ID="lbtnSubmit" runat="server" class="btn btn-success" iconcls="icon-ok"  OnClientClick="getdata()"
                                OnClick="lbtnSubmit_Click"><i class="fa fa-check"></i> 提 交 </asp:LinkButton>
                            <asp:LinkButton ID="lbtnBack" runat="server" class="btn btn-dark" iconcls="icon-back"
                                OnClick="lbtnBack_Click"><i class="fa fa-arrow-left"></i> 返回 </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
