<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="TakeMoney.aspx.cs" Inherits="Web.user.finance.TakeMoney" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>

    <div class="content">

        <div id="container">
            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                        <div class="grid-title">
                            <h4>我要提现</h4>
                        </div>
                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">奖金币：</label>
                                        <div class="col-md-10">
                                              <b><span class="text-danger"><%=LoginUser.Emoney %></span> </b>
                                            <%--  <div class="col-sm-12">
                                <b>释放币余额：<span class="text-danger"><%=LoginUser.BonusAccount %></span> </b>
                            </div>--%>
                                        </div>
                                    </div>

                                         <div class="form-group">
                                        <label class="col-md-2 control-label">提现币种：</label>
                                        <div class="col-md-10">
                                               <asp:DropDownList ID="dropType" class="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                          <div class="form-group">
                                        <label class="col-md-2 control-label"><%=GetLanguage("WithdrawalAmount")%><!--提现金额-->：</label>
                                        <div class="col-md-10">
                                               <asp:TextBox ID="txtTake" class="form-control" runat="server" AutoPostBack="True" onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;" OnTextChanged="txtTake_TextChanged"></asp:TextBox>
                                                
                                        </div>
                                    </div>

                                         <div class="form-group">
                                        <label class="col-md-2 control-label">手续费：</label>
                                        <div class="col-md-10">
                                              <input name="txtExtMoney" type="text" class="form-control" id="txtExtMoney" runat="server" disabled="disabled" />
                                        </div>
                                    </div>

                                   <div class="form-group">
                                        <label class="col-md-2 control-label">提现账户：</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="dropOutAccount" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropOutAccount_SelectedIndexChanged"  ></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group"  id="divOutAccount" runat="server" >
                                        <label class="col-md-2 control-label"><asp:Label ID="lblOutAccountTitle" runat="server">提现账号</asp:Label>：</label>
                                        <div class="col-md-10">
                                            <asp:Label ID="lblOutAccount" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group" id="divOutQrCode"  runat="server" style="display:none">
                                        <label class="col-md-2 control-label"><asp:Label ID="lblOutQRCodeTitle" runat="server">二维码</asp:Label>：</label>
                                        <div class="col-md-10">
                                            <asp:Image ID="imgOutQRCode" runat="server" ImageUrl="" /> 
                                        </div>
                                    </div>
                                    <div class="form-group" id="divOutName"  runat="server" style="display:none">
                                    <label class="col-md-2 control-label"><asp:Label ID="lblOutNameTitle" runat="server">昵称</asp:Label>：</label>
                                    <div class="col-md-10">
                                        <asp:Label ID="lblOutName" runat="server" ></asp:Label>  
                                    </div>
                                    </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                       
                        
                        <div class="form-group" id="div1"  runat="server">
                            <label class="col-md-2 control-label"><asp:Label ID="Label1" runat="server"> </asp:Label></label>
                            <div class="col-md-10">
                               <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" class="btn btn-primary" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-inline col-sm-12">
                                <div class="form-group">
                                    <label class="col-sm-3"></label>
                                    <div class="input-group">
                                        <asp:Label runat="server" ID="ream"></asp:Label>
                                    </div>
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
                    <h4 class="header-title m-t-0 m-b-30">
                        <!--查询-->
                        <%=GetLanguage("Query") %></h4>
                    <div class="row">
                        <div class="form-inline col-sm-12">

                            <div class="form-group">
                                <label>提现日期</label>
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
                                            <th>提现类型<!--提现金额--></th>
                                            <th><%=GetLanguage("WithdrawalAmount")%><!--提现金额--></th>
                                            <th><%=GetLanguage("WithdrawalFee")%><!--提现手续费--></th>
                                            <th><%=GetLanguage("ActualAmount")%><!--到账金额--></th>
                                            <th><%=GetLanguage("DateWithdrawal")%><!--提现日期--></th>
                                            <th><%=GetLanguage("State")%><!--状态--></th>
                                            <th><%=GetLanguage("Operation")%><!--操作--></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                    <td data-title="提现类型"><%# TakeType(Convert.ToInt32(Eval("Take001")))%></td>
                                                    <td data-title="提现金额"><%#Eval("TakeMoney")%></td>
                                                    <td data-title="提现手续费"><%#Eval("TakePoundage")%></td>
                                                    <td data-title="到账金额"><%#Eval("RealityMoney")%></td>
                                                    <td data-title="提现日期"><%#Eval("TakeTime")%></td>
                                                    <td data-title="状态">
                                                        <% if (Language == "zh-cn")
                                                            { %>
                                                        <span class="text-success"><%#Eval("Flag").ToString() == "0" ? "等待审核..." : "已审核"%></span>
                                                        <% }
                                                            else
                                                            { %>
                                                        <span class="text-success"><%#Eval("Flag").ToString() == "0" ? "Not released" : "Has been released"%></span>
                                                        <% }%>
                                                    </td>
                                                    <td data-title="操作">
                                                        <%--<button class="btn btn-danger btn-sm del-alert" data-toggle="modal" data-target="#myModal">删除</button>--%>
                                                        <asp:LinkButton ID="lbtnCancel" runat="server" class="btn btn-danger btn-sm del-alert" CommandName="change" Visible='<%#Eval("Flag").ToString() == "0" ? true : false%>'
                                                            CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('确认取消提现吗？')"><%=GetLanguage("CancelWithdrawal")%><!--取消提现--></asp:LinkButton>
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
    <!-- ENG PAGE CONTAINER-->
    <script type="text/javascript" src="../../js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //弹出框
            var numDel = -1;
            $(".del-alert").on('click', function () {
                numDel = $(".del-alert").index($(this));
            })
            $("#myModal .btn-sure").on('click', function () {
                $(".del-alert").eq(numDel).parents('tr').remove();
            })
        })
    </script>
    <script type="text/javascript" src="../../js/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //选择日期
            $('.input-append.date').datepicker({
                autoclose: true,
                todayHighlight: true,
                format: 'yyyy-mm-dd'
            })
        })
    </script>
    <script type="text/javascript" src="../../JS/Comm.js">
            
    </script>
</asp:content>
