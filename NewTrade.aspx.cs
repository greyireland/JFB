using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_TradingRecord;
public partial class Trade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"] as string;
        if (string.IsNullOrEmpty(action))
            action = Request.Form["action"] as string;
        if (!string.IsNullOrEmpty(action))
        {
            switch (action)
            {
                case "new": NewTrading(); break;
                default: break;
            }
        }
    }

    private void NewTrading()
    {
        string data = Request.Form["data"] as string;
        string paypwd = Request.Form["paypwd"] as string;
        int uid = PageHelper.ParseID(Session["uid"]);
        CSelfInfoManager sim = new CSelfInfoManager();
        if (sim.PayPwdValidation(uid, paypwd))
        {
            try
            {
                int cnt = 0;
                CTradeCredits tc = new CTradeCredits();
                List<TB_TradingRecord> tr_list = CJsonHelper.DeSerialize<List<TB_TradingRecord>>(data);
                tr_list.ForEach(new Action<TB_TradingRecord>((tr) =>
                {
                    if(tr.ReceiveForum == tr.ExpendForum)
                        Response.WriteEnd("{status:'err',data:'注意!所在论坛与交易论坛不能相同!'}");
                }));

                tr_list.ForEach(new Action<TB_TradingRecord>((tr) =>
                {
                    tr.Sponsor = uid;
                    tr.StartTime = DateTime.Now;
                    tc.TradingRecord = tr;
                    cnt++;
                    if (!tc.PublishTrade())
                        throw new Exception(string.Format("第{0}条发布失败!", cnt));
                }));
                Response.WriteEnd("{status:'succ',data:'发布成功!'}");
            }
            catch (Exception e)
            {
                //Response.WriteEnd("{status:'err',data:'" + e.Message + "'}");
            }
        }
        else
            Response.WriteEnd("{status:'err',data:'交易密码错误'}");


    }
}