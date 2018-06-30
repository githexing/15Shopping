<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fenhong.aspx.cs" Inherits="Web.admin.finance.Fenhong" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>发红包</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link rel="stylesheet" type="text/css" href="../../css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />
</head>
<body> 
    <form id="Form1" runat="server"> 

         <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">发红包</h4>
                </div>
                <div class="panel-body"> 
                        <div class="mb15">  
                            <div class="form-group mt10" >
                                <label class="control-label">请输入要发的红包:</label>
                           <%--     <div class="form-control nopadding noborder">--%>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><label class="control-label">元/个分润单位</label>
                               <%-- </div>--%>
                            </div>
                        </div> 
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSearch_Click"  OnClientClick="return confirm('确定分红吗？');"><i class="fa fa-search"></i>发放红包</asp:LinkButton>
                               
                            </div>
                        </div>
                   
                </div>
                <!-- panel-body -->
            </div> 
               <div class="panel-body">
              
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">会员编号:</label>
                                <input id="textUserCode" type="text" runat="server" class="form-control" tip="输入会员编号" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">会员姓名:</label>
                                <asp:TextBox ID="txtTrueName" tip="输入姓名" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="lbtnSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
                            </div>
                        </div>
                   
                </div>
             <div class="panel panel-default">


                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">会员编号</th>
                                <th style="min-width: 80px;">会员姓名</th>
                                <th style="min-width: 80px;">订单号</th>
                                <th style="min-width: 80px;">分润单位</th>
                                <th style="min-width: 80px;">应分红总数</th>
                                <th style="min-width: 80px;">已分红总数</th>
                                <th style="min-width: 80px;">状态</th>
                            <%--<th style="min-width: 80px;">安全账户</th>--%>
                            <%--<th style="min-width: 80px;">释放币</th>--%>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="会员编号">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td data-attr="会员姓名">
                                        <%#Eval("TrueName")%>
                                    </td>
                                    <td data-attr="订单号">
                                        <%#Eval("OrderCode")%> 
                                    </td>
                                    <td data-attr="分润单位">
                                       <%#Eval("BaodanOrder")%> 
                                    </td>
                                    <td data-attr="应分红总数">
                                       <%#Eval("PVTotal")%> 
                                    </td>
                                    <td data-attr="已分红总数">
                                       <%#Eval("Order1")%> 
                                    </td>
                                    <td data-attr="状态">
                                       
                                           <%#Eval("PVTotal").ToString()==Eval("Order1").ToString()?"分红完成":"正在分红"  %> 
                                    </td>
                              <%--      <td data-attr="安全账户">
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="h_detail"><%#Eval("User007")%></asp:LinkButton>
                                    </td>--%>
                                    <%--<td data-attr="释放币">
                                        <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            CommandName="a_detail"><%#Eval("ShopAccount")%></asp:LinkButton>
                                    </td>--%>
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
