<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSet.aspx.cs" Inherits="Web.admin.system.AccountSet" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>账户設置</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <%--<script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>--%>
    <script type="text/javascript" src="../../js/superValidator.js"></script>
    <%--<script src="../Scripts/main-layout.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            setAllCheck("textBankName:textBankAccountUser");
            setIntegeCheck("textBankAccount");
            $('#dropAccount').on('change', function () {
                var bankname;
                var bankaccount;
                index = $(this).val();

                switch (index) {
                    case '1': bankname = '银行名称'; bankaccount = '银行账号'; $('.bankaddressarea').show(); $('.bankuserarea').show(); break;
                    //case '2': bankname = '昵称'; bankaccount = '微信号'; $('.bankaddressarea').hide(); $('.bankuserarea').hide(); break;
                    //case '3': bankname = '昵称'; bankaccount = '支付宝号'; $('.bankaddressarea').hide(); $('.bankuserarea').hide(); break;
                }

                $('.bankname').text(bankname);
                $('.bankaccount').text(bankaccount);
            });
        });
    </script>
    <style type="text/css">
        .red {
            color: Red;
        }
        .control-label {min-width:100px;}
        .form-control{min-width:300px;}
    </style>
</head>
<body>
    <form id="form2" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">账户设置</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">帐户类型:</label>
                                <asp:DropDownList runat="server" ID="dropAccount" class="form-control">
                                    <asp:ListItem Value="1">银行</asp:ListItem>
                                 <%--   <asp:ListItem Value="2">微信</asp:ListItem>
                                    <asp:ListItem Value="3">支付宝</asp:ListItem>--%>
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label bankname">银行名称:</label>
                                <input id="textBankName" type="text" runat="server" class="form-control"  />
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label bankaccount">银行账号:</label>
                                <input id="textBankAccount" type="text" runat="server" class="form-control" onkeyup="value=value.replace(/[^\d]/g,'')" />
                            </div>
                        </div>
                         <div class="mb15 bankaddressarea">
                            <div class="form-group mt10">
                                <label class="control-label ">开户行归属地:</label>
                                <input id="textBankAddress" type="text" runat="server" class="form-control" />
                            </div>
                        </div>
                        <div class="mb15 bankuserarea">
                            <div class="form-group mt10">
                                <label class="control-label ">开  户  名:</label>
                                <input id="textBankAccountUser" type="text" runat="server" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group mt10" style="display: none;">
                            是否默认：<input type="radio" value="0" id="nodryRedio" name="dryRedio" runat="server" />否
                                <input type="radio" value="1" id="dryRedio" name="dryRedio" runat="server" />是
                               <%-- <label class="control-label">是否默认:</label>
                                <asp:RadioButtonList ID="dryRedio" runat="server" TextAlign="Right">
                                    <asp:ListItem Value="0">否</asp:ListItem><asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                    
                                </asp:RadioButtonList>--%>
                        </div>
                        <div class="mb15">
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success mr5"
                                    iconcls="icon-ok" OnClick="btnSave_Click"><i class="fa fa-check"></i> 添 加 </asp:LinkButton>
                            </div>
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
                                <th style="min-width: 80px;">账户类型</th>
                                <th style="min-width: 80px;">名称</th>
                                <th style="min-width: 80px;">账号</th>
                                <th style="min-width: 80px;">开户名</th>
                               <%-- <th style="min-width: 80px;">是否默认</th>--%>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpBank" runat="server" OnItemCommand="rpBank_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="账户类型">
                                        <%#Eval("BankType").ToString() == "1" ? "银行":Eval("BankType").ToString() == "2" ?"微信":"支付宝"%>
                                    </td>
                                    <td data-attr="名称">
                                        <%#Eval("BankName")%>
                                    </td>
                                    <td data-attr="账号">
                                        <%#Eval("BankAccount")%>
                                    </td>
                                    <td data-attr="开户名">
                                        <%#Eval("BankAccountUser")%>
                                    </td>
                                  <%--  <td data-attr="是否默认">
                                        <%#Eval("IsMor").ToString() == "0" ? "否":"是"%>
                                    </td>--%>

                                    <td data-attr="操作">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="modify" class="btn btn-info"
                                            iconcls="icon-edit" CommandArgument='<%#Eval("ID") %>'><i class="fa fa-pencil"></i>编辑</asp:LinkButton>
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
                        <webdiyer:AspNetPager ID="anpBank" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                            FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                            SubmitButtonText="转到" TextAfterPageIndexBox=" 页" TextBeforePageIndexBox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="anpBank_PageChanged">
                        </webdiyer:AspNetPager>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
