using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ErrLog 的摘要说明
/// </summary>
public class ErrLog
{
	public ErrLog()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//

	}
    public static string Err;

    public static string LastErr()
    {
        return Err;
    }
}