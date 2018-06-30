<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcishan.aspx.cs" Inherits="Web.user.finance.addcishan" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#txtMoney").val(" ");
            $("#txtMoney").click(function () {
                $(this).val("");
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box">
        <div class="capositon">
            <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("Financial")%>>><a href="javascript:void(0)"><%=GetLanguage("Transfer")%></a>
        </div>
        <div class="box_con">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">捐款</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                        <tr>
                          <td>奖金余额：<asp:Label ID="Label_money" runat="server" ForeColor="#ff0000"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>捐款金额：
                                <input name="txtMoney" id="txtMoney" class="input_select" runat="server" type="text"
                                    onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;" />元<!--元-->
                                &nbsp;<asp:Button
                                        ID="btnSubmit" runat="server" Text="提交" class="btn" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">捐款查询 </legend>
                    <%=GetLanguage("DateTransfer")%>
                    <!--转账日期-->
                    ：
                    <asp:TextBox ID="txtStartDate" tip="输入转账日期" runat="server" onfocus="WdatePicker()"
                        class="input_select"></asp:TextBox>
                    <%=GetLanguage("To")%>
                    <!--至-->
                    <asp:TextBox ID="txtEndDate" tip="输入转账日期" runat="server" onfocus="WdatePicker()"
                        class="input_select"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="搜 索"
                            class="btn" OnClick="btnSearch_Click" />
                </fieldset>
            </div>
            <div class="dataTable">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th>
                            <%=GetLanguage("MembershipNumber")%>
                            <!--会员编号-->
                        </th>
                        <th>
                            <%=GetLanguage("MemberName")%>
                            <!--会员姓名-->
                        </th>
                        <th>
                            <%=GetLanguage("TheTransferAmount")%>
                            <!--转账金额-->
                        </th>
                        <th>
                            <%=GetLanguage("DateTransfer")%>
                            <!--转账日期-->
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TrueName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("Amount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("ChangeDate")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trBonusNull" runat="server">
                        <td colspan="5" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></span></div>
                        </td>
                    </tr>
                </table>
                <div class="yellow">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                        InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10" ShowInputBox="Never"
                        ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                        pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
