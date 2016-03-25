using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelfInformation : System.Web.UI.Page
{
    protected static string[,] tabs = { { "SelfInformation.aspx", "基本信息" }, { "ForumList.aspx", "我的论坛" }, { "TradingRecord.aspx", "交易记录" }, { "SecuritySetup.aspx", "安全设置" }, { "MessageCenter.aspx", "消息中心" } };
    protected string i_tabs = PageHelper.Init_i_tabs(tabs,2);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}