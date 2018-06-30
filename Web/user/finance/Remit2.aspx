<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Remit2.aspx.cs" Inherits="Web.user.finance.Remit2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线充值</title>
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JS/iepngfix_tilebg.js"></script>

    <script type="text/javascript" language="javascript">

        function Setchk()
        {
            var a=document.getElementById("TxtmMoney1").value.toString();
            var b=document.getElementById("TxtSecond").value.toString();
    
            if(a!=b)
            {
                document.getElementById("orderAmount").value=0;
                alert("提示：您输入的充值金额与确认金额不符，请您重新输入充值金额！");
            }
   
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <!--左侧菜单 star-->
            <div class="left">
                <div class="menu_t">财务管理</div>
                <div class="menu_x">
                    <ul>
                        <li><a href="Bonus.aspx" target="fMain">奖金明细</a></li>
                        <li><a href="dl_JournalAccount.aspx" target="fMain">账户查询</a></li>
                        <li><a href="Remit2.aspx" target="fMain" class="cur2">在线充值</a></li>
                        <li><a href="TransferToEmoney.aspx" target="fMain">账户转账</a></li>
                        <li><a href="TakeMoney.aspx" target="fMain">会员提现</a></li>
                    </ul>
                </div>
            </div>
            <!--左侧菜单 end-->
            <div class="right">
                <div class="title">
                    <span>当前位置：<a href="../default.aspx" class="hui">首页</a> &gt; 财务管理</span><h2>在线充值</h2>
                </div>
                <div class="right_nr">
                    <div class="caiwu">
        <table style="border:1px solid #dcdcdc;" align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
            <tbody>
                <tr class="tableline1_1">
                    <td align="right" height="25" width="16%">帐户余额：</td>
                    <td id="Member_Money" align="left" height="20" width="28%">
                        ￥<asp:Label runat="server" ID="Emoney"></asp:Label>
                    </td>
                    <td height="20" width="56%">&nbsp;</td>
                </tr>
                <tr class="tableline1_2">
                    <td align="right" height="25">会员编号：</td>
                    <td id="MemberID" align="left" height="20">
                        <asp:Label runat="server" ID="UserCode"></asp:Label>
                    </td>
                    <td height="20">&nbsp;</td>
                </tr>
                <tr class="tableline1_1">
                    <td align="right" height="25">充值金额：</td>
                    <td align="left" height="20">
                        <input name="TxtmMoney1" id="TxtmMoney1" class="input1" type="text" runat="server"/>
                    </td>
                    <td height="20">&nbsp;</td>
                </tr>
                <tr class="tableline1_2">
                    <td align="right" height="25">确认金额：</td>
                    <td align="left" height="20">
                        <input runat="server" name="TxtSecond" id="TxtSecond"  class="input1" onblur="Setchk();" type="text"/>
                    </td>
                    <td height="20">&nbsp;</td>
                </tr>
                <tr class="tableline1_1">
                    <td colspan="3">
                        <div style="padding-left:70px;" align="left">
                            <%--<a href="#" onclick="logins(1);"><img alt="" src="../../images/yzf.gif" alt="易宝支付"></a>&nbsp;&nbsp;&nbsp;--%>
                            <a href="#" onclick="logins(2);">
                                <asp:ImageButton runat="server" src="../../images/zfb.gif" Text="支付宝支付" OnClick="Unnamed1_Click"/>
                               <%-- <asp:Label runat="server" style="color:red;" Text="正在开发中... ..." ID="KF"></asp:Label>--%>
                            </a>
                        </div>
                    </td>
                </tr> 
            </tbody>
        </table>
        <div style="border:1px solid #ff9900; height:200px; width:99%; margin-top:5px; background:#fff8ed; padding:0px; line-height:200%; ">	
			充值注意：<br/>
            支付宝充值时进入转账页面请勿修改任何信息，特别是付款说明。否则您将无法收到电子币！<br/>
            <img src="../../images/fksm.jpg" alt="付款说明" height="60px;" width="300px;" />
		</div>
    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
