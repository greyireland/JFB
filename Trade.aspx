<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="Trade.aspx.cs" Inherits="Trade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_Trade.css" rel="stylesheet" />
    <script src="Js/zelect.js"></script>
    <link href="Css/Css_E_Doc.css" rel="stylesheet" />
    <script src="Js/TradingList.js"></script>
    <link href="Css/Css_TradingList.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <link href="Css/Css_SelfInfo.css" rel="stylesheet" />
    <link href="Css/animate.css" rel="stylesheet" />
    <%--<script src="Js/jquery.fadethis.min.js"></script>--%><script src="Js/jquery.fadethis.js"></script>
    <script src="Js/jquery.goup.min.js"></script>
    <script src="Js/jquery.masonry.min.js"></script>
    <script src="Js/jquery.infinitescroll.min.js"></script>
    <link href="Css/font-awesome.min.css" rel="stylesheet" />
    <script src="Js/bootstrap.min.js"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <style>
  </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $.goup({
                trigger: 200,
                bottomOffset: 50,
                locationOffset: 100,
                title: 'Top',
                titleAsText: true
            });

            $('.tl-container').infinitescroll({
                navSelector: "#navigation", //导航的选择器，会被隐藏
                nextSelector: "#navigation a", //包含下一页链接的选择器
                itemSelector: ".trade-track", //你将要取回的选项(内容块)
                debug: true, //启用调试信息
                animate: false, //当有新数据加载进来的时候，页面是否有动画效果，默认没有
                extraScrollPx: 150, //滚动条距离底部多少像素的时候开始加载，默认150
                bufferPx: 40, //载入信息的显示时间，时间越大，载入信息显示时间越短
                errorCallback: function () {
                    //alert('error');
                }, //当出错的时候，比如404页面的时候执行的函数
                localMode: true, //是否允许载入具有相同函数的页面，默认为false
                dataType: 'json',//可以是json
                template: function (data) {
                    return TradingList.createItemList(data);
                },
                loading: {
                    msgText: "加载中...",
                    finishedMsg: function () {
                        $(".loading").text("没有数据了!");
                    },
                    selector: '.loading' // 显示loading信息的div
                }
            }, function (newElems) {
                //程序执行完的回调函数
                reBind();
            });
        });
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
                    <button type="button" class="btn btn-primary" onclick="trade()">确定</button>
                </div>
            </div>
        </div>
    </div>

    <div class="e-sub-toolbar">
        <a class="click" href="Trade.aspx">现有交易</a>
        <a href="NewTrade.aspx">添加新交易</a>
        <a class="search" data-target="#searchBox">搜索</a>
        <div id="searchBox">
            <select class="f-select" id="fex">
                <option class="select-placeholder" value="0">请选择您所在的论坛</option>
            </select>
            <select class="f-select" id="fre">
                <option class="select-placeholder" value="0">请选择您要交易的论坛</option>
            </select>
            <input type="button" value="搜索" id="searchBtn" />
        </div>
    </div>

    <script>
        (function ($) {
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
            var btn = $(".search");
            var sBox = $(btn.attr("data-target"));
            var top = btn.position().top + btn.outerHeight();
            var left = btn.position().left;
            sBox.hide();
            console.log(btn.position().top + "," + btn.position().left);
            sBox.css({ top: top + "px", left: left - sBox.width() + btn.outerWidth() + "px" });
            btn.unbind('click').click(function () {
                $.ajax("ForumList.aspx",
                {
                    data: { type: "self" },
                    cache: true,
                    async: false,
                    success: function (data) {
                        var json = eval("(" + data + ")");
                        var select = createSelect(json.data);
                        var sel = sBox.children(".f-select");
                        sel.children(":not(.select-placeholder)").remove();
                        sel.append($(select).html());
                        return true;
                    }
                });
                btn.toggleClass("show");
                sBox.toggle();
            });
            sBox.children(".f-select").focus(function () {
                var ph = $(this).children(".select-placeholder");
                ph.remove();
                //$(this).blur(function () {
                //    $(this).prepend(ph);
                //})
            });
            $(sBox.children("input#searchBtn")[0]).click(function () {
                var fexid = $(sBox.children("select#fex")[0]).val();
                var freid = $(sBox.children("select#fre")[0]).val();
                searchForum(fexid, freid);
                $(btn).click();
            });
        })(jQuery);
    </script>
    <script>



        function swing(ele) {
            $(ele).addClass("shake animated");
        }
        function deswing(ele) {
            $(ele).removeClass("shake animated");
        }
    </script>
    <div style="clear: both; position: relative;">
        <div class="tl-container">
        </div>
    </div>


    <script>
        function searchForum(fexid, freid) {
            $.get("Trade.aspx", { "type": "searchTradeable", fexid: fexid, freid: freid }, function (data) {
                var json = eval("(" + data + ")");
                TradingList.create(json);
                reBind();
            });
        }

        $.ajax("Trade.aspx",
            {
                async: false,
                data: {
                    "type": "tradeable",
                    "page": 1,
                },
                success: function (data) {
                    var json = eval("(" + data + ")");
                    TradingList.create(json);
                    reBind();
                },
            });
        function trade() {
            var id = $("#myModal").data("tid");
            if ($("#paypwd").val().trim() == "")
                $("#paygrp").addClass("has-error");
            else
                $.post("Trade.aspx", { "type": "trade", "id": id, "paypwd": $("#paypwd").val() }, function (data) {
                    if (data.toUpperCase() == "TRUE") {
                        alert("交易成功!");
                        window.location.reload(false);
                    }
                    else
                        alert("交易失败!");
                });
        }
        function reBind() {
            $("#tl-trading-content .flag").unbind('click').click(function () {
                var track = $($(this).parents(".trade-track")[0]);
                var id = track.attr("data-trackid");
                $("#paygrp").removeClass("has-error");
                $("#paypwd").val("");

                $("#myModal").modal('show');
                $("#myModal").data("tid", id);

                //$.post("Trade.aspx", { "type": "trade", "id": id }, function (data) {
                //    if (data.toUpperCase() == "TRUE") {
                //        alert("交易成功!");
                //        window.location.reload(false);
                //    }
                //    else
                //        alert("交易失败!");
                //});
            });


            $(".tl-comment-reply").find("input[type='button']").unbind().click(function () {
                var track = $($(this).parents(".trade-track")[0]);
                var textarea = track.find("textarea");
                var id = track.attr("data-trackid");
                var content = textarea.val();
                $.post("Trade.aspx", { "type": "comment", "id": id, "content": content }, function (data) {
                    var json = eval("(" + data + ")");
                    var comments = new TradingList.TradingComments(json);
                    $(track.children(".tl-comment-btn")[0]).unbind('click').click(function () {
                        $(track.children("#tl-comment")[0]).toggle('fast');
                    });
                    $(track.children(".tl-comment-btn")[0]).empty().html("<span>查看评论 (" + json.length + ")</span>");
                    $(track.children("#tl-comment")[0]).empty().append($(comments.create()).children());
                    textarea.val("");
                })
            });

            //$(window).fadeThis({ speed: 500 });
        }


        //TradingList.create({});

        toolbar_index = 3;
    </script>


    <%--<script>$(window).fadeThis({ speed: 500 });</script>--%>
    <%--<script>$('.tl-container').fadeThis({ speed: 500 });</script>--%>
    <div class="loading" style="text-align: center; line-height: 30px;">
        <i class="icon-spinner icon-spin" style="font-size: 20pt; vertical-align: middle;"></i><span style="display: inline; vertical-align: middle;">正在加载...</span>
    </div>
    <div id="navigation"><a href="Trade.aspx?type=tradeable&&page=1"></a></div>
</asp:Content>

