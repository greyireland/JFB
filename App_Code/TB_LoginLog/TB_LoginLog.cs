using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_LoginLog
{
public class TB_LoginLog
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected int loginaccount;
			public int LoginAccount
			{
				get {return loginaccount;}
				set {loginaccount = value;}
			}
            protected DateTime logintime;
			public DateTime LoginTime
			{
				get {return logintime;}
				set {logintime = value;}
			}
	}
    }