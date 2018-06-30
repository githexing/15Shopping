<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="NoticeDetail.aspx.cs" Inherits="web.user.member.NoticeDetail" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     
        <!-- Start content -->
        <div class="content">
            <div class="container">
				
				<div class="row">
					<div class="col-sm-12 text-right m-b-10">
						<a href="javascript:history.go(-1)" class="btn btn-sm btn-default"><i class="fa fa-mail-reply-all"></i> 返回</a>
					</div>
				</div>
				
                <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <div class="row">
                            	<div class="col-sm-12">
                            		<h2 class="text-center"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></h2>
                            		<p class="text-center text-muted"><%=GetLanguage("ReleaseTime") %>:<!--发布时间-->:<asp:Literal ID="LitPublishTime" runat="server"></asp:Literal>
                                        &nbsp;&nbsp;<%=GetLanguage("Publisher")%><!--发布者-->：<asp:Literal ID="LitPublisher" runat="server"></asp:Literal></p>
                            		<div class="m-t-20">
                            			<p><%--会员编号：000001 姓名：华明  在第二期竞拍中抽中一个电烤炉--%><asp:Literal ID="ltContent" runat="server"></asp:Literal></p>
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
