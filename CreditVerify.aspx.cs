using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        CForumManager fm = new CForumManager();

        if (creditForm != null)
        {

            string type = Request.Form["type"] as string;
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "credit": Credit(); break;
                    default: break;
                }
            }
            else
            {
                int uid = PageHelper.ParseID(Session["uid"]);
                CDebitCredits dc = new CDebitCredits();
                dc.DebitRecord = creditForm;
                dc.DebitRecord.DebitAccountId = uid;
                if (dc.CreditVerification())
                {
                    status = "success";
                    errmsg.Visible = false;
                }
                else
                {
                    btnok.Visible = false;
                    script.Visible = false;
                    status = "error";
                }
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
        }
        else
        {
            Response.WriteEnd("ERR");
        }
    }

    private void Credit()
    {
        CDebitCredits dc = new CDebitCredits();
        dc.DebitRecord = Session["creditform"] as TB_DebitRecord;
        if (dc.CreditVerification() && dc.Debit())
            Response.WriteEnd("{msg:'借贷成功!'}");
        else
            Response.WriteEnd("{msg:'借贷失败!'}");
    }

}