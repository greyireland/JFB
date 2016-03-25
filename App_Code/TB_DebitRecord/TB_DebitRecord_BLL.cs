using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_DebitRecord
{
public class TB_DebitRecord_BLL
    {
        public TB_DebitRecord Add(TB_DebitRecord tB_DebitRecord)
        {
            return new TB_DebitRecord_DAL().Add(tB_DebitRecord);
        }

        public int DeleteById(int id)
        {
            return new TB_DebitRecord_DAL().DeleteById(id);
        }

		public int Update(TB_DebitRecord tB_DebitRecord)
        {
            return new TB_DebitRecord_DAL().Update(tB_DebitRecord);
        }
        

        public TB_DebitRecord GetById(int id)
        {
            return new TB_DebitRecord_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_DebitRecord_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_DebitRecord> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_DebitRecord_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_DebitRecord> GetAll()
		{
			return new TB_DebitRecord_DAL().GetAll();
		}
    }
    }