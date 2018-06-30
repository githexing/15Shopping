<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ls.aspx.cs" Inherits="Web.admin.ls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
		<meta name="description" content="">
		<meta name="author" content="">
    <link rel="stylesheet" type="text/css" href="./css/style.css" />

<link rel="stylesheet" type="text/css" href="content/base.css" />
<link rel="stylesheet" type="text/css" href="content/themes/default/easyui.css" />
<link rel="stylesheet" type="text/css" href="content/themes/icon.css" />
<script type="text/javascript" src="scripts/jquery.js"></script>
<script type="text/javascript" src="scripts/jquery.easyui.min.js"></script>
<script type="text/javascript" src="../js/cuntom.js"></script>
<script src="scripts/main-layout.js" type="text/javascript"></script>
<script src="../js/my97datepicker/wdatepicker.js" type="text/javascript"></script>
</head>
<body class="easyui-layout"> 
  <!--头部s-->
    <header>
			<div class="headerwrapper">
				<div class="header-left">
					<a href="index.html" class="logo">
						<img src="images/logo.png" alt="" />
					</a>
					<div class="pull-right">
						<a href="#" class="menu-collapse">
							<i class="fa fa-bars"></i>
						</a>
					</div>
				</div>
				<!-- header-left -->
				<div class="header-right">
					<div class="pull-right">
						<div class="btn-group btn-group-option">
							<button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
								<span class="user-name">Admin</span>
								<i class="fa fa-caret-down"></i>
                            </button>
							<ul class="dropdown-menu pull-right" role="menu">
								<li>
									<a href="#"><i class="glyphicon glyphicon-log-out"></i>退出系统</a>
								</li>
							</ul>
						</div>
						<!-- btn-group -->
					</div>
					<!-- pull-right -->
				</div>
				<!-- header-right -->
			</div>
			<!-- headerwrapper -->
		</header>
		<section>
			<div class="mainwrapper">
				<div class="leftpanel">
					<div class="media profile-left">
						<a class="pull-left profile-thumb" href="profile.html">
							<img class="img-circle" src="images/profile.png" alt="">
						</a>
						<div class="media-body">
							<h4 class="media-heading">Admin</h4>
							<span class="user-options"><a href="#"><i class="glyphicon glyphicon-user"></i></a>
                              <a href="#"><i class="glyphicon glyphicon-log-out"></i></a>
							</span>
						</div>
					</div>

  <%--<div region="north" style=" overflow:hidden;">
   <div class="index_logo">
     <div class="index_logo_top"></div>
     <div class="index_logo_bottom">
      <p><a href="../manageloginout.aspx">[退出系统]</a></p>
      <p>您的级别：</p>
      <p>欢迎 <span></span>登录后台管理</p>
     </div>
   </div>
  </div>--%>
  <!--头部e-->

  <!--导航s-->
   <ul class="nav nav-pills nav-stacked">
       <li><a href="index.html"><i class="fa fa-home"></i> <span>首页</span></a></li>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <li class="parent">
                    <a href="javascript:;"><i class="fa fa-home"></i> <span><%#Eval("menuname") %></span></a>
                    <ul class="children">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href="#" >
                                        <%#Eval("menuname") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        </ul>
                        </li>
                </ItemTemplate>
            </asp:Repeater>
    </ul>
                    </div>
				<!-- leftpanel -->
				<div class="mainpanel">
  <!--导航e-->
   
  <!--中间内容s-->
    <div id="main-panel" region="center" style="background: #eee; overflow-y:hidden">
        <div id="tabs" class="easyui-tabs"  fit="true" border="false" >
			<div title="首页" style="padding:20px;overflow:hidden; color:red; " >
				<iframe scrolling="auto" id="ifr我的工作台" frameborder="0" src="zhuye.aspx" style="width: 100%;
                    height: 100%;"></iframe>
			</div>
		</div>
    </div>
    <!--中间内容e-->
  </div>
  <!--版权-->
  <%--<div class="index_footer"> CopyRight@2010-2012 QDCCAP 版权所有AllRirghtReservice </div>--%>
<%-- START right menu --%>
	<div id="mm" class="easyui-menu" style="width:150px;">
		<div id="mm-tabupdate">刷新</div>
		<div class="menu-sep"></div>
		<div id="mm-tabclose">关闭</div>
		<div id="mm-tabcloseall">全部关闭</div>
		<div id="mm-tabcloseother">除此之外全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-tabcloseright">当前页右侧全部关闭</div>
		<div id="mm-tabcloseleft">当前页左侧全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-exit">退出</div>
	</div>
    <%-- END right menu --%>

    <script src="js/jquery-1.11.1.min.js"></script>
<script src="js/jquery-migrate-1.2.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/modernizr.min.js"></script>
<script src="js/pace.min.js"></script>
<script src="js/retina.min.js"></script>
<script src="js/jquery.cookies.js"></script>
<script src="js/custom.js"></script>
</body>
</html>
