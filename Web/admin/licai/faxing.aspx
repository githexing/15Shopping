<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faxing.aspx.cs" Inherits="Web.admin.licai.faxing" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="operation">
        <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
            OnClick="LinkButton1_Click"> 股票发行 </asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
            OnClick="LinkButton2_Click"> 拆分管理 </asp:LinkButton>
    </div>
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">发行</legend>发行量:<asp:TextBox ID="txtNum" tip="输入发行量" onkeydown="if(event.keyCode==13)event.keyCode=9"
                onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                runat="server" class="easyui-numberbox input_select" precision="2"></asp:TextBox>
            <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-add"
                OnClick="btnOK_Click"> 股票发行 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th>
                    发行量
                </th>
                <th>
                    剩余股票数
                </th>
                <th>
                    发行时间
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rpsp" runat="server" OnItemCommand="rpsp_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("IssueAmount")%>
                        </td>
                        <td align="center">
                            <%#Eval("SurplusAmount")%>
                        </td>
                        <td align="center">
                            <%#Eval("AddTime")%>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-no"
                                CommandName="del" CommandArgument='<%#Eval("ID") %>'>删 除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="tr2" runat="server">
                <td colspan="4" align="center">
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
    </form>
</body>
</html>
