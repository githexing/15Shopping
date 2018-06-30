<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.user._default" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=getParamVarchar("SystemName2")%></title>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    
</head>
<body>
    <form id="form1" runat="server">
      
            <div class="content">
                <div class="page-title">
                    <h3>首页</h3>
                </div>
                <div id="container">
                    <div class="row">
                      <%--  <div class="col-md-t m-b-15">
                            <div class="tiles yellow">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="52452" data-animation-duration="1200"><%=LoginUser.BonusAccount%></span> </div>
                                    <div class="tiles-title">积分($) </div>
                                </div>
                            </div>
                        </div>--%>
                        <div class="col-md-t m-b-15">
                            <div class="tiles pink">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="2545665" data-animation-duration="1000"><%=LoginUser.Emoney%></span> </div>
                                    <div class="tiles-title">消费金(￥) </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-t m-b-15">
                            <div class="tiles pink">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="2545665" data-animation-duration="1000"><%=LoginUser.RegMoney%></span> </div>
                                    <div class="tiles-title">本金($) </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-t m-b-15">
                            <div class="tiles green">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="14500" data-animation-duration="1200"><%=LoginUser.StockAccount%></span> </div>
                                    <div class="tiles-title">月分红静态钱包($) </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-t m-b-15">
                            <div class="tiles purple">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="1600" data-animation-duration="700"><%=LoginUser.StockMoney%></span> </div>
                                    <div class="tiles-title">月分红动态钱包($) </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-t m-b-15">
                            <div class="tiles black">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="1680" data-animation-duration="700"><%=LoginUser.ShopAccount%></span> </div>
                                    <div class="tiles-title">年分红静态钱包($) </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-t m-b-15">
                            <div class="tiles blue">
                                <div class="tiles-body">
                                    <div class="heading"><span class="animate-number" data-value="1680" data-animation-duration="700"><%=LoginUser.GLmoney%></span> </div>
                                    <div class="tiles-title">年分红动态钱包($) </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row m-b-15">
                        <div class="col-md-12">
                            <div class="grid simple line">
                                <div class="grid-title no-border">
                                    <h4>推广连接</h4>
                                </div>
                                <div class="grid-body no-border">
                                    <p><%="http://"+HttpContext.Current.Request.Url.Host+"/Registers.aspx?UserCode="+LoginUser.UserCode%></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="grid simple line">
                                <div class="grid-title no-border">
                                    <h4>新闻中心</h4>
                                </div>
                                <div class="grid-body no-border">
                                    <table class="table no-more-tables table-hover">
                                        <tr>
                                            <td class="text-center" width="80"><%=GetLanguage("SerialNumber")%><%--序号--%></td>
                                            <td class="text-center"><%=GetLanguage("Title")%><%--标题--%></td>
                                            <td class="text-center"><%=GetLanguage("Time")%><%--时间--%></td>
                                        </tr>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td class="text-center">
                                                        <%# this.Repeater1.Items.Count + 1%> 
                                                    </td>
                                                    <td class="text-center">
                                                        <a href="member/NoticeDetail.aspx?ID=<%#Eval("ID") %>" style="color: Red;">» <%# getstring(Language,Eval("NewsTitle").ToString(),18)%></a>
                                                    </td>
                                                    <td class="text-center">
                                                        <%#Convert.ToDateTime(Eval("PublishTime")).ToString("")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr id="tr1" runat="server">
                                            <td colspan="3" class="colspan">
                                                <div class="text-center">
                                                    <i class="fa fa-warning text-warning"></i>
                                                    <%--抱歉！目前数据库暂无数据显示。--%>
                                                     <%=GetLanguage("Manager")%>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
     
        <script type="text/javascript" src="/JS/Comm.js"></script>
    </form>
</body>
</html>
