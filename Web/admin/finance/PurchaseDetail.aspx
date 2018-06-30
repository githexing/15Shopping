<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseDetail.aspx.cs" Inherits="Web.admin.finance.PurchaseDetail" %>

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
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script src="../../JS/CreditLevel.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box box_width">
            <div class="dataTable">
                <fieldset class="fieldset">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                        <tr>
                            <td style="width: 120px; text-align: right;">
                                <h1>买家信息：</h1>
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltUserCode" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                开户银行：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                卖家姓名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltTrueName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                银行帐号：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankAccount" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                开户姓名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankAccountUser" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                开户网点：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBankBranch" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="display: none;">
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
                            <td style="width: 100px; text-align: right;">
                                <h1>求购信息：</h1>
                            </td>
                            <td align="left"></td>
                        </tr>
                        <tr style="display:none;">
                            <td style="text-align: right;">
                                商品标题：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltTitle" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                求购数量：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                已购数量：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltQuantity" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                商品价格：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltPrice" runat="server"></asp:Literal>RMB&nbsp;&nbsp;<span style="color:#f00;">最低价格:<%=getParamAmount("GoldMin")%>RMB&nbsp;&nbsp;最高价格:<%=getParamAmount("GoldMax")%>RMB</span>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td style="text-align: right;">
                                手续费：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltFactorage" runat="server"></asp:Literal>金币
                            </td>
                        </tr>
                        <tr>
                            <td width="200" align="right">
                                买家信誉等级：
                            </td>
                            <td align="left">
                                <span style="display: none;" id="userlevel">
                                    <asp:Literal ID="ltGrade" runat="server"></asp:Literal>
                                </span>
                                <span id="star"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">&nbsp;
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lbtnBack" runat="server" Text="返 回" class="easyui-linkbutton" iconcls="icon-ok" OnClick="lbtnBack_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
