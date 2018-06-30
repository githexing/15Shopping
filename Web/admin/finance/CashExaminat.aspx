<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashExaminat.aspx.cs" Inherits="Web.admin.finance.CashExaminat" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
    <form id="form1" runat="server">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>
                会员编号：<asp:TextBox ID="txtUserCode" runat="server" class="input_select"></asp:TextBox>
                求购日期：<asp:TextBox ID="txtStart" tip="输入求购日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入求购日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="lbtnSearch" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="lbtnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">买家
                    </th>
                    <th align="center">买家评分
                    </th>
                    <th align="center">商品信息
                    </th>
                    <th align="center">商品数量
                    </th>
                    <th align="center">商品单价
                    </th>
                    <th align="center">商品金额
                    </th>
                    <th align="center">求购日期
                    </th>
                    <th align="center">操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%# Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <asp:Literal ID="ltBValues" runat="server"></asp:Literal>
                            </td>
                            <td align="center">
                                <a href="PurchaseDetail.aspx?PurchaseID=<%#Eval("PurchaseID")%>">
                                    查看明细</a>
                            </td>
                            <td align="center">
                                <%#Eval("Number")%>
                            </td>
                            <td align="center">
                                <%#Eval("Price")%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%>
                            </td>
                            <td align="center">
                                <%#Eval("PurchaseDate")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lbtnExaminat" runat="server" CommandArgument='<%# Eval("PurchaseID") %>'
                                    class="easyui-linkbutton" iconcls="icon-ok" Visible='true' CommandName="Examinat"
                                    OnClientClick="javascript:return confirm('确定审核该求购信息吗？')">审核</asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("PurchaseID") %>' class="easyui-linkbutton"
                                    iconcls="icon-no" Visible='<%#Eval("IsPur").ToString()=="0"?true:false %>'
                                    CommandName="Remove" OnClientClick="javascript:return confirm('确定要删除此求购信息吗？')">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="tr1" runat="server">
                    <td colspan="8" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span>
                        </div>
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
    </form>
</body>
</html>
