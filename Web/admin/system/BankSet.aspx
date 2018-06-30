<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankSet.aspx.cs" Inherits="Web.admin.system.BankSet" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>注册账户设置</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../../Js/jquery.provincesBank.js" type="text/javascript"></script>
    <script src="../../Js/provincesdata.js" type="text/javascript"></script>
</head>
<body>
    <form id="form2" runat="server">
        <div class="box box_width">
            <div class="operation" >
                <fieldset class="fieldset">
                <legend class="legSearch">银行设置</legend>
                <table width="100%">
                    <tr>
                        <td width="67px" align="right">
                            <font class="red">*</font>银行名称：
                        </td>
                        <td width="210px">
                            <input id="textBankName" type="text" runat="server" class="input_second" size="20" />
                        </td>
                        <td >
                            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" 
                            iconcls="icon-ok" onclick="btnSave_Click"  > 添 加 </asp:LinkButton>
                        </td>
                    </tr>
                </table>                    
                </fieldset>
            </div>
            
            <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">
                            银行名称
                        </th>
                        <th align="center">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("BankName")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="del" class="easyui-linkbutton" 
                                    iconcls="icon-no"  CommandArgument='<%#Eval("ID") %>'>删除</asp:LinkButton>
                            </td>
                        </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="trNull" runat="server">
                        <td colspan="4" align="center">
                            <div class="NoData">
                                <span class="cBlack" style="display: block">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" alt=""/>
                                    抱歉！目前数据库暂无数据显示。
                                </span>
                            </div>
                        </td>
                    </tr>
                </table>                        
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="anpBank" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" OnPageChanged="anpBank_PageChanged" PrevPageText="上一页"
                        AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3" PageSize="12"
                        ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                        UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                        textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                    </webdiyer:AspNetPager>
                </div>
            </div>      
        </div>
    </form>
</body>
</html>
