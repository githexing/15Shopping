<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockPriceEdit.aspx.cs" Inherits="Web.admin.licai.StockPriceEdit" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑银行账户信息</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
<form id="Form1" class="box_con" runat="server">
<div class="box box_width">
    <div class="operation">
  
      <fieldset class="fieldset">
      <legend class="legSearch">编辑交易价格</legend>
      <table style=" width:80%;">
                    <tr>
                        <td width="200px"><span style=" width: 100px;">&nbsp;交易时间：</span>
                            <input type="text" id="text_startDate" runat="server" class="input_select" tip="输入交易时间" disabled="disabled" onfocus="WdatePicker()"  />
                        </td>
                            
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
                    iconcls="icon-edit" onclick="btn_ok_Click" > 提 交 </asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-back" onclick="Button1_Click" > 返 回 </asp:LinkButton></td>
                    </tr>
                </table>
      </fieldset>
    </div>
    </form>
</body>
</html>
