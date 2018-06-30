<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/Index.Master" CodeBehind="Goodsdetail.aspx.cs" Inherits="Web.user.Mall.Goodsdetail" %>


<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="page-heading">
        <i class="fa fa-bar-chart-o"></i>商品购物
    </div>
    <div class="content">
	    <section class="container">
		    <!--主体开始-->
			<div class="panel panel-default">
                <div class="panel-heading">
	                <h3 class="panel-title">商品详情</h3>
		        </div>
                <div class="panel-body">

				    <div class="row form-horizontal">
                        <div class="col-md-4 tablet-column-reset">
						    <div class="widget-body">
							    <div class="form-group">
								    <label class="col-md-12 control-label">
                                        <asp:Image runat="server" ID="Image0" style="max-width:100%; max-height: 300px;"/>
									</label>
							    </div>
							    <div style="clear:both;"></div>
							</div>
					    </div>
                    

                        <div class="col-md-8 tablet-column-reset">
					        <div class="widget-body">
						        <div class="form-group">
							        <label class="col-md-2 control-label">商品编号 :</label>
								    <div class="col-md-10">
									    <p class="form-control-static"><asp:Literal runat="server" ID="ltGoodsCode"></asp:Literal></p>
								    </div>
							    </div>
							    <div class="form-group">
							        <label class="col-md-2 control-label">商品名称 :</label>
								    <div class="col-md-10">
								        <p class="form-control-static"><asp:Literal runat="server" ID="ltGoodsName"></asp:Literal></p>
								    </div>
							    </div>
							    <div class="form-group">
							        <label class="col-md-2 control-label">库存 :</label>
								    <div class="col-md-10">
									    <p class="form-control-static"><asp:Literal runat="server" ID="ltKucun"></asp:Literal></p>
								    </div>
							    </div>
							    <div class="form-group">
								    <label class="col-md-2 control-label">市场价 :</label>
								    <div class="col-md-10">
								        <p class="form-control-static"><asp:Literal runat="server" ID="ltPrice"></asp:Literal></p>
								    </div>
							    </div>
							    <div class="form-group">
								    <label class="col-md-2 control-label">本站价 :</label>
								    <div class="col-md-10">
								        <p class="form-control-static"><asp:Literal runat="server" ID="ltRPrice"></asp:Literal></p>
								    </div>
							    </div>

                                <style type="text/css">
                                    .cart-numbtn input:focus {
                                        outline: none;
                                    }

                                    .cart-numbtn input[type=button] {
                                        width: 35px;
                                        height: 35px;
                                        border: 1px solid #eee;
                                        background-color: #fff;
                                        border-radius: 4px;
                                    }

                                        .cart-numbtn input[type=button]:hover {
                                            background-color: #eee;
                                        }

                                    .cart-numbtn input[type=number] {
                                        width: 80px;
                                        height: 35px;
                                        border: 1px solid #eee;
                                        border-radius: 4px;
                                        text-align: center;
                                    }

                                    .goods-cart {
                                        display: inline-block;
                                        background: #e98034;
                                        color: #fff;
                                        border-radius: 3px;
                                        padding: 5px 8px;
                                    }

                                        .goods-cart:hover {
                                            text-decoration: none;
                                            color: #fff;
                                            background: #d66a1d;
                                        }
                                </style>

                                <div class="form-group">
								    <label class="col-md-2 control-label"></label>
									<div class="col-md-10 cart-numbtn">
									    <input type="button" name="" id="minus" class="minus" value="-">
										<input type="number" name="" id="cartnum" class="cartnum" value="1">
										<input type="button" name="" id="add" class="add" value="+">
									</div>
								</div>
								<div class="form-group">
									<label class="col-md-2 control-label"></label>
									<div class="col-md-10 cart-numbtn">
										<a href="javascript:void(0);" onclick="addgoodscar()" class="goods-cart">加入购物车</a>
									</div>
								</div>

							    <div style="clear:both;"></div>
						    </div>
					    </div>
                    </div>

                    <div class="row">
						<div class="col-md-1"></div>
						<div class="col-md-10">
						    <div class="form-group">
								<p class="form-control-static">
									<asp:Literal runat="server" ID="ltRemark"></asp:Literal>
								</p>
							</div>
						</div>
						<div class="col-md-1"></div>
					</div>
                </div>
            </div>
        </section>
    </div>
    <input type="hidden" id="hdgid" runat="server" class="hdgid" value="0"/>
    <input type="hidden" id="hduid" runat="server" class="hduid" value="0"/>
    <script type="text/javascript">
        var $minus = $(".minus");
        var $add = $(".add");
        var $cartnum = $(".cartnum");

        $minus.on('click', function () {
            var num = $cartnum.val();
            $cartnum.val(num * 1 - 1);
        });

        $add.on('click', function () {
            var num = $cartnum.val();
            $cartnum.val(num * 1 + 1);
        });

        function addgoodscar() {
            var uid = $(".hduid").val();
            var gid = $(".hdgid").val();
            var num = $cartnum.val();
            if (num <= 0) {
                alert("购买数量必须大于0");
                return;
            }
            if (gid <= 0) {
                alert('返回列表页，重新进入详情页');
                return;
            }
            $.ajax({
                type: 'POST',
                url: '/APPService/Mall.ashx',
                data: { act: "buy", gid: gid, uid: uid, buynum: num },
                success: function (result) {
                    var data = eval('(' + result + ')');
                    alert(data.message);
                    if (data.state == 'success') {
                        window.location.href = "/user/Mall/GoodsCart.aspx";
                    }
                },
                error: function (msg) {
                    //$(".notice").html('Error:'+msg);
                    console.log("error:" + msg);
                }
            });
        }
    </script>
</asp:content>
