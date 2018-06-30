<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Web.user.finance.Account" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <div class="capositon">
        当前位置：财务查询>><a href="javascript:void(0)">我的账户</a></div>
    <div class="box box_width">
        <div class="dataTable">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t2">
                <tr>
                    <td width="300" align="right">
                        <span class="cRed">*</span>累计实发奖金额：
                    </td>
                    <td align="left">
                        <input name="Add_sscFd7" id="txtBonus" class="input_reg" runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td width="300" align="right">
                        <span class="cRed">*</span>E币余额：
                    </td>
                    <td align="left">
                        <input name="Add_sscFd7" id="txtEmoney" class="input_reg" runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td width="300" align="right">
                        <span class="cRed">*</span>奖金账户余额：
                    </td>
                    <td align="left">
                        <input name="Add_sscFd7" id="txtMoney" class="input_reg" runat="server" type="text" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
