<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="help.aspx.cs" Inherits="Web.user.help" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title></title>
		<link rel="stylesheet" type="text/css" href="/css/newsstyle.css"/>
		<script src="/js/flexible.js" type="text/javascript" charset="utf-8"></script>
		<script src="/js/jquery.min.js" type="text/javascript" charset="utf-8"></script>
	</head>
	<body>
		<%--<h2 class="new_title"><asp:Literal ID="ltTitle" runat="server"></asp:Literal></h2>--%>
		<div class="new_content">
			<p><asp:Literal ID="ltContent" runat="server"></asp:Literal></p>
			

		</div>
	</body>
</html>
