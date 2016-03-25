using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Script.Serialization;
/// <summary>
/// JSON帮助
/// </summary>
public class CJsonHelper
{
    static JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
    /// <summary>
    /// json序列化
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Serialize(object obj)
    {
        return jsonSerialize.Serialize(obj);
    }
    
    public static T DeSerialize<T>(string json)
    {
        return jsonSerialize.Deserialize<T>(json);
    }
}
