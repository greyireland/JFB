<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="NewTrade.aspx.cs" Inherits="Trade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_Trade.css" rel="stylesheet" />
    <%--<script src="Js/zelect.js"></script>--%>
    <link href="Css/Css_E_Doc.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <script src="Js/bootstrap.min.js"></script>
    <style>
  </style>
    <script>
        var tradecount = 0;
        function getEle(ele) {
            return document.createElement(ele);
        }

        function createSelect(data) {
            var select = getEle("select");
            for (var i = 0; i < data.length; i++) {
                var option = getEle("option");
                option.value = data[i].forum.id;
                option.innerHTML = data[i].forum.name;
                select.appendChild(option);
            }
            return select;
        }
        function del_trade(ele) {
            $($(ele).parents(".box")[0]).remove();
            --tradecount;
        }
        function addTrade() {
            if (tradecount >= 5) {
                alert("抱歉!最多添加5笔交易!");
                return false;
            }
            var div_box = getEle("div");
            var sec = getEle("section");
            var input_1 = getEle("input");
            var input_2 = getEle("input");
            var a = getEle("a");
            var div_ico = getEle("div");
            tradecount++;
            $.ajax("ForumList.aspx",
                {
                    data: { type: "self" },
                    cache: true,
                    async: false,
                    success: function (data) {
                        var json = eval("(" + data + ")");

                        var select_1 = createSelect(json.data);
                        var select_2 = createSelect(json.data);
                        //alert("as");
                        select_1.className = "fout";
                        select_2.className = "fin";
                        div_box.className = "box";
                        sec.className = "intro";
                        sec.appendChild(select_1);
                        sec.appendChild(select_2);
                        div_box.appendChild(sec);
                        div_box.appendChild(input_1);
                        div_box.appendChild(input_2);
                        div_box.appendChild(a);
                        input_1.type = "text";
                        input_1.placeholder = "请输入积分值...";
                        input_1.className = "trade-val";
                        $(input_1).attr({ "data-vt": "output" });

                        input_2.type = "text";
                        input_2.placeholder = "请输入积分值...";
                        input_2.className = "trade-val";
                        input_2.style.marginLeft = "23px";
                        $(input_2).attr({ "data-vt": "input" });

                        a.className = "btn-del";
                        a.onclick = function () {
                            del_trade(a);
                        };
                        div_ico.className = "btn-del-ico";

                        a.appendChild(div_ico);

                        $(".trade-box").append(div_box);
                        $(".trade-box .box:last .intro select").zelect({
                            placeholder: '请选择...'
                        });
                        zelected_style();
                        $(".dropdown > ol").click(zelected_style);
                        return true;
                    }
                });


        }
        //function zelected_style() {
        //    $("div").remove(".down-arrow");
        //    $(".zelected").append("<div class='down-arrow'><img src='/img/select_arrow.png' /></div>");
        //}
        function $val(i) {
            return $($(".zelected")[i]).val();
        }
        function submit_trade() {
            //var tmp = "{url:'datagrid_data.json',columns:[{field:'code',title:'Code',width:100},{field:'name',title:'Name',width:100},{field:'price',title:'Price',width:100,align:'right'}]}";

            var arr = new Array();
            var boxs = $(".trade-box").children(".box:not(.trade-tool)");

            for (var i = 0; i < boxs.length; i++) {
                var data = {};
                data.ExpendForum = $($(boxs[i]).find(".fout")[0]).val();
                data.ReceiveForum = $($(boxs[i]).find(".fin")[0]).val();
                data.ExpendCredits = $($(boxs[i]).find("input[data-vt='output']")[0]).val();
                data.ReceiveCredits = $($(boxs[i]).find("input[data-vt='input']")[0]).val();
                if (data.ExpendCredits != "" && data.ReceiveCredits != "")
                    arr[i] = data;
            }
            if (arr.length <= 0) {
                alert("请添加至少一笔交易!");
                return;
            }
            $.post("NewTrade.aspx", { action: "new", data: JSON.stringify(arr), paypwd: $("#paypwd").val() }, function (d) {
                var json = eval("(" + d + ")");
                alert(json.data);
                if (json.status == 'succ') {
                    window.location.reload(false);
                };
            });
        }


        function trade() {
            var id = $("#myModal").data("tid");
            if ($("#paypwd").val().trim() == "")
                $("#paygrp").addClass("has-error");
            else
                submit_trade();
        }

        $(window).ready(function () {
            addTrade();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">交易验证</h4>
                </div>
                <div class="modal-body">
                    <ul class="list-group">
                        <li class="list-group-item">
                            <div class="input-group" id="paygrp">
                                <span class="input-group-addon">请输入交易密码</span>
                                <input type="password" id="paypwd" class="form-control" />
                            </div>
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                    <button type="button" class="btn btn-primary" onclick="submit_trade()">确定</button>
                </div>
            </div>
        </div>
    </div>

    <div class="e-sub-toolbar">
        <a href="Trade.aspx">现有交易</a>
        <a class="click" href="NewTrade.aspx">添加新交易</a>
        <a></a>
    </div>
    <div class="trade-box">
        <div class="box trade-tool">
            <div class="box-tip">您所在的论坛</div>
            <div class="box-tip">要交易的论坛</div>
            <div class="box-tip">支出的积分值</div>
            <div class="box-tip">换取的积分值</div>
            <%--<input type="button" value="添加交易" onclick="return addTrade();" />--%>
        </div>
        <%--<input type="button" value="确认交易" onclick="submit_trade();" />--%>
    </div>
    <div class="d-add-trade" onclick="return addTrade();">
        <div class="d-add-trade-img"></div>
    </div>

    <div class="d-operate-trade">
        <div onclick="show();">
            <div class="btn-submit"></div>
        </div>
        <div>
            <div class="btn-reset"></div>
        </div>
    </div>

    <script>
        function show() {
            $("#myModal").modal('show');
        }
        toolbar_index = 3;
    </script>
</asp:Content>

