<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jiaoyipan.aspx.cs" Inherits="Web.admin.licai.jiaoyipan" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>交易盘</title>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
      
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
      <td colspan="2" >
      <div class="box_title ">最新交易信息</div>
      <table width="100%"  border="0" cellspacing="0" cellpadding="0" class="t1">
      <tr>
      <th>买方</th>
      <th>卖方</th>
      <th>成交价</th>
      <th>成交数量</th>
      <th>交易时间</th>
      </tr>
      <tr>
      <td align="center"><asp:Label ID="lbl_mai1" runat="server"></asp:Label></td>
      <td align="center"><asp:Label ID="lbl_mai2" runat="server" Text=""></asp:Label></td>
      <td align="center"><asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label></td>
      <td align="center"><asp:Label ID="lbl_num" runat="server" Text=""></asp:Label></td>
      <td align="center"><asp:Label ID="lbl_time" runat="server" Text=""></asp:Label></td>
      </tr>
      </table>
      </td>
  </tr>
  <tr>
    <td width="50%"  valign="top">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
      <tr>
        <td >
    <div class="box_title ">购买股票</div>
             <table width="99%" border="0" cellpadding="0" cellspacing="0" class="t1">
     <tr>
       <th align="center">购买股票数</th>
       <th align="center">买入单价</th>
       <th align="center">总共价值</th>
     </tr>
     <tr>
       <td align="center"><asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
       <asp:TextBox ID="txt_num1" runat="server" class="input_gp" AutoPostBack="True" 
                         ontextchanged="txt_num1_TextChanged"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel></td>
       <td align="center"><asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
       <asp:TextBox ID="txt_amount1" runat="server" class="input_gp" AutoPostBack="True" 
                         ontextchanged="txt_amount1_TextChanged"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel></td>
       <td align="center"><asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
       <input name="Add_sscFd7" id="textAllamount1" class="input_gp" runat="server" 
                        type="text" disabled="disabled" />
            </ContentTemplate>
            </asp:UpdatePanel></td>
     </tr>
     <tr>
       <td colspan="3" align="center">
                    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-ok" onclick="bt_in_Click" > 提 交 </asp:LinkButton></td>
     </tr>
   </table></td>
   
      </tr>
      <tr>
        <td >
    <div class="box_title ">买盘</div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
            <table width="97%"  border="1" align="center" cellpadding="0" cellspacing="0">
            <tr>
                        <th >
                            序号
                        </th>
                        <th >
                            用户名
                        </th>
                        <th >
                            股票数
                        </th>
                        <th >
                            单价
                        </th>
                        <%--<th >
                            总价值
                        </th>--%>
                        <th >
                            日期
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# this.Repeater1.Items.Count + 1%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessPrice")%>
                                </td>
                                <%--<td align="center">
                                    <%#Eval("SumMoney")%>
                                </td>--%>
                                <td align="center">
                                <%#Eval("BusinessTime")%>
                                    <%--<%#Convert.ToDateTime(Eval("BusinessTime")).ToString("yyyy-mm-dd")%>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr1" runat="server">
                        <td colspan="5" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
   </table>         
                <div class="nextpage cBlack">
                    <ul>
                        <li style="float: right; width: 100%;">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="100" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" 
                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                SubmitButtonText="" textafterpageindexbox=" 页" 
                                textbeforepageindexbox="转到 " onpagechanged="AspNetPager1_PageChanged">
                            </webdiyer:AspNetPager>
                        </li>
                    </ul>
                </div>
              </ContentTemplate>
          </asp:UpdatePanel>
        
        </td>
      </tr>
      <tr>
        <td >
    <div class="box_title ">我的最近10条待买入记录</div>
              <table width="97%"  border="1" align="center" cellpadding="0" cellspacing="0">
            <tr>
                        <th >
                            股票数
                        </th>
                        <th >
                            买入单价
                        </th>
                        <th >
                            总价值
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("BusinessAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessPrice")%>
                                </td>
                                <td align="center">
                                    <%#Eval("SumMoney")%>
                                </td>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr2" runat="server">
                        <td colspan="3" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
   </table>
                <div class="nextpage cBlack">
                    <ul>
                        <li style="float: right; width: 100%;">
                            <webdiyer:AspNetPager ID="AspNetPager2" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="10" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" 
                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                SubmitButtonText="" textafterpageindexbox=" 页" 
                                textbeforepageindexbox="转到 " onpagechanged="AspNetPager2_PageChanged">
                            </webdiyer:AspNetPager>
                        </li>
                    </ul>
                </div>
        </td>
      </tr>
    </table></td>
    <td width="50%"  valign="top">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
      <tr>
        <td >
    <div class="box_title ">卖出股票</div>
             <table width="99%" border="0" cellpadding="0" cellspacing="0" class="t1">
     <tr>
       <th align="center">卖出股票数</th>
       <th align="center">卖出单价</th>
       <th align="center">总共价值</th>
     </tr>
     <tr>
       <td align="center">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate><asp:TextBox ID="txt_num2" runat="server" class="input_gp"
                         ontextchanged="txt_num2_TextChanged" AutoPostBack="True"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel></td>
       <td align="center">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate><asp:TextBox ID="txt_amount2" runat="server"  class="input_gp"
                         ontextchanged="txt_amount2_TextChanged" AutoPostBack="True"></asp:TextBox>
            </ContentTemplate>
            </asp:UpdatePanel></td>
       <td align="center">
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate><input name="Add_sscFd7" id="textAllamount2" class="input_gp" runat="server" 
                        type="text" disabled="disabled" />
            </ContentTemplate>
            </asp:UpdatePanel></td>
     </tr>
     <tr>
       <td colspan="3" align="center">
                    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-ok" onclick="bt_out_Click" > 提 交 </asp:LinkButton></td>
     </tr>
   </table>
        </td>
      </tr>
      <tr>
        <td >
    <div class="box_title ">卖盘</div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
            <table width="97%" border="1" align="center" cellpadding="0" cellspacing="0">
            <tr>
                        <th >
                            序号
                        </th>
                        <th >
                            用户名
                        </th>
                        <th >
                            股票数
                        </th>
                        <th >
                            单价
                        </th>
                        <%--<th >
                            总价值
                        </th>--%>
                        <th >
                            日期
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# this.Repeater3.Items.Count + 1%>
                                </td>
                                <td align="center">
                                    <%#Eval("UserCode")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessPrice")%>
                                </td>
                                <%--<td align="center">
                                    <%#Eval("SumMoney")%>
                                </td>--%>
                                <td align="center">
                                <%#Eval("BusinessTime")%>
                                    <%--<%#Convert.ToDateTime(Eval("BusinessTime")).ToString("yyyy-mm-dd")%>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr3" runat="server">
                        <td colspan="5" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
   </table>
                <div class="nextpage cBlack">
                    <ul>
                        <li style="float: right; width: 100%;">
                            <webdiyer:AspNetPager ID="AspNetPager3" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="100" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" 
                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                SubmitButtonText="" textafterpageindexbox=" 页" 
                                textbeforepageindexbox="转到 " onpagechanged="AspNetPager3_PageChanged">
                            </webdiyer:AspNetPager>
                        </li>
                    </ul>
                </div>
              </ContentTemplate>
          </asp:UpdatePanel>
        </td>
      </tr>
      <tr>
        <td >
    <div class="box_title ">我的最近10条待卖出记录</div>
             <table width="97%"  border="1" align="center" cellpadding="0" cellspacing="0">
            <tr>
                        <th >
                            股票数
                        </th>
                        <th >
                            卖出单价
                        </th>
                        <th >
                            总价值
                        </th>
                    </tr>
                    <asp:Repeater ID="Repeater4" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%#Eval("BusinessAmount")%>
                                </td>
                                <td align="center">
                                    <%#Eval("BusinessPrice")%>
                                </td>
                                <td align="center">
                                    <%#Eval("SumMoney")%>
                                </td>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="tr4" runat="server">
                        <td colspan="3" align="center">
                            <div class="NoData">
                                <span class="cBlack">
                                    <img src="../../images/ico_NoDate.gif" width="16" height="16" />
                                    抱歉！目前数据库暂无数据显示。</span></div>
                        </td>
                    </tr>
   </table>
                <div class="nextpage cBlack">
                    <ul>
                        <li style="float: right; width: 100%;">
                            <webdiyer:AspNetPager ID="AspNetPager4" runat="server" SkinID="AspNetPagerSkin" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" InputBoxClass="pageinput"
                                NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                                SubmitButtonClass="pagebutton" UrlPaging="false" 
                                pageindexboxtype="TextBox" showpageindexbox="Always"
                                SubmitButtonText="" textafterpageindexbox=" 页" 
                                textbeforepageindexbox="转到 " onpagechanged="AspNetPager4_PageChanged">
                            </webdiyer:AspNetPager>
                        </li>
                    </ul>
                </div>
        </td>
      </tr>
    </table>
    
    </td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
