<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketList.aspx.cs" Inherits="Web.user.Ticket.TicketList" %>

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
    <div class="headerbg"><%=fromcityname %>飞往<%=tocityname %>(<%=type %>)</div>
    <div class="divflightList">
    
    </div>
    <div class="divSelectHelper" style="display">
        <div><span class="sortprice"></span><span>航空公司</span></div>
        <div><span class="openpopup"></span><span>时间排序</span></div>
        <div><span class="sorttime"></span><span>价格排序</span></div>
    </div>
    <form runat="server">

        <input type="hidden" runat="server" id="ticket_formdate" />
        <input type="hidden" runat="server" id="ticket_todate" />
        <input type="hidden" runat="server" id="from_code" />
        <input type="hidden" runat="server" id="to_code" />

    </form>
    <script type="text/javascript">
        //根据价格找出最小的价格
        function selectionSort(arr) {
            //var len = arr.length;
            //var minIndex, temp;
            
            arr.sort(function (a, b) {
                return a - b
            });
            //console.log("排序"+arr);
            //选择排序法（从小到大）
            //for (var i = 0; i < len - 1; i++) {
            //    minIndex = i;
            //    for (var j = i + 1; j < len; j++) {
            //        if (arr[j] < arr[minIndex]) {     //寻找最小的数
            //            minIndex = j;                 //将最小数的索引保存
            //        }
            //    }
            //    temp = arr[i];
            //    arr[i] = arr[minIndex];
            //    arr[minIndex] = temp;
            //}
            return arr[0];
        }
        $(document).ready(function () {
            //alert($("#ticket_formdate").val() + "---" + $("#from_code").val() + "---" + $("#to_code").val());
            $.ajax({
                url: "/APPService/Ticket.ashx?act=getfligtlistweb&action=getfligtlist&depdate=" + $("#ticket_formdate").val() + "&depcity=" + $("#from_code").val() + "&arrcity=" + $("#to_code").val() + "&aircode=",
                type: 'post',
                dataType: 'json',
                beforeSend: function () {
                    layer.load();
                },
                complete: function () {
                    layer.closeAll('loading');
                },
                success: function (msg) {
                    if (msg.state == "success") {
                        var jsondata = eval('(' + msg.data + ')');
                        var str = "";
                        var formname;//起飞机场
                        var toname;//到达机场
                        var begindate;//起飞时间
                        var zk;//折扣
                        var num;//数量
                        var formcode;
                        var tocode
                        var count = 0;
                        var i = 0;
                        
                        for (var obj in jsondata.result.P) {
                            if (count == 0) {
                                formname = jsondata.result.P[obj]
                                formcode = obj
                            }
                            if (count == 1) {
                                toname = jsondata.result.P[obj]
                                tocode = obj
                            }
                            count++;
                        }
                        count=1
                        if (jsondata.successcode == "T") {
                            //alert(jsondata.result.D.length);
                            if (jsondata.result.D.length == 0) {
                                alert("没有找到相关票数据");
                                window.history.back();
                            } else {
                                
                                for (var obj1 in jsondata.result.A) {
                                    for (var obj in jsondata.result.F) {
                                        if (obj.match(RegExp(obj1))) {

                                            for (var obj2 in jsondata.result.H) {
                                                if (obj == obj2) {
                                                    var arry = [];
                                                    for (var obj3 in jsondata.result.H[obj2]) {
                                                        arry.unshift(jsondata.result.H[obj2][obj3][0])
                                                    }
                                                }
                                            }
                                            //for (var vardate in jsondata.result.D) {
                                               
                                            //}
                                            begindate = jsondata.result.D[jsondata.result.F[obj][2]]
                                            // alert(begindate);
                                            console.log(begindate)
                                            i++;
                                            var minprice = selectionSort(arry);
                                            //console.log("最小值：" + minprice);
                                            str += "<div class='flightItem'>"
                                            str += "<div class='content' id='con" + i + "' onclick= 'onhide(" + i + ")'>"
                                            str += "<div class='list-icon list-icon1' ></div>"
                                            str += "<div class='listleft-icon'></div>"
                                            str += "<div class='clear'>"
                                            str += "<div class='fighlist-left'>"
                                            str += "<ul class='fl-area'>"
                                            str += "<li>"
                                            str += "<lable class='airco_HU'></lable>"
                                            str += "<span class='fl-tit'>" + jsondata.result.A[obj1] + obj + "</span></li>"
                                            str += "<li><span class='f16 cb fw'>" + jsondata.result.F[obj][3] + "</span> <span class='f14'>" + formname + "</span> </li>"
                                            str += "<li><span class='f14 c4 '>" + jsondata.result.F[obj][5] + "</span> <span class='f12'>" + toname + "</span> </li>"
                                            str += "</ul>"
                                            str += "</div>"
                                            str += "<div class='fighlist-right'>"
                                            str += "<ul class='fr-area'>"
                                            str += "<li><span class='fr-m'><b style='font-size: 14px'>￥</b>" + minprice + "</span></li>"
                                            //str += "<li><span class='lis'>" + num + "张</span><span class='fr-dz'>" + zk + "折</span></li>"
                                            str += "</ul>"
                                            str += "</div>"
                                            str += "</div>"
                                            str += "</div >"
                                            str += "<div class='listdivsub' style='display:none;'>"
                                            for (var obj2 in jsondata.result.H) {
                                                if (obj == obj2) {
                                                    for (var obj3 in jsondata.result.H[obj2]) {

                                                        str += "<div class='listdiv'>"
                                                        str += "<div class='listdivL'><span>" + jsondata.result.H[obj2][obj3][2] + "折</span><span>" + jsondata.result.H[obj2][obj3][9] + "</span></div>"
                                                        str += "<div class='listdivR'>"
                                                        str += "<div class='listfr-area'>"
                                                        str += "<div class='fr-m'><b style='font-size: 14px'>￥</b>" + jsondata.result.H[obj2][obj3][0] + "</div>"
                                                        str += "<div class='listfr-l'>&nbsp;" + jsondata.result.H[obj2][obj3][6] + "&nbsp;张</div>"
                                                        str += "</div>"
                                                        str += "<div class='listfr-input'>"
                                                        str += "<div class='InputArea'  onclick= 'onSumit(\"" + begindate + "\",\"" + jsondata.result.A[obj1] + obj + "\",\"" + jsondata.result.F[obj][3] + "\",\"" + formname + "\",\"" + jsondata.result.F[obj][5] + "\",\"" + toname + "\",\"" + jsondata.result.F[obj][6] + "\",\"" + jsondata.result.H[obj2][obj3][0] + "\",\"" + obj1 + "\",\"" + formcode + "\",\"" + tocode + "\",\"" + obj + "\",\"" + jsondata.result.F[obj][7] + "\",\"" + jsondata.result.H[obj2][obj3][1] + "\",\"" + jsondata.result.F[obj][15] + "\",\"" + jsondata.result.H[obj2][obj3][2] + "\",\"" + jsondata.result.F[obj][9] + "\",\"" + jsondata.result.F[obj][10] + "\",\"" + jsondata.result.F[obj][12] + "\",\"" + jsondata.result.F[obj][13] + "\",\"" + jsondata.result.H[obj2][obj3][4] + "\")'>预订</div>"
                                                        str += "</div>"
                                                        str += "</div>"
                                                        str += "</div>"
                                                    }
                                                }
                                            }
                                            str += "</div>"
                                            str += "</div>"
                                            str += "</div>"
                                        }
                                    }
                                }
                            }
                            //console.log(str);
                            count++
                            $(".divflightList").hide();
                            $(".divflightList").html(str);
                            setTimeout($(".divflightList").show(), 2000);
                           // var jsondataF = eval('(' + jsondata.result.F.FM9462 + ')');
                            //alert(jsondata.result.F(0)[0]);
                        } else {
                            alert("查询结果失败！");
                        }
                    } else {
                        alert("请求接口异常！");
                    }
                },
                error: function () {
                    alert("查询异常！");
                }
            })
            layer.load();
        })
        function onSumit(getdate, focde, formdate, fromdetial, todate, todetial, alltime, price, aircode, depcity, arrcity, flight, flightmodel, cabin, yprice, discount, depterminal, arrterminal, airportfee, fuelfee,staynum) {
            //alert()
            //console.log("机票日期" + getdate + ",航班：" + focde + ",起飞时间：" + formdate + ",起飞机场：" + fromdetial + ",到达时间：" + todate + ",到达机场：" + todetial + ",飞行时长：" + alltime + ",机票价格：" + price + ",私航代码：" + aircode + ",出发机场三字码：" + depcity + ",到达机三字码：" + arrcity + ",航班号：" + flight + ",机型：" + flightmodel + ",仓位代码：" + cabin + "，Y仓价格：" + yprice + ",折扣：" + discount + ",起飞航站楼：" + depterminal + ",到达航站楼：" + arrterminal + ",机建：" + airportfee + ",燃油：" + fuelfee + ",返点：" + staynum);
            console.log("起飞时间：" + formdate + "，到达时间：" + todate)
            var pams = [];
            pams.push($('<input>', { name: 'piaodate', value: getdate, type: "hidden" }));
            pams.push($('<input>', { name: 'ticketcode', value: focde, type: "hidden" }));
            pams.push($('<input>', { name: 'starttime', value: formdate, type: "hidden" }));
            pams.push($('<input>', { name: 'startstationname', value: fromdetial, type: "hidden" }));
            pams.push($('<input>', { name: 'arrivetime', value: todate, type: "hidden" }));
            pams.push($('<input>', { name: 'endstationname', value: todetial, type: "hidden" }));
            pams.push($('<input>', { name: 'alltime', value: alltime, type: "hidden" }));
            pams.push($('<input>', { name: 'price', value: price, type: "hidden" }));
            pams.push($('<input>', { name: 'aircode', value: aircode, type: "hidden" }));
            pams.push($('<input>', { name: 'depcity', value: depcity, type: "hidden" }));
            pams.push($('<input>', { name: 'arrcity', value: arrcity, type: "hidden" }));
            pams.push($('<input>', { name: 'flight', value: flight, type: "hidden" }));
            pams.push($('<input>', { name: 'flightmodel', value: flightmodel, type: "hidden" }));
            pams.push($('<input>', { name: 'cabin', value: cabin, type: "hidden" }));
            pams.push($('<input>', { name: 'yprice', value: yprice, type: "hidden" }));
            pams.push($('<input>', { name: 'discount', value: discount, type: "hidden" }));
            pams.push($('<input>', { name: 'depterminal', value: depterminal, type: "hidden" }));
            pams.push($('<input>', { name: 'arrterminal', value: arrterminal, type: "hidden" }));
            pams.push($('<input>', { name: 'airportfee', value: airportfee, type: "hidden" }));
            pams.push($('<input>', { name: 'fuelfee', value: fuelfee, type: "hidden" }));
            pams.push($('<input>', { name: 'staynum', value: staynum, type: "hidden" }));
            $("<form>", {
                method: 'post',
                action: 'TicketCreateOrder.aspx'
            }).append(pams).appendTo("body").submit();
            layer.load();
        }
        function onhide(pag) {
            var tag = $("#con" + pag).next();
            if (tag.css("display") == "none") {
                $(".listdivsub").hide();
                tag.show();
            } else {
                tag.hide();
            }
        }
        $(".list-icon1").click(function () {
            var tag = $(this).parent().next();
            if (tag.css("display") == "none") {
                $(".listdivsub").hide();
                tag.show();
            } else {
                tag.hide();
            }

        });
    </script>
</body>
</html>
