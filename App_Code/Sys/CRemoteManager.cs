using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;
/// <summary>
/// CRemoteManager 的摘要说明
/// </summary>
public class CRemoteManager
{
    public CRemoteManager()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    private CRemoteMsgProtocol _rmp;
    public CRemoteMsgProtocol RemoteMsgProtocol
    {
        get { return _rmp; }
        set { _rmp = value; }
    }
    static Random rand = new Random(DateTime.Now.Millisecond);
    public CRemoteMsgProtocol SendMsg(string addr)
    {
        CRemoteMsgProtocol rmp = null;
        XmlSerializer xs = new XmlSerializer(_rmp.GetType());
        using (Stream stream = new MemoryStream())
        {
            xs.Serialize(stream, _rmp, null);
            stream.Flush();
            var res = CHttpWebResponseUtility.CreatePostHttpResponse(addr, stream, 500000, null, Encoding.UTF8, null);
            using (Stream responseStream = res.GetResponseStream())
            {
                rmp = xs.Deserialize(responseStream) as CRemoteMsgProtocol;
            }
        }
        return rmp;
    }
}