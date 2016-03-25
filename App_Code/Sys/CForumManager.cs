using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_ForumsInfo;
using JFB.TB_MyForum;
using System.Collections.Generic;
using System.Linq;
using JFB.TB_Account;
/// <summary>
/// 论坛管理
/// </summary>
public class CForumManager
{
    TB_MyForum_DAL mfd = new TB_MyForum_DAL();
    TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
    TB_Account_DAL ad = new TB_Account_DAL();
    TB_MyForum myforum;
    public TB_MyForum MyForum
    {
        get { return myforum; }
        set { myforum = value; }
    }

    public CForumManager()
    {
        myforum = new TB_MyForum();
    }
    /// <summary>
    /// 我的论坛添加
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Add()
    {
        if (mfd.Add(myforum) != null)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 我的论坛修改
    /// </summary>
    /// <returns>修改成功返回true</returns>
    public bool Edit()
    {
        if (mfd.Update(myforum) > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 我的论坛删除
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Delete(int id)
    {
        if (mfd.DeleteById(id) > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 论坛的查找
    /// </summary>
    /// <returns>论坛列表JSON</returns>
    public string Search()
    {
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        var fin_list = from fi in fi_list
                       select new
                       {
                           id = fi.Id,
                           name = fi.ForumName,
                           href = fi.ForumAddress,
                       };
        return CJsonHelper.Serialize(new { forums = fin_list });
    }

    /// <summary>
    /// 论坛名称的查找,根据论坛id
    /// </summary>
    /// <returns>论坛列表JSON</returns>
    public string SearchName(int id)
    {
        TB_ForumsInfo fi = fid.GetById(id);
        return fi.ForumName;
    }


    /// <summary>
    /// 根据账户ID查找论坛
    /// </summary>
    /// <returns>论坛列表JSON</returns>
    public string SearchSelf(int id)
    {
        IEnumerable<TB_ForumsInfo> fi_list = fid.GetAll();
        IEnumerable<TB_MyForum> mf_list = mfd.GetAll();

        var fin_list = from fi in fi_list
                       join mf in mf_list on fi.Id equals mf.ForumId
                       where mf.AccountId == id
                       select new
                       {
                           id = mf.Id,
                           forum = new
                           {
                               name = fi.ForumName,
                               id = fi.Id,
                               href = fi.ForumAddress,
                           },
                           forumAccount = mf.ForumAccount,
                       };
        return CJsonHelper.Serialize(new { data = fin_list });
    }


    public string GetForumUnitPriceOfCredits(int id)
    {
        return fid.GetById(id).UnitPrice.ToString();
    }
    /// <summary>
    /// 借贷最大额
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public double? GetForumMaxCreditCnt(int uid, int f_id)
    {
        return (fid.GetById(f_id).CreditInc * ad.GetById(uid).LineOfCredit);
    }
}
