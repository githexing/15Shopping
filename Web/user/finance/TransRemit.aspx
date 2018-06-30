<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/index.Master" CodeBehind="TransRemit.aspx.cs" Inherits="Web.user.finance.TransRemit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("CompanyAccountInformation") %><%--公司账户信息--%></h4>
                            <div class="row">
                               <div class="form-group col-md-6 col-sm-12" id="khyhs">
                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="khyh" runat="server"></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="bank" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-md-6 col-sm-12" id="gs">
                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="gszh" runat="server"></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="bankAccount" runat="server" CssClass="form-control"  ReadOnly="true" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-md-6 col-sm-12" id="khms">
                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="khm" runat="server"></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="bankUserName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("Applications") %><%--申请信息--%></h4>

                            <div class="row">
                              

                                
                                
                                <div class="form-group col-md-6 col-sm-12" id="zx">

                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="txtName" runat="server" ></asp:Label></label>
                                    <div class="col-md-8">

                                        <asp:DropDownList ID="ourbankname" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                      
                                    </div>


                                </div>

                             <%--   <div class="form-group col-md-6 col-sm-12" id="hcyh">
                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="yh" runat="server" Text="汇出银行："></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="OutBank" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>--%>

                                <div class="form-group col-md-6 col-sm-12" id="hczh">
                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="zh" runat="server" ></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="ourbankaccount" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                  <div class="form-group col-md-6 col-sm-12" id="czje">
                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="lblMoney" runat="server" ></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtMoney" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="form-group col-md-6 col-sm-12" id="scpz">

                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="pz" runat="server"></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:FileUpload ID="FileUpload1" runat="server" class="btn" AutoPostBack="true" Width="200px" Style="width: 135px; display: inline-block;" onchange="this.form.LinkButton3.click();" />&nbsp;&nbsp;
                                                    <asp:Button ID="btnUpload" runat="server" AutoPostBack="true" class="ebtn btn-success" OnClick="btnUpload_Click" Text="上 传"></asp:Button>

                                    </div>

                                </div>
                                 
                                <div class="form-group col-md-6 col-sm-12" id="bzs">

                                    <label class="col-md-4 control-label">
                                        <asp:Label ID="bz" runat="server"></asp:Label></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="barmk" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                 <div class="form-group col-md-6 col-sm-12">
                                    <asp:Image ID="Image1" runat="server" Style="width: 100%; max-width: 240px;    min-height: 100px;;" />

                                </div>
                                <div class="form-group col-md-6 col-sm-12">
                                    <label class="col-md-4 control-label"></label>
                                    <div class="col-md-8">
                                                 
                                <asp:Button ID="btn_Open" runat="server" OnClick="btn_Open_Click" class="btn btn-custom waves-effect waves-light btn-md"/>
                                        <iframe name="ICount" id="Ifrc" height="40px" width="95px" runat="server" border="0" frameborder="0" scrolling="auto"></iframe>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("Query") %><%--查询--%></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("SettlementDate")%><%--结算日期--%></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStart" tip="输入结算日期" class="form-control" name="start" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEnd" tip="input close an account date" class="form-control" name="start" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>

                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To") %><%--至--%></span>
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStartEn" tip="输入结算日期" runat="server" class="form-control" name="end" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEndEn" tip="input close an account date" class="form-control" name="end" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-success waves-effect waves-light btn-md" OnClick="btnSearch_Click" />

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
                                                    <th><%=GetLanguage("MembershipNumber") %><%--会员编号--%></th>
                                                    <th><%=GetLanguage("Name") %><%--会员姓名--%></th>
                                                    <%--<th><%=GetLanguage("OrderNumber") %><!--订单号--></th>--%>
                                                    <th><%=GetLanguage("OrderAmount") %><%--订单金额--%></th>
                                                    <%--<th><%=GetLanguage("OrderTimes") %><!--订单具体时间--></th>--%>
                                                    <th><%=GetLanguage("OutBank") %><%--汇出银行--%></th>
                                                    <th><%=GetLanguage("UserBankAccount") %><%--汇出银行--%></th>
                                                    <th><%=GetLanguage("Shenqing") %><%--申请日期--%></th>
                                                    <th><%=GetLanguage("State") %><%--审核状态--%></th>
                                                    <th><%=GetLanguage("AuditDate") %><%--审核日期--%></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("UserCode")%></td>
                                                            <td><%#Eval("NiceName")%></td>
                                                            <%--<td><%#Eval("Remit004")%></td>--%>
                                                            <td><%#Eval("RemitMoney")%></td>
                                                            <%--<td><%#Eval("RechargeableDate")%></td>--%>
                                                            <td><%#BankStr(Eval("Remit003").ToString())%></td>
                                                            <td><%#Eval("AddDate")%></td>
                                                            <td><%#Eval("BankAccount")%></td>
                                                            <td><%#StateType(Eval("State").ToString())%></td>
                                                            <td><%#Eval("PassDate")%></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="6" class="colspan">
                                                        <div class="form-control-static text-center">
                                                            <i class="fa fa-warning text-warning"></i>
                                                            <%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。-->
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
        </div>
        <!-- container -->
 

   


</asp:Content>
