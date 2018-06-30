<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiFenList.aspx.cs" Inherits="Web.admin.product.JiFenList" %>
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
    <style type="text/css">
    .div{  padding-left:30px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box box_width" id="div1">
        <div class="operation">
            <%--
            <fieldset class="fieldset">
                选择类型：<asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlType_SelectedIndexChanged">
                <asp:ListItem Value="0">已下架商品</asp:ListItem>
                <asp:ListItem Value="1">已上架商品</asp:ListItem>
                </asp:DropDownList>
            </fieldset>--%>
            <fieldset class="fieldset">
            <legend class="legSearch">积分</legend>
                <div class="div">
                    <input id="rdoJiang" type="radio" runat="server" name="rdo" />扣除奖金币&nbsp;&nbsp;<%--<input type="text" id="txtBonusAccount"
                        tip="输入奖金币" name="textfield" runat="server" class="input_select" />&nbsp;&nbsp;--%>
                    <input id="rdoDian" type="radio" runat="server" name="rdo" />扣除拍币&nbsp;&nbsp;<input type="text"
                        id="txtEmoney" tip="输入拍币" name="textfield" runat="server" class="input_select" />&nbsp;
                    会员注册时间：<asp:TextBox ID="txtStar" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="input_select" Width="130px"></asp:TextBox>
                    &nbsp至&nbsp<asp:TextBox ID="txtEnd" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    class="input_select" Width="130px"></asp:TextBox>
                    &nbsp<asp:LinkButton ID="btn_btnAdd" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                        OnClick="btnAdd_Click"> 提 交 </asp:LinkButton></div><br />
                <div class="div">
                    会员编号：<input type="text" id="txtCode" tip="输入会员编号" name="textfield" runat="server"
                        class="input_select" />&nbsp;
                    <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                        OnClick="btnChuSearch_Click"> 搜 索 </asp:LinkButton></div>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        会员编号
                    </th>
                    <th>
                        扣除类型
                    </th>
                    <th>
                        扣除金额
                    </th>
                    <th>
                        扣除时间
                    </th>
                </tr>
                <asp:Repeater ID="rptProduct" runat="server" >
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Type(Eval("JournalType").ToString())%>
                            </td>
                            <td align="center">
                                <%#Convert.ToDecimal(Eval("OutAmount")) + Convert.ToDecimal(Eval("InAmount"))%>
                            </td>
                            <td align="center">
                                <%#Eval("JournalDate")%>
                            </td>                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr align="center" runat="server" id="tr1">
                    <td colspan="10" style="border: 0">
                        <div>
                            抱歉，目前数据库中暂无记录显示！</div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:aspnetpager id="AspNetPager1" runat="server" skinid="AspNetPagerSkin" firstpagetext="首页"
                    lastpagetext="尾页" nextpagetext="下一页" prevpagetext="上一页" alwaysshow="True" inputboxclass="pageinput"
                    numericbuttoncount="3" pagesize="12" showinputbox="Never" shownavigationtooltip="True"
                    submitbuttonclass="pagebutton" urlpaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    submitbuttontext="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " onpagechanged="AspNetPager1_PageChanged">
                </webdiyer:aspnetpager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
