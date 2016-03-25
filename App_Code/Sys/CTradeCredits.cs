using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_TradingRecord;
using JFB.TB_ForumsInfo;
using System.Collections.Generic;
using System.Linq;
using JFB.TB_Account;
using JFB.TB_TradingReply;
using JFB.TB_MyForum;
/// <summary>
/// 积分交易对象
/// </summary>
public class CTradeCredits
{
    TB_TradingRecord tradingrecord;
    TB_TradingRecord_DAL trd = new TB_TradingRecord_DAL();
    TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
    TB_Account_DAL ad = new TB_Account_DAL();
    TB_TradingReply_DAL trpd = new TB_TradingReply_DAL();
    TB_MyForum_DAL mfd = new TB_MyForum_DAL();
    public TB_TradingRecord TradingRecord
    {
        get { return tradingrecord; }
        set { tradingrecord = value; }
    }

    public CTradeCredits()
    {
        tradingrecord = new TB_TradingRecord();
    }
    /// <summary>
    /// 发布交易信息
    /// </summary>
    /// <returns>发布成功返回true</returns>
    public bool PublishTrade()
    {
        if (null != trd.Add(tradingrecord))
            return true;
        else
            return false;
    }
    [Obsolete]
    /// <summary>
    /// 显示个人交易信息
    /// </summary>
    /// <returns>个人交易信息列表JSON</returns>
    public string ShowSelfTrade()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 显示可交易信息
    /// </summary>
    /// <returns>返回可交易信息列表JSON</returns>
    public string ShowTradable(int pn, int uid, int pageSize = 8)
    {
        //int pageSize = 8;
        IEnumerable<TB_TradingRecord> tr_list = trd.GetAll();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        IEnumerable<TB_Account> a_list = ad.GetAll();
        IEnumerable<TB_TradingReply> trp_list = trpd.GetAll();
        int[] mfids = (from mf in mfd.GetAll()
                       where mf.AccountId == uid
                       select mf.ForumId).ToArray();
        var fin_list = from tr in tr_list
                       join fiex in fi_list on tr.ExpendForum equals fiex.Id
                       join fire in fi_list on tr.ReceiveForum equals fire.Id
                       join a in a_list on tr.Sponsor equals a.Id
                       where tr.EndTime == null && mfids.Contains(fiex.Id) && mfids.Contains(fire.Id)
                       orderby tr.Id descending
                       select new
                       {
                           id = tr.Id,
                           account = a.Account,
                           headimg = "Headimg.ashx?user=" + a.Account,
                           time = tr.StartTime.ToString(),
                           content = new
                           {
                               fromhref = fiex.ForumAddress,
                               fromname = fiex.ForumName,
                               outcredits = tr.ExpendCredits,
                               tohref = fire.ForumAddress,
                               toname = fire.ForumName,
                               incredits = tr.ReceiveCredits,
                           },
                           comments = from trp in trp_list
                                      join _a in a_list on trp.ReplierId equals _a.Id
                                      where trp.TradingId == tr.Id
                                      select new
                                      {
                                          account = _a.Account,
                                          headimg = "Headimg.ashx?user=" + _a.Account,
                                          content = trp.ReplyContent,
                                          time = trp.ReplyTime.ToString(),
                                      },
                       };
        ;
        return CJsonHelper.Serialize(new { data = fin_list.Take(pageSize * pn).Skip(pageSize * (pn - 1)), });
    }

    /// <summary>
    /// 查找可交易信息
    /// </summary>
    /// <returns>可交易信息列表JSON</returns>
    public string SearchTradable(int expendForum, int receiveForum, int uid)
    {
        IEnumerable<TB_TradingRecord> tr_list = trd.GetAll();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        IEnumerable<TB_Account> a_list = ad.GetAll();
        IEnumerable<TB_TradingReply> trp_list = trpd.GetAll();
        int[] mfids = (from mf in mfd.GetAll()
                       where mf.AccountId == uid
                       select mf.ForumId).ToArray();
        var fin_list = from tr in tr_list
                       join fiex in fi_list on tr.ExpendForum equals fiex.Id
                       join fire in fi_list on tr.ReceiveForum equals fire.Id
                       join a in a_list on tr.Sponsor equals a.Id
                       where tr.EndTime == null && tr.ExpendForum == expendForum && tr.ReceiveForum == receiveForum && mfids.Contains(fiex.Id) && mfids.Contains(fire.Id)
                       select new
                       {
                           id = tr.Id,
                           account = a.Account,
                           headimg = "Headimg.ashx?user=" + a.Account,
                           time = tr.StartTime.ToString(),
                           content = new
                           {
                               fromhref = fiex.ForumAddress,
                               fromname = fiex.ForumName,
                               outcredits = tr.ExpendCredits,
                               tohref = fire.ForumAddress,
                               toname = fire.ForumName,
                               incredits = tr.ReceiveCredits,
                           },
                           comments = from trp in trp_list
                                      join _a in a_list on trp.ReplierId equals _a.Id
                                      where trp.TradingId == tr.Id
                                      select new
                                      {
                                          account = _a.Account,
                                          headimg = "Headimg.ashx?user=" + _a.Account,
                                          content = trp.ReplyContent,
                                          time = trp.ReplyTime.ToString(),
                                      },
                       };
        return CJsonHelper.Serialize(new { data = fin_list, });
    }

