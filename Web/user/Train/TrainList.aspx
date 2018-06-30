<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainList.aspx.cs" Inherits="Web.user.Train.TrainList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=320,maximum-scale=1.3,user-scalable=no" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>班次列表</title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
     <script src="/JS/layer.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>

    <div class="divflightList">
    </div>
    <div id="submitcontxt"></div>
    <%--<div class="divSelectHelper">
        <div><span class="sortprice"></span><span>航空公司</span></div>
        <div><span class="openpopup"></span><span>时间排序</span></div>
        <div><span class="sorttime"></span><span>价格排序</span></div>
    </div>--%>
    <form runat="server">

        <input type="hidden" runat="server" id="train_date" />
        <input type="hidden" runat="server" id="from_station" />
        <input type="hidden" runat="server" id="to_station" />

    </form>

    <script type="text/javascript">
        //根据价格找出最小的价格
        function selectionSort(arr) {

            var len = arr.length;
            var minIndex, temp;
            //选择排序法（从小到大）
            for (var i = 0; i < len - 1; i++) {
                minIndex = i;
                for (var j = i + 1; j < len; j++) {
                    if (arr[j] < arr[minIndex]) {     //寻找最小的数
                        minIndex = j;                 //将最小数的索引保存
                    }
                }
                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
            return arr[0];
        }
        $(document).ready(function () {
            $.ajax({
                url: "/APPService/TrainTickets.ashx?act=ticketsavailable&train_date=" + $("#train_date").val() + "&from_station=" + $("#from_station").val().split('/')[1] + "&to_station=" + $("#to_station").val().split('/')[1],
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
                        alert(msg.data);
                        //location.href ="TrainQuery.aspx"
                        window.history.back();
                    } else if (msg.state == "success") {
                        var jsondata = eval('(' + msg.data + ')');
                        var str = "";
                        for (var i = 0; i < jsondata.result.list.length; i++) {

                            var runtime = TimesStr(jsondata.result.list[i].run_time);//历时（转化）
                            var price = [jsondata.result.list[i].yz_price, jsondata.result.list[i].rz_price, jsondata.result.list[i].yw_price, jsondata.result.list[i].rw_price, jsondata.result.list[i].gjrw_price, jsondata.result.list[i].swz_price, jsondata.result.list[i].ydz_price, jsondata.result.list[i].edz_price, jsondata.result.list[i].wz_price, jsondata.result.list[i].tdz_price]
                            var pricestr = ["硬座￥", "软座￥", "硬卧￥", "软卧￥", "高级软卧￥", "商务座￥", "一等座￥", "二等座￥", "无座￥", "特等座￥"]
                            var arry = []
                            var arrystr = []
                            for (var t = 0; t < price.length; t++) {
                                if (price[t] > 0) {
                                    arry.unshift(price[t])//将数组为0的排除
                                    arrystr.unshift(pricestr[t] + price[t]);
                                }
                            }
                            var minprice = selectionSort(arry)
                            console.log(arrystr)
                            str += "<div class='flightItem'>"
                            str += "<div class='content' onclick= 'onhide(" + i + ")'>"
                            str += "<div class='list-icon list-icon1' id='con" + i + "' ></div>"
                            str += "<div class='train-lt'>"
                            str += "<div class='train-tit'> " + jsondata.result.list[i].train_code + "</div>"
                            str += "<span class='train-txim'> <b class='sx'>" + jsondata.result.list[i].start_time + "</b> <i>始</i>" + jsondata.result.list[i].start_station_name + "</span>"
                            str += "<span class='train-txim'> <b>" + jsondata.result.list[i].arrive_time + "</b><i>终</i>" + jsondata.result.list[i].end_station_name + "</span>"
                            str += "</div>"//---end train-lt---
                            str += "<div class='train-rt'>"
                            str += "<div class='price'>￥<b>" + minprice + "</b></div >"
                            str += "<span> " + runtime + "</span >"
                            str += "</div >"//--end train- rt---
                            str += "</div > ";//--end content---

                            str += "<div class='listdivsub train-listd' id='listicon1" + i + "' style='display:none'>"

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'> <span>硬座</span></div >"
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area' >"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].yz_price) + "</div >"
                            str += "</div >"//-- end listfr- area---
                            str += "<div class='listfr-input' >"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"硬座￥" + jsondata.result.list[i].yz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div >"//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>软座</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].rz_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"软座￥" + jsondata.result.list[i].rz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")'> 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>硬卧</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].yw_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"硬卧￥" + jsondata.result.list[i].yw_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>软卧</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].rw_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"软卧￥" + jsondata.result.list[i].rw_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>高级软卧</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].gjrw_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"高级软卧￥" + jsondata.result.list[i].gjrw_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>商务座</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].swz_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"商务座￥" + jsondata.result.list[i].swz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>一等座</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].ydz_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"一等座￥" + jsondata.result.list[i].ydz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>二等座</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].edz_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"二等座￥" + jsondata.result.list[i].edz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>无座</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].wz_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "','" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"无座￥" + jsondata.result.list[i].wz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "<div class='listdiv'>"
                            str += "<div class='listdivL'><span>特等座</span></div > "
                            str += "<div class='listdivR'>"
                            str += "<div class='listfr-area'>"
                            str += "<div class='fr-m'> <b style='font-size:14px'>￥</b>" + PriceHand(jsondata.result.list[i].tdz_price) + "</div >"
                            str += "</div > "//-- end listfr- area---
                            str += "<div class='listfr-input'>"
                            str += "<div class='InputArea' onclick= 'onSumit(\"" + jsondata.result.list[i].train_start_date + "\",\"" + jsondata.result.list[i].train_code + "\",\"" + jsondata.result.list[i].start_time + "\",\"" + jsondata.result.list[i].start_station_name + "\",\"" + jsondata.result.list[i].arrive_time + "\",\"" + jsondata.result.list[i].end_station_name + "\",\"" + runtime + "\",\"特等座￥" + jsondata.result.list[i].tdz_price + "\",\"" + jsondata.result.list[i].from_station_code + "\",\"" + jsondata.result.list[i].to_station_code + "\",\"" + arrystr + "\")' > 预订</div >"
                            str += "</div >"//-- end listfr- input---
                            str += "</div > "//-- end listdivR---
                            str += "</div > "//-- end listdiv---

                            str += "</div > "//-- end listdivsub train- listd---
                            str += "</div > ";//-- end flightItem---
                        }
                        //$(".divflightList").html(str);
                        $(".divflightList").hide();
                        $(".divflightList").html(str);
                        setTimeout($(".divflightList").show(), 2000);

                        //location.href = "TrainList.aspx?data=" + msg.data;
                    }
                },
                error: function () {
                    alert("查询异常！");
                }
            })
        })
        //历时处理
        function TimesStr(str) {
            var s = str.split(':')
            return s[0] + "时" + s[1] + "分"
        }
        //无票处理
        function PriceHand(price) {
            var str
            if (price == 0) {
                str = "无票";
            } else {
                str = price;
            }
            return str
        }
        function onhide(pag) {
            var tag = $("#con" + pag).parent().next();
            if (tag.css("display") == "none") {
                $(".listdivsub").hide();
                tag.show();
            } else {
                tag.hide();
            }
        }

        function onSumit(piaodate, trancode, starttime, startstationname, arrivetime, endstationname, runtime, zwprice, formcode, endcode, arry) {

            if (zwprice.split('￥')[1] == 0) {
                alert("没有票了")
            } else {

                var pams = [];
                pams.push($('<input>', { name: 'piaodate', value: piaodate, type: "hidden" }));
                pams.push($('<input>', { name: 'trancode', value: trancode, type: "hidden" }));
                pams.push($('<input>', { name: 'starttime', value: starttime, type: "hidden" }));
                pams.push($('<input>', { name: 'startstationname', value: $("#from_station").val().split('/')[0], type: "hidden" }));
                pams.push($('<input>', { name: 'arrivetime', value: arrivetime, type: "hidden" }));
                pams.push($('<input>', { name: 'endstationname', value: $("#to_station").val().split('/')[0], type: "hidden" }));
                pams.push($('<input>', { name: 'runtime', value: runtime, type: "hidden" }));
                pams.push($('<input>', { name: 'zwprice', value: zwprice, type: "hidden" }));
                pams.push($('<input>', { name: 'formcode', value: formcode, type: "hidden" }));
                pams.push($('<input>', { name: 'endcode', value: endcode, type: "hidden" }));
                pams.push($('<input>', { name: 'arry', value: arry, type: "hidden" }));
                $('<form>', {
                    method: 'post',
                    action: 'TrainCreateOrder.aspx'
                }).append(pams).appendTo("body").submit();
            }
            //location.href = "TrainCreateOrder.aspx?data={\"piaodate\":\"" + piaodate + "\",\"trancode\":\"" + trancode + "\",\"starttime\":\"" + starttime + "\",\"startstationname\":\"" + startstationname + "\",\"arrivetime\":\"" + arrivetime + "\",\"endstationname\":\"" + endstationname + "\",\"runtime\":\"" + runtime + "\",\"zwprice\":\"" + zwprice + "\"}";
        }
    </script>
</body>
</html>
