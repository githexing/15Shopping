<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/Index.Master"  CodeBehind="OrderProduct.aspx.cs" Inherits="Web.user.Mall.OrderProduct" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">

<script src="/JS/My97DatePicker/WdatePicker.js"></script>
<div class="content">

      <div class="container">
                <div class="row">
					<div class="col-md-12">
						<div class="panel panel-default">
							<div class="panel-heading">
								<h3 class="panel-title">我的发货订单</h3>
							</div>
							<div class="widget-body innerAll overthrow" style="padding: 20px;overflow: auto;">
								<div class="form-inline">
				            		<div class="form-group">
					                    <label class="inline">订单编号</label>
					                    <input type="text" runat="server" id="txtOrdercode" class="form-control">
					                </div>
					            	<div class="form-group">
                                        <asp:DropDownList runat="server" ID="dropOrderState" class="form-control">
                                            <asp:ListItem value="0">全部</asp:ListItem>
				                			<asp:ListItem value="1">已支付</asp:ListItem>
                                            <asp:ListItem value="2">已发货</asp:ListItem>
				                			<asp:ListItem value="3">已完成</asp:ListItem>
                                        </asp:DropDownList>
					                </div>
					                <div class="form-group">
					                    <label class="inline">发布时间</label>
					                    <div class="input-daterange input-group" id="date-range">
										    <input type="text" class="form-control" runat="server" id="txtStartTime" onfocus="WdatePicker()" name="">
                    					
                                            <span class="input-group-addon bg-inverse b-0 text-white">至</span>
					                    
										    <input type="text" class="form-control" runat="server" id="txtEndTime" onfocus="WdatePicker()" name="">
                    				    </div>
					                </div>
                                    <asp:Button runat="server" ID="btnSearch" Text="搜索" CssClass="btn btn-primary" OnClick="btnSearch_Click"/>
					            </div>
								<div class="widget-body innerAll overthrow col-md-12" style="padding: 20px;overflow: auto;">
								    <table class="table table-bordered table-primary table-merge">
										<thead>
											<tr class="tac">
											   <th align="center">时间
                        </th>
                        <th align="center">订单号
                        </th>
                        <th align="center">会员编号
                        </th>
                      <%--  <th align="center">购买数量
                        </th>--%>

                        <th align="center">总金额/总积分
                        </th>

                        <th align="center">收货人姓名
                        </th>
                        <th align="center">收货地址
                        </th>

                        <th align="center">联系电话
                        </th>

                        <th align="center">快递公司
                        </th>
                        <th align="center">快递单号
                        </th>
                          <th align="center">运营中心编号
                        </th>
                        <th align="center">订单类型
                        </th>
                        <th align="center">状态
                        </th>
                        <th align="center">操作
                        </th>
										    </tr>
										</thead>
										<tbody>
                                            <asp:Repeater runat="server" ID="rpOrderList"  OnItemCommand="rptOrder_ItemCommand">
                                                <ItemTemplate>
											<tr class="tac">
												 <td align="center">
                                    <%#Convert.ToDateTime(Eval("OrderDate")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderCode")%>
                                </td>

                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                               <%-- <td align="center">
                                    <%#Eval("OrderSum")%>
                                </td>--%>

                                <td align="center">
                                    <%#Eval("OrderTotal")%>
                                </td>

                                <td align="center">
                                    <%#Eval("order7")%>
                                </td>

                                <td align="center">
                                    <%#Eval("UserAddr")%>
                                </td>

                                <td align="center">
                                    <%#Eval("order6")%>
                                </td>

                                <td align="center">
                                    <asp:TextBox ID="txtGongsi" runat="server" Text='<%#Eval("order3")%>'></asp:TextBox>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtDanhao" runat="server" Text='<%#Eval("order4")%>'></asp:TextBox>
                                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                </td>
                                 <td align="center">
                                      <%# userBLL.GetUserCodeByUserID(long.Parse(Eval("order5").ToString()==""?"0":Eval("order5").ToString()))%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderType").ToString()=="1"?"报单产品":Eval("OrderType").ToString() =="2"?"复投产品":""%>
                                </td>
                                <td align="center">
                                    <%# GetState(Eval("IsSend").ToString(),Eval("IsDel").ToString())%>
                                </td>

                                <td align="center" width="250">
                                    <asp:HiddenField ID="hft" runat="server" Value='<%# Eval("IsSend") %>' />
                                    <%--<asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                    CommandName="edit">编辑</asp:LinkButton>
                                 <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                   class="easyui-linkbutton" iconcls="icon-edit"  Visible='<%#Convert.ToInt32(Eval("IsSend"))==2?true:false%>' CommandName="save">编辑</asp:LinkButton>&nbsp;--%>
                                    <asp:LinkButton ID="lbtnEnter" runat="server" CommandName="enter" CommandArgument='<%# Eval("OrderCode") %>'
                                        class="easyui-linkbutton" iconcls="icon-ok" Visible='<%#Convert.ToInt32(Eval("IsDel"))>0 ? false: Convert.ToInt32(Eval("IsSend"))==1?true:false%>'
                                        OnClientClick="javascript:return confirm('仔细核对快递公司及单号，确认要发货？')">确认发货</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                        class="easyui-linkbutton" iconcls="icon-search" CommandName="show">查看明细</asp:LinkButton>&nbsp;
                               
                                    <asp:LinkButton ID="lbtnCancel" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                        class="easyui-linkbutton" iconcls="icon-cancel" CommandName="cancel" OnClientClick="javascript:return confirm('确定取消订单？')"
                                        Visible='<%#(Convert.ToInt32(Eval("IsDel")) == 1)?true:false%>'>撤销</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("OrderCode") %>'
                                        class="easyui-linkbutton" iconcls="icon-undo" CommandName="revoke" OnClientClick="javascript:return confirm('确定撤销申请吗？')"
                                        Visible='<%#(Convert.ToInt32(Eval("IsDel")) == 1)?true:false%>'>撤销申请</asp:LinkButton>
                                </td>
											</tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <tr runat="server" id="tr1">
                                                <td colspan="14" align="center">暂无记录</td>
                                            </tr>
										</tbody>
									</table>
									<div class="dataTables_paginate paging_simple_numbers" id="example_paginate">
										<div class="page">
                                            <webdiyer:aspnetpager id="AspNetPager1" runat="server" skinid="AspNetPagerSkin" firstpagetext="首页"
                                                lastpagetext="尾页" nextpagetext="下一页" prevpagetext="上一页" alwaysshow="True" inputboxclass="pageinput"
                                                numericbuttoncount="3" pagesize="10" showinputbox="Never" shownavigationtooltip="True"
                                                submitbuttonclass="pagebutton" urlpaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                                                submitbuttontext="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " direction="LeftToRight"
                                                horizontalalign="Right" onpagechanged="AspNetPager1_PageChanged">
                                            </webdiyer:aspnetpager>
										</div>	
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
</div></div>
    
</asp:content>
