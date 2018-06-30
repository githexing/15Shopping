<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CancelOrder.aspx.cs" Inherits="Web.user.Cash.CancelOrder" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     
        <!-- Start content -->
        <div class="content">
            <div class="container">
				<div class="row">
					
				</div>
				
				<div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("OrderInformation")%><%--订单信息--%></h4>
                            <div class="row form-horizontal">
                        		<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("OrderNumber")%><%--订单编号--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="lblOrderCode" runat="server"></asp:Literal></div>
                                </div>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("OrderTime")%><%--下订时间--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="lbOrderDate" runat="server"></asp:Literal></div>
                                </div>
                    			
                            </div>
						</div>
					</div>
                </div>
				
                	<div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("CommodityInfo")%><%--商品信息--%></h4>
                            <div class="row form-horizontal">
                        		<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"> <%=GetLanguage("TitleGoods")%><%--商品标题--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                                </div>
                    			<%--<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("Quantity")%><!--商品数量--></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltNumber" runat="server"></asp:Literal> </div>
                                </div>--%>
                    			<%--<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("CommodityPrices")%><!--商品价格--></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltPrice" runat="server"></asp:Literal>RMB</div>
                                </div>--%>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"> <%=GetLanguage("GoodsAmount")%><%--商品金额--%></label>
                                    <div class="col-sm-9 form-control-static">  <asp:Literal ID="ltAmount" runat="server"></asp:Literal>RMB</div>
                                </div>
                    				<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"> <%=GetLanguage("QuantityPayment")%><%--付款数量--%></label>
                                    <div class="col-sm-9 form-control-static">  <asp:Literal ID="ltPayment" runat="server"></asp:Literal>个</div>
                                </div>
                    			<%--<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label">  <%=GetLanguage("QuantityArrival")%><!--到账数量--></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltArrival" runat="server"></asp:Literal>个</div>
                                </div>--%>
                            </div>
						</div>
					</div>
                </div>
				 	<div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("SellerInfo")%><%--卖家信息--%></h4>
                            <div class="row form-horizontal">
                        		
                    			
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label">  <%=GetLanguage("BankAccount")%><%--卖家银行帐号--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal></div>
                                </div>
                    				<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label">  <%=GetLanguage("AccountName")%><%--卖家银行姓名--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal></div>
                                </div>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("BankBranch")%><%--卖家开户网点--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltBankBranch" runat="server"></asp:Literal></div>
                                </div>
                                	
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><span class="cRed">*</span><%=GetLanguage("Termination") %><%--终止原因--%></label>
                                    <div class="col-sm-9 form-control-static"><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="280px" Height="80px"></asp:TextBox></div>
                                </div>
                          
                                 <asp:Button ID="btnCheck" runat="server" class="btn btn-custom waves-effect waves-light" OnClick="btnCheck_Click" />
                                &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" class="btn btn-custom waves-effect waves-light" OnClick="btnBack_Click" />
                            </div>
						</div>
					</div>
                </div>
                <!-- End row -->

            </div> <!-- container -->

        </div> <!-- content -->

  
    </asp:Content>