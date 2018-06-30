<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chongxiaoList.aspx.cs" Inherits="Web.admin.team.chongxiaoList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>重消账户管理</title>
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
    <form id="Form1" class="box_con" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
    <div class="operation">
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search"  PostBackUrl="chongxiao.aspx" > 修改账户 </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" PostBackUrl="chongxiaoList.aspx" > 修改记录 </asp:LinkButton>
    </div>
        <div class="operation">
                <fieldset class="fieldset">
                    <legend class="legSearch">查询</legend>
                    会员编号：<input name="Add_sscFd7" id="txtUserCode" 
                         class="input_select" runat="server" type="text" />
                    会员姓名：<input name="Add_sscFd7" id="txtTrueName" 
                         class="input_select" runat="server" type="text" />
    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-search" onclick="btnSearch_Click" > 搜 索 </asp:LinkButton>
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
                            重消账户余额
                        </th>
                        <th align="center">
                            修改金额
                        </th>
                        <th align="center">
                            修改日期
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" >
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("TrueName")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BonusAccount")%>
                                </td>
                               <td align="center">
                                    <%#Eval("Mix005")%>
                               </td>
                               <td align="center">
                                    <%#Eval("AddTime")%>
                               </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="divno" runat="server">
                        <td colspan="5" align="center">
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
                        NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                        SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                        SubmitButtonText="" textafterpageindexbox=" 页" textbeforepageindexbox="转到 " Direction="LeftToRight"
                        HorizontalAlign="Right" OnPageChanged="AspNetPager1_PageChanged">
                    </webdiyer:AspNetPager>
                </div>
                </div>
</div>
    </form>
</body>
</html>
