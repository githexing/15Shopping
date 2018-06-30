<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiaoyijilu.aspx.cs" Inherits="Web.admin.licai.jiaoyijilu" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>交易记录</title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
<script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" class="box_con" >
<div class="box box_width">
    <div class="operation">
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="LinkButton1_Click" > 买入记录 </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="LinkButton2_Click" > 卖出记录 </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="LinkButton3_Click" > 待交易记录 </asp:LinkButton>
    </div>
                <div class="operation">
                    <fieldset class="fieldset">
                        <legend class="legSearch">查询</legend>
                        交易时间：<asp:TextBox ID="txtDaiStar" tip="输入交易时间" runat="server"  class="input_select"  onfocus="WdatePicker()"></asp:TextBox>
                        至<asp:TextBox ID="txtDaiEnd" tip="输入交易时间" runat="server"  class="input_select"  onfocus="WdatePicker()"></asp:TextBox>
                        
                    <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="btnDai_Click" > 搜 索 </asp:LinkButton>
                    </fieldset>
                </div>
        <div class="dataTable">
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <tr>
                        <th >
                            交易时间
                        </th>
                        <th>
                            交易类型
                        </th>
                        <th >
                            交易数
                        </th>
                        <th >
                            交易单价
                        </th>
                        <th >
                            总共价值
                        </th>
                        <th >
                            撤单
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater3" runat="server" 
                        onitemcommand="Repeater3_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("BusinessTime")%>
                                </td>
                                <td align="center">
                                    <%# getType(Convert.ToInt32(Eval("BusinessType")))%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessPrice")%>
                                </td>
                                <td align="center">
                                    <%#Eval("SumMoney")%>
                                </td>
                                <td align="center">
                                <asp:LinkButton ID="lbtnOpen" runat="server" CommandArgument='<%# Eval("ID") %>'  CommandName="Open"
                                   class="easyui-linkbutton"   
                    iconcls="icon-undo"   OnClientClick="javascript:return confirm('确定撤单？')">撤单</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr3" runat="server">
                        <td colspan="6" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
                </table>
                <div class="nextpage cBlack">
                    <webdiyer:AspNetPager ID="AspNetPager3" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" 
                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                SubmitButtonText="" textafterpageindexbox=" 页" 
                                textbeforepageindexbox="转到 " onpagechanged="AspNetPager3_PageChanged">
                            </webdiyer:AspNetPager>
                </div>
                </div>

</div>
    </form>
</body>
</html>
