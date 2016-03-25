using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// PageHelper 的摘要说明
/// </summary>
public class PageHelper
{
    static readonly string Salt = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
    public PageHelper()
    {
    }
    public byte[] ImgToBytes(FileStream s)
    {
        byte[] buffer = new byte[s.Length];
        s.Read(buffer, 0, Convert.ToInt32(s.Length));
        return buffer;
    }
    public static Stream BytesToStream(byte[] bytes)
    {
        MemoryStream ms = new MemoryStream(bytes);
        return ms;
    }
    public static string GetMD5(string str)
    {
        byte[] b = System.Text.Encoding.Default.GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = "";
        for (int i = 0; i < b.Length; i++)
        {
            ret += b[i].ToString("x").PadLeft(2, '0');
        }
        return ret;
    }
    public static string GetPwd(string pwd)
    {
        return pwd;
        //return GetMD5(pwd + PageHelper.Salt);
    }
    public static void DoScript(HttpResponse resp, string script)
    {
        resp.Write("<script>" + script + "</script>");
    }
    public static string Init_i_tabs(string[,] val, int count)
    {
        StringBuilder sb = new StringBuilder(1000);
        for (int i = 0; i < val.Length / count; i++)
        {
            sb.AppendFormat("<a href=\"{0}\">{1}</a>", val[i, 0], val[i, 1]);
        }
        return sb.ToString();
    }
    /// <summary>
    /// obj转int
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>转换失败返回-1</returns>
    public static int ParseID(object obj)
    {
        int? id = obj as int?;
        if (id != null)
            return (int)id;
        else
            return -1;
    }
    /// <summary>
    /// 返回小数的整数部分
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static string SpliteInt(double d)
    {
        try
        {
            string dStr = d.ToString("F2");
            return dStr.Substring(0, dStr.IndexOf('.'));
        }
        catch
        {
            return "0";
        }
    }

    /// <summary>
    /// 返回小数的小数部分
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static string SpliteFloat(double d)
    {
        try
        {
            string dStr = d.ToString("F2");
            return dStr.Substring(dStr.IndexOf('.') + 1, dStr.Length - dStr.IndexOf('.'));
        }
        catch
        {
            return "00";
        }
    }

}

public static class Extend
{
    public static void WriteEnd(this HttpResponse hr, string con)
    {
        hr.Write(con);
        hr.End();
    }
}