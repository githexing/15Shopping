<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProLevelManage.aspx.cs" Inherits="Web.admin.team.ProLevelManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员升级</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">    
                <!-- panel-body -->
            
             </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">升级查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtUserCode" tip="输入会员编号" runat="server" class="form-control"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">升级日期:</label>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtStart" tip="输入升级日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                        <label class="control-label">至</label>
                                        <asp:TextBox ID="txtEnd" tip="输入升级日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group mt10">
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="搜 索" OnClick="btnSearch_Click" />
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
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">升级前级别</th>
                                <th style="min-width: 80px;">升级后级别</th>
                                <th style="min-width: 80px;">需缴金额</th>
                                <th style="min-width: 80px;">汇款金额</th>
                                <th style="min-width: 80px;">汇款具体时间</th>
                                <th style="min-width: 80px;">汇出银行</th>
                                <th style="min-width: 80px;">汇出账户</th>
                                <th style="min-width: 80px;">汇款备注</th>
                                <th style="min-width: 80px;">汇入银行</th>
                                <th style="min-width: 80px;">汇入账户</th>
                                <th style="min-width: 80px;">汇入开户名</th>
                                <th style="min-width: 80px;">申请日期</th>
                                <th style="min-width: 80px;">审核状态</th>
                            </tr>
                        </thead>
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Truename")%>
                                    </td>
                                     <td align="center">
                                        <%# levelBLL.GetLevelName(Convert.ToInt32(Eval("LastLevel")))%>
                                    </td>
                                    <td align="center">
                                        <%# levelBLL.GetLevelName(Convert.ToInt32(Eval("EndLevel")))%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("ProMoney")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("RemitMoney")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("RechargeableDate")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Remit003")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Remit004")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("Remark")%>
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
                                        <%#Eval("AddDate")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("State").ToString() == "0" ? "未审" : "已审"%>
                                    </td>
                                   <%-- <td align="center">--%>
                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="flag" class="easyui-linkbutton"
                                            iconcls="icon-ok" CommandArgument='<%#Eval("ID") %>' Visible='<%#Eval("State").ToString()=="0"?true:false %>'>审核</asp:LinkButton>
                                        <asp:Label ID="Label1" runat="server" Text="已审核" Visible='<%#Eval("State").ToString()=="1"?true:false %>'></asp:Label>--%>
                                        <%--<asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" class="easyui-linkbutton"
                                            iconcls="icon-no" CommandArgument='<%#Eval("ID") %>' Visible='<%#Eval("State").ToString()=="0"?true:false %>'>删除</asp:LinkButton>--%>
                                  <%--  </td>--%>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="7" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
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
