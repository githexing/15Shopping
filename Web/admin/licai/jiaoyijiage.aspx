<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiaoyijiage.aspx.cs" Inherits="Web.admin.licai.jiaoyijiage" %>

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
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body class="subBody">

<form id="Form1" class="box_con" runat="server">
<div class="box box_width">
    <div class="operation">
  
      <fieldset class="fieldset">
      <legend class="legSearch">发布交易价格</legend>
      <table style=" width:80%;">
                    <tr>
                        <td width="200px"><span style=" width: 100px;">&nbsp;交易时间：</span>&nbsp;<asp:TextBox ID="txt_startDate"  tip="输入交易时间" class="input_select" 
                                runat="server" onfocus="WdatePicker()"  
                                ></asp:TextBox></td>
                            
                        <td width="200px"><span style=" width: 100px;">&nbsp;上次收盘价：</span>&nbsp;<asp:TextBox ID="txt_back" class="input_select"  tip="输入上次收盘价" runat="server"></asp:TextBox>
                        </td>
                        <td><span style=" width: 100px;">开盘价：</span><asp:TextBox ID="txt_open" class="input_select"  tip="输入开盘价" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><span style=" width: 100px;">
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rb"
                                AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" />
                            日涨价：</span>
                            <input type="text" id="text_up" runat="server" class="input_select" tip="输入日涨价" />
                        </td>
                        <td>  &nbsp;&nbsp;&nbsp;&nbsp;  涨幅天数：
                            <input type="text" id="text_upday" runat="server" class="input_select" tip="输入涨幅天数" />
                        </td>
                        <td><span style=" color:Red;"></span></td>
                    </tr>
                    <tr>
                        <td><span style=" width: 100px;">
                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rb" 
                                AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" />
                            日跌价：</span>
                            <input type="text" id="text_down" runat="server" class="input_select" tip="输入日跌价" />
                            
                        </td>
                        <td>  &nbsp;&nbsp;&nbsp;&nbsp;  跌幅天数：
                            <input type="text" id="text_downday" runat="server" class="input_select" tip="输入跌幅天数" />
                        
                        </td>
                        <td>
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-ok" onclick="btn_ok_Click" > 提 交 </asp:LinkButton></td>
                    </tr>
                </table>
      </fieldset>
    </div>
    
        <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
    <tr>
                    <th align="center">
                        交易时间
                    </th>
                    <th align="center">
                        上次收盘价
                    </th>
                    <th align="center">
                        开盘价
                    </th>
                    <th align="center">
                        日涨/跌价
                    </th>
                    <th align="center">
                        涨/跌天数
                    </th>
                    <th align="center">
                        最后开盘价
                    </th>
                    <th align="center">
                        最后涨/跌日
                    </th>
                    <th align="center">
                        操作
                    </th>
    
    </tr>
      <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
        <ItemTemplate>
    <tr>
      <td align="center"><%# Convert.ToDateTime(Eval("BusinessTime")).ToString("yyyy-MM-dd")%></td>
      <td align="center"><%#Eval("UpPrice")%></td>
      <td align="center"><%#Eval("OpenMoney")%></td>
      <td align="center"><%#Eval("Price")%></td>
      <td align="center"><%#Eval("Up_DropDayNumber")%></td>
      <td align="center"><%#Eval("LastOpenMoney")%></td>
      <td align="center"><%#Eval("LastUp_DropDayNumber").ToString() == "" ? "未设置" : Convert.ToDateTime(Eval("LastUp_DropDayNumber")).ToString("yyyy-MM-dd")%></td>
      <td align="center">
      <asp:LinkButton ID="lbtnOpen" runat="server" CommandArgument='<%# Eval("ID") %>' Visible='<%# Convert.ToDateTime(Eval("BusinessTime")).Day==DateTime.Now.Day?true:false %>'
                              class="easyui-linkbutton"       iconcls="icon-edit"    CommandName="edit" Text="编辑"/>
                                
                            <asp:LinkButton ID="lbtnDelete" CommandArgument='<%# Eval("ID") %>' CommandName="del"  Visible='<%# Convert.ToDateTime(Eval("BusinessTime"))>DateTime.Now ?true:false %>'
                              class="easyui-linkbutton"     iconcls="icon-no"    runat="server" OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton></td>
     </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr id="trBonusNull" runat="server">
          <td colspan="8" align="center"><div class="NoData"><span class="cBlack"> <img src="../../images/ico_NoDate.gif" width="16" height="16" /> 抱歉！目前数据库暂无数据显示。</span></div></td>
        </tr>
  </table>
          <div class="nextpage cBlack">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页"
                            PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                            PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                            UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                            textafterpageindexbox=" 页" textbeforepageindexbox="转到 " 
                            onpagechanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
