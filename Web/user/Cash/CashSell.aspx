<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="Cashsell.aspx.cs" Inherits="Web.user.Cash.Cashsell" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="../../JS/ValidateData.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        function CheckQuantity() {
            var strNumber = $('.txtNumber').val();
            var strPrice = $('.txtPrice').val();
            if ((Trim(strNumber) != "" || Trim(strNumber) != "0") && (Trim(strPrice) != "" || Trim(strPrice) != "0")) {
                document.getElementById("spanAmount").innerHTML = strNumber * strPrice;
            }
            else {
                document.getElementById("spanAmount").innerHTML = "0";
            }
        }

        function CheckData() {
            var strNumber = $('.txtNumber').val();
            var strUnitNum = document.getElementById("txtUnitNum").value;
            var strThreePassword = $('.txtThreePassword').val();

            if (Trim(strNumber) == "" || Trim(strNumber) == "0") {
                alert("请输入单件商品数量！");
                return false;
            }

            if (Trim(strUnitNum) == "" || Trim(strUnitNum) == "0") {
                alert("请输入发布件数！");
                return false;
            }
            if (Trim(strThreePassword) == "" || Trim(strThreePassword) == "0") {
                alert("请输入二级密码！");
                return false;
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- Start right Content here -->
   
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
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                 <div class="form-group col-sm-6" style="height:26px;">
                                    <label class="col-sm-3 control-label"><%=GetLanguage("ReceiveAccount") %><%--收款账户--%></label>
                                    <div class="col-sm-9 form-control-static">
                                        <div class="input-group">
                                        <asp:DropDownList ID="dorpReceiveAccount" runat="server" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="dorpReceiveAccount_SelectedIndexChanged" >
                                            
                                        </asp:DropDownList>
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
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("ConsignmentInfo")%><%--寄售信息--%></h4>
                            <div class="row">
                                <div class="form-horizontal col-sm-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><%=GetLanguage("GoldBalance")%><%--金币结余--%></label>
                                        <div class="col-md-10 form-control-static">
                                            <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                                            <span class="text-danger"></span>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label"><span class="text-danger">*</span> <%=GetLanguage("Quantity")%><%--商品数量--%></label>
                                                <div class="col-md-10">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtNumber" runat="server" class="form-control txtNumber" onkeydown="this.value=this.value.replace(/\D/g,'')" onKeyPress="this.value=this.value.replace(/\D/g,'')" AutoPostBack="True" OnTextChanged="txtNumber_TextChanged"></asp:TextBox>


                                                        <span class="input-group-addon"><%=GetLanguage("GoldCoin")%><%--个金币--%></span>
                                                    </div>
                                                    <span class="help-block"><small>(<%=GetLanguage("Mini")%><%--最少--%><%=getParamInt("Gold1") %><%=GetLanguage("GoldCoin")%><%--个金币--%>)</small></span>
                                                </div>
                                            </div>
                                            <%--<div class="form-group">
                                                <label class="col-md-2 control-label"><span class="text-danger">*</span> <%=GetLanguage("CommodityPrices")%><!--商品价格--></label>
                                                <div class="col-md-10">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtPrice" class="form-control txtPrice" precision="2" runat="server" onblur="CheckQuantity();" onkeyup="value=value.replace(/[^\d.]/g,'')" onafterpaste="this.value=this.value.replace(/[^\d.]/g,'')"></asp:TextBox>
                                                        <!--金币-->
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                                   <span class="input-group-addon">$</span>
                                                    </div>
                                                    <span class="help-block"><small><%=GetLanguage("LowestPrice")%>:<%=getParamAmount("GoldMin")%>RMB<%=GetLanguage("HighestPrice")%>:<%=getParamAmount("GoldMax")%>RMB<span id="spanPrice"></span><span id="spanService"></span></small></span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label"><%=GetLanguage("GoodsAmount")%><!--商品金额--></label>
                                                <div class="col-md-10 form-control-static"><span id="spanAmount"></span>$</div>
                                            </div>--%>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label"><%=GetLanguage("Factorage")%><%--手续费--%></label>
                                                <div class="col-md-10">
                                                    <div class="input-group">
                                                        <input name="txtFactorage" type="text" id="txtFactorage" runat="server" disabled="disabled" class="form-control" />
                                                        <span class="input-group-addon"><%=GetLanguage("FeeCoin")%><%--个保证金--%></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label"><span class="text-danger">*</span> <%=GetLanguage("SecondPassword")%><%--二级密码--%></label>
                                        <div class="col-md-10">
                                            <input name="txtThreePassword" type="password" id="txtThreePassword" runat="server" class="form-control txtThreePassword" />
                                        </div>
                                    </div>
                                    <div class="form-group m-b-0">
                                        <div class="col-sm-offset-2 col-sm-10">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-custom " OnClientClick="CheckData()" OnClick="btnSubmit_Click" />
                                            &nbsp;<asp:Literal ID="ltWarning" runat="server"></asp:Literal>
                                        </div>
                                    </div>
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
