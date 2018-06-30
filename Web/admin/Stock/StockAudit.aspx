<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockAudit.aspx.cs" Inherits="Web.admin.Stock.StockAudit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>预购列表</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">预购列表查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <asp:TextBox ID="txtUserCode" tip="输入购买日期" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">购买日期:</label>
                                <asp:TextBox ID="txtStart" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search" OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
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
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">总购买金额</th>
                                <th style="min-width: 80px;">未购买金额</th>
                                <th style="min-width: 80px;">申请时间</th>
                                <th style="min-width: 80px;">状态</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Amount")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SurplusSum")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BuyDate")%>
                                    </td>
                                    <td align="center">
                                        <asp:Literal ID="ltIsBuy" runat="server"></asp:Literal>
                                    </td>
                                    <td align="center">
                                        <%--<asp:LinkButton ID="lbtnAudit" runat="server" CommandArgument='<%# Eval("StockBuyID") %>' class="easyui-linkbutton"
                                    iconcls="icon-ok" Visible='<%#Eval("IsBuy").ToString()=="0"?true:false %>' CommandName="Audit" OnClientClick="javascript:return confirm('确定要通过此申请吗？')">审核通过</asp:LinkButton>--%>&nbsp;&nbsp;<asp:LinkButton
                                        ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("StockBuyID") %>' class="btn btn-danger"
                                        iconcls="icon-no" Visible='<%#Eval("IsBuy").ToString()=="0"?true:false %>'
                                        CommandName="Remove" OnClientClick="javascript:return confirm('确定要删除此申请记录吗？')"><i class="fa fa-minus"></i>删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="6" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
