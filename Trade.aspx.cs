using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string type = Request.QueryString["type"] as string;
        if (string.IsNullOrEmpty(type))
            type = Request.Form["type"] as string;
        if (!string.IsNullOrEmpty(type))
        {
            switch (type)
            {
                case "tradeable": ShowAllTradeable(); break;
                case "comment": ShowComments(); break;
                case "trade": BeginTrade(); break;
                case "searchTradeable": SearchTradeable(); break;
                default: break;
            }
        }
    }

    private void SearchTradeable()
    {
        int fexid = int.Parse(Request.QueryString["fexid"] as string);
        int freid = int.Parse(Request.QueryString["freid"] as string);
        CTradeCredits tc = new CTradeCredits();
        Response.WriteEnd(tc.SearchTradable(freid, fexid, PageHelper.ParseID(Session["uid"])));
    }

    private void BeginTrade()
    {
        int id = int.Parse(Request.Form["id"] as string);
        string paypwd = Request.Form["paypwd"] as string;
        CTradeCredits tc = new CTradeCredits();
        if (new CSelfInfoManager().PayPwdValidation(PageHelper.ParseID(Session["uid"]), paypwd))
            Response.WriteEnd(tc.Trade(id, PageHelper.ParseID(Session["uid"])).ToString());
        else
            Response.WriteEnd("alert('交易密码错误!');");
    }

    private void ShowComments()
    {
        CEvaluateManager em = new CEvaluateManager();
        int id = int.Parse(Request.Form["id"] as string);
        string content = Request.Form["content"] as string;
        em.TradingReply.ReplierId = PageHelper.ParseID(Session["uid"]);
        em.TradingReply.ReplyContent = content;
        em.TradingReply.ReplyTime = DateTime.Now;
        em.TradingReply.TradingId = id;
        em.Publish();
        Response.WriteEnd(em.Show(id));
    }

    private void ShowAllTradeable()
    {
        int pn = int.Parse(Request.QueryString["page"]);
        CTradeCredits tc = new CTradeCredits();
        Response.Write(tc.ShowTradable(pn, PageHelper.ParseID(Session["uid"])));
        Response.End();
    }
}