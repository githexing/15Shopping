<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paydown.aspx.cs" Inherits="Web.user.finance.Paydown" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../style/main.css" rel="stylesheet" type="text/css" />
    <link href="../../style/box.css" rel="stylesheet" type="text/css" />
    <link href="../../style/common.css" rel="stylesheet" type="text/css" />
    <link href="../../style/skin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <title>支付宝即时到账</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="managerContent">
            <div class="managerContentR">
                <div class="clumn_qd">
                    <div class="newsList">
                        <table style="border:1px solid #dcdcdc;" align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                            <tbody>
                                <tr class="tableline1_1">
                                    <td align="right" height="25" width="254">支付方式:</td>
                                    <td align="left" width="489">支付宝支付</td>
                                </tr>
                                <tr class="tableline1_2">
                                    <td align="right" height="25">订单编号:</td>
                                    <td align="left">
                                        <input name="p2_Order" id="p2_Order" readonly="readonly" type="text" runat="server"/>
                                    </td>
                                </tr>
                                <tr class="tableline1_1">
                                    <td align="right" height="25">充值金额:</td>
                                    <td align="left">
                                        <input name="p3_Amt" id="p3_Amt" readonly="readonly" type="text" runat="server"/>
                                    </td>
                                </tr>
                                <tr class="tableline1_2">
                                    <td align="right" height="25">支付人:</td>
                                    <td align="left">
                                        <input name="pa_MP" id="pa_MP" readonly="readonly" type="text" runat="server"/>
                                    </td>
                                </tr>
                                <tr class="tableline1_1">
                                    <td align="right" height="25">商品名称:</td>
                                    <td align="left">
                                        <input name="p5_Pid" id="p5_Pid" readonly="readonly" value="King online" type="text" runat="server"/>
                                    </td>
                                </tr>
                                <tr class="tableline1_2">
                                    <td align="right" height="28">&nbsp;</td>
                                    <td align="left">
                                        <asp:Button runat="server" ID="tj" Text="确定充值" OnClick="btnSubmit_Click"/>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
