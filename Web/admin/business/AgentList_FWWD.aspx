<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentList_FWWD.aspx.cs" Inherits="Web.admin.business.AgentList_FWWD" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>已开通服务网点</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">已开通服务网点查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input name="Add_sscFd7" id="txtUserCode" tip="输入会员编号" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员姓名:</label>
                                <input name="Add_sscFd7" id="txtTrueName" tip="输入会员姓名" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10" style="display:none">
                                <label class="control-label">会员级别:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList runat="server" ID="dropLevel" class="width100p selectval mwidth168"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">开通日期:</label>
                                <asp:TextBox ID="textStar" tip="输入开通日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="textEnd" tip="输入开通日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnSearch2_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="LinkButton1_Click" OnClientClick="return confirm('确定要导出数据吗?')"><i class="fa fa-download"></i> 导 出 </asp:LinkButton>
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
                                <th style="min-width: 100px;">服务网点编号</th>
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">会员级别</th>
                                <th style="min-width: 80px;">代理区域</th>
                                <th style="min-width: 80px;">申请日期</th>
                                <th style="min-width: 80px;">确认日期</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand" OnItemDataBound="Repeater2_ItemDataBound">
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
                                        <%#Eval("OpenTime")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="close" CommandArgument='<%#Eval("ID") %>'
                                            class="btn btn-danger" iconcls="icon-no" Visible='<%#Eval("Flag").ToString()=="1"?true:false %>'><i class="fa fa-minus"></i>冻结</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="open" CommandArgument='<%#Eval("ID") %>'
                                            class="btn btn-danger" iconcls="icon-ok" Visible='<%#Eval("Flag").ToString()=="2"?true:false %>'>解冻</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("ID") %>'
                                            class="btn btn-primary" iconcls="icon-search" CommandName="list"><i class="fa fa-share-square-o"></i>会员列表</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="8" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Right" OnPageChanged="AspNetPager2_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
