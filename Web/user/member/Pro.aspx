	<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pro.aspx.cs" Inherits="Web.user.member.Pro" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>会员升级</title>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- BEGIN PAGE CONTAINER-->
        <div class="page-content">
            <div class="content">
                <div class="page-title">
                    <h3>会员升级</h3>
                </div>
                <div id="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="grid simple line">
                                <div class="grid-title">
                                    <div class="form-inline form-search">
                                        <div class="form-group">
                                            <label class="inline">会员编号:</label>
                                            <%--<input type="text" class="form-control" value="">--%>
                                            <asp:Label ID="lblUserCode" runat="server" class="input-append date" Text=""></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="inline">会员姓名:</label>
                                            <asp:Label ID="lblTrueName" runat="server" class="input-append date" Text=""></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="inline">会员级别:</label>
                                            <asp:Label ID="lblLevel" runat="server" class="input-append date" Text=""></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="inline">奖金余额:</label>
                                            <asp:Label ID="lbBonusAccout" runat="server" class="input-append date" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="grid-title">
                                    <div class="form-inline form-search">
                                        <div class="form-group">
                                            <label class="inline">升级级别:</label>
                                            <div class="input-group">
                                                <div class="input-append date">
                                                    <%--<input type="text" class="form-control" name="start">--%>
                                                    <asp:DropDownList ID="ddlLevel" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>
                                                    <span class="add-on hidden"></span>
                                                </div>
                                                <span class="input-group-addon">需缴纳金额($)</span>
                                                <div class="input-append date">
                                                    <%--<input type="text" class="form-control" name="end">--%>
                                                    <input name="jd" type="text" id="txtMoney" runat="server" disabled="disabled" class="form-control" />
                                                    <span class="add-on hidden"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="提 交" OnClick="btnSubmit_Click" />
                                        <%-- <button type="submit" class="btn btn-primary"><i class="fa fa-search"></i>搜索</button>--%>

                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="grid-body no-border">
                                    <div class="table-over">
                                        <table class="table no-more-tables table-hover">
                                            <thead>
                                                <tr>
                                                    <th>升级前级别</th>
                                                    <th>升级后级别</th>
                                                    <th>需缴金额($)</th>
                                                    <th>申请日期</th>
                                                    <th>审核日期</th>
                                                    <th>状态</th>
                                                    <th>备注</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td data-title="升级前级别"><%# getLastLevel(Convert.ToInt32(Eval("LastLevel")))%></td>
                                                            <td data-title="升级后级别"><%# getLastLevel(Convert.ToInt32(Eval("EndLevel")))%></td>
                                                            <td data-title="需缴金额($)"><%#Eval("ProMoney")%></td>
                                                            <td data-title="申请日期"><%#Eval("AddDate")%></td>
                                                            <td data-title="审核日期"><%#Eval("FlagDate")%></td>
                                                            <td data-title="状态"><%#Eval("Flag").ToString() == "0" ? "未审核" : "已审核"%></td>
                                                            <td data-title="备注"><%#Eval("Remark")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="6" class="colspan">
                                                        <div class="text-center"><i class="fa fa-warning text-warning"></i>抱歉！目前数据库中暂无记录显示</div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <div class="text-right">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" OnPageChanged="AspNetPager1_PageChanged"
                                            AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                                            PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                                            UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText="">
                                        </webdiyer:AspNetPager>
                                    </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- ENG PAGE CONTAINER-->
        <!-- END CONTAINER -->
        <!-- BEGIN JS DEPENDECENCIES-->
        <!-- END CORE JS DEPENDECENCIES-->
        <!-- BEGIN CORE TEMPLATE JS -->
        <!-- END CORE TEMPLATE JS -->
        <script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/bootstrap-datepicker.js"></script>
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
