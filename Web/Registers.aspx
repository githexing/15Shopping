<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registers.aspx.cs" Inherits="Web.Registers" %>

<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>注册-云图</title>
    <script src="js/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/flexible.js" type="text/javascript" charset="utf-8"></script>
    <link rel="stylesheet" type="text/css" href="css/regstyle.css" />
            <link rel="stylesheet" type="text/css" href="/css/sweetalert2.min.css" />
<script src="JS/jquery-1.11.3.min.js"></script>
<script src="JS/CustomFun.js"></script>
<script src="JS/jquery.hovertreescroll.js"></script>
<script src="JS/js.js"></script>
</head>
<body>
     <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="register">
        <div class="logo">云图
            <%--<img src="images/logo.png" />--%></div>
        <div class="register-form">
            <div class="form-group">
                <span class="ico ico-user"></span>
                <span>
                    <input type="text" name="txtUserCode" id="txtUserCode" runat="server" maxlength="11" placeholder="手机号码" /></span>
            </div>
            <div class="form-group">
                <span class="ico ico-sex"></span>
                <span class="check">
                    <input type="radio" name="sex" id="sex1" runat="server" checked/><b></b>
                    <label for="sex1">男</label>
                </span>
                <span class="check">
                    <input type="radio" name="sex" id="sex2" runat="server" /><b></b>
                    <label for="sex2">女</label>
                </span>
            </div>
            <div class="form-group" style="display:none">
                <span class="ico ico-tel"></span>
                <span>
                    <input type="text" name="txtPhoneNum" id="txtPhoneNum" runat="server" placeholder="手机号码" /></span>
            </div>
            <div class="form-group">
                <span class="ico ico-password"></span>
                <span>
                    <input type="password" name="txtPassword" id="txtPassword" runat="server" placeholder="登录密码" /></span>
                <a href="#" class="ico ico-show jsShow"></a>
            </div>
            <div class="form-group">
                <span class="ico ico-password"></span>
                <span>
                    <input type="password" name="txtSecondPassword" id="txtSecondPassword" runat="server" placeholder="支付密码" /></span>
                <a href="#" class="ico ico-show jsShow"></a>
            </div>
            <div class="form-group">
                <span class="ico ico-recommend"></span>
                <span>
                    <input type="text" name="txtRecommendCode" id="txtRecommendCode" runat="server" placeholder="推荐人编号" disabled="disabled" /></span>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                <ContentTemplate>
                    <div class="form-group">
                        <span class="ico ico-code"></span>
                        <span>
                            <input type="text" name="checkCode" id="verifid_code" runat="server" placeholder="验证码" /></span>
                        <asp:Button ID="varifiBtn" runat="server" AutoBackPost="true" OnClientClick="return checkphone();" class="btn-code" OnClick="VerifiCode_Click"  Text="获取验证码" />
                        <span id="countdown_s" class="countdown_s" runat="server"></span>
                        <input type="hidden" class="countdown_val" runat="server" id="countdown_val" />
                        <input type="hidden" class="btn_is_view" runat="server" id="btn_is_view" />

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            <span id="msg" class="msg" style="color: red; margin-left: 220px; font-size: 16px;" runat="server"></span>
        </div>
        <div class="btn-block">
            <asp:Button runat="server" OnClick="btnSubmit_Click" ID="btnSubmit" class="button_0" Text="注 册"/>
        </div>
    </div>
    <div class="download">
        <h3>下载app</h3>
        <div class="download-btn">
            <a href="#">
                <span class="ico-android"></span>
                <span>下载安卓版</span>
            </a>
            <a href="#">
                <span class="ico-ios"></span>
                <span>下载苹果版</span>
            </a>
        </div>
    </div> <script src="/js/sweetalert2.min.js"></script>

    <script type="text/javascript">
        $(".jsShow").click(function () {
            var obj = $(this).parent('.form-group').find('input');
            if (obj.attr('type') == 'password') {
                obj.attr('type', 'text');
                $(this).addClass('active');
            } else {
                obj.attr('type', 'password');
                $(this).removeClass('active');
            }

        })

        function checkphone() {
            $(".txtPhoneNum");
            $(".txtPhoneNum").css("border", "1px solid #ddd");
            $(".msg").html("");
            var ispost = formVerification($(".txtPhoneNum"), function (msg, obj) {
                $(obj).css("border", "1px solid red");
                $(".msg").html(msg);
            });
            if (ispost) $(".msg").html("正在发送验证码...");
            return ispost;
        }
        $(document).ready(function () {
            var time = setInterval(function () {
                var s_num = parseInt($(".countdown_val").val());
                if (s_num != null && !isNaN(s_num) && s_num > 0) {
                    s_num -= 1;
                    $(".countdown_val").val(s_num);
                    $(".countdown_s").html("重新获取验证码" + s_num + "秒");
                    if (s_num <= 0) $("#code_div").load(location.href + " #code_div>*");
                }
            }, 1000);
        });
    </script>
         </form>
   
</body>
</html>
