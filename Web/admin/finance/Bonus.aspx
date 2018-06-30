<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bonus.aspx.cs" Inherits="Web.admin.finance.Bonus" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>��Ա����</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">�Ƽ����ۼ�</th>
                                <th style="min-width: 80px;">�������ۼ�</th>
                                <th style="min-width: 80px;">�������ۼ�</th>
                                <th style="min-width: 80px;">�����ۼ�</th>
                                <th style="min-width: 80px;">�������Ľ��ۼ�</th>
                                <th style="min-width: 80px;">���㽱�ۼ�</th>
                                <th style="min-width: 80px;">���ѻ��ֶһ����ۼ�</th>
                                <th style="min-width: 80px;">�����ۼ�</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td data-attr="�ͷű��ۼ�">
                                    <%=GetBonus(0, 1)%>
                                </td>
                                <td data-attr="��̬�����ۼ�">
                                    <%=GetBonus(0, 2)%>
                                </td>
                                <td data-attr="��̬�����ۼ�">
                                    <%=GetBonus(0, 3)%>
                                </td>
                                   <td data-attr="��̬�����ۼ�">
                                    <%=GetBonus(0, 4)%>
                                </td>
                                   <td data-attr="��̬�����ۼ�">
                                    <%=GetBonus(0, 5)%>
                                </td>
                                   <td data-attr="��̬�����ۼ�">
                                    <%=GetBonus(0, 6)%>
                                </td>
                                   <td data-attr="��̬�����ۼ�">
                                    <%=GetBonus(0, 7)%>
                                </td>
                                <td data-attr="�����ۼ�">
                                    <%=GetBonusAllTotal(0, "Amount")%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">��Ա�����ѯ</h4>
                </div>
                <div class="panel-body">
                    <div class="form-inline">
                        <div class="form-group mt10">
                            <label class="control-label">��������:</label>
                            <asp:TextBox ID="txtStar" tip="�����������"
                                runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            <label class="control-label">��</label>
                            <asp:TextBox ID="txtEnd" tip="�����������" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                        </div>
                        <div class="form-group mt10">
                            <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                OnClick="btnSearch_Click"><i class="fa fa-search"></i> �� �� </asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                OnClick="LinkButton3_Click"><i class="fa fa-download"></i> �� �� </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
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
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="�ͷű�">
                                        <%#Eval("shifang")%><%--1.�ͷű�--%>
                                    </td>
                                    <td data-attr="��̬����">
                                        <%#Eval("jingtai")%><%--2.��̬����--%>
                                    </td>
                                    <td data-attr="��̬����">
                                        <%#Eval("dongtai")%><%--3.��̬����--%>
                                    </td>
                                      <td data-attr="��̬����">
                                        <%#Eval("dongtai1")%><%--3.��̬����--%>
                                    </td>
                                      <td data-attr="��̬����">
                                        <%#Eval("dongtai2")%><%--3.��̬����--%>
                                    </td>
                                      <td data-attr="��̬����">
                                        <%#Eval("dongtai3")%><%--3.��̬����--%>
                                    </td>
                                      <td data-attr="��̬����">
                                        <%#Eval("dongtai4")%><%--3.��̬����--%>
                                    </td>
                                    <td data-attr="ʵ��">
                                        <%#Eval("am")%><%--ʵ��--%>
                                    </td>
                                    <td data-attr="��������">
                                        <%#Eval("SttleTime")%><%--��������--%>
                                    </td>
                                    <td data-attr="�鿴��ϸ">
                                        <asp:LinkButton ID="lbtnDetail" class="btn btn-info" runat="server" PostBackUrl='<%#Eval("SttleTime","BonusDetail.aspx?SttleTime={0}") %>'><i class="fa fa-share-square-o"></i>�鿴��ϸ</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server">
                            <td colspan="8" align="center" class="none">��Ǹ��Ŀǰ����������ʾ��</td>
                        </tr>
                    </table>
                    <div class="nextpage cBlack">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                            FirstPageText="��ҳ"
                            LastPageText="βҳ" NextPageText="��һҳ" PrevPageText="��һҳ" AlwaysShow="True" InputBoxClass="pageinput"
                            NumericButtonCount="3" PageSize="12" ShowInputBox="Never" ShowNavigationToolTip="True"
                            SubmitButtonClass="pagebutton" UrlPaging="false" PageIndexBoxType="TextBox" ShowPageIndexBox="Always"
                            SubmitButtonText="ת��" TextAfterPageIndexBox=" ҳ" TextBeforePageIndexBox="ת�� " Direction="LeftToRight"
                            HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged">
                        </webdiyer:AspNetPager>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
