<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right.ascx.cs" Inherits="Web.userControl.Right" %>

<!-- Start content -->
<div class="content">
    <div class="container">

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="row">
                        <div class="form-inline col-sm-12">
                            <div class="form-group">
                                <label>请选择语言</label>
                                <select name="" class="form-control">
                                    <option value="">-请选择-</option>
                                    <option value="">中文</option>
                                    <option value="">English</option>
                                </select>
                            </div>
                            <button type="submit" class="btn btn-custom waves-effect waves-light btn-md">提交</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-4 col-md-6">
                <div class="card-box widget-user">
                    <div class="text-center">
                        <h2 class="text-success"><%=LoginUser.Emoney%></h2>
                        <h5>原始币</h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-6">
                <div class="card-box widget-user">
                    <div class="text-center">
                        <h2 class="text-pink"><%=LoginUser.BonusAccount%></h2>
                        <h5>现金积分</h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-6">
                <div class="card-box widget-user">
                    <div class="text-center">
                        <h2 class="text-info"><%=LoginUser.StockMoney%></h2>
                        <h5>复投积分</h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-6">
                <div class="card-box widget-user">
                    <div class="text-center">
                        <h2 class="text-warning"><%=LoginUser.StockAccount%></h2>
                        <h5>投资积分</h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-6">
                <div class="card-box widget-user">
                    <div class="text-center">
                        <h2 class="text-purple"><%=LoginUser.ShopAccount%></h2>
                        <h5>释放币</h5>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-6">
                <div class="card-box widget-user">
                    <div class="text-center">
                        <h2 class="text-info">推广链接</h2>
                        <h5>
                            <a href='<%=rem_url %>' target="_brank" class="tga" style="background: none; background-color: transparent; border: none; font-size: inherit; outline: none; color: #06f; float: left;"><%=rem_url %></a>
                        </h5>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <h4 class="header-title m-t-0 m-b-30">新闻中心</h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-merge table-responsive">
                                <table class="table table-condensed m-0">
                                    <thead>
                                        <tr>
                                            <th>序号</th>
                                            <th>标题</th>
                                            <th>时间</th>
                                            <th>操作</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td th-name="序号">1</td>
                                                    <td th-name="标题">第二期中奖名单</td>
                                                    <td th-name="时间">2016/8/20 18:53:54</td>
                                                    <td th-name="操作"><a href="news_detail.html" class="btn btn-info btn-sm">查看</a></td>
                                                </tr>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
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

<footer class="footer">
    Copyright ©2016 XXX
</footer>




