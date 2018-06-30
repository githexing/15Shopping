<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveWordsDetail.aspx.cs" Inherits="web.admin.system.LeaveWordsDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="list-group contact-group">
                <div class="list-group-item">
                    <div class="media">
                        <div class="pull-left">
                            <%--  <img src="../upload/<%#Eval("PicUrl") %>" alt="uploading">--%>
                            <img class="img-circle img-online" src="../images/profile.png" />
                        </div>
                        <div class="media-body">
                            <h4 class="media-heading">
                                <asp:Label ID="lblSendMember" runat="server" Text=""></asp:Label>
                                <small>发送时间：
                                            <asp:Label ID="lblSendDate" runat="server" Text=""></asp:Label></small></h4>
                            <div class="media-content">
                                <p><i class="fa fa-bullhorn"></i>主题：<asp:Label ID="lblSendTitle" runat="server" Text=""></asp:Label></p>
                                <asp:Label ID="lblSendContent" runat="server" Text=""></asp:Label>
                                <div class="managerReply" id="divNull" runat="server">
                                    <p class="cRed">目前暂时无回复信息！</p>
                                <a id="link" runat="server" target="_blank"> <asp:Image ID="lblpic" runat="server"/></a>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- media -->
                </div>
            </div>
            <div class="panel panel-primary-head widget-chat">
                <div class="panel-heading">
                    <div class="pull-right">
                        <%--<a data-toggle="tooltip" class="tooltips mr5" href="t-4-2.html" data-original-title="返回"><i class="glyphicon glyphicon-circle-arrow-left"></i></a>--%>
                    </div>
                    <!-- panel-btns -->
                    <h3 class="panel-title">留言</h3>
                </div>
                <div class="panel-body">
                    <div class="chat-conversation">
                        <asp:Repeater ID="rpReply" runat="server">
                            <ItemTemplate>
                                <div class="managerReply">
                                    <h2 class="cGold ico_admin">
                                        <%#Eval("UserType").ToString() == "1" ? GetUserCode(Eval("UserID").ToString(), 1) : GetUserCode(Eval("UserID").ToString(), 2)%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("ReTime")%>回复：</h2>
                                    <p>
                                    </p>
                                    <p class="cRed">
                                        <%#Eval("ReContent")%>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <!--end managerReply-->
                        <div class="nextpage cBlack">
                            <webdiyer:AspNetPager ID="anpReply" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                                SubmitButtonText="转到" TextAfterPageIndexBox=" 页" TextBeforePageIndexBox="转到 " Direction="LeftToRight"
                                HorizontalAlign="Center" OnPageChanged="anpReply_PageChanged">
                            </webdiyer:AspNetPager>

                        </div>
                        <%--<ul class="widget-conversation-list">
                            <li class="clearfix">
                                <div class="chat-avatar">
                                    <p>system</p>
                                </div>
                                <div class="conversation-text">
                                    <div class="ctext-wrap">
                                        <i>2016-10-25 15:03:32</i>
                                        <p>Hello!</p>
                                    </div>
                                </div>
                            </li>
                            <li class="clearfix odd">
                                <div class="chat-avatar">
                                    <p>admin</p>
                                </div>
                                <div class="conversation-text">
                                    <div class="ctext-wrap">
                                        <i>2016/11/30 10:28:10</i>
                                        <p>Hi, How are you? What about our next meeting?</p>
                                    </div>
                                </div>
                            </li>
                        </ul>--%>
                        <hr />
                        <div class="panel-title">回复留言：</div>
                        <div class="row mt10">
                            <div class="col-xs-12">
                                <asp:TextBox ID="txtPubContext" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt10">
                            <div class="col-xs-3">
                                <asp:LinkButton ID="btn_s1" runat="server" class="btn btn-primary" iconcls="icon-ok" OnClick="btnRepeat_Click"> 提 交 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-dark" iconcls="icon-back" OnClick="btnBack_Click"> 返回 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
