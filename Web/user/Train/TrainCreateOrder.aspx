<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainCreateOrder.aspx.cs" Inherits="Web.user.Train.TrainCreateOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=320,maximum-scale=1.3,user-scalable=no" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/layer.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="piaodatetxt" />
        <input type="hidden" runat="server" id="trancodetxt" />
        <input type="hidden" runat="server" id="starttimetxt" />
        <input type="hidden" runat="server" id="startstationnametxt" />
        <input type="hidden" runat="server" id="arrivetimetxt" />
        <input type="hidden" runat="server" id="endstationnametxt" />
        <input type="hidden" runat="server" id="runtimetxt" />
        <input type="hidden" runat="server" id="zwpricetxt" />
        <input type="hidden" runat="server" id="formcode" />
        <input type="hidden" runat="server" id="endcode" />
        <input type="hidden" runat="server" id="arry" />
        <input type="hidden" runat="server" id="money" />
        <input type="hidden" runat="server" id="uid" />
        <input type="hidden" runat="server" id="isbaoxian" />
    </form>
    <div class="jpbox" id="orderMain">
        <div class="rq-hb">
            <p id="info"><%=piaodate%> 车次:<%=trancode%></p>
        </div>
        <div class="sj">
            <div class="cf-time">
                <p id="statime" class="time"><%=starttime%></p>
                <p id="startstationname"><%=startstationname%></p>
            </div>
            <div class="trainsk"></div>
            <div class="dd-time">
                <p id="arytime" class="time"><%=arrivetime%></p>
                <p id="endstationname"><%=endstationname%></p>
            </div>
            <div class="fj alc">耗时<%=runtime%>钟</div>
        </div>
        <div id="divpassengers">
            <div class="person">
                <ul>
                    <li>
                        <div class="zx_t">座席</div>
                        <div class="sel_wrap">
                            <span id="seattype"><%=zwprice%></span>
                            <select name="ddlseattype" id="ddlseattype" class="selectzw Jsselect" autocomplete="off">
                                <option value="<%=zwprice%>"><%=zwprice%></option>
                               
                            </select>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="person" id="passenger">
                <ul >
                    <li>
                        <div class="cjr">乘客</div>
                       <%-- <div class="zj-cjr"></div>--%>
                    </li>
                </ul>
                <ul class="passengerinfo">
                    <li class="deletepassenger" style="display:none"><div class="cjr"></div><div class="sc-cjr"><a>删除乘客</a></div></li>
                    <li><span class="xm">姓名:</span><span class="xm-inp"><input class="name" name="" type="text"/></span></li>
                    <li>
                        <span class="ck_typet" style="border-right: 1px solid #ccc">乘客类型:</span>
                        <span class="ck_type">
                            <div class="sel_wrap">
                                <span class="passengertype">成人</span>
                                <select name="ddlpassenger" id="ddlpassenger" class="selectpaio Jsselect">
                                    <option value="1">成人票</option>
                                    <option value="2">儿童票</option>
                                    <option value="4">残军票</option>
                                </select>
                            </div>
                        </span>
                       <%-- <span class="xm">姓名:</span><span class="xm-inp"><input class="name" name="" value="" type="text"/></span>--%>
                    </li>
                    <li>
                        <span class="zj" style="border-right: 1px solid #ccc">
                            <div class="sel_wrap">
                                <span>身份证</span>
                                <select name="ddlidcard" id="ddlidcard Jsselect" class="selectcard">
                                    <option value="1">二代身份证</option>
                <%--                    <option value="2">一代身份证</option>
                                    <option value="C">港澳通行证</option>
                                    <option value="B">护照</option>
                                    <option value="G">台湾通行证</option>--%>
                                </select>
                            </div>
                        </span>
                        <span class="zj-inp"><input class="idcardnumber" name="" type="text">
                            <input class="birthday" name="" type="hidden" value="" placeholder="请填写出生日期">
                        </span>
                        
                       <%-- <span class="zj-inp">
                            <input class="idcardnumber" name="" type="text" maxlength="18">
                            <input class="birthday" name="" type="hidden" value="" placeholder="请填写出生日期">
                        </span>--%>
                    </li>
                   <%-- <li>
                            <span class="xm">出生日期</span><span class="xm-inp"><input class="birthday" name="" type="text" value="" placeholder="  请填写出生日期"/></span>
                        </li>--%>
                    <li style="display:none">
                        <span class="xm">出生日期</span><span class="xm-inp"></span>
                    </li>
                    <li>保险
                        	<span class="baoxian" style="float: right; width: 77%; border-left: 1px solid #ccc">
                                <div>
                                    <span class="bx">1份</span>
                                </div>
                            </span>
                    </li>
                    <div class="baoxian-mx">
                        <ul>
                            <li>
                                <span class="zj" style="border-right: 1px solid #ccc">保险产品</span>
                                <span class="ck_type">
                                    <div class="sel_wrap">
                                        <span class="insurance" style="font-size: 12px">I旅行火车意外险A款(5.00元)</span>
                                        <select name="ddlInsurance" id="ddlInsurance" class="selectinsuranceproduct insuranceproduct Jsselect" autocomplete="off">
                                           <%-- <option value="0">无</option>--%>
                                            <option value="1">I旅行火车意外险A款(5.00元)</option>
                                        </select>
                                    </div>
                                </span>
                            </li>
                            <li>
                                <span class="bxms"><a>保险产品描述</a></span>
                            </li>
                            <li>性别
                                	<span class="sex" style="float: right; width: 77%; border-left: 1px solid #ccc">
                                        <div class="sel_wrap">
                                            <span class="sex">男</span>
                                            <select name="ddlsex" id="ddlsex" class="selectsex Jsselect" autocomplete="off">
                                                <option value="M">男</option>
                                                <option value="F">女</option>
                                            </select>
                                        </div>
                                    </span>
                            </li>
                            <li style="diplay: none;"><span class="phone">手机号码</span><div class="phone-inp">
                                <input name="txtInsuranceMobile" type="text" class="phonenum" id="txtInsuranceMobile" maxlength="11" /></div>
                            </li>
                        </ul>
                    </div>
                </ul>
                <ul id="passhead">
				        <li><div class="cjr"></div><div class="zj-cjr"><a onclick="copypassenger()">增加乘客</a></div></li>
				    </ul>
            </div>
        </div>
        <div class="contact">
            <ul>
                <li>
                    <div class="shouji">联系人</div>
                    <div class="shouji-inp">
                        <input name="" type="text" id="usercode" placeholder="请填写联系人姓名" value="" />
                    </div>
                </li>
                <li>
                    <div class="shouji">
                        联系手机
                    </div>
                    <div class="shouji-inp">
                        <input name="" type="text" id="linkphone" placeholder="请填写联系人手机号码" value="" maxlength="11" />
                    </div>
                </li>
            </ul>
        </div>
        <div class="zongjin mb">
            总金额：￥<span class="jine" id="span_priceinfo"></span>
        </div>
        <div class="btn-block">
            <a href="#" onclick="SubmitOrder()">提交订单</a>
        </div>
        <div style="height: 15px;"></div>
    </div>
    <script type="text/javascript">
        var price = $("#ddlseattype").val().split('￥')[1]
        var zwcode = zw($("#ddlseattype").val().split('￥')[0]);
        var zwname = $("#ddlseattype").val().split('￥')[0];
        var bx = 5; //初始保险费用
        var htmlval = '';
        $(document).ready(function () {

            $("#span_priceinfo").html($("#ddlseattype").val().split('￥')[1])
            var arry = $("#arry").val().split(',');
            $.each(arry, function () {
                if ($("#zwpricetxt").val() == this) {
                    $("#ddlseattype").append("<option value='" + this + "' selected='selected'>" + this + "</option>");
                } else {
                    $("#ddlseattype").append("<option value='" + this + "'>" + this + "</option>");
                }
            });
            //保险处理
            if ($("#isbaoxian").val() == "0") {
                $("#span_priceinfo").html(parseFloat($("#span_priceinfo").html()) + bx)
                $(".selectinsuranceproduct").append("<option value='0'>无</option>");

            } else if ($("#isbaoxian").val() == "1") {
                $(".bx").html(1 + "份");
                $("#span_priceinfo").html(parseFloat($("#span_priceinfo").html()) + bx)
            }
            //				$(".Jsselect").change(function() {
            $("body").on("change", $(".Jsselect"), function (e) {
                $(e.target).prev().html($(e.target).find("option:selected").html());
                if ($(e.target).attr('class') == "selectzw Jsselect") {
                    $("#span_priceinfo").html($(e.target).find("option:selected").html().split('￥')[1])
                }
            });

            //				$(".selectinsuranceproduct").change(function() {
            $("body").on("change", $(".selectinsuranceproduct"), function (e) {
                if ($(e.target).val() == 1) {
                    $("#span_priceinfo").html(parseFloat($("#span_priceinfo").html()) + bx)
                    $(".bx").eq($(".selectinsuranceproduct").index(e.target)).html(1 + "份");
                } else if ($(e.target).val() == 0) {
                    $("#span_priceinfo").html(parseFloat($("#span_priceinfo").html()) - bx)
                    $(".bx").eq($(".selectinsuranceproduct").index(e.target)).html(0 + "份");
                }
            });

            //处理出生日期
            //				$(".idcardnumber").change(function() {
            $("body").on("change", $(".idcardnumber"), function (e) {
                var str = $(e.target).val().substring(0, 14)
                var b = str.substr(6, 8);
                var y = b.substr(0, 4)
                var m = b.substr(4, 2)
                var d = b.substr(6, 2)
                var bra = y + "-" + m + "-" + d
                $(e.target).next().val(bra);
            });


            htmlval = "<ul class='passengerinfo'>" + $(".passengerinfo").html();
            htmlval += "</ul>"
        })

        function copypassenger() {
            $("#passhead").before(htmlval);

            $("#span_priceinfo").html(parseFloat($("#span_priceinfo").html()) + parseFloat(price) + bx)

            $(".deletepassenger").show();
            $(".sc-cjr").off('click').on('click', function () {
                $(this).parents(".passengerinfo").remove();
                var num = $(".passengerinfo").size()
                if ($(".deletepassenger").length > 1) {
                    $(".deletepassenger").show();
                } else if ($(".deletepassenger").length == 1) {
                    $(".deletepassenger").hide();
                }
                $("#span_priceinfo").html(price * num + num * bx)
            });
        }

        function datefrmat(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            m = m < 10 ? ('0' + m) : m;
            var d = date.getDate();
            d = d < 10 ? ('0' + d) : d;
            var h = date.getHours();
            var minute = date.getMinutes();
            minute = minute < 10 ? ('0' + minute) : minute;
            return y + '' + m + '' + d + '' + h + '' + minute;
        };

        function SubmitOrder() {
            var price = parseFloat($("#span_priceinfo").html());
            var allmoney = parseFloat($("#money").val());

            if (price <= allmoney) {
                var nowdate = new Date()
                var order = 'ZX' + datefrmat(nowdate);
                var passengers = "[";
                var city = "南宁";
                //alert($("#ddlseattype").val())
                var startstationname = $("#startstationnametxt").val();
                var endstationname = $("#endstationnametxt").val();
                var FromStationDate = $("#info").html().split('车次')[0] + " " + $("#statime").html();
                var ToStationDate = $("#info").html().split('车次')[0] + " " + $("#arytime").html();
                var count = $(".passengerinfo").size()

                var orderinfo = "["
                for (var i = 0; i < count; i++) {
                    if ($.trim($(".name").eq(i).val()) == "") {
                        alert('请输入姓名');
                        return;
                    }
                    if ($.trim($(".phonenum").eq(i).val()) == "") {
                        alert('请输入手机号码');
                        return;
                    }
                    if ($.trim($(".idcardnumber").eq(i).val()) == "") {
                        alert('请输入身份证');
                        return;
                    }
                    var insurance;
                    console.log($(".selectinsuranceproduct").eq(i).find("option:selected").val())
                    if ($(".selectinsuranceproduct").eq(i).find("option:selected").val() > 0) {
                        insurance = ",\"insurance\":{\"name\":\"" + $(".name").eq(i).val() + "\",\"mobile\":\"" + $(".phonenum").eq(i).val() + "\",\"gender\":\"" + $(".selectsex").eq(i).find("option:selected").val() + "\",\"birth\":\"" + $(".birthday").eq(i).val() + "\",\"city\":\"" + city + "\",\"idcard\":\"" + $(".idcardnumber").eq(i).val() + "\"}"
                    } else {
                        insurance = ",\"insurance\":{}";
                    }
                    passengers += "{\"passengerid\":" + (i + 1) + ",\"passengersename\":\"" + $(".name").eq(i).val() + "\",\"piaotype\":" + $(".selectpaio").eq(i).val() + ",\"piaotypename\":\"" + $(".selectpaio").eq(i).find("option:selected").text() + "\",\"passporttypeseid\":" + $(".selectcard").eq(i).val() + ",\"passporttypeseidname\":\"" + $(".selectcard").eq(i).find("option:selected").text() + "\",\"passportseno\":\"" + $(".idcardnumber").eq(i).val() + "\",\"price\":\"" + $("#ddlseattype").val().split('￥')[1] + "\",\"zwcode\":\"" + zwcode + "\",\"zwname\":\"" + zwname + "\"";
                    orderinfo += "{\"name\":\"" + $(".name").eq(i).val() + "(" + $(".selectpaio").eq(i).find("option:selected").text() + ")\",\"idcard\":\"" + $(".idcardnumber").eq(i).val() + "\"}"
                    if (insurance != "") {
                        passengers += insurance
                    }
                    if (i < count - 1) {
                        passengers += "},";
                        orderinfo += ",";
                    } else {
                        passengers += "}";
                        orderinfo += "";
                    }

                }
                orderinfo += "]";
                passengers += "]";
                $.ajax({
                    url: "/APPService/TrainTickets.ashx?act=submit&LinkMan=" + $("#usercode").val() + "&LinkPhone=" + $("#linkphone").val() + "&UserID=" + $("#uid").val() + "&allprice=" + price + "&user_orderid=" + order + "&FromStationName=" + startstationname + "&ToStationName=" + endstationname + "&FromStationDate=" + FromStationDate + "&ToStationDate=" + ToStationDate + "&train_date=" + $("#piaodatetxt").val() + "&is_accept_standing=yes&from_station_code=" + $("#formcode").val() + "&to_station_code=" + $("#endcode").val() + "&checi=" + $("#trancodetxt").val() + "&passengers=" + passengers,
                    type: 'post',
                    dataType: 'json',
                    beforeSend: function () {
                        layer.load();
                    },
                    complete: function () {
                        layer.closeAll('loading');
                    },
                    success: function (msg) {
                        layer.closeAll('loading');

                        if (msg.state == "error") {
                            var mm = msg.data.split('：');
                            if (mm.length > 1)
                                alert(mm[1]);
                            else {
                                if (mm.indexOf('passportseno') > 0) {
                                    alert('输入的身份证号不合理');
                                    return;
                                } else if (mm.indexOf('mobile') > 0) {
                                    alert('请输入正确的手机号码');
                                    return;
                                } else if (mm.indexOf('birth') > 0) {
                                    alert('请输入正确的身份证号');
                                    return;
                                }
                                alert(msg.data)
                            }
                        } else if (msg.state == "success") {
                            var pams = [];
                            var datajson = eval('(' + msg.data + ')');
                            pams.push($('<input>', {
                                name: 'ordercode',
                                value: datajson.result.orderid
                            }));
                            $('<form> ', {
                                method: 'post',
                                action: 'TrainOrderDetail.aspx'
                            }).append(pams).appendTo("body").submit();
                        }

                    },
                    error: function () {

                        alert("提交异常！");
                    }
                })

            } else {
                alert("余额不足！");
            }

        }

        function zw(code) {
            var st
            switch (code) {
                case "硬座":
                    st = "1";
                    break;
                case "软座":
                    st = "2";
                    break;
                case "硬卧":
                    st = "3";
                    break;
                case "软卧":
                    st = "4";
                    break;
                case "高级软卧":
                    st = "6";
                    break;
                case "二等座":
                    st = "O";
                    break;
                case "一等座":
                    st = "M";
                    break;
                case "特等座":
                    st = "P";
                    break;
                case "商务座":
                    st = "9";
                    break;
            }
            return st;
        }
		</script>
</body>
</html>
