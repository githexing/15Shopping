<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="NoticeList.aspx.cs" Inherits="web.user.member.NoticeList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
       <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
   
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("Query") %><%--查询--%></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label for=""><%=GetLanguage("Title")%><%--标题--%></label>
                                        <input type="text" id="txtTitle" runat="server" class="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <label><%=GetLanguage("ReleaseTime")%><!--发布时间--></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStart" class="form-control" name="start" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtStartEn" tip="input close an account date" class="form-control" name="start" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>

                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%><%--至--%></span>
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtEnd" runat="server" onfocus="WdatePicker()" class="form-control" name="end"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEndEn" tip="input close an account date" class="form-control" name="end" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                        </div>
                                    </div>
                                     <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success btn-md" Text="搜索" />
                                    
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
                                                    <th><%=GetLanguage("SerialNumber")%><%--序号--%></th>
                                                    <th><%=GetLanguage("Title")%><%--标题--%></th>
                                                    <th><%=GetLanguage("Time")%><%--时间--%></th>
                                                    <th>操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                 <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td th-name="序号"><%# this.Repeater1.Items.Count + 1%></td>
                                                    <td th-name="标题"><%# getstring(Language,Eval("NewsTitle").ToString(),18)%></a></td>
                                                    <td th-name="时间"><%#Convert.ToDateTime(Eval("PublishTime")).ToString("")%></td>
                                                    <td th-name="操作"><a href="NoticeDetail.aspx?ID=<%#Eval("ID") %>" class="btn btn-info btn-sm"><%=GetLanguage("check") %><%--查看--%></a></td>
                                                </tr>
                                                 </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="4" class="colspan">
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
                                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                                                  NumericButtonCount="3" PageSize="12"  
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"   PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                                            OnPageChanged="AspNetPager1_PageChanged">
                                        </webdiyer:AspNetPager>
                                    </div>

                        </div>
                    </div>
                </div>
                <!-- End row -->

            </div>
            <!-- container -->

        </div>
        <!-- content -->
 
    </div>
</asp:Content>
