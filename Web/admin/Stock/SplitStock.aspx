<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplitStock.aspx.cs" Inherits="Web.admin.Stock.SplitStock" %>

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
                    <asp:LinkButton ID="lbtnIssue" runat="server" class="btn btn-primary" iconcls="icon-ok"
                        OnClick="lbtnIssue_Click"> MDD金币发行 </asp:LinkButton>
                    <asp:LinkButton ID="lbtnSplit" runat="server" class="btn btn-primary" iconcls="icon-ok"
                        OnClick="lbtnSplit_Click"> 拆分管理 </asp:LinkButton>
                    <asp:LinkButton ID="lbtnSubmit" runat="server" class="btn btn-primary" iconcls="icon-search"
                        OnClick="lbtnSubmit_Click"> 提 交 </asp:LinkButton>
                </div>
                <div class="panel-body">
                    <div class="alert alert-info">
                        <asp:Literal ID="ltltSplit" Visible="false" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="row row-stat">
                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-user"><i class="fa fa-gavel"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                    <asp:Literal ID="ltSplitPriceB" runat="server"></asp:Literal></h1>
                                <h5 class="md-title nomargin">当前MDD金币价</h5>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-globe"><i class="fa fa-code-fork"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                    <asp:Literal ID="ltSplitPriceL" runat="server"></asp:Literal></h1>
                                <h5 class="md-title nomargin">MDD金币拆分价</h5>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-envelope"><i class="fa fa-money"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                    <asp:Literal ID="ltSplitPrice" runat="server"></asp:Literal></h1>
                                <h5 class="md-title nomargin">拆分后MDD金币价格</h5>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-gavel"><i class="fa fa-magic"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                    <asp:Literal ID="ltSplitRateOne" runat="server"></asp:Literal>:<asp:Literal ID="ltSplitRate" runat="server"></asp:Literal></h1>
                                <h5 class="md-title nomargin">MDD金币拆分比例</h5>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-envelope"><i class="fa fa-money"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                    <asp:Literal ID="ltSplitTimes" runat="server"></asp:Literal></h1>
                                <h5 class="md-title nomargin">拆分次数</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">拆分前MDD金币价</th>
                                <th style="min-width: 80px;">拆分后MDD金币价</th>
                                <th style="min-width: 80px;">拆分比例</th>
                                <th style="min-width: 80px;">拆分次数</th>
                                <th style="min-width: 80px;">拆分时间</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("SplitPriceB")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SplitPriceL")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SplitRate")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SplitTimes")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SplitDate")%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtnDetail" runat="server" class="btn btn-info" iconcls="icon-search"
                                            PostBackUrl='<%#Eval("SplitID","SplitStockDetail.aspx?SplitID={0}") %>'><i class="fa fa-pencil"></i>拆分明细</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="6" align="center">抱歉！目前数据库暂无数据显示。</td>
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
