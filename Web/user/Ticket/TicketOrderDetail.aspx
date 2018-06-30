<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketOrderDetail.aspx.cs" Inherits="Web.user.Ticket.TicketOrderDetail" %>

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
     <script src="/JS/layer.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <div class="order-basic">
        <div class="order-o">订单金额：<b class="orange"><%=price %></b></div>
        <div class="order-o">订单状态：<b class="red"><%=statusstr %></b></div>
        <div class="order-o">订单编码：<b><%=orderid %></b></div>
    </div>
    <div class="order-mox">
        <h3>航班信息</h3>
        <div class="order-xp">
            <div class="order-place">
                <div class="tix"><%=piaodate %></div>
                <div class="prc"><%=trancode %> <%=cabin %>舱</div>
                <div class="clear">
                    <div class="start">
                        <div><%=startstationname %></div>
                        <div><%=starttime %></div>
                    </div>
                    <div class="ico"></div>
                    <div class="end">
                        <div><%=endstationname %></div>
                        <div><%=arrivetime %></div>
                    </div>
                </div>
            </div>
        </div>
        <h3>联系人</h3>
        <div class="order-xp">
            <div class="order-tc">
                <span class="tdl"><%=linkman %></span>
                <span class="ndt"><%=linkmobile %></span>
            </div>
        </div>
        <h3>乘客信息</h3>
         <form id="formmain" runat="server">
            <input type="hidden" runat="server" id="ordercode" />
             <input type="hidden" id="states" />
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="order-xp">
                        <div class="order-tc">
                            <span class="tdl">登机人：</span>
                            <span class="ndt"><%#Eval("name") %></span>
                        </div>
                        <div class="order-tc">
                            <span class="tdl">身份证：</span>
                            <span class="ndt"><%#Eval("cardno") %></span>
                        </div>
                        <div class="order-tc">
                            <span class="tdl">保险：</span>
                            <span class="ndt">1份</span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
             <input type="hidden" id="uid" runat="server"  />
             <input type="hidden" id="status" runat="server" />
        </form>
    </div>
    <%--<div class="dt-pl">
        <input name="" type="password" id="pwdpay" lay-verify="title" autocomplete="off" placeholder="请输入支付密码" class="layui-input" />
    </div>--%>
    <div class="btn-block mb">
        <a href="#" onclick="submitpay()">立即支付</a>
    </div>
    <div class="btn-block cen">
         <a href="javascript:if(confirm('确实要取消订单吗?'))" class="cancel" onclick="submitcancel()">取消订单</a>
    </div>
    <script type="text/javascript">
        //加载数据 查询订单状态
        var iCount
        $(document).ready(function () {
           // console.log($("#status").val());
            if ($("#status").val() <=1) {
                $(".mb").css({ display: "block" })
                $(".cen").css({ display: "block" })
            } else {
                $(".mb").css({ display: "none" })
                $(".cen").css({ display: "none" })
            }
            iCount = setInterval(onsubmt, 3000);
        })
        function onsubmt() {
            if ($("#status").val() < 1) {
                $.ajax({
                    url: "/APPService/Ticket.ashx?act=getorder&action=getorder&orderno=" + $("#ordercode").val(),
                    type: 'post',
                    dataType: 'json',
                    success: function (msg) {
                        var datajson = eval('(' + msg.data + ')');
                        if (msg.state == "error") {
                            if (datajson.info.match("余额不足")) {
                                alert(" 该功能暂停使用")
                            } else {
                                alert(datajson.info)
                            }
                        } else if (msg.state == "success") {
                            if (datajson.successcode == "T") {
                                $(".red").html(statushand(datajson.result.orderstatus));
                                if (datajson.result.orderstatus <= 1) {
                                    $(".mb").css({ display: "block" })
                                    $(".cen").css({ display: "block" })
                                } else {
                                    $(".mb").css({ display: "none" })
                                    $(".cen").css({ display: "none" })
                                }
                                $("#status").val(datajson.result.orderstatus)
                            }
                        }
                    },
                    error: function () {
                        alert("提交异常！");
                    }
                })
            }
            else if ($("#status").val() >= 1 || $("#status").val() == 10 || $("#status").val() == 19)
            {
                clearInterval(iCount);
            }
        }
        //确认支付
        function submitpay() {
            if ($("#status").val() == 0) {
                alert("当前状态无法支付,订单状态为等待支付后才可支付!");
            } else if ($("#status").val() == 1) {
                layer.prompt({
                    title: "请输入支付密码",
                }, function (res, index) {
                    $.ajax({
                        url: "/APPService/Ticket.ashx?act=autopayvm&action=autopayvm&orderno=" + $("#ordercode").val() + "&loacthpaypwd=" + res,
                        type: 'post',
                        dataType: 'json',
                        success: function (msg) {
                            var datajson = eval('(' + msg.data + ')');
                            if (msg.state == "error") {
                                alert(datajson.info);
                            } else if (msg.state == "success") {
                                if (datajson.successcode == "T") {
                                    $(".red").html(statushand(datajson.result.orderstatus));
                                    $("#states").val(datajson.result.orderstatus)
                                    var pams = [];
                                    pams.push($('<input>', { name: 'orderid', value: $("#ordercode").val() }));
                                    $("<form>", {
                                        method: 'post',
                                        action: 'TicketSuccess.aspx'
                                    }).append(pams).appendTo("body").submit();
                                } else {
                                    alert(datajson.info);
                                }
                            }
                        },
                        error: function () {
                            alert("提交异常！");
                        }
                    })
                })
            } else {
                alert("当前状态为" + statushand($("#states").val()) + "不可支付");
            }
        }
        //取消订单
        function submitcancel() {
            var reqrul;
            if ($("#status").val() <= 2) {
                reqrul = "/APPService/Ticket.ashx?act=ordercancel&action=ordercancel&orderno=" + $("#ordercode").val()
            } else {
                alert("当前状态不可取消(退票)");
                return;
            }
            $.ajax({
                url: reqrul,
                type: 'post',
                dataType: 'json',
                success: function (msg) {
                    var datajson = eval('(' + msg.data + ')');
                    if (msg.state == "error") {
                        alert(datajson.info)
                    } else if (msg.state == "success") {
                        if (datajson.successcode == "T") {
                            alert(datajson.info);
                            $("#states").val(10)
                            window.location.href = 'TicketOrderList.aspx?UserID=' + $("#uid").val()
                        }
                    }
                },
                error: function () {
                    alert("提交异常！");
                }
            })
        }
        function statushand(str) {
            var msg;
            switch (str) {
                case "0":
                    msg = "待确认";
                    break;
                case "1":
                    msg = "等待支付";
                    break;
                case "2":
                    msg = "等待出票";
                    break;
                case "3":
                    msg = "出票完成";
                    break;
                case "10":
                    msg = "订单关闭";
                    break;
                case "16":
                    msg = "暂不能出票";
                    break;
                case "19":
                    msg = "已拒单";
                    break;
                case "31":
                    msg = "退款中";
                    break;
                case "32":
                    msg = "退款失败";
                    break;
                case "33":
                    msg = "退款成功";
                    break;
                default:
                    msg = "待确认";
                    break;
            }
            return msg;
        }
    </script>
</body>
</html>
