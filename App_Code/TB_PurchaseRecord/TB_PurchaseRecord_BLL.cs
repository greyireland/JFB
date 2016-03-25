using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_PurchaseRecord
{
public class TB_PurchaseRecord_BLL
    {
        public TB_PurchaseRecord Add(TB_PurchaseRecord tB_PurchaseRecord)
        {
            return new TB_PurchaseRecord_DAL().Add(tB_PurchaseRecord);
        }

        public int DeleteById(int id)
        {
            return new TB_PurchaseRecord_DAL().DeleteById(id);
        }

		public int Update(TB_PurchaseRecord tB_PurchaseRecord)
        {
            return new TB_PurchaseRecord_DAL().Update(tB_PurchaseRecord);
        }
        

        public TB_PurchaseRecord GetById(int id)
        {
            return new TB_PurchaseRecord_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_PurchaseRecord_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_PurchaseRecord> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_PurchaseRecord_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_PurchaseRecord> GetAll()
		{
			return new TB_PurchaseRecord_DAL().GetAll();
		}
    }
    }