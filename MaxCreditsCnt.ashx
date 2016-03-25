<%@ WebHandler Language="C#" Class="MaxCreditsCnt" %>

using System;
using System.Web;
using System.Web.SessionState;

public class MaxCreditsCnt : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        CForumManager fm = new CForumManager();
        int uid = PageHelper.ParseID(context.Session["uid"]);
        int fid = int.Parse(context.Request.QueryString["fid"]);
        if (uid > 0)
            context.Response.WriteEnd(fm.GetForumMaxCreditCnt(uid, fid).ToString());

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}