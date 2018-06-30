<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketOrderList.aspx.cs" Inherits="Web.admin.order.TicketOrderList" %>

<!DOCTYPE html>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单列表</title>
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
                    <h4 class="panel-title">列表查询</h4>
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
                            <div class="form-group mt10">
                                飞机票余额：<asp:Label runat="server" ID="banlcenmoney"></asp:Label>
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
                                <th style="min-width: 80px;" class="text-center">订票人编号</th>
                                <th style="min-width: 100px;" class="text-center">下订时间</th>
                                <th style="min-width: 80px;" class="text-center">航班号</th>
                                <th style="min-width: 80px;" class="text-center">起始站</th>
                                <th style="min-width: 100px;" class="text-center">起始时间</th>
                                <th style="min-width: 80px;" class="text-center">终点站</th>
                                <th style="min-width: 100px;" class="text-center">达到时间</th>
                                <%--<th style="min-width: 80px;" class="text-center">起飞航站楼</th>
                                <th style="min-width: 80px;" class="text-center">到达航站楼</th>
                                <th style="min-width: 80px;" class="text-center">仓位代码</th>--%>
                                <th style="min-width: 80px;" class="text-center">Y仓价格</th>
                                <th style="min-width: 80px;" class="text-center">仓位折扣</th>
                                <th style="min-width: 80px;" class="text-center">支付金额</th>
                                <th style="min-width: 80px;" class="text-center">税费合计</th>
                                <th style="min-width: 80px;" class="text-center">票价合计</th>
                                <th style="min-width: 80px;" class="text-center">保费合计</th>
                                <%--<th style="min-width: 80px;" class="text-center">邮寄费用</th>
                                <th style="min-width: 80px;" class="text-center">优惠抵扣金额</th>--%>
                                <th style="min-width: 80px;" class="text-center">联系人</th>
                                <th style="min-width: 80px;" class="text-center">联系人电话</th>
                                <th style="min-width: 80px;" class="text-center">状态</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" data-attr="订单编号">
                                        <a href="TicketOrderDetail.aspx?OrderID=<%#Eval("ID")%>">
                                            <%# Eval("OrdeID")%>
                                    </td>
                                    <td align="center" data-attr="订票人编号">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td align="center" data-attr="下订时间">
                                        <%#Eval("AddDate")%>
                                    </td>
                                    <td align="center" data-attr="航班号">
                                        <%#Eval("AirName")%>
                                    </td>
                                    <td align="center" data-attr="起始站">
                                        <%#Eval("DepcityName")%>
                                    </td>
                                    <td align="center"  data-attr="起始时间">
                                        <%#Eval("DepTime")%>
                                    </td>
                                    <td align="center" data-attr="终点站">
                                        <%#Eval("ArrcityName")%>
                                    </td>
                                    <td align="center" data-attr="达到时间">
                                        <%#Eval("ArrTime")%>
                                    </td>
                             <%--       <td align="center" data-attr="起飞航站楼">
                                        <%#Eval("Depterminal")%>
                                    </td>
                                    <td align="center" data-attr="到达航站楼">
                                        <%#Eval("Arrterminal")%>
                                    </td>
                                    <td align="center" data-attr="仓位代码">
                                        <%#Eval("Cabin")%>
                                    </td>--%>
                                    <td align="center" data-attr="Y仓价格">
                                        <%#Eval("YPrice")%>
                                    </td>
                                    <td align="center" data-attr="仓位折扣">
                                        <%#Eval("Discount")%>
                                    </td>
                                      <td align="center" data-attr="支付金额">
                                        <%#Eval("PayPrice")%>
                                    </td>
                                    <td align="center" data-attr="税费合计">
                                        <%#Eval("Totaltax")%>
                                    </td>
                                    <td align="center" data-attr="票价合计">
                                        <%#Eval("TicketPrice")%>
                                    </td>
                                    <td align="center" data-attr="保费合计">
                                        <%#Eval("InsurancePrice")%>
                                    </td>
                                 <%--   <td align="center" data-attr="邮寄费用">
                                        <%#Eval("PostPrice")%>
                                    </td>
                                     <td align="center" data-attr="优惠抵扣金额">
                                        <%#Eval("CouponPrice")%>
                                    </td>--%>
                                      <td align="center" data-attr="联系人">
                                        <%#Eval("LinkMan")%>
                                    </td>
                                      <td align="center" data-attr="联系人电话">
                                        <%#Eval("LinkMobile")%>
                                    </td>
                                    <td align="center" data-attr="订单状态">
                                        <%#Status(Eval("Status").ToString())%>
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

