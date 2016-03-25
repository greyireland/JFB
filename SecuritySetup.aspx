<%@ Page Title="" Language="C#" MasterPageFile="~/ChildPage.master" AutoEventWireup="true" CodeFile="SecuritySetup.aspx.cs" Inherits="SelfInformation" %>

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
    <div class="i-content i-shadow">
        <span class="i-title"><%=tabs[3,1] %></span>
        <hr style="border: 1px solid #808080; margin: 0 20px;" />
        <!--内容-->

        <div class="i-table-div">
            <table style="width:100%;">
                <tr>
                    <td>登陆密码：</td>
                    <td>登录支付宝账户时需要输入的密码</td>
                    <td><a>修改</a></td>
                </tr>
                <tr class="double">
                    <td>支付密码：</td>
                    <td>在账户资金变动、修改账户信息时需要输入的密码</td>
                    <td><a>修改</a><a>找回</a></td>
                </tr>
                <tr>
                    <td>安全保护问题：</td>
                    <td>您已设置 <%=1 %> 个安全保护问题</td>
                    <td><a>修改</a></td>
                </tr>
                <tr class="double">
                    <td>邮箱校验服务：</td>
                    <td>申请该服务之后，账户相关设置或资金变动都需要邮箱验证码确认</td>
                    <td><a>开通</a></td>
                </tr>
            </table>
        </div>
    </div>
    <div style="clear: both;"></div>
    <script>
        index = 4;
        toolbar_index = 2;
    </script>
</asp:Content>

