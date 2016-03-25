using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_TradingReply;
using System.Collections.Generic;
using System.Linq;
using JFB.TB_Account;
/// <summary>
/// 交易评价管理
/// </summary>
public class CEvaluateManager
{

    private TB_TradingReply tradingreply;
    //交易评价
    TB_TradingReply_DAL trd = new TB_TradingReply_DAL();
    TB_Account_DAL ad = new TB_Account_DAL();
    public TB_TradingReply TradingReply
    {
        get { return tradingreply; }
        set { tradingreply = value; }
    }
    public CEvaluateManager()
    {
        tradingreply = new TB_TradingReply();
    }
    /// <summary>
    /// 查看评价
    /// </summary>
    /// <param name="id">指定查看的交易记录id</param>
    /// <returns></returns>
    public string Show(int id)
    {
        IEnumerable<TB_TradingReply> tr_list = trd.GetAll();
        IEnumerable<TB_Account> a_list = ad.GetAll();
        var fin_list = from tr in tr_list
                       join a in a_list on tr.ReplierId equals a.Id
                       where tr.TradingId == id
                       select new
                       {
                           account = a.Account,
                           headimg = "Headimg.ashx?user=" + a.Account,
                           content = tr.ReplyContent,
                           time = tr.ReplyTime.ToString(),
                       };
        return CJsonHelper.Serialize(fin_list);
    }

    /// <summary>
    /// 发布评价
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Publish()
    {
        if (trd.Add(tradingreply) != null)
            return true;
        else
            return false;
    }
}
