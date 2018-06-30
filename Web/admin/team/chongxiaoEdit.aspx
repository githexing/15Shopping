<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chongxiaoEdit.aspx.cs" Inherits="Web.admin.team.chongxiaoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>重消账户管理</title>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">修改<%=GetUserCode(getIntRequest("userid"))%>重消账户</legend>
                    修改金额：<input name="Add_sscFd7" id="txtMoney" 
                         class="easyui-numberbox input_select" runat="server" min="0"  precision="2" runat="server" type="text" />
    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-edit" onclick="btnSearch_Click" > 修 改 </asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-back"  PostBackUrl="chongxiao.aspx" > 返 回 </asp:LinkButton>
                </fieldset>
                </div>
</div>
    </form>
</body>
</html>
