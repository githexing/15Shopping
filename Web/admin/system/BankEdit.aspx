<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankEdit.aspx.cs" Inherits="Web.admin.system.BankEdit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑銀行賬戶信息</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>

    <script src="../../Js/jquery.provincesBank.js" type="text/javascript"></script>

    <script src="../../Js/provincesdata.js" type="text/javascript"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            setChineseCheck("textBankName:textBankAccountUser:text1");
            setIntegeCheck("textBankAccount");
        });
    </script>

    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server" class="box_con">
        <div class="box box_width">
            <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">账户设置</legend>
                    <table width="100%">
                        <tr id="tr1" runat="server">
                            <td width="67px" align="right"><font class="red">*</font>银行名称：
                            </td>
                            <td width="210px">
                                <input id="textBankName" type="text" runat="server" class="input_second" size="20" /></td>
                            <td width="67px" align="right">
                                <font class="red">*</font>银行账号：</td>
                            <td width="210px">
                                <input id="textBankAccount" type="text" runat="server" class="input_second" /></td>
                            <td width="67px" align="right">
                                <font class="red">*</font>开户名：</td>
                            <td>
                                <input id="textBankAccountUser" type="text" runat="server" class="input_second" />
                                <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"
                                    iconcls="icon-ok" OnClick="btnSave_Click"> 设 置 </asp:LinkButton>
                            </td>
                        </tr>
                        <tr id="tr2" runat="server">
                            <td width="67px" align="right">
                                <font class="red">*</font>财付通号：</td>
                            <td width="210px">
                                <input id="textRichesNum" type="text" runat="server" class="input_second" /></td>
                            <td width="67px" align="right">
                                <font class="red">*</font>名稱：</td>
                            <td width="210px">
                                <input id="textRichesName" type="text" runat="server" class="input_second" />
                            </td>
                            <td colspan="2">
                                <asp:LinkButton ID="linkbtnRiches" runat="server" class="easyui-linkbutton"
                                    iconcls="icon-ok" OnClick="linkbtnRiches_Click"> 设 置 </asp:LinkButton></td>
                        </tr>
                        <tr id="tr3" runat="server">
                            <td width="67px" align="right">
                                <font class="red">*</font>支付宝：</td>
                            <td width="210px">
                                <input id="textPayNum" type="text" runat="server" class="input_second" /></td>
                            <td width="67px" align="right">
                                <font class="red">*</font>名稱：</td>
                            <td width="210px">
                                <input id="textPayName" type="text" runat="server" class="input_second" /></td>
                            <td colspan="2">
                                <asp:LinkButton ID="lnkbtnPay" runat="server" class="easyui-linkbutton"
                                    iconcls="icon-ok" OnClick="lnkbtnPay_Click"> 设 置 </asp:LinkButton></td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
