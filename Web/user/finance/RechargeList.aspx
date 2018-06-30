<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RechargeList.aspx.cs" Inherits="Web.user.finance.RechargeList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>充值记录</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" class="box_con" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="box box_width">
            <div class="capositon">
                <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("FinanceCenter")%>>><a href="javascript:void(0)"><%=GetLanguage("RechargeList")%></a>
            </div>
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch"><%=GetLanguage("RechargeList")%><%--提现记录--%></legend>
                <%=GetLanguage("RechargeDate")%>
                    <!--提现日期-->
                    ：
                <%if (GetLanguage("LoginLable") == "zh-cn")
                  {%>
                    <asp:TextBox ID="txtStar" tip="输入充值日期" runat="server" onfocus="new WdatePicker();"
                        class="input_select"></asp:TextBox>
                    <%=GetLanguage("To")%>
                    <!--至-->
                    <asp:TextBox ID="txtEnd" tip="输入充值日期" class="input_select" runat="server" onfocus="new WdatePicker();"></asp:TextBox>
                    <%}
                  else
                  {%>
                    <asp:TextBox ID="txtStarEn" tip="input withdraw deposits date" runat="server" onfocus="new WdatePicker({lang:'en'});"
                        class="input_select"></asp:TextBox>
                    <%=GetLanguage("To")%>
                    <!--至-->
                    <asp:TextBox ID="txtEndEn" tip="input withdraw deposits date" class="input_select"
                        runat="server" onfocus="new WdatePicker({lang:'en'});"></asp:TextBox>
                    <%} %>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
                </fieldset>
            </div>
           <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">会员编号</th>
                        <th align="center">充值金额</th>
                        <th align="center">充值类型</th>
                        <th align="center">金币类型</th>
                        <th align="center">充值方式</th>
                        <th align="center">充值方式</th>
                        <th align="center">充值日期</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><%#Eval("UserCode")%></td>
                                <td align="center"><%#Eval("RechargeableMoney")%></td>
                                <td align="center"><%#Eval("RechargeStyle").ToString() == "1" ? "增加" : "减少"%></td>
                                <td align="center"><%#Eval("RechargeType").ToString() == "1" ? "电子币" :"金币"%></td>
                                <td align="center"><%#Eval("Recharge001").ToString() == "1" ? "后台" :"支付宝"%></td>
                                <td align="center"><%#Eval("Flag").ToString() == "1" ? "<font style='color:green'>成功</font>" :"<font style='color:red'>失败</font>"%></td>
                                <td align="center"><%#Eval("RechargeDate")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="4" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="yellow">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" OnPageChanged="AspNetPager1_PageChanged"
                        AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10"
                        ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
