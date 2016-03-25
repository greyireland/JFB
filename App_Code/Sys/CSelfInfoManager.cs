using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using JFB.TB_Account;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
/// <summary>
/// 个人信息管理
/// </summary>
public class CSelfInfoManager
{
    TB_Account_DAL ad = new TB_Account_DAL();
    /// <summary>
    /// 修改姓名
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool EditName()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 修改安全
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool EditSecurity()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 修改邮箱
    /// </summary>
    /// <returns>成功返回true</returns>
    public bool EditEmail()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// 查看信息
    /// </summary>
    /// <returns>成功返回信息对象</returns>
    public TB_Account ShowInfo(int id)
    {
        return ad.GetById(id);
    }

    /// <summary>
    /// 获取头像
    /// </summary>
    /// <returns>头像文件流</returns>
    public void WriteHeadImg(string account, Stream stream)
    {
        TB_Account acc = ad.GetByAccount(account);
        string path = CPorter.headImgPath + "\\DefaultUser.JPG";
        if (null != acc)
            path = CPorter.headImgPath + acc.HeadImgPath;
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            using (Image img = new Bitmap(fs))
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }

    public bool PayPwdValidation(int uid, string pwd)
    {
        TB_Account ac = ad.GetById(uid);
        return ac.PayPwd == pwd;
    }

    public bool Update(TB_Account account)
    {
        return ad.Update(account) > 0;
    }
}
