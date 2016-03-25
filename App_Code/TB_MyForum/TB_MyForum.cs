using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_MyForum
{
public class TB_MyForum
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected int forumid;
			public int ForumId
			{
				get {return forumid;}
				set {forumid = value;}
			}
            protected int accountid;
			public int AccountId
			{
				get {return accountid;}
				set {accountid = value;}
			}
            protected string forumaccount;
			public string ForumAccount
			{
				get {return forumaccount;}
				set {forumaccount = value;}
			}
            protected string forumpwd;
			public string ForumPwd
			{
				get {return forumpwd;}
				set {forumpwd = value;}
			}
	}
    }