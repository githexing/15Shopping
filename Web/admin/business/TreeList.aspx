<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeList.aspx.cs" Inherits="Web.admin.business.TreeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">查询</legend>会员编号：<input name="Add_sscFd7" id="txtUserCode2"
                tip="输入会员编号" class="input_select" runat="server" type="text" />
            层数：<input name="Add_sscFd7" id="txtGenera" tip="请输入层数" class="input_select" runat="server"
                type="text" />
            <asp:LinkButton ID="LinkButton5" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="btnSearch2_Click"> 搜 索 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th align="center">
                    层数
                </th>
                <th align="center">
                    会员编号
                </th>
                <th align="center">
                    级别
                </th>
                <th align="center">
                状态
                </th>
                <th align="center">
                    左区
                </th>
                <th align="center">
                    右区
                </th>
                <th align="center">
                    左区总业绩
                </th>
                <th align="center">
                    右区总业绩
                </th>
                <th align="center">
                    左区新增业绩
                </th>
                <th align="center">
                    右区新增业绩
                </th>
                <th align="center">
                    左区剩余业绩
                </th>
                <th align="center">
                    右区剩余业绩
                </th>
            </tr>
            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%# Eval("Layer")%>
                        </td>
                        <td align="center">
                            <%# Eval("UserCode")%>
                        </td>
                        <td align="center">
                            <%#MyTypeName(Eval("LevelID"))%>
                        </td>
                        <td align="center">
                        <%#IsOpen(Eval("IsOpend"))%>
                        </td>
                        <td align="center">
                           <%#MyChild(Eval("UserID"),1)%>
                        </td>
                        <td align="center">
                            <%#MyChild(Eval("UserID"), 2)%>
                        </td>
                        <td align="center">
                            <%#Eval("LeftScore")%>
                        </td>
                        <td align="center">
                            <%#Eval("RightScore")%>
                        </td>
                        <td align="center">
                            <%#Eval("LeftNewScore")%>
                        </td>
                        <td align="center">
                            <%#Eval("RightNewScore")%>
                        </td>
                        <td align="center">
                            <%#Eval("LeftBalance")%>
                        </td>
                        <td align="center">
                            <%#Eval("RightBalance")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="tr1" runat="server">
                <td colspan="11" align="center">
                    <div class="NoData" id="span1">
                        <span class="cBlack">
                            <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                            抱歉！目前数据库暂无数据显示。</span></div>
                </td>
            </tr>
        </table>
        <div class="nextpage cBlack">
        <span class="count">显示<%=((AspNetPager2.PageSize * (AspNetPager2.CurrentPageIndex-1)) +1).ToString()%>到<%=AspNetPager2.CurrentPageIndex == AspNetPager2.PageCount ? AspNetPager2.RecordCount.ToString() : ((AspNetPager2.PageSize * (AspNetPager2.CurrentPageIndex - 1)) + AspNetPager2.PageSize).ToString()%>,共<%=AspNetPager2.RecordCount.ToString()%>记录,每页<%=AspNetPager2.PageSize.ToString()%>条</span>
            <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                HorizontalAlign="Right" OnPageChanged="AspNetPager2_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
