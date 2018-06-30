<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leavewords.aspx.cs" Inherits="web.admin.system.Leavewords" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <div class="main_content" style=" float:left; ">
        <form id="Form1"  runat="server">
        <div class="main_dt">
        <h2>
            留言</h2>
        <ul>
            
            <li><span style="margin-right:10px; display:block; width:100px; text-align:right; float:left;"><font>*</font>留言对象：</span>
            <input type="text" name="textUserCode" id="textUserCode"  tip="输入留言对象" class=" input_second" runat="server" >
            
        </li>
            <li><span style="margin-right:10px; display:block; width:100px; text-align:right; float:left;"><font>*</font>主题：</span>
            <input type="text" name="textTitle" id="textTitle" tip="输入主题"  runat="server" class="input_second">
        </li>
            <li style="height:250px;"><span style="margin-right:10px; display:block; width:100px; text-align:right; float:left;"><font>*</font>内容：</span>
            <asp:TextBox ID="txtPubContext" runat="server" tip="输入内容" class="input_neirong" TextMode="MultiLine" ></asp:TextBox>
        </li><li style=" padding-left:100px;">
            <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton"   iconcls="icon-ok" onclick="btnSubmit_Click"  > 提 交 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-back" onclick="btnBack_Click" > 返回 </asp:LinkButton>
            </li>
        </ul>
        </div>
        </form>
    </div>
</body>
</html>
