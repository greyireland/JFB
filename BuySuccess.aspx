<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="BuySuccess.aspx.cs" Inherits="Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Js/bootstrap.min.js"></script>
    <style>
        .buySucc {
            background-image: url(/img/buysuccess.png);
            background-position: 0 0;
            background-size: 500px;
            width: 500px;
            height: 55px;
            margin: 30px;
            display: inline-block;
        }

        .succ-ico {
            background-image: url(/img/succ-ico.png);
            background-position: 0 0;
            background-size: 80px;
            width: 80px;
            height: 80px;
            margin: 30px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div>
        <div style="width: 70%; text-align: center; margin: 0 auto;">
            <ol class="breadcrumb">
                <li>1.下单</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>2.确认订单</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>3.付款</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>4.充值</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li class="active">5.成功</li>
            </ol>
        </div>
    </div>

    <div style="width: 70%; margin: 10px auto;">
        <div style="width: 800px; margin: 0 auto;">
            <div class="succ-ico"></div>
            <div class="buySucc"></div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">购买信息</div>
            <div class="panel-body">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">下单时间</span>
                            <input type="text" class="form-control" readonly value="<%=time %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">购买论坛</span>
                            <input type="text" class="form-control" readonly value="<%=forumName %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">积分单价</span>
                            <input type="text" class="form-control" readonly value="￥<%=unitPrice %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">积分数量</span>
                            <input type="text" class="form-control" readonly value="<%=cntofcredits %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">支付金额</span>
                            <input type="text" class="form-control" readonly value="￥<%=moneyofcredits %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <a class="btn btn-default" href="Buy.aspx" style="border-top-right-radius: 0; border-bottom-right-radius: 0; float: right;" type="button">继续购买 <span class="glyphicon glyphicon-arrow-right"></span></a>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <script>
            function UnitPrice() {
                return $($("#myforums").children("option[value='" + $("#myforums").val() + "']")[0]).attr("data-up");
            }
            function SetTotalPrice(cnt) {
                var tp = parseFloat(cnt) * parseFloat(UnitPrice());
                $("#totalprice").text("￥" + tp.toFixed(2));
            }

            function Change() {
                $("#unitprice").text("￥" + UnitPrice());
            }
            (function () {
                $("#myforums").change(function () {
                    Change();
                });
                $("#cntofcredits").change(function () {
                    SetTotalPrice($(this).val());
                });
            })();
            (function () {
                $.get("Buy.aspx", { type: "forums" }, function (data) {
                    var data = eval("(" + data + ")").data;
                    if (data.length <= 0) {
                        alert("请先输入您的论坛!");
                        window.location = "ForumList.aspx";
                    }
                    for (var i = 0; i < data.length; i++) {
                        var option = document.createElement("option");
                        option.value = data[i].forum.id;
                        option.innerText = data[i].forum.name;
                        $.ajax("UnitPrice.ashx", {
                            async: false,
                            cache: false,
                            data: { fid: data[i].forum.id },
                            success: function (d) {
                                $(option).attr({ "data-up": d });
                            }
                        });
                        $("#myforums").append(option);
                        Change();
                        SetTotalPrice(0)
                    }
                });
            })();
            function NextStep() {
                var cnt = $("#cntofcredits").val();
                var fid = $("#myforums").val();
                $.ajax("Buy.aspx", {
                    type: "POST",
                    async: false,
                    cache: false,
                    data: { type: "next", cnt: cnt, fid: fid },
                    success: function (data) {
                        window.location = "BuyVerify.aspx";
                    }
                });
            }
        </script>
        <script>
            toolbar_index = 4;
        </script>
</asp:Content>

