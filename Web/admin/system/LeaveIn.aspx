<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveIn.aspx.cs" Inherits="Web.admin.system.LeaveIn" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言管理</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-group col-sm-1">
                        <asp:LinkButton ID="btn_s1" runat="server" class="btn btn-primary"
                            iconcls="icon-print" OnClick="btn_s1_Click"><i class="fa fa-folder-o"></i> 收件箱 </asp:LinkButton>
                    </div>
                    <div class="form-group col-sm-1">
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary"
                            iconcls="icon-print" OnClick="LinkButton1_Click"><i class="fa fa-folder-open-o"></i> 发件箱 </asp:LinkButton>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">留言查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">发件人:</label>
                                <input id="textSendCode" type="text" runat="server" tip="输入发件人" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnInSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-danger mr5"
                                    iconcls="icon-no" OnClick="btnInDel_Click" OnClientClick="return confirm('确定删除吗？')"><i class="fa fa-minus"></i> 删 除 </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">
                                    <div class="ckbox ckbox-default">
                                        <asp:CheckBox ID="ckAllIn" runat="server" Text="全选"
                                            OnCheckedChanged="ckAllIn_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </th>
                                <th style="min-width: 80px;">发件人</th>
                                <th style="min-width: 80px;">内容</th>
                                <th style="min-width: 80px;">发送时间</th>
                                <th style="min-width: 80px;">状态</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpInBox" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style='<%#Eval("IsRead").ToString()=="0"?"background:#CCCCCC; color:#FFF": ""%>' data-attr="全选">
                                        <input type="checkbox" name="CheckBoxIn" id="CheckBoxIn" value='<%#Eval("ID") %>' runat="server" />
                                    </td>
                                    <td style='<%#Eval("IsRead").ToString()=="0"?"background:#CCCCCC; color:#FFF": ""%>' data-attr="发件人">
                                        <%#GetUserCode(Eval("UserID").ToString(),Eval("FromUserType").ToString()) %>
                                    </td>
                                    <td style='<%#Eval("IsRead").ToString()=="0"?"background:#CCCCCC; color:#FFF": ""%>' data-attr="内容">
                                        <a href='LeaveWordsDetail.aspx?id=<%#Eval("ID") %>&type=1' target="_self"><%#Eval("MsgContent")%></a>
                                    </td>
                                    <td style='<%#Eval("IsRead").ToString()=="0"?"background:#CCCCCC; color:#FFF": ""%>'  data-attr="发送时间">
                                        <%#Convert.ToDateTime(Eval("LeaveTime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                    </td>
                                    <td style='<%#Eval("IsRead").ToString()=="0"?"background:#CCCCCC; color:#FFF": ""%>' data-attr="状态">
                                        <%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复"%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trInNull" runat="server" class="none">
                            <td colspan="5" style="border: 0" align="center">抱歉，目前数据库中暂无记录显示！</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                             <webdiyer:AspNetPager ID="anpInMail" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="anpInMail_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
