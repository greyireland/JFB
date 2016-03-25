
var JSHelper = (function () {
    //判断元素是否在看见区域
    var isVisiableFromBottom = function (ele) {
        var top = ele.getBoundingClientRect().top //元素顶端到可见区域顶端的距离
        var se = document.documentElement.clientHeight //浏览器可见区域高度。
        if (top - 40 <= se) {
            return true;
        }
        return false;
    }

    var isVisiableFromTop = function (ele) {
        var top = ele.getBoundingClientRect().top //元素顶端到可见区域顶端的距离
        var height = $(ele).height();
        //var se = document.documentElement.clientHeight //浏览器可见区域高度。
        console.log(top + "," + height);
        if (top + height >= 0) {
            return true;
        }
        return false;
    }

    return {
        isVisiableFromBottom: isVisiableFromBottom,
        isVisiableFromTop: isVisiableFromTop,
    }
})();
//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]
var TradingList = (function ($) {
    var getEle = function (ele) {
        return document.createElement(ele);
    };

    ///act:account
    function TradingHead(act, src, time) {
        var div = getEle("div");
        var img = getEle("img");
        var span_id = getEle("span");
        var span_time = getEle("span");
        this.create = function () {
            div.id = "tl-trading-header";
            img.src = src;
            span_id.className = "id";
            span_id.innerText = act;
            span_time.className = "time";
            span_time.innerText = time;
            div.appendChild(img);
            div.appendChild(span_id);
            div.appendChild(span_time);
            return div;
        }
    };

    function TradingContent(content) {
        var div = getEle("div");
        var table = getEle("table");
        var row = getEle("tr");
        var tds = new Array();
        var a_1 = getEle("a");
        var a_2 = getEle("a");

        var span_1 = getEle("span");
        var span_2 = getEle("span");
        var span_3 = getEle("span");
        this.create = function () {
            for (var i = 0; i < 5; i++) {
                tds[i] = getEle("td");
                row.appendChild(tds[i]);
            }
            div.id = "tl-trading-content";
            tds[0].width = "25%";
            a_1.target = "_blank";
            a_1.href = content.fromhref;
            a_1.innerText = content.fromname;
            tds[0].appendChild(a_1)
            tds[1].width = "15%";
            tds[1].appendChild(span_1);
            span_1.className = "out";
            span_1.innerText = content.outcredits;
            tds[2].width = "20%";
            tds[2].appendChild(span_2);
            span_2.className = "flag";
            span_2.innerText = "换";

            span_2.onmouseenter = function () {
                //$(span_2).addClass("rubberBand animated");
            }

            span_2.onmouseleave = function () {
                //$(span_2).removeClass("rubberBand animated");
            }

            tds[3].width = "25%";
            a_2.target = "_blank";
            a_2.href = content.tohref;
            a_2.innerText = content.toname;
            tds[3].appendChild(a_2);
            tds[4].width = "15%";
            tds[4].appendChild(span_3);
            span_3.className = "in";
            span_3.innerText = content.incredits;
            row.style.textAlign = "center";
            table.appendChild(row);
            div.appendChild(table);
            return div;
        }
    };

    function TradingBtnView(content, callback) {
        var div = getEle("div");
        this.create = function () {
            div.className = "tl-comment-btn";
            div.innerHTML = content;
            callback(div);
            return div;
        }
    };

    function TradingComments(comments) {
        var div = getEle("div");
        this.ele = function () {
            return div;
        };
        function TradingComment(comment) {
            var div = getEle("div");
            var img = getEle("img");
            var span_id = getEle("span");
            var span_time = getEle("span");
            var span_comment = getEle("span");

            this.create = function () {
                img.src = comment.headimg;
                span_id.className = "id";
                span_time.className = "time";
                span_comment.className = "content";
                span_id.innerText = comment.account;
                span_comment.innerText = comment.content;
                span_time.innerText = comment.time;
                div.appendChild(img);
                div.appendChild(span_id);
                div.appendChild(span_time);
                div.appendChild(span_comment);

                return div;
            };
        }
        this.create = function () {
            div.id = "tl-comment";
            for (var i = 0; i < comments.length; i++) {
                div.appendChild(new TradingComment(comments[i]).create());
            }
            return div;
        }
    };

    function TradingCommentBtn() {

        var _div = getEle("div");
        var div = getEle("div");
        var text = getEle("textarea");
        var btn = getEle("input");
        this.create = function () {
            _div.className = "tl-comment-reply";
            text.placeholder = "我也说一句";

            btn.type = "button";
            btn.value = "回复";
            text.onfocus = function () {
                $(text).animate({
                    height: "50px",
                }, 200);
                $(btn).animate({
                    lineHeight: "52px",
                }, 200);
            }
            $("body").click(function (e) {
                if ($(e.toElement).parents(".tl-comment-reply")[0] != _div) {
                    $(text).height(15);
                    $(btn).css({ "lineHeight": "17px" });
                }
            });
            div.appendChild(text);
            div.appendChild(btn);
            _div.appendChild(div);
            return _div;
        };
    }
    var createItemList = function (data) {
        var tradeList = new Array();

        for (var i = 0; i < data.data.length; i++) {
            var div = getEle("div");

            div.className = "slide-left trade-track";
            var th = new TradingHead(data.data[i].account, data.data[i].headimg, data.data[i].time);
            var tc = new TradingContent(data.data[i].content);
            var tcom = new TradingComments(data.data[i].comments);
            var tbv = new TradingBtnView(data.data[i].comments.length > 0 ? "<span>查看评论 (" + data.data[i].comments.length + ")</span>" : "<span>暂无评论</span>", function (div) {
                (function () {
                    var ele = tcom.ele();
                    if (data.data[i].comments.length > 0) {
                        $(div).click(function () {
                            $(ele).toggle("fast");
                        });
                    }

                })();
            });

            var tcomb = new TradingCommentBtn();
            //div.className = "bounceInUp animated";
            var eleList = [
                th,
                tc,
                tbv,
                tcom,
                tcomb,
            ];

            for (var j = 0; j < eleList.length; j++) {
                div.appendChild(eleList[j].create());
            }

            //div.appendChild(th.create());
            //div.appendChild(tc.create());
            //div.appendChild(viewbtn.create());
            //div.appendChild(tcoms.create());
            //div.appendChild(tcombtn.create());
            $(div).attr({ "data-trackid": data.data[i].id });
            tradeList[i] = div;
        }
        return tradeList;
    }

    var create = function (data) {

        var container = $(".tl-container");
        //data = json;
        container.empty();

        var list = createItemList(data);
        for (var i = 0; i < list.length; i++) {
            container.append(list[i]);
        }

    }

    //window.onscroll = function () {
    //    var divs = $(container).children();
    //    for (var m = 0; m < divs.length; m++) {
    //        divs[m].className = "slide-left trade-track";
    //        if (JSHelper.isVisiableFromBottom(divs[m]) && $(divs[m]).attr("data-isshow") != "1") {

    //        }
    //    }
    //}


    return {
        create: create,
        TradingComments: TradingComments,
        createItemList:createItemList,
    };
})(jQuery || {});