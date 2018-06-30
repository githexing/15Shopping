<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/index.Master"  CodeBehind="ApplyAccount.aspx.cs" Inherits="Web.user.team.ApplyAccount" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
 
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("ApplyAccount")%><%--申请分号--%></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-inline">
                                        <%--<label><%=GetLanguage("MembershipNumber")%><!--会员编号--></label>--%>
                                        <label>1、主账号投资额度达到<%=p_amount %>美金。</label><br />
                                        <label>2、完成直推<%=p_recnum %>人 。</label><br />
                                        <label>3、需要释放币<%=p_trans %>个 。</label><br />
                                    </div>
                                    <asp:UpdatePanel runat="server"><ContentTemplate>
                                    <asp:Button ID="btnApply" runat="server" OnClick="btnApply_Click" class="btn btn-success waves-effect waves-light btn-md" />
                                        </ContentTemplate></asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- container -->

        </div>
        <!-- content -->

    
 
</asp:Content>
