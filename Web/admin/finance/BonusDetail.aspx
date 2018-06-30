<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BonusDetail.aspx.cs" Inherits="Web.admin.finance.BonusDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server"  class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">��ѯ</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline"  >
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">��Ա���:</label>
                                <asp:TextBox ID="txtUserCode" tip="�����Ա���"
                                    runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">��Ա����:</label>
                                <asp:TextBox ID="txtTrueName" tip="��������" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5 mb10" iconcls="icon-search"
                                    OnClick="lbtnSearch_Click"><i class="fa fa-search"></i> �� �� </asp:LinkButton>
                                <asp:LinkButton ID="lbtnBack" runat="server" class="btn btn-primary mb10" iconcls="icon-search"
                                    PostBackUrl="Bonus.aspx">�� �� </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">��Ա���</th>
                                <th style="min-width: 80px;">��Ա����</th>
                                <th style="min-width: 80px;">�Ƽ���</th>
                                <th style="min-width: 80px;">������</th>
                                <th style="min-width: 80px;">������</th>
                                <th style="min-width: 80px;">����</th>
                                <th style="min-width: 80px;">�������Ľ�</th>
                                <th style="min-width: 80px;">���㽱</th>
                                <th style="min-width: 80px;">���ѻ��ֶһ���</th>
                                <th style="min-width: 80px;">ʵ��</th>
                                <th style="min-width: 80px;">��������</th>
                                <th style="min-width: 80px;">�鿴��ϸ</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="��Ա���">
                                        <%#Eval("UserCode")%><%--��Ա���--%>
                                    </td>
                                    <td data-attr="��Ա����">
                                        <%#Eval("TrueName")%><%--��Ա���--%>
                                    </td>
                                    <td data-attr="�ͷű�">
                                        <%#Eval("shifang")%><%--1.�ͷű�--%>
                                    </td>
                                    <td data-attr="��̬����">
                                        <%#Eval("jingtai")%><%--2.��̬����--%>
                                    </td>
                                    <td data-attr="��̬����">
                                        <%#Eval("dongtai")%><%--3.��̬����--%>
                                    </td>
                                    <td data-attr="���㽱">
                                        <%#Eval("dongtai1")%><%--2.���㽱--%>
                                    </td>
                                    <td data-attr="��������">
                                        <%#Eval("dongtai2")%><%--2.��������--%>
                                    </td>
                                    <td data-attr="�Ŷ�����">
                                        <%#Eval("dongtai3")%><%--2.�Ŷ�����--%>
                                    </td>
                                      <td data-attr="�Ŷ�����">
                                        <%#Eval("dongtai4")%><%--2.�Ŷ�����--%>
                                    </td>

                                    <td data-attr="ʵ��">
                                        <%#Eval("am")%><%--ʵ�� 6--%>
                                    </td>
                                    <td data-attr="��������">
                                        <%#Eval("SttleTime")%><%--��������--%>
                                    </td>
                                    <td data-attr="�鿴��ϸ">
                                        <asp:LinkButton ID="lbtnDetail" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                            class="btn btn-info" iconcls="icon-search" CommandName="Open"><i class="fa fa-search"></i>�鿴��ϸ</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="trBonusNull" runat="server" class="none">
                            <td colspan="15" align="center">��Ǹ��Ŀǰ���ݿ�����������ʾ��</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">

                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                             FirstPageText="��ҳ"
                            LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" pageindexboxtype="TextBox" showpageindexbox="Always"
                            SubmitButtonText="ת��" textafterpageindexbox=" ҳ" textbeforepageindexbox="ת�� " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                     
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
