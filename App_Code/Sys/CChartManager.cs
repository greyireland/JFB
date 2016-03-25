using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JFB.TB_ForumsInfo;
using JFB.TB_MyForum;
using JFB.TB_TradingRecord;
using JFB.TB_DebitRecord;
using JFB.TB_PurchaseRecord;
/// <summary>
/// CChartManager 的摘要说明(用于获取图表绘制数据)
/// </summary>
public class CChartManager
{

    private static readonly string url = "http://localhost:14349/ForumA.aspx";
    //论坛信息
    TB_ForumsInfo_DAL fid = new TB_ForumsInfo_DAL();
    //我的论坛
    TB_MyForum_DAL mfd = new TB_MyForum_DAL();
    //交易记录
    TB_TradingRecord_DAL trd = new TB_TradingRecord_DAL();
    //借贷记录
    TB_DebitRecord_DAL drd = new TB_DebitRecord_DAL();
    //购买记录
    TB_PurchaseRecord_DAL prd = new TB_PurchaseRecord_DAL();
    public CChartManager()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private double GetCredits(string addr, string uuname, string upwd, string funame, string fpwd)
    {
        CRemoteManager rm = new CRemoteManager();
        rm.RemoteMsgProtocol = new CRemoteMsgProtocol();
        rm.RemoteMsgProtocol.UUsername = uuname;
        rm.RemoteMsgProtocol.UPassword = upwd;
        rm.RemoteMsgProtocol.ErrMsg = "";
        rm.RemoteMsgProtocol.SetCheckCode(funame, fpwd);
        return rm.SendMsg(addr).Credits;
    }

    private double GetCredits(ref int i)
    {
        Random rand = new Random(i * DateTime.Now.Millisecond);
        ++i;
        return rand.Next(0, 70);
    }
    /// <summary>
    /// 获取积分信息
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public string GetCreditInfo(int uid)
    {
        int i = 0;
        var forum_list = from mf in mfd.GetAll()
                         join forum in fid.GetAll() on mf.ForumId equals forum.Id
                         where mf.AccountId == uid
                         select new
                         {
                             name = forum.ForumName,
                             credits = GetCredits(ref i),//GetCredits(url, mf.ForumAccount, mf.ForumPwd, forum.ForumManageAccount, forum.ForumManagePwd),
                         };
        var option = new
        {
            title = new
            {
                text = "",
                subtext = "",
            },
            tooltip = new
            {
                trigger = "axis"
            },
            legend = new
            {
                data = new string[] { "积分余额" },
            },
            toolbox = new
            {
                show = true,
                feature = new
                {
                    mark = new { show = false },
                    dataView = new { show = false, readOnly = true },
                    magicType = new { show = false, type = new string[] { "line", "bar" } },
                    restore = new { show = false },
                    saveAsImage = new { show = false }
                }
            },
            calculable = true,
            xAxis = new[]{
                new {
                    type= "value",
                }
        },
            yAxis = new[]{
                new {
                    type= "category",
                    data= from forum in forum_list orderby forum.name select forum.name,
                }
            },
            series = new[] {
                new {
                    name= "积分余额",
                    type= "bar",
                    data= from forum in forum_list orderby forum.name select forum.credits,
                    markPoint= new {
                        data= new[]{
                            new { type= "max", name= "最大值" },
                            new { type= "min", name= "最小值" }
                        }
                    },
                    markLine= new {
                        data= new[]{
                            new { type= "average", name= "平均值" }
                        }
                    }
                }
            }
        };

        return CJsonHelper.Serialize(option);
    }


    /// <summary>
    /// 初始化月列表
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private List<DateTime> InitMonth(DateTime start, DateTime end)
    {
        List<DateTime> list = new List<DateTime>();
        DateTime flag = start;
        while (flag.Date < end.Date)
        {
            list.Add(flag.Date);
            flag = flag.AddDays(1);
        }
        return list;
    }

