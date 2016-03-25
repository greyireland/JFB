<%@ WebHandler Language="C#" Class="ChartInfo" %>

using System;
using System.Web;
using System.Web.SessionState;
public class ChartInfo : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var Request = context.Request;
        string type = Request.QueryString["type"] as string;
        if (type != null)
        {
            switch (type)
            {
                case "all": GetAllCredits(context); break;
                case "ex": GetExpend(context); break;
                case "in": GetIncome(context); break;
                case "cd": GetCdCredit(context); break;
                case "py": GetSumPayCredit(context); break;
                default: break;
            }
        }

    }

    private void GetAllCredits(HttpContext context)
    {
        int uid = PageHelper.ParseID(context.Session["uid"]);
        CChartManager cm = new CChartManager();
        context.Response.WriteEnd(cm.GetCreditInfo(uid));
    }
    private void GetExpend(HttpContext context)
    {
        int uid = PageHelper.ParseID(context.Session["uid"]);
        CChartManager cm = new CChartManager();
        context.Response.WriteEnd(cm.GetMonthExCreditInfo(uid, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1)));
    }

    private void GetIncome(HttpContext context)
    {
        int uid = PageHelper.ParseID(context.Session["uid"]);
        CChartManager cm = new CChartManager();
        context.Response.WriteEnd(cm.GetMonthInCreditInfo(uid, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1)));
    }

    private void GetCdCredit(HttpContext context)
    {
        int uid = PageHelper.ParseID(context.Session["uid"]);
        CChartManager cm = new CChartManager();
        context.Response.WriteEnd(cm.GetSumCdCreditInfo(uid));
    }

    private void GetSumPayCredit(HttpContext context)
    {
        int uid = PageHelper.ParseID(context.Session["uid"]);
        CChartManager cm = new CChartManager();
        context.Response.WriteEnd(cm.GetSumPayCreditInfo(uid));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}