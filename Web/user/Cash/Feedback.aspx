<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="Feedback.aspx.cs" Inherits="Web.user.Cash.Feedback" %>

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
                                    <label class="col-sm-3 control-label"><%=GetLanguage("OrderNumber")%>：<%--订单编号--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltOrderCode" runat="server"></asp:Literal></div>
                                </div>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("OrderTime")%>：<%--下订时间--%></label>
                                    <div class="col-sm-9 form-control-static"><asp:Literal ID="ltOrderDate" runat="server"></asp:Literal>  </div>
                                </div>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("BuyNote")%>：<%--购买备注--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltBRemark" runat="server"></asp:Literal></div>
                                </div>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("SalesNote")%>：<%--销售备注--%></label>
                                    <div class="col-sm-9 form-control-static"> <asp:Literal ID="ltSRemark" runat="server"></asp:Literal></div>
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
                                    <label class="col-sm-3 control-label">售卖数量<!--售卖数量-->：</label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltSellNumber" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label">购买数量<!--购买数量-->：</label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltBuyNumber" runat="server"></asp:Literal>
                                    </div>
                                </div>
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"> 支付金额<%--支付金额--%>：</label>
                                    <div class="col-sm-9 form-control-static">
                                     <asp:Literal ID="ltAmount" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
						</div>
					</div>
                </div>
				 	<div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("SellerInfo")%><%--卖家信息--%></h4>
                            <div class="row form-horizontal">
                        		<div class="form-group col-sm-6" style="display:none;">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MembershipNumber") %>：<%--会员编号--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltUserCode" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MemberNickname")%>：<%--昵称--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltNiceName" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                 <div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("ContactPhone")%>：<%--手机号码--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltPhoneNum" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                
                                 
                           <h5 class="page-header"></h5>
                        
                                 <div class="form-group col-sm-6" style="height:26px;">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("ReceiveAccount") %>：<%--收款账户--%></label>
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
                                    <label class="col-sm-3 control-label"><%=GetLanguage("BankAccount")%>：<%--银行帐号--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                                                
                                <div class="form-group col-sm-6" id="divBankAccountUser" runat="server">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("AccountName")%>：<%--开户姓名--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6" id="divQRNiceName" runat="server">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("MemberNickname")%>：<%--昵称--%></label>
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
                                </div>
                                 
                            </div>
						</div>
					</div>
                </div>
                     <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                          
                             <h6><%=GetLanguage("BuyersInfo")%><%--买家信息--%>：</h6>
                            <div class="row form-horizontal">
                        		<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label"> <%=GetLanguage("MemberNickname")%><%--会员编号--%>：</label>
                                    <div class="col-sm-9 form-control-static">
                                      <asp:Literal ID="ltBUserCode" runat="server"></asp:Literal>
                                    </div>
                                </div>
                    			
                    			<div class="form-group col-sm-6">
                                    <label class="col-sm-3 control-label">   <%=GetLanguage("ContactPhone")%><%--买家手机号码--%>：</label>
                                    <div class="col-sm-9 form-control-static">
                                      <asp:Literal ID="ltBPhoneNum" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="form-group  col-sm-6">
                                    <label class="col-md-3 control-label">图片凭证<!--上传凭证-->：<span class="required">&nbsp;</span>
                                    </label>
                                     <div class="col-md-9">
                                    <span class="file-input has-error">
                                        <div class="file-preview">
                                            <div class="file-drop-zone clearfix">
                                                <div class="file-preview-frame">
                                                            
                                                    <img id="previewImage" class="previewImage" runat="server" src="/images/uploadfile.png" style="min-width: 160px; max-height: 120px;" alt="暂无图片" />
                                                    <input type="hidden" id="hiddenupimage" name="hiddenupimage" value="" />
                                                </div>
                                            </div>
                                        </div>
                                    </span>
                                         </div>
                                </div>
                            </div>
                            
						</div>
					</div>
                </div>
                <!-- End row -->
                <div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("Feedback")%><%--反馈信息--%></h4>
                            <div class="row form-horizontal">
                        		<div class="form-group col-sm-12">
                                    <label class="col-sm-1 control-label"> <%=GetLanguage("Reason")%><%--原因说明--%></label>
                                    <div class="col-sm-9 form-control-static">   
                                        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                    			<div class="form-group col-sm-12">
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-custom " OnClick="btnSubmit_Click" />
                                     &nbsp;&nbsp;<a class="btn btn-none " onclick="javascript:history.go(-1)"><%=GetLanguage("Return") %></a>
                                </div>
                            </div>
						</div>
					</div>
                </div>


            </div> 
           
            <!-- container -->

        </div> <!-- content -->
     <script src="/js/BigPicture.min.js"></script>
        <script>

            (function () {

                function setClickHandler(id, fn) {
                    document.getElementById(id).onclick = fn;
                }

                setClickHandler('<%=previewImage.ClientID%>', function (e) {
                    if ($(e.target).attr("src") == "") return;
                    e.target.tagName === 'IMG' && e.target.className === 'previewImage' && BigPicture({
                        el: e.target,
                        imgSrc: $(e.target).attr("src")
                    });
                });

            })();
        </script>
 
    </asp:Content>
