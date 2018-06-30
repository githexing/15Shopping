<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainOrderDetail.aspx.cs" Inherits="Web.user.Train.TrainOrderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=320,maximum-scale=1.3,user-scalable=no" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/md5.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <div class="order-basic">
        <div class="order-o">订单金额：<b class="orange"><%=price%></b></div>
        <div class="order-o">订单状态：<b class="red"><%=states%></b></div>
        <div class="order-o">订单编码：<b><%=orderid%></b></div>
    </div>
    <div class="order-mox">
        <h3>列车信息</h3>
        <div class="order-xp">
            <div class="order-place">
                <div class="tix"><%=piaodate%></div>
                <div class="prc">车次:<%=trancode%></div>
                <div class="clear">
                    <div class="start">
                        <div><%=startstationname%></div>
                        <div><%=starttime%></div>
                    </div>
                    <div class="icotrain"></div>
                    <div class="end">
                        <div><%=endstationname%></div>
                        <div><%=arrivetime%></div>
                    </div>
                </div>
            </div>
        </div>
        <h3>联系人</h3>
        <div class="order-xp">
            <div class="order-tc">
                <span class="tdl"><%=usercode%></span>
                <span class="ndt"><%=linkphone%></span>
            </div>
        </div>
        <input type="hidden" id="states" />
        <h3 class="tran_info">乘客信息</h3>
        <form id="formmain" runat="server">
            <input type="hidden" runat="server" id="ordercode" />
            <input type="hidden" runat="server" id="uid" />
            <input type="hidden" runat="server" id="status" />
            
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="order-xp">
                        <div class="order-tc">
                            <span class="tdl">登车人：</span>
                            <span class="ndt"><%#Eval("name") %></span>
                        </div>
                        <div class="order-tc">
                            <span class="tdl">身份证：</span>
                            <span class="ndt"><%#Eval("idcard") %></span>
                        </div>
                        <div class="order-tc">
                            <span class="tdl">保险：</span>
                            <span class="ndt"><%#Eval("insurance") %></span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </div>
   <%-- <div class="dt-pl">
        <input name="" type="password" id="pwdpay" lay-verify="title" autocomplete="off" placeholder="请输入支付密码" class="layui-input" />
    </div>--%>
    <div class="btn-block mb">
        <a href="#" onclick="submitpay()">立即支付</a>
    </div>
    <div class="btn-block cen">
        <a href="javascript:if(confirm('确实要取消订单吗?'))" class="cancel" onclick="submitcancel()">取消订单</a>
    </div>
    <script src="/JS/layer.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        //加载数据 查询订单状态
        var iCount
        $(document).ready(function () {
            if ($("#status").val() ==2) {
                $(".mb").css({ display: "block" })
                $(".cen").css({ display: "block" })
            } else if ($("#status").val() >= 3 || $("#status").val()==1) {
                
                $(".mb").css({ display: "none" })
                $(".cen").css({ display: "none" })
            }
            iCount = setInterval(onsubmt, 3000);
        })
        function onsubmt() {
           
            if ($("#status").val() < 1) {
                $.ajax({
                    url: "/APPService/TrainTickets.ashx?act=orderstatus&orderid=" + $("#ordercode").val(),
                    type: 'post',
                    dataType: 'json',
                    success: function (msg) {
                        if (msg.state == "error") {
                            alert(msg.data)
                            clearInterval(iCount);
                        } else if (msg.state == "success") {
                            var datajson = eval('(' + msg.data + ')');
                            $(".red").html(datajson.result.msg);
                            $("#status").val(datajson.result.status)
                            $("#ordercode").val($("#ordercode").val())
                        }
                    },
                    error: function () {
                        clearInterval(iCount);
                        alert("提交异常！");
                    }
                })
            } else if ($("#status").val() >= 1) {
                clearInterval(iCount);
            }
        }
        //确认支付
        function submitpay() {
           // alert($("#status").val())
            if ($("#status").val() != 2) {
                alert("当前状态无法支付,订单状态为占座成功后才可支付!");
            } else if ($("#status").val() == 2) {
                layer.prompt({
                    title: "请输入支付密码",
                }, function (res, index) {
                        $.ajax({
                            url: "/APPService/TrainTickets.ashx?act=pay&orderid=" + $("#ordercode").val() + "&paypwd=" + res,
                            type: 'post',
                            dataType: 'json',
                            beforeSend: function () {
                                layer.load();
                            },
                            complete: function () {
                                layer.closeAll('loading');
                            },
                            success: function (msg) {
                                if (msg.state == "error") {
                                    if (msg.data.match("余额不足")) {
                                        alert(" 该功能暂停使用")
                                    } else {
                                        alert(msg.data)
                                    }
                                   
                                } else if (msg.state == "success") {
                                    var datajson = eval('(' + msg.data + ')');
                                    var pams = [];
                                    pams.push($('<input>', { name: 'orderid', value: $("#ordercode").val() }));
                                    $("<form>", {
                                        method: 'post',
                                        action: 'TrainSuccess.aspx'
                                    }).append(pams).appendTo("body").submit();
                                }
                            },
                            error: function () {
                                alert("提交异常！");
                            }
                        })
                        layer.close(index);
                });
               
            }
        }
        //取消订单
        function submitcancel() {
            if ($("#status").val() > 2) {
                alert("当前状态无法取消订单!");
            }else{
                $.ajax({
                    url: "/APPService/TrainTickets.ashx?act=cancel&orderid=" + $("#ordercode").val(),
                    type: 'post',
                    dataType: 'json',
                    beforeSend: function () {
                        layer.load();
                    },
                    complete: function () {
                        layer.closeAll('loading');
                    },
                    success: function (msg) {
                        if (msg.state == "error") {
                            alert(msg.data)
                        } else if (msg.state == "success") {
                            var datajson = eval('(' + msg.data + ')');
                            alert(datajson.result.msg);
                            window.location.href = 'TrainOrderList.aspx?UserID=' + $("#uid").val()
                        }
                    },
                    error: function () {
                        alert("提交异常！");
                    }
                })
            }
        }

    </script>
</body>
</html>