    /// <summary>
    /// 查找可交易信息
    /// </summary>
    /// <returns>该交易对象</returns>
    private TB_TradingRecord SearchTradable(int tradeId)
    {
        return trd.GetById(tradeId);
    }
    /// <summary>
    /// 进行交易
    /// </summary>
    /// <param name="id"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public bool Trade(int id, int uid)
    {

        //交易时数据库需要加锁
        tradingrecord = trd.GetById(id);
        if (tradingrecord.Recipient == null)
        {
            tradingrecord.Recipient = uid;
            tradingrecord.EndTime = DateTime.Now;
            if (trd.Update(tradingrecord) > 0)
            {
                return new CMsg().Publish(
                    string.Format(
                    "您在{0}发布的一笔交易已完成,在{1}收入{2}积分!",
                    tradingrecord.StartTime.ToUniversalTime(),
                    fid.GetAll().First(fi =>
                    {
                        return fi.Id == tradingrecord.ReceiveForum;
                    }).ForumName,
                    tradingrecord.ReceiveCredits
                    ),
                    "交易提醒!",
                    tradingrecord.Sponsor);
            }
            else
                return false;
        }
        else
        {
            ErrLog.Err = "抱歉!该交易已完成,请选择其他交易!";
            return false;
        }
    }

    /// <summary>
    /// 删除个人交易信息
    /// </summary>
    /// <returns>删除成功返回true</returns>
    public bool DeleteSelfTrade(int id)
    {
        if (trd.DeleteById(id) > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 查找个人交易信息
    /// </summary>
    /// <returns>个人交易信息列表JSON</returns>
    public string SearchSelfTrade(DateTime start, DateTime end, int uid)
    {
        IEnumerable<TB_TradingRecord> tr_list = trd.GetAll();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();

        var fin_list = from tr in tr_list
                       join fiex in fi_list on tr.ExpendForum equals fiex.Id
                       join fire in fi_list on tr.ReceiveForum equals fire.Id
                       where tr.Sponsor == uid && ((tr.StartTime > start && tr.EndTime < end) || tr.EndTime == null)
                       orderby tr.Id descending
                       select new
                       {
                           id = tr.Id,
                           time = tr.StartTime.ToString(),
                           forumFrom = new
                           {
                               name = fiex.ForumName,
                               id = fiex.Id,
                               href = fiex.ForumAddress,
                           },
                           expend = -tr.ExpendCredits,
                           forumTo = new
                           {
                               name = fire.ForumName,
                               id = fire.Id,
                               href = fire.ForumAddress,
                           },
                           income = tr.ReceiveCredits,
                           status = tr.EndTime == null ? "等待交易" : "交易成功",
                       };


        return CJsonHelper.Serialize(new { data = fin_list, });
    }
    /// <summary>
    /// 交易详细信息
    /// </summary>
    /// <param name="id">交易id</param>
    /// <returns></returns>
    public string ShowTradeDetail(int id)
    {
        IEnumerable<TB_TradingRecord> tr_list = trd.GetAll();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        IEnumerable<TB_TradingReply> trp_list = trpd.GetAll();
        IEnumerable<TB_Account> a_list = ad.GetAll();
        var fin_list = from tr in tr_list
                       join fiex in fi_list on tr.ExpendForum equals fiex.Id
                       join fire in fi_list on tr.ReceiveForum equals fire.Id
                       join _a in a_list on tr.Sponsor equals _a.Id
                       join __a in a_list on tr.Recipient equals __a.Id into all
                       from x in all.DefaultIfEmpty()
                       where tr.Id == id
                       select new
                       {
                           id = tr.Id,
                           time = tr.StartTime.ToString() + " ~ " + (tr.EndTime == null ? "" : tr.EndTime.ToString()),
                           exforum = fiex.ForumName,
                           excredits = tr.ExpendCredits,
                           inforum = fire.ForumName,
                           incredits = tr.ReceiveCredits,
                           status = tr.EndTime == null ? 0 : 1,//0--等待交易，1--交易成功
                           statusStr = tr.EndTime == null ? "等待交易" : "交易成功",
                           mark = "备注",//需要修改
                           trader = tr.Recipient == null ? "暂无" : x.Account,
                           publisher = _a.Account,
                           comments = (from trp in trp_list
                                       join a in a_list on trp.ReplierId equals a.Id
                                       where trp.TradingId == tr.Id
                                       select new
                                       {
                                           account = a.Account,
                                           headimg = "Headimg.ashx?user=" + a.Account,
                                           content = trp.ReplyContent,
                                           time = trp.ReplyTime.ToString(),
                                       }),
                       };
        return CJsonHelper.Serialize(new { data = fin_list, });
    }

    /// <summary>
    /// 计算支出积分总和
    /// </summary>
    /// <returns></returns>
    public string Exsum(int uid)
    {
        var exsum = trd.GetAll().Sum((tr) =>
        {
            if (tr.Sponsor == uid && tr.EndTime != null)
                return tr.ExpendCredits;
            else
                return 0;
        });

        return Math.Round(exsum, 2).ToString();
    }

    /// <summary>
    /// 计算收入积分总和
    /// </summary>
    /// <returns></returns>
    public string Insum(int uid)
    {
        var insum = trd.GetAll().Sum((tr) =>
        {
            if (tr.Recipient == uid)
                return tr.ExpendCredits;
            else
                return 0;
        });

        return Math.Round(insum, 2).ToString();
    }
}
