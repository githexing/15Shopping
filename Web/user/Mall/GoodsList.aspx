<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/Index.Master" CodeBehind="GoodsList.aspx.cs" Inherits="Web.user.Mall.GoodsList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div class="page-heading">
        <i class="fa fa-bar-chart-o"></i>商品购物
    </div>

    <style type="text/css">
        .goods-list {
            background: #fff;
            padding: 15px;
            text-align: center;
        }

            .goods-list ul {
                /*display: inline-block;*/
                text-align: left;
                padding: 0;
            }

        .goods-li {
            display: inline-block;
            width: 25%;
            list-style: none;
            padding: 0 1%;
            margin-bottom: 20px;
            float: left;
        }

        .goods-listimg {
            position: relative;
            width: 100%;
            height: 0;
            padding-bottom: 100%;
            display: block;
        }

            .goods-listimg img {
                position: absolute;
                width: 100%;
                height: 100%;
                left: 0;
                top: 0;
                background-color: #eee;
            }

        .goods-title {
            margin-bottom: 0;
            margin-top: 10px;
        }

            .goods-title a {
                color: #333;
                display: block;
                overflow: hidden;
                white-space: nowrap;
                text-overflow: ellipsis;
                font-size: 16px;
            }

                .goods-title a:hover {
                    color: #333;
                    text-decoration: none;
                }

        .goods-sp {
            margin-top: 10px;
            display: inline-block;
        }

            .goods-sp b {
                color: #fd2e46;
            }

        .goods-cart {
            float: right;
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

        @media (max-width: 1400px) {
            .goods-li {
                width: 33.33%;
                font-size: .8rem;
            }
        }

        @media (max-width: 992px) {
            .goods-li {
                width: 50%;
                font-size: .8rem;
            }
        }

        @media (max-width: 768px) {
            .goods-li {
                width: 100%;
                margin-right: 0;
                font-size: .8rem;
            }
        }
    </style>
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>

    <div class="content">
        <div class="container">
            <div class="row">
                    <div class="col-sm-12">

            <div class="clearfix npb" role="tablist" style="margin-bottom: 10px;">
                <asp:Repeater runat="server" ID="RepeaterMenu">
                    <ItemTemplate>
                        <a href='GoodsList.aspx?gt=<%#Eval("ID") %>' id='a<%#Eval("ID") %>' class="btn btn-default"><%#Eval("TypeName") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <input type="hidden" id="hdtype" runat="server" class="hdtype" value="0"/>
            <input type="hidden" id="hduid" runat="server" class="hduid" value="0"/>
            <div class="goods-list">
                <ul class="clearfix">
                    <asp:Repeater runat="server" ID="RepeaterGoods">
                        <ItemTemplate>
                            <li class="goods-li">
                                <span class="goods-listimg">
                                    <a href='goodsdetail.aspx?gid=<%#Eval("ID") %>'>
                                        <img src='../../Upload/<%#Eval("Pic1") %>' alt=""/>
                                    </a>
                                </span>
                                <h3 class="goods-title">
                                    <a href='goodsdetail.aspx?gid=<%#Eval("ID") %>'><%#Eval("GoodsName") %></a>
                                </h3>
                                <span class="goods-sp">库存：<%#Eval("Goods002") %> <b> ¥<%#Eval("RealityPrice") %></b></span>
                                <a href="javascript:void(0);" onclick="addgoodscar('<%#Eval("ID") %>')" class="goods-cart">加入购物车</a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li runat="server" id="li1" style="text-align: center;">
                        <div>
                            暂无记录
                        </div>
                    </li>
                </ul>
            </div>
                        </div>
                </div>
            
            <div class="row">
                    <div class="col-sm-12">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                            NumericButtonCount="3" PageSize="12"  
                            ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"  PagingButtonSpacing="0" 
                            CurrentPageButtonClass ="active"
                            OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
            </div>
                </div>
        </div>
    </div>
    

    <script type="text/javascript">
        $(function () {
            var tid = $(".hdtype").val();
            //console.log("type:"+tid);
            if (tid > 0) {
                $("#a" + tid).addClass("btn btn-primary");
            }
        });
        function addgoodscar(gid) {
            var uid = $(".hduid").val();
            $.ajax({
                type: 'POST',
                url: '/APPService/Mall.ashx',
                data: { act: "buy", gid: gid, uid: uid, buynum: 1},
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
