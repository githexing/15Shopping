<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XLH.aspx.cs" Inherits="Web.admin.team.XLH" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>生成序列号</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link rel="stylesheet" type="text/css" href="../../css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/style.css" />
</head>
<body> 
    <form id="Form1" runat="server"> 

         <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">生成序列号</h4>
                </div>
                <div class="panel-body"> 
                        <div class="mb15">  
                            <div class="form-group mt10" >
                                <label class="control-label">会员编号:</label>
                           <%--     <div class="form-control nopadding noborder">--%>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                               <%-- </div>--%>
                            </div>
                        </div>
                          <div class="mb15">  
                            <div class="form-group mt10" >
                                <label class="control-label">序列号:</label>
                        <%--        <div class="form-control nopadding noborder">--%>
                                    <asp:Literal ID="LiteralAgent" runat="server"></asp:Literal>
                                <%--</div>--%>
                            </div>
                        </div> 
                        <div class="mb15">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-primary mr5"
                                    iconcls="icon-search" OnClick="btnSearch_Click"><i class="fa fa-search"></i>生成序列号</asp:LinkButton>
                               
                            </div>
                        </div>
                   
                </div>
                <!-- panel-body -->
            </div> 
    </form>
</body>
</html>
