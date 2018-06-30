<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashOrderDetail.aspx.cs" Inherits="Web.admin.finance.CashOrderDetail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
<%--    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="box box_width">
            <div class="dataTable">
                <fieldset class="fieldset">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table table-bordered table-primary mb30  ">
                        <tr>
                            <td width="150" align="right">
                                <h4>订单信息：</h4>
                            </td>
                            <td align="left"></td>
                        </tr>
                        <tr>
                            <td width="150" align="right">订单编号：
                            </td>
                            <td align="left">
                                <asp:Literal ID="lblOrderCode" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">下订时间：
                            </td>
                            <td align="left">
                                <asp:Literal ID="lbOrderDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">付款时间：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltPayDate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                      <%--  <tr>
                            <td width="150" align="right"></td>
                            <td align="left"></td>
                        </tr>--%>
                        <tr>
                            <td width="150" align="right">
                                <h4>商品信息：</h4>
                            </td>
                            <td align="left"></td>
                        </tr>
                        <tr>
                            <td width="150" align="right">订单金额：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltAmount" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td width="150" align="right">商品数量：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltNumber" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">
                                <h4>卖家信息：</h4>
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSUserCode" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td width="150" align="right">开户银行：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSBankName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">姓名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSTrueName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">银行帐号：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSBankAccount" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">开户名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSBankAccountUser" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">开户网点：</td>
                            <td align="left">
                                <asp:Literal ID="ltSBankBranch" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td width="150" align="right">手机号码：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSPhoneNum" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td width="150" align="right">
                                卖家信誉等级：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltSGrade" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">
                                <h4>买家信息：</h4>
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBUserCode" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td width="150" align="right">开户银行：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBBankName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">姓名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBTrueName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">银行帐号：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBBankAccount" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">开户名：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBBankAccountUser" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td width="150" align="right">开户网点：</td>
                            <td align="left">
                                <asp:Literal ID="ltBBankBranch" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td width="150" align="right">手机号码：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBPhoneNum" runat="server"></asp:Literal>
                            </td>
                        </tr>
                          <tr id="trFeedback" runat="server">
                            <td width="150" align="right">
                                <h4>反馈信息：</h4>
                            </td>
                            <td align="left">
                                <asp:Literal ID="litFeedback" runat="server"></asp:Literal></td>
                        </tr>
                       
                        <%--<tr>
                            <td width="150" align="right">
                                买家信誉等级：
                            </td>
                            <td align="left">
                                <asp:Literal ID="ltBGrade" runat="server"></asp:Literal>
                            </td>
                        </tr>--%>

                        <tr>
                            <td width="150" align="right">&nbsp;
                            </td>
                            <td align="left">
                                <asp:Button ID="btnBack" runat="server" Text="返 回" class="btn" OnClick="btnBack_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
