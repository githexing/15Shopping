<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeList.aspx.cs" Inherits="Web.admin.finance.TakeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="form-group">
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary" iconcls="icon-search"
                                OnClick="LinkButton1_Click"><i class="fa fa-caret-square-o-up"></i> 申请记录 </asp:LinkButton>
                        </div>
                        <div class="form-group">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary" iconcls="icon-search"
                                OnClick="LinkButton2_Click"><i class="fa fa-print"></i> 提现记录 </asp:LinkButton>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">已提现:</label>
                                <input name="Add_sscFd7" id="txtMoney" tip=""
                                    disabled="disabled" class="form-control mwidth168" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input name="Add_sscFd7" id="txtUserCode2" tip="输入会员编号" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员姓名:</label>
                                <input name="Add_sscFd7" id="txtTrueName" tip="输入会员姓名" class="form-control" runat="server" type="text" />
                            </div>
                             <div class="form-group mt10"  style="display:none;">
                                <label class="control-label">提现类型:</label>
                                <asp:DropDownList ID="dropDown" runat="server" class="form-control">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">日分红</asp:ListItem>
                                    <asp:ListItem Value="2">分享奖</asp:ListItem>
                                    <asp:ListItem Value="3">对碰奖</asp:ListItem>
                                    <asp:ListItem Value="4">见点奖</asp:ListItem>
                                    <asp:ListItem Value="5">达人收益</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">申请日期:</label>
                                <asp:TextBox ID="textStar" tip="输入提现日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="textEnd" tip="输入提现日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnSearch2_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary mr5" iconcls="icon-print"
                                    OnClick="daochu_Click"><i class="fa fa-download"></i> 导出Excel </asp:LinkButton>
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
                                <th style="min-width: 100px;">会员编号</th>
                                <th style="min-width: 80px;">会员昵称</th>
                                <th style="min-width: 80px;">申请日期</th>
                                <th style="min-width: 80px;">提现类型</th>
                                <th style="min-width: 80px;">提现金额</th>
                                <th style="min-width: 80px;">手续费</th>
                                <th style="min-width: 80px;">实发</th>
                                <th style="min-width: 80px;">账户类型</th>
                                <th style="min-width: 80px;">账户名称</th>
                                <th style="min-width: 80px;">账号</th>
                                <th style="min-width: 80px;">开户名</th>
                                <th style="min-width: 80px;">支行</th>
                               
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("NiceName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TakeTime")%>
                                    </td>
                                    <td align="center"><%# TakeType(Convert.ToInt32(Eval("Take001")))%></td>
                                    <td align="center">
                                        <%#Eval("TakeMoney")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TakePoundage")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("RealityMoney")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("AccountType")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BankName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BankAccount")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BankAccountUser")%>
                                    </td>
                                     <td align="center">
                                        <%#Eval("BankBranch")%>
                                    </td>

                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="7" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                         <webdiyer:AspNetPager ID="AspNetPager2" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager2_PageChanged">
                        </webdiyer:AspNetPager>
                      
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
