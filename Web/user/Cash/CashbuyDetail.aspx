<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CashbuyDetail.aspx.cs" Inherits="Web.user.Cash.CashbuyDetail" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 
        <!-- Start content -->
        <div class="content">
            <div class="container">

				<div class="row">
				<%--	<div class="col-sm-12 text-right m-b-10">
						<a href="javascript:history.go(-1)" class="btn btn-sm btn-default"><i class="fa fa-mail-reply-all"></i> 返回</a>
					</div>--%>
				</div>
                <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("CommodityInfo")%><%--商品信息--%></h4>
                            <div class="row">
                        		<div class="form-horizontal">
                        			<%--<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"> <%=GetLanguage("TitleGoods")%><!--商品标题--></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></div>
                                    </div>--%>
                        			<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"> 售卖数量<!--商品数量--></label>
                                        <div class="col-md-9 form-control-static"> <asp:Literal ID="ltNumber" runat="server"></asp:Literal></div>
                                    </div>
                                    
                        			<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"><%=GetLanguage("CommodityPrices")%><!--商品价格--></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltPrice" runat="server"></asp:Literal></div>
                                    </div>
                        			<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"><%=GetLanguage("GoodsAmount")%><%--商品金额--%></label>
                                        <div class="col-md-9 form-control-static"> <asp:Literal ID="ltAmount" runat="server"></asp:Literal></div>
                                    </div>
                                    <div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"> 剩余数量<!--剩余数量--></label>
                                        <div class="col-md-9 form-control-static"> <asp:Literal ID="ltBalanceNumber" runat="server"></asp:Literal></div>
                                    </div>
                        			<%--<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"> <%=GetLanguage("QuantityPayment")%><!--付款数量--></label>
                                        <div class="col-md-9 form-control-static"> <asp:Literal ID="ltPayment" runat="server"></asp:Literal>个</div>
                                    </div>
                                    <div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label">  <%=GetLanguage("QuantityArrival")%><!--到账数量--></label>
                                        <div class="col-md-9 form-control-static">  <asp:Literal ID="ltArrival" runat="server"></asp:Literal>个</div>
                                    </div>--%>
                        		</div>
                            </div>
                            <hr />
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("SellerInfo")%><%--卖家信息--%></h4>
                            <div class="row form-horizontal">
                        		 <div class="row form-horizontal">
                        		<div class="form-group col-sm-6" style="display:none;">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MembershipNumber") %><%--会员编号--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltUserCode" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MemberNickname")%><%--昵称--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltNiceName" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                 <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("ContactPhone")%><%--手机号码--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltPhoneNum" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                
                                 
                           <h5 class="page-header"></h5>
                        
                                 <div class="form-group col-sm-6" style="height:26px;">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("ReceiveAccount") %><%--收款账户--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <div class="input-group">
                                         <asp:Literal ID="ltReceiveAccount" runat="server"></asp:Literal>  
                                        </div>
                                    </div>
                                </div>
                                       
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9 form-control-static">
                                        
                                    </div>
                                </div>
                              
                               <div class="form-group col-sm-6" id="divBankAccount" runat="server">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("BankAccount")%><%--银行帐号--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                                                
                                <div class="form-group col-sm-6" id="divBankAccountUser" runat="server">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("AccountName")%><%--开户姓名--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6" id="divQRNiceName" runat="server">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MemberNickname")%><%--昵称--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltQRNiceName" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                 <div class="form-group col-sm-6" id="divOutQrCode"  runat="server">
                                        <label class="col-md-3 control-label"><asp:Label ID="lblOutQRCodeTitle" runat="server">收款二维码</asp:Label>：</label>
                                        <div class="col-md-9">
                                           <asp:Image ID="imgOutQRCode" runat="server" ImageUrl="" style="height:200px;" /> 
                                        </div>
                                  
                                 </div>
                                <div class="form-group col-sm-6" id="divBagAddress"  runat="server">
                                        <label class="col-md-3 control-label"><asp:Label ID="Label1" runat="server">地址钱包</asp:Label>：</label>
                                        <div class="col-md-9">
                                           <asp:Literal ID="ltBagAddress" runat="server"></asp:Literal>
                                        </div>
                    			<%--<asp:Button ID="btnBack" runat="server" class="btn btn-custom waves-effect waves-light" OnClick="btnBack_Click" />--%>
                                <a class="btn btn-custom waves-effect waves-light" onclick="javascript:history.go(-1)">返回</a>
                            </div>
						</div>
					</div>
                </div>
                
                <!-- End row -->

            </div> <!-- container -->

        </div> <!-- content -->

 
    </asp:Content>