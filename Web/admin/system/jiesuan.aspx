<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiesuan.aspx.cs" Inherits="Web.admin.system.jiesuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box box_width">
        <div class="main_dt">
            <h2>
                奖金操作</h2>
            <ul>
                <li><span style="display: block; width: 180px; text-align: right; float: left;"></span>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                        OnClick="btnSave_Click" OnClientClick="javascript:return confirm('确定要日结吗？')"> 日结 </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" 
                        iconcls="icon-ok" onclick="LinkButton1_Click" OnClientClick="javascript:return confirm('确定要周发吗？')"> 周发 </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
