using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JFB.TB_Account;
public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
        }
    }
    protected void sub_Click(object sender, EventArgs e)
    {
        TB_Account account = new TB_Account();
        CPorter porter = new CPorter();
        porter.Account.Account = username.Text;
        porter.Account.LoginPwd = password.Text;
        porter.Account.Exp = 0;
        porter.Account.STATUS = "正常";//0代表正常状态
        //uinfo.Gender = gender.SelectedValue;
        //uinfo.Birthday = Convert.ToDateTime(birthday.Text);
        porter.Account.SecurityLevel = "中";
        porter.Account.Email = email.Text;
        porter.Account.LineOfCredit = 1;//信用额度，初始为1
        porter.Account.PwdAnswer = a_to_secret_question.Text;//密保答案应用MD5加密
        porter.Account.PwdQuestion = secret_question.Text;
        porter.Account.PayPwd = pay_pwd.Text;
        porter.SaveHeadImg(headfile.FileBytes); //Session["TmpImg"] == null ? File.ReadAllBytes(defimgpath) : File.ReadAllBytes(Session["TmpImg"].ToString());
        if(porter.Register())
            PageHelper.DoScript(Response, "alert('注册成功!请登录');window.location = 'Default.aspx';");
        else
            PageHelper.DoScript(Response, "alert('注册失败');");
    }
}