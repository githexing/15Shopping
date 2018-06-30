<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chaifen.aspx.cs" Inherits="Web.admin.licai.chaifen" %>

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
            <legend class="legSearch">拆分</legend><legend class="legSearch"></legend>今日开盘价格:
            <input name="Add_sscFd7" id="txtPrice" class="input_select" runat="server" type="text"
                disabled="disabled" />&nbsp;&nbsp;&nbsp; 拆分比例:<input name="Add_sscFd7" id="txtBeiShu"
                    size="12" tip="输入拆分比例" onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                    class="easyui-numberbox input_select" precision="2" runat="server" type="text" />
            <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="btnwcash_Click"> 提 交 </asp:LinkButton>
        </fieldset>
    </div>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th>
                    开盘价格
                </th>
                <th>
                    拆分比例
                </th>
                <th>
                    拆分时间
                </th>
                <th>
                    操作
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("jg")%>
                        </td>
                        <td align="center">
                            <%#Eval("bl")%>
                        </td>
                        <td align="center">
                            <%#Eval("sj")%>
                        </td>
                        <td align="center">
                            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                PostBackUrl='<%#Eval("sj","chaifenDetails.aspx?cfsj={0}") %>'>拆分明细</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr id="tr1" runat="server">
                <td colspan="4" align="center">
                    <div class="NoData">
                        <span class="cBlack">
                            <img alt="" src="../../images/ico_NoDate.gif" width="16" height="16" />
                            抱歉！目前数据库暂无数据显示。</span></div>
                </td>
            </tr>
        </table>
        <div class="nextpage cBlack">
            <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager2_PageChanged">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
