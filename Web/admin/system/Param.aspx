<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Param.aspx.cs" Inherits="Web.admin.system.Param" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>动态参数</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="dataTable">
        <table width="99%" border="0" cellspacing="0" cellpadding="0" class="">
            <%--<tr>
                <td colspan="4">
                    <asp:LinkButton ID="lbtnUpdateAll" class="easyui-linkbutton" iconcls="icon-reload"
                        runat="server" onclick="lbtnUpdateAll_Click">修改全部</asp:LinkButton>
                </td>
            </tr>--%>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <%#(Eval("Remark").ToString().Contains("<font") && Container.ItemIndex >= 0) ? "</table></div><div class=\"kuang\" ><table cellSpacing=\"0\" cellPadding=\"0\" border=\"0\" class=\"reg\" >" : ""%>
                    <tr>
                        <td width="230px" align="right">
                            <%#Eval("Remark")%>
                        </td>
                        <td width="200px">
                            <input type="hidden" value='<% #Eval("id")%>' id="hiddenid" runat="server" />
                            <input name="paramValue" id="paramValue" value='<% #Eval("ParamVarchar")%>' onkeydown="if(event.keyCode==13)event.keyCode=9"
                                onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && (event.keyCode<65 || event.keyCode>90) && (event.keyCode<97 || event.keyCode>122) && event.keyCode!=46) event.returnValue=false;"
                                runat="server" type="text" class=" input_second" />
                        </td>
                        <td width="120px">
                            <%#Eval("EndRemark")%>
                        </td>
                        <td width="100px">
                            <asp:LinkButton ID="lbtnUpdate" style="min-width:25px" class="easyui-linkbutton" iconcls="icon-reload" runat="server"
                                CommandArgument='<%#Eval("id")%>' Visible=' <%#int.Parse(Eval("IsEdit").ToString()) == 1 ? true : false%>'
                                CommandName="Update">修改</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <%--<div style="overflow: hidden; width: 100%; margin: 5px 0;">
        <asp:LinkButton ID="lbtnUpdateAll_One" class="easyui-linkbutton" iconcls="icon-reload"
            runat="server" OnClick="lbtnUpdateAll_Click">修改全部</asp:LinkButton>
    </div>--%>
    </form>
</body>
</html>
