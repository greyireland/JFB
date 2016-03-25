using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChildPage : System.Web.UI.MasterPage
{
    protected string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        uname = Session["username"] == null ? "" : Session["username"].ToString();
    }
    
}
