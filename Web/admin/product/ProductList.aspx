<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="web.admin.product.ProductList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>商品列表</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../../SpryAssets/imgbox/jquery.min.js" type="text/javascript"></script>
    <script src="../../SpryAssets/imgbox/jquery.imgbox.pack.js" type="text/javascript"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <style type="text/css">
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
        });
    </script>
</head>
<body>
    <form id="Form1" runat="server"  class="form-inline">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline" >
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">商品编号:</label>
                                <input type="text" id="txtCode" tip="输入商品编号" name="textfield" runat="server" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">商品名称:</label>
                                <input type="text" id="txtName" name="textfield" runat="server" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5 mb10" iconcls="icon-search"
                                    OnClick="lbtnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="lbtnAdd" runat="server" class="btn btn-primary mb10" iconcls="icon-add"
                                    OnClick="lbtnAdd_Click"><i class="fa fa-plus"></i> 发布商品 </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">商品编号</th>
                                <th style="min-width: 80px;">商品名称</th>
                                <th style="min-width: 80px;">一级分类</th>
                                <%--<th style="min-width: 80px;">二级分类</th>
                                <th style="min-width: 80px;">三级分类</th>--%>
                                <th style="min-width: 80px;">市场价</th>
                                <th style="min-width: 80px;">状态</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("GoodsCode")%>
                                    </td>
                                    <td>
                                        <span title=' <%#Eval("GoodsName")%>'><%#Eval("GoodsName").ToString().Length>6?Eval("GoodsName").ToString().Substring(0,6)+"..":Eval("GoodsName") %></span>
                                    </td>
                                    <td>
                                        <%#Eval("TypeName")%>
                                    </td>
                                   <%-- <td>
                                        <span title=' <%#Eval("TypeName")%>'><%#Eval("TypeName").ToString().Length > 4 ? Eval("TypeName").ToString().Substring(0, 4) + ".." : Eval("TypeName")%></span>
                                    </td>
                                    <td>
                                        <%#Eval("SypeName") %>
                                    </td>--%>
                                    <td>
                                        <%#Eval("Price")%>
                                    </td>
                                    <td>
                                        <%# Eval("StateType").ToString() == "1" ? "审核通过" : "审核中"%>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lbtnAudit" runat="server" CommandName="Audit" class="btn btn-success mb5"
                                            iconcls="icon-edit" CommandArgument='<%# Eval("ID") %>'> <%# Eval("StateType").ToString() == "0" ? "审核通过" : "审核不通过"%><i class="fa fa-check-square-o"></i></asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="edit" class="btn btn-info mb5"
                                    iconcls="icon-edit" CommandArgument='<%# Eval("ID") %>'><i class="fa fa-pencil"></i>编 辑</asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="up" Visible='<%#Eval("Goods001").ToString()=="0"?true:false %>'
                                    class="btn btn-info mb5" iconcls="icon-add" CommandArgument='<%# Eval("ID") %>'><i class="fa fa-cloud-upload"></i>上 架</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="down" Visible='<%#Eval("Goods001").ToString()=="1"?true:false %>'
                                            class="btn btn-info mb5" iconcls="icon-remove" CommandArgument='<%# Eval("ID") %>'><i class="fa fa-cloud-download"></i>下 架</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" class="btn btn-danger mb5" iconcls="icon-no" OnClientClick="return confirm('确定要删除吗！')" CommandArgument='<%# Eval("ID") %>'><i class="fa fa-minus"></i>删 除</asp:LinkButton>&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr align="center" runat="server" id="tr1" class="none">
                            <td colspan="8" style="border: 0">抱歉，目前数据库中暂无记录显示！</td>
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
