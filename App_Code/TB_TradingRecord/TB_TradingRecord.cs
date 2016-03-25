using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_TradingRecord
{
public class TB_TradingRecord
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected DateTime starttime;
			public DateTime StartTime
			{
				get {return starttime;}
				set {starttime = value;}
			}
            protected DateTime? endtime;
			public DateTime? EndTime
			{
				get {return endtime;}
				set {endtime = value;}
			}
            protected int expendforum;
			public int ExpendForum
			{
				get {return expendforum;}
				set {expendforum = value;}
			}
            protected int? receiveforum;
			public int? ReceiveForum
			{
				get {return receiveforum;}
				set {receiveforum = value;}
			}
            protected double expendcredits;
			public double ExpendCredits
			{
				get {return expendcredits;}
				set {expendcredits = value;}
			}
            protected double receivecredits;
			public double ReceiveCredits
			{
				get {return receivecredits;}
				set {receivecredits = value;}
			}
            protected int sponsor;
			public int Sponsor
			{
				get {return sponsor;}
				set {sponsor = value;}
			}
            protected int? recipient;
			public int? Recipient
			{
				get {return recipient;}
				set {recipient = value;}
			}
	}
    }