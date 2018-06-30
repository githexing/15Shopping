<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TradeEdit.aspx.cs" Inherits="Web.admin.licai.TradeEdit" %>

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
        <form id="form1" runat="server" class="box_con" >
<div class="box box_width">
    <div class="operation">
        <fieldset class="fieldset">
            <legend class="legSearch">编辑交易量</legend>交易时间：
            <input name="Add_sscFd7" id="textStar" runat="server" type="text" class="input_select"  disabled="disabled" style=" width:150px;" />
            交易量：<input name="Add_sscFd7" id="txtNum" runat="server" type="text" class="easyui-numberbox input_select" style=" width:150px;" precision="2" tip="输入交易量" />
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-edit" onclick="btnSearch_Click" > 提 交 </asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-back" onclick="LinkButton2_Click" > 返 回 </asp:LinkButton>
        </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
