<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QQSet.aspx.cs" Inherits="Web.admin.system.QQSet" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>QQ客服設置</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />


    <script type="text/javascript" src="../../JS/jquery-1.11.3.min.js"></script>

    <script type="text/javascript" src="../../js/superValidator.js"></script>

    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">添加</h4>
            </div>
            <div class="panel-body">
                <form class="form-inline" action="#">
                    <div class="mb15">
                        <div class="form-group mt10">
                            <label class="control-label">客服名称:</label>
                            <input id="txtName" type="text" runat="server" class="form-control" size="20" />
                        </div>
                        <div class="form-group mt10">
                            <label class="control-label">客服号码:</label>
                            <input id="txtQQnumber" type="text" runat="server" class="form-control" />
                        </div>
                       <%-- <div class="form-group mt10">
                            <label class="control-label">类型:</label>
                            <div class="form-control nopadding noborder">
                                <input id="chkGroup" type="checkbox" runat="server" />
                                选中则是输入微信群号码，不选为微信号
                            </div>
                        </div>--%>
                        <div class="form-group mt10">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success mr5"
                                iconcls="icon-ok" OnClick="btnSave_Click"><i class="fa fa-check"></i>添加 </asp:LinkButton>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <table class="table table-bordered table-primary mb30">
                    <thead>
                        <tr>
                            <th style="min-width: 80px;">客服名称</th>
                            <th style="min-width: 80px;">号码</th>
                           <%-- <th style="min-width: 80px;">类型</th>--%>
                            <th style="min-width: 80px;">操作</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rpBank" runat="server" OnItemCommand="rpBank_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("ServiceName")%>
                                </td>
                                <td>
                                    <%#Eval("QQnum")%>
                                </td>
                                <%--<td>
                                    <%#Convert.ToInt32(Eval("QQType"))==1? "QQ群":"QQ号"%>
                                </td>--%>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="modify" class="btn btn-info"
                                        iconcls="icon-edit" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i>编辑</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" class="btn btn-danger"
                                        iconcls="icon-no" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-minus"></i>删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trNull" runat="server" class="none">
                        <td colspan="4" align="center">抱歉！目前数据库中暂无记录显示。</td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
                    <%--<webdiyer:AspNetPager ID="anpBank" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="anpBank_PageChanged" PrevPageText="上一页"
                        AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12"
                        ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>--%>
                    
                        <webdiyer:AspNetPager ID="anpBank" runat="server"    CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                                                  NumericButtonCount="3" PageSize="12"  
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"   PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                                               OnPageChanged="anpBank_PageChanged">
                                            </webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

