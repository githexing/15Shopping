<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="Web.admin.business.Agent" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代开通运营中心</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" class="box_con" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">代开通运营中心查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="form-group">
                            <label class="control-label">会员编号:</label>
                            <input name="txtUserCode" id="txtUserCode" tip="输入会员编号" class="form-control" runat="server" type="text" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">会员姓名:</label>
                            <input name="txtTrueName" id="txtTrueName" tip="输入会员姓名" class="form-control" runat="server" type="text" />
                        </div>
                        <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search" OnClick="lbtnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                    </form>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 100px;">运营中心编号</th>
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">会员级别</th>
                                <th style="min-width: 80px;">代理区域</th>
                                <th style="min-width: 80px;">申请日期</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("AgentCode")%>
                                    </td>
                                    <td>
                                        <%# Eval("UserCode")%>
                                    </td>
                                    <td>
                                        <%#Eval("TrueName")%>
                                    </td>
                                    <td>
                                        <%#Eval("LevelName")%>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltlArea"></asp:Literal>
                                    </td>
                                    <td>
                                        <%#Eval("AppliTime")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbtnOpen" runat="server" CommandArgument='<%# Eval("ID") %>'
                                            class="btn btn-info" CommandName="Open" OnClientClick="javascript:return confirm('确定激活此运营中心？')"><i class="fa fa-key"></i>激活</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("ID") %>'
                                            class="btn btn-danger" CommandName="Remove" OnClientClick="javascript:return confirm('确定要删除此运营中心吗？')"><i class="fa fa-minus"></i>删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="divno" runat="server" class="none">
                            <td colspan="7" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
