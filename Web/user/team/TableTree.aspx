<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/index.Master" CodeBehind="TableTree.aspx.cs" Inherits="Web.user.team.TableTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
     
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--查询--%><%=GetLanguage("Query") %></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("MembershipNumber")%><%--会员编号--%></label>
                                        <input name="txtUserCode" id="txtUserCode" runat="server" class="form-control" type="text" />

                                    </div>
                                    <div class="form-group">
                                        <label><%=GetLanguage("OpeningDate")%><%--开通日期--%></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <asp:UpdatePanel ID="UpdatePanel00" runat="server">
                                                <ContentTemplate>
                                                    <%--<input type="text" >--%>
                                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                                        {%>
                                                    <asp:TextBox ID="txtStart" tip="开通日期" runat="server" onfocus="WdatePicker()" class="form-control" name="start"></asp:TextBox>
                                                    <%}
                                                        else
                                                        {%>
                                                    <asp:TextBox ID="txtStartEn" tip="Opening date" runat="server" onfocus="WdatePicker({lang:'en'})" class="form-control" name="start"></asp:TextBox>
                                                    <%} %>
                                                    <span class="add-on hidden"></span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%><%--至--%></span>
                                            <asp:UpdatePanel ID="UpdatePanel01" runat="server">
                                                <ContentTemplate>
                                                    <%if (GetLanguage("LoginLable") == "zh-cn")
                                                        {%>
                                                    <asp:TextBox ID="txtEnd" tip="开通日期" runat="server" onfocus="WdatePicker()" class="form-control" name="end"></asp:TextBox>
                                                    <%}
                                                        else
                                                        {%>
                                                    <asp:TextBox ID="txtEndEn" tip="Opening date" runat="server" onfocus="WdatePicker({lang:'en'})" class="form-control" name="end"></asp:TextBox>
                                                    <%} %>
                                                    <span class="add-on hidden"></span>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" class="btn btn-success btn-md" />

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
                                                    <th><%=GetLanguage("MembershipNumber")%><!--会员编号--></th>
                                                    <th><%=GetLanguage("MemberName")%><!--会员姓名--></th>
                                                    <%-- <th><%=GetLanguage("MembershipLevels")%><!--会员级别--></th>--%>
                                                    <th><%=GetLanguage("ReferenceNumber")%><!--推荐人编号--></th>
                                                    <th><%=GetLanguage("RegistrationHours")%><!--注册日期--></th>
                                                    <th><%=GetLanguage("OpeningDate")%><!--开通日期--></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:UpdatePanel ID="UpdatePanel02" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Repeater ID="Repeater1" runat="server">
                                                            <ItemTemplate>
                                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                                    <td>
                                                                       <%-- <a href="../member/PersonalInfo.aspx?UserID=<%# Eval("UserID")%>">--%>
                                                                            <%# Eval("UserCode")%><%--</a>--%>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("NiceName")%>
                                                                    </td>
                                                                    <%--  <td>
                                                                        <% if (Language == "zh-cn")
                                                                            { %>
                                                                        <%#Eval("LevelName")%>
                                                                        <% }
                                                                            else
                                                                            { %>
                                                                        <%#Eval("Level03")%>
                                                                        <% }%>
                                                                    </td>--%>
                                                                    <td>
                                                                        <%#Eval("RecommendCode")%>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("RegTime")%>
                                                                    </td>
                                                                    <td>
                                                                        <%#Eval("OpenTime")%>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="6" class="colspan">
                                                        <div class="form-control-static text-center">
                                                            <i class="fa fa-warning text-warning"></i>
                                                            <%-- 抱歉！目前数据库暂无数据显示。--%>
                                                            <%=GetLanguage("Manager")%>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                        NumericButtonCount="3" PageSize="12"
                                        ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false" PagingButtonSpacing="0" CurrentPageButtonClass="active"
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
