<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.admin.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>会员奖金</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">推荐奖累计</th>
                                <th style="min-width: 80px;">层销奖累计</th>
                                <th style="min-width: 80px;">销量奖累计</th>
                                <th style="min-width: 80px;">管理奖累计</th>
                                <th style="min-width: 80px;">服务中心奖累计</th>
                                <th style="min-width: 80px;">见点奖累计</th>
                                <th style="min-width: 80px;">消费积分兑换奖累计</th>
                                <th style="min-width: 80px;">奖金累计</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td data-attr="释放币累计">
                                    <%=GetBonus(0, 1)%>
                                </td>
                                <td data-attr="静态收益累计">
                                    <%=GetBonus(0, 2)%>
                                </td>
                                <td data-attr="动态收益累计">
                                    <%=GetBonus(0, 3)%>
                                </td>
                                   <td data-attr="动态收益累计">
                                    <%=GetBonus(0, 4)%>
                                </td>
                                   <td data-attr="动态收益累计">
                                    <%=GetBonus(0, 5)%>
                                </td>
                                   <td data-attr="动态收益累计">
                                    <%=GetBonus(0, 6)%>
                                </td>
                                   <td data-attr="动态收益累计">
                                    <%=GetBonus(0, 7)%>
                                </td>
                                <td data-attr="奖金累计">
                                    <%=GetBonusAllTotal(0, "Amount")%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">会员奖金查询</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="form-group mt10">
                            <label class="control-label">结算日期:</label>
                            <asp:TextBox ID="txtStar" tip="输入结算日期"
                                runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            <label class="control-label">至</label>
                            <asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                        </div>
                        <div class="form-group mt10">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                OnClick="LinkButton3_Click"><i class="fa fa-download"></i> 导 出 </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">推荐奖</th>
                                <th style="min-width: 80px;">层销奖</th>
                                <th style="min-width: 80px;">销量奖</th>
                                     <th style="min-width: 80px;">管理奖</th>
                                     <th style="min-width: 80px;">服务中心奖</th>
                                     <th style="min-width: 80px;">见点奖</th>
                                     <th style="min-width: 80px;">消费积分兑换奖</th>
                                <th style="min-width: 80px;">实发</th>
                                <th style="min-width: 80px;">结算日期</th>
                                <th style="min-width: 80px;">查看明细</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="释放币">
                                        <%#Eval("shifang")%><%--1.释放币--%>
                                    </td>
                                    <td data-attr="静态收益">
                                        <%#Eval("jingtai")%><%--2.静态收益--%>
                                    </td>
                                    <td data-attr="动态收益">
                                        <%#Eval("dongtai")%><%--3.动态收益--%>
                                    </td>
                                      <td data-attr="动态收益">
                                        <%#Eval("dongtai1")%><%--3.动态收益--%>
                                    </td>
                                      <td data-attr="动态收益">
                                        <%#Eval("dongtai2")%><%--3.动态收益--%>
                                    </td>
                                      <td data-attr="动态收益">
                                        <%#Eval("dongtai3")%><%--3.动态收益--%>
                                    </td>
                                      <td data-attr="动态收益">
                                        <%#Eval("dongtai4")%><%--3.动态收益--%>
                                    </td>
                                    <td data-attr="实发">
                                        <%#Eval("am")%><%--实发--%>
                                    </td>
                                    <td data-attr="结算日期">
                                        <%#Eval("SttleTime")%><%--结算日期--%>
                                    </td>
                                    <td data-attr="查看明细">
                                        <asp:LinkButton ID="lbtnDetail" class="btn btn-info" runat="server" PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><i class="fa fa-share-square-o"></i>查看明细</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server">
                            <td colspan="8" align="center" class="none">抱歉！目前暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                            FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                            SubmitButtonText="转到" TextAfterPageIndexBox=" 页" TextBeforePageIndexBox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
