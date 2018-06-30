<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="licaiManage.aspx.cs" Inherits="Web.admin.licai.licaiManage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1"  class="box_con" runat="server">
<div class="box box_width">
    <div class="operation">
  
      <fieldset class="fieldset">
      <legend class="legSearch">操作</legend>
      用户名:<input id="textUserCode" type="text" runat="server" class="input_select" tip="输入用户名" />
      可交易股票>=<input id="txtStockAccount" type="text" runat="server" class="easyui-numberbox input_select" 
                                precision="2" tip="输入可交易股票" /><%--
      贡献仓股票>=<input id="txtDmoney" type="text" runat="server" class="easyui-numberbox" 
                                precision="2"
                    size="10" tip="输入贡献仓股票" />--%>
      身份证号:<input id="txtIDcord" type="text" runat="server" class="input_select"  tip="输入身份证号" />
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="btnSearch_Click" > 搜 索 </asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-no" onclick="Button1_Click" > 锁 定 </asp:LinkButton>
    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-ok" onclick="Button2_Click" > 解 锁 </asp:LinkButton>
      </fieldset>
    </div>
        <div class="dataTable">
  <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
    <tr>
      <th >
          <asp:CheckBox ID="ckAll" runat="server" Text="全选" 
                  AutoPostBack="true" oncheckedchanged="ckAll_CheckedChanged"/>
        </th>
      <th >用户名</th>
      <th >级别</th>
      <th >身份证号</th>
      <th >姓名</th>
      <th >性别</th>
      <th >可交易股票</th>
      <th >交易钱包余额</th>
      <th >状态</th>
    </tr>
      <asp:Repeater ID="Repeater1" runat="server" >
        <ItemTemplate>
    <tr>
      <td align="center"><input type="checkbox"  name="CheckBoxIn" id="CheckBoxIn" value='<%#Eval("UserID") %>' runat="server"/></td>
      <td align="center"><%#Eval("UserCode")%></td>
      <td align="center"><%# getLevel(Convert.ToInt32(Eval("LevelID")))%></td>
      <td align="center"><%#Eval("IdenCode")%></td>
      <td align="center"><%#Eval("TrueName")%></td>
      <td align="center"><%#Convert.ToInt32(Eval("Gender"))==0?"女":"男"%></td>
      <td align="center"><%#Eval("StockAccount")%></td>
      <td align="center"><%#Eval("StockMoney")%></td>
      <td align="center"><%#Convert.ToInt32(Eval("User003"))==1?"已锁定":"正常"%></td>
     </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr id="trBonusNull" runat="server">
          <td colspan="10" align="center"><div class="NoData"><span class="cBlack"> <img src="../../images/ico_NoDate.gif" width="16" height="16" /> 抱歉！目前数据库暂无数据显示。</span></div></td>
        </tr>
    <tr>
          <td colspan="10" align="left">
            股票总量：<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            股票钱包：<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
          </td>
    </tr>
  </table>
          <div class="nextpage cBlack">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" 
                            PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                            PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                            UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                            textafterpageindexbox=" 页" textbeforepageindexbox="转到 " 
                            onpagechanged="AspNetPager1_PageChanged" >
                        </webdiyer:AspNetPager>
        </div>
        </div>
    
    </div>
    </form>
</body>
</html>
