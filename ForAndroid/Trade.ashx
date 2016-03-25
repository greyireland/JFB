<%@ WebHandler Language="C#" Class="Trade" %>

using System;
using System.Web;

public class Trade : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                case "query": GetSelfAllTrade(context); break;
                case "submit": TakeTrade(context); break;
                case "self": ShowSelfTrade(context); break;
                case "detail": ShowDetail(context); break;
                case "deletedetail": DeleteDetail(context); break;
            }
        }
    }

    private void ShowSelfTrade(HttpContext context)
    {
        CTradeCredits tc = new CTradeCredits();
        context.Response.Write(tc.SearchSelfTrade(DateTime.MinValue, DateTime.MaxValue, uid));
    }

    private void DeleteDetail(HttpContext context)
    {
        CTradeCredits tc = new CTradeCredits();
        int tid = int.Parse(context.Request.QueryString["tid"] as string);
        if (tc.DeleteSelfTrade(tid))
            context.Response.Write(new { msg = "删除成功!", status = 1 });
        else
            context.Response.Write(new { msg = "删除失败!", status = 0 });
    }

    private void ShowDetail(HttpContext context)
    {
        int tid = int.Parse(context.Request.QueryString["tid"] as string);
        CTradeCredits tc = new CTradeCredits();
        context.Response.Write(tc.ShowTradeDetail(tid));
    }

    private void GetSelfAllTrade(HttpContext context)
    {
        if (uid > 0)
        {
            context.Response.Write(new CTradeCredits().ShowTradable(1, uid, int.MaxValue));
        }
    }
    private void TakeTrade(HttpContext context)
    {
        int tid = int.Parse(context.Request.QueryString["id"]);
        string paypwd = context.Request.QueryString["paypwd"] as string;
        if (tid > 0)
        {
            CSelfInfoManager si = new CSelfInfoManager();

            if (si.ShowInfo(uid).PayPwd == paypwd)
                if (new CTradeCredits().Trade(tid, uid))
                    context.Response.Write(new { msg = "交易成功!", status = 1 });
                else
                    context.Response.Write(new { msg = "交易失败!", status = 0 });
            else
                context.Response.Write(new { msg = "交易密码错误!", status = 0 });
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