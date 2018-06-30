<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="web.admin.product.EditProduct" %>

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
    <style type="text/css">
        .style1 {
            width: 150px;
        }

        table span {
            padding-left: 5px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $(".panel").css("display", "none");
            $(".panel-header").css("display", "none");
            $(".panel-title").css("display", "none");
            $(".window-shadow").css("display", "none");
        });
    </script>
    <script type="text/javascript">
        function check() {
            document.getElementById("form1").reset();
        }
        function showDialog() {
            if ($('#hGid').val() == '') {
                alert("请先提交商品信息再添加属性！");
                return;
            }
            $('#divw').show();
            var top = $("#btnadd").offset().top - 400;
            var left = $("#btnadd").offset().left;
            $('#divw').window('open').window('resize', { width: '500px', height: '350px', top: top, left: left });
            $(".panel").css("display", "block");
            $(".panel-header").css("display", "block");
            $(".panel-title").css("display", "block");
            $(".window-shadow").css("display", "block");
        }
        function hideDialog() {
            $('#divw').hide();
            $(".panel").css("display", "none");
            $(".panel-header").css("display", "none");
            $(".panel-title").css("display", "none");
            $(".window-shadow").css("display", "none");
        }
    </script>

    <script type="text/javascript">
        function sizeValue() {
            var ss = "";

            $('.psize').each(function () {
                id = $(this).attr('id').split('_')[1];
                va = $(this).val();
                if (va != "") {
                    ss += id + ',' + va;
                    ss += '|';
                }
            });
            return ss;
        }

        function propertySubmit() {
            var t_gid = $('#hGid').val();
            var t_color = $('#txtColor').val()
            var t_size = sizeValue();

            if (t_gid == '') {
                alert("请先提交商品信息再添加属性");
                return;
            }
            if (t_color.trim() == '') {
                alert("请输入颜色！");
                return;
            }
            if (t_size.trim() == '') {
                alert("请输入尺码数量！");
                return;
            }
            $.ajax({
                type: 'POST',
                url: '/APPService/Mall.ashx',
                data: {act:"", gid: t_gid, color: t_color, size: t_size },
                success: function (data) {
                    alert(data);
                    if (data == '添加属性成功') {
                        $('#divw').window('close');
                        location.reload();
                        //window.scrollTo(0, document.body.clientHeight);
                    }
                },
                dataType: 'text'
            });
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
                        <div style="height: 20px;"></div>
                        <table border="0" cellpadding="0" width="100%" cellspacing="0">
                            <tr runat="server" id="trType">
                                <td align="right">一级分类：
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlType" runat="server">
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--二级分类：<asp:DropDownList ID="ddl_secondType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_secondType_SelectedIndexChanged">
                                               <asp:ListItem Selected="True">1</asp:ListItem>
                                            </asp:DropDownList>
                                            三级分类：<asp:DropDownList ID="dd_sanType" runat="server">
                                                <asp:ListItem Value="0">请选择</asp:ListItem>
                                            </asp:DropDownList>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="100px">商品编号：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGoodsCode" runat="server" class="input_select1" Width="200px" MaxLength="60"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">商品名称：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGoodsName" runat="server" class="input_select1" Width="200px" MaxLength="60"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr runat="server" id="trAddRecommend" style="display:none">
                                <td align="right">加入推荐：
                                </td>
                                <td>
                                    <asp:CheckBoxList ID="checkList" runat="server" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">新品上市</asp:ListItem>
                                        <asp:ListItem Value="2">折扣区</asp:ListItem>
                                        <asp:ListItem Value="3">每周推荐</asp:ListItem>
                                        <asp:ListItem Value="4">母婴用品</asp:ListItem>
                                        <asp:ListItem Value="5">食品饮料</asp:ListItem>
                                        <asp:ListItem Value="6">个人护理</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">库存数量：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNum" runat="server" min="0" class="input_select1"
                                        precision="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">市场价：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrice" runat="server" class="input_select1"
                                        Width="200px"></asp:TextBox><span>元</span>
                                </td>
                            </tr>

                            <tr>
                                <td align="right">本站价：</td>
                                <td>
                                    <asp:TextBox ID="txtShopPrice" runat="server" class="input_select1"
                                        Width="200px" >0</asp:TextBox><span>元</span>
                                </td>
                            </tr>
                                   <tr style="display:none">
                                <td align="right">分润单位：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" min="0" class="input_select1" onkeyup="value=value.replace(/[^\d]/g,'')" 
                                        precision="0" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr runat="server" id="trCity" style="display:none">
                                <td align="right">所在城市：
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" min="0" class="input_select1"
                                        precision="1" Width="200px"></asp:TextBox><span></span>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right">商品图片：
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" class="input_select1" Width="200px" onchange="this.form.LinkButton3.click();" />&nbsp;&nbsp;
                                <asp:Button ID="btnUpload" runat="server" class="easyui-linkbutton" OnClick="btnUpload_Click" Text="上 传"></asp:Button><asp:Label ID="Label1" runat="server"
                                    Text="" ForeColor="Red">(上传商品图片长宽比例为565*374)</asp:Label>
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
                    </td>
                </tr>
            </table>
            <!--添加属性窗口-->
            <%--<div id="divw" title="添加属性" class="easyui-window backdiv" style="width: 500px; height: 350px; padding: 10px; top: 100px; display: none;">
                <table border="0" cellpadding="0" width="100%" cellspacing="0">
                    <tr>
                        <td>&nbsp;</td>
                        <td><a style="position: relative; top: -10px; left: 315px; color: Gray;" href="javascript:void(0)"
                            id="cle" onclick="hideDialog();">关闭</a></td>
                    </tr>
                    <tr runat="server">
                        <td align="right">颜色：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td align="right">图片：
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fileColor" runat="server" class="input_select1" Width="200px" onchange="this.form.btnColorPic.click();" />&nbsp;&nbsp;
                            <asp:Button ID="btnColorPic" runat="server" class="easyui-linkbutton3333" OnClientClick="sizeValue();return true;" OnClick="btnColorPic_Click" Width="0px" Height="0px" Text="上 传"></asp:Button>
                            <br />
                            <asp:Label ID="Label2" runat="server"
                                Text="" ForeColor="Red">(上传商品图片长宽比例为60*60)</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">尺码：
                        </td>
                        <td align="left">
                            <table>
                                <tr>
                                    <td></td>
                                    <td>输入尺码数量，没有则留空</td>
                                </tr>
                                <asp:Repeater ID="rpSize" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("Name") %></td>
                                            <td>
                                                <input class="psize" type="text" id='s_<%#Eval("SizeID") %>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="button" id="colorSubmit" onclick="propertySubmit()" value="确定" /></td>
                    </tr>
                    <tr runat="server" id="tr1"></tr>
                </table>
            </div>
            <input type="hidden" id="hSizeValue" runat="server" />
            <input type="hidden" id="hGid" value="<%=GetPID() %>" />--%>

            <!--添加属性窗口-->
            <%--<div>
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnadd" onclick="showDialog()">添加属性</a>
                <div class="dataTable">
                    <table class="t1" style="width: 300px">
                        <thead>
                            <tr>
                                <th>颜色</th>
                                <th>尺码</th>
                                <th>数量</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpColor" runat="server" OnItemDataBound="rpColor_ItemDataBound" OnItemCommand="rpColor_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="3"><%#Eval("ColorName") %>
                                            <asp:LinkButton ID="btnColorDel" class="easyui-linkbutton" iconcls="icon-clear" Style="margin-left: 100px;" runat="server" Text="删除" CommandName="del" CommandArgument='<%#Eval("ColorID") %>' /></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td colspan="2">
                                            <table width="99%" border="0" style="border: 0px;">
                                                <asp:Repeater ID="rptProduct" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Eval("SizeName") %></td>
                                                            <td><%#Eval("Qry") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>--%>
        </form>
    </div>
</body>
</html>
