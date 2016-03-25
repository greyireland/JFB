<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div>
        <div style="width: 70%; text-align: center; margin: 0 auto;">
            <ol class="breadcrumb">
                <li class="active">1.下单</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>2.确认订单</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>3.付款</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>4.充值</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>5.成功</li>
            </ol>
        </div>
    </div>

    <div style="width: 70%; margin: 10px auto;">
        <form class="form-horizontal" role="form">
            <div class="form-group">
                <label class="col-sm-2 control-label">选择论坛</label>
                <div class="col-sm-10">
                    <div class="input-group">
                        <select class="form-control" id="myforums">
                        </select>
                        <span class="input-group-addon">单价</span>
                        <span class="input-group-addon" id="unitprice"></span>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword" class="col-sm-2 control-label">购买的积分数量</label>
                <div class="col-sm-10">
                    <div class="input-group">
                        <input type="text" id="cntofcredits" class="form-control" placeholder="输入购买的积分数量" />
                        <span class="input-group-addon">总价</span>
                        <span class="input-group-addon" id="totalprice"></span>
                    </div>
                </div>
            </div>
            <a onclick="NextStep()" class="btn btn-success" style="text-decoration: none; float: right; margin-top: 100px; margin-right: 50px; outline-style: none;" type="button">下一步 <span class="glyphicon glyphicon-share-alt"></span></a>
            <div style="clear: both; display: block;"></div>
        </form>
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

