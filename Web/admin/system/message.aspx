<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="Web.admin.system.message" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>短信管理</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
          <tr>
              <th  align="center">用户编号</th>
              <th  align="center">手机号码</th>
              <th  align="center">短信内容</th>
              <th  align="center">发送时间</th>
              <th  align="center">状态</th>
           </tr>
    <asp:Repeater ID="rpNews" runat="server">
    <ItemTemplate>
          <tr>
          <td align="center"><%#Eval("UserCode")%></td>
          <td align="center"> <%#Eval("MobileNum")%></td>
          <td align="center"><%#Eval("Mcontent")%></td>
          <td align="center"><%#Eval("SendTime")%></td>
          <td align="center"><%#Eval("Flag")%></td>
          <%--<asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"
             iconcls="icon-edit" CommandName="modify" CommandArgument='<%#Eval("ID") %>'>编辑</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   iconcls="icon-no" CommandName="del" OnClientClick="javascript:return confirm('确定要删除吗？')" CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton></td>--%>
        </tr>
          </ItemTemplate>
          </asp:Repeater>
        <tr id="trNull" runat="server" style="border:0">
          <td colspan="4" align="center"><div class="NoData"><span class="cBlack"> <img src="../../images/ico_NoDate.gif" width="16" height="16" /> 抱歉！目前数据库暂无数据显示。</span></div></td>
        </tr>
      </table>
      <div style=" width:99%;"><br />
          <webdiyer:AspNetPager ID="anpNews" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                            LastPageText="尾页" NextPageText="下一页" 
                            PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                            PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                            UrlPaging="false" pageindexboxtype="TextBox" 
                showpageindexbox="Always" SubmitButtonText=""
                            textafterpageindexbox=" 页" textbeforepageindexbox="转到 " 
                HorizontalAlign="Right" onpagechanged="anpNews_PageChanged">
                        </webdiyer:AspNetPager>
                        </div>
      </div>
    </form>
</body>
</html>
