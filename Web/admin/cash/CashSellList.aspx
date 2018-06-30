<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashSellList.aspx.cs" Inherits="Web.admin.cash.CashSellList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>交易平台购买列表</title>
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
    <form id="form1" class="box_con" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">交易平台购买查询</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">选择下拉:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropType" runat="server" class="width100p selectval mwidth168">
                                        <asp:ListItem Value="0">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">会员编号</asp:ListItem>
                                        <asp:ListItem Value="2">会员姓名</asp:ListItem>
                                        <asp:ListItem Value="3">订单编号</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <input name="txtInput" id="txtInput" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">订单状态:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropState" runat="server" class="width100p selectval mwidth168">
                                        <asp:ListItem Value="-2">全部</asp:ListItem>
                                        <asp:ListItem Value="-1">已撤销</asp:ListItem>
                                        <asp:ListItem Value="0">挂单中</asp:ListItem>
                                        <asp:ListItem Value="1">已完成</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">购买日期:</label>
                                <asp:TextBox ID="txtStart" tip="输入购买日期" runat="server" onfocus="WdatePicker()" CssClass="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入购买日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">订单编号</th>
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">出售价格</th>
                                <th style="min-width: 80px;">出售总数</th>
                                <th style="min-width: 80px;">已售数量</th>
                                <th style="min-width: 80px;">剩余数量</th>
                                <th style="min-width: 80px;">购买时间</th>
                                <th style="min-width: 80px;">状态</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater runat="server" ID="Repeater1" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("OrderCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TrueName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Price")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Number")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SaleNum")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SurplusNum")%>
                                    </td>
                                    <td align="center">
                                        <asp:Literal runat="server" ID="ltStateName"></asp:Literal>
                                    </td>
                                    <td align="center">
                                        <%#Eval("SellDate")%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("CashsellID") %>' class="btn btn-danger"
                                            iconcls="icon-no" Visible='<%#Eval("IsSell").ToString()=="0"?true:false %>'
                                            CommandName="cancel" OnClientClick="javascript:return confirm('确定要撤销此订单吗？')"><i class="fa fa-minus"></i>撤销</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="9" align="center">抱歉！目前数据库暂无数据显示。</td>
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