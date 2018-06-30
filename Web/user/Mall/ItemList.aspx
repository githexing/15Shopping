<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs" Inherits="Web.user.Mall.ItemList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../css/common.css" />
    <link rel="stylesheet" type="text/css" href="../../css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <div class="top">
            <div class="wrap">
                <i class="backto"><a href="javascript:history.back();"></a></i>
                <div class="ptitle">
                    <asp:Literal runat="server" ID="ltSearch"></asp:Literal>
                </div>
                <i class="searchi"><a href="Search.aspx"></a></i>
            </div>
        </div>
        <div class="sort">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <ul>
                        <li>
                            <span>

                                <asp:DropDownList runat="server" ID="dropSort" AutoPostBack="true" OnSelectedIndexChanged="dropSort_SelectedIndexChanged">
                                    <asp:ListItem Value="1">综合排序</asp:ListItem>
                                    <asp:ListItem Value="2">价格由高到低</asp:ListItem>
                                    <asp:ListItem Value="3">价格由低到高</asp:ListItem>
                                </asp:DropDownList>

                            </span>
                        </li>
                        <li>
                            <span>
                                <asp:DropDownList runat="server" ID="dropSell" AutoPostBack="true" OnSelectedIndexChanged="dropSell_SelectedIndexChanged">
                                    <asp:ListItem Value="1">销量优先</asp:ListItem>
                                </asp:DropDownList>

                                <i class="downarrow"></i>
                            </span>
                        </li>
                    </ul>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="itemlist">
            <div class="items">
                <ul>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                        <ContentTemplate>

                            <asp:Repeater runat="server" ID="Repeater1">
                                <ItemTemplate>
                                    <li>
                                        <div>
                                            <a href='goodsdetail.aspx?gid=<%#Eval("ID") %>'>
                                                <img src='../../Upload/<%#Eval("Pic1") %>' alt="" />
                                            </a>
                                            <p>
                                                <a href='goodsdetail.aspx?gid=<%#Eval("ID") %>'><%#Eval("GoodsName") %></a>
                                            </p>
                                            <p>
                                                <a href='goodsdetail.aspx?gid=<%#Eval("ID") %>'>
                                                    <span class="prices">¥<%#Eval("RealityPrice") %></span>
                                                    <em class="oldprices">¥<%#Eval("Price") %></em>
                                                </a>
                                            </p>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <li runat="server" id="li1" style="text-align: center;">
                        <div>
                            暂无记录
                        </div>
                    </li>
                </ul>
            </div>
        </div>

        <div class="page">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                SubmitButtonText="" textafterpageindexbox=" 页" TextBeforeInputBox="" textbeforepageindexbox="转到 " Direction="LeftToRight"
                HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        </div>

        <script type="text/javascript" charset="utf-8" src="../../js/flexible.js"></script>
    </form>
</body>
</html>
