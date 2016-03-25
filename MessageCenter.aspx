<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="MessageCenter.aspx.cs" Inherits="SelfInformation" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_SelfInfo.css" rel="stylesheet" />

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
    <div class="i-content i-shadow i-msg-list">
        <span class="i-title"><%=tabs[4,1] %></span>
        <hr style="border: 1px solid #808080; margin: 0 20px; margin-bottom: 20px;" />
        <!--内容-->

        <div id="msgContainer">
        </div>
        <script>
            //var json_data = {
            //    data: [
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContent" },
            //        { msgTitle: "MsgTitle", msgContent: "MsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContentMsgContent" },
            //    ]
            //};
            function createMsgList(json_data) {
                for (var i = 0; i < json_data.data.length; i++) {
                    var div_tit = document.createElement("div");
                    var div_con = document.createElement("div");
                    var div_main = document.createElement("div");

                    div_main.appendChild(div_tit);
                    div_main.appendChild(div_con);

                    div_tit.innerText = json_data.data[i].msgTitle;
                    div_con.innerHTML = json_data.data[i].msgContent;
                    $("#msgContainer").append(div_main);
                }
                if (json_data.data.length < 1) {
                    $("#msgContainer").html("<div style=\"height:auto;margin:0 auto;width:50px;\">暂无消息</div>");
                }

            };



            $.get("MessageCenter.aspx", { type: "msg" }, function (data) {
                var json = eval("(" + data + ")");
                createMsgList(json);
            });
        </script>

    </div>
    <div style="clear: both;"></div>
    <script>
        index = 5;
        toolbar_index = 2;
    </script>
</asp:Content>

