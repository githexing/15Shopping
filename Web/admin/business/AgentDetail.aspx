<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentDetail.aspx.cs" Inherits="Web.admin.business.AgentDetail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>服务中心信息</title>
    <link href="../../css/indexcss.css" rel="stylesheet" type="text/css" />
    <link href="../../imgbox/imgbox.css" rel="stylesheet" type="text/css" />

    <script src="../../imgbox/jquery.min.js" type="text/javascript"></script>
    <script src="../../imgbox/jquery.imgbox.pack.js" type="text/javascript"></script>
	<style type="text/css">
		#images a {
			margin-right: 14px;
		}

		#images a img {
			border: 1px solid #888;	
			padding: 3px;
			vertical-align: top;
		}

		#credit {
			clear: both;	
			margin-top: 50px;
			padding-top: 20px;
			font-size: 10px;
			border-top: 1px solid #BBB;
			font-family: Verdana;
		}
	</style>
	<script type="text/javascript">
	    $(document).ready(function() {
	        $("#images a").imgbox();
	    });
	</script>
</head>
<body>
    <form id="form1" runat="server" class="box_con">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box box_width">
        <div class="main_dt">
    <h2>
            服务中心信息</h2>
        <div class="operation">
                <fieldset class="fieldset">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t4">
                <tr id="tr1" runat="server" visible="false">
                <td colspan="4" style=" padding-left:120px; color:Red;">您已有申请记录，请等待审核！</td>
                </tr>
                <tr>
                <td align="right" width="200px;">
                *服务中心编号：
                </td>
                <td ><input name="Add_sscFd7" id="txtAgentCode"  class="input_select" runat="server" type="text" />
                </td>
                </tr>
                <tr>
                <td align="right" width="200px;">
                *类型：
                </td>
                <td >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged"
                     RepeatDirection="Horizontal" AutoPostBack="true" >
                    <asp:ListItem Value="1">服务中心</asp:ListItem>
                    <asp:ListItem Value="2">专卖店</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                </tr>
                <tr>
                <td align="right">
                *营业执照号：
                </td>
                <td><input name="Add_sscFd7" id="txtCode"  class="input_select" runat="server" type="text" />
                </td>
                </tr>
                <tr>
                <td align="right">
                </td>
                <td >
                <div id="images" >
        <a id="example1" runat="server" title="" >
        <img id="img2"  width="80"  runat="server"      alt="点击查看原图" />
        </a>
    </div>
                </td>
                </tr>
                <tr id="tr2" runat="server">
                <td align="right">
                </td>
                <td >
                <asp:FileUpload ID="FileUpload1" runat="server"/>&nbsp;
                <asp:Button ID="Button1" runat="server" Text="上 传" class="btn" OnClick="Button1_Click"  />
                </td>
                </tr>
                <div id="Div1" runat="server" visible="false">
                <tr>
                <td align="right">
                *申请县市：
                </td>
                <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="DropDownList4" runat="server"  class="" 
            onselectedindexchanged="DropDownList4_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList><asp:DropDownList ID="DropDownList5" runat="server" class="" >
		<asp:ListItem Value="请选择">请选择</asp:ListItem>
        </asp:DropDownList>
            <input name="jd" type="text" id="txtAddress" runat="server"   class="input_select" />
        </ContentTemplate>
        </asp:UpdatePanel>
                </td>
                </tr>
                </div>
                <tr>
                <td align="right">
                </td>
                <td>
                <asp:Button ID="Button3" runat="server" Text="提 交" class="btn" OnClick="btnSave_Click" />
                </td>
                </tr>
                </table>
                </fieldset>
                </div>
    </div> 
</div>
    </form>
</body>
</html>
