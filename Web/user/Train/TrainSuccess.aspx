<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainSuccess.aspx.cs" Inherits="Web.user.Train.TrainSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="succeed">
			<span class="tu"><img src="/images/suc.png"></span>
			<span class="zi">恭喜您，预订成功！</span>
		</div>
		<div class="tip">温馨提示：请在注意取票时间</div>
		<div class="dd-xq">
			<h3>订单详情</h3>
			<p>订单号：<span id="orderNo"><%=orderid %></span></p>
			<p>总价：<span id="totalPrice" class="jg">￥<%=price %></span></p>
			<p>发车时间：<%=orderdate %></p>
			<p>车  次   号：<%=checi %></p>
			<p>起始城市：<%=weizhi %></p>
		</div>
        <input type="hidden" id="uid" runat="server"/>
    </form>
    <div class="dt-pl">
			
			<div class="btn-block">
				<input type="submit" name="" value="查看订单列表" id="" class="button" onclick="onlist()">
			</div>
		</div>
    <script type="text/javascript">
        function onlist() {
            window.location.href = 'TrainOrderList.aspx?UserID=' + $("#uid").val()
        }
        
    </script>
</body>
</html>
