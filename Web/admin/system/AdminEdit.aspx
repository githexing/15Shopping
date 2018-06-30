<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="Web.admin.system.AdminEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>编辑管理員</title>
     <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
         function postBackByObject() {
             var o = window.event.srcElement;
             if (o.tagName == "INPUT" && o.type == "checkbox") {
                 __doPostBack("UpdatePanel1", "");
             }
          //   alert(document.body.scrollHeight);
          //   alert(top.mainFrame.height);
             
         }
         function setTopLoad() {
             //var h = document.getElementById("tvAdminTree");
             //alert(document.body.scrollHeight);
             //             top.mainFrame.height = document.body.scrollHeight;
             document.frames.frameElement.style.height = document.body.scrollHeight;
             alert(document.frames.frameElement.style.height);

         }
    </script>
    <style type="text/css">
        .cdiv{
        text-align:left;
            width: 631px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            
    <div>
    <asp:Label ID="lblPrompt" runat="server" Text="" ForeColor="Red"></asp:Label>
    <table >
            <tr>
                <td align="right">
                    <span style="color:Red">*</span> 管理员编号：</td>
                <td>
                    <asp:TextBox ID="txtUserCode" runat="server"  class="input_select"></asp:TextBox>
                    </td>
                <td align="right">
                    <span style="color:Red">*</span> 姓名：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"  class="input_select"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <span style="color:Red">*</span> 登录密码：</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"  class="input_select"></asp:TextBox>
                    </td>
                <td align="right">
                     <span style="color:Red">*</span> 确认登录密码：</td>
                <td>
                   <asp:TextBox ID="txtRPass" runat="server" TextMode="Password"  class="input_select"></asp:TextBox>
                   </td>
            </tr>
            <tr>
                <td align="right">
                    <span style="color:Red">*</span> 二级密码：</td>
                <td>
                    <asp:TextBox ID="txtSecondPass" runat="server" TextMode="Password"  class="input_select"></asp:TextBox>
                    </td>
                <td align="right">
                     <span style="color:Red">*</span> 确认二级密码：</td>
                <td>
                   <asp:TextBox ID="txtRSecondPass" runat="server" TextMode="Password"  class="input_select"></asp:TextBox>
                   </td>
            </tr> 
            <tr>
                <td align="right">
                    <span style="color:Red">*</span> 三级密码：</td>
                <td>
                    <asp:TextBox ID="txtThirdPass" runat="server" TextMode="Password"  class="input_select"></asp:TextBox>
                    </td>
                <td align="right">
                     <span style="color:Red">*</span> 确认三级密码：</td>
                <td>
                   <asp:TextBox ID="txtRThirdPass" runat="server" TextMode="Password"  class="input_select"></asp:TextBox>
                   </td>
            </tr> 
        </table>
              <div class="tagcontent" style="text-align:left; padding-top:10px;">
        
        <asp:UpdatePanel ID="UpdatePanel1"  runat="server">
        <ContentTemplate>
        <div  style="text-align:left; width: 152px; padding-left:35px;">
        <asp:CheckBox ID="ckCheck" runat="server" Text="全选" AutoPostBack="True" 
          oncheckedchanged="ckCheck_CheckedChanged" />
       <asp:CheckBox ID="ckUnCheck" runat="server" Text="反选" AutoPostBack="True" 
          oncheckedchanged="ckUnCheck_CheckedChanged" />
          </div>
            <div class="cdiv" style=" padding-left:15px;">
             <asp:TreeView ID="tvAdminTree"  runat="server"  
          ShowCheckBoxes="All"
          ontreenodecheckchanged="tvAdminTree_TreeNodeCheckChanged" 
          ImageSet="Arrows"  
                   >
                 <ParentNodeStyle Font-Bold="False" />
                 <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                 <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                     HorizontalPadding="0px" VerticalPadding="0px" />
                 <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                     HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" 
                     CssClass="cdiv" />
        </asp:TreeView>
         </div>
  
       
    <!--end data 表格數据--> 
           </ContentTemplate>
      </asp:UpdatePanel><br />
    <div style="text-align:left; padding-left:35px;">
    <asp:LinkButton ID="LinkButton1" class="easyui-linkbutton"  iconcls="icon-ok"  runat="server" onclick="btnSave_Click">保存</asp:LinkButton>
<%--    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click"/>--%>
    </div>
      </div>
    </div>
    </form>
</body>
</html>
