<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="LeaveWordsDetail.aspx.cs" Inherits="web.user.member.LeaveWordsDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12 text-right m-b-10">
                        <a href="javascript:history.go(-1)" class="btn btn-sm btn-default"><i class="fa fa-mail-reply-all"></i>返回</a>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h2 class="text-center">
                                        <asp:Label ID="lblSendTitle" runat="server" Text=""></asp:Label></h2>
                                    <p class="text-center text-muted">发件人：<asp:Label ID="lblSendMember" runat="server" Text=""></asp:Label></p>
                                    <p class="text-center text-muted">发送时间：<asp:Label ID="lblSendDate" runat="server" Text=""></asp:Label></p>
                                    <hr />
                                    <div class="m-t-20">
                                        <p>
                                            回复留言：<asp:Label ID="lblContentError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                        </p>
                                        <p>
                                            <asp:TextBox ID="txtPubContext" runat="server" Height="127px" Width="100%" Style="border: 1px #A4BED4 solid; float: inherit;"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </p>
                                        <asp:Button ID="btnRepeat" runat="server" Text="回 复" OnClientClick="return check()"
                                            OnClick="btnRepeat_Click" class="btn" />
                                        
                                    </div>
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
                                    <h5 class="m-b-20">回复信息</h5>
                                    <div class="clearfix m-b-10">
                                        <div class="pull-left" style="margin-right: 10px;">
                                            <img src="/images/avatar-1.jpg" class="img-circle" width="40" height="40">
                                        </div>
                                        <div class="pull-left">
                                            <div class="reply">
                                                <asp:Label ID="lblSendContent" runat="server" Text=""></asp:Label>
                                            </div>
                                            <!--end reply-->
                                            <div class="managerReply" id="divNull" runat="server">
                                                <p class="cRed">
                                                    目前暂时无回复信息！
                                                </p>
                                            </div>
                                            <asp:Repeater ID="rpReply" runat="server">
                                                <ItemTemplate>
                                                    <div>回复：<%#Eval("UserType").ToString() == "1" ? GetUserCode(Eval("UserID").ToString(), 1) : GetUserCode(Eval("UserID").ToString(), 2)%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("ReTime")%> </div>
                                                    <div><%#Eval("ReContent")%></p></div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <div class="col-sm-12">
                                                  <webdiyer:AspNetPager ID="anpReply" runat="server"    CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" 
                                                  NumericButtonCount="3" PageSize="12"  
                                                ShowNavigationToolTip="True" SubmitButtonClass="pagebutton" UrlPaging="false"   PagingButtonSpacing="0" CurrentPageButtonClass ="active"
                                               OnPageChanged="anpReply_PageChanged">
                                            </webdiyer:AspNetPager>
                                               
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- End row -->

            </div>
            <!-- container -->

        </div>
        <!-- content -->
 
</asp:Content>
