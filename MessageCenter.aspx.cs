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
            type = Request.Form["type"] as string;
        if (!string.IsNullOrEmpty(type))
        {
            switch (type)
            {
                case "msg": ShowMsg(); break;
                default: break;
            }
        }
    }

    private void ShowMsg()
    {
        CMsg m = new CMsg();
        int uid = PageHelper.ParseID(Session["uid"]);
        if (uid > 0)
        {
            Response.WriteEnd(m.GetMsg(uid));
        }
    }
}