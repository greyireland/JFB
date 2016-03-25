using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_PurchaseRecord;
using JFB.TB_ForumsInfo;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// 积分购买
/// </summary>
public class CPurchaseCredits
{
    TB_PurchaseRecord purchaserecord;
    TB_PurchaseRecord_DAL prd = new TB_PurchaseRecord_DAL();
    TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
    public TB_PurchaseRecord PurchaseRecord
    {
        get { return purchaserecord; }
        set { purchaserecord = value; }
    }
    public CPurchaseCredits()
    {
        purchaserecord = new TB_PurchaseRecord();
    }
    /// <summary>
    /// 购买积分
    /// </summary>
    /// <returns>购买成功返回true</returns>
    public bool Purchase()
    {
        if (null != prd.Add(purchaserecord))
            return true;
        else
            return false;
    }
    [Obsolete]
    /// <summary>
    /// 显示购买记录
    /// </summary>
    /// <returns>记录列表</returns>
    public List<TB_PurchaseRecord> ShowRecord()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 查找购买记录
    /// </summary>
    /// <returns>记录列表JSON</returns>
    public string SearchRecord(DateTime start, DateTime end)
    {
        IEnumerable<TB_PurchaseRecord> pr_list = prd.GetAll();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();

        var fin_list = from pr in pr_list
                       join fi in fi_list on pr.ForumId equals fi.Id
                       where pr.PurchaserId == purchaserecord.Id && pr.PurchaseTime > start && pr.PurchaseTime < end
                       select new
                       {
                           pr.Amount,
                           pr.PurchaseCredits,
                           pr.PurchaseStatus,
                           pr.PurchaseTime,
                           fi.ForumName,
                       };
        return CJsonHelper.Serialize(fin_list);
    }

    /// <summary>
    /// 删除购买记录
    /// </summary>
    /// <returns>删除成功返回true</returns>
    public bool DeleteRecord()
    {
        if (prd.DeleteById(purchaserecord.Id) > 0)
            return true;
        else
            return false;
    }
    

}
