<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferBonus.aspx.cs" Inherits="Web.user.finance.TransferBonus" %>

<!DOCTYPE html>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Admin</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <link rel="stylesheet" type="text/css" href="../../css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <!-- BEGIN PAGE CONTAINER-->
        <div class="page-content">
            <div class="content">
                <div class="page-title">
                    <h3>转账管理</h3>
                </div>
                <div id="container">
                    <div class="row m-b-20">
                        <div class="col-md-12">
                            <div class="grid simple">
                                <div class="grid-title">
                                    <h4>个人账户</h4>
                                </div>
                                <div class="grid-body no-border">
                                    <div class="row-fluid ">
                                        <div class="col-md-6">
                                            <address class="margin-bottom-20 margin-top-10">
                                                <strong>奖金积分：</strong>
                                                <span>
                                                    <%=LoginUser.BonusAccount.ToString() %>
                                                </span>
                                            </address>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row m-b-20">
                        <div class="col-md-12">
                            <div class="grid simple">
                                <div class="grid-title">
                                    <h4>我要转账</h4>
                                </div>
                                <div class="grid-body no-border">
                                    <div class="form-horizontal col-sm-12">
                                        <div class="form-group">
                                            <label class="col-md-2 control-label"><%=GetLanguage("TransferType")%><!--转账类型-->：</label>
                                            <div class="col-md-5">
                                                <asp:UpdatePanel ID="UpdatePane1" runat="server">
                                                <ContentTemplate>
                                                <asp:DropDownList ID="dropCurrency" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCurrency_SelectedIndexChanged"></asp:DropDownList>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-2 control-label"><%=GetLanguage("MembershipNumber")%><!--会员编号-->：</label>
                                            <div class="col-md-5">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                <asp:TextBox runat="server" ID="txtUserCode" class="form-control" Text="" AutoPostBack="true" OnTextChanged="txtUserCode_TextChanged"></asp:TextBox>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-2 control-label"><%=GetLanguage("MemberName")%><!--会员姓名-->：</label>
                                            <div class="col-md-5">
                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                <ContentTemplate>
                                                <asp:TextBox runat="server" ID="txtTrueName" class="form-control" Text="" Enabled="false"></asp:TextBox>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-2 control-label"><%=GetLanguage("TransferScore")%><!--转账积分-->：</label>
                                            <div class="col-md-5">
                                                <%--<input type="number" id="cashMoney" onchange="$('#cashActual').val(($(this).val()*.95).toFixed(2))" class="form-control">--%>
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                <asp:TextBox ID="txtScore" class="form-control" runat="server" type="text"
                                                    onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                                    AutoPostBack="True" OnTextChanged="txtScore_TextChanged" />
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-md-2 control-label"><%=GetLanguage("ActualScore")%><%--到账积分--%>：</label>
                                            <div class="col-md-5">
                                                <%--<input type="number" id="cashActual" class="form-control" readonly="readonly">--%>
                                                <input type="text" id="txtActualScore" runat="server" disabled="disabled" class="form-control" name="txtActualScore" />
                                            </div>
                                        </div>
                                        <div class="form-group m-b-0">
                                            <div class="col-sm-offset-2 col-sm-10">
                                                <asp:Button ID="btnSubmit" runat="server" Text="提交" class="btn btn-primary" OnClick="btnSubmit_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row m-b-20">
                        <div class="col-md-12">
                            <div class="grid simple">
                                <div class="grid-title">
                                    <h4>转账列表</h4>
                                </div>
                                <div class="grid-title">
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <label class="inline"><%=GetLanguage("CurrencyType")%><!--币种--></label>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                            <asp:DropDownList ID="dropType" class="form-control" runat="server" OnSelectedIndexChanged="dropType_SelectedIndexChanged"></asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="form-group">
                                            <label class="inline"><%=GetLanguage("DateTransfer")%><!--转账日期--></label>
                                            <div class="input-group">
                                                <div class="input-append date">
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                                        {%>
                                                    <asp:TextBox ID="txtStart" runat="server" class="form-control" name="start" onfocus="WdatePicker()"></asp:TextBox>
                                                    <%}
                                                        else
                                                        {%>
                                                    <asp:TextBox ID="txtStartEn" runat="server" class="form-control" name="start" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                                    <%} %>
                                                    <span class="add-on hidden"></span>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <span class="input-group-addon"><%=GetLanguage("To")%></span>
                                                <div class="input-append date">
                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                    <ContentTemplate>
                                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                                        {%>
                                                    <asp:TextBox ID="txtEnd" runat="server" class="form-control" name="end" onfocus="WdatePicker()"></asp:TextBox>
                                                    <%}
                                                        else
                                                        {%>
                                                    <asp:TextBox ID="txtEndEn" runat="server" class="form-control" name="end" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                                    <%} %>
                                                    <span class="add-on hidden"></span>
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                                <div class="grid-body no-border">
                                    <div class="table-over">
                                        <table class="table no-more-tables table-hover">
                                            <thead>
                                                <tr>
                                                    <th><%=GetLanguage("MembershipNumber")%><%--会员编号--%></th>
                                                    <th><%=GetLanguage("MemberName")%><%--会员姓名--%></th>
                                                    <th><%=GetLanguage("TransferType")%><%--转账类型--%></th>
                                                    <th><%=GetLanguage("TransferScore")%><%--转账积分--%></th>
                                                    <th><%=GetLanguage("ActualScore")%><%--到账积分--%></th>
                                                    <th><%=GetLanguage("DateTransfer")%>D<%--转账日期--%></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                <ContentTemplate>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td data-title="会员编号"><%#Eval("UserCode")%></td>
                                                            <td data-title="会员姓名"><%#Eval("TrueName")%></td>
                                                            <td data-title="转账类型"><%#ChangeType(Convert.ToInt32(Eval("ChangeType")))%></td>
                                                            <td data-title="转账积分"><%#Eval("Amount")%></td>
                                                            <td data-title="到账积分"><%#Eval("Change005")%></td>
                                                            <td data-title="转账日期"><%#Eval("ChangeDate")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </tbody>
                                            <tr id="tr1" runat="server">
                                                <td colspan="6" class="colspan">
                                                    <div class="text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="text-right">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" AlwaysShow="True"
                                            InputBoxClass="pageinput" NumericButtonCount="3" PageSize="10" ShowInputBox="Never"
                                            ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"
                                            pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="" OnPageChanged="AspNetPager1_PageChanged">
                                        </webdiyer:AspNetPager>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" src="../../js/jquery-1.11.3.min.js"></script>
        <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
        <script type="text/javascript" src="../../js/bootstrap-datepicker.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                //选择日期
                $('.input-append.date').datepicker({
                    autoclose: true,
                    todayHighlight: true,
                    format: 'yyyy-mm-dd'
                })
            })
        </script>
    </form>
</body>
</html>