<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProduct.aspx.cs" Inherits="web.admin.product.OrderProduct" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>激活</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script type="text/javascript" src="../Scripts/Common.js"></script>

    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <style>
        .red {
            color: red;
        }
    </style>
</head>
<body class="subBody">
    <form id="form1" runat="server" class="box_con">
        <div class="Member_right">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">搜索</legend>
                    <a href="OrderProduct.aspx?type=1" iconcls="icon-search" class="easyui-linkbutton">所有记录</a>
                    <a href="OrderProduct.aspx?type=2" iconcls="icon-search" class="easyui-linkbutton">未付款</a>
                    <a href="OrderProduct.aspx?type=3" iconcls="icon-search" class="easyui-linkbutton">待发货</a>
                    <a href="OrderProduct.aspx?type=4" iconcls="icon-search" class="easyui-linkbutton">已发货</a>
                    <a href="OrderProduct.aspx?type=5" iconcls="icon-search" class="easyui-linkbutton">已完成</a>
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">操作</legend>
                    <table width="99%" border="0" cellspacing="0" cellpadding="0" class="">
                        <tr>
                            <td>代理编号
                       
                                <input name="txtInput" id="txtInput" class="input_select" runat="server" type="text" />
                                结算日期：<asp:TextBox ID="txtStar" tip="输入结算日期"
                                    runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                                至<asp:TextBox ID="txtEnd" tip="输入结算日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                                <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                                    OnClick="btnSearch2_Click"> 搜 索 </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"
                                    iconcls="icon-print" OnClick="daochu_Click"> 导 出 </asp:LinkButton>
                            </td>

                        </tr>
                    </table>
                </fieldset>
            </div>
            <!--end operation 操作-->
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">时间
                        </th>
                        <th align="center">订单号
                        </th>
                        <th align="center">会员编号
                        </th>
                        <th align="center">购买数量
                        </th>

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
                    <asp:Repeater ID="rptOrder" runat="server" OnItemCommand="rptOrder_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Convert.ToDateTime(Eval("OrderDate")).ToString("yyyy-MM-dd HH:mm:ss")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderCode")%>
                                </td>

                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderSum")%>
                                </td>

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
                                      <%#userBLL.GetUserCodeByUserID(long.Parse(Eval("order5").ToString()==""?"0":Eval("order5").ToString()))%>
                                </td>
                                <td align="center">
                                    <%#Eval("OrderType").ToString()=="1"?"报单产品":Eval("OrderType").ToString() =="2"?"复投产品":""%>
                                </td>
                                <td align="center">
                                    <%#GetState(Eval("IsSend").ToString(),Eval("IsDel").ToString())%>
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
                    <tr runat="server" id="trNull">
                        <td colspan="12" align="center">
                            <div id="divno" runat="server" class="NoData">
                                <span class="cBlack">抱歉！目前数据库暂无数据显示。</span>
                            </div>
                        </td>
                    </tr>
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
