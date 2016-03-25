using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_OverdraftRecord;
using JFB.TB_ForumsInfo;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// 积分透支
/// </summary>
public class COverdraftCredits
{
    TB_OverdraftRecord overdraftrecord;
    TB_OverdraftRecord_DAL ord = new TB_OverdraftRecord_DAL();
    TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
    public TB_OverdraftRecord OverdraftRecord
    {
        get { return overdraftrecord; }
        set { overdraftrecord = value; }
    }
    /// <summary>
    /// 透支积分
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Overdraft()
    {
        if (null != ord.Add(overdraftrecord))
            return true;
        else
            return false;
    }

    /// <summary>
    /// 显示透支记录
    /// </summary>
    /// <returns>记录列表</returns>
    [Obsolete]
    public List<TB_OverdraftRecord> ShowOverdraft()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 查找透支记录
    /// </summary>
    /// <returns>记录列表JSON</returns>
    public string SearchOverdraft(DateTime start, DateTime end)
    {
        IEnumerable<TB_OverdraftRecord> or_list = ord.GetAll();
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();

        var fin_list = from or in or_list
                       join fi in fi_list on or.OverdraftForumId equals fi.Id
                       where or.OverdrafterId == overdraftrecord.OverdrafterId && or.OverdraftTime > start && or.OverdraftTime < end
                       select new
                       {
                           or.Id,
                           or.OverdraftCredits,
                           or.OverdraftTime,
                           fi.ForumName,
                           fi.ForumAddress
                       };
        return CJsonHelper.Serialize(fin_list);
    }

    /// <summary>
    /// 删除透支记录
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool DeleteOverdraft()
    {
        throw new System.NotImplementedException();
    }
}
