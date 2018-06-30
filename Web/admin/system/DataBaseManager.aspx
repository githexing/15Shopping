<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBaseManager.aspx.cs"
    Inherits="Web.admin.system.DataBaseManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>数据库管理</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form2" runat="server">
        <div class="contentpanel">
            <div class="panel panel-default">
                <div class="panel-body">
                   <%-- <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-save"
                        OnClick="btnBak_Click"><i class="fa fa-floppy-o"></i> 备份数据库 </asp:LinkButton>--%>
                    <asp:LinkButton ID="LinkButton1" Visible="true" runat="server" class="btn btn-primary mr5" iconcls="icon-cancel"
                        OnClick="btnClear_Click" OnClientClick="return confirm('确定要清空测试数据吗?')"><i class="fa fa-scissors"></i> 清空测试数据 </asp:LinkButton>
                </div>
            </div>
          <%--  <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">备份文件</th>
                                <th style="min-width: 80px;">备份日期</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="备份文件">
                                        <%#Eval("name")%>
                                    </td>
                                    <td data-attr="备份日期">
                                        <%#Eval("time")%>
                                    </td>
                                    <td data-attr="操作">
                                        <asp:LinkButton ID="lbtnH" Visible="false" runat="server" class="btn btn-info" iconcls="icon-back"
                                            CommandName="close" CommandArgument='<%#Eval("name") %>'><i class="fa fa-pencil">还原</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnX" runat="server" class="btn btn-danger" iconcls="icon-print"
                                            CommandName="open" CommandArgument='<%#Eval("name") %>'>下载</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnB" runat="server" class="btn btn-danger" iconcls="icon-no"
                                            CommandArgument='<%# Eval("name") %>' CommandName="que"><i class="fa fa-minus"></i>删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="3" align="center">暂无备份</td>
                        </tr>
                    </table>
                    <ul>
                           <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                     
                    </ul>
                </div>
            </div>--%>
        </div>
    </form>
</body>
</html>
