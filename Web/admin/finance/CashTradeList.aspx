<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashTradeList.aspx.cs" Inherits="Web.admin.finance.CashTradeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>交易列表</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">交易列表查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">订单编号:</label>
                                <asp:TextBox ID="txtOrderCode" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">下订日期:</label>
                                <asp:TextBox ID="txtStart" tip="输入下订日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入下订日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="lbtnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr class=" ">
                                <th style="min-width: 80px;" class="text-center">订单编号</th>
                                <th style="min-width: 80px;" class="text-center">卖家编号</th>
                                <th style="min-width: 80px;" class="text-center">买家编号</th>
                                <th style="min-width: 80px;" class="text-center">订单金额</th>
                                <%--<th style="min-width: 80px;">商品数量</th>--%>
                                <th style="min-width: 80px;"class="text-center">下订时间</th>
                                <th style="min-width: 80px;"class="text-center">付款时间</th>
                                <th style="min-width: 80px;"class="text-center">发货时间</th>
                                <th style="min-width: 80px;"class="text-center">订单状态</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" data-attr="订单编号">
                                        <a href="CashOrderDetail.aspx?OrderID=<%#Eval("OrderID")%>">
                                            <%# Eval("OrderCode")%>
                                    </td>
                                    <td align="center" data-attr="卖家编号">
                                        <%#userBLL.GetUserCode(long.Parse(Eval("SUserID").ToString()))%>
                                    </td>
                                    <td align="center" data-attr="买家编号">
                                        <%#userBLL.GetUserCode(long.Parse(Eval("BUserID").ToString()))%>
                                    </td>
                                    <td align="center" data-attr="商品价格">
                                        <%#Convert.ToDecimal(Eval("Amount")).ToString("0.00")%>
                                    </td>
                                   <%-- <td align="center" data-attr="商品数量">
                                        <%#Eval("Number")%>
                                    </td>--%>
                                    <td align="center" data-attr="下订时间">
                                        <%#Eval("OrderDate")%>
                                    </td>
                                    <td align="center" data-attr="付款时间">
                                        <%#Eval("PayDate")%>
                                    </td>
                                    <td align="center" data-attr="发货时间">
                                        <%#Eval("SendDate")%>
                                    </td>
                                    <td align="center" data-attr="订单状态">
                                        <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="9" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                         <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                  
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
