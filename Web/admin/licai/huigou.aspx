<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="huigou.aspx.cs" Inherits="Web.admin.licai.huigou" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>回购股票</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" class="box_con" runat="server">
    <div class="box box_width">
        <div class="operation">
            <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="LinkButton1_Click"> 回购股票 </asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                OnClick="LinkButton2_Click"> 回购记录 </asp:LinkButton>
        </div>
        <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">操作</legend>类型：<asp:RadioButton ID="rbtnSelete" Text="所选用户"
                    runat="server" GroupName="rb" AutoPostBack="true" OnCheckedChanged="rbtnSelete_CheckedChanged" />
                <asp:RadioButton ID="rbtnAll" Text="全部用户" runat="server" GroupName="rb" AutoPostBack="true"
                    OnCheckedChanged="rbtnAll_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                交易单价：<asp:TextBox ID="txtMoney" tip="输入交易单价" onkeydown="if(event.keyCode==13)event.keyCode=9"
                    onKeyPress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                    class="easyui-numberbox input_select" precision="2" runat="server"></asp:TextBox>
                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                    OnClick="btn_ok_Click"> 提 交 </asp:LinkButton>
            </fieldset>
            <fieldset class="fieldset">
                <legend class="legSearch">选择用户</legend>会员编号:<input id="textUserCode" type="text"
                    runat="server" class="input_select" tip="输入会员编号" />
                会员级别:<asp:DropDownList ID="ddlLevel" runat="server">
                </asp:DropDownList>
                开通日期:<asp:TextBox ID="txtOpenStar" tip="输入开通日期" runat="server" class="input_select"
                    onfocus="WdatePicker()"></asp:TextBox>
                至<asp:TextBox ID="txtOpenEnd" tip="输入开通日期" runat="server" class="input_select" onfocus="WdatePicker()"></asp:TextBox>
                推荐人编号:<input id="txtRecommendCode" type="text" runat="server" class="input_select"
                    tip="输入推荐人编号" />
                <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="btnSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>
        <div class="dataTable">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th>
                        <asp:CheckBox ID="ckAll" runat="server" Text="全选" AutoPostBack="true" OnCheckedChanged="ckAll_CheckedChanged" />
                    </th>
                    <th>
                        会员编号
                    </th>
                    <th>
                        会员姓名
                    </th>
                    <th>
                        级别
                    </th>
                    <th>
                        开通时间
                    </th>
                    <th>
                        股票仓
                    </th>
                    <th>
                        股票钱包
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <input type="checkbox" name="CheckBoxIn" id="CheckBoxIn" value='<%#Eval("UserID") %>'
                                    runat="server" />
                            </td>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("TrueName")%>
                            </td>
                            <td align="center">
                                <%# getLevel(Convert.ToInt32(Eval("LevelID")))%>
                            </td>
                            <td align="center">
                                <%#Eval("OpenTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("StockAccount")%>
                            </td>
                            <td align="center">
                                <%#Eval("StockMoney")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="9" align="center">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
            </table>
            <div class="nextpage cBlack">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                    NumericButtonCount="3" PageSize="100" ShowInputBox="Never" ShowNavigationToolTip="True"
                    SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                    SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
