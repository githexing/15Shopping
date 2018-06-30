<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Web.user.Mall.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title></title>

    <link rel="stylesheet" type="text/css" href="../../css/common.css" />
    <link rel="stylesheet" type="text/css" href="../../css/main.css" />
    <script type="text/javascript" src="../../JS/jquery-1.11.1.min.js"></script>
</head>
<body class="grey">
    <form id="form1" runat="server">
        <div class="top">
            <div class="wrap">
                <i class="backto"><a href="javascript:history.back();"></a></i>
                <div class="search">
                    <span class="searchicon"></span>
                    <input type="text" class="searchtxt" name="txtSearch" id="txtSearch" runat="server" placeholder="输入关键词搜索" />
                </div>

                <asp:LinkButton runat="server" CssClass="searchbtn" Text="搜索" ID="btnSearch" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="searchhis">
            <h4>最近搜索</h4>
            <asp:Button runat="server" ID="Button1" Text="清除记录" style="float:right;" OnClick="Button1_Click"/>
            <ul>
                <asp:Repeater runat="server" ID="rpSearchList">
                    <ItemTemplate>
                        <li><a href='Itemlist.aspx?st=<%#Eval("SearchContext") %>'><%#Eval("SearchContext") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
                
            </ul>
        </div>

        <script type="text/javascript" charset="utf-8" src="../../js/flexible.js"></script>
    </form>
</body>
</html>