    /// <summary>
    /// 获取月支出积分
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public string GetMonthExCreditInfo(int uid, DateTime start, DateTime end)
    {
        var month = InitMonth(start, end);
        var mf_list = from mf in
                          (from _mf in mfd.GetAll() where _mf.AccountId == uid select _mf)
                      join fi in fid.GetAll()
                      on mf.ForumId equals fi.Id
                      select new
                      {
                          id = mf.ForumId,
                          name = fi.ForumName,
                          exCredits = from date in month
                                      join data in
                                          (from tr in trd.GetAll()
                                           where tr.EndTime != null && tr.Sponsor == uid && tr.StartTime.Date >= start.Date && tr.StartTime.Date < end.Date && tr.ExpendForum == mf.ForumId
                                           group tr by tr.StartTime.Date into trs
                                           select new
                                           {
                                               sum = trs.Sum(p => p.ExpendCredits),
                                               data = trs.Key.Date,
                                           }) on date.Date equals data.data.Date into res
                                      from data in res.DefaultIfEmpty()
                                      select data == null ? 0 : data.sum,
                      };

        var option = new
        {
            title = new
            {
                text = "",
                subtext = ""
            },
            tooltip = new
            {
                trigger = "axis"
            },
            legend = new
            {
                data = from _mf in mf_list orderby _mf.name select _mf.name,
            },
            toolbox = new
            {
                show = true,
                feature = new
                {
                    mark = new { show = false },
                    dataView = new { show = false, readOnly = true },
                    magicType = new { show = false, type = new[] { "line", "bar" } },
                    restore = new { show = false },
                    saveAsImage = new { show = false }
                }
            },
            calculable = true,
            xAxis = new[]{
                new {
                    name = start.Year+"-"+start.Month+"月",
                    type= "category",
                    boundaryGap= false,
                    data= from m in month select m.Day,
                }
            },
            yAxis = new[]{
                new {
                    type= "value",
                }
            },
            series = from _mf in mf_list
                     select new
                     {
                         name = _mf.name,
                         type = "line",
                         data = _mf.exCredits,
                         markPoint = new
                         {
                             data = new[]
                             {
                            new { type= "max", name= "最大值" },
                            new { type= "min", name= "最小值" }
                        }
                         },
                         markLine = new
                         {
                             data = new[]{
                            new { type= "average", name= "平均值" }
                        }
                         }
                     },
        };
        return CJsonHelper.Serialize(option);
    }


    /// <summary>
    /// 获取月收入积分
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public string GetMonthInCreditInfo(int uid, DateTime start, DateTime end)
    {
        var month = InitMonth(start, end);
        var mf_list = from mf in
                          (from _mf in mfd.GetAll() where _mf.AccountId == uid select _mf)
                      join fi in fid.GetAll()
                      on mf.ForumId equals fi.Id
                      select new
                      {
                          id = mf.ForumId,
                          name = fi.ForumName,
                          inCredits = from date in month
                                      join data in
                                          (from tr in trd.GetAll()
                                           where tr.EndTime != null && tr.Recipient == uid && tr.EndTime.Value.Date >= start.Date && tr.EndTime.Value.Date < end.Date && tr.ReceiveForum == mf.ForumId
                                           group tr by tr.EndTime.Value.Date into trs
                                           select new
                                           {
                                               sum = trs.Sum(p => p.ReceiveCredits),
                                               data = trs.Key.Date,
                                           }) on date.Date equals data.data.Date into res
                                      from data in res.DefaultIfEmpty()
                                      select data == null ? 0 : data.sum,
                      };

        var option = new
        {
            title = new
            {
                text = "",
                subtext = ""
            },
            tooltip = new
            {
                trigger = "axis"
            },
            legend = new
            {
                data = from _mf in mf_list orderby _mf.name select _mf.name,
            },
            toolbox = new
            {
                show = true,
                feature = new
                {
                    mark = new { show = false },
                    dataView = new { show = false, readOnly = true },
                    magicType = new { show = false, type = new[] { "line", "bar" } },
                    restore = new { show = false },
                    saveAsImage = new { show = false }
                }
            },
            calculable = true,
            xAxis = new[]{
                new {
                    name = start.Year+"-"+start.Month+"月",
                    type= "category",
                    boundaryGap= false,
                    data= from m in month select m.Day,
                }
            },
            yAxis = new[]{
                new {
                    type= "value",
                }
            },
            series = from _mf in mf_list
                     orderby _mf.name
                     select new
                     {
                         name = _mf.name,
                         type = "line",
                         data = _mf.inCredits,
                         markPoint = new
                         {
                             data = new[]
                             {
                            new { type= "max", name= "最大值" },
                            new { type= "min", name= "最小值" }
                        }
                         },
                         markLine = new
                         {
                             data = new[]{
                            new { type= "average", name= "平均值" }
                        }
                         }
                     },
        };
        return CJsonHelper.Serialize(option);
    }

