<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/index.Master" CodeBehind="TransferToEmoney.aspx.cs" Inherits="Web.user.finance.TransferToEmoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
     <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <!-- Start right Content here -->
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-custom">
                                    <%=LoginUser.StockMoney%></h2>
                                <h5>电子积分<!--原始币--></h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6" >
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-pink">
                                    <%=LoginUser.Emoney%></h2>
                                <h5>奖金积分<!--现金积分--></h5>
                            </div>
                        </div>
                    </div>

                  <div class="col-lg-4 col-md-6" >
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning">
                                    <%=LoginUser.BonusAccount%>
                               </h2>
                                <h5>消费积分</h5>
                            </div>
                        </div>
                    </div>
                     <%--  <div class="col-lg-4 col-md-6" >
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning">
                                    <%=LoginUser.StockAccount%>
                               </h2>
                                <h5>报单积分</h5>
                            </div>
                        </div>
                    </div>--%>
                       <div class="col-lg-4 col-md-6" >
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning">
                                    <%=LoginUser.StockAccount%>
                               </h2>
                                <h5>报单积分</h5>
                            </div>
                        </div>
                    </div> 
                   
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("MemberTransfer") %><!--会员转账--></h4>
                            <div class="row">
                                <div class="form-horizontal col-sm-12"> 
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><%=GetLanguage("TransferType") %><!--转账类型-->：</label>
                                        <div class="col-sm-10"><%-- OnSelectedIndexChanged="dropCurrency_SelectedIndexChanged" AutoPostBack="True"--%>
                                            <asp:DropDownList ID="dropCurrency" class="form-control" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="dropCurrency_SelectedIndexChanged"   ></asp:DropDownList>
                                             


                                        </div>
                                    </div>
                                    
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><%=GetLanguage("MembershipNumber") %><!--会员编号-->：</label>
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <asp:TextBox runat="server" ID="txtUserCode" class="form-control" Text="" AutoPostBack="true" OnTextChanged="txtUserCode_TextChanged"></asp:TextBox>

                                                <span class="input-group-addon"><%=GetLanguage("Name") %><!--会员姓名--></span>
                                                <asp:TextBox runat="server" ID="txtTrueName" class="form-control" Text="" Enabled="false"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><%=GetLanguage("TheTransferAmount") %><!--转账金额-->：</label>
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtMoney" class="form-control" runat="server" type="text"
                                                    onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                                    AutoPostBack="True" OnTextChanged="txtMoney_TextChanged" />

                                                <span class="input-group-addon"><%=GetLanguage("ActualAmount") %><!--到账金额--></span>
                                                <input type="text" id="txtActualAmount" runat="server" disabled="disabled" class="form-control" name="txtActualAmount" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"><%=GetLanguage("SecondPassword") %><!--二级密码-->：</label>
                                        <div class="col-sm-10">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtSecondPassword"  class="form-control" runat="server"  textmode="password"   />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group m-b-0">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-info " OnClick="btnSubmit_Click" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><!--查询--><%=GetLanguage("Query") %></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("CurrencyType") %><!--币种--></label>
                                        <asp:DropDownList ID="dropType" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label><%=GetLanguage("DateTransfer") %><!--转账日期--></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStart" runat="server" class="form-control" name="start" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtStartEn" runat="server" class="form-control" name="start" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%><!--至--></span>
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtEnd" runat="server" class="form-control" name="end" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEndEn" runat="server" class="form-control" name="end" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                        </div>
                                    </div>
                                      <asp:Button ID="btnSearch" runat="server" class="btn btn-success  btn-md" OnClick="btnSearch_Click" />
                           
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
                                                    <th><%=GetLanguage("TransferType")%><!--转账类型--></th>
                                                    <th><%=GetLanguage("TheTransferAmount")%><!--转账金额--></th>
                                                   <%-- <th><%=GetLanguage("ActualAmount")%><!--到账金额--></th>--%>
                                                    <th><%=GetLanguage("DateTransfer")%><!--转账日期--></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                               <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td data-title="会员编号"><%#Eval("UserCode")%></td>
                                                            <td data-title="会员姓名"><%#Eval("TrueName")%></td>
                                                            <td data-title="转账类型"><%#ChangeType(Convert.ToInt32(Eval("ChangeType")))%></td>
                                                            <td data-title="转账金额"><%#Eval("Amount")%></td>
                                                           <%-- <td data-title="到账金额"><%#Eval("Change005")%></td>--%>
                                                            <td data-title="转账日期"><%#Eval("ChangeDate")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                <td colspan="5" class="colspan">
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
</asp:content>
