<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Web.admin.business.MemberList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>已开通会员</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
   <%-- <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>--%>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">已开通会员查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">选择下拉:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropType" runat="server" class="width100p selectval mwidth168  form-control">
                                        <asp:ListItem Value="0">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">会员编号</asp:ListItem>
                                        <asp:ListItem Value="2">会员姓名</asp:ListItem>
                                        <asp:ListItem Value="3">推荐人编号</asp:ListItem>
                                        <%--<asp:ListItem Value="4">安置人编号</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label">&nbsp;</label>
                                <input name="txtInput" id="txtInput" class="form-control" runat="server" type="text" />
                            </div>
                            <div class="form-group mt10" style="display:none;">
                                <label class="control-label">会员级别:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropLevel" runat="server" class="width100p selectval mwidth168 form-control"></asp:DropDownList>
                                </div>
                            </div>
                              <div class="form-group mt10" >
                                <label class="control-label">选择状态:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="DropDownList1" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0">-查询全部-</asp:ListItem>
                                        <asp:ListItem Value="1">未开通</asp:ListItem>
                                        <asp:ListItem Value="2">已开通</asp:ListItem>
                                          <asp:ListItem Value="3">已冻结</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">注册日期:</label>
                                <asp:TextBox ID="txtRegStart" tip="输入开通日期" runat="server" onfocus="WdatePicker()"
                                    class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtRegEnd" tip="输入开通日期" runat="server" onfocus="WdatePicker()"
                                    class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10" >
                                <label class="control-label">开通日期:</label>
                                <asp:TextBox ID="txtOpenStart" tip="输入开通日期" runat="server" onfocus="WdatePicker()"
                                    class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">至</label>
                                <asp:TextBox ID="txtOpenEnd" tip="输入开通日期" runat="server"
                                    onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="lbtnExport" runat="server" class="btn btn-primary mr5" iconcls="icon-print"
                                    OnClick="lbtnExport_Click"><i class="fa fa-download"></i> 导出Excel </asp:LinkButton>
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
                                <th style="min-width: 100px;">会员编号</th>
                                <th style="min-width: 80px;">昵称</th>
                                <%--<th style="min-width: 80px;">会员级别</th>--%>
                                <%--<th style="min-width: 80px;">推荐人编号</th>
                                <th style="min-width: 80px;">推荐人昵称</th>--%>
                                <th style="min-width: 80px;">注册日期</th>
                              <%--  <th style="min-width: 80px;">激活矿机</th>
                                <th style="min-width: 80px;">原始币</th>
                                <th style="min-width: 80px;">释放币</th>--%>
                              <%--  <th style="min-width: 80px;">直推人数</th>
                                <th style="min-width: 80px;">团队人数</th>
                                <th style="min-width: 80px;">团队业绩</th>--%>
                                <th style="min-width: 80px;">开通日期</th>
                                <th style="min-width: 80px;">状态</th>
<%--                                <th style="min-width: 80px;">复投次数</th>--%>
                                <th style="min-width: 80px;">操作</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                            OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="会员编号">
                                        <a href="UserDetail.aspx?UserID=<%# Eval("UserID")%>">
                                            <%# Eval("UserCode")%></a>
                                    </td>
                                    <td data-attr="昵称">
                                        <%#Eval("NiceName")%>
                                    </td>
                                   <%-- <td>
                                        <%#Eval("LevelName")%>
                                    </td>--%>
                                    <%--<td data-attr="推荐人编号">
                                        <%#Eval("RecommendCode")%>
                                    </td>
                                    <td data-attr="推荐人昵称">
                                        <%#GetNiceName(Eval("RecommendCode").ToString()) %>
                                    </td>--%>
                                    <td data-attr="注册日期">
                                        <%#Eval("RegTime")%>
                                    </td>
                                    <%--<td data-attr="激活矿机">
                                        <%#Eval("User004")%>
                                    </td>
                                    <td data-attr="原始币">
                                        <%#Eval("Emoney")%>
                                    </td>
                                    <td data-attr="释放币">
                                        <%#Eval("BonusAccount")%>
                                    </td>--%>
                                  <%--   <td data-attr="直推人数">
                                        <%#Eval("User003")%>
                                    </td>
                                     <td data-attr="团队人数">
                                        <%#Eval("User015")%>
                                    </td>
                                     <td data-attr="团队业绩">
                                        <%#Eval("User001")%>
                                    </td>--%>
                                    <td data-attr="开通日期">
                                        <%#Eval("OpenTime")%>
                                    </td>
                                    <td data-attr="开通日期">
                                        <%#Convert.ToInt32(Eval("IsLock")) == 0 ? "" : "已冻结"%>
                                    </td>
                                    <%--<td>
                                        <%#Eval("BillCount")%>
                                    </td>--%>
                                    <td data-attr="操作">
                                        <%--<asp:LinkButton ID="lbtnBatch" runat="server" CommandName="Batch" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-danger" iconcls="icon-no" Visible='<%#Eval("IsOut").ToString()=="1"?true:false %>'><i class="fa fa-minus"></i>复投</asp:LinkButton>--%>
                                        <asp:LinkButton ID="lbtnLock" runat="server" CommandName="Lock" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-danger" iconcls="icon-no" Visible='<%#Eval("IsLock").ToString()=="0"?true:false %>'><i class="fa fa-minus"></i>冻结</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnOpen" runat="server" CommandName="Open" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-danger" iconcls="icon-ok" Visible='<%#Eval("IsLock").ToString()=="1"?true:false %>'>解冻</asp:LinkButton>
                                        <%--<asp:LinkButton ID="lbtnInto" runat="server" CommandName="Into" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-primary" iconcls="icon-ok" Visible='<%#Eval("IsOpend").ToString() == "2" ? true : false%>'><i class="fa fa-share-square-o"></i>进入前台</asp:LinkButton>--%>
                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="nomodify" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-danger" iconcls="icon-no" Visible='<%#Eval("user005").ToString() == "0" || Eval("user005").ToString() == "" ? true : false%>'><i class="fa fa-minus"></i>拒绝修改资料</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="modifypass" CommandArgument='<%#Eval("UserID") %>'
                                            class="btn btn-primary" iconcls="icon-ok" Visible='<%#Eval("user005").ToString() == "1" ? true : false%>'><i class="fa fa-share-square-o"></i>允许修改资料</asp:LinkButton>--%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="11" align="center">抱歉！目前数据库暂无数据显示。</td>
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
