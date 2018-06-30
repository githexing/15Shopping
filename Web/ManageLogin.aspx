<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageLogin.aspx.cs" Inherits="Web.ManageLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="renderer" content="webkit"/> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <title>登录</title>
    <link rel="stylesheet" type="text/css" href="./admin/css/style.css" />
    <script src="JS/jquery-1.11.3.min.js" type="text/javascript"></script>
    <script src="js/login1.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function replace(o) {
            var obj = document.getElementById(o)
            if (obj.value != "") {
                obj.value == "";
            }
        }
        $(document).ready(function () {
            cleartip();
            $("#txtPwd").focus(function () {
                $("#pwd_tip").html("");
            }).blur(function () {
                var tip = $("#pwd_tip").html();
                var txtpwd = $("#txtPwd").val();
                if (txtpwd == "") {
                    $("#pwd_tip").html("密码");
                }
            });
            $("#txtUserName").focus(function () {
                $("#user_tip").html("");
            }).blur(function () {
                var tip = $("#user_tip").html();
                var txtpwd = $("#txtUserName").val();
                if (txtpwd == "") {
                    $("#user_tip").html("用户名");
                }
            });
            $("#txtVa").focus(function () {
                $("#Va_tip").html("");
            }).blur(function () {
                var tip = $("#Va_tip").html();
                var txtpwd = $("#txtVa").val();
                if (txtpwd == "") {
                    $("#Va_tip").html("验证码");
                }
            });
        });
        function ssss(t, v) {
            $("#" + t).html("");
            $("#" + v).focus();
        }
        function cleartip() {
            if ($("#txtPwd").val() != "") {
                $("#pwd_tip").html("");
            }
            if ($("#txtUserName").val() != "") {
                $("#user_tip").html("");
            }
            if ($("#txtVa").val() != "") {
                $("#Va_tip").html("");
            }
        }
        function getcode() {
            $('img').attr('src', 'userfiles/CheckCode.aspx?t=' + Math.random());
        }
    </script>
</head>
<body class="signin">
    <form id="Form1" name="colorform" runat="server">
        
			<div class="panel panel-signin">
				<div class="panel-body">
					<h4 class="text-center mb5">后台登录</h4>
					<div class="mb30"></div>
					 
						<div class="input-group mb15">
							<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <input class="form-control" id="txtUserName" runat="server" type="text" value=""  placeholder="请输入账号" />
						</div>
						<!-- input-group -->
						<div class="input-group mb15">
							<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <input class="form-control" id="txtPwd" runat="server" type="password" value="" placeholder="请输入密码"/>
						</div>
						<!-- input-group -->
                    <div class="ckbox ckbox-primary mt10 input-group ">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-flag"></i></span>
						<input id="txtVa" runat="server" type="text" class="form-control"  style="width: 216px;float:left;" value="" placeholder="输入验证码"  />
                        <img alt="" src="userfiles/CheckCode.aspx"  onclick="getcode()" style="width: 64px;" class="form-control"/> 
					</div>
                    <div class="input-group mb15" style="margin-top:20px;">
                        <asp:Button ID="btnLogin" runat="server" class="btn btn-success form-control" style="width:320px;" Text="登陆" OnClick="btnLogin_Click" OnClientClick="return validate()"  />
					</div>
				</div>
			</div>
		 
    </form>
</body>
</html>
