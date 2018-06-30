<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMachine.aspx.cs" Inherits="Web.admin.finance.AddMachine" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <title>�����ֵ</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/select2.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">�����ֵ</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">��Ա���:</label>
                                <asp:TextBox ID="txtUserCode" class="form-control" runat="server" tip="�����Ա���"></asp:TextBox>
                            </div>
                          
                            <div class="form-group mt10">
                                <label class="control-label">��ֵ����:</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtMoney" class="form-control" runat="server" min="0" precision="2" tip="�����ֵ����"></asp:TextBox>
                                    <span class="input-group-addon">̨</span>
                                </div>
                            </div>
                           
                            <div class="form-group mt10">
                                <asp:LinkButton ID="btnSub" runat="server" class="btn btn-success mr5"
                                    iconcls="icon-ok" OnClientClick="javascript:return confirm('ȷ�ϸ��û�Ա��ֵ�����')" OnClick="btnSub_Click"><i class="fa fa-check"></i> �� �� </asp:LinkButton>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">�����ֵ��ѯ</h4>
                </div>
                <div class="panel-body">
                    
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">��Ա���:</label>
                                <asp:TextBox ID="usercode" runat="server" CssClass="form-control" ></asp:TextBox>
                                <%--<asp:TextBox ID="txtCode" runat="server" tip="�����Ա���" class="form-control"></asp:TextBox>--%>
                            </div>
                             
                            <div class="form-group mt10">
                                <label class="control-label">��ֵ����:</label>
                                <asp:TextBox ID="txtStart" tip="�����ֵ����" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">��</label>
                                <asp:TextBox ID="txtEnd" tip="�����ֵ����" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="lbtnSearch" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSubmit_Click"><i class="fa fa-search"></i> �� �� </asp:LinkButton>
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
                                <th style="min-width: 80px;">����</th>
                                <th style="min-width: 80px;">��ֵ����</th>
                                <th style="min-width: 80px;">��ֵ����</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="��Ա���">
                                        <%#Eval("UserCode")%>
                                    </td>
                                     <td data-attr="����">
                                        <%#Eval("TrueName")%>
                                    </td>
                                    <td data-attr="��ֵ����">
                                        <%#Eval("Num")%>
                                    </td>
                                    <td data-attr="��ֵ����">
                                        <%#Eval("BuyTime")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none">
                            <td colspan="7" align="center">��Ǹ������������ʾ��</td>
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

