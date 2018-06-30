<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="TradingFloor.aspx.cs" Inherits="Web.user.Cash.TradingFloor" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
         <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
   
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="btn-group pull-right">
                                <a href="Cashsell.aspx" class="btn"><%=GetLanguage("CommissionedSell")%><%--委托卖出--%></a>
                                <a href="CashsellList.aspx" class="btn"><%=GetLanguage("SellRecords")%><%--卖出记录--%></a>
                                <a href="CashbuyList.aspx" class="btn"><%=GetLanguage("BuyRecords")%><%--购买记录--%></a>
                                <a href="Cashbuy.aspx" class="btn"><%=GetLanguage("More")%><%--更多--%></a>
                            </div>
                            <h4 class="header-title m-b-30">交易大厅</h4>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0">
                                            <thead>
                                                <tr>
                                                    <th><%=GetLanguage("Seller")%><%--卖家--%>
                                                    </th>
                                                   
                                                    <th><%=GetLanguage("CommodityInfo")%><%--商品信息--%>
                                                    </th>
                                                   <%-- <th><%=GetLanguage("Quantity")%><!--商品数量-->
                                                    </th>
                                                    <th><%=GetLanguage("CommodityPrices")%><!--商品单价-->
                                                    </th>--%>
                                                    <th><%=GetLanguage("GoodsAmount")%><%--商品金额--%>
                                                    </th>
                                                    <th ><%=GetLanguage("ResidualAmount")%><%--剩余金额--%>
                                                    </th>
                                                    <%--<th ><%=GetLanguage("QuantityArrival")%><!--到账数量-->
                                                    </th>--%>
                                                    <th><%=GetLanguage("EntrustmentDate")%><%--委托日期--%>
                                                    </th>
                                                    <th><%=GetLanguage("Operation")%><%--操作--%>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td  th-name='<%=GetLanguage("Seller")%>'>
                                                                <%# Eval("UserCode")%>
                                                            </td>
                                                           
                                                            <td  th-name='<%=GetLanguage("CommodityInfo")%>'>
                                                                <a href="CashbuyDetail.aspx?CashsellID=<%#Eval("CashsellID")%>">
                                                                    <%=GetLanguage("DetailsView")%></a>
                                                            </td>
                                                            <%--<td>
                                                                <%#Convert.ToDecimal(Eval("Number")) + Convert.ToDecimal(Eval("Charge"))%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Price")%>
                                                            </td>--%>
                                                            <td  th-name='<%=GetLanguage("GoodsAmount")%>'>
                                                                <%#Convert.ToDecimal(Eval("Amount")).ToString("0.00")%>
                                                            </td>
                                                            <td  th-name='<%=GetLanguage("PurchaseTime")%>'>
                                                                <%#(Convert.ToDecimal(Eval("Amount")) - Convert.ToDecimal(Eval("SaleNum"))).ToString("0.00")%>
                                                            </td>
                                                           <%-- <td>
                                                                <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold3") / 100)%>
                                                            </td>--%>
                                                            <td  th-name='<%=GetLanguage("EntrustmentDate")%>'>
                                                                <%#Eval("SellDate")%>
                                                            </td>
                                                            <td  th-name='<%=GetLanguage("Operation")%>'>
                                                                <asp:LinkButton ID="lbtnBuy" runat="server" CommandName="Buyinto" CommandArgument='<%#Eval("CashsellID") %>'
                                                                    class="btn" iconcls="icon-ok"><%=GetLanguage("Buy")%><%--购买--%></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="10" class="colspan">

                                                        <div class="form-control-static text-center">
                                                            <i class="fa fa-warning text-warning"></i>
                                                            <%=GetLanguage("Manager")%>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                        NumericButtonCount="3" PageSize="12"
                                        ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                        OnPageChanged="AspNetPager1_PageChanged">
                                    </webdiyer:AspNetPager>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End row -->

            </div>
            <!-- container -->

        </div>
        <!-- content -->
       
</asp:Content>
