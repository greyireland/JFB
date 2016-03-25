using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_TradingReply
{
public class TB_TradingReply
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected int tradingid;
			public int TradingId
			{
				get {return tradingid;}
				set {tradingid = value;}
			}
            protected int replierid;
			public int ReplierId
			{
				get {return replierid;}
				set {replierid = value;}
			}
            protected string replycontent;
			public string ReplyContent
			{
				get {return replycontent;}
				set {replycontent = value;}
			}
            protected DateTime replytime;
			public DateTime ReplyTime
			{
				get {return replytime;}
				set {replytime = value;}
			}
	}
    }