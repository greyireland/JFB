using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelfInformation : System.Web.UI.Page
{
    protected static string[,] tabs = { { "SelfInformation.aspx", "基本信息" }, { "ForumList.aspx", "我的论坛" }, { "TradingRecord.aspx", "交易记录" }, { "SecuritySetup.aspx", "安全设置" }, { "MessageCenter.aspx", "消息中心" } };
    protected string i_tabs = PageHelper.Init_i_tabs(tabs, 2);
    CForumManager fm = new CForumManager();
    int uid = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"] as string;
        if (string.IsNullOrEmpty(type))
            type = Request.Form["type"] as string;
        uid = PageHelper.ParseID(Session["uid"]);

        if (!string.IsNullOrEmpty(type))
        {
            switch (type)
            {
                case "all": AllForums(); break;
                case "self": SelfForums(); break;
                case "del": DelSelfForum(); break;
                case "add": AddSelfForum(); break;
                case "edit": EditSelfForum(); break;
                default: break;
            }
        }
    }

    private void EditSelfForum()
    {
        InitPostData();
        Response.WriteEnd(fm.Edit().ToString());
    }

    private void AddSelfForum()
    {
        InitPostData();
        Response.WriteEnd(fm.Add().ToString());
    }

    private void InitPostData()
    {
        string tidStr = Request.Form["tid"] as string;
        int tid = -1;
        int.TryParse(tidStr, out tid);
        string fid = Request.Form["fid"] as string;
        string funame = Request.Form["funame"] as string;
        string fupwd = Request.Form["fupwd"] as string;
        if (uid > 0)//此处未做参数正确性检测
        {
            fm.MyForum.Id = tid;
            fm.MyForum.AccountId = uid;
            fm.MyForum.ForumId = int.Parse(fid);
            fm.MyForum.ForumPwd = fupwd;
            fm.MyForum.ForumAccount = funame;
        }
    }

    private void DelSelfForum()
    {
        int id = -1;
        if (int.TryParse(Request.QueryString["id"] as string, out id))
        {
            if (fm.Delete(id))
                Response.WriteEnd("true");
            else
                Response.WriteEnd("false");
        }

    }

    private void AllForums()
    {
        Response.Write(fm.Search());
        Response.End();
    }

    private void SelfForums()
    {
        if (uid > 0)
        {
            Response.Write(fm.SearchSelf(uid));
            Response.End();
        }

    }
}