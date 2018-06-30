<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scale.aspx.cs" Inherits="Web.admin.finance.Scale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拨出比例</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../style/jquery-ui-1.10.3.css" />
    <script type="text/javascript" src="../../JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Scripts/Common.js"></script>
    <script type="text/javascript" language="javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Scripts/main-layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="row row-stat">
                <div class="col-md-4">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-globe"><i class="fa fa-dollar"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><%= AllIn%></h1>
                                <h5 class="md-title nomargin">总收入</h5>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-envelope"><i class="fa fa-fire"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><%= AllOut%></h1>
                                <h5 class="md-title nomargin">总支出</h5>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel noborder">
                        <div class="panel-heading noborder">
                            <div class="panel-icon icon-gavel"><i class="fa fa-retweet"></i></div>
                            <div class="media-body">
                                <h1 class="mt5"><%= AllScale%></h1>
                                <h5 class="md-title nomargin">拨出比</h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">拨出比例查询</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">转账日期:</label>
                                <asp:TextBox ID="txtChuStar" tip="输入转账日期" runat="server" onfocus="WdatePicker()" class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="form-group mt10">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-primary mr5" iconcls="icon-search"
                                    OnClick="btnChuSearch_Click"><i class="fa fa-search"></i> 搜 索 </asp:LinkButton>
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
                                <th style="min-width: 80px;">收入</th>
                                <th style="min-width: 80px;">支出</th>
                                <th style="min-width: 80px;">拨出比</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td data-attr="收入"><%= In%></td>
                                <td data-attr="支出"><%= Out%></td>
                                <td data-attr="拨出比"><%= Scal%></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
