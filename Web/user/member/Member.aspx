<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Web.user.member.Member" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>激活</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="capositon">
        <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("daili")%>>><a href="javascript:void(0)"><%=GetLanguage("OpenMembership")%></a><!--待开通会员--></div>
    <div class="box box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">
                    <%=GetLanguage("Query")%><!--搜索--></legend>
                <%=GetLanguage("LoginInformation")%><!--会员编号-->:<input id="textUserCode" type="text"
                    runat="server" class="input_select" tip="输入会员编号" />
                会员级别:<asp:DropDownList ID="ddlLevel" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn" OnClick="btnSearch_Click" />
            </fieldset>
        </div>
        <!--end operation 操作-->
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        <%=GetLanguage("LoginInformation")%><!--会员编号-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("MemberNickname")%><!--会员昵称-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("MemberName")%><!--会员姓名-->
                    </th>
                    <th align="center">
                        <%=GetLanguage(" RegistrationAmount")%><!--注册金额-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("MembershipLevels")%><!--会员级别-->
                    </th>
                    <th align="center">
                        <%=GetLanguage("RegistrationHours")%><!--注册日期-->
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("User006")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%#Eval("RegMoney")%>
                            </td>
                            <td align="center">
                                <%# getLevel(Convert.ToInt32(Eval("LevelID")))%>
                            </td>
                            <td align="center">
                                <%#Eval("RegTime")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="6" align="center">
                        <div id="divno" runat="server" class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <div class="nextpage cBlack">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" OnPageChanged="AspNetPager1_PageChanged"
                                PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                                PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                                UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                            </webdiyer:AspNetPager>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <!--end data 表格数据-->
    </div>
    </form>
</body>
</html>
