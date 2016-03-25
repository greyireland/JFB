<%@ WebHandler Language="C#" Class="Forum" %>

using System;
using System.Web;

public class Forum : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    int uid = -1;
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/x-javascript";
        uid = AppHelper.Verification(context);
        string action = context.Request.QueryString["action"] as string;
        if (string.IsNullOrEmpty(action))
            action = context.Request.Form["action"] as string;
        if (action != null)
        {
            switch (action)
            {
                case "showself": GetSelfForums(context); break;
                case "addforum": AddSelfForum(context); break;
                case "allforum": GetAllForum(context); break;
            }
        }
    }

    private void GetSelfForums(HttpContext context)
    {
        CForumManager fm = new CForumManager();
        context.Response.Write(fm.SearchSelf(uid));

    }

    private void GetAllForum(HttpContext context)
    {
        CForumManager fm = new CForumManager();
        context.Response.Write(fm.Search());

    }

    private void AddSelfForum(HttpContext context)
    {
        CForumManager fm = new CForumManager();
        fm.MyForum.AccountId = uid;
        fm.MyForum.ForumAccount = context.Request.QueryString["funame"] as string;
        fm.MyForum.ForumId = int.Parse(context.Request.QueryString["fid"] as string);
        fm.MyForum.ForumPwd = context.Request.QueryString["fupwd"] as string;

        if (fm.Add())
            context.Response.Write(new { msg = "添加成功!", status = 1 });
        else
            context.Response.Write(new { msg = "添加失败!", status = 0 });

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}