<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="SelfInformation.aspx.cs" Inherits="SelfInformation" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_SelfInfo.css" rel="stylesheet" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Js/echarts-plain.js"></script>
    <link href="Css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">

    <%-- 各子页通用代码 --%>
    <%--<div class="i-tabs i-shadow">
        <%=i_tabs %>
    </div>
    <div class="i-content i-shadow"></div>--%>

    <div class="i-tabs i-shadow">
        <%=i_tabs %>
    </div>
    <div class="i-content i-shadow">

        <span class="i-title"><%=tabs[0,1] %></span>
        <hr style="border: 1px solid #808080; margin: 0 20px;" />
        <div class="i-content-inf">
            <div class="tit">个人信息</div>
            <form id="form" runat="server">
                <div id="d_headimg">
                    <img id="headimg" src="Headimg.ashx" />
                    <span class="btn_Upload"><span>设置头像</span><asp:FileUpload ID="headfile" runat="server" onchange="handleFiles(this)" /></span>
                </div>
            </form>
            <div>
                <table class="tb-self-info">
                    <tr>
                        <td><span class="icon-user" style="font-size:11pt;"></span>&nbsp账户名:</td>
                        <td><%=account.Account as string %></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><span class="icon-envelope" style="font-size:11pt;"></span>&nbsp邮箱:</td>
                        <td><%=account.Email %></td>
                        <td></td><%--<a href="javascript:void(0)" class="btn btn-primary btn-xs" style="text-decoration: none;">修改 <span class="glyphicon glyphicon-pencil"></span></a>--%>
                    </tr>
                    <tr>
                        <td><span class="icon-key" style="font-size:11pt;"></span>&nbsp安全等级:</td>
                        <td><%=account.SecurityLevel %></td>
                        <td><a href="SecuritySetup.aspx" class="btn btn-primary btn-xs" style="text-decoration: none;">提升 <span class="glyphicon glyphicon-arrow-up"></span></a></td>
                    </tr>
                </table>
            </div>
        </div>


        <div class="i-content-inf a-tl" style="height: 400px;">
            <div class="tit">账户余额</div>
            <%--            <div class="inf-l">
                
                 显示积分宝账户余额 
                <div class="p-info link">
                    <span style="font-size: 24pt; margin-left: 40px; margin-top: 10pt;">9999.<span style="display: inline; font-size: 18pt;">00</span></span>
                    <table class="a-table">
                        <tr>
                            <td><a class="a-tl" href="Trade.aspx">立即交易</a></td>
                            <td><a class="a-tr" href="TradingRecord.aspx">查看记录</a></td>
                        </tr>
                        <tr>
                            <td><a class="a-bl" href="Credit.aspx">积分借贷</a></td>
                            <td><a class="a-br" href="Buy.aspx">购买积分</a></td>
                        </tr>
                    </table>
                </div>

                
            </div>--%>
            <div id="chart" class="chart" style="height: 100%; width: 100%; display: block;">
            </div>


            <%--<div class="inf-r">
                <div class="tit">常用论坛</div>
                显示积分宝账户余额 
                <div class="uforum scrobar link">
                    <a href="">论坛A</a>
                    <a href="">论坛B</a>
                    <a href="">aaaaaaaaa</a>
                    <a href="">aaaaaaaaa</a>
                    <a href="">aaaaaaaaa</a>
                    <a href="">aaaaaaaaa</a>
                    <a href="">aaaaaaaaa</a>
                    <a href="">aaaaaaaaa</a>
                    <a href="">aaaaaaaaa</a>
                </div>
            </div>--%>
        </div>
        <div class="i-content-inf">
            <div class="tit">资产动态<%//时间区间 %></div>
            <div class="propers i-shadow">
                <div class="bar"></div>
                <div class="pro c1">
                    <div class="dhmq shou"></div>
                    <a class="chart-ico" href="ElectronicDocuments.aspx">
                        <div></div>
                    </a>
                    <div>
                        <span class="float-big"><%=PageHelper.SpliteInt(income) %>.<span class="float-small"><%=PageHelper.SpliteFloat(income) %></span></span>
                    </div>
                </div>
                <div class="pro c2">
                    <div class="dhmq zhi"></div>
                    <a class="chart-ico" href="ElectronicDocuments.aspx">
                        <div></div>
                    </a>
                    <div>
                        <span class="float-big"><%=PageHelper.SpliteInt(expend) %>.<span class="float-small"><%=PageHelper.SpliteFloat(expend) %></span></span>
                    </div>
                </div>
                <div class="pro c3">
                    <div class="dhmq qian"></div>
                    <a class="chart-ico" href="ElectronicDocuments.aspx">
                        <div></div>
                    </a>
                    <div>
                        <span class="float-big"><%=PageHelper.SpliteInt(debit) %>.<span class="float-small"><%=PageHelper.SpliteFloat(debit) %></span></span>
                    </div>
                </div>
                <div class="pro c4 pro-last">
                    <div class="dhmq mai"></div>
                    <a class="chart-ico" href="ElectronicDocuments.aspx">
                        <div></div>
                    </a>
                    <div>
                        <span class="float-big"><%=PageHelper.SpliteInt(buy) %>.<span class="float-small"><%=PageHelper.SpliteFloat(buy) %></span></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>
    <script>

        index = 1;
        toolbar_index = 2;
    </script>
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

    <script>
        var ct = document.getElementById("chart");
        var myChart = echarts.init(ct);
        $.get("ChartInfo.ashx", { type: "all" }, function (data) {
            var option = eval("(" + data + ")");
            myChart.setOption(option);
        });

    </script>
</asp:Content>

