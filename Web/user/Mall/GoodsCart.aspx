<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/Index.Master" CodeBehind="GoodsCart.aspx.cs" Inherits="Web.user.Mall.GoodsCart" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".nav-nav").eq(3).addClass("nav-active")
        });
    </script>
    <style type="text/css">
        .divnone {
            display: none;
        }

        .divnxs {
            display: block;
        }

        .cart-list {
        }

        .cart-li {
            padding: 20px 0;
            margin: 0 20px;
            border-bottom: 1px solid #f5f5f5;
        }

        .cart-img {
            max-width: 220px;
            max-height: 120px;
            float: left;
            margin-right: 10px;
            overflow: hidden;
        }

            .cart-img img {
                max-width: 100%;
            }

        .cart-info {
            float: left;
            width: 500px;
        }

        .cart-title {
            margin: 0 10px 10px 0;
            overflow: hidden;
            -ms-text-overflow: ellipsis;
            text-overflow: ellipsis;
            white-space: nowrap;
        }

        .cart-sp {
            margin-bottom: 5px;
        }

        .cart-del {
            display: inline-block;
            padding: 5px 8px;
            background: #e98034;
            color: #fff;
            border-radius: 4px;
            margin-bottom: 10px;
        }

            .cart-del:hover,
            .cart-del:focus {
                color: #fff;
                text-decoration: none;
            }

            .cart-del:hover {
                background-color: #ff984e;
            }

        .cart-numbtn {
        }

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
    </style>

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="content">
        <div class="container">
			<!--主体开始-->
			<div class="row">
			    <div class="col-md-12 tablet-column-reset form-inline">
				    <div class="panel panel-default">
						<div class="panel-heading">
	                        <h3 class="panel-title">购物车   <asp:DropDownList CssClass="form-control" runat="server" name="ddlType" ID="ddlType" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></h3>

		                </div>
								
						<div class="widget-body" style="padding: 20px;overflow: auto;">
							<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                       <div style="margin:20px 0 0 20px;" class="">
                                <div class="form-group" style="display:none">
							        <label class="control-label">请选择运营中心：</label>
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="DropDownList2" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group">
								    <label class="control-label"></label><asp:Label runat="server" ID="Label1"></asp:Label>
								</div>
							</div>
						    <div style="margin:20px 0 0 20px;" class="">
                                <div class="form-group">
							        <label class="control-label">请选择收货地址：</label>
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="dropAddress" AutoPostBack="True" OnSelectedIndexChanged="dropAddress_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="form-group">
								    <label class="control-label">详细地址：</label><asp:Label runat="server" ID="lbAddess"></asp:Label>
								</div>
							</div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
						</div>
								
						<div id="divlist" class="cart-list">
                            <div class="cart-li clearfix">
                                <input type="checkbox" class="allselect" id="btnselectAll"/>全选
                            </div>
                            <asp:Repeater runat="server" ID="RepeaterCar">
                                <ItemTemplate>
                                    <div class="cart-li clearfix">
                                        <div class="cart-img">
                                            <input type="checkbox" class="cartselect" value='<%#Eval("ID") %>' runat="server" />
                                        </div>
							            <div class="cart-img">
                                            <img src='../../Upload/<%#Eval("Pic1") %>' alt=""/>
							            </div>
								        <div class="cart-info">
									        <h3 class="cart-title"><a href='Goodsdetail.aspx?gid=<%#Eval("GoodsID") %>'><%#Eval("GoodsName") %></a></h3>
									        <%--<div class="cart-sp">颜色分类：红色</div>--%>
									        <div class="cart-sp">价格：¥<%#Eval("RealityPrice") %></div>
									        <%--<div class="cart-sp">数量：<%#Eval("Goods006") %></div>--%>
								        </div>
								        <div class="cart-handle">
									        <a href="javascript:;" class="cart-del" >删除</a>
									        <div class="cart-numbtn">
										        <input type="button" name="" id="minus" class="minus" value="-" />
										        <input type="number" name="" id="cartnum" class="cartnum" value='<%#Eval("Goods006") %>' />
										        <input type="button" name="" id="add" class="add" value="+" />
                                                <input type="hidden" class="carid" runat="server" value='<%#Eval("ID") %>' />
									        </div>
								        </div>
							        </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <input type="hidden" id="hdVlaue" runat="server" class="hdVlaue" value="0"/>
                            <input type="hidden" id="hduid" runat="server" class="hduid" value="0"/>
                            <div class="checkcart" style="font-size:13px;text-align:right;padding: 0 20px 20px 20px;">
                                <p>总价：<span class="prices">￥0</span></p>
                               <%--   <input type="radio" id="radio4"  name="radio4"  value="1"   >自提</>
                                <input type="radio" id="radio5"  name="radio5"  value="2" >快递</>--%>
                                <br />
                                  <div id="radio2_div" style="display:none">
                                         <input type="radio" id="radio4"  name="radio4"   value="2"><label for="radio4">100%报单积分</label></>
                                 </br><input type="radio" id="radio3"  name="radio3"  value="1"><label for="radio3">50%电子积分+50%报单积分</label></> 
                                </div>  
                                <div id="radio1_div" style="display:none">
                              <%--  <input type="radio" id="radio1"  name="radio1"  value="1"   >电子积分</>--%>
                                <input type="radio" id="radio2"  name="radio2"  value="2" >种子积分</>
                                </div>
                                  <div id="radio3_div" style="display:none"> 
                                <input type="radio" id="radio3_1"  name="radio3_1"  value="1">50%电子积分+50%报单积分</> 
                                </div>  
                                   <div id="radio4_div" style="display:none"> 
                                <input type="radio" id="radio4_1"  name="radio4_1"  value="1"><label for="radio4_1">消费积分</label></> 
                                </div>  
                                </br>
                                <input type="button" id="paybtn" value="支付" class="btn btn-primary"  />
                            </div>
						</div>
                        
						<footer class="data-footer innerAll half text-right clearfix"></footer>
                        <div id="divempty" style="font-size:18px;text-align:center;">
                            <div class="emptycart">您的购物车是空的～</div>
                        </div>
					</div>
                    
				</div>
			</div>
		</section>
    </div>
    <script src="../../JS/jquery-1.11.3.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var checkText = $("#<%=ddlType.ClientID%>").find("option:selected").val();//复投还是报单 
            if (checkText==0) {
                $("#radio1_div").attr("style", "display:none")
                $("#radio2_div").attr("style", "display:none")
                $("#radio3_div").attr("style", "display:none")
            }
            else if (checkText == 2) {
                $("#radio1_div").attr("style", "display")
             
            }
            else if (checkText==1) {
                $("#radio2_div").attr("style", "display")
            }
            else if (checkText == 3) {
                $("#radio3_div").attr("style", "display")
            }
            else if (checkText == 4) {
                $("#radio4_div").attr("style", "display")
            }

        })
        $(function () {
            //$('input:radio[name="radio1"]').click(function () {
              
            //       $("#radio2").removeAttr("checked");
                  
               
            //})
            //$('input:radio[name="radio2"]').click(function () {
               
            //     $("#radio1").removeAttr("checked");
               
            //})
            $('input:radio[name="radio4"]').click(function () {

                $("#radio3").removeAttr("checked");


            })
            $('input:radio[name="radio3"]').click(function () {

                $("#radio4").removeAttr("checked");

            })

        })
        $(function () {
            var $allselect = $(".allselect");
            var $cartselect = $(".cartselect");
            var selectnum = 0;
            var $minus = $(".minus");
            var $add = $(".add");
            var $cartnum = $(".cartnum");
            var $paybtn = $("#paybtn");
            var $allpricebox = $(".checkcart .prices");
            var $price = $(".cart-list .cart-sp");
            var $hdid = $(".carid");
            var $delid = $(".cart-del");

            var $divD = $("#divempty");
            var $divE = $("#divlist");
            var a = $(".hdVlaue").val();
            if (a == 0) {
                $divD.addClass("divnone");
                $divE.addClass("divnxs");
            }
            else {
                $divD.addClass("divnone");
                $divE.addClass("divnxs");
            }
            


            function getprice() {
                var $totalprice = 0;
                $.each($cartnum, function (i, o) {
                    if ($cartselect.eq(i).prop("checked")) {
                        var price = $price.eq(i).html();
                        console.log('price:' + price);
                        console.log('num:' + o.value);
                        $totalprice = $totalprice + (o.value * price.substr(4)) * 100;
                    }
                });

                $totalprice = parseInt($totalprice);
                $allpricebox.html('￥' + $totalprice / 100);
            }

            $delid.on('click', function () {
                var a = $delid.index(this);
                var cid = $hdid.eq(a).val();
                console.log(cid);
                $.ajax({
                    type: 'POST',
                    url: '/APPService/Mall.ashx',
                    data: { act: "del", cartid: cid },
                    success: function (result) {
                        var data = eval('(' + result + ')');
                        alert(data.message);
                        if (data.state == 'success') {
                            window.location.reload();
                        }
                    },
                    error: function (msg) {
                        //$(".notice").html('Error:'+msg);
                        console.log(msg);
                    }
                });
            });

            $minus.on('click', function () { 
                var a = $minus.index(this);
                //console.log("index:" + a);
                var num = $cartnum.eq(a).val();
                var cid = $hdid.eq(a).val();
                $.ajax({
                    type: 'POST',
                    url: '/APPService/Mall.ashx',
                    data: { act: "minus", cartid: cid },
                    success: function (result) {
                        var data = eval('(' + result + ')');
                        alert(data.message);
                        if (data.state == 'success') {
                            $cartnum.eq(a).val(Math.max(--num, 1));
                            if (selectnum) {
                                getprice();
                            }
                        }
                    },
                    error: function (msg) {
                        //$(".notice").html('Error:'+msg);
                        console.log(msg);
                    }
                });
            });

            $add.on('click', function () {
                var b = $add.index(this);
                var num = $cartnum.eq(b).val();
                var cid = $hdid.eq(b).val();
                $.ajax({
                    type: 'POST',
                    url: '/APPService/Mall.ashx',
                    data: { act: "add", cartid: cid },
                    dataType: 'json',
                    success: function (result) {
                        var data = eval('(' + result + ')');
                        alert(data.message);
                        if (data.state == 'success') {
                            $cartnum.eq(b).val(Math.max(++num, 1));
                            if (selectnum) {
                                getprice();
                            }
                        }
                    },
                    error: function (msg) {
                        console.log(msg);
                    }
                });

                $cartnum.eq($add.index(this)).val(num * 1 + 1);
                if (selectnum) {
                    getprice();
                }
            });

            $cartselect.on('click', function () {
                if (this.checked) {
                    selectnum++;
                } else {
                    selectnum--;
                }
                //if (selectnum < $cartselect.length) {
                //    $allselect.removeClass("checked");
                //} else {
                //    $allselect.addClass("checked");
                //}
                if (selectnum) {
                    $paybtn.html('支付(' + selectnum + ')');
                } else {
                    $paybtn.html('支付');
                }
                getprice();
            });
            //全选
            $allselect.on('click', function () {
                if ($(this).hasClass("checked")) {
                    $cartselect.prop("checked", null);
                    $(this).removeClass("checked");
                    selectnum = 0;
                } else {
                    selectnum = $cartselect.length;
                    $cartselect.prop("checked", "true");
                    $(this).addClass("checked");
                }

                if (selectnum) {
                    $paybtn.html('支付(' + selectnum + ')');
                } else {
                    $paybtn.html('支付');
                }
                getprice();
            });

            $paybtn.on('click', function () {
                var idsstr = "";
                var isc = "";
                var iuid = $(".hduid").val();
                $cartselect.each(function () { //遍历table里的全部checkbox
                    var va = $(this).val();
                    idsstr += va + ","; //获取所有checkbox的值
                    if ($(this).is(":checked")) {//如果被选中
                        isc += va + ","; //获取被选中的值
                    }
                });
                isc = isc.substring(0, isc.length - 1);
                //console.log("总：" + idsstr);
                //console.log("选：" + isc);
                var paytype = 1;
                if (paytype <= 0) {
                    alert("请选择结算的账户");
                    return;
                }
                if (isc.length == 0) {
                    alert("请选择购物车中的商品");
                    return;
                }
                var addrid = $("#<%=dropAddress.ClientID%>").val();
                if (addrid <= 0) {
                    alert("请选择收货地址");
                    return;
                }
                if (isc.length > 0) {
                    var checkText = $("#<%=ddlType.ClientID%>").find("option:selected").val();//复投还是报单 
                    var r;
                    if (checkText == '1') {
                        var r1 = $('input:radio[name="radio4"]').is(":checked")
                        var r2 = $('input:radio[name="radio3"]').is(":checked")
                        if (!r1 && !r2) {
                            alert("请选择报单产品支付方式");
                            return;
                        }
                        if (r1) {
                            r = "1-1";
                        }
                       else if (r2) {
                            r = "1-2";
                        }
                        
                    }
                   else if (checkText == '2') { 
                        //var r1 = $('input:radio[name="radio1"]').is(":checked")
                        var r2 = $('input:radio[name="radio2"]').is(":checked")  
                        if (!r2 ) {
                            alert("请选择复购产品支付方式");
                            return;
                        }
                       if (r2) {
                            r = "2-2";
                        }
                    }
                   else if (checkText == '3') {
                        //var r1 = $('input:radio[name="radio1"]').is(":checked")
                       var r2 = $('input:radio[name="radio3_1"]').is(":checked")
                        if (!r2) {
                            alert("请选择原点升级产品支付方式");
                            return;
                        }
                        if (r2) {
                            r = "3-1";
                        }
                    }
                   else if (checkText == '4') {
                        //var r1 = $('input:radio[name="radio1"]').is(":checked")
                       var r2 = $('input:radio[name="radio4_1"]').is(":checked")
                        if (!r2) {
                            alert("请选择兑换产品支付方式");
                            return;
                        }
                        if (r2) {
                            r = "4-1";
                        }
                    }

                    //var YY = $("#ctl00_ContentPlaceHolder1_DropDownList2").find("option:selected").val();//运营中心 
                    //alert(YY);
                    //r += "-" + YY;
                    //var r11 = $('input:radio[name="radio4"]').is(":checked")
                    //var r22 = $('input:radio[name="radio5"]').is(":checked")
                    //if (!r11 && !r22) {
                    //    alert("请选择送货方式");
                    //    return;
                    //}
                    //if (r11) {

                    //    r += "-1";
                    //}
                    //else if (r22) {
                    //    r += "-2";
                    //}



                 
                    $.ajax({
                        type: 'POST',
                        url: '/APPService/Mall.ashx',
                        data: { act: "pay", cartidlist: isc, uid: iuid, paytype: paytype, addrid: addrid, checked: r },
                        success: function (result) {
                            var data = eval('(' + result + ')');
                            alert(data.message);
                            if (data.state == 'success') {
                                window.location.href = "/user/Mall/OrderList.aspx";
                            }
                        },
                        error: function (msg) {
                            console.log(msg);
                        }
                    });
                }
            });



            //var a = $(".hdVlaue").val();
            //var divD = document.getElementsByClassName("divlist");
            //var divE = document.getElementsByClassName("divempty");
            //if (a == 0) {//空
            //    divD.style.display = "none";
            //    divE.style.display = "block";
            //}
            //else {
            //    divD.style.display = "block";
            //    divE.style.display = "none";
            //}
        });

    </script>
</asp:content>
