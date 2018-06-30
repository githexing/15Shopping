<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalDetail.aspx.cs"
    Inherits="Web.admin.finance.JournalDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>流水账明细</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contentpanel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary"
                        iconcls="icon-back" PostBackUrl="JournalAccount.aspx"><i class="fa fa-rotate-left"></i> 返 回 </asp:LinkButton>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">业务摘要(<asp:Literal ID="ltRemark" runat="server"></asp:Literal>)</th>
                                <th style="min-width: 80px;">
                                    <asp:Literal ID="ltIncome" runat="server"></asp:Literal>收入</th>
                                <th style="min-width: 80px;">
                                    <asp:Literal ID="ltExpenditure" runat="server"></asp:Literal>支出</th>
                                <th style="min-width: 80px;">
                                    <asp:Literal ID="ltBalance" runat="server"></asp:Literal>余额</th>
                                <th style="min-width: 80px;">日期</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("Remark")%>
                                    </td>
                                    <td>
                                        <%#Eval("InAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("OutAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("BalanceAmount")%>
                                    </td>
                                    <td>
                                        <%#Eval("JournalDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="5" align="center">抱歉！目前数据库暂无数据显示。</td>
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
