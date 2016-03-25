using JFB.TB_Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AppHelper 的摘要说明
/// </summary>
public class AppHelper
{
    private const string HEAD_USER_NAME = "JFB-User-Name";
    private const string HEAD_TOKEN = "JFB-Token";

    public AppHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }


    /// <summary>
    /// 验证用户,
    /// </summary>
    /// <param name="context"></param>
    /// <returns>成功返回用户id，失败返回-1</returns>
    public static int Verification(HttpContext context)
    {
        string username = context.Request.Headers.Get(HEAD_USER_NAME);
        string token = context.Request.Headers.Get(HEAD_TOKEN);
        username = HttpUtility.UrlDecode(username,System.Text.Encoding.UTF8);
        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(token))
        {
            CPorter p = new CPorter();
            p.Account.Account = username;
            p.Account.Token = token;
            if (p.IsApp())
                return p.Account.Id;
            else
                return -1;
        }
        return -1;
    }

    /// <summary>
    /// 设置Token
    /// </summary>
    /// <param name="context"></param>
    /// <returns>成功返回true,失败返回false</returns>
    public static bool setToken(int uid, string token)
    {
        CSelfInfoManager sm = new CSelfInfoManager();
        TB_Account account = sm.ShowInfo(uid);
        account.Token = token;
        return sm.Update(account);

    }
}