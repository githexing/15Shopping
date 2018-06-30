<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProduceThreeType.aspx.cs" Inherits="Web.admin.product.ProduceThreeType" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/base.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../Content/themes/icon.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body class="subBody">
    <div class="main_content">
        <form id="form1" class="main_dt" runat="server">
            <%-- <h2>
            添加商品类目</h2>
            <ul>
            
            <li><span><font>*</font></span>
                
            </li>
            
        </ul>--%>
            <div class="operation">
                <fieldset class="fieldset">
                    二级分类：<asp:DropDownList ID="ddlPriduceType" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;三级分类：<asp:TextBox ID="txtPriduceType" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btn_btnAdd" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                    OnClick="btnAdd_Click"> 添 加 </asp:LinkButton>
                </fieldset>
            </div>
            <div>
                <br />
                <table id="tabcontent" width="100%" border="0" cellspacing="0" cellpadding="0" class="t1">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <tr>
                                <th align="center">二级分类
                                </th>
                                <th align="center">三级分类
                                </th>
                                <th align="center">操作
                                </th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td align="center">
                                    <%# GetParentName(Eval("ParentID"))%>
                                </td>
                                <td align="center">
                                    <asp:TextBox runat="server" ID="txtTypeName" MaxLength="120" Style="text-align: center; width: 90%;"
                                        Text='<%# Eval("TypeName")%>'></asp:TextBox>
                                </td>

                                <td align="center">
                                    <asp:LinkButton ID="lbtnEdit" CommandArgument='<%#Eval("ID") %>' CommandName="Update" OnClientClick="return confirm('确定要修改?')"
                                        runat="server">编辑</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lbtnDel" CommandArgument='<%#Eval("ID") %>' CommandName="del"
                                        runat="server" OnClientClick="javascript:return confirm('注意：将会删除此类别下的所有商品!')">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div id="span1" class="cBlack" runat="server" style="text-align: center;">
                    <span>&nbsp;抱歉！目前数据库暂无数据显示。</span>
                </div>
            </div>
            <div class=" yellow">
                <span class="count">显示<%=((AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex-1)) +1).ToString()%>到<%=AspNetPager1.CurrentPageIndex == AspNetPager1.PageCount ? AspNetPager1.RecordCount.ToString(): ((AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex-1)) +AspNetPager1.PageSize).ToString()%>,共<%=AspNetPager1.RecordCount.ToString()%>记录,每页<%=AspNetPager1.PageSize.ToString()%>条</span><span
                    class="number"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" SkinID="AspNetPagerSkin"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上一页" AlwaysShow="true" NumericButtonCount="3" PageSize="15">
                    </webdiyer:AspNetPager>
                </span>
            </div>
        </form>
    </div>
</body>
</html>
