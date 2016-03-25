using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected string logmsg = "";
    CPorter porter = new CPorter();
    protected void Page_Load(object sender, EventArgs e)
    {
        login_panel.Visible = true;
        if (!string.IsNullOrEmpty(Session["username"] as string))
            login_panel.Visible = false;
    }
    protected void login_Click(object sender, EventArgs e)
    {
        porter.Account.Account = username.Text;
        porter.Account.LoginPwd = password.Text;
        string vcodeStr = Session["vCode"] as string;
        if (vcode.Text.Trim() != vcodeStr.Trim())
        {
            PageHelper.DoScript(Response, "alert('验证码错误!');window.location='Default.aspx';");
            return;
        }
        if (!porter.Login())
        {
            PageHelper.DoScript(Response, "alert('" + ErrLog.LastErr() + "');window.location='Default.aspx';");
            return;
        }
        Session["username"] = porter.Account.Account;
        Session["uid"] = porter.Account.Id;
        login_panel.Visible = false;
        //此处密码以审核通过
    }
}