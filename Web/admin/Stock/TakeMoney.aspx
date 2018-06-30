<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeMoney.aspx.cs" Inherits="Web.admin.Stock.TakeMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>奖金提现</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="box box_width">
        <div class="operation">
            <asp:LinkButton ID="lbtnApply" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="lbtnApply_Click"> 申请记录 </asp:LinkButton>
            <asp:LinkButton ID="lbtnWithdraw" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="lbtnWithdraw_Click"> 提现记录 </asp:LinkButton>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>已提现：<input name="txtMoney" id="txtMoney" tip=""
                    disabled="disabled" class="input_select" runat="server" type="text" />
                会员编号：<input name="txtUserCode" id="txtUserCode" tip="输入会员编号" class="input_select"
                    runat="server" type="text" />
                会员姓名：<input name="txtTrueName" id="txtTrueName" tip="输入会员姓名" class="input_select"
                    runat="server" type="text" />
                申请日期：<asp:TextBox ID="txtStar" tip="输入提现日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入提现日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="lbtnSearch_Click"> 搜 索 </asp:LinkButton>
                <asp:LinkButton ID="lbtnExport" runat="server" class="easyui-linkbutton" iconcls="icon-print"
                    OnClick="lbtnExport_Click"> 导出Excel </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        会员编号
                    </th>
                    <th align="center">
                        会员姓名
                    </th>
                    <th align="center">
                        申请日期
                    </th>
                    <th align="center">
                        提现金额
                    </th>
                    <th align="center">
                        手续费
                    </th>
                    <th align="center">
                        实发
                    </th>
                    <th align="center">
                        开户银行
                    </th>
                    <th align="center">
                        银行卡号
                    </th>
                    <th align="center">
                        开户名
                    </th>
                    <th align="center">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%#Eval("TakeTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("TakeMoney")%>
                            </td>
                            <td align="center">
                                <%#Eval("TakePoundage")%>
                            </td>
                            <td align="center">
                                <%#Eval("RealityMoney")%>
                            </td>
                            <td align="center">
                                <%#Eval("BankName")%>
                            </td>
                            <td align="center">
                                <%#Eval("BankAccount")%>
                            </td>
                            <td align="center">
                                <%#Eval("BankAccountUser")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnEnter" CommandArgument='<%# Eval("ID") %>' CommandName="Open"
                                    class="easyui-linkbutton" iconcls="icon-ok" runat="server">确认</asp:LinkButton>
                                <asp:LinkButton ID="lbtnDelete" CommandArgument='<%# Eval("ID") %>' CommandName="Remove"
                                    class="easyui-linkbutton" iconcls="icon-no" runat="server" OnClientClick="javascript:return confirm('确认删除吗？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="divno" runat="server">
                    <td colspan="10" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                    HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
