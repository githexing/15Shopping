<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JinpaiList.aspx.cs" Inherits="Web.admin.product.JinpaiList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
            <tr>
                <th>
                    竞拍会员编号
                </th>
                <th>
                    竞拍商品
                </th>
                <th>
                    时间
                </th>
                <th>
                    竞拍价
                </th>
                <th>
                    竞拍状态
                </th>
            </tr>
            <asp:Repeater ID="rptProduct" runat="server">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <%#Eval("UserCode")%>
                        </td>
                        <td align="center">
                            <%#Eval("SaPrName")%>
                        </td>
                        <td align="center">
                            <%#Eval("AuctionTime")%>
                        </td>
                        <td align="center">
                            <%#Eval("AuctionPrice")%>
                        </td>
                        <td align="center">
                            <%#Eval("Atype").ToString()=="2"?"竞拍成功":"竞拍失败"%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr align="center" runat="server" id="tr1">
                <td colspan="10" style="border: 0">
                    <div>
                        抱歉，目前数据库中暂无记录显示！</div>
                </td>
            </tr>
        </table>
        <div class="yellow">
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