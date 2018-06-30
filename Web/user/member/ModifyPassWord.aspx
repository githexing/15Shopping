<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master"  CodeBehind="ModifyPassWord.aspx.cs" Inherits="Web.user.member.ModifyPassWord" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--登录密码--%><%=GetLanguage("ShopPassword") %></h4>
                            <div class="row">
                        		<div class="form-horizontal col-sm-12" id="form1">
                        			<div class="form-group">
                                        <label class="col-md-2 control-label"><%--旧登录密码--%><%=GetLanguage("Oldpassword") %></label>
                                        <div class="col-md-10">
                                            <input type="password" class="form-control" id="txtPwd" runat="server" value=""  />
                                        </div>
                                    </div>
                        			<div class="form-group">
                                        <label class="col-md-2 control-label"><%--新登录密码--%><%=GetLanguage("newpassword") %></label>
                                        <div class="col-md-10">
                                            <input type="password" id="txtNewPwd" runat="server" class="form-control" value="" />
                                        </div>
                                    </div>
                        			<div class="form-group">
                                        <label class="col-md-2 control-label"><%--确认登录密码--%><%=GetLanguage("Confirmpassword") %></label>
                                        <div class="col-md-10">
                                        	<input type="password" id="txtRPNewPwd" runat="server" class="form-control" value=""  />
                                        </div>
                                    </div>
                                    <div class="form-group m-b-0">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            
                                                <asp:Button ID="btnPwd" runat="server" Text="确认修改" type="submit"   class="btn btn-custom" OnClick="btnPwd_Click"/>
                                            
                                        </div>
                                    </div>
                        		</div>
                            </div>
						</div>
					</div>
                </div>
                <div class="row" >
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--二级密码--%><%=GetLanguage("SecondPassword") %></h4>
                            <div class="row">
                        		<div class="form-horizontal col-sm-12">
                        			<div class="form-group">
                                        <label class="col-md-2 control-label"><%--旧二级密码--%><%=GetLanguage("OldSecondPassword") %></label>
                                        <div class="col-md-10">
                                            <input type="password" id="txtSecondPwd" runat="server" class="form-control" value=""  />
                                        </div>
                                    </div>
                        			<div class="form-group">
                                        <label class="col-md-2 control-label"><%--新二级密码--%><%=GetLanguage("NewSecondPassword") %></label>
                                        <div class="col-md-10">
                                            <input type="password" id="txtNewSecondPwd" runat="server" class="form-control" value=""  />
                                        </div>
                                    </div>
                        			<div class="form-group">
                                        <label class="col-md-2 control-label"><%--确认二级密码--%><%=GetLanguage("ConfirmSecondPassword") %></label>
                                        <div class="col-md-10">
                                        	<input type="password" id="txtRPSecondPwd" runat="server" class="form-control" value=""  />
                                        </div>
                                    </div>
                                    <div class="form-group m-b-0">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            
                                             <asp:Button ID="btnSecond" runat="server" Text="确认修改" type="submit" class="btn btn-custom " OnClick="btnSecond_Click"/>
                                         
                                        </div>
                                    </div>
                        		</div>
                            </div>
						</div>
					</div>
                </div>
          
                <!-- End row -->

            </div> <!-- container -->

        </div> <!-- content -->
 
    </asp:Content>