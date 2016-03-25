<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="TestPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Js/jquery-1.10.2.min.js"></script>
    <script src="Js/jPages.min.js"></script>
    <script src="Js/TradingList.js"></script>
    <script src="Js/jquery.pagination.js"></script>
    <link href="Css/Css_TradingList.css" rel="stylesheet" />
    <link href="Css/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/bootstrap-theme.min.css" rel="stylesheet" />
    <style>
        .pagination a {
            text-decoration: none;
            border: 1px solid #AAE;
            color: #15B;
        }

        .pagination a, .pagination span {
            display: inline-block;
            padding: 0.1em 0.4em;
            margin-right: 5px;
            margin-bottom: 5px;
        }

        .pagination .current {
            background: #26B;
            color: #fff;
            border: 1px solid #AAE;
        }

            .pagination .current.prev, .pagination .current.next {
                color: #999;
                border-color: #999;
                background: #fff;
            }
    </style>
    <script>
        var json = {
            data: [
                {
                    account: "kj786543563",
                    headimg: "",
                    time: "2012-5-3 12:20:30",
                    content: "发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                    comments: [
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                    ]
                },
                {
                    account: "kj786543563",
                    headimg: "",
                    time: "2012-5-3 12:20:30",
                    content: "发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                    comments: [
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                    ]
                },
                {
                    account: "kj786543563",
                    headimg: "",
                    time: "2012-5-3 12:20:30",
                    content: "发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                    comments: [
                    ]
                },
                {
                    account: "kj786543563",
                    headimg: "",
                    time: "2012-5-3 12:20:30",
                    content: "发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                    comments: [
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                        {
                            account: "kj724362203",
                            headimg: "",
                            content: "//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]",
                            time: "",
                        },
                    ]
                },
                <%
        for (int t = 0; t < 10; t++)
        {
            Response.Write(@"{
                    account: 'kj786543563',
                    headimg: '',
                    time: '2012-5-3 12:20:30',
                    content: '发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]',
                    comments: [
                        {
                            account: 'kj724362203',
                            headimg: '',
                            content: '//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]',
                            time: '',
                        },
                        {
                            account: 'kj724362203',
                            headimg: '',
                            content: '//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]',
                            time: '',
                        },
                        {
                            account: 'kj724362203',
                            headimg: '',
                            content: '//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]',
                            time: '',
                        },
                        {
                            account: 'kj724362203',
                            headimg: '',
                            content: '//发布者账号，发布者头像，发布时间，发布内容，评论:[评论着账号，评论者头像，评论内容]',
                            time: '',
                        },
                    ]
                },");
        }
        
        %>

            ]
        }
    </script>

    <title></title>
