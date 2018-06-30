<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineRechargeAlipay.aspx.cs" Inherits="Web.user.finance.OnlineRechargeAlipay" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="GBK" />
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .txt-amount {
    color: #F60;
    font-weight: bold;
    font-family: arial;
    font-size: 16px;
}
    </style>
    <script type="text/javascript">
        function submit() {
            document.getElementById("memo").value = remark; //加载备注
        }
	</script>
</head>
<body>
    <form id="form1" runat="server"  action="redirect.aspx" method="post"  target="_blank">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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

        <div class="box">
            <div class="capositon">
                <%=GetLanguage("CurrentPosition")%>：<%=GetLanguage("FinanceCenter")%>>><a href="javascript:void(0)"><%=GetLanguage("Recharge")%></a>
            </div>
            <div class="box_con">
                <div class="operation">
                    <fieldset class="fieldset">
                        <legend class="legSearch">充值确认</legend>
                            <input name="optEmail" id="optEmail"  value="<%=AlipayAccount %>"  type="hidden">
                            <input name="payAmount" id="payAmount" value="<%=PayAmount %>" type="hidden">
                            <input name="userid" id="userid" value="<%=LoginUser.UserID %>" type="hidden">
			               <%-- <input name="title" id="title" value="<%=out_trade_no %>" type="hidden">--%>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                            <tr>
                                <td style="text-align: right;width:50%">
                                    支付方式
                                    ：</td>
                                <td><label title="" >支付宝支付</label></td>
                            </tr>
                           
                            <tr>
                                <td style="text-align: right;">确认金额 ：</td>
                               <td><label id="lblRechargeAmount" class="txt-amount">￥<%=PayAmount %></label></td>
                                    
                                
                            </tr>
                            <tr >
                                <td style="text-align: right;">支付人 ：</td>
                                <td><label title="" ><%=LoginUser.UserCode %></label></td>
                            </tr>
                             <tr style="display:none;" >
                                <td style="text-align: right;">备注 ：</td>
                                <td  >
                                    <asp:TextBox runat="server" ID="memo" class="input_select" Text=""  Enabled="false"
                                               ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    <input type="submit" value="确认充值"   class ="btn" />
                                </td> 

                            </tr>
                           
                             
                        </table>
                        <br />
                       <label style="color:#ff0000;">重要提示：
                                        支付宝付款时，请不要修改支付宝
                                        的“付款说明”和“备注”，否则不能
                                        自动到账。</label> 
                    </fieldset>
                </div>
            </div>
        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
