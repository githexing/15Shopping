<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="LeaveMsg.aspx.cs" Inherits="Web.user.member.LeaveMsg" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="btn-group pull-left m-b-10">
                                <a href="LeaveMsg.aspx" class="btn btn-custom waves-effect"><%=GetLanguage("TheInbox")%><%--收信箱--%></a>
                                <a href="LeaveOut.aspx" class="btn btn-default waves-effect"><%=GetLanguage("TheOutbox")%><%--发件箱--%></a>
                                <a href="Leavewords.aspx" class="btn btn-default waves-effect"><%=GetLanguage("message")%><%--留言--%></a>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0">
                                            <thead>
                                                <tr>
                                                    <th><%=GetLanguage("sender")%><%--发件人--%></th>
                                                    <th><%=GetLanguage("SubjectContent")%><%--主題内容--%></th>
                                                    <th><%=GetLanguage("TheOutboxDate")%><%--发件日期--%></th>
                                                    <th><%=GetLanguage("Operation")%><!--操作--></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td th-name="收件人"><%#GetUserCode(Eval("UserID").ToString(), Eval("FromUserType").ToString())%></td>
                                                            <td th-name="主題内容"><a href='LeaveWordsDetail.aspx?type=in&id=<%#Eval("ID") %>&type=1' target="_self"><%#Eval("MsgTitle")%></a></td>
                                                            <td th-name="发件日期"><%#Convert.ToDateTime(Eval("LeaveTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                                                            <td th-name="操作"><%#Eval("IsReply").ToString() == "0" ? "未回复" : "已回复"%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                            <tr id="tr1" runat="server">
                                                <td colspan="4" class="colspan">
                                                    <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><%--抱歉！目前数据库中暂无记录显示--%></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
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
