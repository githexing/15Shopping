<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="Leavewords.aspx.cs" Inherits="web.user.member.Leavewords" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("message")%><%--留言--%></h4>
                            <div class="row">
                                <div class="form-horizontal col-sm-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%=GetLanguage("Theme")%><%--主题--%></label>
                                        <div class="col-md-10">
                                            <input type="text" name="txtTitle" id="txtTitle" tip="输入主題" runat="server" class="form-control" />

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%=GetLanguage("MessageContent")%><%--留言内容--%></label>
                                        <div class="col-md-10">

                                            <asp:TextBox ID="txtPubContext" runat="server" tip="输入内容" class="form-control" Height="180px" TextMode="MultiLine"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group m-b-0">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-custom " OnClick="btnSubmit_Click"/>&nbsp;&nbsp;
                                            <asp:Button ID="btnBack" runat="server" class="btn btn-custom " OnClick="btnBack_Click" />
                                          
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
        <!-- content -->
 
</asp:Content>
