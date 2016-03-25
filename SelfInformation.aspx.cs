using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_Account;
public partial class SelfInformation : System.Web.UI.Page
{
    protected static string[,] tabs = { { "SelfInformation.aspx", "基本信息" }, { "ForumList.aspx", "我的论坛" }, { "TradingRecord.aspx", "交易记录" }, { "SecuritySetup.aspx", "安全设置" }, { "MessageCenter.aspx", "消息中心" } };
    protected string i_tabs = PageHelper.Init_i_tabs(tabs, 2);
    protected TB_Account account;
    protected double income;
    protected double expend;
    protected double debit;
    protected double buy;

    CSelfInfoManager sm = new CSelfInfoManager();
    CCreditsManager cm = new CCreditsManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        int uid = PageHelper.ParseID(Session["uid"]);
        if (uid > 0)
        {
            account = sm.ShowInfo(uid);
            income = cm.SumIncomeCredits(uid);
            expend = cm.SumExpendCredits(uid);
            debit = cm.SumDebitCredits(uid);
            buy = cm.SumBuyCredits(uid);
        }
        else
            account = new TB_Account();
    }
}