<%@ Page Language="C#" MasterPageFile="/user/index.Master" AutoEventWireup="true" CodeBehind="Registers.aspx.cs" Inherits="Web.user.Registers" %>



<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

 
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--登录资料--%><%=GetLanguage("LoginInformation") %></h4>
                            <div class="row form-horizontal">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span>手机号码：</label>
                                    <div class="col-sm-10 m-b-5">
                                            <input type="text" id="txtUserCode" runat="server" class="form-control" maxlength="11"/>
                                        </div>
                                        <div class="col-sm-5 m-b-5"  style="display:none" >
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
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--密码--%><%=GetLanguage("LoginPassword") %>：<br/><span style="color:darkgrey;"><%=GetLanguage("PasswordDefault") %></span></label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtPassword" runat="server" class="form-control" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--确认密码--%><%=GetLanguage("ConfirmPass") %>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtRegPassword" runat="server" class="form-control" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%--二级密码--%><%=GetLanguage("SecondPassword") %>：<br/><span style="color:darkgrey;"><%=GetLanguage("PasswordDefault") %></span></label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" id="txtSecondPassword" runat="server" class="form-control" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span> <%=GetLanguage("ConfirmPass") %><%--确认密码--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="password" class="form-control" id="txtRegSecondPassword" runat="server" autocomplete="off"/>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <h4 class="header-title m-t-0 m-b-30"><%--会员资料--%><%=GetLanguage("NetworkInformation") %></h4>

                                <div class="col-sm-12" >
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("MemberNickname") %> <%--昵称--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtNiceName" type="text" id="txtNiceName" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12" >
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("IDNumber") %> <!--身份证号-->：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" id="txtIDNumber" maxlength="18" runat="server" />
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
                             
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("ReferenceNumber") %> <%--推荐人编号--%>：</label>
                                        <div class="col-sm-10 m-b-5">
                                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="form-control"  disabled="disabled" />
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
                                        <label class="col-sm-2 control-label"><span class="text-danger">*</span><%=GetLanguage("ContactPhone") %> <!--手机号码-->：</label>
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
        <!-- container -->
 <script>
     function checkphone() {
         //$(".form1").find("#mobile").css("border", "1px solid #ddd");
         //$(".msg").html("");
         //var ispost = formVerification($(".form1").find("#mobile"), function (msg, obj) {
         //    $(obj).css("border", "1px solid red");
         //    $(".msg").html(msg);
         //});
         $('#<%=btnSendSMS.ClientID%>').hide();
         ispost = true;
         if (ispost) $(".msg").html("正在发送验证码...");
         return ispost;
     }

     $(document).ready(function () {
         $('#<%=txtPassword.ClientID%>').val('111111');
         $('#<%=txtRegPassword.ClientID%>').val('111111');
         $('#<%=txtSecondPassword.ClientID%>').val('111111');
         $('#<%=txtRegSecondPassword.ClientID%>').val('111111');

         var time = setInterval(function () {
             var s_num = parseInt($(".countdown_val").val());
             if (s_num != null && !isNaN(s_num) && s_num > 0) {
                 s_num -= 1;
                 $(".countdown_val").val(s_num);
                 $(".countdown_s").html("重新获取验证码" + s_num + "秒");
                 if (s_num <= 1) $("#code_div").load(location.href + " #code_div>*");
             }
         }, 1000);
     });

 </script>
    
</asp:content>


