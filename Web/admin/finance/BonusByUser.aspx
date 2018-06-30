<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusByUser.aspx.cs" Inherits="Web.admin.finance.BonusByUser" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>奖金明细</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body class="subBody">
    <form runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">直接招商津贴累计</th>
                                <th style="min-width: 80px;">区域津贴累计</th>
                                <th style="min-width: 80px;">管理津贴累计</th>
                                <th style="min-width: 80px;">幸运津贴累计</th>
                                <th style="min-width: 80px;">学习津贴累计</th>
                                <th style="min-width: 80px;">和谐津贴累计</th>
                                <th style="min-width: 80px;">应发累计</th>
                                <th style="min-width: 80px;">综合服务费累计</th>
                                <th style="min-width: 80px;">返本费累计</th>
                                <th style="min-width: 80px;">责任消费累计</th>
                                <th style="min-width: 80px;">市场权益累计</th>
                                <th style="min-width: 80px;">实发累计</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td data-attr="直接招商津贴累计"><%=GetBonus(0,2) %></td>
                                <td data-attr="区域津贴累计"><%=GetBonus(0,1) %></td>
                                <td data-attr="管理津贴累计"><%=GetBonus(0,4) %></td>
                                <td data-attr="幸运津贴累计"><%=GetBonus(0,3) %></td>
                                <td data-attr="学习津贴累计"><%=GetBonus(0,5) %></td>
                                <td data-attr="和谐津贴累计"><%=GetBonus(0,6) %></td>
                                <td data-attr="应发累计"><%=getBonusYF(0,1) %></td>
                                <td data-attr="综合服务费累计"><%=getBonusFWF(0) %></td>
                                <td data-attr="返本费累计"><%=getBonusFBF(0) %></td>
                                <td data-attr="责任消费累计"><%=getBonusCFXF(0) %></td>
                                <td data-attr="市场权益累计"><%=GetBonus(0,7) %></td>
                                <td data-attr="实发累计"><%=getBonusSF(0) %></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">奖金明细查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="form-group mt10">
                            <label class="control-label">结算日期:</label>
                            <asp:TextBox ID="txtStar" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            <label class="control-label">至</label>
                            <asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                        </div>
                        <div class="form-group mt10">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                        </div>
                    </form>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">用户</th>
                                <th style="min-width: 80px;">直接招商津贴</th>
                                <th style="min-width: 80px;">区域津贴</th>
                                <th style="min-width: 80px;">管理津贴</th>
                                <th style="min-width: 80px;">幸运津贴</th>
                                <th style="min-width: 80px;">学习津贴</th>
                                <th style="min-width: 80px;">和谐津贴</th>
                                <th style="min-width: 80px;">应发</th>
                                <th style="min-width: 80px;">综合服务费</th>
                                <th style="min-width: 80px;">返本费</th>
                                <th style="min-width: 80px;">责任消费</th>
                                <th style="min-width: 80px;">市场权益</th>
                                <th style="min-width: 80px;">实发</th>
                                <th style="min-width: 80px;">结算日期</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("yhm")%>
                                        <%--用户--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("tj")%>
                                        <%--直接招商津贴 Amount 2--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("dp")%><%--区域津贴 Amount 1--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("gl")%><%--管理津贴  Amount 4--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("jd")%><%--幸运津贴 Amount 3--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("xx")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("hx")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("yf")%><%--应发 Amount--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("fwf")%><%--综合服务费 Revenue--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("fbf")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("cfxf")%><%--责任消费 Bonus006--%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("bd")%><%--市场权益 bd --%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("sf")%><%--实发sf --%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SttleTime")%><%--结算日期--%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-info" iconcls="icon-search"
                                            PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><i class="fa fa-share-square-o"></i>查看明细</asp:LinkButton>
                                        <a class="btn btn-danger" href='BonusByUserDel.aspx?uid=<%#Eval("uid") %>&SttleTime= <%#Eval("SttleTime")%>'><i class="fa fa-minus"></i>删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trBonusNull" runat="server" class="none">
                            <td colspan="12" align="center">抱歉！目前数据库暂无数据显示。</td>
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
