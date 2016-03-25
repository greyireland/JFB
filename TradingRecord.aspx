<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="TradingRecord.aspx.cs" Inherits="SelfInformation" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    
    <script src="Js/bootstrap.min.js"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Css_SelfInfo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">详细信息</h4>
                </div>
                <div class="modal-body">
                    <div class="succ-ico" id="status-ico" style="position: absolute; top: 10px; right: 20px;"></div>
                    <form class="form-horizontal" role="form">

                        <div class="form-group">
                            <label class="col-sm-2 control-label">交易时间:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-time"></p>
                            </div>
                            <label class="col-sm-2 control-label">发布人:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-publisher"></p>
                            </div>
                            <label class="col-sm-2 control-label">交易人:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-trader"></p>
                            </div>
                            <label class="col-sm-2 control-label">支出论坛:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-exforum"></p>
                            </div>
                            <label class="col-sm-2 control-label">支出积分:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-excredits"></p>
                            </div>
                            <label class="col-sm-2 control-label">收入论坛:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-inforum"></p>
                            </div>
                            <label class="col-sm-2 control-label">收入积分:</label>
                            <div class="col-sm-10">
                                <p class="form-control-static trading-incredits"></p>
                            </div>
                            <label class="col-sm-2 control-label">备注:</label>
                            <div class="col-sm-10">
                                <textarea class="form-control trading-mark" rows="3" style="resize: none; overflow: hidden;"></textarea>
                            </div>
                            <label class="col-sm-2 control-label">评论:</label>
                            <div class="col-sm-10 trading-reply">
                            </div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary">保存修改</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        function ShowDetail(id) {
            function getEle(ele) {
                return document.createElement(ele);
            }
            function createReply(data) {
                var div = getEle("div");
                var a = getEle("a");
                var img = getEle("img");
                var div_c = getEle("div");
                var h5 = getEle("h5");
                div.className = "media";
                div.appendChild(a);
                a.className = "pull-left";
                a.appendChild(img);
                img.className = "media-object";
                img.width = 30;
                img.alt = data.account;
                img.src = data.headimg;
                div_c.className = "media-body";
                div_c.innerText = data.content;
                $(div_c).prepend(h5);
                h5.className = "media-heading";
                h5.innerText = data.account;
                div.appendChild(div_c);
                return div;
            }
            function createReplyList(data) {
                var ul = getEle("ul");
                ul.className = "list-group";
                for (var i = 0; i < data.length; i++) {
                    var li = getEle("li");
                    li.className = "list-group-item";
                    li.appendChild(createReply(data[i]));
                    ul.appendChild(li);
                }
                return ul;
            }

            $.get("TradingRecord.aspx", { type: "detail", id: id }, function (data) {
                var json = eval("(" + data + ")").data[0];
                $(".trading-time").empty().text(json.time);
                $(".trading-exforum").empty().text(json.exforum);
                $(".trading-excredits").empty().text(json.excredits);
                $(".trading-inforum").empty().text(json.inforum);
                $(".trading-incredits").empty().text(json.incredits);
                $(".trading-mark").empty().text(json.mark);
                $(".trading-publisher").empty().text(json.publisher);
                $(".trading-trader").empty().text(json.trader);
                $(".trading-reply").empty().append(createReplyList(json.comments));
                if (json.status == 1) {
                    $("div#status-ico").removeClass().addClass("succ-ico");
                }
                else
                    $("div#status-ico").removeClass().addClass("wait-ico");
            });

        }

        function DeleteTrade(id) {
            $.get("TradingRecord.aspx", { type: "del", id: id }, function (data) {
                var json = eval("(" + data + ")");
                alert(json.msg);
                ReBind();
            });
        }
    </script>
    <%-- 各子页通用代码 --%>
    <%--<div class="i-tabs i-shadow">
        <%=i_tabs %>
    </div>
    <div class="i-content i-shadow"></div>--%>

    <div class="i-tabs i-shadow">
        <%=i_tabs %>
    </div>
    <div class="i-content i-shadow i-list i-TradRcdList">
        <span class="i-title"><%=tabs[2,1] %></span>
        <hr style="border: 1px solid #808080; margin: 0 20px;" />
        <!--内容-->
        <div class="i-TradRcdListHead list-item">
            <span>最近交易记录</span>
            <span><a>收支明细</a></span>
            <span><a>购买记录</a></span>
            <span><a>借贷记录</a></span>
        </div>
        <div id="trading-record-list">
        </div>

        <script>
            function ReBind() {
                $.get("TradingRecord.aspx", { type: "trade" }, function (data) {
                    var json = eval("(" + data + ")");
                    $("#trading-record-list").empty();
                    createTradRcdList(json);
                    var st;
                    $(".operate-btn span").mouseenter(function () {
                        var ele = this;
                        st = setTimeout(function () {
                            $($(ele).parents(".operate")[0]).children("div").show();
                        }, 100);

                    });
                    $(".operate-btn span").mouseleave(function () {
                        clearTimeout(st);
                    });
                    $(".operate div").mouseleave(function () {
                        $(this).hide();
                    })
                });
            };
            ReBind();

            function createTradRcdList(data) {
                //var data = json_TradRcd;
                for (var i = 0; i < data.data.length; i++) {
                    var tradRcds = new Array();
                    var a_forumFrom = document.createElement("a");
                    var a_forumTo = document.createElement("a");
                    var div_operates = document.createElement("div");
                    var span_operate = document.createElement("span");
                    var span_operatePar = document.createElement("span");

                    var ul = document.createElement("ul");
                    var ulPar = document.createElement("div");
                    var li_s = new Array();
                    var a_s = new Array();
                    var a_str = ["详细", "备注", "删除"];
                    for (var j = 0; j < 3; j++) {
                        li_s[j] = document.createElement("li");
                        a_s[j] = document.createElement("a");
                        a_s[j].innerText = a_str[j];
                        li_s[j].appendChild(a_s[j]);
                        ul.appendChild(li_s[j]);
                    }

                    $(a_s[0]).attr({ "data-toggle": "modal", "data-target": "#myModal" });
                    $(a_s[1]).attr({ "data-toggle": "modal", "data-target": "#myModal" });
                    //alert(data.data[i].id);
                    (function () {
                        var id = data.data[i].id;
                        $(a_s[0]).click(function () {
                            ShowDetail(id);
                        });
                        $(a_s[1]).click(function () {
                            ShowDetail(id);
                        });
                        $(a_s[2]).click(function () {
                            if(confirm("确认删除该记录吗?"))
                                DeleteTrade(id);
                        });
                    })();

                    ulPar.appendChild(ul);

                    var container = document.createElement("div");
                    for (var j = 0; j < 6; j++) {
                        tradRcds[j] = document.createElement("span");
                        container.appendChild(tradRcds[j]);
                    }

                    container.appendChild(div_operates);
                    span_operatePar.className = "operate-btn";
                    div_operates.className = "operate";
                    span_operate.innerText = a_str[0];

                    span_operatePar.appendChild(span_operate);
                    div_operates.appendChild(span_operatePar);


                    div_operates.appendChild(ulPar);


                    tradRcds[0].innerText = data.data[i].time;
                    tradRcds[0].title = data.data[i].time;

                    $(tradRcds[0]).attr({ "data-toggle": "tooltip" });
                    a_forumFrom.innerText = data.data[i].forumFrom.name;
                    a_forumFrom.href = data.data[i].forumFrom.href;
                    a_forumFrom.target = "_blank";
                    a_forumFrom.title = data.data[i].forumFrom.name;
                    tradRcds[1].className = "forumName";
                    tradRcds[1].appendChild(a_forumFrom);
                    tradRcds[2].innerText = data.data[i].expend;
                    tradRcds[2].style.color = "#F37857";
                    tradRcds[2].className = "num";
                    a_forumTo.innerText = data.data[i].forumTo.name;
                    a_forumTo.href = data.data[i].forumTo.href;
                    a_forumTo.target = "_blank";
                    a_forumTo.title = data.data[i].forumTo.name;

                    tradRcds[3].className = "forumName";
                    tradRcds[3].appendChild(a_forumTo);
                    tradRcds[4].innerText = data.data[i].income;
                    tradRcds[4].style.color = "#53A000";
                    tradRcds[4].className = "num";
                    tradRcds[5].innerText = data.data[i].status;
                    //tradRcds[6].innerText = "详细";alert("as");
                    $("#trading-record-list").append(container);
                }
            }
        </script>
        <script>
            
        </script>
    </div>
    <div style="clear: both;"></div>
    <script>
        index = 3;
        toolbar_index = 2;


        //$.ajax({
        //    url: 'TradingRecord.aspx',
        //    data: { type: "trade" },
        //    cache: false,
        //    async: false,
        //    type: "GET",
        //    success: function (data) {
        //        var json = eval("(" + data + ")");
        //        createTradRcdList(json);
        //    }
        //});
    </script>

</asp:Content>

