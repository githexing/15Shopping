<%@ Page Title="tb_Link" Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs"
    Inherits="lgk.Web.tb_Link.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接设置</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div class="contentpanel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">友情链接设置</h4>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:LinkButton ID="lbtnAdd" runat="server" class="btn btn-primary mr5" OnClick="lbtnAdd_Click"><i class="fa fa-plus"></i>添加链接</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">序号</th>
                                <th style="min-width: 80px;">网站名称</th>
                                <th style="min-width: 80px;">网站网址</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <%#Eval("Status")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("LinkName")%>
                                    </td>
                                    <td align="center">
                                        <a href='<%#Eval("LinkUrl")%>' target="_blank">
                                            <%#Eval("LinkUrl")%></a>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-info" PostBackUrl='<%#Eval("ID","Add.aspx?id={0}&Link001=1") %>'><i class="fa fa-pencil"></i>编辑</asp:LinkButton>
                                        <a href="delete.aspx?id=<%#Eval("ID") %>&p=List" class="btn btn-danger"><i class="fa fa-minus"></i>删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trBonusNull" runat="server" class="none">
                            <td colspan="15" align="center">抱歉！目前数据库暂无数据显示。</td>
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
