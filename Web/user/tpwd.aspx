<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tpwd.aspx.cs" Inherits="Web.user.tpwd" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>三级密码</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <link rel="stylesheet" type="text/css" href="../css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/animate.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container row-fluid">
            <!-- BEGIN PAGE CONTAINER-->
            <div class="page-content">
                <div class="content">
                    <div class="page-title">
                        <h3><%=GetLanguage("ThreePassword")%><%--三级密码--%></h3>
                    </div>
                    <div id="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="grid simple">
                                    <div class="grid-title no-border">
                                        <h4>输入密码</h4>
                                    </div>
                                    <div class="grid-body no-border">
                                        <div class="form-horizontal col-sm-12">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label"><%=GetLanguage("PleaseThreePassword")%><%--请输入三级密码--%></label>
                                                <div class="col-md-10">
                                                    <input name="txtSecondPassword" id="txtSecondPassword" class="form-control" runat="server" maxlength="20" onkeydown="if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('ImageButton1').click();return false;}} else {return true}; " type="password" />
                                                </div>
                                            </div>
                                            <div class="form-group m-b-0">
                                                <div class="col-sm-offset-2 col-sm-10">
                                                    <asp:Button ID="btnOK" runat="server" class="btn btn-primary" OnClick="btnOK_Click"/>
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
    </form>
</body>
</html>

