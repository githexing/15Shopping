<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoktSet.aspx.cs" Inherits="Web.admin.system.ScoktSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link rel="stylesheet" type="text/css" href="../css/style.css" />
     <script type="text/javascript" src="/JS/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="/JS/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/js/superValidator.js"></script>
    <script src="/Scripts/main-layout.js" type="text/javascript"></script>
    <style type="text/css">
        .red {
            color: Red;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="mainwrapper" style="top: 0px; background-color: #E8E8FF">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">新增</h4>
                </div>
                <div class="panel-body">
                    <form class="form-inline" action="#">
                        <div class="mb15">
                            <div class="form-group mt10">
                                <label class="control-label">占座回调地址:</label>
                                <input id="city" type="text" runat="server" class="form-control" size="20" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">出票回调地址:</label>
                                <input id="textName" type="text" runat="server" class="form-control" size="20" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">退款回调地址:</label>
                                <input id="textCode" type="text" runat="server" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                <label class="control-label">公司名称:</label>
                                <input id="text1" type="text" runat="server" class="form-control" />
                            </div>
                            <div class="form-group mt10">
                                 <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-success mr5" iconcls="icon-ok" OnClick="LinkButton2_Click"><i class="fa fa-check"></i>提交回调地址 </asp:LinkButton>
                                <a class="btn btn-success mr5" id="train" onclick="onupdate()"><i class="fa fa-check"></i> 手动推送地址 </a>
                            </div>
                        </div>
                    </form>
                </div>
                <!-- panel-body -->
            </div>
            </div>
         <script type="text/javascript">
            function onupdate() {
                $.ajax({
                    url: "/APPService/TrainTickets.ashx?act=setpush&submit_callback=" + $("#city").val() + "&pay_callback=" + $("#textName").val() + "&refund_callback=" + $("#textCode").val() + "&name=" + $("#text1").val(),
                    type: 'post',
                    dataType: 'json',
                    success: function (data) {
                        if (data.state == "success") {
                            alert("提交成功");
                        } else {
                            alert(data.message);
                        }
                    },
                    error: function () {
                        alert("提交异常！");
                    }
                })
            }
        </script>
    </form>
</body>
</html>
