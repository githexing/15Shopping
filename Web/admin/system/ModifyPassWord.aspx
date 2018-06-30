<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassWord.aspx.cs"
    Inherits="Web.admin.system.ModifyPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div  class="form-horizontal form-bordered">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title"></h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">旧登录密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="textPassWord" class="form-control" runat="server" type="password" tip="输入登录密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">新登录密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="textNewPassWord" class="form-control" runat="server" type="password" tip="输入新登录密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">确认登录密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="textRPNewPassWord" class="form-control" runat="server" type="password" tip="输入确认登录密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label"></label>
                            <div class="col-sm-6">
                                <asp:LinkButton ID="btn_s1" runat="server" class="btn btn-primary mt10" iconcls="icon-save"
                                    OnClick="btnPassWord_Click"><i class="fa fa-check"></i> 保 存 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div   class="form-horizontal form-bordered">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title"></h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">旧二级密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="textSecondPass" class="form-control" runat="server" type="password" tip="输入二级密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">新二级密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="textNewSecondPass" class="form-control" runat="server" type="password" tip="输入新二级密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">确认二级密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="textRPSecondPass" class="form-control" runat="server" type="password" tip="确认二级密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label"></label>
                            <div class="col-sm-6">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary mt10" iconcls="icon-save"
                                    OnClick="btnSecondPass_Click"><i class="fa fa-check"></i> 保 存 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div  class="form-horizontal form-bordered">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4 class="panel-title"></h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">旧三级密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="Password1" class="form-control" runat="server" type="password" tip="输入三级密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">新三级密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="Password2" class="form-control" runat="server" type="password" tip="输入新三级密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">确认三级密码：</label>
                            <div class="col-sm-6">
                                <input name="Add_sscFd7" id="Password3" class="form-control" runat="server" type="password" tip="确认三级密码(必输入项)" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label"></label>
                            <div class="col-sm-6">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mt10" iconcls="icon-save" OnClick="Button1_Click"><i class="fa fa-check"></i> 保 存 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
