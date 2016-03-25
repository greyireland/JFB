<%@ WebHandler Language="C#" Class="UnitPrice" %>

using System;
using System.Web;

public class UnitPrice : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string fidStr = context.Request.QueryString["fid"] as string;
        if (fidStr != null)
        {
            int fid = -1;
            if (int.TryParse(fidStr, out fid))
            {
                context.Response.WriteEnd(new CForumManager().GetForumUnitPriceOfCredits(fid));
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}