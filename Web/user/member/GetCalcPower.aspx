
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master"  CodeBehind="GetCalcPower.aspx.cs" Inherits="Web.user.member.GetCalcPower" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <!-- Start content -->
        <div class="content">
            <div class="container">
				
				<div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                            	<h1 class="text-purple"><i class="fa fa-diamond"></i></h1>
                                <p>邀请好友</p>
                                <p>激活码：<%=LoginUser.User008 %></p>
                                <p style="margin-top:50px; ">
                                    <%--<a href="invitation.html" class="btn btn-sm btn-custom waves-effect waves-light">+1算力</a>--%>
                                    <a href='<%=rem_url %>' target="_brank" class="tga" style="background: none; background-color: transparent; border: none; font-size: inherit; outline: none; color: #06f; float: left;"><%=rem_url %></a>
                                </p>
                            </div>
                        </div>
                    </div>
                    
                    <%--<div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                            	<h1 class="text-purple"><i class="fa fa-calendar"></i></h1>
                                <p>每日登陆</p>
                                <p>登陆获取算力</p> 
                                <%if(A==1) %> 
                                <%{ %>
                                 <p><a id="QD" class="btn btn-sm btn-custom waves-effect waves-light">签到</a></p>
                                  <%} %>
                                <%else { %>
                                 <!--   <p><a id="QD" class="btn btn-sm btn-custom waves-effect waves-light">签到</a></p>-->
                                <h3><span class="text-success"><i class="fa fa-check-circle"></i> 已完成</span></h3>
                                  <%} %>
                            </div>
                        </div>
                    </div>--%>
                    
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                            	<h1 class="text-purple"><i class="fa fa-gears"></i></h1>
                                <p>增加矿机</p>
                                <p>获得更多释放币</p>
                                <p><a href="/user/finance/Invest.aspx" class="btn btn-sm btn-custom waves-effect waves-light">立即购买</a></p>
                            </div>
                        </div>
                    </div>
                </div>

            </div> <!-- container -->

        </div> <!-- content -->
    <script type="text/javascript">
        $(function () {
            $("#QD").click(function () {
                $.ajax({
                    url: "/APPService/YunTu_QianDao.ashx?UserID=<%=getLoginID()%>",
                    type: "POST",
                    success: function (data) {
                        data = eval('(' + data + ')')
                        alert(data.message); 
                    } 
                }) 
            }) 
        })


    </script>
</asp:Content>