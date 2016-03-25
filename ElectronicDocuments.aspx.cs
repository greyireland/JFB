using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ElectronicDocuments : System.Web.UI.Page
{
    protected double income;
    protected double expend;
    protected double debit;
    protected double buy;
    protected void Page_Load(object sender, EventArgs e)
    {
        int uid = PageHelper.ParseID(Session["uid"]);
        if (uid > 0)
        {
            CCreditsManager cm = new CCreditsManager();
            income = cm.SumIncomeCredits(uid);
            expend = cm.SumExpendCredits(uid);
            debit = cm.SumDebitCredits(uid);
            buy = cm.SumBuyCredits(uid);
        }
    }
}