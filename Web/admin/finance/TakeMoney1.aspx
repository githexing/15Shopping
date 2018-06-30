<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TakeMoney1.aspx.cs" Inherits="Web.admin.finance.TakeMoney1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>人文关怀管理</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.11.3.min.js"></script>
    
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
 <%--   <script src="../Scripts/main-layout.js" type="text/javascript"></script>--%>
    
</head>
<body >
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default" style="display:none">
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="form-group">
                            <asp:LinkButton ID="lbtnApply" runat="server" class="btn btn-primary" iconcls="icon-search" OnClick="lbtnApply_Click"><i class="fa fa-caret-square-o-up"></i> 申请记录 </asp:LinkButton>
                        </div>
                        <div class="form-group">
                            <asp:LinkButton ID="lbtnDraw" runat="server" class="btn btn-primary" iconcls="icon-search" OnClick="lbtnDraw_Click"><i class="fa fa-print"></i> 提现记录 </asp:LinkButton>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <%--<form class="form-inline">--%>
                        <div class="mb15">
                            <div class="form-group mt10" style="display:none">
                                <label class="control-label">已提现:</label>
                                <input name="txtMoney" id="txtMoney" tip="" disabled="disabled" class="form-control mwidth168" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input name="txtUserCode" id="txtUserCode" tip="输入会员编号" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员姓名:</label>
                                <input name="txtTrueName" id="txtTrueName" tip="输入会员姓名" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10" ">
                                <label class="control-label">审核类型:</label>
                                <asp:DropDownList ID="dropTypeDown" runat="server" CssClass="form-control" OnSelectedIndexChanged="dropTypeDown_SelectedIndexChanged" AutoPostBack="true">
                                 <asp:ListItem Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">未审核</asp:ListItem>
                                    <asp:ListItem Value="2">已审核</asp:ListItem>
                                     <%--  <asp:ListItem Value="3">动态月分红</asp:ListItem>
                                    <asp:ListItem Value="4">静态年分红</asp:ListItem>
                                    <asp:ListItem Value="5">动态年分红</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">申请日期:</label>
                                <asp:TextBox ID="txtStar" tip="输入提现日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入提现日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search" OnClick="lbtnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="lbtnExport" runat="server" class="btn btn-primary mr5" iconcls="icon-print"  Visible="false" OnClick="lbtnExport_Click"><i class="fa fa-download"></i> 导出Excel </asp:LinkButton>
                            </div>
                        </div>
                    <%--</form>--%>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr><th><input type="checkbox" value="0" class="allchoicebox" id="chioce" onclick="javascript:allChoice(this)" />选择</th>
                                <th style="min-width: 100px;">会员编号</th>
                                <th style="min-width: 80px;">会员昵称</th>
                                <th style="min-width: 80px;">申请日期</th>
                                <th style="min-width: 80px;">类型</th>
                                <th style="min-width: 80px;">申请金额</th> 
                                <th style="min-width: 80px;">实发</th>
                                <th style="min-width: 80px;">账户类型</th>
                                <th style="min-width: 80px;">账户名称</th>
                                <th style="min-width: 80px;">账号</th>
                                <th style="min-width: 80px;">开户名</th>
                                <th style="min-width: 80px;">支行</th>
                                <th style="min-width: 80px;">备注</th>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr><td><input type="checkbox" value="<%#Eval("ID")%>" class="choicebox" /></td>
                                    <td align="center">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("NiceName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TakeTime")%>
                                    </td>
                                    <td align="center">人文关怀</td>
                                    <td align="center">
                                        <%#Eval("TakeMoney")%>
                                    </td> 
                                    <td align="center">
                                        <%#Eval("RealityMoney")%>
                                    </td>
                                    <td align="center">
                                         银行卡
                                    </td>
                                    <td align="center">
                                        <%#Eval("BankName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BankAccount")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("BankAccountUser")%>
                                    </td>
                                     <td align="center">
                                        <%#Eval("BankBranch")%>
                                    </td>
                                     <td align="center">
                                        <%#Eval("Take004")%>
                                    </td>
                                    <td align="center">
                                        <asp:LinkButton ID="lbtnConfirm" CommandArgument='<%# Eval("ID") %>'  Visible='<%# Eval("Flag").ToString()=="0"?true:false %>' CommandName="Open"  OnClientClick="javascript:return confirm('确认审核吗？')"
                                            class="btn btn-info" iconcls="icon-ok" runat="server"><i class="fa fa-pencil"></i>确认</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnDelete" CommandArgument='<%# Eval("ID") %>' Visible='<%# Eval("Flag").ToString()=="0"?true:false %>' CommandName="Remove"
                                            class="btn btn-danger" iconcls="icon-no" runat="server" OnClientClick="javascript:return confirm('确认删除吗？')"><i class="fa fa-minus"></i> 删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="11" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div>
                     <%--   <input type="checkbox" value="0" class="allchoicebox"   onclick="javascript:allChoice2(this)" />全选
                        <input type="button" onclick="javascript:submitChoice()" value="一键确认" />--%>
                    </div>
                    <div class="nextpage cBlack">
                        <%--<webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>--%>
                           <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="转到" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                      
                    </div>
                    <script>
                        function allChoice(t) {
                            var che = $(t).is(':checked');
                            
                            $("table td [type='checkbox']").attr('checked', che);
                            $('.allchoicebox').attr('checked', che);
                        }
                        function allChoice2(t) {
                            var che = $(t).is(':checked');

                            $("table td [type='checkbox']").attr('checked', che);
                            $('.allchoicebox').attr('checked', che);
                        }
                        function submitChoice() {
                            var tid = "";
                            $('table td :checked').each(function () {
                                tid += $(this).val() + ",";
                            });
                            tid = tid.substring(0, tid.length - 1);

                            $.ajax({
                                url: 'TakeMoney.aspx',
                                type: 'GET', //GET
                                async: false,    //或false,是否异步
                                data: {
                                    tid: tid, action:"ajax"
                                },
                                timeout: 5000,    //超时时间
                                dataType: 'text',   //返回的数据格式：json/xml/html/script/jsonp/text
                                success: function (jsondata) {
                                    if (jsondata == "ok") {
                                        $('table td :checked').each(function () {
                                            $(this).parent().parent().find('.btn').hide();
                                        });
                                        $("table [type='checkbox']").attr('checked', false);
                                        alert("操作成功");
                                    }
                                    else alert("操作失败");
                                }
                            })
                        }
                    </script>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