    /// <summary>
    /// 获取总借贷积分
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public string GetSumCdCreditInfo(int uid)
    {
        var scredit_list = from _sdr in
                               (from dr in drd.GetAll()
                                where dr.RealityPaymentTime == null && dr.DebitAccountId == uid
                                group dr by dr.DebitForumId into sdr
                                select new
                                    {
                                        fid = sdr.Key,
                                        scredit = sdr.Sum(d => d.DebitCredits),
                                    })
                           join fi in fid.GetAll()
                           on _sdr.fid equals fi.Id
                           select new
                           {
                               forum = fi.ForumName,
                               scredit = _sdr.scredit,
                           };


        var option = new
        {
            title = new
            {
                text = "",
                subtext = "",
                x = "center"
            },
            tooltip = new
            {
                trigger = "item",
                formatter = "{a}<br/>{b}<br/>借贷额 = {c} ({d}%)"
            },
            legend = new
            {
                x = "center",
                y = "bottom",
                data = from f in scredit_list orderby f.forum select f.forum,
            },
            toolbox = new
            {
                show = true,
                feature = new
                {
                    mark = new { show = false },
                    dataView = new { show = false, readOnly = true },
                    restore = new { show = false },
                    saveAsImage = new { show = false }
                }
            },
            calculable = false,
            series = new[]{
                        new {
            name="借贷总额",
            type="pie",
            radius = new []{30, 100},
            center = new []{"50%", "40%"},
            roseType = "area",
            itemStyle =　new {
                normal = new {
                    label = new {
                        show = false
                    },
                    labelLine = new {
                        show = false
                    }
                },
                emphasis = new {
                    label = new {
                        show = false
                    },
                    labelLine = new {
                        show = false
                    }
                }
            },
            data=from sc in scredit_list 
                 orderby sc.forum 
                 select new
            {
                value = sc.scredit,
                name = sc.forum,
},
        },
    },
        };

        return CJsonHelper.Serialize(option);
    }


    /// <summary>
    /// 获取购买积分
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public string GetSumPayCreditInfo(int uid)
    {
        var pay_list = from _spr in
                           (from pr in prd.GetAll()
                            where pr.PurchaserId == uid
                            group pr by pr.ForumId into spr
                            select new
                            {
                                fid = spr.Key,
                                scredit = spr.Sum(d => d.PurchaseCredits),
                                pay = spr.Sum(p => p.Amount),
                            })
                       join fi in fid.GetAll()
                       on _spr.fid equals fi.Id
                       select new
                       {
                           forum = fi.ForumName,
                           scredit = _spr.scredit,
                           pay = _spr.pay,
                       };


        var option = new
        {
            tooltip = new
            {
                trigger = "item",
                formatter = "{a}<br/>{b}<br/>所购积分 = {c} ({d}%)"
            },
            legend = new
            {
                orient = "vertical",
                x = "left",
                data = from f in pay_list orderby f.forum select f.forum,
            },
            toolbox = new
            {
                show = true,
                feature = new
                {
                    mark = new { show = false },
                    dataView = new { show = false, readOnly = true },
                    restore = new { show = false },
                    saveAsImage = new { show = false }
                }
            },
            calculable = false,
            series = new[]{
                        new {
            name="购买总额",
            type="pie",
            radius = new []{50, 100},
            center = new []{"50%", "60%"},
            itemStyle =　new {
                normal = new {
                    label = new {
                        show = false
                    },
                    labelLine = new {
                        show = false
                    }
                },
                emphasis = new {
                    label=new {
                        show = true,
                        position = "center",
                        textStyle = new {
                            fontSize = "20",
                            fontWeight = "bold"
                        }
                    }
                }
            },
            data=from sc in pay_list 
                 orderby sc.forum 
                 select new
            {
                value = sc.scredit,
                name = sc.forum,
},
        },
    },
        };

        return CJsonHelper.Serialize(option);
    }


}