</head>
<body>
    <div>
        <button onclick="hid()" style="position: fixed; top: 0; left: 0;">click</button>
    </div>
    <form id="form1" runat="server">

        <div id="Pagination" class="pagination"></div>
        <div class="tl-container" id="itemContainer">
            <div>
                <div id="tl-trading-header">
                    <img src="" />
                    <span class="id">kj786543563</span>
                    <span class="time">2014-5-12 12:30:25</span>
                </div>
                <div id="tl-trading-content">
                    askdkahjdbcxbzohwuihakjckjzbcbznbhalgfiahuigfhjsa
                    kvjhxzmvbmnzvwgeifuhkshjadfgkhjasgfjhgakjhgf
                    skdkahjdbcxbzohwuihakjckjzbcbznbhalgfiahuigfhjsa
                    kvjhxzmvbmnzvwgeifuhkshjadfgkhjasgfjhgakjhgf
                    skdkahjdbcxbzohwuihakjckjzbcbznbhalgfiahuigfhjsa
                    kvjhxzmvbmnzvwgeifuhkshjadfgkhjasgfjhgakjhgf
                </div>
                <div class="tl-comment-btn">
                    <span>查看评论</span>
                </div>
                <div id="tl-comment">
                    <div>
                        <img />
                        <span class="id">kj123456</span>
                        <span class="time"></span>
                        <span class="content">qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq</span>
                    </div>
                    <div>
                        <img />
                        <span>kj123456</span>
                        <span>asssssssdasdad</span>
                    </div>
                    <div>
                        <img />
                        <span>kj123456</span>
                        <span>zcvzzxvxcvzxcvzxcvzxcv</span>
                    </div>
                </div>
                <div class="tl-comment-reply">
                    <div>
                        <textarea placeholder="我也说一句"></textarea>
                        <input type="button" value="回复" />
                    </div>
                </div>
            </div>
        </div>



        <script>
            $(function () {
                //此demo通过Ajax加载分页元素

                var initPagination = function () {
                    var num_entries = 500;
                    // 创建分页
                    $("#Pagination").pagination(num_entries, {
                        num_edge_entries: 1, //边缘页数
                        num_display_entries: 4, //主体页数
                        callback: pageselectCallback,
                        items_per_page: 1, //每页显示1项
                        prev_text: "前一页",
                        next_text: "后一页"
                    });

                };

                function pageselectCallback(page_index, jq) {
                    //var new_content = $("#hiddenresult div.result:eq(" + page_index + ")").clone();
                    //$("#Searchresult").empty().append(new_content); //装载对应分页的内容
                    $("#itemContainer").empty();
                    TradingList.create({});
                    return false;
                }
                initPagination();
                //ajax加载
                //$("#hiddenresult").load("load.html", null, initPagination);
            });
        </script>
        &nbsp;<div>
            <%
                //CDebitCredits dc = new CDebitCredits();
                //dc.DebitRecord.Id = 4;
                //Response.Write(dc.SearchRecord(DateTime.MinValue, DateTime.MaxValue));

                CForumManager fm = new CForumManager();
                Response.Write(fm.SearchSelf(1));
            %>

            <div id="hidden">4564654<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
        </div>


        <script>
            function hid() {
                console.log(JSHelper.isVisiableFromTop(hidden));
            }
        </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:CommandField DeleteImageUrl="~/img/add-btn.png" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="主键" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Account" HeaderText="Account" SortExpression="Account" />
                        <asp:BoundField DataField="LoginPwd" HeaderText="LoginPwd" SortExpression="LoginPwd" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="PayPwd" HeaderText="PayPwd" SortExpression="PayPwd" />
                        <asp:BoundField DataField="PwdQuestion" HeaderText="PwdQuestion" SortExpression="PwdQuestion" />
                        <asp:BoundField DataField="PwdAnswer" HeaderText="PwdAnswer" SortExpression="PwdAnswer" />
                        <asp:BoundField DataField="Exp" HeaderText="Exp" SortExpression="Exp" />
                        <asp:BoundField DataField="LineOfCredit" HeaderText="LineOfCredit" SortExpression="LineOfCredit" />
                        <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                        <asp:BoundField DataField="HeadImgPath" HeaderText="HeadImgPath" SortExpression="HeadImgPath" />
                        <asp:BoundField DataField="SecurityLevel" HeaderText="SecurityLevel" SortExpression="SecurityLevel" />
                        <asp:BoundField DataField="Account" HeaderText="Account" SortExpression="Account" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:DB_JFB_ConnectionString %>" DeleteCommand="DELETE FROM [TB_Accounts] WHERE [Id] = @original_Id AND [Account] = @original_Account AND [LoginPwd] = @original_LoginPwd AND [Email] = @original_Email AND [PayPwd] = @original_PayPwd AND [PwdQuestion] = @original_PwdQuestion AND [PwdAnswer] = @original_PwdAnswer AND [Exp] = @original_Exp AND [LineOfCredit] = @original_LineOfCredit AND [STATUS] = @original_STATUS AND [HeadImgPath] = @original_HeadImgPath AND [SecurityLevel] = @original_SecurityLevel" InsertCommand="INSERT INTO [TB_Accounts] ([Account], [LoginPwd], [Email], [PayPwd], [PwdQuestion], [PwdAnswer], [Exp], [LineOfCredit], [STATUS], [HeadImgPath], [SecurityLevel]) VALUES (@Account, @LoginPwd, @Email, @PayPwd, @PwdQuestion, @PwdAnswer, @Exp, @LineOfCredit, @STATUS, @HeadImgPath, @SecurityLevel)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [TB_Accounts]" UpdateCommand="UPDATE [TB_Accounts] SET [Account] = @Account, [LoginPwd] = @LoginPwd, [Email] = @Email, [PayPwd] = @PayPwd, [PwdQuestion] = @PwdQuestion, [PwdAnswer] = @PwdAnswer, [Exp] = @Exp, [LineOfCredit] = @LineOfCredit, [STATUS] = @STATUS, [HeadImgPath] = @HeadImgPath, [SecurityLevel] = @SecurityLevel WHERE [Id] = @original_Id AND [Account] = @original_Account AND [LoginPwd] = @original_LoginPwd AND [Email] = @original_Email AND [PayPwd] = @original_PayPwd AND [PwdQuestion] = @original_PwdQuestion AND [PwdAnswer] = @original_PwdAnswer AND [Exp] = @original_Exp AND [LineOfCredit] = @original_LineOfCredit AND [STATUS] = @original_STATUS AND [HeadImgPath] = @original_HeadImgPath AND [SecurityLevel] = @original_SecurityLevel">
                    <DeleteParameters>
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        <asp:Parameter Name="original_Account" Type="String" />
                        <asp:Parameter Name="original_LoginPwd" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_PayPwd" Type="String" />
                        <asp:Parameter Name="original_PwdQuestion" Type="String" />
                        <asp:Parameter Name="original_PwdAnswer" Type="String" />
                        <asp:Parameter Name="original_Exp" Type="Int32" />
                        <asp:Parameter Name="original_LineOfCredit" Type="Int32" />
                        <asp:Parameter Name="original_STATUS" Type="String" />
                        <asp:Parameter Name="original_HeadImgPath" Type="String" />
                        <asp:Parameter Name="original_SecurityLevel" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Account" Type="String" />
                        <asp:Parameter Name="LoginPwd" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="PayPwd" Type="String" />
                        <asp:Parameter Name="PwdQuestion" Type="String" />
                        <asp:Parameter Name="PwdAnswer" Type="String" />
                        <asp:Parameter Name="Exp" Type="Int32" />
                        <asp:Parameter Name="LineOfCredit" Type="Int32" />
                        <asp:Parameter Name="STATUS" Type="String" />
                        <asp:Parameter Name="HeadImgPath" Type="String" />
                        <asp:Parameter Name="SecurityLevel" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Account" Type="String" />
                        <asp:Parameter Name="LoginPwd" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="PayPwd" Type="String" />
                        <asp:Parameter Name="PwdQuestion" Type="String" />
                        <asp:Parameter Name="PwdAnswer" Type="String" />
                        <asp:Parameter Name="Exp" Type="Int32" />
                        <asp:Parameter Name="LineOfCredit" Type="Int32" />
                        <asp:Parameter Name="STATUS" Type="String" />
                        <asp:Parameter Name="HeadImgPath" Type="String" />
                        <asp:Parameter Name="SecurityLevel" Type="String" />
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        <asp:Parameter Name="original_Account" Type="String" />
                        <asp:Parameter Name="original_LoginPwd" Type="String" />
                        <asp:Parameter Name="original_Email" Type="String" />
                        <asp:Parameter Name="original_PayPwd" Type="String" />
                        <asp:Parameter Name="original_PwdQuestion" Type="String" />
                        <asp:Parameter Name="original_PwdAnswer" Type="String" />
                        <asp:Parameter Name="original_Exp" Type="Int32" />
                        <asp:Parameter Name="original_LineOfCredit" Type="Int32" />
                        <asp:Parameter Name="original_STATUS" Type="String" />
                        <asp:Parameter Name="original_HeadImgPath" Type="String" />
                        <asp:Parameter Name="original_SecurityLevel" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
