<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketQuery.aspx.cs" Inherits="Web.user.Ticket.TicketQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=320,maximum-scale=1.3,user-scalable=no" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title></title>
     <link rel="stylesheet" type="text/css" href="/css/date.css"/>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
</head>

<body>
<%--   <div class="ticket-con jsticketcon">
        <div style="text-align: center; line-height:80px;">
            敬请期待
        </div>
    </div>--%>

    <div class="ticket-tab" id="tickettab">
        <a href="javascript:;" class="active">单程</a>
       <%-- <a href="javascript:;">往返</a>--%>
    </div>
    <div class="ticket-con jsticketcon">
        <div class="ticket-chioce mb">
            <div class="ticket-group">
                <a href="javascript:;" class="from">出发城市</a>
                <a href="javascript:;" class="exchange"></a>
                <a href="javascript:;" class="arrive">到达城市</a>
            </div>
            <div class="ticket-date">
                <a href="javascript:;" class="calendar">
                    <span>去程日期</span>
                    <b></b>
                    <input type="hidden" value="" />
                </a>
            </div>
            <div class="ticket-date" style="display: none">
                <a href="javascript:;" class="calendar">
                    <span>返程日期</span>
                    <b></b>
                    <input type="hidden" value="" />
                </a>
            </div>
        </div>
        <div class="btn-block">
            <a href="javascript:;" onclick="Query()">机票查询</a>
        </div>
    </div>

    <div class="pop" style="display: none;" id="chiocecity">
        <div class="citypop">
            <a href="javascript:;" class="pop-close">关闭</a>
            <h1 class="pop-tit">选择城市</h1>
            <div class="ticket-tab">
                <a href="javascript:;" class="active">国内城市</a>
                <!--<a href="javascript:;">国际城市</a>-->
            </div>
            <div class="ticket-search">
                <input type="text" name="" id="" value="" placeholder="丹东/DDG/DD/DANDONG" />
                <input type="button" name="" value="取消" style="display: none;" />
            </div>
            <div class="ticket-citysearch" style="display: none;">
                <ul>
                    <li>广州 (GUANGZHOU)</li>
                    <li>广汉 (GUANGHAN)</li>
                </ul>
            </div>
            <div class="ticket-citylist" id="cityLetter">
                <div class="ticket-citylist-t jscitytit">热门</div>
                <div class="ticket-citylist-c jscity">
                    <ul class="clear">
                        <li onclick="oncity(this)">广州/CAN</li>
                        <li onclick="oncity(this)">成都/CTU</li>
                        <li onclick="oncity(this)">北京/BJS</li>
                        <li onclick="oncity(this)">上海/SHA</li>
                        <li onclick="oncity(this)">重庆/CKG</li>
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
    <input type="hidden" class="code" />
    <input type="hidden" class="code" />
    <script src="/JS/date.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript">
        var datatag = null;
        var citytag = null;
        var mindate = new Date().format("yyyy-MM-dd");
        $(document).ready(function () {
            var nowdate = new Date()
            $(".calendar b").html(datefrmat(nowdate))
        })
        function datefrmat(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            m = m < 10 ? ('0' + m) : m;
            var d = date.getDate();
            d = d < 10 ? ('0' + d) : d;
            return y
                + '-' + m + '-' + d;
        };
        function datefr(year, mony, day) {
            var y = year;
            var m = mony;
            m = m < 10 ? ('0' + m) : m;
            var d = day;
            d = d < 10 ? ('0' + d) : d;
            return y + '-' + m + '-' + d;
        };
        //单返切换
        $("#tickettab a").click(function () {
            $(this).addClass('active').siblings().removeClass('active');
            if ($(this).index() == 0) {
                $(".ticket-date").eq($(this).index()).css('display', 'block').siblings(".ticket-date").css('display', 'none');
            }
            if ($(this).index() == 1) {
                $(".ticket-date").eq($(this).index()).css('display', 'block').siblings(".ticket-date").css('display', 'block');
            }
        })

        ////唤起日期选择
        //$(".calendar").click(function () {
        //    $("#calendarchioce").show();
        //    datatag = $(this).find("b");
        //    $("#dp_wrapper a.ui_calendar_active").removeClass("ui_calendar_active");
        //    $("#" + datatag.attr("data-id")).addClass("ui_calendar_active");
        //});

        ////选择日期
        //$(".ui_calendar_day").click(function () {
        //    var aDate = this.id.substr(2).split("-");
        //    datatag.html(datefr(aDate[0], aDate[1], aDate[2])).attr("data-id", this.id);
        //    $("#calendarchioce").hide();
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
                    url: "/APPService/Ticket.ashx?act=QueryCity&query=" + strwhere + "&str=" + $(this).text(),
                    type: 'post',
                    dataType: 'json',
                    success: function (data) {
                        var htm = "<ul class='clear'>";
                        for (var i = 0; i < data.length; i++) {
                            htm += "<li onclick='oncity(this,\"" + data[i].name + "\",\"" + data[i].code + "\")'>" + data[i].city + "/" + data[i].code + "</li>"
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
        function oncity(doc, city, code) {
            citytag.html(doc.innerHTML);
            $("#chiocecity").hide();
        }
        $(".exchange").click(function () {
            var str = $(this).prev().html();
            $(this).prev().html($(this).next().html());
            $(this).next().html(str);
        });
        function Query() {
            if ($(".from").html() == "出发城市") {
                alert("请选择出发城市");
                return;
            }
            if ($(".arrive").html() == "到达城市") {
                alert("请选择到达城市");
                return;
            }
            var tag = $("#tickettab").children(".active")
            var pams = [];
            pams.push($("<input>", { name: 'formcityname', value: $(".from").html().split('/')[0], type:"hidden" }));
            pams.push($("<input>", { name: 'tocityname', value: $(".arrive").html().split('/')[0], type: "hidden"}));
            pams.push($("<input>", { name: 'type', value: tag.html(), type: "hidden" }));
            pams.push($("<input>", { name: 'fromtime', value: $(".calendar b").eq(0).html(), type: "hidden"}));
            pams.push($("<input>", { name: 'tomtime', value: $(".calendar b").eq(1).html(), type: "hidden"}));
            pams.push($("<input>", { name: 'fromcode', value: $(".from").html().split('/')[1], type: "hidden"}));
            pams.push($("<input>", { name: 'tocode', value: $(".arrive").html().split('/')[1], type: "hidden"}));
            $("<form>", {
                method: 'post',
                action: 'TicketList.aspx'
            }).append(pams).appendTo("body").submit();


        }
        // 搜索输入
        $(".ticket-search input[type='text']").on("input", function () {
            $(".ticket-citysearch").show();
            $(".ticket-citylist").hide();
            $(".ticket-search").addClass('search');
            if (this.value == " " || !this.value.length) {
                return false;
            }
            var strwhere = "city like '%" + this.value + "%'"
            $.ajax({
                url: "/APPService/Ticket.ashx?act=QueryCity&query=" + strwhere + "&str=" + this.value,
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    var htm = "<ul class='clear'>";
                    for (var i = 0; i < data.length; i++) {
                        htm += "<li onclick='oncity(this)'>" + data[i].city + "/" + data[i].code + "</li>"
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
    </script>
</body>

</html>
