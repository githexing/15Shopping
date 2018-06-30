<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainQuery.aspx.cs" Inherits="Web.user.Train.TrainQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=320,maximum-scale=1.3,user-scalable=no" />
    <title>火车票查询</title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/css/date.css"/>
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
 <%--   <div class="ticket-con jsticketcon">
        <div style="text-align: center; line-height:80px;">
            敬请期待
        </div>
    </div>--%>
        <div class="ticket-con jsticketcon">
        <div class="ticket-chioce mb">
            <div class="ticket-group train">
                <a href="#" class="from">出发城市</a>
                <a href="#" class="exchange"></a>
                <a href="#" class="arrive">到达城市</a>
            </div>
            <div class="ticket-group">
                <a href="#" class="calendar">
                    <span>出发日期</span>
                    <b></b>
                    <input type="hidden" value="" />
                </a>
            </div>
            <%--<div class="ticket-group">
                <div class="trainnum">
                    <select id="" name="" class="src_sel">
                        <option value="0" selected="selected">不限车次</option>
                        <!--<option value="1">高铁/动车(G/D/C)</option>
	                        <option value="2">普通车次(K/T/Z)</option> -->
                    </select>
                </div>
            </div>--%>
            <%--<div class="ticket-group">
                <div class="trainposition">
                    <select id="" name="" class="src_sel">
                        <option value="0" selected="selected">不限座席</option>

                    </select>
                </div>
            </div>--%>
        </div>
        <div class="btn-block">
            <a href="#" onclick="Query()">火车票查询</a>
        </div>
    </div>
    <div class="pop" style="display: none;" id="chiocecity">
        <div class="citypop">
            <a href="javascript:;" class="pop-close">关闭</a>
            <h1 class="pop-tit">选择城市</h1>
            <div class="ticket-tab">
                <a href="#" class="active">国内城市</a>
                <!--<a href="#">国际城市</a>-->
            </div>
            <div class="ticket-search">
                <input type="text" name="" id="city" value="" placeholder="丹东/DDG/DD/DANDONG"  />
                <input type="button" name="" style="display: none;" value="取消" />
            </div>
            <div class="ticket-citysearch" style="display: none;">
               <%-- <ul>
                    <li>广州 (GUANGZHOU)</li>
                    <li>广汉 (GUANGHAN)</li>
                </ul>--%>
            </div>
            <div class="ticket-citylist" id="cityLetter">
                <div class="ticket-citylist-t jscitytit">热门</div>
                <div class="ticket-citylist-c jscity">
                    <ul class="clear">
                        <li onclick="oncity(this)">广州/GZQ</li>
                        <li onclick="oncity(this)">成都/BJP</li>
                        <li onclick="oncity(this)">北京/BJP</li>
                        <li onclick="oncity(this)">上海/SHH</li>
                        <li onclick="oncity(this)">重庆北/CUW</li>
                    </ul>
                </div>
                <div class="ticket-citylist-t jscitytit">ABCD</div>
                <div class="ticket-citylist-c jscity" style="display: none;">
                </div>
                <div class="ticket-citylist-t jscitytit">EFGHJ</div>
                <div class="ticket-citylist-c jscity" style="display: none;">
                </div>
                <div class="ticket-citylist-t jscitytit">KLMN</div>
                <div class="ticket-citylist-c jscity" style="display: none;">
                </div>
                <div class="ticket-citylist-t jscitytit">PQRSTW</div>
                <div class="ticket-citylist-c jscity" style="display: none;">
                </div>
                <div class="ticket-citylist-t jscitytit">XYZ</div>
                <div class="ticket-citylist-c jscity" style="display: none;">
                </div>
            </div>
        </div>
    </div>
    <script src="/JS/date.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript">

        var datatag = null;
        var citytag = null;
        var mindate = new Date().format("yyyy-MM-dd");
        $(document).ready(function () {
            var nowdate = new Date()
            $(".calendar b").html(datefrmat(nowdate))
        })
        //唤起日期选择
        //$(".calendar").click(function () {
        //    $("#calendarchioce").show();
        //    datatag = $(this).find("b");
        //    $("#dp_wrapper a.ui_calendar_active").removeClass("ui_calendar_active");
        //    $("#" + datatag.attr("data-id")).addClass("ui_calendar_active");
        //});
        $(".calendar").click(function () {
            var datatag = $(this).find("b");
            var datainput = $(this).find("input");
            var cal = datainput.datepicker({
                minDate: mindate,
                onPicked: function (date) {
                    datatag.html(date.format("yyyy-MM-dd"));
                    datainput.val(date);
                }
            });
            cal.show();
            if (!$("#calendarclose").length) {
                $("#dp_wrapper").prepend($("<div class=\"gray ac_result_tip\" style='z-index:9999;position:absolute'>选择日期<i id='calendarclose' class=\"returnico\"></i></div>"));
            }
            $("#calendarclose").click(function () {
                cal.close();
            })
        });
        ////选择日期
        //$(".ui_calendar_day").click(function () {
        //    var aDate = this.id.substr(2).split("-");
        //    datatag.html(datefr(aDate[0], aDate[1], aDate[2])).attr("data-id", this.id);
        //    $("#calendarchioce").hide();
        //});
        function datefrmat(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            m = m < 10 ? ('0' + m) : m;
            var d = date.getDate();
            d = d < 10 ? ('0' + d) : d;
            return y + '-' + m + '-' + d;
        };
        function datefr(year, mony, day) {
            var y = year;
            var m = mony;
            m = m < 10 ? ('0' + m) : m;
            var d = day;
            d = d < 10 ? ('0' + d) : d;
            return y + '-' + m + '-' + d;
        };
        //唤起城市选择
        $(".from,.arrive").click(function () {
            citytag = $(this);
            $("#chiocecity").show();
        });

        //关闭城市选择
        $(".pop-close").click(function () {
            $(this).parent().parent().hide();
        });

        //切换城市分类
        $(".jscitytit").click(function () {
            var tag = $(this).next();
            if (tag.css("display") == "none") {
                $(".jscity").hide();
                tag.show();
                var strwhere = "Code like '[" + $(this).text() + "]%'";
                $.ajax({
                    url: "/APPService/TrainTickets.ashx?act=QueryCity&query=" + strwhere + "&str=" + $(this).text(),
                    type: 'post',
                    dataType: 'json',
                    success: function (data) {
                        var htm = "<ul class='clear'>";
                        for (var i = 0; i < data.length; i++) {
                            htm += "<li onclick='oncity(this)'>" + data[i].name + "/" + data[i].code + "</li>"
                        }
                        htm += "</ul>"
                        tag.html(htm)
                    },
                    error: function () {
                        alert("查询异常！");
                    }
                })
            } else {
                $(".jscity").hide();
                tag.hide();
            }
        });
        //选择城市
        function oncity(city) {
            citytag.html(city.innerHTML);
            $("#chiocecity").hide();
            $("#city").val();
        }


        $(".exchange").click(function () {
            var str = $(this).prev().html();
            $(this).prev().html($(this).next().html());
            $(this).next().html(str);
            $("#city").val();
        });
        function Query() {
            if ($(".arrive").html() == "到达城市") {
                alert("请选择达到城市")
                return
            }
            if ($(".from").html() == "出发城市") {
                alert("请选择出发城市")
                return
            }
            location.href = "TrainList.aspx?train_date=" + $(".calendar b").html() + "&from_station=" + $(".from").html() + "&to_station=" + $(".arrive").html();

        }
        // 搜索输入
        $(".ticket-search input[type='text']").on("input", function () {
            $(".ticket-citysearch").show();
            $(".ticket-citylist").hide();
            $(".ticket-search").addClass('search');
            if (this.value == " " || !this.value.length){
                return false;
            }
            var strwhere = "Name like '%" + this.value + "%'"
            $.ajax({
                url: "/APPService/TrainTickets.ashx?act=QueryCity&query=" + strwhere + "&str=" + this.value,
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    var htm = "<ul class='clear'>";
                    for (var i = 0; i < data.length; i++) {
                        htm += "<li onclick='oncity(this)'>" + data[i].name + "/" + data[i].code + "</li>"
                    }
                    htm += "</ul>"
                    $(".ticket-citysearch").html(htm)
                },
                error: function () {
                    alert("查询异常！");
                }
            })
        });

        // 搜索取消
        $(".ticket-search input[type='button']").click(function () {
            $(".ticket-search input[type='text']").val("");
            $(".ticket-search").removeClass('search');
            $(".ticket-citysearch").hide();
            $(".ticket-citylist").show();
        });
        //function onchangecity(value) {
        //    var strwhere = "Name like '%" + value + "%'";
        //    var count = $(".jscitytit").size();
        //    //alert(count)
        //    $.ajax({
        //        url: "/APPService/TrainTickets.ashx?act=QueryCity&query=" + strwhere,
        //        type: 'post',
        //        dataType: 'json',
        //        success: function (data) {
        //            var htm = "<ul class='clear'>";
        //            for (var i = 0; i < data.length; i++) {
        //                htm += "<li onclick='oncity(this)'>" + data[i].name + "/" + data[i].code + "</li>"
                        
        //                for (var t = 0; t < count; t++) {
        //                    $(".jscity").eq(t).show();
        //                        $(".jscitytit").eq(t).next().show();
        //                        $(".jscitytit").eq(t).next().html(htm)
                           
        //                }
        //            }
        //            htm += "</ul>"
        //            //tag.html(htm)
        //        },
        //        error: function () {
        //            alert("查询异常！");
        //        }
        //    })
        //}
    </script>
</body>
</html>
