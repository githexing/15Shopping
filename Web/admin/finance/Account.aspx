<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Web.admin.finance.Account" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>账户查询</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="row row-stat">
                <div class="col-md-3"  style="display:none;">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-user"><i class="fa fa-users"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                   <%-- <a href="../business/AgentList.aspx"></a>--%>

                                </h1>
                                <h5 class="md-title nomargin">
                                   <%-- <a href="../business/AgentList.aspx">拨出矿机</a>--%>

                                </h5>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->

                <div class="col-md-3" style="display:none;">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <a href="javascript:;">
                                <div class="panel-icon icon-globe"><i class="fa fa-user"></i></div>
                                <div class="media-body">
                                    <h1 class="mt5">
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                       <%-- <a href="../business/Member.aspx"> </a>--%>
                                    </h1>
                                    <h5 class="md-title nomargin">
                                        
                                       <%-- <a href="../business/Member.aspx">待激活会员</a>--%>

                                    </h5>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->

                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-envelope"><i class="fa fa-envelope"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                    <%--<a href="../system/LeaveIn.aspx"></a>--%>

                                </h1>
                                <h5 class="md-title nomargin">
                                    <%--<a href="../system/LeaveIn.aspx">未读邮件</a>--%>
                                    原始币数量
                                </h5>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->

                <div class="col-md-3">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-gavel"><i class="fa fa-child"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                <%--    <a href="../business/Agent.aspx"> </a>--%>

                                </h1>
                                <h5 class="md-title nomargin">
                                    释放币数量
                                   <%-- <a href="../business/Agent.aspx">申请代理商</a>--%>

                                </h5>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->
            </div>
            <div class="row row-stat" >
                <div class="col-md-3" style="display:none;">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-user"><i class="fa fa-sign-out"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><a href="TakeMoney.aspx">
                                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label></a></h1>
                                <h5 class="md-title nomargin"><a href="TakeMoney.aspx">今日申请提现</a></h5>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->

                <div class="col-md-3" style="display:none;">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-globe"><i class="fa fa-credit-card"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><a href="TakeList.aspx">
                                    <asp:Label ID="Label6" runat="server" Text=""></asp:Label></a></h1>
                                <h5 class="md-title nomargin"><a href="TakeList.aspx">已提现金额</a></h5>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->

                <div class="col-md-3" >
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-envelope"><i class="fa fa-money"></i></div>
                            <div class="media-body">
                                <h1 class="mt5">
                                   <%-- <a href="Account.aspx">  </a>--%>
                                    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                </h1>
                                <h5 class="md-title nomargin">
                                  <%--  <a href="Account.aspx">注册总金额</a>--%>
                                    智能钱包
                                </h5>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- col-md-3 -->

                <div class="col-md-3" style="display:none">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-envelope"><i class="fa fa-money"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><a href="RemitManage.aspx"><asp:Label ID="Label8" runat="server" Text=""></asp:Label></a></h1>
                                <h5 class="md-title nomargin"><a href="RemitManage.aspx">充值管理</a></h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-default" style="display:none;">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;"></th>
                                <th style="min-width: 80px;">总收入</th>
                                <th style="min-width: 80px;">总支出</th>
                                <th style="min-width: 80px;">总盈利</th>
                                <th style="min-width: 80px;">拨出比率</th>
                            </tr>
                        </thead>
                        <tr>
                            <td align="center">总计
                            </td>
                            <td align="center">
                                <%=GetIncomeTotal().ToString("0.00")%>
                            </td>
                            <td align="center">
                                <%=GetPayTotal().ToString("0.00")%>
                            </td>
                            <td align="center">
                                <%=(GetIncomeTotal() - GetPayTotal()).ToString("0.00")%>
                            </td>
                            <td align="center">
                                <%=GetIncomeTotal() == 0 ? "0" : (GetPayTotal() / GetIncomeTotal() * 100).ToString("0.00")%>%
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="panel panel-default" style="display:none;">
                <div class="panel-heading">
                    <h4 class="panel-title">账户查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="form-group mt10">
                            <label class="control-label">結算日期:</label>
                            <asp:TextBox ID="txtStar" tip="輸入日期" runat="server" class="form-control datepicker" onfocus="WdatePicker()"></asp:TextBox>
                            <label class="control-label">至</label>
                            <asp:TextBox ID="txtEnd" tip="輸入日期" runat="server" class="form-control datepicker" onfocus="WdatePicker()"></asp:TextBox>
                        </div>
                        <div class="form-group mt10">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5"
                                iconcls="icon-search" OnClick="LinkButton2_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                        </div>
                    </form>
                </div>
            </div>
            <div class="panel panel-default" style="display:none;">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 100px;">結算日期</th>
                                <th style="min-width: 80px;">本日收入</th>
                                <th style="min-width: 80px;">本日支出</th>
                                <th style="min-width: 80px;">本日盈利</th>
                                <th style="min-width: 80px;">拨出比率</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("recordTime")%>
                                    </td>
                                    <td>
                                        <%#  (float.Parse(Eval("sr").ToString())).ToString("0.00")%>
                                    </td>
                                    <td>
                                        <%#  (float.Parse(Eval("zc").ToString())).ToString("0.00")%>
                                    </td>
                                    <td>
                                        <%#  (float.Parse(Eval("yl").ToString())).ToString("0.00")%>
                                  
                                    </td>
                                    <td>
                                        <%#MyBL(Eval("sr"),Eval("zc"))%>
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
                            SubmitButtonClass="pagebutton" UrlPaging="false"
                            pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页"
                            textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
