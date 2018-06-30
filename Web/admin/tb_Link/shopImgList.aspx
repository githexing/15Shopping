<%@ Page Title="tb_Link" Language="C#"  AutoEventWireup="true" CodeBehind="shopImgList.aspx.cs" Inherits="lgk.Web.tb_Link.shopImgList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
<form id="Form1" runat="server">
 <fieldset class="fieldset">
                    <legend class="legSearch">操作</legend>
                      <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"
                                    PostBackUrl="Add.aspx?Link001=3">添加图片</asp:LinkButton>

</fieldset>

  <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        序号
                    </th>
                    <th>
                        名称
                    </th>
                    <th>
                        图片
                    </th>
                   
                    <th>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("Status")%>
                            </td>
                           <%-- <td align="center">
                                <%#Eval("fl")%>
                            </td>--%>
                            <td align="center">
                                <%#Eval("LinkName")%>
                            </td>
                            <td align="center">
                           
                              
                            <a href='<%#Eval("LinkUrl")%>' target="_blank">
                                 <img src="../../Upload/Banner/<%#Eval("LinkImage")%>" width="650px" />
                               
                               </a>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" 
                                    PostBackUrl='<%#Eval("ID","Add.aspx?id={0}&Link001=3") %>'>编辑</asp:LinkButton>
                                    <%--  <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"
                                    PostBackUrl='<%#Eval("ID","delete.aspx?id={0}&p=indexImgList.aspx") %>'>删除</asp:LinkButton>--%>
                            <a href="delete.aspx?id=<%#Eval("ID") %>&p=shopImgList"  class="easyui-linkbutton" >删除</a>
                            
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="15" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " OnPageChanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
            </div>
        </div>

 </form>
</body>
</html>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
