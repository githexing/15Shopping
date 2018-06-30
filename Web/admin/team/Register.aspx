<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.admin.team.Register" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- BEGIN CONTAINER -->
        <div class="page-container row-fluid">
            <!-- BEGIN PAGE CONTAINER-->
            <div class="page-content">
                <div class="content">
                    <div class="page-title">
                        <h3>会员注册</h3>
                    </div>
                    <div id="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="grid simple">
                                    <div class="grid-title no-border">
                                        <h4>登录资料</h4>
                                    </div>
                                    <div class="grid-body no-border">
                                        <div class="form-horizontal col-md-12">
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>会员编号：</label>
                                                <div class="col-sm-5">
                                                    <%-- <input type="text" class="form-control">--%>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="form-control" />&nbsp;
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="col-sm-5">
                                                    <%--<input type="submit" value="生成编号" class="btn btn-info">
                                                    <input type="submit" value="检测编号" class="btn btn-success">--%>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" class="btn btn-info" />&nbsp;&nbsp;
                                                           <asp:Button ID="btnValidate" runat="server" OnClick="btnValidate_Click" class="btn btn-success" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span> 密码：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtPassword" type="password" id="txtPassword" runat="server" class="form-control"
                                                        value="1" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>确认密码：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtRegPassword" type="password" id="txtRegPassword" runat="server" class="form-control"
                                                        value="1" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>二级密码：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtSecondPassword" type="password" id="txtSecondPassword" runat="server" class="form-control"
                                                        value="1" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>确认密码：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtRegSecondPassword" type="password" id="txtRegSecondPassword" runat="server" class="form-control"
                                                        value="1" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>三级密码：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtThreePassword" type="password" id="txtThreePassword" runat="server" class="form-control"
                                                        value="1" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>确认密码：</label>
                                                <div class="col-sm-10">
                                                    <%--<input type="password" class="">--%>
                                                    <input name="txtRegThreePassword" type="password" id="txtRegThreePassword" runat="server" class="form-control"
                                                        value="1" />
                                                </div>
                                            </div>
                                             <div class="form-group" style="display:none">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>会员等级：</label>
                                                <div class="col-sm-10">
                                                     <asp:UpdatePanel ID="UpdatePane2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="dropLevel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropLevel_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                              <div class="form-group" style="display:none">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span> 注册金额:($)</label>
                                                <div class="col-sm-10">
                                                   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                         <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled" class="form-control" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="form-group" style="display:none">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span> 消费金:(¥)</label>
                                                <div class="col-sm-10">
                                                   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                         <input name="txfRegMoney" type="text" id="txfRegMoney" runat="server" disabled="disabled" class="form-control" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>推荐人：</label>
                                                <div class="col-sm-10">
                                                    <%--<input type="password" class="">--%>
                                                  <input name="txtRecommendCode" disabled="disabled" type="text" id="txtRecommendCode" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                              <div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">*</span>安置人：</label>
                                                <div class="col-sm-10">
                                                    <%--<input type="password" class="">--%>
                                                  <input name="txtParentCode" disabled="disabled" type="text" id="txtParentCode" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="grid-title no-border">
                                        <h4>银行资料</h4>
                                    </div>
                                    <div class="grid-body no-border">
                                        <div class="form-horizontal col-md-12">
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">开户银行：</label>
                                                <div class="col-sm-5">
                                                    <asp:DropDownList ID="dropBank" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-5">
                                                    <asp:DropDownList ID="dropProvince" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">银行支行：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">银行账户：</label>
                                                <div class="col-sm-10">
                                                    <%--<input type="text"  value="">--%>
                                                    <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="form-control" value="" maxlength="19" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">开户姓名：</label>
                                                <div class="col-sm-10">
                                                    <%--<input type="text" class="form-control" value="">--%>
                                                    <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="grid-title no-border">
                                        <h4>基本资料</h4>
                                    </div>
                                    <div class="grid-body no-border">
                                        <div class="form-horizontal col-md-12">
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">会员姓名：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">身份证号：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtIdenCode" type="text" id="txtIdenCode" maxlength="18" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">联系电话：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtPhoneNum" type="text" id="txtPhoneNum" maxlength="11" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">联系地址：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtAddress" type="text" id="txtAddress" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <%--<div class="form-group">
                                                <label class="col-sm-2 control-label"><span class="text-danger">&nbsp;</span> <%=GetLanguage("QQNumber")%>：</label>
                                                <div class="col-sm-10">
                                                    <input type="text" class="form-control" value="">-
                                                    <input name="txtQQnumer" type="text" id="txtQQnumer" runat="server" class="form-control" />
                                                </div>
                                            </div>--%>
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label">电子邮箱：</label>
                                                <div class="col-sm-10">
                                                    <input name="txtEmail" type="text" id="txtEmail" runat="server" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <%--<button type="submit" class="btn btn-primary"><i class="fa fa-check"></i>提交</button>--%>
                                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary " OnClick="btnSubmit_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                        </div>
                        </div>
                </div>
            </div>
           </div>
            <!-- ENG PAGE CONTAINER-->
        </div>
        <!-- END CONTAINER -->
    </form>
</body>
</html>
