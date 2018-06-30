<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainOrderList.aspx.cs" Inherits="Web.user.Train.TrainOrderList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=320,maximum-scale=1.3,user-scalable=no" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
    <form id="formmain" runat="server">
        <div class="orderlist-tab">
            <asp:LinkButton runat="server" ID="all" OnClick="all_Click" CssClass="active">全部</asp:LinkButton>
            <asp:LinkButton runat="server" ID="nopay" OnClick="nopay_Click">未支付</asp:LinkButton>
            <asp:LinkButton runat="server" ID="dpay" OnClick="dpay_Click">出票中</asp:LinkButton>
            <asp:LinkButton runat="server" ID="ypayt" OnClick="ypayt_Click">已出票</asp:LinkButton>
            
        </div>

        <div class="orderlist-lists">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <a href="TrainOrderDetail.aspx?ordercode=<%#Eval("OrderID")%>">
                        <div class="orderlist-li">
                            <div class="orderlist-time">下单时间：<%# Eval("TrainDate")%></div>
                            <div class="orderlist-info">
                                <div class="clear">
                                    <div class="orderlist-l">
                                        <span class="city"><%# Eval("FromStationName")%></span>
                                        <span class="time"><%# Eval("FromStationDate")%></span>
                                    </div>
                                    <div class="orderlist-c">
                                        <span class="train"><%# Eval("CheCi")%></span>
                                    </div>
                                    <div class="orderlist-r">
                                        <span class="city"><%# Eval("ToStationName")%></span>
                                        <span class="time"><%# Eval("ToStationDate")%></span>
                                    </div>
                                </div>
                                <div class="clear">
                                    <span class="people"><%# Eval("LinkMan")%></span>
                                    <span class="type"><%# States(Eval("State").ToString())%></span>
                                </div>
                            </div>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $(".orderlist-tab").children().click(function () {
                $(".orderlist-tab").children().removeClass("active")
                $(this).addClass("active")
              
            })
        })
    </script>--%>
</body>
</html>
