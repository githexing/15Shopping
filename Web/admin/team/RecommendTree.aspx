<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendTree.aspx.cs"
    Inherits="Web.admin.team.RecommendTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>直接推荐图</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="/JS/Scripts/themes/default/style.min.css" />
   <%-- <link rel="stylesheet" type="text/css" href="/JS/treeview/jquery.treeview.css" />--%>
<%--    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>--%>
   <%-- <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>--%>
    
   <%-- <script src="/js/Scripts/main-layout.js" type="text/javascript"></script>--%>
      <script type="text/javascript" src="/js/jquery-1.11.3.min.js"></script>
  <%--  <script type="text/javascript" src="../js/Scripts/Common.js"></script>--%>
   <%--<script type="text/javascript" src="/JS/treeview/jquery.cookie.js"></script>
    <script type="text/javascript" src="/JS/treeview/jquery.treeview.js"></script>
    <script type="text/javascript" src="/JS/treeview/jquery.treeview.async.js"></script>--%>
    <script type="text/javascript" src="/js/Scripts/jstree.min.js"></script>
    <script type="text/javascript" src="/js/Scripts/RecommendTree.js"></script>
    <script type="text/javascript">
        $(function () {
            Serach();
        } ) 
    </script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
        <div class="mainwrapper" style="top:0px;background-color:#E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">直接推荐图查询</h4>
                </div>
                <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label">会员编号:</label>
                            <%--<asp:TextBox ID="txtUserCode" tip="输入会员编号"
                                runat="server" class="form-control">--%>
                             <input type="text" id="txtUserCode" class="form-control"/>
                            <input type="button" id="UserCode" class="btn btn-primary mr5" onclick="Serach()" value="搜 索"/>
                          <%--   <a class="btn btn-primary mr5" href="RecommendTree.aspx">我的直推图 </a>--%>
                        </div>
                        <!-- form-group -->
                        
                        <%--<asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-search" OnClick="btnSearch_Click">--%>
                           <%-- <i class="fa fa-search"></i> 搜 索 </asp:LinkButton>--%>
                       
                    
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <ul id="red" class="treeview-default">

                    </ul>
                                         <input id="uid" class="userid" type="hidden" runat="server"/>
                                         <input id="tage" class="tage" type="hidden" runat="server"/>
                    <%--<div class="dataTable" align="left">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tbody>
                                <tr>
                                    <td>
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
                            </tbody>
                        </table>
                    </div>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
