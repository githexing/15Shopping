<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineRecharge.aspx.cs" Inherits="Web.user.finance.OnlineRecharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../style/index.css" rel="stylesheet" type="text/css" />
    <link href="../../style/style.css" rel="stylesheet" type="text/css" />
    <link href="../../style/ny.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
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
                        <legend class="legSearch"><%=GetLanguage("Recharge")%></legend>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                            <tr>
                                <td style="width: 95px; text-align: right;">
                                    <%=GetLanguage("CurrencyBalance")%><!--电子币余额--> ：</td>
                                <td  >
                                    <a><asp:Label ID="lblBonus"  style="color: #F60;" runat="server" Text="0"></asp:Label></a>&nbsp;<%=GetLanguage("USD")%><!--元-->
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    <%=GetLanguage("MembershipNumber")%><!--会员编号-->
                                    ：</td>
                                <td  >
                                            <label title="" ><%=LoginUser.UserCode %></label>
                               
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">充值金额 ：</td>
                                <td  >
                                    <asp:TextBox runat="server" ID="txtRechargeAmount" class="input_select" Text="" 
                                     onkeydown="if(event.keyCode==13)event.keyCode=9" onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;">
                                               </asp:TextBox>
                                    </td>
                            </tr>
                            
                            <tr>
                                <td style="text-align: right;">
                                
                                    <asp:Button runat="server" ID="btnAlipay" Text ="支付宝" CssClass="btn"  OnClick="btnAlipay_Click1" /> 
                                     </td>
                                <%--<td>
                                    <asp:LinkButton runat="server" ID="btnTenpay" Text ="财付通" CommandName="Tenpay" CommandArgument="" CssClass="btn" OnClick ="btnTenpay_Click"></asp:LinkButton> 
                                </td>--%>
                            </tr>
                        </table>
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
