<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="dl_JournalAccount.aspx.cs" Inherits="Web.user.finance.dl_JournalAccount" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
   <%-- <div class="content-page">--%>
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-custom">
                                    <asp:Literal ID="LitEmoney" runat="server"></asp:Literal></h2>
                                <h5>奖金积分</h5>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-pink">
                                    <asp:Literal ID="LitBonusAccount" runat="server"></asp:Literal></h2>
                                <h5>电子积分</h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-pink">
                                    <asp:Literal ID="LitStockMoney" runat="server"></asp:Literal></h2>
                                <h5>消费积分</h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6" style="display:none">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning">
                                    <asp:Literal ID="LitStockAccount" runat="server"></asp:Literal></h2>
                                <h5>报单积分</h5>
                            </div>
                        </div>
                    </div> 
                         <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning">
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></h2>
                                <h5>报单积分</h5>
                            </div>
                        </div>
                    </div> 
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2>
                                    <asp:Button ID="btnDetail" runat="server" class="btn btn-sm btn-custom " OnClick="btnDetail_Click" />
                                </h2>
                                <h5><%=GetLanguage("account") %><%--我的账户--%></h5>
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
                                                    <th><%=GetLanguage("BusinessSummary")%><%--业务摘要--%></th>
                                                    <th><%=GetLanguage("Operation") %><%--操作类型--%><%--币种--%></th>
                                                    <th><%=GetLanguage("AccountTypes")%><%--账户类型--%></th>
                                                    <th><%=GetLanguage("AccountAmount")%><%--账目金额--%></th>
                                                    <th><%=GetLanguage("TheBalanceOf")%><%--余额--%></th>
                                                    <th><%=GetLanguage("Date")%><%--日期--%></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td data-title="业务摘要">
                                                                <%if (Language == "zh-cn") %>
                                                                <%{ %>
                                                                <%#Eval("Remark")%><%-- 详情--%>
                                                                <%}
                                                                    else
                                                                    { %>
                                                                <%#Eval("Remarken")%><%-- 详情--%>
                                                                <%} %>
                                                            </td>
                                                            <td data-title="账户类型">
                                                                <%#AccountType(Eval("InAmount").ToString())%>
                                                            </td>
                                                            <td data-title="操作类型">
                                                                <%#OpeanType(Eval("JournalType").ToString())%>
                                                            </td>

                                                            <td data-title="账目金额">
                                                                <%# decimal.Parse(Eval("InAmount").ToString()) == 0 ? Eval("OutAmount") : Eval("InAmount")%>
                                                            </td>
                                                            <td data-title="余额"><%#Eval("BalanceAmount")%></td>
                                                            <td data-title="日期"><%#Eval("JournalDate")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </tbody>
                                            <tr id="tr1" runat="server">
                                                <td colspan="6" class="colspan">
                                                    <div class="text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><%--抱歉！目前数据库中暂无记录显示--%></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                                                  NumericButtonCount="3" PageSize="12"  
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"   PagingButtonSpacing="0" CurrentPageButtonClass ="active"
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

      
   <%-- </div>--%>
</asp:content>
