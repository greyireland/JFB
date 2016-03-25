using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_DebitRecord;
public partial class Credit : System.Web.UI.Page
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
                case "next": GoNext(); break;
                default: break;
            }
        }
    }

    private void GoNext()
    {
        Session["creditform"] = new TB_DebitRecord
        {
            DebitCredits = double.Parse(Request.Form["cnt"]),
            DebitForumId = int.Parse(Request.Form["fid"]),
        };
    }
}