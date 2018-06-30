<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIssue.aspx.cs" Inherits="Web.admin.Stock.StockIssue" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:LinkButton ID="lbtnSplit" runat="server" class="btn btn-primary" iconcls="icon-search"
                        OnClick="lbtnSplit_Click"><i class="fa fa-code-fork"></i> 拆分管理 </asp:LinkButton>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">发行量:</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtNum" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    <span class="input-group-addon">个</span>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <asp:Literal ID="ltWarning" runat="server"></asp:Literal>
                                <asp:LinkButton ID="lbtnOK" runat="server" class="btn btn-success mr5" iconcls="icon-add"
                                    OnClick="lbtnOK_Click"><i class="fa fa-check"></i> MDD金币发行 </asp:LinkButton>
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
                                <th style="min-width: 80px;">发行总量</th>
                                <th style="min-width: 80px;">剩余总数</th>
                                <th style="min-width: 80px;">发行价格</th>
                                <th style="min-width: 80px;">发行期次</th>
                                <th style="min-width: 80px;">发行时间</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("IssueAmount")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SurplusAmount")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("IssuePrice")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Periods")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("AddDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="5" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
