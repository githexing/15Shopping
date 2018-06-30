<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register1.aspx.cs" Inherits="Web.Register1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员注册</title>
     <link rel="stylesheet" type="text/css" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/css/core.css" />
    <link rel="stylesheet" type="text/css" href="/css/components.css" />
    <link rel="stylesheet" type="text/css" href="/css/icons.css" />
    <link rel="stylesheet" type="text/css" href="/css/pages.css" /> 
    <link rel="stylesheet" type="text/css" href="/css/menu.css" /> 
    <link rel="stylesheet" type="text/css" href="/css/responsive.css" />
    <link rel="stylesheet" type="text/css" href="/css/sweetalert2.min.css" /> 
    <link rel="stylesheet" type="text/css" href="/css/emergygame.css"/>
    <script src="/js/jquery.min.js"></script>
      <script src="/js/sweetalert2.min.js"></script>
       
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" id="ScriptManager1"></asp:ScriptManager>
    <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--登录资料--%>登录资料</h4>
                            <div class="row form-horizontal">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>手机号码：</label>
                                      <div class="col-sm-10 m-b-5">
                                            <input type="text" id="txtUserCode" runat="server" class="form-control" maxlength="11"/>
                                        </div>
                                        <div class="col-sm-5 m-b-5" style="display:none"  >
                                            <asp:Button ID="btnCreateUser" CssClass="btn btn-info" runat="server" Text="生成编号" OnClick="btnCreateUser_Click" />
                                            <asp:Button ID="btnValidate" CssClass="btn btn-success" runat="server" Text="检测账号" OnClick="btnValidate_Click" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="display:none;">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> 验证码：</label>
                                        <div class="col-sm-2 m-b-5">
                                            <input type="text" class="form-control" id="Text1" maxlength="4" runat="server" placeholder="验证码" autocomplete="off"/>
                                        </div>
                                        <div class="col-sm-5 m-b-5">
                                            <asp:ImageButton ID="ImageButton2" runat="server" Style="width: 80px; height: 38px; border: 0px; cursor: pointer;" ImageUrl="~/ValidatedCode.aspx" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="display:none;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group" >
                                            <label class="col-sm-2 control-label"><span class="text-danger">*</span> 短信验证码：</label>
                                            <div class="col-sm-2 m-b-5">
                                                  <input type="text" class="form-control" id="txtVerifCode" maxlength="6" runat="server" placeholder="短信验证码" autocomplete="off" />
                                            </div>
                                            <div class="col-sm-5 m-b-5" id="code_div">
                                                 <asp:Button ID="btnSendSMS" runat="server" CssClass="btn btn-success"  OnClick="DX_btnLogin_Click" AutoBackPost="true" OnClientClick="return checkphone();"    Text="获取验证码" autocomplete="off"/>
                                                 <span id="countdown_s" style="height:40px; display:inline-block; " class="countdown_s" runat="server"></span>
                                                <input type="hidden" class="countdown_val" runat="server" id="countdown_val" />
                                                <input type="hidden" class="btn_is_view" runat="server" id="btn_is_view" />
                                                <span  id="msg" runat="server" class="msg" style="color:red;margin-left:220px;font-size:16px;" ></span></div>
                                            </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>
                                        
                                     
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--密码--%>登陆密码：<br/> </label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtPassword" runat="server" class="form-control" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--确认密码--%>确认登陆密码：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtRegPassword" runat="server" class="form-control" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--二级密码--%>交易密码：<br/></label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtSecondPassword" runat="server" class="form-control" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> 确认交易密码<%--确认密码--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" class="form-control" id="txtRegSecondPassword" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <h4 class="header-title m-t-0 m-b-30"><%--会员资料--%>会员资料</h4>

                                <div class="col-sm-12" >
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>昵称 <%--昵称--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtNiceName" type="text" id="txtNiceName" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                   <div class="col-sm-12" >
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>身份证号  <!--身份证号-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtIDNumber" maxlength="18" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>推荐人编号  <%--推荐人编号--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                  <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>服务中心编号  <%--推荐人编号--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtRecommendCode" type="text" id="Agent" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12"  style="display:none;">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>注册区域：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <asp:RadioButtonList runat="server" ID="radioRegQy" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Selected="True">左区</asp:ListItem>
                                                <asp:ListItem Value="2">右区</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" style="display:none">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> 手机号码 <!--手机号码-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtPhoneNum" runat="server" />
                                        </div>
                                    </div>
                                </div>
                             
                            </div>
                        </div>
                        <hr />
                        <div class="card-box">
                           <%-- <h4 class="header-title m-t-0 m-b-30"><!--银行资料--><%=GetLanguage("Banking") %></h4>
                            <div class="row form-horizontal">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--开户银行--><%=GetLanguage("Depositary") %>：</label>
                                        <div >
                                            
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <div class="col-sm-5 m-b-5"> <asp:DropDownList ID="dropBank" runat="server" class="form-control">
                                                        </asp:DropDownList></div>
                                                       <div class="col-sm-5 m-b-5">
                                                        <asp:DropDownList ID="dropProvince" runat="server" class="form-control">
                                                        </asp:DropDownList></div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--银行支行--><%=GetLanguage("BankBranch") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="form-control" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--银行账户--><%=GetLanguage("BankAccount") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtBankAccount" type="text" id="txtBankAccount" maxlength="19" class="form-control" runat="server" value="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <!--开户姓名--><%=GetLanguage("AccountName") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtBankAccountUser" runat="server" value=""/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        --%>
                              
                            <div class="row">
                                <div class="form-group m-b-0 m-b-5">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="btn btn-custom " OnClientClick="javascript:return confirmex()" OnClick="btnSubmit_Click" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End row -->

        </div>
    </form>
</body>
</html>
