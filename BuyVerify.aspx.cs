using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_PurchaseRecord;
public partial class Buy : System.Web.UI.Page
{
    protected string forumName;
    protected string cntofcredits;
    protected string moneyofcredits;
    protected string unitPrice;
    protected string time;
    protected void Page_Load(object sender, EventArgs e)
    {
        TB_PurchaseRecord orderForm = Session["orderform"] as TB_PurchaseRecord;
        CForumManager fm = new CForumManager();

        if (orderForm != null)
        {
            string type = Request.Form["type"] as string;
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "buy": BuyCredits(); break;
                    default: break;
                }
            }
            else
            {
                forumName = fm.SearchName(orderForm.ForumId);
                cntofcredits = orderForm.PurchaseCredits.ToString();
                unitPrice = fm.GetForumUnitPriceOfCredits(orderForm.ForumId);
                moneyofcredits = (double.Parse(unitPrice) * double.Parse(cntofcredits)).ToString();
                orderForm.PurchaseTime = DateTime.Now;
                time = orderForm.PurchaseTime.ToString();
                orderForm.Amount = double.Parse(moneyofcredits);
                orderForm.PurchaserId = PageHelper.ParseID(Session["uid"]);
                Session["orderform"] = orderForm;
            }
        }
        else
        {
            Response.WriteEnd("ERR");
        }
    }

    private void BuyCredits()
    {
        CPurchaseCredits pc = new CPurchaseCredits();
        pc.PurchaseRecord = Session["orderform"] as TB_PurchaseRecord;
        if (pc.Purchase())
            Response.WriteEnd("{msg:'购买成功!'}");
        else
            Response.WriteEnd("{msg:'购买失败!'}");
    }
}