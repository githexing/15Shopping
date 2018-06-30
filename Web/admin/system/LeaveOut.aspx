<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveOut.aspx.cs" Inherits="Web.admin.system.LeaveOut" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contentpanel">
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
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">收件人:</label>
                                <input id="textInCode" type="text" runat="server" tip="输入收件人" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSendSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-danger mr5"
                                    iconcls="icon-no" OnClick="btnDelSend_Click" OnClientClick="return confirm('确定删除吗？')"><i class="fa fa-minus"></i> 删 除 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-print" OnClick="btnSendLeave_Click"><i class="fa fa-search"></i> 留 言 </asp:LinkButton>
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
                                        <asp:CheckBox ID="ckAllSend" runat="server" AutoPostBack="True" Text="全选"
                                            OnCheckedChanged="ckAllSend_CheckedChanged" />
                                    </div>
                                </th>
                                <th style="min-width: 80px;">收件人</th>
                                <th style="min-width: 80px;">主题内容</th>
                                <th style="min-width: 80px;">发送时间</th>
                                <th style="min-width: 80px;">状态</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpSendBox" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" data-attr="全选">
                                        <input type="checkbox" name="CheckBoxSend" id="CheckBoxSend" value='<%#Eval("ID") %>' runat="server" /></td>
                                    <td align="center" data-attr="收件人"><%#GetUserCode(Eval("ToUserID").ToString(), Eval("ToUserType").ToString())%></td>
                                    <td align="center" data-attr="主题内容"><a href="LeaveWordsDetail.aspx?id=<%#Eval("ID") %>&type=2" target="_self"><%#Eval("MsgTitle")%></a></td>
                                    <td align="center" data-attr="发送时间"><%#Convert.ToDateTime(Eval("LeaveTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                    <td align="center" data-attr="状态"><%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复"%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trSendNull" runat="server" class="none">
                            <td colspan="5" align="center">抱歉，目前数据库中暂无记录显示！</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                              <webdiyer:AspNetPager ID="anpSendMail" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="anpsendMail_PageChanged">
                        </webdiyer:AspNetPager>

                       
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
