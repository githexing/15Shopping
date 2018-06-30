<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lockscreen.aspx.cs" Inherits="Web.user.lockscreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link rel="stylesheet" type="text/css" href="../css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<body class="error-body no-top">
    <div class="container">
        <div class="lockscreen-wrapper animated  flipInX">
            <div class="row">
                <div class="col-md-12">
                    <div class="profile-wrapper">
                        <img width="70" height="70" alt="" src="../static/img/ico_user_white.png" />
                    </div>
                    <form id="form1" runat="server" class="user-form" action="index.aspx" method="post">
                        <h2 class="user"><%=LoginUser.UserCode %></h2>
                        <input type="password" placeholder="请输入登录密码"/>
                        <button type="submit" class="btn btn-primary "><i class="fa fa-unlock"></i></button>
                    </form>
                </div>
            </div>
        </div>
        <div id="push"></div>
    </div>
</body>
</html>
