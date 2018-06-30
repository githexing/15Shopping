<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferSearch.aspx.cs"
    Inherits="Web.admin.finance.TransferSearch" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>ת�˲�ѯ</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">��Աת�˲�ѯ</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">��Ա���:</label>
                                <input id="textChuUserCode" type="text" runat="server" class="form-control" tip="����ת����Ա���" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">ת������:</label>
                                <asp:TextBox ID="txtChuStar" tip="����ת������" runat="server" onfocus="WdatePicker()"
                                    class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">��</label>
                                <asp:TextBox ID="txtChuEnd" tip="����ת������" runat="server" onfocus="WdatePicker()"
                                    class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnChuSearch_Click"><i class="fa fa-search"></i> �� �� </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">ת�����</th>
                                <th style="min-width: 80px;">ת����</th>
                                <th style="min-width: 80px;">ת������</th>
                                <th style="min-width: 80px;">ת�˽��</th>
                                <th style="min-width: 80px;">ת������</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="ת�����">
                                        <%#Eval("UserCode")%>
                                    </td>
                                    <td data-attr="ת����">
                                        <%#Eval("tocode")%>
                                    </td>
                                    <td data-attr="ת������">
                                        <%#ChangeType(Convert.ToInt32(Eval("ChangeType").ToString()))%>
                                    </td>
                                    <td data-attr="ת�˽��">
                                        <%#Eval("Amount")%>
                                    </td>
                                    <td data-attr="ת������">
                                        <%#Eval("ChangeDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server">
                            <td colspan="5" align="center" class="none">
                                <div class="NoData">
                                ��Ǹ��Ŀǰ���ݿ�����������ʾ��</td>
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
