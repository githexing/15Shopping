<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/user/index.Master" CodeBehind="UserBank.aspx.cs" Inherits="Web.user.member.UserBank" %>

<asp:content runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <input type="hidden" class="hduid" value="<%=MyUserID %>"/>
    <div class="content">
        <div class="container">
            <style>
                .uplfile {
                    position: absolute;
                    width: 300px;
                    height: 300px;
                    opacity: 0;
                    cursor: pointer;
                    z-index: 20;
                }

                .thumbimg {
                    width: 300px;
                    height: 300px;
                    overflow: hidden;
                    position: relative;
                    border: 1px solid #eee;
                    z-index: 2;
                }

                    .thumbimg img {
                        width: 100%;
                        height: 100%;
                    }

                    .thumbimg span {
                        position: absolute;
                        right: 0;
                        bottom: 0;
                        font-size: 24px;
                        color: #71b6f9;
                    }

                        .thumbimg span i {
                            vertical-align: middle;
                        }
            </style>
            <div class="row">
			    <div class="col-sm-12">
					<div class="card-box">
                        <h4 class="header-title m-t-0 m-b-30"><%=GetLanguage("UserBank") %></h4>
                        <div class="row form-horizontal">
                        	<div class="col-sm-12">
		                        <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 类型：</label>
		                            <div class="col-sm-10 m-b-5">
		                                <select id="selectbanktype" class="form-control" onchange="onselectbank(this)">
		                                    <option value="0">请选择</option><!--账户类别-->
		                                </select>
		                            </div>
		                         </div>
		                    </div>

                            <div id="divbank">
                        	    <div class="col-sm-12">
		                            <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 开户银行：</label>
		                                <div class="col-sm-5 m-b-5">
		                                    <select id="selectbank" class="form-control">
		                                        <option value="0">请选择</option><!--银行-->
		                                    </select>
		                                </div>
		                                <div class="col-sm-5 m-b-5">
		                                    <select id="selectprovince" class="form-control">
		                                        <option value="0">请选择</option><!--省份-->
		                                    </select>
		                                </div>
		                             </div>
		                        </div>
		                        <div class="col-sm-12">
		                            <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 开户姓名：</label>
		                                <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" value="" id="bankusername">
		                                </div>
		                            </div>
		                        </div>
		                        <div class="col-sm-12">
		                            <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 银行支行：</label>
		                                <div class="col-sm-10 m-b-5">
                                            <input type="text" class="form-control" value="" id="bankbranch">
		                                </div>
		                            </div>
		                        </div>
		                        <div class="col-sm-12">
		                            <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 银行卡号：</label>
		                                <div class="col-sm-10 m-b-5">
		                                    <input type="text" class="form-control" value="" id="bankaccount" onkeyup="value=value.replace(/[^\d]/g,'')"
                                            onafterpaste="this.value=this.value.replace(/[^\d]/g,'') ">
		                                </div>
		                            </div>
		                        </div>
		                       <%-- <div class="col-sm-12">
		                            <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 身份证号：</label>
		                                <div class="col-sm-10 m-b-5">
		                                    <input type="text" class="form-control" value="" id="idcard" onkeyup="value=value.replace(/[^\d]/g,'')"
                                            onafterpaste="this.value=this.value.replace(/[^\d]/g,'') ">
		                                </div>
		                            </div>
		                        </div>--%>
                            </div>
                            <div id="otherpay">
                                <div class="col-sm-12">
                                    <div class="col-sm-12">
		                                <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 二维码图片：</label>
		                                    <div class="col-sm-10 m-b-5">
		                                        <input type="file" id="file" class="uplfile" value="">
											    <div class="thumbimg">
												    <img id="img" />
												    <span><i class="fa fa-cloud-upload"></i></span>
											    </div>
		                                    </div>
		                                </div>
		                            </div>
                                    <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 会员昵称：</label>
                                        <div class="col-sm-10 m-b-5">
		                                    <input type="text" class="form-control" value="" id="wxnickname">
		                                </div>
                                    </div>
                                    <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 会员账户：</label>
                                        <div class="col-sm-10 m-b-5">
		                                    <input type="text" class="form-control" value="" id="wxaccount" onkeyup="value=value.replace(/[^\d]/g,'')">
		                                </div>
                                    </div>
                                </div>
                            </div>
                            <div id="divbagaddress">
                                <div class="col-sm-12">
                                    <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 钱包名称：</label>
                                        <div class="col-sm-10 m-b-5">
		                                    <input type="text" class="form-control" value="" maxlength="50" id="bagname">
		                                </div>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 钱包地址：</label>
                                        <div class="col-sm-10 m-b-5">
		                                    <input type="text" class="form-control" value="" maxlength="50" id="bagaddress">
		                                </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
		                        <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 交易密码：</label>
		                            <div class="col-sm-10 m-b-5">
		                                <input type="password" class="form-control" value="" id="txtpaypwd" autocomplete="off">
		                            </div>
		                        </div>
		                    </div>
                            <%--<div class="col-sm-12">
		                        <div class="form-group"><label class="col-sm-2 control-label"><span class="text-danger">*</span> 手机验证码：</label>
		                            <div class="col-sm-3 m-b-5">
		                                <input type="password" class="form-control" value="" id="phonecode" autocomplete="off">
		                            </div>
		                            <div class="col-sm-1 m-b-5">
		                                <button type="button" class="btn btn-custom waves-effect waves-light">获取验证码</button>
		                            </div>
		                        </div>
		                    </div>--%>
                        </div>
                        <hr />
                        <div class="row">
		                    <div class="form-group m-b-0 m-b-5">
	                            <div class="col-sm-offset-2 col-sm-10">
                                    <a href="javascript:void(0);" class="btn btn-custom waves-effect waves-light" id="asubmit" >提交</a>
	                            </div>
	                        </div>
                        </div>
					</div>
				</div>
            </div>
                
            <div class="row" id="tbdata">
			    <%--<div class="col-lg-2 col-md-6">
                    <div class="card-box">
	                    <img class="img-responsive" width="100%" src="images/avatar-1.jpg" alt="" />
	                    <div class="white-box">
	                        <h5>银行名称</h5>
	                        <h5>银行卡账号</h5>
	                        <a class="btn btn-success btn-rounded waves-effect waves-light" href="#">编辑</a>
	                    </div>
                    </div>
                </div>
				<div class="col-lg-2 col-md-6">
                    <div class="card-box">
	                    <img class="img-responsive" width="100%" src="images/avatar-1.jpg" alt="" />
	                    <div class="white-box">
	                        <h5>微信账号</h5>
	                        <a class="btn btn-success btn-rounded waves-effect waves-light" href="#">编辑</a>
	                    </div>
                    </div>
                </div>--%>
            </div>
                <!-- End row -->

        </div> <!-- container -->

    </div>
    <script src="/JS/jquery.md5.js"></script>
    <script type="text/javascript">
        function onselectbank(obj) {
            var a = obj.value;
            if (a == 1) {
                $("#divbank").show();
                $("#otherpay").hide();
                $("#divbagaddress").hide();
            }
            else if (a == 4) {
                $("#divbagaddress").show();
                $("#divbank").hide();
                $("#otherpay").hide();
            } else {
                $("#divbank").hide();
                $("#otherpay").show();
                $("#divbagaddress").hide();
            }
        }

        function AddTable(data) {
            var html = "";
            $(data).each(function (i)            //解析json
            {
                var c = i+1;
                html += "<div class='col-lg-4 col-md-6'>";
                html += "<div class='card-box'>"
                html += "<img class='img-responsive' width='100%' src='" + this.Pic + "' alt='' />";
                html += "<div class='white-box'>";
                if (this.AccountType == "1") {
                    html += "<h3>类型：银行卡</h3>";
                    html += "<h5>开户银行：" + this.BankName + "</h5>";
                    //var length = this.BankAccount.toString().length;
                    //if (length > 13) {
                    //    var at = this.BankAccount.substring(0, 6);
                    //    var bt = this.BankAccount.substring(length - 4, length - 1);
                    //    html += "<h5>银行账号：" + at + '...' + bt + "</h5>";//前6中...后4
                    //} else
                    {
                        html += "<h5>银行账号：" + this.BankAccount + "</h5>";//前6中...后4
                    }
                }
                //else if (this.AccountType == "2") {
                //    html += "<h3>类型：微信</h3>";
                //    html += "<h5>微信昵称：" + this.BankName + "</h5>";
                //}
                //else if (this.AccountType == "3") {
                //    html += "<h3>类型：支付宝</h3>";
                //    html += "<h5>支付宝账号：" + this.BankAccount + "</h5>";
                //}
                //else if (this.AccountType == "4") {
                //    html += "<h3>类型：数字钱包地址</h3>";
                //    html += "<h5>钱包名称：" + this.BankName + "</h5>";
                //    html += "<h5>钱包地址：" + this.BankAccount + "</h5>";
                //}
                //html += "<a class='btn btn-success btn-rounded waves-effect waves-light' href='javascript:void(0);'>修改</a>";
                html += "<a class='btn btn-success btn-rounded waves-effect waves-light ' name='asd' onclick='asd(" + this.BankID + ")' value='" + this.BankID + "' >删除</a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
            });
            document.getElementById("tbdata").innerHTML = html;
        }

        function asd(a) {
            //alert(a);
            var userid = $(".hduid").val();
            $.ajax({

                url: "/AppService/BankAcount.ashx",
                type: "post",
                data: { act: "CancelBank", userid: userid, bankid: a },
                success: function (result) {
                    var data = eval("(" + result + ")");
                    alert(data.message);
                    window.location = "/user/member/UserBank.aspx";
                }
            }) 
        } 
        $(function () {
            var userid = $(".hduid").val();
            $("#divbank").show();
            $("#otherpay").hide();
            $("#divbagaddress").hide();
            $.ajax({
                url: "/AppService/BankAcount.ashx",
                type: "post",
                data: { act: "banktypelist", userid: userid },
                success: function (result) {
                    var data = eval("(" + result + ")");
                    if (data.state == "success") {
                        var selectbanktype = $("#selectbanktype");
                        $(data.data.list).each(function (i) {
                            //sle.options.add(new Option(this.AccountTypeName, this.AccountType));
                            selectbanktype.append("<option value='" + this.AccountType + "'>" + this.AccountTypeName + "</option>");
                        });
                        var selectbank = $("#selectbank");
                        $(data.data.bankList).each(function (i) {
                            selectbank.append("<option value='" + this.ID + "'>" + this.BankName + "</option>");
                        });
                        var selectprovince = $("#selectprovince");
                        $(data.data.provinceList).each(function (i) {
                            selectprovince.append("<option value='" + this.provinceID + "'>" + this.province + "</option>");
                        });
                        console.log(data.data.userbankList);
                        AddTable(data.data.userbankList);
                    }
                    else {
                        alert(data.message);
                    }
                },
                error: function () {
                    alert("Network anomaly");
                }
            });

            $("#asubmit").click(function () {
                if ($("#txtpaypwd").val() == '') {
                    swal({ title: '支付密码不能为空', text: '', type: 'warning' });
                    return;
                }
                $("#asubmit").attr("disabled", true); 
                $("#asubmit").text("正在提交...");
                var banktype = $("#selectbanktype option:selected").val();
                var phonecode = $("#phonecode").val();
               
                if (banktype == 1) {//银行
                    var bankname = $("#selectbank option:selected").text();//银行名称
                    var province = $("#selectprovince option:selected").text();//省份
                    var bankbranch = $("#bankbranch").val();
                    var bankaccount = $("#bankaccount").val();
                    var bankuser = $("#bankusername").val();
                    var idcard = '';//$("#idcard").val();
                    var paypwd = $.md5($("#txtpaypwd").val());
                    $.ajax({
                        url: "/AppService/BankAcount.ashx",
                        type: "post",
                        data: { act: "addbank", userid: userid, bankname: bankname, bankaccount: bankaccount, bankuser: bankuser, defaults: 0, paypwd: paypwd, fromwhere: "pc" },
                        success: function (result) {
                            var data = eval("(" + result + ")");
                            if (data.state == "success") {
                                $("#txtpaypwd").val('');
                                AddTable(data.data)
                               // swal({ title: '添加成功', text: '', type: 'success' });
                            }
                            alert(data.message);
                        },
                        error: function () {
                            alert("Network anomaly");
                        }
                    })
                } else if (banktype == 2 || banktype == 3) {//微信/支付宝
                    //console.log($('#file')[0].files[0]);
                    var formdata = new FormData();
                    var nickname = $("#wxnickname").val();
                    var wxaccount = $("#wxaccount").val();
                    var paypwd = $.md5($("#txtpaypwd").val());
                    formdata.append("act", "addwxalipay");
                    formdata.append("userid", userid);
                    formdata.append("img", $('#file')[0].files[0]);
                    formdata.append("nickname", nickname);
                    formdata.append("accounts", wxaccount);
                    formdata.append("type", banktype);
                    formdata.append("defaults", 0);
                    $.ajax({
                        url: "/AppService/BankAcount.ashx",
                        type: "post",
                        data: formdata,
                        processData: false,
                        contentType: false,
                        success: function (result) {
                            var data = eval("(" + result + ")");
                            if (data.state == "success") {
                                $("#txtpaypwd").val('');
                                AddTable(data.data)
                            } 
                            alert(data.message);
                        },
                        error: function () {
                            alert("Network anomaly");
                        }
                    })
                }
                else if (banktype == 4) {//钱包地址
                    var formdata = new FormData();
                    var bagname = $("#bagname").val();
                    var bagaddress = $("#bagaddress").val();
                    var paypwd = $.md5($("#txtpaypwd").val());
                    formdata.append("act", "addbagaddress");
                    formdata.append("userid", userid);
                    formdata.append("accountname", bagname);
                    formdata.append("accounts", bagaddress);
                    formdata.append("defaults", 0);
                    $.ajax({
                        url: "/AppService/BankAcount.ashx",
                        type: "post",
                        data: formdata,
                        processData: false,
                        contentType: false,
                        success: function (result) {
                            var data = eval("(" + result + ")");
                            if (data.state == "success") {
                                $("#txtpaypwd").val('');
                                AddTable(data.data)
                            }
                            alert(data.message);
                        },
                        error: function () {
                            alert("Network anomaly");
                        }
                    })
                }
                $("#asubmit").attr("disabled", false); 
                $("#asubmit").text("提交");
            })
        })
    </script>
    <script src = "/js/jquery.uploadimg.js" ></script>
    <script>
        var oUpload = new UploadPic();
        var oImgUp = $("#file");

        oUpload.init({
            input: oImgUp[0],
            callback: function (base64) {
                $("#img").attr('src', base64);
            }
        });
    </script>
</asp:content>
