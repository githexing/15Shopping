<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberTree.aspx.cs" Inherits="web.admin.team.MemberTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>系谱图</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script src="../../JS/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.draggable.js" type="text/javascript"></script>
    <style type="text/css">
        #draggable
        {
            padding: 0.5em;
            float: left;
            margin: 0 10px 10px 0;
            border: none;
        }
        .div1
        {
            float: left;
            margin: 10px;
            margin-left: 3px;
            font-size: 11px;
            color: #fff;
            margin-right: 3px;
            width: 66px;
            background-color: #2C8025;
            text-align: center;
            height: 28px;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#draggable").draggable({ distance: 20 });
        });
    </script>
</head>
<body class="subBody">
    <form id="form1" runat="server" class="box_con">
    <div class="box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>会员编号:<asp:TextBox ID="txtUserCode" tip="输入会员编号"
                    runat="server" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 跳 转 </asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-print"
                    OnClick="btnMy_Click"> 我的系谱图 </asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-undo"
                    OnClick="Button1_Click"> 上一级 </asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton" iconcls="icon-redo"
                    OnClick="Button2_Click"> 下一级 </asp:LinkButton>
<%--                将会员
                <asp:TextBox ID="txtMoveUser" class="input_select" runat="server"></asp:TextBox>
                移动到会员
                <asp:TextBox ID="txtTargetUser" class="input_select" runat="server"></asp:TextBox>
                的
                <asp:DropDownList ID="ddlLocation" runat="server">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                    <asp:ListItem Value="1">左边</asp:ListItem>
                    <asp:ListItem Value="2">右边</asp:ListItem>
                </asp:DropDownList>
                边
                <asp:LinkButton ID="LinkButton5" runat="server" class="easyui-linkbutton" OnClick="LinkButton5_Click"> 确定 </asp:LinkButton>--%>
            </fieldset>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
            <%--    <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/000.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    未开通</div>--%>
                 <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/001.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    VIP</div>
                <%--<div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/003.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    二星会员</div>
                <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/006.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    三星会员</div>
                <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/005.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    四星会员</div>
                <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/004.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    五星会员</div>
                <div style="width: 74px; height: 20px; float: left; color: #fff; background: url('../../images/002.jpg');
                    text-align: center; line-height: 20px; font-weight: bold;">
                    六星会员</div>--%>
            </fieldset>
        </div>
        <div class="dataTable" style="overflow: auto;">
            <asp:Literal ID="Literal1" runat="server" EnableViewState="False"></asp:Literal>
        </div>
    </div>
    </form>
</body>
</html>
