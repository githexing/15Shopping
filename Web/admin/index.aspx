<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=getParamVarchar("SystemName1")%></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
<%--    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>--%>
<%--    <script type="text/javascript" src="../js/cuntom.js"></script>
    <script src="Scripts/main-layout.js" type="text/javascript"></script>--%>
<%--    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript">
        $(function () {

            //$("#codeImage").attr("src", "/CheckCode.aspx?_t=" + new Date().valueOf());
            var winH = $(window).height();
            var winw = $(window).width();
            alert(winH);
            $("#main-panel").css({ "height": winH + "px" });

        });

    </script>--%>
</head>
<body class="easyui-layout" style="background-color: #E8E8FF">
    <!--头部s-->
    <header>
			<div class="headerwrapper">
				<div class="header-left">
					<a href="#" class="logo">
						<img src="../images/logo.png" alt="" style="height:40px;" />
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
								<span class="user-name"><%=strUserName %></span>
								<i class="fa fa-caret-down"></i>
                            </button>
							<ul class="dropdown-menu pull-right" role="menu">
								<li>
									<a href="../manageloginout.aspx"><i class="glyphicon glyphicon-log-out"></i>退出系统</a>
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
						<a class="pull-left profile-thumb" href="#">
							<img class="img-circle" src="images/profile.png" alt="" />
						</a>
						<div class="media-body">
							<h4 class="media-heading"><%=strUserName %></h4>
						<%--	<span class="user-options"><a href="#"><i class="glyphicon glyphicon-user"></i></a>
                              <a href="#"><i class="glyphicon glyphicon-log-out"></i></a>
							</span>--%>
						</div>
					</div>
					<!-- media -->
  <!--头部e-->

  <!--导航s-->
   <ul class="nav nav-pills nav-stacked">
       <li><a href="index.aspx"><i class="fa fa-home"></i> <span>首页</span></a></li>

            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <li class="parent">
                        <a href="javascript:;"><i class="fa fa-home"></i> <span><%#Eval("menuname") %></span></a>
                        <ul class="children">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a class="h30" href='<%#Eval("URL") %>' target="list">
                                        <%#Eval("menuname") %></a></li>
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
<!-- contentpanel start-->
  <!--导航e-->
   
  <!--中间内容s MY.document.body.scrollHeight < 560 ? 675 : MY.document.body.scrollHeight;-->
    <div id="main-panel" region="center" style="background: #eee; overflow-y:hidden">
        <div id="tabs" class="easyui-tabs"  fit="true" border="false" >
			<div title="首页" style="padding:20px;overflow:hidden; color:red; "  >
				<iframe scrolling="auto" id="MY" name="list" frameborder="0" src="zhuye.aspx" 
                      style="width: 100%;     min-height: calc(100vh - 85px);" ></iframe>
			</div>
		</div>
    </div>
                   
    <!--中间内容e-->
  </div>
            </div><!-- mainwrapper -->
        </section>
    <!--版权-->
    <%--<div class="index_footer"> CopyRight@2010-2012 QDCCAP 版权所有AllRirghtReservice </div>--%>
    <%-- START right menu --%>
   
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
