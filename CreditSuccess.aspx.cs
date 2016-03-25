using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_PurchaseRecord;
using JFB.TB_DebitRecord;
public partial class Buy : System.Web.UI.Page
{
    protected string forumName;
    protected string cntofcredits;
    protected string borrowingRate;
    protected string maxCreCnt;
    protected string debittime;
    protected string repaytime;
    protected string status;
    protected void Page_Load(object sender, EventArgs e)
    {
        TB_DebitRecord creditForm = Session["creditform"] as TB_DebitRecord;
        if (creditForm != null)
        {
            int uid = PageHelper.ParseID(Session["uid"]);
            CForumManager fm = new CForumManager();
            forumName = fm.SearchName(creditForm.DebitForumId);
            cntofcredits = creditForm.DebitCredits.ToString();
            maxCreCnt = fm.GetForumMaxCreditCnt(uid, creditForm.DebitForumId).ToString();
            borrowingRate = ((1 + 0.3) * creditForm.DebitCredits).ToString();//此处需要修改
            creditForm.DebitTime = DateTime.Now;
            debittime = creditForm.DebitTime.ToString();
            creditForm.BorrowingRate = 0.3;
            creditForm.DebitAccountId = uid;
            creditForm.StipulatePaymentTime = creditForm.DebitTime.AddDays(30);
            repaytime = creditForm.StipulatePaymentTime.ToString();
            Session["creditform"] = creditForm;
        }
        else
        {
            Response.WriteEnd("ERR");
        }
    }

    private void GoNext()
    {
        Session["orderform"] = new TB_PurchaseRecord
        {
            PurchaseCredits = double.Parse(Request.Form["cnt"]),
            ForumId = int.Parse(Request.Form["fid"]),
        };
    }

    private void ShowMyForums()
    {
        int uid = PageHelper.ParseID(Session["uid"]);
        CForumManager fm = new CForumManager();
        Response.WriteEnd(fm.SearchSelf(uid));
    }
}