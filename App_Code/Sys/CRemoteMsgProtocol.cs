using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// CRemoteMsgProtocol 的摘要说明
/// </summary>
[XmlRoot("JFBMSG")]
public class CRemoteMsgProtocol
{
    public CRemoteMsgProtocol()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 时间戳,保证时序
    /// </summary>
    public long Timestamp
    {
        get;
        set;
    }
    /// <summary>
    /// 消息类型
    /// 包括:0--获取积分，1--扣除积分
    /// </summary>
    public int MsgType
    {
        get;
        set;
    }

    /// <summary>
    /// 积分额-信誉度
    /// </summary>
    [XmlElement("Credits")]
    public double Credits
    {
        get;
        set;
    }
    /// <summary>
    /// 错误标志
    /// </summary>
    public bool IsErr
    {
        get;
        set;
    }

    /// <summary>
    /// 错误消息,当错误标志为true时，该字段有效
    /// </summary>
    [XmlElement("ErrMsg")]
    public string ErrMsg
    {
        get;
        set;
    }
    /// <summary>
    /// 用户论坛用户名
    /// </summary>
    [XmlElement("Username")]
    public string UUsername
    {
        get;
        set;
    }
    /// <summary>
    /// 用户论坛密码
    /// </summary>
    [XmlElement("Password")]
    public string UPassword
    {
        get;
        set;
    }
    /// <summary>
    /// 特征码
    /// </summary>
    public string Token
    {
        get;
        set;
    }


    /// <summary>
    /// 校验码,为(论坛用户名+论坛密码)的MD5码
    /// </summary>
    public string CheckCode
    {
        get;
        set;
    }

    public void SetCheckCode(string funame, string fpwd)
    {
        Token = Guid.NewGuid().ToString().Replace("-","");
        CheckCode = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(funame + fpwd + Token, "MD5");
    }
}