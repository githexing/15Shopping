<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.user.Ticket.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" type="text/css" href="/css/style.css" />
    <script src="/JS/jquery.min.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/flexible.js" type="text/javascript" charset="utf-8"></script>
    <script src="/JS/layer.js" type="text/javascript" charset="utf-8"></script>
</head>
<body>
      <form id="form2" runat="server">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="jpbox" id="orderMain">
        <div class="rq-hb">
            <p><asp:Label runat="server" ID="piaodate"></asp:Label><asp:Label runat="server" ID="ticketcode"></asp:Label> </p>
        </div>
        <div class="sj">
            <div class="cf-time">
                <p class="time"><asp:Label runat="server" ID="starttime"></asp:Label></p>
                <p><asp:Label runat="server" ID="startstationname"></asp:Label></p>
            </div>
            <div class="go">
            </div>
            <div class="dd-time">
                <p class="time"><asp:Label runat="server" ID="arrivetime"></asp:Label><</p>
                <p><asp:Label runat="server" ID="endstationname"></asp:Label></p>
            </div>
            <div class="fj">飞行<asp:Label runat="server" ID="alltime"></asp:Label>分钟</div>
        </div>
        
        <div id="divpassengers">
            <div class="person" id="passenger">
               <%-- <ul id="passhead" style="display:none">
                    <li>
                        <div class="cjr">乘客</div>
                        <div class="zj-cjr"><a onclick="copypassenger()">增加乘机人</a></div>
                    </li>
                </ul>--%>
                <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                                    <ContentTemplate>
                <ul class="passengerinfo" id="mainpassengerinfo" runat="server">
                      <li class="deletepassenger" style="display:none"><div class="cjr"></div><div class="sc-cjr"><a>删除乘客</a></div></li>
                    <li>
                        <span class="zj">
                            <div class="sel_wrap">
                                <label class="passengertype">成人票</label>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlpassenger" runat="server" CssClass="selectpaio Jsselect" AutoPostBack="true" OnSelectedIndexChanged="ddlpassenger_SelectedIndexChanged">
                                            <asp:ListItem Value="ADT">成人票</asp:ListItem>
                                            <asp:ListItem Value="CHD">儿童票</asp:ListItem>
                                            <asp:ListItem Value="INF">婴儿</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<select name="ddlpassenger" id="ddlpassenger" class="selectpaio Jsselect" autocomplete="off"  onchange="onclacktype(value)">
                                            <option value="ADT">成人票</option>
                                            <option value="CHD">儿童票</option>
                                            <option value="INF">婴儿</option>
                                        </select>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </span>
                        <span class="xm-inp">
                            <input name="" type="text" placeholder=" 请填写乘机人姓名" class="ticketname" id="txt_name_1" value="">
                        </span>
                    </li>
                    <li>
                        <span class="zj">
                            <div class="sel_wrap">
                                <label>身份证</label>
                                <select name="ddlidcard" id="ddlidcard" class="selectcard Jsselect" autocomplete="off">
                                    <option value="NI" selected="selected">身份证</option>
                                    <option value="PP" >护照</option>
                                    <option value="ID">其他</option>
                                    
                                </select>
                            </div>
                        </span>
                        <span class="xm-inp">
                            <input name="" class="idcardnumber" type="text" placeholder="请填写证件号码" id="" value="" maxlength="18">
                            <input class="birthday" name="" type="hidden" value="" placeholder="请填写出生日期">
                        </span>
                    </li>
                     <li>性别
                                	<span class="sex" style="float: right; width: 77%; border-left: 1px solid #ccc">
                                        <div class="sel_wrap">
                                            <span class="sex">男</span>
                                            <select name="ddlsex" id="ddlsex" class="selectsex Jsselect" autocomplete="off">
                                                <option value="M" selected="selected">男</option>
                                                <option value="F">女</option>
                                            </select>
                                        </div>
                                    </span>
                            </li>
                     <li style="display:none">
                        <span class="xm" style="display:none">出生日期</span><span class="xm-inp"></span>
                    </li>
                    <li>保险
                        <span class="zj" style="float: right; width: 77%; border-left: 1px solid #ccc">
                            <div class="sel_wrap">
                                 <span class="zj">航空险</span>
                                 <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlInsurance" runat="server" CssClass="selectinsuranceproduct Jsselect" AutoPostBack="true" OnSelectedIndexChanged="ddlInsurance_SelectedIndexChanged">
                                            <asp:ListItem Value="0">航空险</asp:ListItem>
                                            <asp:ListItem Value="1">意外险</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                  </asp:UpdatePanel>
                                    <%--<select name="ddlInsurance" id="ddlInsurance" class="selectinsuranceproduct Jsselect" autocomplete="off">
                                        <option value="0">航空险</option>
                                        <option value="1">意外险</option>
                                    </select>--%>
                            </div>
                        </span>
                        <%--<span class="bxms">
                                    
                        </span>--%>
                    </li>
                        <div class="baoxian-mx">
                        <span class="bx"></span><br />
                       
                        <a id="ms" onclick="bxms(this)">保险产品描述</a>
                        
                        </div>
                        <div class="bxms"  style="display:none;" runat="server"></div>
                        <div class="bxje"  style="display:none;" runat="server"></div>
                </ul>
                 </ContentTemplate></asp:UpdatePanel>
                <ul id="passhead" runat="server">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                    <ContentTemplate>
				        <li><div class="cjr"></div><div class="zj-cjr"><asp:LinkButton runat="server" ID="addpassgen" OnClick="addpassgen_Click">增加乘客</asp:LinkButton><%--<a onclick="copypassenger()">增加乘客</a>--%></div></li>
				    </ContentTemplate></asp:UpdatePanel>
                                        </ul>
                </div>
            </div>
        </div>
        
        <div class="contact">
            <ul>
                <li>
                    <div class="shouji">联系人</div>
                    <div class="shouji-inp">
                        <input name="" type="text" id="linkman" placeholder="请填写联系人姓名" value="">
                    </div>
                </li>
                <li>
                    <div class="shouji">
                        联系手机
                    </div>
                    <div class="shouji-inp">
                        <input name="" type="text" id="linkmobile" placeholder="请填写联系人手机号码" value="" maxlength="11">
                    </div>
                </li>
                 <li>
                     <div style="font-size:6px">
            票面价：￥<span id="span1"><asp:Label runat="server" ID="price"></asp:Label></span> ,
            机建费：￥<span id="span6"><asp:Label runat="server" ID="jjf"></asp:Label></span>,
            燃油费：￥<span id="span12"><asp:Label runat="server" ID="ryf"></asp:Label></span>
        </div>
                    </li>
            </ul>
        </div>
        
         <div class="zongjin mb">
            总金额：￥<span class="jine" id="span_priceinfo"><asp:Label runat="server" ID="allprice"></asp:Label></span>
        </div>
        <div class="btn-block">
            <a href="#" onclick="SubmitOrder()">提交订单</a>
        </div>
        <div style="height: 15px;"></div>
        <input type="hidden" runat="server" id="uid"/>
          <input type="hidden" runat="server" id="aircode" />
          <input type="hidden" runat="server" id="depcity" />
          <input type="hidden" runat="server" id="arrcity" />
          <input type="hidden" runat="server" id="flight" />
          <input type="hidden" runat="server" id="flightmodel" />
          <input type="hidden" runat="server" id="cabin" />
          <input type="hidden" runat="server" id="yprice" />
          <input type="hidden" runat="server" id="discount" />
          <input type="hidden" runat="server" id="depterminal" />
          <input type="hidden" runat="server" id="arrterminal" />
          <input type="hidden" runat="server" id="staynum" />
         <input type="hidden" runat="server" id="depdate" />
         <input type="hidden" runat="server" id="deptime" />
         <input type="hidden" runat="server" id="arrtime" />
         <input type="hidden" runat="server" id="dprice" />
         <input type="hidden" runat="server" id="ticketcodeTxt" />
         <input type="hidden" runat="server" id="depacity" />
         <input type="hidden" runat="server" id="arrycity" />
         <input type="hidden" runat="server" id="pricesum"  />
    </form>
     <script src="/JS/TicketCreateOrder.js" type="text/javascript" charset="utf-8"></script>
    
</body>
</html>
