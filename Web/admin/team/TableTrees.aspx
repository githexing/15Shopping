<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TableTrees.aspx.cs" Inherits="Web.admin.team.TableTrees" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <!-- BEGIN PAGE CONTAINER-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        <h3><%=GetLanguage("MemberList")%><%--会员列表--%></h3>
                    </div>
                    <div id="panel-body">
                        <div class="mb15">

                            <div class="form-group mt10">
                                <label class="inline"><%=GetLanguage("MembershipNumber")%><%--会员编号--%></label>
                                <input name="txtUserCode" id="txtUserCode" runat="server" class="form-control" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="inline"><%=GetLanguage("OpeningDate")%><%--开通日期--%></label>
                                <div class="input-group">
                                    <div class="input-append date">
                                        <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <%--<input type="text" >--%>
                                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                                    {%>
                                                <asp:TextBox ID="txtStart" tip="开通日期" runat="server" onfocus="WdatePicker()" class="form-control" name="start"></asp:TextBox>
                                                <%}
                                                    else
                                                    {%>
                                                <asp:TextBox ID="txtStartEn" tip="Opening date" runat="server" onfocus="WdatePicker({lang:'en'})" class="form-control" name="start"></asp:TextBox>
                                                <%} %>
                                                <span class="add-on hidden"></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <span class="input-group-addon"><%=GetLanguage("To")%><%--至--%></span>
                                    <div class="input-append date">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                                    {%>
                                                <asp:TextBox ID="txtEnd" tip="开通日期" runat="server" onfocus="WdatePicker()" class="form-control" name="end"></asp:TextBox>
                                                <%}
                                                    else
                                                    {%>
                                                <asp:TextBox ID="txtEndEn" tip="Opening date" runat="server" onfocus="WdatePicker({lang:'en'})" class="form-control" name="end"></asp:TextBox>
                                                <%} %>
                                                <span class="add-on hidden"></span>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <%--<button type="submit" ><i class="fa fa-search"></i>搜索</button>--%>
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-primary" />
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <table class="table table-bordered table-primary mb30">
                                    <thead>
                                        <tr>
                                            <th><%=GetLanguage("MembershipNumber")%><!--会员编号--></th>
                                            <th><%=GetLanguage("MemberName")%><!--会员姓名--></th>
                                            <th>是否开通<!--会员姓名--></th>
                                            <%--<th><%=GetLanguage("MembershipLevels")%><!--会员级别--></th>--%>
                                            <th><%=GetLanguage("ReferenceNumber")%><!--推荐人编号--></th>
                                            <th><%=GetLanguage("RegistrationHours")%><!--注册日期--></th>
                                            <th><%=GetLanguage("OpeningDate")%><!--开通日期--></th>
                                            <th>操作<!--开通日期--></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td data-attr="会员编号">
                                                                <a href="../business/UserDetail.aspx?UserID=<%# Eval("UserID")%>">
                                                                    <%# Eval("UserCode")%></a>
                                                            </td>
                                                            <td data-attr="会员姓名">
                                                                <%#Eval("NiceName")%>
                                                            </td>
                                                            <td data-attr="是否开通"><%# (Eval("IsOpend").ToString()=="0" ? "未开通":"已开通")%></td>
                                                           <%-- <td>
                                                                <%#Eval("LevelName")%>
                                                            </td>--%>

                                                            <td data-attr="推荐人编号">
                                                                <%#Eval("RecommendCode")%>
                                                            </td>
                                                            <td data-attr="注册时间">
                                                                <%#Eval("RegTime")%>
                                                            </td>
                                                            <td data-attr="开通日期">
                                                                <%#Eval("OpenTime")%>
                                                            </td>
                                                            <td data-attr="操作">
                                                                <asp:LinkButton ID="lbtnRemove" runat="server" CommandArgument='<%# Eval("UserID") %>' class="btn btn-danger" ommandName="Remove" OnClientClick="javascript:return confirm('确定要删除此会员吗？')"><i class="fa fa-minus"></i>删除</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <tr id="tr1" runat="server">
                                            <td colspan="6" class="colspan">
                                                <div class="text-center">
                                                    <i class="fa fa-warning text-warning"></i>
                                                    <%-- 抱歉！目前数据库暂无数据显示。--%>
                                                    <%=GetLanguage("Manager")%>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="nextpage cBlack">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                    FirstPageText="首页"
                                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                    SubmitButtonClass="pagebutton" UrlPaging="false" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                                    SubmitButtonText="转到" TextAfterPageIndexBox=" 页" TextBeforePageIndexBox="转到 " Direction="LeftToRight"
                                    HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                                </webdiyer:AspNetPager>
                            </div>
                            </div>
                            
                        </div>
                    </div>

                </div>
            </div>
            <!-- ENG PAGE CONTAINER-->
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
