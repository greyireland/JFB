using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// WebModule 的摘要说明
/// </summary>
public class WebModule : IHttpModule
{
    public WebModule()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Init(HttpApplication context)
    {
        context.AcquireRequestState += context_AcquireRequestState;
    }

    void context_AcquireRequestState(object sender, EventArgs e)
    {
        HttpApplication context = sender as HttpApplication;
        string path = context.Request.Path.ToLower();
        if (path.EndsWith(".aspx"))
        {
            //没有用户登录,或者访问default.aspx,或者访问register.aspx页,都转到Default.aspx默认页面
            if (PageHelper.ParseID(context.Session["uid"]) < 0 && path.IndexOf("default.aspx") < 0 && path.IndexOf("register.aspx") < 0)
            {
                context.Response.Redirect("Default.aspx");
            }
            else
            {
                context.Session.Timeout = 10;
            }
        }
        string logout = context.Request.Form["logout"] as string;
        if (logout != null)
        {
            switch (logout)
            {
                case "true": Logout(context); break;
                default: break;
            }
        }
    }
    protected void Logout(HttpApplication context)
    {
        context.Session.Clear();
        context.Session.Abandon();
        context.Response.WriteEnd("Default.aspx");
    }
}