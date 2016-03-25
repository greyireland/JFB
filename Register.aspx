<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Css/bootstrap.min.self.css" rel="stylesheet" />
    <link href="Css/Css_Ordinary.css" rel="stylesheet" />
    <link href="Css/Css_Master.css" rel="stylesheet" />
    <link href="Css/CSS_Register.css" rel="stylesheet" />
    <script src="Js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Js/Js_Register.js" type="text/javascript"></script>
    <script src="Js/sco.valid.js"></script>
    <script src="Js/bootstrap.min.js"></script>
    <title></title>
    <%--<script>
        $(window).ready(function () {
            $("#sub").click(function () {
                $("#form").submit();
            });
        });
    </script>--%>
    <%--    <script>
        function aaa() {
            $.ajaxFileUpload
        (
            {
                url: 'TempHImg.ashx',
                secureuri: false,
                fileElementId: 'headfile',
                dataType: 'content',
                beforeSend: function () {
                },
                complete: function () {
                },
                success: function (data, status) {
                    var start = data.indexOf(">");
                    if (start != -1) {
                        var end = data.indexOf("<", start + 1);
                        if (end != -1) {
                            data = data.substring(start + 1, end);
                        }
                    }
                    $("#headimg").attr({ "src": data });
                },
                error: function (data, status, e) {
                    alert(e);
                }
            }
        )
            return false;
        }
    </script>--%>


    <script>



        function OnSubmit() {
            if ($("#username").val() == "") {
            }
            return false;
        }
    </script>
