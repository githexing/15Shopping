<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WealthPlan.aspx.cs" Inherits="web.admin.system.WealthPlan" %>

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
    <div class="main_dt">
        <form id="Form1" class="main_neirong" runat="server">
        <h2>
            服务条款<CKEditor:CKEditorControl ID="textPubContext"  
                runat="server"></CKEditor:CKEditorControl>
        </h2>
            <div class="neirong_button1"><br />
            <asp:LinkButton ID="btn_s1" runat="server" class="easyui-linkbutton"   iconcls="icon-save" onclick="btnSubmit_Click"  > 保 存 </asp:LinkButton>
                
            </div>
        </form>
    </div>
</body>

