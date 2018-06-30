<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemitManage.aspx.cs" Inherits="Web.admin.finance.RemitManage" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />

    <title>会员充值</title>

    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">充值管理</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <asp:TextBox ID="txtUserCode" runat="server" tip="输入会员编号" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10" style="display:none;">
                                <label class="control-label">会员姓名:</label>
                                <asp:TextBox ID="txtTrueName" runat="server" tip="输入会员姓名" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">审核状态:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropState" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="请选择">请选择</asp:ListItem>
                                        <asp:ListItem Value="1" Text="未审核">未审核</asp:ListItem>
                                        <asp:ListItem Value="2" Text="已审核">已审核</asp:ListItem>
                                        <asp:ListItem Value="3" Text="已撤消">已撤消</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="form-group mt10">
                                <label class="control-label">审核类型:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropRemitType" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="请选择">请选择</asp:ListItem>
                                        <asp:ListItem Value="1" Text="未审核">开通会员</asp:ListItem>
                                        <asp:ListItem Value="2" Text="已审核">账号复投</asp:ListItem>
                                        <asp:ListItem Value="3" Text="已审核">会员升级</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="form-group mt10">
                                <label class="control-label">申请日期:</label>
                                <asp:TextBox ID="txtStar" tip="输入申请日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtEnd" tip="输入申请日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                            </div>
                        </div>
                        
                            
                        
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body" id="image_container">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">收款账户信息</th>
                                <th style="min-width: 80px;">充值金额</th>
                                <%--<th style="min-width: 80px;">打款金额</th>--%>
                                <th style="min-width: 80px;">打款账户信息</th>
                              <%--   <th style="min-width: 80px;">充值码</th>--%>
                                <th style="min-width: 80px;">申请日期</th>
                                <th style="min-width: 80px;">审核状态</th>
                                <th style="min-width: 80px;">审核日期</th>
                                
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpRemit" runat="server" OnItemCommand="rpRemit_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="会员编号"><%#Eval("UserCode")%></td>
                                    <td data-attr="会员姓名"><%#Eval("Truename")%></td>
                                    <td data-attr="收款账户信息">
                                        账户类型：<%#Eval("BankType").ToString() == "1"?"银行卡":Eval("BankType").ToString() == "2"?"微信":"支付宝"%><br />
                                        <%#Eval("BankName")%><br />
                                        <%#Eval("BankAccount")%><br />
                                        <%#Eval("BankAccountUser")%>
                                    </td>
                                    <td data-attr="充值金额"><%#Eval("RemitMoney")%></td>
                                    <%--<td data-attr="打款金额"><%#Eval("Remit006")%></td>--%>
                                    <td data-attr="打款账户信息">
                                        账户类型：<%#Eval("Bank003").ToString() == "1"?"银行卡":Eval("Bank003").ToString() == "2"?"微信":"支付宝"%><br />
                                        <%#Eval("PlayBankName")%><br />
                                        <%#Eval("PlayBankAccount")%><br />
                                        <%#Eval("PlayBankAccountUser")%>
                                    </td>
                                 <%--   <td data-attr="充值码"><%#Eval("Remit003")%></td>--%>
                                    <td data-attr="申请日期"><%#Eval("AddDate")%></td>
                                    <td data-attr="审核状态"><%#StateType(Eval("State").ToString())%></td>
                                    <td data-attr="申请日期"><%#Eval("PassDate")%></td>
                                    <td data-attr="操作">
                                        <asp:LinkButton ID="lbtnVerify" runat="server" CommandArgument='<%# Eval("ID") %>' class="btn btn-success"
                                            iconcls="icon-ok" CommandName="verify" OnClientClick="javascript:return confirm('确定审核？')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'><i class="fa fa-pencil"></i>确认</asp:LinkButton>
                                        <a class="btn btn-info viewimg" data-img='<%# Eval("Remit004") %>' style='<%# Eval("Remit004").ToString() == "" ? "display:none;":"" %>'   ><i class="fa fa-eye"></i>查看打款凭证</a>
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%# Eval("ID") %>' class="btn btn-danger"
                                            iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('确定要撤销吗？')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'><i class="fa fa-pencil"></i>撤销</asp:LinkButton>
                                        
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none" >
                            <td colspan="13" align="center">抱歉！目前数据库暂无数据显示。</td>
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
         <script src="/js/BigPicture.min.js"></script>
        <script>

            (function () {

                function setClickHandler(id, fn) {
                    document.getElementById(id).onclick = fn;
                }

                setClickHandler('image_container', function (e) {
                    e.target.tagName === 'A' && e.target.className === 'btn btn-info viewimg' && BigPicture({
                        el: e.target,
                        imgSrc: $(e.target).data("img")
                    });
                });

            })();
        </script>
    </form>
</body>
</html>