</head>
<body class="body-color">
    <div class="reg-head">
        <div class="logo"><%--积分宝--%></div>
        <div class="option">
            <ul class="ui-link fn-clear">
                <li class="ui-link-item list-item">
                    <%if (Session["username"] != null)
                          Response.Write(string.Format("<a href=\"{0}\">{1}</a>", "SelfInformation.aspx", Session["username"] as string));
                      else
                          Response.Write(string.Format("<a href=\"{0}\">{1}</a>", "Default.aspx", "登陆"));
                    %>
                </li>
                <li class="ui-link-item list-item"><a href="">主页</a>
                </li>
                <li class="ui-link-item list-item"><a href="">网站地图</a>
                </li>
                <li class="ui-link-item list-item"><a href="">关于我们</a>
                </li>
                <li class="ui-link-item list-item ui-link-item-last"><a href="">联系我们</a>
                </li>
            </ul>
        </div>
    </div>
    <div class="reg-head high-head">
        <div>
            <img src="" /><!--图片-->
            <span class="title">账户注册</span>
        </div>
    </div>
    <form id="form" method="post" action="" runat="server" autocomplete="off">
        <div id="d_register">
            <div class="reg-item">
                <h3>账户信息</h3>
            </div>
            <div id="d_headimg">
                <img id="headimg" src="Headimg.ashx" />
                <span class="btn_Upload"><span>设置头像</span><asp:FileUpload ID="headfile" runat="server" onchange="handleFiles(this)" /></span>
            </div>
            <div class="form-line">
                <label class="label">积分宝账号：</label>
                <div class="element">
                    <div>
                        <asp:TextBox
                            class="text"
                            MaxLength="65"
                            ID="username"
                            runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv1" Display="Dynamic" ControlToValidate="username" runat="server" ErrorMessage="请输入用户名!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev1" Display="Dynamic" runat="server" ControlToValidate="username" ValidationExpression="^[a-zA-Z][a-zA-Z0-9_]{4,15}$" ErrorMessage="用户名格式错误!"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>

            <div class="form-line">
                <label class="label">设置登录密码：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" TextMode="Password" MaxLength="65" ID="password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv2" Display="Dynamic" ControlToValidate="password" runat="server" ErrorMessage="请输入密码!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev2" Display="Dynamic" runat="server" ControlToValidate="password" ValidationExpression="^[a-zA-Z]\w{5,17}$" ErrorMessage="密码格式错误!"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="form-line">
                <label class="label">再输入一遍：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" TextMode="Password" MaxLength="65" ID="repassword" runat="server"></asp:TextBox>
                        <asp:CompareValidator Display="Dynamic" ID="cv1" runat="server" ControlToValidate="repassword" ControlToCompare="password" ErrorMessage="两次密码输入不同!"></asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div class="form-line">
                <label class="label">邮箱：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" MaxLength="65" ID="email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv3" Display="Dynamic" ControlToValidate="email" runat="server" ErrorMessage="请输入邮箱!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev3" Display="Dynamic" runat="server" ControlToValidate="email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="邮箱格式错误!"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="reg-item">
                <h3>密保信息</h3>
            </div>
            <div class="form-line">
                <label class="label">设置支付密码：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" TextMode="Password" MaxLength="65" ID="pay_pwd" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv4" Display="Dynamic" ControlToValidate="pay_pwd" runat="server" ErrorMessage="请输入支付密码!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev4" Display="Dynamic" runat="server" ControlToValidate="pay_pwd" ValidationExpression="^[a-zA-Z]\w{5,17}$" ErrorMessage="支付密码格式错误!"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <div class="form-line">
                <label class="label">再输入一遍：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" TextMode="Password" MaxLength="65" ID="re_pay_pwd" runat="server"></asp:TextBox>
                        <asp:CompareValidator Display="Dynamic" ID="cv2" runat="server" ControlToValidate="re_pay_pwd" ControlToCompare="pay_pwd" ErrorMessage="两次密码输入不同!"></asp:CompareValidator>
                        <span></span>
                    </div>
                </div>
            </div>
            <div class="form-line">
                <label class="label">密码保护问题：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" MaxLength="65" ID="secret_question" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv5" Display="Dynamic" ControlToValidate="secret_question" runat="server" ErrorMessage="请输入密码保护问题!"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="form-line">
                <label class="label">密码保护答案：</label>
                <div class="element">
                    <div>
                        <asp:TextBox class="text" MaxLength="65" ID="a_to_secret_question" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv6" Display="Dynamic" ControlToValidate="a_to_secret_question" runat="server" ErrorMessage="请输入支付密码!"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div><%--if(OnSubmit()){ return true; }else{ return false; }--%>
            <asp:Button ID="sub" OnClick="sub_Click" CssClass="btn btn-primary" Style="margin-top: 50px; margin-left: 70%; width: 100px;" OnClientClick="" runat="server" Text="注册" />

        </div>
    </form>
    <script>
        $(function () {
            $('#username').popover({
                trigger: "focus",
                content: "请输入中文﹑英文字母、数字（0~9）或下划线，长度4~15位",
            });
            $('#password').popover({
                trigger: "focus",
                content: "请输入英文字母、数字（0~9）或下划线，长度5~17位",
            });
            $('#pay_pwd').popover({
                trigger: "focus",
                content: "请输入英文字母、数字（0~9）或下划线，长度5~17位，为了您的账户安全，请勿与登陆密码相同。该密码在进行积分交易时使用。",
            });
            $('#secret_question').popover({
                trigger: "focus",
                content: "请输入您的密码保护问题，该问题在您找回密码时使用。",
            });
        });
    </script>
    <footer class="reg-footer body-color">
        <ul class="ui-link fn-clear">
            <li class="ui-link-item reg-foot-item"><a href="" target="_blank" title="关于积分宝">关于积分宝</a></li>
            <li class="ui-link-item reg-foot-item"><a href="" target="_blank" title="官方博客">官方博客</a></li>
            <li class="ui-link-item reg-foot-item"><a href="" target="_blank" title="诚征英才">诚征英才</a></li>
            <li class="ui-link-item reg-foot-item"><a href="" target="_blank" title="开放平台">开放平台</a></li>
            <li class="ui-link-item reg-foot-item"><a href="" target="_blank" title="联系我们">联系我们</a></li>
            <li class="ui-link-item reg-foot-item ui-link-item-last"><a href="" target="_blank" title="网站地图">网站地图</a></li>
        </ul>
        <br />
        <ul class="ui-link fn-clear">
            <li class="ui-link-item reg-foot-item ui-link-item-last">积分宝版权所有 2014 <a href="" target="_blank">ICP证: Xxx-xxxxxxxx</a></li>
        </ul>
    </footer>
    <script>
        window.URL = window.URL || window.webkitURL;
        var fileElem = document.getElementById("fileElem"),
            fileList = document.getElementById("fileList");
        function handleFiles(obj) {
            var files = obj.files,
                img = new Image();
            if (window.URL) {
                //File API
                //alert(files[0].name + "," + files[0].size + " bytes");
                img.src = window.URL.createObjectURL(files[0]); //创建一个object URL，并不是你的本地路径
                $("#headimg").attr({ "src": img.src });
                img.width = 200;
                img.onload = function (e) {
                    window.URL.revokeObjectURL(this.src); //图片加载后，释放object URL
                }
                //fileList.appendChild(img);
            } else if (window.FileReader) {
                //opera不支持createObjectURL/revokeObjectURL方法。我们用FileReader对象来处理
                var reader = new FileReader();
                reader.readAsDataURL(files[0]);
                reader.onload = function (e) {
                    alert(files[0].name + "," + e.total + " bytes");
                    img.src = this.result;
                    $("#headimg").attr({ "src": img.src });
                    img.width = 200;
                    //fileList.appendChild(img);
                }
            } else {
                //ie
                obj.select();
                obj.blur();
                var nfile = document.selection.createRange().text;
                document.selection.empty();
                img.src = nfile;
                $("#headimg").attr({ "src": img.src });
                img.width = 200;
                img.onload = function () {
                    alert(nfile + "," + img.fileSize + " bytes");
                }
                //fileList.appendChild(img);
                //fileList.style.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod='image',src='"+nfile+"')";
            }
        }
    </script>
</body>
</html>
