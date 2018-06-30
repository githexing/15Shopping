<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="CashbuyEdit.aspx.cs" Inherits="Web.user.Cash.CashbuyEdit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("SellerInfo") %><%--卖家信息--%></h4>
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
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
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
                                        <label class="col-md-2 control-label"><asp:Label ID="lblOutQRCodeTitle" runat="server">二维码</asp:Label>：</label>
                                        <div class="col-md-10">
                                           <asp:Image ID="imgOutQRCode" runat="server" ImageUrl="" style="height:200px;" /> 
                                        </div>
                                  
                                 </div>
                                <div class="form-group col-sm-6" id="divBagAddress"  runat="server">
                                        <label class="col-md-2 control-label"><asp:Label ID="Label1" runat="server">地址钱包</asp:Label>：</label>
                                        <div class="col-md-10">
                                           <asp:Literal ID="ltBagAddress" runat="server"></asp:Literal>
                                        </div>
                                    
                    			
                            </div>
                                         </ContentTemplate>
                                </asp:UpdatePanel>
                           </div>
                            </div>
                        </div>
                    </div>
                          
                            <div class="row">
                                <div class="col-sm-12">
                                <div class="card-box">
                                      <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("CommodityInfo")%><%--商品信息--%></h4>
                        		<div class="form-horizontal">
                        			<div class="form-group col-sm-12">
                                        <label class="col-md-3 control-label">商品数量<%--=GetLanguage("GoodsAmount")--%><%--商品金额--%></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltAmount" runat="server"></asp:Literal></div>
                                    </div>
                                    <div class="form-group col-sm-12">
                                        <label class="col-md-3 control-label">剩余数量<%--=GetLanguage("ResidualAmount")--%><%--剩余金额--%></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltResidualAmount" runat="server"></asp:Literal></div>
                                    </div>
                                    <div class="form-group col-sm-12">
                                        <label class="col-md-3 control-label">购买数量<%--=GetLanguage("AmountOfPurchase")--%><%--购买金额--%></label>
                                        <div class="col-md-9 form-control-static"><input name="txtUnitNum" type="text" id="txtUnitNum" runat="server"  value="1" class="form-control" /></div>
                                    </div>
                                    
                        			<%--<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"><%=GetLanguage("Quantity")%><!--商品数量--></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltNumber" runat="server"></asp:Literal></div>
                                    </div>
                        			<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"><%=GetLanguage("CommodityPrices")%><!--商品价格--></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltPrice" runat="server"></asp:Literal>RMB</div>
                                    </div>--%>
                        			<%--<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"><%=GetLanguage("QuantityPayment")%><!--付款数量--></label>
                                        <div class="col-md-9 form-control-static"> <asp:Literal ID="ltPayment" runat="server"></asp:Literal>个</div>
                                    </div>--%>
                        			<%--<div class="form-group col-sm-6">
                                        <label class="col-md-3 control-label"><%=GetLanguage("QuantityArrival")%><!--到账数量--></label>
                                        <div class="col-md-9 form-control-static"><asp:Literal ID="ltArrival" runat="server"></asp:Literal>个</div>
                                    </div>--%>
                        		</div>
                             
                              
                            <div class="row">
                            	<div class="col-md-12">
		                            <div class="form-group m-b-0 text-center">
                                         <asp:Button ID="btnSubmit" runat="server" class="btn btn-custom " OnClientClick="CheckData()" OnClick="btnSubmit_Click" />
		            
		                            </div>
                            	</div>
                            </div>
						</div>
					</div>
                </div>
                
                <!-- End row -->

            </div> <!-- container -->

        </div> <!-- content -->
 
    </asp:Content>
