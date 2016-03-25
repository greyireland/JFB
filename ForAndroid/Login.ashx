<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;

public class Login : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/x-javascript";
        string username = context.Request.QueryString["username"] as string;
        string password = context.Request.QueryString["password"] as string;
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            CPorter p = new CPorter();
            p.Account.Account = username;
            p.Account.LoginPwd = password;

            if (p.Login())
            {
                string token = Guid.NewGuid().ToString().Replace("-", "");
                if (AppHelper.setToken(p.Account.Id, token))
                    context.Response.Write(CJsonHelper.Serialize(new
                    {
                        firstName = "",
                        lastName = "",
                        username = username,
                        phone = "",
                        objectId = "",
                        sessionToken = token,
                        gravatarId = "",
                        avatarUrl = "/Headimg.ashx",
                    }));
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