<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendTree2.aspx.cs" Inherits="Web.admin.team.RecommendTree2" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>直系图</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="box_width">
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">直系查询</legend>会员编号:<asp:TextBox ID="txtUserCode" tip="输入会员编号"
                    runat="server"  class="input_select"></asp:TextBox>&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="btnSearch_Click" > 搜 索 </asp:LinkButton>
                    <a class="easyui-linkbutton" href="RecommendTree.aspx"> 我的直推图 </a>
            </fieldset>
        </div>
        <div class="dataTable" align="left" style="padding-left: 15px; padding-right: 320px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr align="left">
                    <td align="left">
                        <asp:TreeView ID="TreeView1" runat="server" LeafNodeStyle-CssClass="LeafNodesStyle"
                            CssClass="TreeView" NodeStyle-CssClass="NodeStyle" ParentNodeStyle-CssClass="ParentNodeStyle"
                            RootNodeStyle-CssClass="RootNodeStyle" SelectedNodeStyle-CssClass="SelectedNodeStyle"
                            LeafNodeStyle-Width="100%" NodeStyle-Width="100%" ParentNodeStyle-Width="100%"
                            RootNodeStyle-Width="100%" SelectedNodeStyle-Width="100%" ImageSet="Arrows" MaxDataBindDepth="1"
                            ExpandDepth="1">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                            <SelectedNodeStyle CssClass="SelectedNodeStyle" Width="100%" Font-Underline="True"
                                ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px"></SelectedNodeStyle>
                            <RootNodeStyle CssClass="RootNodeStyle" Width="100%"></RootNodeStyle>
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                            <LeafNodeStyle CssClass="LeafNodesStyle" Width="100%"></LeafNodeStyle>
                        </asp:TreeView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
