<%@ Page Language="C#" MasterPageFile="~/user/index.Master" AutoEventWireup="true" CodeBehind="PopLink.aspx.cs" Inherits="Web.user.member.PopLink" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="content-page">
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30">推广链接</h4>
                            <div class="form-horizontal">
                        		<div class="form-group">
                                    <label class="col-sm-2 control-label">推广链接中心</label>
                                    <div class="col-sm-10 form-control-static">
<%--                                       <%="http://"+HttpContext.Current.Request.Url.Host+"/Registers.aspx?UserCode="+LoginUser.UserCode%>--%>
                                       <a href='<%=rem_url %>' target="_brank" class="tga" style="background:none; background-color:transparent;border:none;font-size:inherit; outline:none; color:#06f;float:left;"><%=rem_url %></a>
                                    </div>
                                </div>
                              
                            </div>
						</div>
					</div>
                </div>
                <!-- End row -->

            </div> <!-- container -->

        </div> <!-- content -->
        </div>
    </asp:Content>