using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_OverdraftRecord
{
public class TB_OverdraftRecord_BLL
    {
        public TB_OverdraftRecord Add(TB_OverdraftRecord tB_OverdraftRecord)
        {
            return new TB_OverdraftRecord_DAL().Add(tB_OverdraftRecord);
        }

        public int DeleteById(int id)
        {
            return new TB_OverdraftRecord_DAL().DeleteById(id);
        }

		public int Update(TB_OverdraftRecord tB_OverdraftRecord)
        {
            return new TB_OverdraftRecord_DAL().Update(tB_OverdraftRecord);
        }
        

        public TB_OverdraftRecord GetById(int id)
        {
            return new TB_OverdraftRecord_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_OverdraftRecord_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_OverdraftRecord> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_OverdraftRecord_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_OverdraftRecord> GetAll()
		{
			return new TB_OverdraftRecord_DAL().GetAll();
		}
    }
    }