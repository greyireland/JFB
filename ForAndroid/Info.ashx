<%@ WebHandler Language="C#" Class="Info" %>

using System;
using System.Web;

public class Info : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                case "self": GetSelfInfo(context); break;
                case "msg": GetMsgs(context); break;
            }
        }
    }

    private void GetSelfInfo(HttpContext context)
    {
        CSelfInfoManager sim = new CSelfInfoManager();
        CTradeCredits tc = new CTradeCredits();
        var info = sim.ShowInfo(uid);

        context.Response.Write(CJsonHelper.Serialize(new
        {
            username = info.Account,
            email = info.Email,
            securitylevel = info.SecurityLevel,
            exp = info.Exp,
            exsum = tc.Exsum(uid),
            insum = tc.Insum(uid),
        }));

    }
    private void GetMsgs(HttpContext context)
    {
        CMsg m = new CMsg();
        context.Response.Write(m.GetMsg(uid));

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}