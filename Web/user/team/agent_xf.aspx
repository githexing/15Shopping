<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agent_xf.aspx.cs" Inherits="Web.user.team.agent_xf" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
<div class="capositon">当前位置：报单中心管理>><a href="javascript:void(0)">消费管理</a>
      
        <%if (Loginagent != null && Loginagent.Flag == 1)
          {%>
        <asp:Button ID="Button5" runat="server" Text="我要充值" class="btn" PostBackUrl="../finance/Remit.aspx" />
        <%
            } %>
        <asp:Button ID="Button6" runat="server" Text="账户转账" class="btn" PostBackUrl="../finance/TransferToEmoney.aspx" />
        </div>
        <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">消费</legend>
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="">
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                会员编号：<asp:TextBox ID="txtCode" runat="server" AutoPostBack="true"  class="input_select"
                            ontextchanged="txtCode_TextChanged"></asp:TextBox>
                         会员姓名：<a><asp:Label ID="Label1" runat="server" Text=""></asp:Label></a>，
                         所属报单中心：<a><asp:Label ID="Label2" runat="server" Text=""></asp:Label></a>，
                         重复消费余额：<a><asp:Label ID="Label3" runat="server" Text=""></asp:Label></a>元
                    </ContentTemplate>
                    </asp:UpdatePanel>
                         </td>
                </tr>
                    <tr>
                <td>消费金额：<input name="Add_sscFd7" id="txtMoney"  onkeydown="if(event.keyCode==13)event.keyCode=9" onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"  class="input_select" runat="server" type="text" />
                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="提 交" onclick="LinkButton3_Click"  class="btn"   OnClientClick="javascript:return confirm('确认消费？')"/>
                         </td>
                    </tr>
                    </table>
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">查询</legend>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                    <td>
                                会员编号：<input name="Add_sscFd7" id="txtUserCode" 
                         class="input_select" runat="server" type="text" />
                                会员姓名：<input name="Add_sscFd7" id="txtTreuName" 
                         class="input_select" runat="server" type="text" />
                    </td>
                    </tr>
                    <tr>
                    <td>
                    消费日期：<asp:TextBox ID="txtStar"   runat="server" onfocus="WdatePicker()"
                         class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtEnd"   runat="server" onfocus="WdatePicker()"
                         class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="搜 索" onclick="btnSearch1_Click"  class="btn" /></td>
                    </tr>
                    </table>
                </fieldset>
                </div>
        <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th align="center">
                            会员编号
                        </th>
                        <th align="center">
                            会员姓名
                        </th>
                        <th align="center">
                            所属报单中心
                        </th>
                        <th align="center">
                            消费金额
                        </th>
                        <th align="center">
                            消费日期
                        </th>
                        <th align="center">
                            备注
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server"  >
                        <ItemTemplate>
                            <tr>
                            <td align="center">
                            <%# Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%#Eval("User006")%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount")%>
                            </td>
                            <td align="center">
                                <%#Eval("AddTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("Source")%>
                            </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="15" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
                </table>
                <div class="yellow">
                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                         OnPageChanged="AspNetPager2_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
                </div>
            </div>
    </form>
</body>
</html>
