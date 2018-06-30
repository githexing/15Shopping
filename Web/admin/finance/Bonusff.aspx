<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonusff.aspx.cs" Inherits="Web.admin.finance.Bonusff" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>奖金结算</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

</head>
<body>
    <form id="Form1" class="box_con" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="row">
                <div class="col-md-4">
                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-block btn-lg btn-rounded btn-primary" iconcls="icon-save"
                        OnClick="LinkButton1_Click" OnClientClick="javascript:return confirm('确定要释放原始币吗？')">释放原始币</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-block btn-lg btn-rounded btn-primary" iconcls="icon-save"
                        OnClick="LinkButton2_Click" OnClientClick="javascript:return confirm('确定要发放静态收益吗？')">静态收益</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-block btn-lg btn-rounded btn-primary" iconcls="icon-save"
                        OnClick="LinkButton3_Click" OnClientClick="javascript:return confirm('确定要发放动态收益吗？')">动态收益</asp:LinkButton>
                </div>
            </div>
            <br />
            <br />
            <div class="panel panel-default" style="display:none;">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;text-align:center;">操作名称</th>
                                <th style="min-width: 80px;text-align:center;">操作时间</th>
                                <th style="min-width: 80px;text-align:center;">完成时间</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>

                                        <td data-attr="操作名称">
                                            <%#Eval("LogCode")%><!--1.操作名称-->
                                        </td>
                                        <td data-attr="操作时间">
                                            <%#Eval("LogDate")%><!--2.操作时间-->
                                        </td>
                                        <td data-attr="完成时间">
                                            <%#Eval("Log4")%><!--完成时间-->
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            <tr id="tr1" runat="server">
                                <td colspan="8" align="center" class="none">抱歉！目前暂无数据显示。</td>
                            </tr>
                        </tbody>
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
                <!-- row -->
            </div>
        </div>

    </form>
</body>
</html>
