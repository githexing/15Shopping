<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="Web.user.team.UpdateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑用户</title>
    <link href="../../style/css.css" rel="Stylesheet" type="text/css" />
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () { 
           var data=<%=levelID %>;
           if(data=="2")
           {
              $("#trAddress").hide();
           }
        })
    </script>
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="capositon">
            当前位置：首页>><a href="javascript:void(0)">修改信息</a></div>
        <div class="dataTable">
            <fieldset class="fieldset">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="">
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>用户名：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtUserCode" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>登陆密码：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtPassword" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>二级密码：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtSecondPassword" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>三级密码：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtThreePassword" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>报单会员用户名：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtAgentCode" runat="server" class="input_reg" visible="True"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>推荐会员用户名：
                        </td>
                        <td>
                            <input name="jd" type="text" id="txtRecommendCode" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>接点会员用户名：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtParentCode" runat="server" class="input_reg"
                                disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>会员级别：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtLevel" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>注册金额：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtRegMoney" runat="server" class="input_reg" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>注册区域：
                        </td>
                        <td align="left">
                            <input id="Radio1" type="radio" name="qy" runat="server" disabled="disabled" />
                            左区&nbsp;&nbsp;&nbsp;&nbsp;
                            <input id="Radio2" type="radio" name="qy" runat="server" disabled="disabled" />
                            右区
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>姓名：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtTrueName" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>昵称：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtNickName" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>身份证号：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtIdenCode" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>手机号：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtPhoneNum" runat="server" value="" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <td width="200" align="right">
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>开户银行：
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlBank" runat="server">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                    </asp:DropDownList>
                                    <%--                                                                        <asp:DropDownList ID="DropDownList1" runat="server" class="">
                                        <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                    </asp:DropDownList>--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>银行支行：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtBankBranch" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>银行卡号：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtBankAccount" runat="server" value="" class="input_reg" maxlength="19" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            <span class="cRed">*</span>开户名：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtBankAccountUser" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr id="trAddress">
                        <td width="200" align="right">
                            发货地址：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtAddress" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSubmit" runat="server" Text="提 交" class="btn" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                    <%--<tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>财付通号：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtCaiCode" runat="server" class="input_reg" />
                    </td>
                </tr>
                <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>财付通名：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtCaiName" runat="server" class="input_reg" />
                    </td>
                </tr>--%>
                    <%--                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>--%>
                    <%--    <tr>
                        <td width="200" align="right">
                            联系地址：
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownList4" runat="server" class="" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList5" runat="server" class="">
                                        <asp:ListItem Value="请选择">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtAddress" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            Email：
                        </td>
                        <td align="left">
                            <input name="jd" type="text" id="txtEmail" runat="server" class="input_reg" />
                        </td>
                    </tr>
                    <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>邮编号码：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtYouBian" runat="server" class="input_reg" />
                    </td>
                </tr>
                <tr>
                    <td width="200" align="right">
                        <span class="cRed">*</span>QQ号码：
                    </td>
                    <td align="left">
                        <input name="jd" type="text" id="txtQQnumer" runat="server" class="input_reg" />
                    </td>
                </tr>--%>
                    <tr>
                        <td width="200" align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td width="200" align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    </form>
</body>
</html>
