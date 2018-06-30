<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainOrderDetail.aspx.cs" Inherits="Web.admin.order.TrainOrderDetail" %>

<!DOCTYPE html>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-ok"  PostBackUrl="~/admin/order/TrainOrderList.aspx"> 返 回 </asp:LinkButton>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr class=" ">
                                <th style="min-width: 80px;" class="text-center">乘客姓名</th>
                                <th style="min-width: 80px;" class="text-center">票类型</th>
                                <th style="min-width: 80px;" class="text-center">证件类型</th>
                                <th style="min-width: 80px;"class="text-center">证件号码</th>
                                <th style="min-width: 80px;"class="text-center">票价</th>
                                <th style="min-width: 80px;"class="text-center">座位类型</th>
                                <th style="min-width: 80px;"class="text-center">座位号</th>
                                <th style="min-width: 80px;"class="text-center">是否购买保险</th>
                                 <th style="min-width: 80px;" class="text-center">手续费</th>
                                <th style="min-width: 80px;"class="text-center">出票状态</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" data-attr="乘客姓名">
                                        <%# Eval("PassengerseName")%>
                                    </td>
                                    <td align="center" data-attr="票类型">
                                        <%#Eval("PiaotypeName")%>
                                    </td>
                                    <td align="center" data-attr="证件类型">
                                        <%#Eval("PassporttypeseidName")%>
                                    </td>
                                    <td align="center" data-attr="证件号码">
                                        <%#Eval("PassportseNO")%>
                                    </td>
                                    <td align="center" data-attr="票价">
                                        <%#Eval("Price")%>
                                    </td>
                                    <td align="center" data-attr="座位类型">
                                        <%#Eval("ZWName")%>
                                    </td>
                                    <td align="center" data-attr="座位号">
                                        <%#Eval("cxin")%>
                                    </td>
                                      <td align="center" data-attr="是否购买保险">
                                        <%#Eval("InsuranceID").ToString()=="0"?"否":"是"%>
                                    </td>
                                     <td align="center" data-attr="手续费">
                                        <%#Eval("Disacount")%>
                                    </td>
                                    <td align="center" data-attr="出票状态">
                                        <%#Status(Eval("State").ToString())%>
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
