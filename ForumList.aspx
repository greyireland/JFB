<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="ForumList.aspx.cs" Inherits="SelfInformation" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/Css_SelfInfo.css" rel="stylesheet" />
    <script src="Js/Js_ForumList.js"></script>
    <script src="Js/bootstrap.min.js"></script>
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="Content" runat="Server">


    <div class="editPanel" id="hh">
        <table style="text-align: left; margin-left: 20px;">
            <tr>
                <td>论坛：</td>
                <td>
                    <select class="f-select"></select></td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <input id="uname" type="text" /></td>
            </tr>
            <tr>
                <td>密码：</td>
                <td>
                    <input id="pwd" type="password" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <input class="b-operate-btn" id="btnOK" type="button" style="display: inline; margin-right: 30px;" value="确定" /><input id="btnCancel" class="b-operate-btn" type="button" style="display: inline;" value="取消" /></td>
            </tr>
        </table>
    </div>

    <%-- 各子页通用代码 --%>
    <%--<div class="i-tabs i-shadow">
        <%=i_tabs %>
    </div>
    <div class="i-content i-shadow"></div>--%>

    <div class="i-tabs i-shadow">
        <%=i_tabs %>
    </div>
    <div class="i-content i-shadow i-list">
        <span class="i-title"><%=tabs[1,1] %></span>
        <hr style="border: 1px solid #808080; margin: 0 20px;" />
        <div class="i-forumListHead list-item">
            <span>论坛名称</span>
            <span>论坛地址</span>
            <span>论坛账号</span>
            <span>操作</span>
        </div>
        <!--内容-->
        <div id="forumList" class="list-item">
        </div>
        <script>
            createList();
        </script>
        <div class="forum-add" onclick="ShowEditForumListItem()">
            <div class="forum-add-ico"></div>
        </div>
    </div>


    <div style="clear: both;"></div>
    <script>
        index = 2;
        toolbar_index = 2;
    </script>
</asp:Content>

