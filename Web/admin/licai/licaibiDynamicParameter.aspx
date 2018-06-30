<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="licaibiDynamicParameter.aspx.cs"
    Inherits="Web.admin.licai.licaibiDynamicParameter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>动态参数</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="box box_width">
    <div class="main_dt">
    <h2>
            动态参数设置</h2>
        <ul>
        <asp:Repeater ID="Repeater1" runat="server" onitemcommand="Repeater1_ItemCommand">
        <ItemTemplate>
        <li><span><font>*</font><%#Eval("Remark")%></span><input name="Add_sscFd7" id="paramValue" value='<% #Eval("ParamAmount")%>'
                                        runat="server" type="text" min="0" class="easyui-numberbox input_second" precision="2" tip="必输入项" />
                                        <span style="display:block; width:50px; text-align:left; float:left;">&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="update" >修改</asp:LinkButton>
                                        </span>
            </li>
        </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="Repeater2" runat="server" onitemcommand="Repeater2_ItemCommand" >
        <ItemTemplate>
        <li><span><font>*</font><%#Eval("Remark")%></span>
            <input name="sd" type="radio" checked='<%# Eval("ParamInt").ToString() == "1" ? true : false%>' id="ropen" runat="server"/>　开　
            <input name="sd"  type="radio" checked='<%# Eval("ParamInt").ToString() == "0" ? true : false%>' id="rclose" runat="server"/>　关
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id")%>' CommandName="update" >修改</asp:LinkButton>
            </li>
        </ItemTemplate>
        </asp:Repeater>
        </ul>
    </div>
    </div>
    </form>
</body>
</html>
