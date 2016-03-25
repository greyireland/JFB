
function ShowEditForumListItem(tid, id, uname, type) {
    $.get("ForumList.aspx", { type: "all" }, function (data) {
        var forumList = eval('(' + data + ')');

        $(".editPanel .f-select").empty();
        $(".editPanel input[id='uname']").val("");
        $(".editPanel input[id='pwd']").val("");
        for (var i = 0; i < forumList.forums.length; i++) {
            var option = document.createElement("option");
            option.innerText = forumList.forums[i].name;
            option.value = forumList.forums[i].id;
            if (option.value == id)
                $(option).attr("selected", true);
            $(".editPanel .f-select").append(option);
        }
        if (uname != "undefined") {
            $(".editPanel #uname").val(uname);
        }
        $(".editPanel #btnOK").unbind("click").click(function () {
            var fid = $(".editPanel .f-select").val();
            var funame = $(".editPanel input[id='uname']").val();
            var fupwd = $(".editPanel input[id='pwd']").val();
            if (type == "edit")
                EditForum(tid,fid,funame,fupwd);
            else
                AddForum(fid, funame, fupwd);
            $(".editPanel").hide();
        });
        $(".editPanel #btnCancel").click(function () {
            $(".editPanel").hide();
        });
        $(".editPanel").css({ top: (window.innerHeight - $(".editPanel").height()) / 2 + "px", left: (window.innerWidth - $(".editPanel").width()) / 2 + "px" });

        $(".editPanel").show();
    });
    //var panel = document.createElement("div");
    //var btnOK = document.createElement("input");
    //var btnCancel = document.createElement("input");
    //var txtUname = document.createElement("input");
    //var txtPwd = document.createElement("input");
    //btnOK.type = "button";
    //btnCancel.type = "button";
    //txtUname.type = "text";
    //txtPwd.type = "password";


    //var forums = document.createElement("select");
    //forums.className = "f-select";
    //var forumList = GetForumList();

    //for (var i = 0; i < forumList.forums.length; i++) {
    //    var option = document.createElement("option");
    //    option.innerText = forumList.forums[i].name;
    //    option.id = forumList.forums[i].id;
    //    if (option.id == id)
    //        $(option).attr("selected", true);
    //    forums.appendChild(option);
    //}

    //panel.className = "editPanel";
    //btnOK.value = "确定";
    //btnCancel.value = "取消";

    //btnOK.className = "b-operate-btn";
    //btnCancel.className = "b-operate-btn";





    //panel.appendChild(forums);
    //panel.appendChild(txtUname);
    //panel.appendChild(txtPwd);
    //panel.appendChild(btnOK);
    //panel.appendChild(btnCancel);

    //document.write(panel.outerHTML);
}


function createList() {
    $.get("ForumList.aspx", { type: "self" }, function (data) {
        var json = eval('(' + data + ')');
        $("#forumList").empty();
        for (var i = 0; i < json.data.length; i++) {
            var divbox = document.createElement("div");
            var forumName = document.createElement("span");
            var forumHref = document.createElement("span");
            var forumAccount = document.createElement("span");
            var forumOperate = document.createElement("span");
            var forumHrefLink = document.createElement("a");
            var btnEdit = document.createElement("input");
            var btnDel = document.createElement("input");

            btnEdit.type = "button";
            btnDel.type = "button";

            btnEdit.value = "编辑";
            btnDel.value = "删除";

            btnEdit.className = "b-operate-btn";
            btnDel.className = "b-operate-btn";



            $(forumName).attr({ "data-fid": json.data[i].forum.id });
            forumName.innerText = json.data[i].forum.name;
            forumHrefLink.href = json.data[i].forum.href;
            forumHrefLink.innerText = json.data[i].forum.href;
            forumHrefLink.style.display = "inline";
            forumHrefLink.target = "_blank";
            forumAccount.innerText = json.data[i].forumAccount;
            forumHref.appendChild(forumHrefLink);
            forumOperate.appendChild(btnEdit);
            forumOperate.appendChild(btnDel);

            (function () {
                var id = json.data[i].forum.id;
                var name = json.data[i].forumAccount;
                var tname = json.data[i].forum.name;
                var tid = json.data[i].id;
                $(btnEdit).click(function () {
                    ShowEditForumListItem(tid, id, name, "edit");
                });
                $(btnDel).click(function () {
                    DeleteForum(tname, tid);
                });

            })();

            $(divbox).attr({ "data-tid": json.data[i].id });

            divbox.className = "i-forumListContent";
            divbox.appendChild(forumName);
            divbox.appendChild(forumHref);
            divbox.appendChild(forumAccount);
            divbox.appendChild(forumOperate);

            $("#forumList").append(divbox);
            //document.write(divbox.outerHTML);
        }
    });

}
function DeleteForum(name, id) {
    if (confirm("确定要删除[" + name + "]?"))
        $.get("ForumList.aspx", { type: "del", id: id }, function (data) {
            console.log(data);
            createList();/*此处可以优化*/
        })
}

function AddForum(fid, funame, fupwd) {
    //需要去对应论坛做登陆验证
    $.post("ForumList.aspx",
        {
            type: "add",
            fid: fid,
            funame: funame,
            fupwd: fupwd
        }, function (data) {
            console.log(data);
            createList();
        })
}
function EditForum(tid, fid, funame, fupwd) {
    //需要去对应论坛做登陆验证
    $.post("ForumList.aspx",
        {
            type: "edit",
            tid: tid,
            fid: fid,
            funame: funame,
            fupwd: fupwd
        }, function (data) {
            console.log(data);
            createList();
        })
}