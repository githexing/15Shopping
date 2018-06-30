<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WealthPlan.aspx.cs" Inherits="web.user.member.WealthPlan" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" class="" runat="server">
        <div id="main">
            <!--左侧菜单 star-->
            <div class="left">
                <div class="menu_t">信息中心</div>
                <div class="menu_x">
                    <ul>
                        <li><a href="NoticeList.aspx" target="fMain">公告信息</a></li>
                        <li><a href="LeaveMsg.aspx" target="fMain">我要留言</a></li>
                        <li><a href="QQService.aspx" target="fMain">公司客服</a></li>
                        <li><a href="WealthPlan.aspx" target="fMain" class="cur2">服务条款</a></li>
                    </ul>
                </div>
            </div>
            <!--左侧菜单 end-->
            <div class="right">
                <div class="title">
                    <span>当前位置：<a href="../default.aspx" class="hui">首页</a> &gt; 信息中心</span><h2>服务条款</h2>
                </div>
                <div class="right_nr">

    <div class="box">
    <div class="capositon">
        <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("InformationCenter")%>>><a href="javascript:void(0)"><%=GetLanguage("terms")%></a></div>
        <div class="dataTable">
          <dl class="newsInfotitle">
    <dt class="wryh">&nbsp;<asp:Label ID="lbTitle" runat="server" Text="" Font-Size="X-Large"></asp:Label>
  </dl>
  <div class="infomoreText">
    <asp:Literal ID="lilContent" runat="server"></asp:Literal>
  </div>
            </div>
        </div>
                    </div>
            <%--
  <ul class="upandnext">
    <li>上一篇：<a href="#">秋冬季节全面增强体质的全能大菜</a></li>
    <li>下一篇：<a href="#">大学生给父母打电话只为钱 男生为救病父</a></li>
  </ul>--%>
            
        </div>
    </div>
    </form>
</body>
</html>
