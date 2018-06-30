<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/index.Master" CodeBehind="Address.aspx.cs" Inherits="Web.user.product.Address" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="content">

            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                        <div class="grid-title">
                            <h4>收获地址</h4>
                        </div>

                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">详细地址：</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label">收货人姓名：</label>
                                    <div class="col-md-10">
                                          <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label">手机号码：</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtPhoneNum" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <%--<div class="form-group">
                                    <label class="col-md-2 control-label">备用手机号：</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="form-group"  id="divOutAccount" runat="server" >
                                    <label class="col-md-2 control-label">设为默认地址：</label>
                                    <div class="col-md-10">
                                        <asp:CheckBox ID="chkDefault"  Checked="false" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group" id="div1"  runat="server">
                                <label class="col-md-2 control-label"></label>
                                <div class="col-md-10" style="margin-bottom: 15px;" >
                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" class="btn btn-primary" />
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
                                            <th>详细地址</th>
                                            <th>收货人姓名</th>
                                            <th>常用手机号</th>
                                            <%--<th>备用手机号</th>--%>
                                            <th>默认地址</th>
                                            <th>操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td th-name="详细地址"><%# Eval("Address")%></td>
                                                    <td th-name="收货人姓名"><%#Eval("MemberName")%></td>
                                                    <td th-name="常用手机号"><%#Eval("PhoneNum")%></td>
                                                    <%--<td th-name="备用手机号"><%#Eval("Phone")%></td>--%>
                                                    <td th-name="默认地址"><%#Eval("Address01").ToString()=="0" ? GetLanguage("NoCast") : GetLanguage("YesCast") %></td>
                                                    <td th-name="操作">
                                                        <asp:LinkButton ID="lbtnDefaultEn" class="btn btn-primary btn-sm" runat="server" CommandArgument='<%# Eval("ID") %>' Visible='<%#Eval("Address01").ToString()=="0" ? true:false %>'
                                                            CommandName="Default" OnClientClick="javascript:return confirm('Set default address?')"
                                                            ><%=GetLanguage("Default")%><!--默认--></asp:LinkButton>
                                                        <asp:LinkButton ID="lbtnEditEn" class="btn btn-primary btn-sm" runat="server" CommandName="Edit" CommandArgument='<%#Eval("ID") %>'
                                                            ><%=GetLanguage("Edit")%><%--编辑--%></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tr id="tr1" runat="server">
                                        <td colspan="6" class="colspan">
                                            <div class="text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="text-right">

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
        </div>
             
            </div>
        </div>
    </div>
            </div>
</asp:content>
