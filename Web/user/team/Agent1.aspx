<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="/user/index.Master" CodeBehind="Agent1.aspx.cs" Inherits="Web.user.team.Agent1" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <div class="page-container row-fluid">
            <!-- BEGIN PAGE CONTAINER-->
            <div class="page-content">
                <div class="content">
                    <div class="page-title">
                        <h3>申请运营中心</h3>
                    </div>
                    <div id="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div  class="card-box" >
                                    <div class="header-title m-t-0 m-b-30">
                                        <h4>运营中心信息</h4>
                                    </div>
                                    <div  class="row">
                                        <div class="row-fluid ">
                                            <div class="col-md-6">
                                                <address class="margin-bottom-20 margin-top-10">
                                                    <strong>
                                                        <asp:Literal ID="ltAgent1" runat="server"></asp:Literal><%--报单中心编号--%>：</strong> <span>
                                                            <asp:Literal ID="LitAgent1Code" runat="server"></asp:Literal> <%--<input id="txtAgent1Code" name="txtAgent1Code" runat="server" type="text" disabled="disabled" />--%></span>
                                                </address>
                                            </div>
                                            <br />
                                             <div class="col-md-6">
                                                <address class="margin-bottom-20 margin-top-10">
                                                    <strong>
                                                       请输入发货地址：</strong> <span>
                                                           <input id="Address" name="txtAgent1Code"  maxlength="40" runat="server" type="text"  />
                                                             <%--<input id="txtAgent1Code" name="txtAgent1Code" runat="server" type="text" disabled="disabled" />--%></span>
                                                </address>
                                            </div>
                                             <br />
                                               <div class="col-md-6">
                                                <address class="margin-bottom-20 margin-top-10">
                                                    <strong>
                                                       手机号码：</strong> <span>
                                                           <input id="Phone" name="txtAgent1Code"  maxlength="11" runat="server" type="text"  />
                                                             <%--<input id="txtAgent1Code" name="txtAgent1Code" runat="server" type="text" disabled="disabled" />--%></span>
                                                </address>
                                            </div>
                                        </div>
                                        <div class="row-fluid ">
                                            <div class="col-md-6">
                                                <asp:Literal ID="ltAudit" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                        <div class="row-fluid ">
                                            <div class="col-md-6">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" OnClick="btnSubmit_Click" />
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
 </asp:Content>