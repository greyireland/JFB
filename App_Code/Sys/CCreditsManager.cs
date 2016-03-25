using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_TradingRecord;
using System.Collections.Generic;
using System.Linq;
using JFB.TB_DebitRecord;
using JFB.TB_PurchaseRecord;
public class CCreditsManager
{
    TB_TradingRecord_DAL trd = new TB_TradingRecord_DAL();
    TB_DebitRecord_DAL drd = new TB_DebitRecord_DAL();
    TB_PurchaseRecord_DAL prd = new TB_PurchaseRecord_DAL();
    /// <summary>
    /// 计算收入积分总和
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public double SumIncomeCredits(int uid)
    {
        List<TB_TradingRecord> tr_list = (List<TB_TradingRecord>)trd.GetAll();
        double sum = 0;
        tr_list.ForEach(new Action<TB_TradingRecord>((tr) =>
        {
            if (tr.Recipient == uid)
                sum += tr.ReceiveCredits;
        }));
        return sum;
    }

    /// <summary>
    /// 计算支出积分总和
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public double SumExpendCredits(int uid)
    {
        List<TB_TradingRecord> tr_list = (List<TB_TradingRecord>)trd.GetAll();
        double sum = 0;
        tr_list.ForEach(new Action<TB_TradingRecord>((tr) =>
        {
            if (tr.Sponsor == uid && tr.EndTime != null)
                sum += tr.ExpendCredits;
        }));
        return sum;
    }

    public double SumDebitCredits(int uid)
    {
        List<TB_DebitRecord> dr_list = (List<TB_DebitRecord>)drd.GetAll();
        double sum = 0;
        dr_list.ForEach(new Action<TB_DebitRecord>((dr) =>
        {
            if (dr.DebitAccountId == uid && dr.RealityPaymentTime == null)
                sum += dr.DebitCredits;
        }));
        return sum;
    }

    public double SumBuyCredits(int uid)
    {
        List<TB_PurchaseRecord> dr_list = (List<TB_PurchaseRecord>)prd.GetAll();
        double sum = 0;
        dr_list.ForEach(new Action<TB_PurchaseRecord>((pr) =>
        {
            if (pr.PurchaserId == uid)
                sum += pr.PurchaseCredits;
        }));
        return sum;
    }
}
