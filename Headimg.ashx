<%@ WebHandler Language="C#" Class="Headimg" %>

using System;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Drawing;

public class Headimg : IHttpHandler, IRequiresSessionState{
    CSelfInfoManager sim = new CSelfInfoManager();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/png";
        string username = "default";
        string user = context.Request.QueryString["user"];
        string uname = context.Session["username"] as string;
        if (!string.IsNullOrEmpty(uname))
            username = uname;
        if (!string.IsNullOrEmpty(user))
            username = user;
        sim.WriteHeadImg(username, context.Response.OutputStream);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}