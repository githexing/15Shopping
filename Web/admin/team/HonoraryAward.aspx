<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HonoraryAward.aspx.cs"
    Inherits="Web.admin.team.HonoraryAward" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>奖金查询</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script src="../../JS/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="../../JS/jquery.ui.draggable.js" type="text/javascript"></script>
    <style type="text/css">
        #draggable
        {
            padding: 0.5em;
            float: left;
            margin: 0 10px 10px 0;
            border: none;
        }
        .div1
        {
            float: left;
            margin: 10px;
            margin-left: 3px;
            font-size: 11px;
            color: #fff;
            margin-right: 3px;
            width: 66px;
            background-color: #2C8025;
            text-align: center;
            height: 28px;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#draggable").draggable({ distance: 20 });
        });
    </script>
</head>
<body class="">
    <form id="Form1" runat="server">
    <div class="box box_width">
        <div class="capositon">
            当前位置：财务中心>><a href="javascript:void(0)">荣誉奖查询</a>
        </div>
                <div class="operation">
            <fieldset class="fieldset">
                <legend class="legSearch">查询</legend>会员编号:<asp:TextBox ID="txtUserCode" tip="输入会员编号"
                    runat="server" class="input_select"></asp:TextBox>
                <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton" iconcls="icon-search"
                    OnClick="idSearch_Click"> 搜 索 </asp:LinkButton>
            </fieldset>
        </div>

        <div class="dataTable" align="center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                <tr>
                    <th align="center">
                        会员编号
                    </th>
                    <th align="center">
                        左区总业绩积分
                    </th>
                    <th align="center">
                        右区总业绩积分
                    </th>
                    <th align="center">
                       荣誉级别
                    </th>
                    <th align="center">
                        荣誉奖励
                    </th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("UserCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("LeftCount")%>
                            </td>
                            <td align="center">
                                <%#Eval("RightCount")%>
                            </td>
                            <td align="center">
                                <%#Eval("AwardTitle")%>
                            </td>
                            <td align="center">
                                <%#Eval("AwardDetail")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="trBonusNull" runat="server">
                    <td colspan="6">
                        <div class="NoData">
                            <span class="cBlack">
                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                抱歉！目前数据库暂无数据显示。</span></div>
                    </td>
                </tr>
            </table>
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                    LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                    PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput" NumericButtonCount="3"
                    PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True" SubmitButtonClass="pagebutton"
                    UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always" SubmitButtonText=""
                    textafterpageindexbox=" 页" textbeforepageindexbox="转到 ">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
