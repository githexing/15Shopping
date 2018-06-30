<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendBonusDetail.aspx.cs" Inherits="Web.user.finance.RecommendBonusDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>无标题文档</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="subBody">
    <form id="Form1" class="box" runat="server">
    <div class="capositon">
    <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("FinancialQueries")%>>><a href="javascript:void(0)"><%=GetLanguage("BonusDetails")%></a>
        <!--奖金明细-->
        <asp:Button ID="Button2" runat="server" Text="账户查询" class="btn" PostBackUrl="dl_JournalAccount.aspx" />
       
        <asp:Button ID="Button4" runat="server" Text="账户转账" class="btn" PostBackUrl="TransferToEmoney.aspx" /></div>
    <div class=" box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch"><%=GetLanguage("Query") %><!--查询--></legend><%=GetLanguage("AwardName")%><!--奖项名称-->:<asp:DropDownList ID="ddlBonus" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                <asp:Button ID="Button1" runat="server" Text="返 回" class="btn" PostBackUrl="RecommendBonus.aspx" />
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        <%=GetLanguage("AwardName")%><!--奖项名称-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("money")%><!--金额-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("SettlementDate")%><!--结算日期-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("State")%><!--状态-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("Details")%><!--详情-->
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%if (cnen == "zh-cn") %>
                                <%{ %>
                                <%#Eval("typename")%>
                                <%}
                                  else
                                  { %>
                                <%#Eval("typenameen")%>
                                <%} %>

                            </td>
                            <td align="center">
                                <%#Eval("amount")%>
                                <%--金额--%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%><%--结算日期--%>
                            </td>
                            <td align="center">

                                <%if (cnen == "zh-cn") %>
                                <%{ %>
                                <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "已发放" : "未发放"%>
                                <%}
                                  else
                                  { %>
                                <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "Issue" : "Not issue"%>
                                <%} %>

                            </td>
                            <td align="center">
                                <%if (cnen == "zh-cn") %>
                                <%{ %>
                                <%#Eval("source")%><%-- 详情--%>
                                <%}
                                  else
                                  { %>
                                <%#Eval("sourceen")%><%-- 详情--%>
                                <%} %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="13" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt=""/>
                                 <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>