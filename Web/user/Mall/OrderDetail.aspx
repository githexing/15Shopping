<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/Index.Master" CodeBehind="OrderDetail.aspx.cs" Inherits="Web.user.Mall.OrderDetail" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div class="content">
            <div class="container">
		    <!--主体开始-->
			<div class="row">
                <div class="col-md-6 tablet-column-reset" >
				    <div class="panel panel-default">
						<div class="panel-heading">
	                        <h3 class="panel-title">订单详情</h3>
		                </div>

                        <div class="widget-body innerAll overthrow" style="padding: 20px 0 0 10px; line-height: 1.5;">
						    <div class="row">
							    <p class="col-md-12">订单编号：<asp:Literal runat="server" ID="ltOrderCode"></asp:Literal></p>
                                <p class="col-md-4">总金额：<asp:Literal runat="server" ID="ltTotalAmount"></asp:Literal></p>
								<p class="col-md-4">收货人姓名：<asp:Literal runat="server" ID="ltUserName"></asp:Literal></p>
                                <p class="col-md-4">手机号码：<asp:Literal runat="server" ID="ltPhone"></asp:Literal></p>
								<p class="col-md-12">收货地址：<asp:Literal runat="server" ID="ltAddress"></asp:Literal></p>
                                <p class="col-md-4">订单状态：<asp:Literal runat="server" ID="ltStateName"></asp:Literal></p>
								<p class="col-md-4">快递公司：<asp:Literal runat="server" ID="ltGongsi"></asp:Literal></p>
								<p class="col-md-4">快递单号：<asp:Literal runat="server" ID="ltDanhao"></asp:Literal></p>
                                <p class="col-md-4" style="display:none">运营中心编号：<asp:Literal runat="server" ID="Literal1"></asp:Literal></p>
                                <p class="col-md-4" style="display:none>运营中心手机号码：<asp:Literal runat="server" ID="Literal2"></asp:Literal></p>
                                <p class="col-md-6">创建时间：<asp:Literal runat="server" ID="ltAddTime"></asp:Literal></p>
							</div>
						</div>


						<div class="widget-body" style="padding: 20px;overflow: auto;">
						    
                            <div class="form-group">
								<label class="col-md-4 control-label"></label>
								<div class="col-md-8">
									<p class="form-control-static">
                                        <input type="hidden" id="hdsend" runat="server" />
                                        <input type="hidden" id="hdoid" runat="server" />
                                        <a href="javascript:void(0);" class="ho" id="sure">完成</a>
									</p>
								</div>
							</div>
							<div style="clear:both;"></div>
						</div>
						<footer class="data-footer innerAll half text-right clearfix"></footer>
					</div>
				</div>

			    <div class="col-md-6 tablet-column-reset" >
                    
				    <div class="panel panel-default">
						<div class="panel-heading">
	                        <h3 class="panel-title">订单商品</h3>
		                </div>

						<div class="widget-body innerAll overthrow" style="padding: 20px;overflow: auto;">
                            <table class="table table-bordered table-primary">
							    <thead>
								    <tr class="tac">
									    <th>商品编号</th>
									    <th>商品名称</th>
										<th>商品价格</th>
										<th>购买数量</th>
										<th>总金额</th>
									</tr>
								</thead>
								<tbody>
                                    <asp:Repeater runat="server" ID="Repeater1">
                                        <ItemTemplate>
									<tr class="tac">
									    <td><%#Eval("GoodsCode") %></td>
										<td><%#Eval("ProcudeName") %></td>
										<td>￥<%#Eval("Price") %></td>
										<td><%#Eval("OrderSum") %></td>
										<td>￥<%#Eval("OrderTotal") %></td>
									</tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <tr id="tr1" runat="server" class="panel panel-default">
                                        <td>暂无记录</td>
                                    </tr>
								</tbody>
                            </table>
							<div style="clear:both;"></div>
						</div>
						<footer class="data-footer innerAll half text-right clearfix"></footer>
					</div>
                        
                    
				</div>
                        
		    </div>
		    <!--./主体开始-->
		</div>
    </div>
    <script type="text/javascript">
        $(function () {
            var isend = $("#hdsend").val();

            if (isend == 1) {
                //$("#cancel").show();
                $("#sure").hide();
            }
            else if (isend == 2) {
                //$("#cancel").hide();
                $("#sure").show();
            }
            else if (isend == 3) {
                //$("#cancel").hide();
                $("#sure").hide();
            }
            else {
                //$("#cancel").hide();
                $("#sure").hide();
            }

            //$("#cancel").on('click', function () {
            //    var oid = $("#hdoid").val();
            //    $.ajax({
            //        type: 'POST',
            //        url: '/ajax/OrderAjax.ashx',
            //        data: { act: "cancel", oid: oid },
            //        dataType: 'json',
            //        success: function (data) {
            //            //console.log(data.state);
            //            if (data.state == 'True') {
            //                window.location.reload();
            //            }
            //        },
            //        error: function (msg) {
            //            console.log(msg);
            //        }
            //    });
            //});

            $("#sure").on('click', function () {
                var oid = $("#hdoid").val();
                $.ajax({
                    type: 'POST',
                    url: '/ajax/OrderAjax.ashx',
                    data: { act: "sure", oid: oid },
                    dataType: 'json',
                    success: function (data) {
                        //console.log(data.state);
                        if (data.state == 'True') {
                            window.location.reload();
                        }
                    },
                    error: function (msg) {
                        console.log(msg);
                    }
                });
            });

        })
    </script>
</asp:Content>
