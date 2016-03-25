using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_SystemMsg
{
public class TB_SystemMsg
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected DateTime msgtime;
			public DateTime MsgTime
			{
				get {return msgtime;}
				set {msgtime = value;}
			}
            protected string msgtitle;
			public string MsgTitle
			{
				get {return msgtitle;}
				set {msgtitle = value;}
			}
            protected string msgcontent;
			public string MsgContent
			{
				get {return msgcontent;}
				set {msgcontent = value;}
			}
            protected int receiver;
			public int Receiver
			{
				get {return receiver;}
				set {receiver = value;}
			}
            protected bool isread;
			public bool IsRead
			{
				get {return isread;}
				set {isread = value;}
			}
	}
    }