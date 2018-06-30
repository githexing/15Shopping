<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusDetails.aspx.cs" Inherits="Web.admin.finance.BonusDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>查看奖金明细</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline"  >
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">奖项名称:</label>
                                <asp:DropDownList ID="ddlBonus" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5 mb10" iconcls="icon-search"
                                    OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary mb10" iconcls="icon-search"
                                    OnClick="Button1_Click">返 回 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">奖项名称</th>
                                <th style="min-width: 80px;">奖金金额</th>
                                <th style="min-width: 80px;">结算日期</th>
                                <th style="min-width: 80px;">发放状态</th>
                                <th style="min-width: 80px;">详情</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="奖项名称">
                                        <%#Eval("typename")%>
                                    </td>
                                    <td data-attr="奖金金额">
                                        <%#Eval("amount")%>
                                        <%--金额--%>
                                    </td>
                                    <td data-attr="结算日期">
                                        <%#Eval("SttleTime")%>
                                    </td>
                                    <td data-attr="发放状态">
                                        <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "已发放" : "未发放"%>
                                    </td>
                                    <td data-attr="详情">
                                        <%#Eval("source")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="10" align="center">抱歉！目前数据库暂无数据显示。</td>
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
