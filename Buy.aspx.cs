using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_PurchaseRecord;
public partial class Buy : System.Web.UI.Page
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
                case "forums": ShowMyForums(); break;
                case "next": GoNext(); break;
                default: break;
            }
        }
    }

    private void GoNext()
    {
        Session["orderform"] = new TB_PurchaseRecord { 
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