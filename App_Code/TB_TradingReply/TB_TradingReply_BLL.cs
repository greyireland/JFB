using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_TradingReply
{
public class TB_TradingReply_BLL
    {
        public TB_TradingReply Add(TB_TradingReply tB_TradingReply)
        {
            return new TB_TradingReply_DAL().Add(tB_TradingReply);
        }

        public int DeleteById(int id)
        {
            return new TB_TradingReply_DAL().DeleteById(id);
        }

		public int Update(TB_TradingReply tB_TradingReply)
        {
            return new TB_TradingReply_DAL().Update(tB_TradingReply);
        }
        

        public TB_TradingReply GetById(int id)
        {
            return new TB_TradingReply_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_TradingReply_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_TradingReply> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_TradingReply_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_TradingReply> GetAll()
		{
			return new TB_TradingReply_DAL().GetAll();
		}
    }
    }