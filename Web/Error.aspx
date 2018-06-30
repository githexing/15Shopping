<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web.Error" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>错误</title>
      <link href="css/indexcss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
    <div class="box">
<div class="capositon">当前位置：系统>><a href="javascript:void(0)">错误</a></div>
     
    <div class="dataTable">
        <span style=" color:Red; font-size:25px; padding-left:50px;"><%=message %></span>
        </div>
</div>
    </form>
</body>
</html>

