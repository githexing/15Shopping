<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemitManage.aspx.cs" Inherits="Web.admin.finance.RemitManage" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />

    <title>��Ա��ֵ</title>

    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />

    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server" class="form-inline">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">��ֵ����</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">��Ա���:</label>
                                <asp:TextBox ID="txtUserCode" runat="server" tip="�����Ա���" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10" style="display:none;">
                                <label class="control-label">��Ա����:</label>
                                <asp:TextBox ID="txtTrueName" runat="server" tip="�����Ա����" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">���״̬:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropState" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="��ѡ��">��ѡ��</asp:ListItem>
                                        <asp:ListItem Value="1" Text="δ���">δ���</asp:ListItem>
                                        <asp:ListItem Value="2" Text="�����">�����</asp:ListItem>
                                        <asp:ListItem Value="3" Text="�ѳ���">�ѳ���</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="form-group mt10">
                                <label class="control-label">�������:</label>
                                <div class="form-control nopadding noborder">
                                    <asp:DropDownList ID="dropRemitType" runat="server" class="width100p selectval mwidth168 form-control">
                                        <asp:ListItem Value="0" Text="��ѡ��">��ѡ��</asp:ListItem>
                                        <asp:ListItem Value="1" Text="δ���">��ͨ��Ա</asp:ListItem>
                                        <asp:ListItem Value="2" Text="�����">�˺Ÿ�Ͷ</asp:ListItem>
                                        <asp:ListItem Value="3" Text="�����">��Ա����</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="form-group mt10">
                                <label class="control-label">��������:</label>
                                <asp:TextBox ID="txtStar" tip="������������" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                                <label class="control-label">��</label>
                                <asp:TextBox ID="txtEnd" tip="������������" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSearch_Click"><i class="fa fa-search"></i> �� �� </asp:LinkButton>
                            </div>
                        </div>
                        
                            
                        
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            <div class="panel panel-default">
                <div class="panel-body" id="image_container">
                    <table class="table table-bordered table-primary mb30">
                        <thead>
                            <tr>
                                <th style="min-width: 80px;">��Ա���</th>
                                <th style="min-width: 80px;">��Ա����</th>
                                <th style="min-width: 80px;">�տ��˻���Ϣ</th>
                                <th style="min-width: 80px;">��ֵ���</th>
                                <%--<th style="min-width: 80px;">�����</th>--%>
                                <th style="min-width: 80px;">����˻���Ϣ</th>
                              <%--   <th style="min-width: 80px;">��ֵ��</th>--%>
                                <th style="min-width: 80px;">��������</th>
                                <th style="min-width: 80px;">���״̬</th>
                                <th style="min-width: 80px;">�������</th>
                                
                                <th style="min-width: 80px;">����</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="rpRemit" runat="server" OnItemCommand="rpRemit_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td data-attr="��Ա���"><%#Eval("UserCode")%></td>
                                    <td data-attr="��Ա����"><%#Eval("Truename")%></td>
                                    <td data-attr="�տ��˻���Ϣ">
                                        �˻����ͣ�<%#Eval("BankType").ToString() == "1"?"���п�":Eval("BankType").ToString() == "2"?"΢��":"֧����"%><br />
                                        <%#Eval("BankName")%><br />
                                        <%#Eval("BankAccount")%><br />
                                        <%#Eval("BankAccountUser")%>
                                    </td>
                                    <td data-attr="��ֵ���"><%#Eval("RemitMoney")%></td>
                                    <%--<td data-attr="�����"><%#Eval("Remit006")%></td>--%>
                                    <td data-attr="����˻���Ϣ">
                                        �˻����ͣ�<%#Eval("Bank003").ToString() == "1"?"���п�":Eval("Bank003").ToString() == "2"?"΢��":"֧����"%><br />
                                        <%#Eval("PlayBankName")%><br />
                                        <%#Eval("PlayBankAccount")%><br />
                                        <%#Eval("PlayBankAccountUser")%>
                                    </td>
                                 <%--   <td data-attr="��ֵ��"><%#Eval("Remit003")%></td>--%>
                                    <td data-attr="��������"><%#Eval("AddDate")%></td>
                                    <td data-attr="���״̬"><%#StateType(Eval("State").ToString())%></td>
                                    <td data-attr="��������"><%#Eval("PassDate")%></td>
                                    <td data-attr="����">
                                        <asp:LinkButton ID="lbtnVerify" runat="server" CommandArgument='<%# Eval("ID") %>' class="btn btn-success"
                                            iconcls="icon-ok" CommandName="verify" OnClientClick="javascript:return confirm('ȷ����ˣ�')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'><i class="fa fa-pencil"></i>ȷ��</asp:LinkButton>
                                        <a class="btn btn-info viewimg" data-img='<%# Eval("Remit004") %>' style='<%# Eval("Remit004").ToString() == "" ? "display:none;":"" %>'   ><i class="fa fa-eye"></i>�鿴���ƾ֤</a>
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%# Eval("ID") %>' class="btn btn-danger"
                                            iconcls="icon-no" CommandName="Remove" OnClientClick="javascript:return confirm('ȷ��Ҫ������')" Visible='<%#Convert.ToInt32(Eval("State"))==0?true:false%>'><i class="fa fa-pencil"></i>����</asp:LinkButton>
                                        
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr id="tr1" runat="server" class="none" >
                            <td colspan="13" align="center">��Ǹ��Ŀǰ���ݿ�����������ʾ��</td>
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
         <script src="/js/BigPicture.min.js"></script>
        <script>

            (function () {

                function setClickHandler(id, fn) {
                    document.getElementById(id).onclick = fn;
                }

                setClickHandler('image_container', function (e) {
                    e.target.tagName === 'A' && e.target.className === 'btn btn-info viewimg' && BigPicture({
                        el: e.target,
                        imgSrc: $(e.target).data("img")
                    });
                });

            })();
        </script>
    </form>
</body>
</html>
