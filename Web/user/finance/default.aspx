<%@ Page Language="C#" AutoEventWireup="true"  Inherits="_Default" CodeBehind="default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <title>支付宝即时到账</title>
    <style type="text/css">
        .datatable {
            margin:0 auto;
            width:50%;
            margin-top:50px;
            border:solid 1px #eeeeee;
        }
            .datatable tr td {
                border:solid 1px #eeeeee;
            }
            .datatable .left {
                width:15%;
                text-align:right;
                height:30px;
                padding-right:10px;
            }
        .datatable1 {
            margin:0 auto;
            width:50%;
            border:solid 1px #eeeeee;
            border-top:0px;
        }
            .datatable1 tr td {
                border: solid 1px #eeeeee;
            }
        .btnsubmit {
            width:268px;
            height:52px;
            background:url(../../images/taobao.png) no-repeat;
            margin-left:100px;
            border:0px;
        }
            .btnsubmit:hover {
                cursor:pointer;
            }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <table class="datatable" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" style="background:#0099cc; font-size:18px; color:#ffffff;" align="center">请确认您的充值信息</td>
            </tr>
            <tr>
                <td class="left">充值时间</td><td></td>
            </tr>
            <tr>
                <td class="left">充值金额</td><td></td>
            </tr>
        </table>
        <table class="datatable1" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height:60px; width:50%;">
                    <asp:Button ID="btnSubmit" class="btnsubmit" runat="server" OnClick="btnSubmit_Click" /></td><td>
                    <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"/><span style="color:red; padding-left:10px; font-size:12px;">若有错误请点击返回按钮</span></td>
            </tr>
        </table>
    </form>
</body>
</html>