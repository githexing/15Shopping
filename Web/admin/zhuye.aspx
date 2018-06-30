<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhuye.aspx.cs" Inherits="Web.admin.zhuye" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body style="background-color: #E8E8FF">
    <form id="form1" runat="server">
<div class="mainwrapper" style="top:0px;background-color:#E8E8FF">
<!-- contentpanel start-->
                     <%--   <div class="row row-stat">
						    <div class="col-md-4">
                                <div class="panel noborder">
                                    <div class="panel-heading noborder">
                                        <div class="panel-btns">
                                            <a href="#" class="panel-close tooltips" data-toggle="tooltip" title="Close Panel"><i class="fa fa-times"></i></a>
                                        </div>
                                        <div class="panel-icon icon-user"><i class="fa fa-user"></i></div>
                                        <div class="media-body">
                                            <h1 class="mt5">9,421</h1>
                                            <h5 class="md-title nomargin">日分红奖累计</h5>											
                                        </div>
                                    </div>
                                </div>
                            </div>
							
							<div class="col-md-4">
                                <div class="panel noborder">
                                    <div class="panel-heading noborder">
                                        <div class="panel-btns">
                                            <a href="#" class="panel-close tooltips" data-toggle="tooltip" title="Close Panel"><i class="fa fa-times"></i></a>
                                        </div>
                                        <div class="panel-icon icon-globe"><i class="fa fa-globe"></i></div>
                                        <div class="media-body">                                          
                                            <h1 class="mt5">3,298</h1>
											<h5 class="md-title nomargin">奖金累计</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
							
                            <div class="col-md-4">
                                <div class="panel noborder">
                                    <div class="panel-heading noborder">
                                        <div class="panel-btns">
                                            <a href="#" class="panel-close tooltips" data-toggle="tooltip" title="Close Panel"><i class="fa fa-times"></i></a>
                                        </div>
                                        <div class="panel-icon icon-envelope"><i class="fa fa-envelope"></i></div>
                                        <div class="media-body">                                           
                                            <h1 class="mt5">4,658</h1>
											<h5 class="md-title nomargin">流通币累计</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%><!-- row -->
						<div class="row">
                          <%--  <div class="col-md-12">
                                <div style="text-align:center;font-size:20px;margin-top:20px;"><strong>最新交易价格：<asp:Label runat="server" ID="lbLatestPrice"></asp:Label></strong></div>
                            </div>--%>
                             <%-- <div class="col-md-4">
                                <p><asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-block btn-lg btn-rounded btn-primary" iconcls="icon-ok" OnClick="LinkButton1_Click"> 清空奖金 </asp:LinkButton>
                                </p>
                            </div>--%>
                            <%--<div class="col-md-4">
                                <p><asp:LinkButton ID="lbtnSettle" runat="server" class="btn btn-block btn-lg btn-rounded btn-success" iconcls="icon-ok" OnClick="lbtnSettle_Click"> 发放奖金 </asp:LinkButton>
                                </p>
                            </div>--%>
                            
                            <%--<div class="col-md-4">
                                <p><asp:LinkButton ID="lbtnBuy" runat="server" class="btn btn-block btn-lg btn-rounded btn-info" iconcls="icon-ok" OnClick="lbtnBuy_Click"> 购买股票 </asp:LinkButton>
                                </p>
                            </div>--%>
                        </div><!-- row -->
					</div>
<!-- contentpanel -->

      <%--  <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/jquery-migrate-1.2.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/modernizr.min.js"></script>
        <script src="js/pace.min.js"></script>
        <script src="js/retina.min.js"></script>
        <script src="js/jquery.cookies.js"></script>
        <script src="js/custom.js"></script>--%>
    </form>
</body>
</html>
