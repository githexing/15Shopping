<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalAccount.aspx.cs"
    Inherits="Web.admin.finance.JournalAccount" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>账户明细</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">账户明细查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input id="textUserCode" type="text" runat="server" class="form-control" tip="输入会员编号" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员姓名:</label>
                                <asp:TextBox ID="txtTrueName" tip="输入姓名" runat="server" class="form-control"></asp:TextBox>
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
                            <tr>
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">奖金积分</th>
                                <th style="min-width: 80px;">电子积分</th>
                                <th style="min-width: 80px;">消费积分</th>
                                <th style="min-width: 80px;">报单积分</th>
                                <th style="min-width: 80px;">平台手续费</th>
                                <th style="min-width: 80px;">公益基金</th>
                            <%--    <th style="min-width: 80px;">安全账户</th>--%>
                                <%--<th style="min-width: 80px;">释放币</th>--%>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="会员编号">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td data-attr="会员姓名">
                                        <%#Eval("TrueName")%>
                                    </td>
                                    <td data-attr="奖金积分">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="b_detail"><%#Eval("Emoney")%></asp:LinkButton>
                                    </td>
                                    <td data-attr="电子积分">
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="e_detail"><%#Eval("StockMoney")%></asp:LinkButton>
                                    </td>
                                    <td data-attr="消费积分">
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="s_detail"><%#Eval("BonusAccount")%></asp:LinkButton>
                                    </td>
                                    <td data-attr="报单积分">
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="a_detail"><%#Eval("StockAccount")%></asp:LinkButton>
                                    </td>
                                    <td data-attr="平台手续费">
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="h_detail"><%#Eval("ShopAccount")%></asp:LinkButton>
                                    </td>
                                    <td data-attr="公益基金">
                                        <asp:LinkButton ID="LinkButton6" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="c_detail"><%#Eval("GLmoney")%></asp:LinkButton>
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
