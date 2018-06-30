<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManage.aspx.cs" Inherits="Web.admin.system.AdminManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <a href="AdminEdit.aspx" class="btn btn-primary"><i class="fa fa-plus"></i>添加管理员</a>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">管理员编号</th>
                                <th style="min-width: 80px;">姓名</th>
                                <th style="min-width: 80px;">注册日期</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpAdmin" runat="server" OnItemCommand="rpAdmin_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="管理员编号"><%#Eval("UserName")%></td>
                                    <td data-attr="姓名"><%#Eval("TrueName")%></td>
                                    <td data-attr="注册日期"><%#Eval("AddDate")%></td>
                                    <td data-attr="操作">
                                        <asp:LinkButton ID="LinkButton1" class="btn btn-info" iconcls="icon-edit" runat="server" Enabled='<%#Eval("ID").ToString()==getLoginID().ToString()?false:true %>'
                                            CommandName="modify" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" class="btn btn-danger" iconcls="icon-remove" runat="server" Enabled='<%#Eval("ID").ToString()==getLoginID().ToString()?false:true %>'
                                            CommandName="del" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-minus"></i>删除</asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trNull" runat="server" class="none">
                            <td colspan="4" align="center">抱歉！目前数据库暂无数据。</td>
                        </tr>
                    </table>
                </div>
                <div class="nextpage cBlack">
                      <webdiyer:AspNetPager ID="anpAdmin" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
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
    </form>
</body>
</html>
