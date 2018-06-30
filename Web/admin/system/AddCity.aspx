<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCity.aspx.cs" Inherits="Web.admin.system.AddCity" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <script type="text/javascript" src="/JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="/JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/js/superValidator.js"></script>
    <script src="/Scripts/main-layout.js" type="text/javascript"></script>
    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
    <script type="text/javascript">
    function check() {
        var k ="//S+/.[xls]/";  
        if(!k.test(document.getElementById("fileId").value)) {
            alert("只能上次xls格式的文件");
            return false;
        }
        return true;
    }
</script>  
</head>
<body>
    <form id="form2" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">新增</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">地区名称:</label>
                                <input id="city" type="text" runat="server" class="form-control" size="20" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">机场名称:</label>
                                <input id="textName" type="text" runat="server" class="form-control" size="20" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">三字代码:</label>
                                <input id="textCode" type="text" runat="server" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                <asp:FileUpload ID="fu_excel" runat="server"  />  
                                <asp:LinkButton runat="server" class="btn btn-success mr5" iconcls="icon-ok" ID="daoru" OnClientClick="return check()" OnClick="daoru_Click">导入机场地区</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success mr5" iconcls="icon-ok" OnClick="LinkButton2_Click"><i class="fa fa-check"></i>添加机场地区 </asp:LinkButton>
                                <a class="btn btn-success mr5" id="train" onclick="onupdate()"><i class="fa fa-check"></i> 更新火车票城市代码 </a>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">地区名称</th>
                                <th style="min-width: 80px;">机场名称</th>
                                <th style="min-width: 80px;">三字代码</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpBank" runat="server" OnItemCommand="rpBank_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="地区名称">
                                        <%#Eval("City")%>
                                    </td>
                                    <td data-attr="机场名称">
                                        <%#Eval("Name")%>
                                    </td>
                                    <td data-attr="三字代码">
                                        <%#Eval("Code")%>
                                    </td>
                                    <td data-attr="操作">
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" class="btn btn-danger"
                                            iconcls="icon-no" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-minus"></i>删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trNull" runat="server" class="none">
                            <td colspan="4" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                            <webdiyer:AspNetPager ID="anpCity" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="anpCity_PageChanged">
                        </webdiyer:AspNetPager>
                   
                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript" src="/JS/jquery.min.js"></script>
        <script type="text/javascript">
            function onupdate() {
                $.ajax({
                    url: "/APPService/TrainTickets.ashx?act=citycode&stationName=&all=1",
                    type: 'post',
                    dataType: 'json',
                    success: function (data) {
                        if (data.state == "success") {
                            alert("更新成功");
                        } else {
                            alert(data.message);
                        }
                    },
                    error: function () {
                        alert("查询异常！");
                    }
                })
            }
        </script>
    </form>
</body>
</html>
