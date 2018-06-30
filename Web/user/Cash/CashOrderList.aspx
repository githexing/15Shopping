<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CashOrderList.aspx.cs" Inherits="Web.user.Cash.CashOrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <script type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
     <style type="text/css">
       
        .time_div1 {
            display:none;
        }
    </style>

        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("MyOrder")%></h4>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label><%=GetLanguage("OrderNumber")%><%--订单编号--%></label>
                                        <asp:TextBox ID="txtOrderCode" runat="server" class="form-control"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label><%=GetLanguage("OrderType")%><%--订单类型--%></label>
                                        <asp:DropDownList ID="dropOrderType" class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group">
                                        <label><%=GetLanguage("ReleaseTime")%><!--发布时间--></label>
                                        <div class="input-daterange input-group" id="date-range">
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtStart" tip="下订日期" class="form-control" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtStartEn" tip="Set date" class="form-control" runat="server" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
                                            <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%></span>
                                            <%if (GetLanguage("LoginLable") == "zh-cn")
                                                {%>
                                            <asp:TextBox ID="txtEnd" tip="下订日期" runat="server" class="form-control" onfocus="WdatePicker()"></asp:TextBox>
                                            <%}
                                                else
                                                {%>
                                            <asp:TextBox ID="txtEndEn" tip="Set date" runat="server" class="form-control" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                            <%} %>
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
                                                    <th><%=GetLanguage("OrderNumber")%><%--订单编号--%>
                                                    </th>
                                                    <th><%=GetLanguage("OrderAmount")%><!--商品价格-->
                                                    </th>
                                                    <%--<th><%=GetLanguage("Quantity")%><!--商品数量-->
                                                    </th>--%>
                                                    <%--<th><%=GetLanguage("QuantityPayment")%><!--付款数量-->
                                                    </th>--%>
                                                    <%--<th><%=GetLanguage("QuantityArrival")%><!--到账数量-->
                                                    </th>--%>
                                                    <th><%=GetLanguage("OrderTime")%><%--下订时间--%>
                                                    </th>
                                                    <th><%=GetLanguage("State")%><%--订单状态--%>
                                                    </th>
                                                    <th><%=GetLanguage("Operation")%><%--操作--%>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td th-name='<%=GetLanguage("OrderNumber")%>' >
                                                                <a href="CashOrderDetail.aspx?OrderID=<%#Eval("OrderID")%>">
                                                                    <%# Eval("OrderCode")%></a>
                                                            </td>
                                                            <td  th-name='<%=GetLanguage("OrderAmount")%>'>
                                                                <%#Convert.ToDecimal(Eval("Amount")).ToString("0.00")%>
                                                            </td>
                                                            <%--<td>
                                                                <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold2") / 100)%>
                                                            </td>--%>
                                                          <%--  <td>
                                                                <%#Eval("Number")%>
                                                            </td>--%>
                                                           <%-- <td>
                                                                <%#Convert.ToDecimal(Eval("Number")) + (Convert.ToDecimal(Eval("Number")) * getParamAmount("Gold3") / 100)%>
                                                            </td>--%>
                                                            <td  th-name='<%=GetLanguage("OrderTime")%>'>
                                                                <%#Eval("OrderDate")%>
                                                            </td>
                                                            <td  th-name='<%=GetLanguage("State")%>'>
                                                                <asp:Literal ID="ltStatus" runat="server"></asp:Literal>
                                                                 <div class='time_div<%#(Eval("Status").ToString()=="0") && (Eval("IsFeedback").ToString()=="0")  && (Eval("BStatus").ToString()=="0")&& (Eval("SStatus").ToString()=="0")?"":"1" %>' data-ms='<%#Eval("downtime") %>''>
                                                                    <span class="hh" style="color: red;">0</span>小时
                                                                    <span class="mm" style="color: red;">0</span>分
                                                                    <span class="ss" style="color: red;">0</span>秒
                                                                </div>
                                                            </td>
                                                            <td  th-name='<%=GetLanguage("Operation")%>'>
                                                                <%if (currentCulture == "en-us")
                                                                    {%>
                                                                <asp:LinkButton ID="lbtnPayforEn" runat="server" CommandArgument='<%# Eval("OrderID") %>'
                                                                    Visible='true' CommandName="Payfor" OnClientClick="javascript:return confirm('Confirm payment?')" class="btn btn-custom btn-sm"><%=GetLanguage("Payment")%><!--付款--></asp:LinkButton>
                                                                <asp:LinkButton ID="lbtnSendoutEn" runat="server" class="btn btn-custom btn-sm" CommandName="Sendout" CommandArgument='<%#Eval("OrderID")%>' OnClientClick="return confirm('Has confirmed the payment?')"><%=GetLanguage("ConfirmPayment")%><%--确认已付款--%></asp:LinkButton>
                                                                <asp:LinkButton ID="lbtnUndoneEn" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="Undone" OnClientClick="javascript:return confirm('Confirmation revocation?')" class="btn btn-custom btn-sm">Revoke</asp:LinkButton>
                                                                <%}
                                                                    else
                                                                    {%>
                                                                <asp:LinkButton ID="lbtnPayfor" runat="server" CommandArgument='<%# Eval("OrderID") %>'
                                                                    Visible='true' CommandName="Payfor" OnClientClick="javascript:return confirm('确认付款吗？')" class="btn btn-custom btn-sm"><%=GetLanguage("Payment")%><!--付款--></asp:LinkButton>
                                                                <asp:LinkButton ID="lbtnSendout" runat="server" class="btn btn-custom btn-sm" CommandName="Sendout" CommandArgument='<%#Eval("OrderID")%>' OnClientClick="return confirm('已确认付款了吗？')"><%=GetLanguage("ConfirmPayment")%><%--确认已付款--%></asp:LinkButton>
                                                                <asp:LinkButton ID="lbtnUndone" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="Undone" OnClientClick="javascript:return confirm('确认撤销吗？')" class="btn btn-custom btn-sm"><%=GetLanguage("Revoke") %><%--撤销--%></asp:LinkButton>
                                                                 <asp:LinkButton ID="lbtnNoGetPay" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="NoGetPay" OnClientClick="javascript:return confirm('确认未收到付款吗？')" class="btn btn-custom btn-sm"><%=GetLanguage("NoGetPay") %><%--未收到付款--%></asp:LinkButton>
                                                                <%} %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                   <td colspan="7" class="colspan">
                                                        <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i>
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
            <!-- container -->

        </div>
        <!-- content -->
    <script type="text/javascript"> 
           $(document).ready(function(){ 
              var time = setInterval(function(){ 
                   $(".time_div").each(function(){ 
                       var date=new Date($(this).data("ms")); 
                       if(date!=null&&date.toString()!="Invalid Date"){ 
                           var msVal=date.getTime()-new Date().getTime()+new Date(1970,01,01).getTime(); 
                           if(msVal>0){ 
                               var newTime=new Date(msVal); 
                               hh = newTime.getHours();
                               mm = newTime.getMinutes();
                               ss = newTime.getSeconds();

                               $(this).find(".hh").html(hh); 
                               $(this).find(".mm").html(mm); 
                               $(this).find(".ss").html(ss);
                              // console.log('hh:' + hh+",mm:"+mm+",ss:"+ss);
                               if (hh == 0 && mm == 0 && ss == 0) {
                                   $(this).hide();
                               }
                           } 
                            
                       } 
                    
                   });},1000); 
           }); 
            
       </script>

   
</asp:Content>
