<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfos.aspx.cs" Inherits="Web.admin.team.PersonalInfos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>会员信息</title>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="page-content">
            <div class="content">
                <div class="page-title">
                    <h3><%=GetLanguage("MemberInformation")%><%--会员资料--%></h3>
                </div>
                <div id="container">
                    <div class="row m-b-20">
                        <div class="col-md-12">
                            <div class="tiles">
                                <div class="user-profile">
                                    <div class="user-description-box">
                                        <h4 class="semi-bold no-margin"><%=LoginUser.UserCode %></h4>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <p><i class="fa fa-edit"></i>会员编号：<%=LoginUser.UserCode %></p>
                                            </div>
                                            <div class="col-md-6">
                                                <p>
                                                    <i class="fa fa-star"></i>会员级别：
                                      <%if (Language == "en-us")
                                          { %>
                                                    <%=levelBLL.GetModel(LoginUser.LevelID).level03 %>
                                                    <%}
                                                        else
                                                        { %>
                                                    <%=levelBLL.GetModel(LoginUser.LevelID).LevelName %>
                                                    <%} %>
                                                </p>
                                            </div>
                                            <div class="col-md-6">
                                                <p><i class="fa fa-globe"></i>注册金额 ：<%=LoginUser.RegMoney %>元</p>
                                            </div>
                                            <div class="col-md-6">
                                                <p>
                                                    <i class="fa fa-file-o"></i>报单中心：
                                                    <asp:Literal ID="LiteralAgent" runat="server"></asp:Literal>
                                                </p>
                                            </div>
                                            <div class="col-md-6">
                                                <p>
                                                    <i class="fa fa-sitemap"></i>推荐人编号：
                                                    <asp:Literal ID="LiteralRecommendCode" runat="server"></asp:Literal>
                                                </p>
                                            </div>
                                            <div class="col-md-6">
                                                <p><i class="fa fa-phone"></i>联系电话 ：<asp:Literal ID="LiteralPhoneNum" runat="server"></asp:Literal></p>
                                            </div>
                                            <div class="col-md-6">
                                                <p>
                                                    <i class="fa fa-credit-card"></i>身份证号：
                                                    <asp:Literal ID="LiteralIdenCode" runat="server"></asp:Literal>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="grid simple">
                                <div class="grid-title no-border">
                                    <h4>修改资料</h4>
                                </div>
                                <div class="grid-body no-border">
                                    <div class="form-group">
                                        <label class="form-label">会员姓名</label>
                                        <div class="controls">
                                            <%--<input type="text" class="form-control">--%>
                                            <input name="txtTrueName" type="text" id="txtTrueName" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">联系地址</label>
                                        <div class="controls">
                                            <%--<input type="text" class="form-control" value="">--%>
                                            <input name="txtAddress" type="text" id="txtAddress" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">开户银行</label>
                                        <div class="controls">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <%--<select name="" class="form-control">
                                                        <option value="0">请选择</option>
                                                        <option selected="selected" value="农业银行">农业银行</option>
                                                        <option value="建设银行">建设银行</option>
                                                    </select>--%>
                                                    <asp:DropDownList ID="dropBank" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-6">
                                                    <%--<select name="" class="form-control">
                                                        <option selected="selected" value="0">江西省</option>
                                                        <option value="110000">北京市</option>
                                                        <option value="120000">天津市</option>
                                                        <option value="130000">河北省</option>
                                                        <option value="140000">山西省</option>
                                                        <option value="150000">内蒙古</option>
                                                        <option value="210000">辽宁省</option>
                                                        <option value="220000">吉林省</option>
                                                        <option value="230000">黑龙江省</option>
                                                        <option value="310000">上海市</option>
                                                        <option value="320000">江苏省</option>
                                                        <option value="330000">浙江省</option>
                                                        <option value="340000">安徽省</option>
                                                        <option value="350000">福建省</option>
                                                        <option value="360000">江西省</option>
                                                        <option value="370000">山东省</option>
                                                        <option value="410000">河南省</option>
                                                        <option value="420000">湖北省</option>
                                                        <option value="430000">湖南省</option>
                                                        <option value="440000">广东省</option>
                                                        <option value="450000">广西省</option>
                                                        <option value="460000">海南省</option>
                                                        <option value="500000">重庆市</option>
                                                        <option value="510000">四川省</option>
                                                        <option value="520000">贵州省</option>
                                                        <option value="530000">云南省</option>
                                                        <option value="540000">西藏</option>
                                                        <option value="610000">陕西省</option>
                                                        <option value="620000">甘肃省</option>
                                                        <option value="630000">青海省</option>
                                                        <option value="640000">宁夏</option>
                                                        <option value="650000">新疆</option>
                                                        <option value="710000">台湾省</option>
                                                        <option value="810000">香港</option>
                                                        <option value="820000">澳门</option>
                                                    </select>--%>
                                                    <asp:DropDownList ID="dropProvince" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">银行支行</label>
                                        <div class="controls">
                                             <input name="txtBankBranch" type="text" id="txtBankBranch" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">银行账户</label>
                                        <div class="controls">
                                            <input name="txtBankAccount" type="text" id="txtBankAccount" runat="server" class="form-control" value="" maxlength="19" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">开户姓名	</label>
                                        <div class="controls">
                                            <input name="txtBankAccountUser" type="text" id="txtBankAccountUser" runat="server" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="text-center">
                                        <%--<button type="submit" class=""><i class="fa fa-check"></i>保存</button>--%>
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
        </div>
        <!-- ENG PAGE CONTAINER-->
    </form>
</body>
</html>
