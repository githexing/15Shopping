<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionType.aspx.cs" Inherits="Web.admin.product.AuctionType" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
     <form id="Form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width" id="div1">
        <div class="operation">
            <div>
            <%--<input type="radio" runat="server" id="rdoShou" name="rdo" oncheckedchanged="RadioButton1_CheckedChanged"/>手动竞拍&nbsp; 
            <input type="radio" runat="server" id="rdoZi" name="rdo" oncheckedchanged="RadioButton2_CheckedChanged"/>自动竞拍--%>
                <asp:RadioButton ID="rdoShou" runat="server" Text="手动竞拍" 
                    oncheckedchanged="RadioButton1_CheckedChanged" AutoPostBack="True"
                    />&nbsp;<asp:RadioButton 
                    ID="rdoZi" runat="server" Text="自动竞拍" 
                    oncheckedchanged="RadioButton2_CheckedChanged" AutoPostBack="True" 
                     /></div>
           <div id="DivShou" runat="server">
                会员编号：<input type="text" id="txtCode" tip="输入商品编号"
                    name="textfield" runat="server" class="input_select" />
                <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnChuSearch_Click"> 提 交 </asp:LinkButton>
           </div>
           <div id="DivZi" runat="server">
                激活时间：<asp:TextBox ID="txtStar" tip="输入激活日期" runat="server" onfocus="WdatePicker()"
                    class="input_select"></asp:TextBox>
                至<asp:TextBox ID="txtEnd" tip="输入激活日期" runat="server" onfocus="WdatePicker()" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="btn_s2" runat="server" class="easyui-linkbutton" 
                    iconcls="icon-search" onclick="btn_s2_Click"> 提 交 </asp:LinkButton>
           </div>
          <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-back"
                OnClick="btnSearch_Click"> 返 回 </asp:LinkButton>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        会员编号
                    </th>
                    <%--<th>
                        操作
                    </th>--%>
                </tr> 
                <asp:Repeater ID="rptProduct" runat="server" >
                    <ItemTemplate>
                       <tr>
                            <td id="td1" align="center">
                                    <%#Eval("UserCode")%>
                            </td>
                            <%--<td align="center" width="30%">
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="up" 
                                    class="easyui-linkbutton" iconcls="icon-add" CommandArgument='<%# Eval("userId") %>'>参与竞拍</asp:LinkButton>
                                <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="del" class="easyui-linkbutton"
                                    iconcls="icon-edit" CommandArgument='<%# Eval("AID") %>' OnClientClick="javascript:return confirm('真的要删除吗？')">删除</asp:LinkButton>&nbsp;&nbsp;
                                
                            </td>--%>
                       </tr>
                       
                    </ItemTemplate>
                </asp:Repeater>
                <%--<asp:Repeater ID="rptUser" runat="server" >
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                    <%#Eval("UserCode")%>
                            </td>
                            <td align="center" width="30%">
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="up" 
                                    class="easyui-linkbutton" iconcls="icon-add" CommandArgument='<%# Eval("userId") %>'>参与竞拍</asp:LinkButton>
                                <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="del" class="easyui-linkbutton"
                                    iconcls="icon-edit" CommandArgument='<%# Eval("AID") %>' OnClientClick="javascript:return confirm('真的要删除吗？')">删除</asp:LinkButton>&nbsp;&nbsp;
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater> --%>
                <tr align="center" runat="server" id="tr1">
                    <td colspan="10" style="border: 0">
                        <div>
                            抱歉，目前数据库中暂无记录显示！</div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
