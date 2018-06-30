<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="MyIDAuthentication.aspx.cs" Inherits="Web.user.member.MyIDAuthentication" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="content">
        <div class="container">
            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                         <h4 class="header-title m-t-0 m-b-30"><%--身份证验证--%><%=GetLanguage("IDcardAuthentication") %></h4>
                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--会员编号--%><%=GetLanguage("MembershipNumber") %>：</label>
                                    <div class="col-md-10">
                                        <span class="text-danger"><%=LoginUser.UserCode%></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--身份证--%><%=GetLanguage("IDNumber") %>：</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIdCard" runat="server" class="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%--真实姓名--%><%=GetLanguage("RealName") %>：</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtRealName" runat="server" class="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-custom btn-md" OnClick="btnSubmit_Click" Text="提 交"/>
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

    </div>
</asp:Content>