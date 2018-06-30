<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="Remit.aspx.cs" Inherits="Web.user.finance.Remit" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script type="text/javascript" src="/Js/My97DatePicker/WdatePicker.js"></script>
        <script src="/js/jquery.form.js" type="text/javascript"></script>
    <style>
        .controls {
            position: relative;
        }

        .selectimage {
            position: absolute;
            width: 84px !important;
            height: 34px !important;
            padding: 0 !important;
            left: 0;
            top: 0;
            opacity: 0;
            cursor: pointer;
            box-sizing: border-box;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="content">
        <div class="container">
            <div class="row m-b-20">
                <div class="col-md-12">
                    <div class="card-box">
                        <div class="grid-title">
                            <h4>充值报单积分</h4>
                        </div>
                        <div class="row">
                            <div class="form-horizontal col-sm-12">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">汇入账户：</label>
                                        <div class="col-md-10">
                                              <asp:DropDownList ID="dropBank" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropBank_SelectedIndexChanged"></asp:DropDownList>  
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">汇入账号：</label>
                                        <div class="col-md-10">
                                           <asp:Label ID="lblBankAccount" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">开户名：</label>
                                        <div class="col-md-10">
                                             <asp:Label ID="lblBankAccountUser" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">汇款金额：</label>
                                        <div class="col-md-10">
                                            <input name="jd" type="text" id="txtMoney" runat="server" onkeydown="if(event.keyCode==13)event.keyCode=9"
                                                onkeypress="if ((event.keyCode<48 || event.keyCode>57 ) && event.keyCode!=46) event.returnValue=false;"
                                                class="form-control" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">汇款具体时间：</label>
                                        <div class="col-md-10">
                                              <asp:TextBox ID="txtTime" runat="server" class="form-control" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">汇出账户：</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList ID="dropOutAccount" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="dropOutAccount_SelectedIndexChanged"  ></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group"  id="divOutAccount" runat="server" >
                                        <label class="col-md-2 control-label"><asp:Label ID="lblOutAccountTitle" runat="server">汇出账号</asp:Label>：</label>
                                        <div class="col-md-10">
                                            <asp:Label ID="lblOutAccount" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group" id="divOutQrCode"  runat="server" style="display:none">
                                        <label class="col-md-2 control-label"><asp:Label ID="lblOutQRCodeTitle" runat="server">二维码</asp:Label>：</label>
                                        <div class="col-md-10">
                                           <asp:Image ID="imgOutQRCode" runat="server" ImageUrl="" /> 
                                        </div>
                                    </div>
                                     <div class="form-group" id="divOutName"  runat="server" style="display:none">
                                        <label class="col-md-2 control-label"><asp:Label ID="lblOutNameTitle" runat="server">昵称</asp:Label>：</label>
                                        <div class="col-md-10">
                                            <asp:Label ID="lblOutName" runat="server" ></asp:Label>  
                                        </div>
                                    </div>
                                 </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="form-group" style="display:none">
                                    <label class="col-md-2 control-label">充值码：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtRemitCode" type="text" runat="server" class="form-control" readonly MaxLength="60"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label"><%=GetLanguage("UploadVoucher") %><!--上传凭证-->：<span class="required">&nbsp;</span>
                                    </label>
                                     <div class="col-md-10">
                                    <span class="file-input has-error">
                                        <div class="file-preview">
                                            <div class="file-drop-zone clearfix">
                                                <div class="file-preview-frame">
                                                            
                                                    <img id="previewImage" src="/images/uploadfile.png" style="min-width: 160px; max-height: 120px;" alt="暂无图片" />
                                                    <input type="hidden" id="hiddenupimage" name="hiddenupimage" value="" />
                                                </div>
                                            </div>
                                        </div>
                                    </span>
                                         </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-10" id="upload">
                                      
                                        <div  class="controls input-icon" >
                                            <a class="btn btn-primary"><%=GetLanguage("Selectpicture") %></a>
                                            <input type="file" id="selectImage3" name="selectImage3" class="btn selectimage" />
                                            <input type="button" id="uploadImage" name="uploadImage" value='<%=GetLanguage("upload") %>' class="file btn btn-primary" style="display:none;" />
                                        </div>
                                    </div>
                               </div>
                                       
                                <div class="form-group">
                                    <label class="col-md-2 control-label">汇款备注：</label>
                                    <div class="col-md-10">
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtRemark" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSubmit" runat="server" Style="margin: 0px;" Text="提 交" class="btn btn-custom " OnClick="btnSubmit_Click" OnClientClick="javascript:return confirm('确定要充值吗？')" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                              <%--  <asp:Button ID="btnReset" runat="server" Style="margin: 0px;" Text="重 置" class="btn" OnClick="btnReset_Click" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box">
                                <h4 class="header-title m-t-0 m-b-30">
                                    <!--查询-->
                                    <%=GetLanguage("Query") %></h4>
                                <div class="row">
                                    <div class="form-inline col-sm-12">

                                        <div class="form-group">
                                            <label><%=GetLanguage("DateTransfer") %><!--转账日期--></label>
                                            <div class="input-daterange input-group" id="date-range">
                                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                                    {%>
                                                <asp:TextBox ID="txtStart" runat="server" class="form-control" name="start" onfocus="WdatePicker()"></asp:TextBox>
                                                <%}
                                                    else
                                                    {%>
                                                <asp:TextBox ID="txtStartEn" runat="server" class="form-control" name="start" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                                <%} %>
                                                <span class="input-group-addon bg-inverse b-0 text-white"><%=GetLanguage("To")%><!--至--></span>
                                                <%if (GetLanguage("LoginLable") == "zh-cn")
                                                    {%>
                                                <asp:TextBox ID="txtEnd" runat="server" class="form-control" name="end" onfocus="WdatePicker()"></asp:TextBox>
                                                <%}
                                                    else
                                                    {%>
                                                <asp:TextBox ID="txtEndEn" runat="server" class="form-control" name="end" onfocus="WdatePicker({lang:'en'})"></asp:TextBox>
                                                <%} %>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-md" OnClick="btnSearch_Click" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-merge table-responsive">

                                            <table class="table table-condensed m-0">
                                                <tr>
                                                    <th align="center">收款账户信息
                                                    </th>
                                                    <th align="center">汇款金额
                                                    </th>
                                                    <th align="center">汇款具体时间
                                                    </th>
                                                    <th align="center">打款账户信息
                                                    </th>
                                                    <th align="center">汇款备注
                                                    </th>
                                                    <th align="center">申请日期
                                                    </th>
                                                      <th align="center">充值码
                                                    </th>
                                                    <th align="center">状态
                                                    </th>
                                                </tr>
                                                <asp:Repeater ID="rpTake" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td data-attr="收款账户信息">
                                                                账户类型：<%#Eval("BankType").ToString() == "1"?"银行卡":Eval("BankType").ToString() == "2"?"微信":"支付宝"%><br />
                                                                <%#Eval("BankName")%><br />
                                                                <%#Eval("BankAccount")%><br />
                                                                <%#Eval("BankAccountUser")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("RemitMoney")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("RechargeableDate")%>
                                                            </td>
                                                            <td data-attr="打款账户信息">
                                                                账户类型：<%#Eval("Bank003").ToString() == "1"?"银行卡":Eval("Bank003").ToString() == "2"?"微信":"支付宝"%><br />
                                                                <%#Eval("PlayBankName")%><br />
                                                                <%#Eval("PlayBankAccount")%><br />
                                                                <%#Eval("PlayBankAccountUser")%>
                                                            </td>
                                                            
                                                            <td>
                                                                <%#Eval("Remark")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("AddDate")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Remit003")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("State").ToString() == "0" ?"未审" : "已审"%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr>
                                                    <td colspan="7">
                                                        <div id="divno" runat="server" class="NoData">
                                                            <span class="cBlack">
                                                                <img src="../../images/ico_NoDate.gif" width="16" height="16" alt="" />
                                                                <%=GetLanguage("Manager")%></span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="text-right">

                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList"
                                                    NumericButtonCount="3" PageSize="12"
                                                    ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                                                    OnPageChanged="AspNetPager1_PageChanged">
                                                </webdiyer:AspNetPager>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <script>
          $("#uploadImage").click(function () {
              console.log("上传的图片");
              if ($('#selectImage3').val().length <= 0) {
                  alert('请选择上传的图片');
                  return;
              }
              $("#aspnetForm").ajaxSubmit({
                  url: '/Handle/UploadImage.ashx',
                  beforeSubmit: function () {
                      //$("#upload").append(wait);
                      $("#upload img").css("display", "inline");
                  },
                  success: function (data) {
                      $("#upload img").fadeOut(2000);
                      if (data != "上传失败") {
                          $("#previewImage").attr("src", "/upload/" + data).hide().fadeIn(2000);
                          $('#hiddenupimage').val("/upload/" + data);
                      }
                      else {
                          alert("上传失败");
                      }
                  },
                  error: function (ex) {
                      alert(ex.msg);
                  }
              });
          });
          $('#selectImage3').change(function () {
              $("#uploadImage").click();
          });

    </script>
</asp:content>
