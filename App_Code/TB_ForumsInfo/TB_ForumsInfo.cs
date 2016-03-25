using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_ForumsInfo
{
public class TB_ForumsInfo
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected string forumname;
			public string ForumName
			{
				get {return forumname;}
				set {forumname = value;}
			}
            protected string forumaddress;
			public string ForumAddress
			{
				get {return forumaddress;}
				set {forumaddress = value;}
			}
            protected double? unitprice;
			public double? UnitPrice
			{
				get {return unitprice;}
				set {unitprice = value;}
			}
            protected double? creditinc;
			public double? CreditInc
			{
				get {return creditinc;}
				set {creditinc = value;}
			}
            protected double? overdraftinc;
			public double? OverdraftInc
			{
				get {return overdraftinc;}
				set {overdraftinc = value;}
			}
            protected string forummanageaccount;
			public string ForumManageAccount
			{
				get {return forummanageaccount;}
				set {forummanageaccount = value;}
			}
            protected string forummanagepwd;
			public string ForumManagePwd
			{
				get {return forummanagepwd;}
				set {forummanagepwd = value;}
			}
	}
    }