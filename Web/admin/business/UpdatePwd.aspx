<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePwd.aspx.cs" Inherits="Web.admin.business.UpdatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
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
                <div class="main_dt">
                <h2>
    <asp:LinkButton ID="LinkButton1" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-back" onclick="btnReturn_Click" > 返 回 </asp:LinkButton>修改<%=usercode %>密码</h2>
                    <ul>
                        
                        <li><span><font>*</font>新登录密码：</span>
                                    <input name="Add_sscFd7" id="textNewPassWord" class="input_second"  runat="server" type="password"
                                        tip="输入新登录密码(必输入项)" />
                        </li>
                        <li><span><font>*</font>确认登录密码：</span>
                                    <input name="Add_sscFd7" id="textRPNewPassWord" class="input_second"  runat="server" type="password"
                                        tip="输入确认登录密码(必输入项)" />
                        </li>
                        <div class="dt_button">
    <asp:LinkButton ID="LinkButton2" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-save" onclick="btnPassWord_Click" > 保 存 </asp:LinkButton>
                            </div>
                        <li><span><font>*</font>新二级密码：</span>
                                    <input name="Add_sscFd7" id="textNewSecondPass" class="input_second"  runat="server" type="password"
                                        tip="输入新二级密码(必输入项)" />
                        </li>
                        <li><span><font>*</font>确认二级密码：</span>
                                    <input name="Add_sscFd7" id="textRPSecondPass" class="input_second"  runat="server" type="password"
                                        tip="确认二级密码(必输入项)" />
                        </li>
                        <div class="dt_button">
    <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-save" onclick="btnSecondPass_Click" > 保 存 </asp:LinkButton>
                            </div>
                        <li><span><font>*</font>新三级密码：</span>
                                    <input name="Add_sscFd7" id="Password2" class="input_second"  runat="server" type="password"
                                        tip="输入新三级密码(必输入项)" />
                        </li>
                        <li><span><font>*</font>确认三级密码：</span>
                                    <input name="Add_sscFd7" id="Password3" class="input_second"  runat="server" type="password"
                                        tip="确认三级密码(必输入项)" />
                        </li>
                        <div class="dt_button">
    <asp:LinkButton ID="LinkButton4" runat="server" class="easyui-linkbutton"   
                    iconcls="icon-save" onclick="Button1_Click" > 保 存 </asp:LinkButton>
                            </div>
                        </ul>
                </div>
    </form>
</body>
</html>

