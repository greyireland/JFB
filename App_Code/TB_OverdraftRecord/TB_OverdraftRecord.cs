using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_OverdraftRecord
{
public class TB_OverdraftRecord
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected int overdrafterid;
			public int OverdrafterId
			{
				get {return overdrafterid;}
				set {overdrafterid = value;}
			}
            protected int overdraftforumid;
			public int OverdraftForumId
			{
				get {return overdraftforumid;}
				set {overdraftforumid = value;}
			}
            protected DateTime overdrafttime;
			public DateTime OverdraftTime
			{
				get {return overdrafttime;}
				set {overdrafttime = value;}
			}
            protected double overdraftcredits;
			public double OverdraftCredits
			{
				get {return overdraftcredits;}
				set {overdraftcredits = value;}
			}
	}
    }