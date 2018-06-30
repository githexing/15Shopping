<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashbuyDetail.aspx.cs" Inherits="Web.admin.finance.CashbuyDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../../JS/CreditLevel.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="box box_width">
            <div class="dataTable">
                <fieldset class="fieldset">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                        <tr>
                            <td width="200" align="right">
                                <h1>商品信息：</h1>
                            </td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="200" align="right">商品标题：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">商品数量：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">商品价格：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltPrice" runat="server"></asp:Literal>RMB
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">商品金额：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltAmount" runat="server"></asp:Literal>RMB
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td width="200" align="right">
                                发布件数：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltUnitNum" runat="server"></asp:Literal>件
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">
                                <h1>卖家信息：</h1>
                            </td>
                            <td align="left"><asp:Literal ID="ltUserCode" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">开户银行：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">姓名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltTrueName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">银行帐号：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">开户姓名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">开户网点：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankBranch" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">QQ号码：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltQQnumer" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">手机号码：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltPhoneNum" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">
                                <h1>信用等级：</h1>
                            </td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="200" align="right">
                                卖家信誉等级
                            </td>
                            <td align="left">
                                <span style="display: none;" id="userlevel">
                                    <asp:Literal ID="ltGrade" runat="server"></asp:Literal>
                                </span>
                                <span id="star"></span>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">&nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBack" runat="server" Text="返 回" class="easyui-linkbutton" iconcls="icon-ok" OnClick="btnBack_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
