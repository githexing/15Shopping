<%@ Page Language="C#" MasterPageFile="/user/index.Master" AutoEventWireup="true" CodeBehind="RegSuccess.aspx.cs" Inherits="Web.RegSuccess" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

   
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("Register")%></h4>
                            <h4 class="text-success"><%=GetLanguage("Congratulations")%><%--恭喜您注册成功！--%></h4>
                            <div class="row form-horizontal">
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MembershipNumber")%><!--会员编号-->：</label>
                                    <div class="col-sm-9 form-control-static">
                                       <label class="text-success"> <%=strUserCode %></label>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("RegisterNickname")%><%--注册昵称--%>：</label>
                                    <div class="col-sm-9 form-control-static">
                                       <label class="text-success"> <%=strNickname%>&nbsp;</label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- container -->

 
</asp:Content>
