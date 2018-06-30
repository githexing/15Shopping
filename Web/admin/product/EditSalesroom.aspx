<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditSalesroom.aspx.cs" Inherits="web.admin.product.EditSalesroom" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
    <script src="../../JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../../JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1 {
            width: 150px;
        }

        table span {
            padding-left: 5px;
        }

        .style2 {
            height: 32px;
        }
    </style>
    <script type="text/javascript">
        function ResetCheck() {
            document.getElementById("form1").reset();
        }
    </script>
</head>
<body class="subBody">
    <div class="main_content">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table border="0" cellpadding="0" width="100%" cellspacing="0" style="border: 1px #8a8b8b solid;">
                <tr>
                    <td style="padding-left: 20px; padding-top: 35px;" valign="top" class="style1">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Image ID="Image1" runat="server" Width="240px" Height="154px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <div style="height: 20px;">
                        </div>
                        <table border="0" cellpadding="0" width="100%" cellspacing="0">
                            <tr>
                                <td align="right">一级分类：
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="dropOneType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropOneType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            二级分类：<asp:DropDownList ID="dropSecondType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropSecondType_SelectedIndexChanged">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            三级分类：<asp:DropDownList ID="dropThreeType" runat="server">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="100px">商品编号：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGoodsCode" runat="server" class="input_select1" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">商品名称：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGoodsName" runat="server" class="input_select1" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">市场价：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrice" runat="server" min="0" class="easyui-numberbox input_select1"
                                        precision="2" Width="200px"></asp:TextBox><span>元</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">竞拍价：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRealityPrice" runat="server" min="0" class="easyui-numberbox input_select1"
                                        precision="2" Width="200px"></asp:TextBox><span>元</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">数量：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtCount" runat="server" min="0" class="easyui-numberbox input_select1"
                                        precision="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%-- <tr>
                            <td align="right">
                                所在城市：
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" min="0" class="input_select1"
                                    precision="1" Width="200px"></asp:TextBox><span></span>
                            </td>
                        </tr>--%>
                            <tr style="display: none;">
                                <td align="right">开始时间：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStart" runat="server" min="0" class="input_select1" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',minDate:'%y-%M-#{%d}'})"
                                        precision="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td align="right">结束时间：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEnd" runat="server" min="0" class=" input_select1" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',minDate:'%y-%M-#{%d}'})"
                                        precision="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr style="display: none;">
                                <td align="right">支付时间：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPlay" runat="server" min="0" class="easyui-numberbox input_select1"
                                        precision="0" Width="52px"></asp:TextBox>
                                    分钟内支付</td>
                            </tr>
                            <tr>
                                <td align="right">竞拍次数：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurchase" runat="server" min="0" class="easyui-numberbox input_select1" Enabled="false"
                                        precision="0" Width="52px"></asp:TextBox>次
                                </td>
                            </tr>
                            <tr>
                                <td align="right">商品图片：
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" class="input_select1" Width="200px" />&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton3" runat="server" class="easyui-linkbutton" OnClick="Button1_Click"> 上 传 </asp:LinkButton><asp:Label ID="Label1" runat="server"
                                    Text="" ForeColor="Red">(上传商品图片长宽比例为150*150)</asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; vertical-align: top;">商品详情：
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="textPubContext" Width="100%" Height="100%" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>

                <tr>
                    <td align="right"></td>
                    <td>
                        <asp:LinkButton ID="lbtnSubmit" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                            OnClick="lbtnSubmit_Click"> 提 交 </asp:LinkButton>
                        <asp:LinkButton ID="lbtnReset" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                            OnClientClick="ResetCheck()"> 重 置 </asp:LinkButton>
                        <asp:LinkButton ID="lbtnBack" runat="server" class="easyui-linkbutton" iconcls="icon-back"
                            OnClick="lbtnBack_Click"> 返 回 </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
