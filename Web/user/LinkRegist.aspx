<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkRegist.aspx.cs" Inherits="Web.user.LinkRegist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title><%--推广链接--%><%=GetLanguage("PromotionLink") %></title>
    <link rel="stylesheet" type="text/css" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/css/core.css" />
    <link rel="stylesheet" type="text/css" href="/css/components.css" />
    <link rel="stylesheet" type="text/css" href="/css/icons.css" />
    <link rel="stylesheet" type="text/css" href="/css/pages.css" />
    <link rel="stylesheet" type="text/css" href="/css/menu.css" />
    <link rel="stylesheet" type="text/css" href="/css/responsive.css" />
    <link rel="stylesheet" type="text/css" href="/css/login.css" />
    <link rel="stylesheet" type="text/css" href="/css/sweetalert2.min.css" />
    <style>
        @media (min-width: 767px) {
            .wrapper-page {
                width: 600px;
            }
        }

        .logo img {
            width: 100px;
        }
    </style>
</head>
<body class="fixed-left" style="overflow-y: auto">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="particles-pages" id="particles-js"></div>
        <div class="login-bg1"></div>
        <div class="login-bg2"></div>
        <div class="login-bg3"></div>
        <div class="clearfix"></div>
        <div class="wrapper-page">
            <div class="text-center">
                <a href="index.html" class="logo">
                    <img src="/images/login-logo.png" />
                </a>
            </div>
            <div class="m-t-40 card-box">
                <div class="text-center tit-tab clearfix m-t-20">
                    <h4 class="text-uppercase font-bold m-b-0" style="width: 100%">注册</h4>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal m-t-20" >

                        <div class="form-group ">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> 手机号码：</label>
                                <div class="col-sm-9 m-b-10">
                                    <input type="text" id="txtUserCode" runat="server" class="form-control" maxlength="11" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group" id="tb-pa1"  style="display:none;">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> 验证码：</label>
                                <div class="col-sm-6 m-b-10">
                                    <input type="text" class="form-control" id="txtImgVerifyCode" maxlength="4" runat="server" placeholder="验证码" />
                                </div>
                                <div class="col-sm-3 m-b-5">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Style="width: 80px; height: 38px; border: 0px; cursor: pointer;" ImageUrl="~/ValidatedCode.aspx" />
                                </div>

                            </div>
                        </div>
                        <div class="form-group" id="tb-pa1">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> 短信验证码：</label>
                                <div class="col-sm-6 m-b-10">
                                    <input type="text" class="form-control" id="txtVerifCode" maxlength="6" runat="server" placeholder="短信验证码" />
                                </div>
                                <div class="col-sm-3 m-b-10">
                                    <a id="btnsend" class="btn btn-success" onclick="asd()">获取短信</a>
                                    <span id="msg" class="msg" style="font-size: 12px;"></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" id="tb-pa1">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> <%--密码--%><%=GetLanguage("LoginPassword") %>：</label>
                                <div class="col-sm-9 m-b-5">
                                    <input type="password" id="txtPassword" runat="server" class="form-control" />
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> <%--确认密码--%><%=GetLanguage("ConfirmPass") %>：</label>
                                <div class="col-sm-9 m-b-10">
                                    <input type="password" id="txtRegPassword" runat="server" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                            
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> <%--二级密码--%><%=GetLanguage("SecondPassword") %>：</label>
                                <div class="col-sm-9 m-b-10">
                                    <input type="password" id="txtSecondPassword" runat="server" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> <%--确认密码--%><%=GetLanguage("ConfirmPass") %>：</label>
                                <div class="col-sm-9 m-b-10">
                                    <input type="password" class="form-control" id="txtRegSecondPassword" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> <%--昵称--%><%=GetLanguage("MemberNickname") %>：</label>
                                <div class="col-sm-9 m-b-10">
                                    <input name="txtNiceName" type="text" id="txtNiceName" runat="server" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="col-sm-3 control-label"><span class="text-danger">*</span> <%--推荐人编号--%><%=GetLanguage("ReferenceNumber") %>：</label>
                                <div class="col-sm-9 m-b-10">
                                    <asp:Label runat="server" ID="txtRecommendCode" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group text-center m-t-30">
                            <div class="col-xs-12">
                                <asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="btn btn-custom" OnClientClick="javascript:return confirmex()" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end card-box-->

        <!-- container -->

        <%-- </div>--%>
        <!-- content -->
        <script src="/js/sweetalert2.min.js"></script>
        <%--<footer class="footer">
            Copyright ©<%=DateTime.Now.Year %>
        </footer>--%>
    </form>
    <script src="js/modernizr.min.js"></script>
    <script>
        var resizefunc = [];
    </script>
    <script src="/js/jquery.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/js/detect.js"></script>
    <script src="/js/fastclick.js"></script>
    <script src="/js/jquery.slimscroll.js"></script>
    <script src="/js/jquery.blockui.js"></script>
    <script src="/js/waves.js"></script>
    <script src="/js/jquery.nicescroll.js"></script>
    <script src="/js/jquery.scrollto.min.js"></script>
    <script src="/js/jquery.core.js"></script>
    <script src="/js/jquery.app.js"></script>
    <script src="/js/particles.min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        var countdown = 60;
        function asd() {
            var phone = $("#txtUserCode").val();
            var YZM = $("#txtImgVerifyCode").val();
            if (phone == "") {
                alert('请输入手机号码');
                return;
            }
            if (YZM == "") {
                alert('请输入验证码');
                return;
            }
             
            $.ajax({
                url: "/APPService/Yanzhengma.ashx?phone=" + phone+"&&YZM="+YZM+"&&Type=0",
                type: "post",
                success: function (data) {
                    var data = eval('(' + data + ')');
                    if (data.state == "success")
                        settime();
                    alert(data.message);
                }

            })

        }

        function settime() { //发送验证码倒计时
            var send = $("#btnsend");
            var msg = $("#msg");
            if (countdown == 0) {
                send.show();
                msg.text("");
                countdown = 60;
                return;
            } else {
                send.hide();
                msg.text("重新获取" + countdown + "秒");
                countdown--;
            }
            setTimeout(function () {
                settime()
            }
                , 1000);
        }

        //
        $("#tit-tab h4").click(function () {
            $(this).addClass("active").siblings().removeClass("active");
            if ($(this).index() == 0) {
                $("#tb-pa1").css("display", "block");
                $("#tb-pa2").css("display", "none");
            } else {
                $("#tb-pa1").css("display", "none");
                $("#tb-pa2").css("display", "block");
            }
        })


        // 背景动画
        particlesJS("particles-js", {
            "particles": {
                "number": {
                    "value": 40,
                    "density": {
                        "enable": true,
                        "value_area": 800
                    }
                },
                "color": {
                    "value": "#ffffff"
                },
                "shape": {
                    "type": "circle",
                    "stroke": {
                        "width": 0,
                        "color": "#000000"
                    },
                    "polygon": {
                        "nb_sides": 5
                    },
                    "image": {
                        "src": "img/github.svg",
                        "width": 100,
                        "height": 100
                    }
                },
                "opacity": {
                    "value": 0.5,
                    "random": false,
                    "anim": {
                        "enable": false,
                        "speed": 1,
                        "opacity_min": 0.1,
                        "sync": false
                    }
                },
                "size": {
                    "value": 3,
                    "random": true,
                    "anim": {
                        "enable": false,
                        "speed": 40,
                        "size_min": 0.1,
                        "sync": false
                    }
                },
                "line_linked": {
                    "enable": true,
                    "distance": 150,
                    "color": "#ffffff",
                    "opacity": 0.4,
                    "width": 1
                },
                "move": {
                    "enable": true,
                    "speed": 6,
                    "direction": "none",
                    "random": false,
                    "straight": false,
                    "out_mode": "out",
                    "bounce": false,
                    "attract": {
                        "enable": false,
                        "rotateX": 600,
                        "rotateY": 1200
                    }
                }
            },
            "interactivity": {
                "detect_on": "canvas",
                "events": {
                    "onhover": {
                        "enable": false,
                        "mode": "grab"
                    },
                    "onclick": {
                        "enable": false,
                        "mode": "push"
                    },
                    "resize": true
                },
                "modes": {
                    "grab": {
                        "distance": 140,
                        "line_linked": {
                            "opacity": 1
                        }
                    },
                    "bubble": {
                        "distance": 100,
                        "size": 40,
                        "duration": 2,
                        "opacity": 8,
                        "speed": 3
                    },
                    "repulse": {
                        "distance": 200,
                        "duration": 0.4
                    },
                    "push": {
                        "particles_nb": 4
                    },
                    "remove": {
                        "particles_nb": 2
                    }
                }
            },
            "retina_detect": true
        });
    </script>
</body>
</html>

</body>
</html>
