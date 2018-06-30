<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="Web.admin.business.UserDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
<%--    <link href="../../style/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" /--%>
        <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
        <div class="dataTable">
            <fieldset class="fieldset">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr style="display:none">
                        <td width="200" align="right">
                            <h1>
                                登录资料：
                            </h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>会员编号：
                        </td>
                        <td align="left">
                            <input name="txtUserCode" type="text" id="txtUserCode" runat="server" class="form-control"  />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>登陆密码：
                        </td>
                        <td align="left">
                            <input name="txtPassword" type="text" id="txtPassword" runat="server" class="form-control" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>二级密码：
                        </td>
                        <td align="left">
                            <input name="txtSecondPassword" type="text" id="txtSecondPassword" runat="server" class="form-control"
                                disabled="disabled" />
                        </td>
                    </tr>
                  <%--  <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>三级密码：
                        </td>
                        <td align="left">
                            <input name="txtThreePassword" type="text" id="txtThreePassword" runat="server" class="form-control"
                                disabled="disabled" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td width="200" align="right">
                            <h1>
                                网络资料：
                            </h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                  <%--  <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>会员级别：
                        </td>
                        <td align="left">
                            <input name="txtLevel" type="text" id="txtLevel" runat="server" class="form-control" disabled="disabled" />
                        </td>
                    </tr>--%>
                  <%--  <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>注册金额：
                        </td>
                        <td align="left">
                            <input name="txtRegMoney" type="text" id="txtRegMoney" runat="server" disabled="disabled"
                                class="form-control1" />
                        </td>
                    </tr>--%>
                    <%--<tr id="txtArea" runat="server" visible="false">
                        <td width="200" align="right">
                            <span class="cRed">*</span>代理区域：
                        </td>
                        <td align="left">
                            <input name="txtProvince" type="text" id="txtProvince" runat="server" class="form-control" disabled="disabled" />
                            <input name="txtCity" type="text" id="txtCity" runat="server" class="form-control" disabled="disabled" />
                            <input name="txtCountry" type="text" id="txtCountry" runat="server" class="form-control" disabled="disabled" />
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td width="200" align="right" >
                            <span class="cRed">*</span>服务网点编号：
                        </td>
                        <td align="left">
                            <input name="txtAgentCode" type="text" id="txtAgentCode" runat="server" class="form-control" disabled="disabled" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>推荐人编号：
                        </td>
                        <td align="left">
                            <input name="txtRecommendCode" type="text" id="txtRecommendCode" runat="server" class="form-control"
                                disabled="disabled" />
                        </td>
                    </tr>
                   <%-- <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>安置会员编号：
                        </td>
                        <td align="left">
                            <input name="txtParentCode" type="text" id="txtParentCode" runat="server" class="form-control"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>注册区域：
                        </td>
                        <td align="left">
                            <input id="Radio1" type="radio" name="qy" runat="server" disabled="disabled" />
                            1市场&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="Radio2" type="radio" name="qy" runat="server" disabled="disabled" />
                            2市场
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>--%>
                 <%--   <tr style="display:none">
                        <td width="200" align="right">
                            <h1>
                                银行资料：</h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>开户银行：
                        </td>
                        <td align="left">--%>
                            <%--
                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>--%>
                          <%--  <asp:DropDownList ID="dropBank" runat="server" class="form-control" >
                            </asp:DropDownList>
                            <asp:DropDownList ID="dropProvince" runat="server" class="form-control" >
                            </asp:DropDownList>--%>
                            <%--
                                <asp:DropDownList ID="DropDownList1" runat="server" class="">
                                    <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    <%--    </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>银行支行：
                        </td>
                        <td align="left">
                            <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>银行账户：
                        </td>
                        <td align="left">
                            <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="form-control"
                                value="" maxlength="19" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>开户名：
                        </td>
                        <td align="left">
                            <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>支付宝账号：
                    </td>
                    <td align="left">
                       <input type="text" class="form-control" id="txtAlipay" runat="server"  />
                    </td>
                </tr>
               --%>
                   <%-- <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr style="display:none">
                        <td width="200" align="right">
                            <h1>
                                基本资料：</h1>
                        </td>
                        <td align="left">
                        </td>
                    </tr>--%>
                    <tr  style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>姓名：
                        </td>
                        <td align="left">
                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>昵称：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtNickName" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr  >
                        <td width="200" align="right">
                            <span class="cRed">*</span>身份证号：
                        </td>
                        <td align="left">
                            <input name="txtIdenCode" type="text" id="txtIdenCode" runat="server" class="form-control" />
                        </td>
                    </tr>
                   <%-- <tr>
                        <td width="200" align="right">
                            手机号码：
                        </td>
                        <td align="left">
                            <input name="txtPhoneNum" type="text" id="txtPhoneNum" runat="server" class="form-control" />
                        </td>
                    </tr>--%>
                  <%--  <tr id="trAddress"  style="display:none">
                        <td width="200" align="right">
                            <span class="cRed">*</span>联系地址：
                        </td>
                        <td align="left">
                            <input name="txtAddress" type="text" id="txtAddress" runat="server" class="form-control" />
                        </td>
                    </tr>
                                           <tr style="display:none">
                        <td width="200" align="right"  >
                          <span class="cRed">*</span>电子邮箱：
                        </td>
                        <td align="left">
                            <input name="txtEmail" type="text" id="txtEmail" runat="server" class="form-control" />
                        </td>
                    </tr>
                         <tr style="display:none">
                    <td width="200" align="right"   >
                        <span class="cRed">*</span>Q Q号码：
                    </td>
                    <td align="left">
                        <input name="txtQQnumer" type="text" id="txtQQnumer" runat="server" class="form-control" />
                    </td>
                </tr>--%>
   <%--                  <tr>
                        <td width="200" align="right">
                           <span class="cRed">*</span>密保答案：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlQuestion" runat="server"  AutoPostBack="true"
                                onselectedindexchanged="ddlQuestion_SelectedIndexChanged">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                                <asp:ListItem Value="1">您的姓名是？</asp:ListItem>
                                <asp:ListItem Value="2">您的家乡是？</asp:ListItem>
                                <asp:ListItem Value="3">您最敬佩的人是？</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>密保答案：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtAnswer" runat="server" class="form-control"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <%--                <tr>
                    <td width="200" align="right">
                        Email：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtEmail" runat="server" class="form-control" />
                    </td>
                </tr>--%>
                    <%--<tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>邮编号码：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtYouBian" runat="server" class="form-control" />
                    </td>
                </tr>
                <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>QQ号码：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtQQnumer" runat="server" class="form-control" />
                    </td>
                </tr>--%>
<%--                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <h1>
                                <span class="cRed">*</span>激活方式：</h1>
                        </td>
                        <td align="left">
                            <input id="rdHK" type="radio" name="jh" runat="server" disabled="disabled" />
                            银行汇款&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="rdZX" type="radio" name="jh" runat="server" disabled="disabled" />
                            在线激活
                        </td>
                    </tr>--%>
                    <tr style="height:30px"></tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSubmit" class="btn btn-primary mr5" runat="server" Text="提 交"   OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnUpdatePwd" class="btn btn-default mr5" runat="server" Text="重置密码" OnClientClick="javascript:return confirm('是否确定将密码重置为111111？')"   OnClick="btnUpdatePwd_Click" />
                            <a class="btn btn-info mr5" onclick="javascript:history.go(-1)">返回</a>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
