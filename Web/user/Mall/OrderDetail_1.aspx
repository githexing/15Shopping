<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/Index.Master" CodeBehind="OrderDetail_1.aspx.cs" Inherits="Web.user.Mall.OrderDetail_1" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    	<div class="panel panel-default">
    	<div class="widget-body innerAll overthrow" style="padding: 20px;overflow: auto;">
    	<div class="widget-body innerAll overthrow col-md-12" style="padding: 20px;overflow: auto;">
             
      <div class="Member_right">
            <div class="operation">
          <%--      <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton" iconcls="icon-back"    >  --%>
           <a href="javascript:history.go(-1)"  class="easyui-linkbutton" iconcls="icon-back"   >  > 返 回</a><%--</asp:LinkButton>--%> <br />
                <br />
                <fieldset class="fieldset">
                    <legend class="legSearch">订单信息</legend>
                    订单号：<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label"></asp:Label>&nbsp;
                代理编号：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>&nbsp;
                收货人姓名：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>&nbsp;
                收货地址：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>&nbsp;
              <%--  总金额：<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Label"></asp:Label>&nbsp;--%>
                快递公司：<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>&nbsp;
                快递单号：<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>&nbsp;
                </fieldset>
                <!--end operatio-->
            </div>
            <!--end operation 操作-->

            <div class="dataTable">
                <table class="table table-bordered table-primary table-merge">
                    <tr>
                        <th align="center">商品图片
                        </th>
                        <th align="center">商品编号
                        </th>
                        <th align="center">商品名称
                        </th>
                        <th align="center">市场价格
                        </th>
                        <th align="center">本站价格
                        </th>
                        <th align="center">购买数量
                        </th>
                        <th align="center">总金额
                        </th>
                        <th align="center">购买日期
                        </th>
                           <th align="center">运营中心编号
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr align="center">
                                <td><a href='#' target="_blank">
                                    <img alt="" src='../../Upload/<%# Eval("Pic1") %>' width="100" height="100" /></a>
                                </td>
                                <td>
                                    <%#Eval("GoodsCode")%>
                                </td>
                                <td>
                                    <%#Eval("GoodsName")%>
                                </td>
                                <td>
                                    <%#Eval("Price")%>
                                </td>
                                <td>
                                    <%#Eval("ShopPrice")%>
                                </td>
                                <td>
                                    <%#Eval("OrderSum")%>
                                </td>
                                <td>
                                    <%#Eval("OrderTotal")%>
                                </td>
                                <td>
                                    <%#Eval("OrderDate")%>
                                </td>
                                  <td>
                                    <%#userBLL.GetUserCodeByUserID(long.Parse(Eval("order5").ToString()==""?"0":Eval("order5").ToString()))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="yellow">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                        PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>
                </div>
            </div>
            <!--end data 表格数据-->
        </div>
            </div>
            </div>  </div>
    </asp:content>