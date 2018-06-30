<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMoney.aspx.cs" Inherits="Web.admin.finance.AddMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>账户充值</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">账户充值</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <asp:TextBox ID="txtUserCode" class="form-control" runat="server" tip="输入会员编号"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">币种类型:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropMoneyType" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="奖金积分"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="电子积分"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="消费积分"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="报单积分"></asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">充值类型:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropRechargeStyle" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="增加"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="扣除"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">充值金额:</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtMoney" class="form-control" runat="server" min="0" precision="2" tip="输入充值金额"></asp:TextBox>
                                    <span class="input-group-addon">元</span>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="btnSub" runat="server" class="btn btn-success mr5"
                                    iconcls="icon-ok" OnClientClick="javascript:return confirm('确认给该会员充值？')" OnClick="btnSub_Click"><i class="fa fa-check"></i> 提 交 </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">账户充值查询</h4>
                </div>
                <div class="panel-body">
                    
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <asp:TextBox ID="usercode" runat="server" CssClass="form-control" ></asp:TextBox>
                                <%--<asp:TextBox ID="txtCode" runat="server" tip="输入会员编号" class="form-control"></asp:TextBox>--%>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">充值类型:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropType" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="增加"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="扣除"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">充值日期:</label>
                                <asp:TextBox ID="txtStart" tip="输入充值日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入充值日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSubmit_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
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
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">充值金额</th>
                                <th style="min-width: 80px;">充值类型</th>
                                <th style="min-width: 80px;">币种类型</th>
                                <th style="min-width: 80px;">充值方式</th>
                                <th style="min-width: 80px;">充值结果</th>
                                <th style="min-width: 80px;">充值日期</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="会员编号">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td data-attr="充值金额">
                                        <%#Eval("RechargeableMoney")%>
                                    </td>
                                    <td data-attr="充值类型">
                                        <%#Eval("RechargeStyle").ToString() == "1" ? "增加" : "减少"%>
                                    </td>
                                    <td data-attr="币种类型">
                                        <%#RechargeType(Convert.ToInt32(Eval("RechargeType")))%>
                                    </td>
                                    <td data-attr="充值方式">
                                        <%#Eval("Recharge001").ToString() == "0" ? "后台充值" :""%>
                                    </td>
                                    <td data-attr="充值结果">
                                        <%#Eval("Flag").ToString() == "1" ? "<span class='badge badge-success'>成功</span>" :"<span class='badge badge-success'>失败</span>"%>
                                    </td>
                                    <td data-attr="充值日期">
                                        <%#Eval("RechargeDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="7" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                         <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

