<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashOrderList.aspx.cs" Inherits="Web.admin.cash.CashOrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>交易平台成交订单</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">交易平台成交订单查询</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">选择下拉:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropType" runat="server" class="width100p selectval mwidth168">
                                        <asp:ListItem Value="0">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">买家编号</asp:ListItem>
                                        <asp:ListItem Value="2">卖家编号</asp:ListItem>
                                        <asp:ListItem Value="3">交易订单</asp:ListItem>
                                        <asp:ListItem Value="4">买家订单</asp:ListItem>
                                        <asp:ListItem Value="5">卖家订单</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <input name="txtInput" id="txtInput" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">交易时间:</label>
                                <asp:TextBox ID="txtStart" tip="输入交易时间" runat="server" onfocus="WdatePicker()" CssClass="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入交易时间" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">订单编号</th>
                                <th style="min-width: 80px;">买家</th>
                                <th style="min-width: 80px;">买家订单</th>
                                <th style="min-width: 80px;">卖家</th>
                                <th style="min-width: 80px;">卖家订单</th>
                                <th style="min-width: 80px;">交易价格</th>
                                <th style="min-width: 80px;">交易数量</th>
                                <th style="min-width: 80px;">交易金额</th>
                                <th style="min-width: 80px;">交易时间</th>
                            </tr>
                        </thead>
                        <asp:Repeater runat="server" ID="Repeater1" >
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("OrderCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BuyUserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BuyOrderCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SellUserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SellOrderCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Price")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TradingNum")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Amount")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("OrderDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="9" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
