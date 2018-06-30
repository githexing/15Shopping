<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="dl_JournalEmoney.aspx.cs" Inherits="Web.user.finance.dl_JournalEmoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12 text-right m-b-10">
                        <a href="javascript:history.go(-1)" class="btn btn-sm btn-default"><i class="fa fa-mail-reply-all"></i><%=GetLanguage("Return") %><%--返回--%></a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("Query") %><%--查询--%></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("Date")%><%--开通日期--%></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStart" runat="server" class="form-control" name="start" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtStartEn" runat="server" class="form-control" name="start" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>

                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%><%--至--%></span>
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtEnd" runat="server" class="form-control" name="end" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEndEn" runat="server" class="form-control" name="end" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-success  btn-md" OnClick="btnSearch_Click" />

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
                                                    <th><%=GetLanguage("BusinessSummary")%></th>
                                                    <th><%=GetLanguage("Operation") %><%--操作--%></th>
                                                    <th><%=GetLanguage("AccountTypes")%></th>
                                                    <th><%=GetLanguage("AccountAmount")%></th>
                                                    <th><%=GetLanguage("TheBalanceOf")%></th>
                                                    <th><%=GetLanguage("Date")%></th>
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
                                                            <td data-title="操作类型"><%#AccountType(Eval("InAmount").ToString())%></td>
                                                            <td data-title="账户类型"><%#OpeanType(Eval("JournalType").ToString())%></td>
                                                            <td data-title="账目金额"><%#AccountType(Eval("InAmount").ToString()) == "支出" ? Eval("OutAmount") : Eval("InAmount")%></td>
                                                            <td data-title="余额"><%#Eval("BalanceAmount")%></td>
                                                            <td data-title="日期"><%#Eval("JournalDate")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                                <tr id="tr1" runat="server">
                                                    <td colspan="6" class="colspan">
                                                        <div class="text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><%--抱歉！目前数据库中暂无记录显示--%></div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
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
        </div>


    
</asp:Content>
