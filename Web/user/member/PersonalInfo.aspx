<%@ Page Language="C#" MasterPageFile="~/user/index.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="Web.user.member.PersonalInfo" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>会员资料</title>
</asp:Content>
<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
     <script language="javascript" type="text/javascript">
         function back() {
             window.history.go(-1);
         }
    </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--会员资料--%><%=GetLanguage("MemberInformation") %></h4>
                            <div class="row">
                                <div class="form-horizontal col-sm-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%--会员编号--%><%=GetLanguage("MembershipNumber") %></label>
                                        <div class="col-md-10">
                                            <input name="txtUserCode" type="text" id="txtUserCode" class="form-control" runat="server" disabled="disabled" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%--昵称--%><%=GetLanguage("MemberNickname") %></label>
                                        <div class="col-md-10">
                                            <input name="txtNiceName" type="text" class="form-control" id="txtNiceName" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%--推荐人编号--%><%=GetLanguage("ReferenceNumber") %></label>
                                        <div class="col-md-10">
                                            <input name="txtRecommendCode" type="text" class="form-control" id="txtRecommendCode" runat="server" disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none;">
                                        <label class="col-md-2 control-label"><%--支付宝账号--%><%=GetLanguage("AliPay") %></label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="txtAlipay" runat="server"  />
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none;">
                                        <label class="col-md-2 control-label"><%--手机号码--%><%=GetLanguage("ContactPhone") %></label>
                                        <div class="col-md-10">
                                            <input type="text" class="form-control" id="txtPhoneNum" runat="server"  />
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none;">
                                        <label class="col-md-2 control-label"><%--开户银行--%><%=GetLanguage("Depositary") %></label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="dropBank" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                            </div>
                                             <div class="col-md-5">
                                                <asp:DropDownList ID="dropProvince" runat="server"   class="form-control" >
                                                    </asp:DropDownList>
                                             </div>
                                    </div>
                                    <div class="form-group" style="display:none;">
                                        <label class="col-md-2 control-label"><%--银行支行--%><%=GetLanguage("BankBranch") %></label>
                                        <div class="col-md-10">
                                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none;">
                                        <label class="col-md-2 control-label"><%--银行账户--%><%=GetLanguage("BankAccount") %></label>
                                        <div class="col-md-10">
                                            <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none;">
                                        <label class="col-md-2 control-label"><%--开户姓名--%><%=GetLanguage("AccountName") %></label>
                                        <div class="col-md-10">
                                            <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="form-control"  />
                                        </div>
                                    </div>
                                      <div class="form-group" >
                                        <label class="col-md-2 control-label"><%--身份证号码--%>身份证号码</label>
                                        <div class="col-md-10">
                                            <input name="txtBankAccountUser" type="text" id="IdenCode" runat="server" class="form-control"  disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%--二级密码--%><%=GetLanguage("SecondPassword") %></label>
                                        <div class="col-md-10">
                                            <input name="txtSecondPassword" type="password" id="txtSecondPassword" runat="server" class="form-control"  />
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="form-group m-b-0 m-b-5">
                                    <div class="col-sm-offset-2 col-sm-2">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" OnClick="btnSubmit_Click"/>
                                                            </ContentTemplate>
                                             </asp:UpdatePanel>
                                    </div>
                                    <div class=" col-sm-2">
                                        <input type="button" name="button" id="btnBack" value='<%=GetLanguage("Return") %>' class="btn btn-custom " onclick=" back()" />
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
 
</asp:content>
