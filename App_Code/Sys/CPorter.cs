using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_Account;
using System.IO;
using System.Text.RegularExpressions;
/// <summary>
/// 登陆注册
/// </summary>
public class CPorter
{
    internal static readonly string headImgPath = AppDomain.CurrentDomain.BaseDirectory + "HeadImg\\";


    private TB_Account account;
    public TB_Account Account
    {
        get { return account; }
        set { account = value; }
    }

    public CPorter()
    {
        account = new TB_Account();
    }


    /// <summary>
    /// 注册
    /// </summary>
    /// <returns>注册成功返回true</returns>
    public bool Register()
    {
        TB_Account_DAL ad = new TB_Account_DAL();
        if (VerificationRegister(account))
        {
            account.LoginPwd = PageHelper.GetPwd(account.LoginPwd);
            return ad.Add(account) != null;
        }
        return false;
    }
    /// <summary>
    /// 验证注册
    /// </summary>
    /// <returns></returns>
    private bool VerificationRegister(TB_Account account)
    {
        bool pass = true;
        pass = pass && Regex.IsMatch(account.Account, @"^[a-zA-Z][a-zA-Z0-9_]{4,15}$");
        pass = pass && Regex.IsMatch(account.Email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        pass = pass && Regex.IsMatch(account.LoginPwd, @"^[a-zA-Z]\w{5,17}$");
        pass = pass && Regex.IsMatch(account.PayPwd, @"^[a-zA-Z]\w{5,17}$");
        pass = pass && !string.IsNullOrEmpty(account.PwdQuestion);
        pass = pass && !string.IsNullOrEmpty(account.PwdAnswer);
        return pass;
    }

    public string SaveHeadImg(byte[] file)
    {
        string imgFileName = System.Guid.NewGuid().ToString() + ".jpg";
        using (FileStream fs = new FileStream(headImgPath + imgFileName, FileMode.Create))
        {
            fs.Write(file, 0, file.Length);
        }
        account.HeadImgPath = imgFileName;
        return imgFileName;
    }

    /// <summary>
    /// 登陆
    /// </summary>
    /// <returns>登陆成功返回true，否则返回false</returns>
    public bool Login()
    {
        TB_Account_DAL ad = new TB_Account_DAL();
        TB_Account acc = ad.GetByAccount(account.Account);
        if (null == acc)
        {
            ErrLog.Err = "用户不存在!";
            return false;
        }

        if (PageHelper.GetPwd(account.LoginPwd) != acc.LoginPwd)
        {
            ErrLog.Err = "密码错误!";
            return false;
        }
        account = acc;
        return true;


    }

    public bool IsApp()
    {
        TB_Account_DAL ad = new TB_Account_DAL();
        TB_Account acc = ad.GetByAccount(account.Account);
        if (null == acc)
        {
            return false;
        }

        if (account.Token != acc.Token)
        {
            return false;
        }
        account = acc;
        return true;
    }


    /// <summary>
    /// 生成验证码
    /// </summary>
    /// <returns>验证码图像流</returns>
    public Stream CreateVerificationCode()
    {
        throw new System.NotImplementedException();
    }
}
