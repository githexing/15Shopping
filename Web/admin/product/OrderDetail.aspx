<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="web.admin.product.OrderDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单详情</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script type="text/javascript" src="../Scripts/Common.js"></script>

    <script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body class="subBody">
    <form id="form1" runat="server" class="box_con">
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
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
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
    </form>
</body>
</html>
