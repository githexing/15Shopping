<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="BonusDetail.aspx.cs" Inherits="Web.user.finance.BonusDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12 text-right m-b-10">
                        <a href="javascript:history.go(-1)" class="btn btn-sm btn-default"><i class="fa fa-mail-reply-all"></i>返回</a>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30">查询</h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("AwardName")%><!--奖项名称--></label>
                                        <asp:DropDownList ID="dropBonus" runat="server" class="form-control">
                                        </asp:DropDownList>

                                    </div>
                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" class="btn btn-success btn-md" OnClick="btnSearch_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0">
                                            <thead>
                                                <tr>
                                                    <th>奖项名称</th>
                                                    <th>奖金金额</th>
                                                   <%-- <th>日静态收益</th>--%>
                                                    <th>结算日期</th>
                                                    <th>状态</th>
                                                    <th>详情</th>
                                                </tr>
                                            </thead>

                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td th-name="奖项名称"><%if (cnen == "zh-cn") %>
                                                                <%{ %>
                                                                <%#Eval("typename")%>
                                                                <%}
                                                                    else
                                                                    { %>
                                                                <%#Eval("typenameen")%>
                                                                <%} %></td>
                                                            <td th-name="奖金金额"><%#Eval("Amount")%></td>
                                                           <%-- <td th-name="日静态收益"><%#Eval("Revenue")%></td>--%>
                                                            <td th-name="结算日期"><%#Eval("SttleTime")%></td>
                                                            <td th-name="状态"><%if (cnen == "zh-cn") %>
                                                                <%{ %>
                                                                <%#Convert.ToInt32(Eval("IsSettled"))==1?"已发放":"未发放"%><%-- 详情--%>
                                                                <%}
                                                                    else
                                                                    { %>
                                                                <%#Convert.ToInt32(Eval("IsSettled"))==1?"Issue":"Not issue"%><%-- 详情--%>
                                                                <%} %></td>

                                                            <td th-name="详情"><%if (cnen == "zh-cn") %>
                                                                <%{ %>
                                                                <%#Eval("source")%><%-- 详情--%>
                                                                <%}
                                                                    else
                                                                    { %>
                                                                <%#Eval("sourceen")%><%-- 详情--%>
                                                                <%} %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                 <tr id="tr1" runat="server">
                                                    <td colspan="9" class="colspan">
                                                        <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                                    </td>
                                                </tr>
                                               
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                  
                                           <webdiyer:AspNetPager ID="AspNetPager1" runat="server"    CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                                                  NumericButtonCount="3" PageSize="12"  
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"   PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                                               OnPageChanged="AspNetPager1_PageChanged">
                                            </webdiyer:AspNetPager>
                                      
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End row -->

            </div>
            <!-- container -->

        </div>
        <!-- content -->
 
</asp:Content>
