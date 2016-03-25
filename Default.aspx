<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_Default.css" rel="stylesheet" />
    <link rel="stylesheet" href="Css/Css_login.css" media="all" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/font-awesome.min.css" rel="stylesheet" />
    <script src="Js/bootstrap.min.js"></script>
    <script>
        var i = 0;
        var animCode = 0;
        var step = 4;
        var max_height = 180;
        function scrollVal() {
            return $(window).scrollTop();
        }
        $(window).ready(function () {
            $("#J-login input[type!='submit']").click(function () {
                if (scrollVal() < max_height)
                    animCode = setInterval(slide, 1);
            });
        });
        function slide() {
            i = scrollVal();
            if (i >= max_height)
                clearInterval(animCode);
            $(window).scrollTop(i += step);
        }
        //密码安全等级计算
        function getPasswordSecurityLevel(password) {
            return 0
            //密码长度大于5位
            + (password.length > 5)
            //密码含有字母
            + (/[a-z]/.test(password) && /[A-Z]/.test(password))
            //密码含有字母和数字
            + (/\d/.test(password) && /\D/.test(password))
            //密码含有特殊字符
            + (/[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/.test(password) && /\w/.test(password))
            //密码长度大于12位
            + (password.length > 12);

        }

    </script>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">


    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="z-index: 0;">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="img/slider1.png" alt="..." />
                <div class="carousel-caption">
                </div>
            </div>
            <div class="item">
                <img src="img/slider2.png" alt="..." />
                <div class="carousel-caption">
                </div>
            </div>
            <div class="item">
                <img src="img/slider3.png" alt="..." />
                <div class="carousel-caption">
                </div>
            </div>
        </div>
        <asp:Panel ID="login_panel" runat="server" Style="width: auto; height: auto;">
            <div class="login login-modern" id="J-login" style="position: absolute; top: 25px; left: 850px; z-index: 9999">
                <form autocomplete="off" name="loginForm" id="login" action="Default.aspx" method="post" class="ui-form" runat="server">
                    <h2 class='ui-form-title ' id="J-login-title">登录积分宝</h2>
                    <div class="ui-form-item" id="J-username">
                        <label id="J-label-user" class="ui-label">
                            <span class="ui-icon ui-icon-userDEF">账户名：</span>
                        </label>
                        <asp:TextBox CssClass="ui-input ui-input-normal" ID="username" runat="server" TabIndex="1" MaxLength="100" placeholder="用户名"></asp:TextBox>
                        <%--<input type="text" id="J-input-user" class="ui-input ui-input-normal" name="logonId"  tabindex="1" value="" maxlength="100" placeholder="邮箱地址/手机号码">--%>
                    </div>
                    <!--用户名-->
                    <div class="ui-form-item ui-form-item-20pd" id="J-password">
                        <label id="J-label-editer" class="ui-label" data-desc="登录密码">
                            <span class="ui-icon ui-icon-securityON" id="safeSignCheck">登录密码</span>
                        </label>
                        <span class="standardPwdContainer">
                            <asp:TextBox CssClass="ui-input" TabIndex="2" ID="password" placeholder="密码" TextMode="Password" runat="server" oncontextmenu="return false" onpaste="return false" oncopy="return false" oncut="return false" autocomplete="off"></asp:TextBox>
                            <%--<input type="password" tabindex="2" id="password_input" name="password_input" class="ui-input" oncontextmenu="return false" onpaste="return false" oncopy="return false" oncut="return false" autocomplete="off" />--%>
                        </span>
                    </div>
                    <!--密码-->
                    <div id="J-checkcode" class='ui-form-item '>
                        <label id="J-label-checkcode" class="ui-label">
                            <span class="ui-icon ui-icon-checkcodeT" id="J-switchCheckcode">校验码</span>
                        </label>
                        <asp:TextBox ID="vcode" placeholder="验证码" CssClass="ui-input ui-input-checkcode" runat="server" data-type="IMAGE" MaxLength="4" name="checkCode" autocomplete="off" TabIndex="3" data=""></asp:TextBox>
                        <%--<input type="text" placeholder="验证码" value="" class="ui-input ui-input-checkcode" id="J-input-checkcode" data-type="IMAGE" maxlength="4" name="checkCode" autocomplete="off" tabindex="3" data=""/>--%>
                        <span class="sl-checkcode" id="J-checkcodeIcon"></span>
                        <div class="ui-checkcode">
                            <img class="ui-checkcode-img" style="float: left; z-index: 10" id="J-checkcode-img" src="Vcode.ashx" title="点击图片刷新验证码" alt="点击图片刷新验证码" />
                        </div>
                    </div>
                    <!--验证码-->
                    <div class="ui-form-item ui-form-item-30pd" id="J-submit">
                        <asp:Button ID="btn_submit" runat="server" Text="登 录" CssClass="ui-button" TabIndex="4" OnClick="login_Click" />
                        <%--<input type="submit" value="登 录" class="ui-button" id="J-login-btn" tabindex="4"/>--%>
                        <p class="ui-form-other">
                            <!--<a href="https://login.taobao.com/member/login.jhtml?style=alipay&amp;goto=https%3A%2F%2Flab.alipay.com%2Fuser%2Fnavigate.htm%3Fsign_from%3D3000" class="textlink" title="淘宝会员登录" tabindex="6" target="_blank">淘宝会员登录</a>
                        <a href="https://lab.alipay.com/user/reg/index.htm" class="textlink textlink-ml20" title="账户激活" tabindex="7" target="_blank">账户激活</a>-->
                            <a class="register" href="Register.aspx" target="_blank" title="免费注册" tabindex="8">免费注册</a>
                        </p>
                    </div>
                    <!-- //submit -->
                </form>
            </div>
        </asp:Panel>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>

    <%--    <div id="d_login">
        <img src="img/Slider.png" width="100%" />

       
    </div>--%>
    <%--    <div style="padding:0;">
        <img src="img/Slider.png" width="100%" style="opacity: 0; z-index: -100;position:relative;margin:0;" />
    </div>--%>
    <%-- <div class="screen">
        <img src="img/OS_X_10.png" />
        <ul style="display: block; box-sizing: border-box; margin: 0 auto; width: 1200px;">
            <li>
                <ul class="line">
                    <li>
                        <div class="tile yellow">
                            <div class="img bg-msg"></div>
                            <div class="content">
                                <h4>交易通知</h4>
                                <span>告诉您最新的交易动态!</span>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="tile blue">
                            <div class="img bg-pay"></div>
                            <div class="content">
                                <h4>积分购买</h4>
                                <span>简单获取,方便使用!</span>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="tile gray">
                            <div class="img bg-manage"></div>
                            <div class="content">
                                <h4>交易记录</h4>
                                <span>悉心照顾您的每一笔交易!</span>
                            </div>
                        </div>
                    </li>
                </ul>
            </li>
            <li>
                <ul class="line">
                    <li>
                        <div class="tile deepgray">
                            <div class="img bg-add"></div>
                            <div class="content">
                                <h4>添加交易</h4>
                                <span>没有合适的交易,没关系!</span>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="tile red">
                            <div class="img bg-chart"></div>
                            <div class="content">
                                <h4>交易统计</h4>
                                <span>纵观全局,就是如此简单!</span>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="tile green">
                            <div class="img bg-person"></div>
                            <div class="content">
                                <h4>账户管理</h4>
                                <span>我的积分宝,我做主!</span>
                            </div>
                        </div>
                    </li>
                </ul>
            </li>
        </ul>
        <div style="clear: both;"></div>
        <div style="margin-top: 30px; height: 5px; background-color: #0094ff; width: 100%;"></div>
    </div>--%>

    <div style="width: 100%; background-color: #EBEBEB;box-shadow:#303030 0 10px 10px;">
        <div class="main-bottom">
            <div class="divline">
                <div>
                    <div class="main-font jfjy-rcjd">
                    </div>
                    <div>
                        <ul class="item-list">
                            <li><a href="Trade.aspx">立即交易</a></li>
                            <li><a href="NewTrade.aspx">发布积分交易</a></li>
                            <li><a href="TradingRecord.aspx">查看交易记录</a></li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                    <div class="new-tip">
                        <div class="icon-new" style="margin-top: 3px; margin-right: 5px;"></div>
                        <a>交易送积分,先到先得</a>
                    </div>
                </div>
                <div>
                    <div  class="main-font myjf-qsgm">
                    </div>
                    <div>
                        <ul class="item-list">
                            <li><a href="Buy.aspx">我要购买</a></li>
                            <li><a href="Buy.aspx">查看购买流程</a></li>
                            <li><a href="TradingRecord.aspx">我的购买记录</a></li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                    <div class="new-tip">
                        <div class="icon-new" style="margin-top: 3px; margin-right: 5px;"></div>
                        <a>限时打折,总有你想要的</a>
                    </div>
                </div>
                <div class="lase-item">
                    <div  class="main-font yjyh-zjbn">
                    </div>
                    <div>
                        <ul class="item-list">
                            <li><a href="Credit.aspx">开始借贷</a></li>
                            <li><a href="Credit.aspx">借贷须知</a></li>
                            <li><a href="TradingRecord.aspx">积分借贷记录</a></li>
                        </ul>
                    </div>
                    <div class="clear"></div>
                    <div class="new-tip">
                        <div class="icon-new" style="margin-top: 3px; margin-right: 5px;"></div>
                        <a>限量借贷0利率,快快行动吧</a>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
            <div style="height: 0px; border-top: 1px solid #E6E6E6; margin-top: 20px;"></div>
            <div class="divline">
                <div>
                    <table>
                        <tr>
                            <td>
                                <div class="icon-lightbulb" style="font-size: 35pt; margin-right: 20px;"></div>
                            </td>
                            <td>
                                <div   class="main-font rsjfb">
                                    
                                </div>
                                <div>
                                    <ul class="item-list">
                                        <li><a>什么是积分宝</a></li>
                                        <li><a>官方微信</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>

                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <div class="icon-magic" style="font-size: 35pt; margin-right: 20px;"></div>
                            </td>
                            <td>
                                <div   class="main-font zxdt">
                                    
                                </div>
                                <div>
                                    <ul class="item-list">
                                        <li><a>购买优惠</a></li>
                                        <li><a>积分大放送</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>

                </div>
                <div class="lase-item">
                    <table>
                        <tr>
                            <td>
                                <div class="icon-book" style="font-size: 35pt; margin-right: 20px;"></div>
                            </td>
                            <td>
                                <div   class="main-font fzxhjfb">
                                </div>
                                <div>
                                    <ul class="item-list">
                                        <li><a>新手须知</a></li>
                                        <li><a>我要加入积分宝</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>

                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>

        <div class="clear"></div>
        <div style="height: 2px; background-color: #009aff; width: 100%;">
        </div>
    </div>



    <script>
        <%=logmsg%>
    </script>
</asp:Content>

