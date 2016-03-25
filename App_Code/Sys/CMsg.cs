using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_SystemMsg;
using System.Linq;
/// <summary>
/// 消息管理
/// </summary>
public class CMsg
{
    TB_SystemMsg_DAL smd = new TB_SystemMsg_DAL();
    /// <summary>
    /// 发布消息
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Publish(string msg, string title, int uid)
    {
        TB_SystemMsg sm = new TB_SystemMsg();
        sm.IsRead = false;
        sm.MsgContent = msg;
        sm.MsgTime = DateTime.Now;
        sm.MsgTitle = title;
        sm.Receiver = uid;
        return smd.Add(sm) != null;
    }

    /// <summary>
    /// 删除消息
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool Delete()
    {
        throw new System.NotImplementedException();
    }

    public string GetMsg(int uid)
    {
        var sm_list = smd.GetAll();
        var fin_list = from sm in sm_list
                       where sm.Receiver == uid
                       orderby sm.MsgTime descending
                       select new
                       {
                           msgTitle = sm.MsgTitle,
                           msgContent = sm.MsgContent,
                           msgTime = sm.MsgTime.ToString(),
                       };
        return CJsonHelper.Serialize(new { data = fin_list, });
    }
}
