using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelfInformation : System.Web.UI.Page
{
    protected static string[,] tabs = { { "SelfInformation.aspx", "基本信息" }, { "ForumList.aspx", "我的论坛" }, { "TradingRecord.aspx", "交易记录" }, { "SecuritySetup.aspx", "安全设置" }, { "MessageCenter.aspx", "消息中心" } };
    protected string i_tabs = PageHelper.Init_i_tabs(tabs, 2);
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"] as string;
        if (string.IsNullOrEmpty(type))
            return;
        switch (type)
        {
            case "trade": ShowSelfTrade(); break;
            case "detail": ShowDetail(); break;
            case "del": DeleteTrade(); break;
            default: break;
        }
    }

    private void DeleteTrade()
    {
        CTradeCredits tc = new CTradeCredits();
        int id = int.Parse(Request.QueryString["id"] as string);
        if (tc.DeleteSelfTrade(id))
            Response.WriteEnd("{msg:'删除成功!'}");
        else
            Response.WriteEnd("{msg:'删除失败!'}");
    }

    private void ShowDetail()
    {
        CTradeCredits tc = new CTradeCredits();
        int id = int.Parse(Request.QueryString["id"] as string);
        Response.WriteEnd(tc.ShowTradeDetail(id));
    }

    private void ShowSelfTrade()
    {
        CTradeCredits tc = new CTradeCredits();
        Response.Write(tc.SearchSelfTrade(DateTime.MinValue, DateTime.MaxValue, PageHelper.ParseID(Session["uid"])));
        Response.End();
    }
}