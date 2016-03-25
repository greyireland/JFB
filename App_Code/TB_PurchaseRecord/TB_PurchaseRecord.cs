using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_PurchaseRecord
{
public class TB_PurchaseRecord
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
            protected int purchaserid;
			public int PurchaserId
			{
				get {return purchaserid;}
				set {purchaserid = value;}
			}
            protected DateTime purchasetime;
			public DateTime PurchaseTime
			{
				get {return purchasetime;}
				set {purchasetime = value;}
			}
            protected double amount;
			public double Amount
			{
				get {return amount;}
				set {amount = value;}
			}
            protected double purchasecredits;
			public double PurchaseCredits
			{
				get {return purchasecredits;}
				set {purchasecredits = value;}
			}
            protected int purchasestatus;
			public int PurchaseStatus
			{
				get {return purchasestatus;}
				set {purchasestatus = value;}
			}
	}
    }