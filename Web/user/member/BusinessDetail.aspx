<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessDetail.aspx.cs" Inherits="web.user.member.BusinessDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <style type="text/css">
   body
   {
   margin:0px;
   padding:0px;
       }
   .nr1
   {
    height: 32px;
	width: 100%;
	background-image: url(../../images/z_r_1_16.jpg);
	background-repeat: repeat-x;
	background-position: left top;   
	margin:0px;
	padding:0px;
       }
    .nr2_1 {
	height: 20px;
	margin-left: 10px;
	border-bottom-width: thin;
	border-bottom-style: dotted;
	border-bottom-color: #CCC;
	background-image: url(../images/z_r_2_19.jpg);
	background-repeat: no-repeat;
	background-position: left center;
	font-family: "宋体";
	font-size: 12px;
	line-height: 20px;
	color: #666;
	text-decoration: none;
	text-align: left;
	text-indent: 10px;
	width: 100%;
}
.nr2_1 a {
	color: #333;
	text-decoration: none;
	font-size: 12px;
}
.backbtn  /*返回按钮样式*/
{
    background:url(../../images/fan_btn_03.jpg); border:0; width:72px; height:26px;
}

   </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="nr1"></div>
  
  
  
    <div class="wznrx">
        <div style="text-align:center;font-size:20px;font-family:黑体;font-size:16px;margin-top:10px;margin-bottom:10px;">
              <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
         </div> 
         <div style="text-align:center">        
                  <span style="font-size:12px;font-family:宋体;">发布者：<asp:Label ID="lblAuthor" runat="server" Text="" ></asp:Label> 时间:<asp:Label ID="lblDate" runat="server" Text=""></asp:Label></span>
        </div>
              <div style="margin-left:20px;">
              
              <asp:Literal ID="lilContent" runat="server"></asp:Literal>
             </div>
              <!--end contentBox -->
              <div style="text-align:center"> 
                  <asp:Button ID="Button1" runat="server" PostBackUrl="NoticeList.aspx" 
                      CssClass="backbtn"/>
              </div>
    <!--end data 表格数据--> 
      </div>
    
    
    </div>
    </form>
</body>
</html>
