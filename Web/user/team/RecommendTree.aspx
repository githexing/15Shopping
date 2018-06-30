<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/user/index.Master" CodeBehind="RecommendTree.aspx.cs" Inherits="Web.user.team.RecommendTree" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

     
 
        <!-- Start content -->
        <div class="content">
            <div class="container">

                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("ThisFigure")%><%--直接推荐图--%></h4>
                            <div id="basicTree">
                                <ul id="red">

                                    <li data-jstree='{"opened":true}'></li>
                                </ul>

                                <input id="uid" class="userid" type="hidden" runat="server" />
                                <input id="tage" class="tage" type="hidden" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End row -->

            </div>
            <!-- container -->

        </div>
        <!-- content -->

       <script type="text/javascript" src="/js/Scripts/jstree.min.js"></script>
   <script type="text/javascript" src="/js/RecommendTree.js?1"></script>

 
</asp:Content>
