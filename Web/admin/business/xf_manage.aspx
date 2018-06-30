<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xf_manage.aspx.cs" Inherits="Web.admin.business.xf_manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
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
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="LinkButton3_Click"    OnClientClick="javascript:return confirm('确认消费？')" > 提 交 </asp:LinkButton>
                         </td>
                    </tr>
                    </table>
                </fieldset>
                <fieldset class="fieldset">
                    <legend class="legSearch">查询</legend>
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                    <td>
                                会员编号：<input name="Add_sscFd7" id="txtUserCode" 
                         class="input_select" runat="server" type="text" />
                                会员姓名：<input name="Add_sscFd7" id="txtTreuName" 
                         class="input_select" runat="server" type="text" />
                    消费日期：<asp:TextBox ID="txtStar"   runat="server" onfocus="WdatePicker()"
                         class="input_select"></asp:TextBox>
                    至<asp:TextBox ID="txtEnd"   runat="server" onfocus="WdatePicker()"
                         class="input_select"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search"    OnClick="btnSearch1_Click"  > 搜 索 </asp:LinkButton>
                    </td>
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
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                        HorizontalAlign="Right" OnPageChanged="AspNetPager2_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
                </div>
            </div>
    </form>
</body>
</html>
