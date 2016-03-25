<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="BuyVerify.aspx.cs" Inherits="Buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div>
        <div style="width: 70%; text-align: center; margin: 0 auto;">
            <ol class="breadcrumb">
                <li>1.下单</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li class="active">2.确认订单</li>
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
        <div class="panel panel-primary">
            <div class="panel-heading">订单信息</div>
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
                            <button class="btn btn-success" onclick="Buy()" style="border-top-left-radius: 0; border-bottom-left-radius: 0; float: right;" type="button">确认购买 <span class="glyphicon glyphicon-ok"></span></button>
                            <button class="btn btn-default" onclick="Back()" style="border-top-right-radius: 0; border-bottom-right-radius: 0; float: right;" type="button"><span class="glyphicon glyphicon-arrow-left"></span>返回</button>
                        </div>
                    </li>
                </ul>
            </div>

        </div>
        <script>
            function Back() {
                history.back();
            }
            function Buy() {
                $.post("BuyVerify.aspx", { type: "buy" }, function (data) {
                    var json = eval("(" + data + ")");
                    if (json.msg == "购买成功!")
                        window.location.replace("BuySuccess.aspx");
                });
            }
        </script>
    </div>
    <script>
        toolbar_index = 4;
    </script>
</asp:Content>

