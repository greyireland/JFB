<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="CreditVerify.aspx.cs" Inherits="Buy" %>

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
                <li class="active">2.信用验证</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>3.充值</li>
                <li><span class="glyphicon glyphicon-chevron-right"></span></li>
                <li>4.成功</li>
            </ol>
        </div>
    </div>

    <div style="width: 70%; margin: 10px auto;">
        <div class="panel panel-primary">
            <div class="panel-heading">验证信息</div>
            <div class="panel-body">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">借贷时间</span>
                            <input type="text" class="form-control" readonly value="<%=debittime %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">还贷时间</span>
                            <input type="text" class="form-control" readonly value="<%=repaytime %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">借贷论坛</span>
                            <input type="text" class="form-control" readonly value="<%=forumName %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">最大借贷额</span>
                            <input type="text" class="form-control" readonly value="<%=maxCreCnt %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-<%=status %>">
                            <span class="input-group-addon">借贷积分额</span>
                            <input type="text" class="form-control" readonly value="<%=cntofcredits %>">
                            <asp:Panel runat="server" ID="errmsg" CssClass="input-group-addon">
                                <span>信用额度不足,无法借贷过多积分!</span>
                            </asp:Panel>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <span class="input-group-addon">还贷积分额</span>
                            <input type="text" class="form-control" readonly value="<%=borrowingRate %>">
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="input-group has-success">
                            <asp:Panel ID="btnok" runat="server">
                                <button class="btn btn-success" onclick="Credit()" style="border-top-left-radius: 0; border-bottom-left-radius: 0; float: right;" type="button">确认借贷 <span class="glyphicon glyphicon-ok"></span></button>
                            </asp:Panel>
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
        </script>
        <asp:Panel ID="script" runat="server">
            <script>
                function Credit() {
                    $.post("CreditVerify.aspx", { type: "credit" }, function (data) {
                        var json = eval("(" + data + ")");
                        if (json.msg == "借贷成功!")
                            window.location.replace("CreditSuccess.aspx");
                    });
                }
            </script>
        </asp:Panel>
    </div>
    <script>
        toolbar_index = 5;
    </script>
</asp:Content>

