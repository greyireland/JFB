using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_TradingRecord
{
public class TB_TradingRecord_BLL
    {
        public TB_TradingRecord Add(TB_TradingRecord tB_TradingRecord)
        {
            return new TB_TradingRecord_DAL().Add(tB_TradingRecord);
        }

        public int DeleteById(int id)
        {
            return new TB_TradingRecord_DAL().DeleteById(id);
        }

		public int Update(TB_TradingRecord tB_TradingRecord)
        {
            return new TB_TradingRecord_DAL().Update(tB_TradingRecord);
        }
        

        public TB_TradingRecord GetById(int id)
        {
            return new TB_TradingRecord_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_TradingRecord_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_TradingRecord> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_TradingRecord_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_TradingRecord> GetAll()
		{
			return new TB_TradingRecord_DAL().GetAll();
		}
    }
    }