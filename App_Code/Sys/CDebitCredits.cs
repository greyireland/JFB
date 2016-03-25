using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_DebitRecord;
using JFB.TB_ForumsInfo;
using System.Collections.Generic;
using System.Linq;
using JFB.TB_Account;
/// <summary>
/// 积分借贷
/// </summary>
public class CDebitCredits
{

    private TB_DebitRecord debitrecord;
    public TB_DebitRecord DebitRecord
    {
        get { return debitrecord; }
        set { debitrecord = value; }
    }

    public CDebitCredits()
    {
        debitrecord = new TB_DebitRecord();
    }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="accountId">借贷账户ID</param>
    /// <param name="debitForumId">借贷的论坛ID</param>
    /// <param name="debitCredits">借贷积分额</param>
    /// <param name="borrowingRate">利率</param>
    /// <param name="stipulatePaymentTime">规定还贷时间</param>
    /// <param name="debitTime">借贷时间</param>
    public CDebitCredits(int accountId, int debitForumId, float debitCredits, float borrowingRate, DateTime stipulatePaymentTime, DateTime debitTime)
    {
        debitrecord = new TB_DebitRecord
        {
            DebitAccountId = accountId,
            StipulatePaymentTime = stipulatePaymentTime,
            DebitCredits = debitCredits,
            DebitTime = debitTime,
            DebitForumId = debitForumId,
            BorrowingRate = borrowingRate,
        };
    }
    /// <summary>
    /// 借贷积分
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Debit()
    {
        TB_DebitRecord_DAL drd = new TB_DebitRecord_DAL();
        if (drd.Add(debitrecord) != null)//向借贷记录表中插入数据，业务逻辑未完成
            return true;
        else
            return false;
    }
    /// <remarks>此方法已废弃，请使用SearchDebit方法查找所有记录，使用DateTime.MinValue,DateTime.MaxValue作为参数</remarks>
    /// <summary>
    /// 显示借贷记录
    /// </summary>
    /// <returns>返回借贷记录列表JSON</returns>
    [Obsolete]
    public string ShowRecord()
    {
        TB_DebitRecord_DAL drd = new TB_DebitRecord_DAL();
        TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        IEnumerable<TB_DebitRecord> dr_list = drd.GetAll();

        var fin_list = (from fi in fi_list
                        join dr in dr_list on fi.Id equals dr.DebitForumId
                        where dr.DebitAccountId == debitrecord.Id
                        select
                            new
                            {
                                dr.DebitAccountId,
                                dr.DebitCredits,
                                dr.BorrowingRate,
                                tt = dr.DebitTime.ToString(),
                                ss = dr.RealityPaymentTime.ToString(),
                                aa = dr.StipulatePaymentTime.ToString(),
                                fi.ForumName,
                                fi.ForumAddress
                            });

        return CJsonHelper.Serialize(new { data = fin_list });
    }

    /// <summary>
    /// 根据借贷时间查找查找借贷记录
    /// </summary>
    /// <returns>返回借贷记录列表JSON</returns>
    public string SearchRecord(DateTime start, DateTime end)
    {
        TB_DebitRecord_DAL drd = new TB_DebitRecord_DAL();
        TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        IEnumerable<TB_DebitRecord> dr_list = drd.GetAll();

        var fin_list = (from fi in fi_list
                        join dr in dr_list on fi.Id equals dr.DebitForumId
                        where dr.DebitAccountId == debitrecord.Id && dr.DebitTime > start && dr.DebitTime < end
                        select
                            new
                            {
                                dr.DebitAccountId,
                                dr.DebitCredits,
                                dr.BorrowingRate,
                                tt = dr.DebitTime.ToString(),
                                ss = dr.RealityPaymentTime.ToString(),
                                aa = dr.StipulatePaymentTime.ToString(),
                                fi.ForumName,
                                fi.ForumAddress
                            });
        return CJsonHelper.Serialize(new { data = fin_list });
    }



    /// <summary>
    /// 删除借贷记录
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool DeleteRecord()
    {
        TB_DebitRecord_DAL drd = new TB_DebitRecord_DAL();
        if (drd.DeleteById(debitrecord.Id) > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 信用验证
    /// </summary>
    /// <returns></returns>
    public bool CreditVerification()
    {
        if (debitrecord.DebitCredits <= new CForumManager().GetForumMaxCreditCnt(debitrecord.DebitAccountId, debitrecord.DebitForumId))
            return true;
        return false;
    }
}


