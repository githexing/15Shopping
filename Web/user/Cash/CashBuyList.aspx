<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CashbuyList.aspx.cs" Inherits="Web.user.Cash.CashbuyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("BuyRecords")%></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("ReleaseTime")%><!--发布时间--></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStart" tip="发布时间" class="form-control" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtStartEn" tip="Release time" class="form-control" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%></span>
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtEnd" tip="" runat="server" class="form-control" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEndEn" tip="Release time" class="form-control" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success btn-md" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0">
                                            <thead>
                                                <tr>
                                                    <th><%=GetLanguage("Buyers")%><%--买家--%>
                                                    </th>
                                                    <th><%=GetLanguage("Seller")%><%--卖家--%>
                                                    </th>
                                                    <th><%=GetLanguage("CommodityInfo")%><%--商品信息--%>
                                                    </th>
                                                    <%--<th><%=GetLanguage("SellCount")%><!--卖出数量-->
                                                    </th>
                                                    <th><%=GetLanguage("CommodityPrices")%><!--商品单价-->
                                                    </th>--%>
                                                    <th><%=GetLanguage("AmountOfPurchase")%><%--购买金额--%>
                                                    </th>
                                                    <%--<th><%=GetLanguage("QuantityPayment")%><!--付款数量-->
                                                    </th>
                                                    <th><%=GetLanguage("QuantityArrival")%><!--到账数量-->
                                                    </th>--%>
                                                    <th><%=GetLanguage("PurchaseTime")%><%--购买时间--%>
                                                    </th>
                                                    <th><%=GetLanguage("State")%><%--状态--%>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td th-name='<%=GetLanguage("Buyers")%>'>
                                                                <asp:Literal ID="ltBUserCode" runat="server"></asp:Literal>
                                                            </td>
                                                            <td th-name='<%=GetLanguage("Seller")%>'>
                                                                <asp:Literal ID="ltSUserCode" runat="server"></asp:Literal>
                                                            </td>
                                                          
                                                            <td th-name='<%=GetLanguage("CommodityInfo")%>'>
                                                                <a href="CashbuyDetail.aspx?CashsellID=<%#Eval("CashsellID")%>&CashbuyID=<%#Eval("CashbuyID")%>">
                                                                    <%=GetLanguage("DetailsView")%></a>
                                                            </td>
                                                           <%-- <td>
                                                                <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold2") / 100)%>
                                                            </td>--%>
                                                            <%--<td>
                                                                <%#Eval("Price")%>
                                                            </td>--%>
                                                            <td th-name='<%=GetLanguage("AmountOfPurchase")%>'>
                                                                <%#Eval("Amount")%>
                                                            </td>
                                                            <%--<td>
                                                                <%#Eval("Number")%>
                                                            </td>--%>
                                                            <%--<td>
                                                                <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold3") / 100)%>
                                                            </td>--%>
                                                            <td th-name='<%=GetLanguage("PurchaseTime")%>'>
                                                                <%#Eval("BuyDate")%>
                                                            </td>
                                                            <td th-name='<%=GetLanguage("State")%>'>
                                                                <asp:Literal ID="ltIsBuy" runat="server"></asp:Literal></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                  <td colspan="12" class="colspan">
                                                       <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i>
                                                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。-->
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
