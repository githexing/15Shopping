<%@ Page Language="C#" MasterPageFile="~/user/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.user.index" %>

<%@ Register Src="~/userControl/Right.ascx" TagPrefix="uc2" TagName="Right" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:content contentplaceholderid="ContentPlaceHolder1" runat="server">
     
<script type="text/javascript" src="/JS/jquery.qrcode.min.js"></script>

        <div class="content">
            <div class="container">

                <div class="row">
                      <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-success"><%=LoginUser.Emoney%></h2>
                                <h5>奖金积分</h5>
                            </div>
                        </div>
                    </div>
                     <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-pink"><%=LoginUser.StockMoney%></h2>
                                <h5>电子积分</h5>
                            </div>
                        </div>
                    </div>
                 <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-info"><%=LoginUser.BonusAccount%></h2>
                                <h5>消费积分</h5>
                            </div>
                        </div>
                    </div>
                 <%--   <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning"><%=LoginUser.AllBonusAccount%></h2>
                                <h5>种子积分</h5>
                            </div>
                        </div>
                    </div>--%>
                      <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning"><%=LoginUser.StockAccount%></h2>
                                <h5>报单积分</h5>
                            </div>
                        </div>
                    </div>
                    <%-- <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning"><%=LoginUser.GLmoney%></h2>
                                <h5>能量值</h5>
                            </div>
                        </div>
                    </div>
                     <div class="col-lg-4 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">
                                <h2 class="text-warning"><%=LoginUser.AllBonusAccount %></h2>
                                <h5>购物钱包</h5>
                            </div>
                        </div>
                    </div>
                </div>--%>
              <%--  <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">--%>
                                <%--<h2 class="text-purple"></h2>--%>
                               <%-- <div id="leftcode"></div>
                                <h5>左区二维码</h5>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <div class="card-box widget-user">
                            <div class="text-center">--%>
                                <%--<h2 class="text-info"></h2>--%>
                               <%-- <div id="rightcode"></div>
                                <h5>右区二维码</h5>
                            </div>
                        </div>--%>
                   <%-- </div>--%>
                </div>
                <input type="hidden" id="hdleft" value='<%=lefturl %>'/>
                <input type="hidden" id="hdright" value='<%=righturl %>'/>

                <script type="text/javascript">
                    function toUtf8(str) {
                        var out, i, len, c;
                        out = "";
                        len = str.length;
                        for (i = 0; i < len; i++) {
                            c = str.charCodeAt(i);
                            if ((c >= 0x0001) && (c <= 0x007F)) {
                                out += str.charAt(i);
                            } else if (c > 0x07FF) {
                                out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
                                out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
                                out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                            } else {
                                out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
                                out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                            }
                        }
                        return out;
                    }
                    var left = $("#hdleft").val();
                    var right = $("#hdright").val();
                    console.log('sds');
                    console.log(left);
                    console.log(right);
                    $('#leftcode').qrcode(left);
                    $('#rightcode').qrcode(right);
                </script>


                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%--新闻中心--%><%=GetLanguage("NewsInformation") %></h4>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-merge table-responsive">
                                        <table class="table table-condensed m-0">
                                            <thead>
                                                <tr>
                                                    <th><%--序号--%><%=GetLanguage("SerialNumber") %></th>
                                                    <th><%--标题--%><%=GetLanguage("Title") %></th>
                                                    <th><%--时间--%><%=GetLanguage("Time") %></th>
                                                    <th><%--操作--%><%=GetLanguage("Operation") %></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr class="<%# (this.Repeater1.Items.Count + 1) % 2 == 0 ? "odd":"even"%>">
                                                            <td th-name="序号"><%# this.Repeater1.Items.Count + 1%></td>
                                                            <td th-name="标题"><%# getstring(Language,Eval("NewsTitle").ToString(),18)%></a></td>
                                                            <td th-name="时间"><%#Convert.ToDateTime(Eval("PublishTime")).ToString("")%></td>
                                                            <td th-name="操作"><a href="/user/member/NoticeDetail.aspx?ID=<%#Eval("ID") %>" class="btn btn-info btn-sm"><%--查看--%><%=GetLanguage("check") %></a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr id="tr1" runat="server">
                                                    <td colspan="4" class="colspan">
                                                        <div class="form-control-static text-center"><i class="fa fa-warning text-warning"></i><%=GetLanguage("Manager")%><!--抱歉！目前数据库暂无数据显示。--></div>
                                                    </td>
                                                </tr>
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


</asp:content>
