<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendBonus.aspx.cs"
    Inherits="Web.user.finance.RecommendBonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>奖金查询</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="">
    <form id="Form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("FinancialQueries")%>>><a href="javascript:void(0)"><%=GetLanguage("RecommendInfo")%></a>
            <asp:Button ID="Button1" runat="server" Text="账户查询" class="btn" PostBackUrl="dl_JournalAccount.aspx" />
            <%--<asp:Button ID="Button4" runat="server" Text="账户转账" class="btn" PostBackUrl="TransferToEmoney.aspx" />--%>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">
                    <%=GetLanguage("Query")%>
                    <!--查询-->
                </legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td>
                            <%=GetLanguage("SettlementDate")%>
                            <!--结算日期-->
                            ：
                            <%if (GetLanguage("LoginLable") == "zh-cn")
                              {%>
                            <asp:TextBox ID="txtStar" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%=GetLanguage("To")%><!--至-->
                            <asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                            <%}
                              else
                              {%>
                            <asp:TextBox ID="txtStarEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"
                                class="input_select"></asp:TextBox>
                            <%=GetLanguage("To")%><!--至-->
                            <asp:TextBox ID="txtEndEn" tip="input close an account date" runat="server" onfocus="WdatePicker({lang:'en'})"
                                class="input_select"></asp:TextBox>
                            <%} %>
                            <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <td>
                        用户名：
                    </td>
                    <td>
                        <%=getColumn(0,"TrueName","tb_user","UserID="+getLoginID(),"") %>
                    </td>
                    <td>
                        资金总额：
                    </td>
                    <td>
                        <%=getColumn(0,"BonusAccount","tb_user","UserID="+getLoginID(),"") %>
                    </td>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <th>
                        推荐人用户名
                    </th>
                    <th>
                        推荐类型
                    </th>
                    <th>
                        用户编号
                    </th>
                    <th>
                        会员等级
                    </th>
                    <th>
                        <%=GetLanguage("LeadershipAward")%>
                        <!--推荐奖-->
                    </th>
                    <th>
                        <%=GetLanguage("ToTouch")%>
                        <!-- 对碰奖-->
                    </th>
                    <th>
                        <%=GetLanguage("BReturns")%>
                        <!-- B盘返利-->
                    </th>
                    <th>
                        <%=GetLanguage("RealHair")%>
                        <!--实发-->
                    </th>
                    <th>
                        <%=GetLanguage("SettlementDate")%>
                        <!--结算日期-->
                    </th>
                    <th>
                        <%=GetLanguage("ViewDetails")%>
                        <!--查看明细-->
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("xm")%><%--用户姓名--%>
                                <span style="color: #ff0000;">
                                    <%#Convert.ToInt32(Eval("il"))==0?"":"(已锁定)"%></span>
                            </td>
                            <td>
                                <%#Convert.ToInt32(Eval("at"))==0?"推荐用户":"拆分用户"%>
                                <%--直接推荐--%>
                            </td>
                            <td>
                                <%#Eval("yhm")%><%--用户编号--%>
                            </td>
                            <td>
                                <%#Eval("li")%><%--用户编号--%>
                            </td>
                            <td align="center">
                                <%#Eval("tj")%><%--推荐 1--%>
                            </td>
                            <td align="center">
                                <%#Eval("dp")%><%--对碰 2--%>
                            </td>
                            <td align="center">
                                <%#Eval("fl")%><%--B盘返利--%>
                            </td>
                            <%if (getBonus(getLoginID(), 0) > getOutMoney(getLoginID()))
                              { %>
                            <td align="center">
                                <%=getOutMoney(getLoginID())%>
                            </td>
                            <%}
                              else
                              { %>
                            <td align="center">
                                <%#Eval("am")%><%--实发 7--%>
                            </td>
                            <%} %>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--结算日期--%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%#Eval("jj","RecommendBonusDetail.aspx?{0}") %>'><%=GetLanguage("ViewDetails")%><!--查看明细--></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                    InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12" ShowInputBox="Never"
                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                    pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
