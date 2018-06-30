<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forget.aspx.cs" Inherits="Web.forget" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>忘记密码</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="css/core.css" />
    <link rel="stylesheet" type="text/css" href="css/components.css" />
    <link rel="stylesheet" type="text/css" href="css/icons.css" />
    <link rel="stylesheet" type="text/css" href="css/pages.css" />
    <link rel="stylesheet" type="text/css" href="css/menu.css" />
    <link rel="stylesheet" type="text/css" href="css/responsive.css" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="error-body no-top">
    <div class="account-pages"></div>
    <div class="clearfix"></div>
    <div class="wrapper-page">
        <div class="text-center">
            <a href="index.html" class="logo"><span>LOG<span>O</span></span></a>
        </div>
        <div class="m-t-40 card-box">
            <div class="text-center">
                <h4 class="text-uppercase font-bold m-b-0">忘记密码</h4>
            </div>
            <div class="panel-body">
                <form class="form-horizontal m-t-20" id="Form1" runat="server" >

                    <div class="form-group ">
                        <div class="col-xs-12">
                              <asp:TextBox ID="txtUserCode" runat="server" class="form-control" placeholder="用户名"></asp:TextBox>
                         
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12">
                             <asp:DropDownList ID="dropQuestion" runat="server" class="form-control">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">您的姓名是？</asp:ListItem>
                                    <asp:ListItem Value="2">您的家乡是？</asp:ListItem>
                                    <asp:ListItem Value="3">您最敬佩的人是？</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="dropQuestionEn" runat="server" Style="display: none;" class="form-control">
                                    <asp:ListItem Value="0">Please select</asp:ListItem>
                                    <asp:ListItem Value="1">Your name is?</asp:ListItem>
                                    <asp:ListItem Value="2">Your home is?</asp:ListItem>
                                    <asp:ListItem Value="3">People you admire are?</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group ">
                        <div class="col-xs-12">
                       <asp:TextBox ID="txtAnswer" runat="server" class="form-control" placeholder="密保答案"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group text-center m-t-30">
                        <div class="col-xs-12">
                            <input id="btnConfirm" type="button" value=" 确认 " class="btn btn-custom btn-bordred btn-block waves-effect waves-light" onclick="checkinput()" />
                             <a href="login.aspx" class="btn btn-default btn-bordred btn-block waves-effect waves-light">返回登录</a>
                           
                        </div>
                    </div>
                </form>

            </div>
        </div>
        <!-- end card-box-->

    </div>
    <!-- end wrapper page -->
    <!-- jQuery  -->
    <!-- App js -->

    <script src="js/modernizr.min.js"></script>
    <script>
        var resizefunc = [];
    </script>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/detect.js"></script>
    <script src="js/fastclick.js"></script>
    <script src="js/jquery.slimscroll.js"></script>
    <script src="js/jquery.blockui.js"></script>
    <script src="js/waves.js"></script>
    <script src="js/jquery.nicescroll.js"></script>
    <script src="js/jquery.scrollto.min.js"></script>
    <script src="js/jquery.core.js"></script>
    <script src="js/jquery.app.js"></script>
</body>
</html>
