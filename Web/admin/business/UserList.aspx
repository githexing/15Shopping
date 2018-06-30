<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Web.admin.business.UserList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input name="Add_sscFd7" id="txtUserCode" tip="输入会员编号" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员姓名:</label>
                                <input name="Add_sscFd7" id="txtTreuName" tip="输入会员姓名" class="form-control" runat="server" type="text" />
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnSearch1_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="daochu_Click" OnClientClick="return confirm('确定要导出数据吗?')" Style="display: none;"><i class="fa fa-download"></i> 导 出 </asp:LinkButton>
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
                                <th>会员编号
                                </th>
                                <th>会员姓名
                                </th>
                                <th>会员级别
                                </th>
                              <%--  <th>注册金额
                                </th>
                                <th>身份证号
                                </th>
                                <th>联系电话
                                </th>
                                <th>昵称
                                </th>
                                <th>奖金余额
                                </th>
                                <th>E币余额
                                </th>--%>
                                <th>操作
                                </th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater2" runat="server"
                            OnItemCommand="Repeater2_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <%# Eval("UserCode")%>
                                    </td>
                                    <td>
                                        <%#Eval("TrueName")%>
                                    </td>
                                    <td>
                                        <%#Eval("LevelName")%>
                                    </td>
                                  <%--  <td>
                                        <%#Eval("RegMoney")%>
                                    </td>
                                    <td>
                                        <%#Eval("IdenCode")%>
                                    </td>
                                    <td>
                                        <%#Eval("PhoneNum")%>
                                    </td>
                                    <td>
                                        <%#Eval("NiceName")%>
                                    </td>
                                    <td>
                                        <%#Eval("BonusAccount")%>
                                    </td>
                                    <td>
                                        <%#Eval("Emoney")%>
                                    </td>--%>
                                    <td>
                                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="edit" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-info" iconcls="icon-ok"><i class="fa fa-pencil"></i>编辑</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="close" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-danger" iconcls="icon-no" Visible='<%#Eval("IsLock").ToString()=="0"?true:false %>'><i class="fa fa-minus"></i>冻结</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="open" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-danger" iconcls="icon-ok" Visible='<%#Eval("IsLock").ToString()=="1"?true:false %>'>解冻</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="goto" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-primary" iconcls="icon-ok"><i class="fa fa-share-square-o"></i>进入前台</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="8" align="center">抱歉！目前数据库暂无数据显示。</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                            HorizontalAlign="Right" OnPageChanged="AspNetPager2_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
