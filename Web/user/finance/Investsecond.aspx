<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master"  CodeBehind="Investsecond.aspx.cs" Inherits="Web.user.finance.Investsecond" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="row m-b-20">
                                <div class="btn-group pull-left m-b-10">
                                <a href="Invest.aspx" class="btn btn-default waves-effect">主帐号</a>
                                <a href="Investsecond.aspx" class="btn btn-custom waves-effect">分帐号</a>
                            </div>
                            </div>
                            <asp:UpdatePanel runat="server"><ContentTemplate>
                            <div class="row m-b-20">
                                <div class="col-sm-12">
                                    <b>投资积分：<span class="text-success"><%=LoginUser.StockMoney%></span> $</b>
                                </div>
                            </div>
                            <div class="row m-b-20">
                                <div class="col-sm-12">
                                    <b>投资金额必须是：<span class="text-danger"><%=InvestSecondAmountMul %></span> 的倍数</b>
                                </div>
                            </div>
                            <div class="row m-b-20">
                                <div class="col-sm-12">
                                    <b>投资累计：<span class="text-danger"><%=InvestSecondAmountMax %></span> $ 封顶</b>
                                </div>
                            </div>
                                 </ContentTemplate></asp:UpdatePanel>
                            <div class="row">
                                <div class="form-inline col-sm-12">
                                    <div class="form-group">
                                        <label>投资金额</label>
                                        <div class="input-group">
                                             <asp:TextBox ID="txtMoney" class="form-control" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                     <asp:UpdatePanel runat="server"><ContentTemplate>
                                    <asp:Button id="btnInvest" runat="server" Text="投资"  class="btn btn-custom waves-effect waves-light btn-md" OnClick="btnInvest_Click" />
                                    </ContentTemplate></asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--	<div class="row">
					<div class="col-sm-12">
						<div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30">查询</h4>
                            <div class="row m-b-20">
                            	<div class="form-inline col-sm-12">
	                                <div class="form-group">
	                        			<label>提现日期</label>
	                    				<div class="input-daterange input-group" id="date-range">
											<input type="text" class="form-control" name="start">
											<span class="input-group-addon bg-inverse b-0 text-white">至</span>
											<input type="text" class="form-control" name="end">
										</div>
	                        		</div>
	                                <button type="submit" class="btn btn-success waves-effect waves-light btn-md">搜索</button>
	                            </div>
                            </div>
                        </div>
					</div>
				</div>--%>

                <asp:UpdatePanel runat="server"><ContentTemplate>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30">投资记录</h4>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0" id="table">
                                            <thead>
                                                <tr>
                                                    <th>帐号</th>
                                                    <th>单号</th>
                                                    <th>投资方式</th>
                                                    <th>投资金额</th>
                                                    <th>时间</th>
                                                    <th>状态</th>
                                                    <%--<th>操作</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td th-name="帐号"><%#Eval("AccountType").ToString() == "1"?"主号":"分号"%></td>
                                                            <td th-name="单号"><%#Eval("OrderCode")%></td>
                                                            <td th-name="投资方式"><%#Eval("InvestType").ToString() == "1"?"投资积分":"复投积分"%></td>
                                                            <td th-name="投资金额"><%#decimal.Parse(Eval("Amount").ToString()).ToString("0.00")%></td>
                                                            <td th-name="时间"><%#Eval("AddTime")%></td>
                                                            <td th-name="状态"><span class="text-success"><%#Eval("OutType").ToString() == "0"?"成功":"已出局"%></span></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="6" class="colspan">
                                                        <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%></div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
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
                </div>
                </ContentTemplate></asp:UpdatePanel>
                <!-- End row -->

            </div>
            <!-- container -->

        </div>
        <!-- content -->
 
</asp:Content>
