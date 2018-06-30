<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="passwordupdata.aspx.cs" Inherits="Web.user.passwordupdata" %>

<!DOCTYPE html>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <link href="../css/StyleSheet.css?5" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../JS/jquery-1.7.1.min.js"></script>
    <script src="../js/login.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript"></script>
 <title>
	深圳市荟仙堂美容用品有限公司
</title>
    <style type="text/css">
        .auto-style1 {
            width: 459px;
            height: 184px;
            margin-left:200px;
            margin-top:100px;
        }
        .auto-style2 {
        }
        .cssrt {
            text-align:left;
        }
        .auto-style3 {
            width: 189px;
            text-align:right;
        }
        </style>

</head>

<body  class="login" style="overflow:hidden">
<form id="Form1" name="colorform" runat="server">
    <div style="width:840px;height:288px; margin-top:250px;margin-left:auto;margin-right:auto;text-align:center;">
        <ul>
                <table cellpadding="0" cellspacing="0" class="auto-style1">
                    <tr style="text-align:center;">
                        <td colspan="2"><span style="color:black;">找回密码步骤:1.发送信息到邮箱 2.获取信息重新登录 3.重新修改密码  </span></td>
                    </tr>
                    <tr>
                        <td class="auto-style3"><span style="color:black;">会员帐号：</span></td>
                        <td class="cssrt">
                            <asp:TextBox ID="TextBox1" runat="server" Height="25px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"><span style="color:black;">邮箱帐号：</span></td>
                        <td class="cssrt">
                            <asp:TextBox ID="TextBox2" runat="server"  Height="25px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3"><span style="color:black;">验证编码：</span></td>
                        <td class="cssrt">  <asp:TextBox ID="txtVa" runat="server" value="" class="inputStyle" onfocus="this.value=''" Width="99px"  Height="25px"
                            onblur="if(!value){value=defaultValue;}"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        <input type="text" readonly="readonly" id="checkCode" style="width: 70px; height: 30px;
                            color: red; font: 20px/30px 宋体; border: 0; background: 0; cursor: pointer;" onclick="createCode()" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="确认发送" Height="25px"  OnClientClick="return validate()" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
        </ul>
    </form>
</body>
</html>