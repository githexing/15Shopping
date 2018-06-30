<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeManage.aspx.cs" Inherits="web.admin.system.NoticeManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>信息管理</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:LinkButton ID="lbtnAdd" runat="server" class="btn btn-primary" iconcls="icon-add" OnClick="lbtnAdd_Click"><i class="fa fa-plus"></i>发布信息</asp:LinkButton>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">ID</th>
                                <th style="min-width: 80px;">主题</th>
                                <th style="min-width: 80px;">类型</th>
                                <th style="min-width: 80px;">日期</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="ID"><%#Eval("XH")%></td>
                                    <td data-attr="主题"><a href="NoticeEdit.aspx?ID=<%# Eval("ID")%>"><%#Eval("NewsTitle")%></a></td>
                                    <td data-attr="类型">
                                        <asp:Literal ID="ltTypeName" runat="server"></asp:Literal></td>
                                    <td data-attr="日期"><%#Eval("PublishTime")%></td>
                                    <td data-attr="操作">
                                        <asp:LinkButton ID="lbtnEdit" runat="server" class="btn btn-info"
                                            iconcls="icon-edit" CommandName="modify" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnDel" runat="server" class="btn btn-danger" iconcls="icon-no" CommandName="del" OnClientClick="javascript:return confirm('确定要删除吗？')" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-minus"></i>删除</asp:LinkButton></td>
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
