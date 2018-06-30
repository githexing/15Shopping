<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dl_BonusDetails.aspx.cs" Inherits="Web.admin.finance.dl_BonusDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script type="text/javascript" src="../Scripts/Common.js"></script>

    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>

    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="box box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>奖项名称:<asp:DropDownList ID="ddlBonus" runat="server">
                </asp:DropDownList>
                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="Button1_Click">返 回 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        奖项名称
                    </th>
                    <th align="center">
                        金额
                    </th><%--
                    <th align="center">
                        综合服务费
                    </th>
                    <th align="center">
                        返本费
                    </th>--%>
                    <th align="center">
                        应发
                    </th>
                    <th align="center">
                        结算日期
                    </th>
                    <th align="center">
                        发放状态
                    </th>
                    <th align="center">
                        详情
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("typename")%>
                            </td>
                            <td align="center">
                                <%#Eval("amount")%>
                            </td><%--
                            <td align="center">
                                <%#Eval("fwf")%>
                            </td>
                            <td align="center">
                                <%#Eval("fbf")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("sf")%>
                            </td>
                            <td align="center">
                                <%#Eval("SttleTime")%>
                            </td>
                            <td align="center">
                                <%#Convert.ToInt32(Eval("IsSettled")) == 1 ? "已发放" : "未发放"%>
                            </td>
                            <td align="center">
                                <%#Eval("source")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="13" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
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
    </form>
</body>
</html>
