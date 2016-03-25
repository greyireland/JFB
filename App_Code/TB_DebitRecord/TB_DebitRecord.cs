using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_DebitRecord
{
public class TB_DebitRecord
	{	
            protected int id;
			public int Id
			{
				get {return id;}
				set {id = value;}
			}
            protected int debitforumid;
			public int DebitForumId
			{
				get {return debitforumid;}
				set {debitforumid = value;}
			}
            protected int debitaccountid;
			public int DebitAccountId
			{
				get {return debitaccountid;}
				set {debitaccountid = value;}
			}
            protected DateTime debittime;
			public DateTime DebitTime
			{
				get {return debittime;}
				set {debittime = value;}
			}
            protected double debitcredits;
			public double DebitCredits
			{
				get {return debitcredits;}
				set {debitcredits = value;}
			}
            protected DateTime stipulatepaymenttime;
			public DateTime StipulatePaymentTime
			{
				get {return stipulatepaymenttime;}
				set {stipulatepaymenttime = value;}
			}
            protected DateTime? realitypaymenttime;
			public DateTime? RealityPaymentTime
			{
				get {return realitypaymenttime;}
				set {realitypaymenttime = value;}
			}
            protected double borrowingrate;
			public double BorrowingRate
			{
				get {return borrowingrate;}
				set {borrowingrate = value;}
			}
	}
    }