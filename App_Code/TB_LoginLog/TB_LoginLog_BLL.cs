using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_LoginLog
{
public class TB_LoginLog_BLL
    {
        public TB_LoginLog Add(TB_LoginLog tB_LoginLog)
        {
            return new TB_LoginLog_DAL().Add(tB_LoginLog);
        }

        public int DeleteById(int id)
        {
            return new TB_LoginLog_DAL().DeleteById(id);
        }

		public int Update(TB_LoginLog tB_LoginLog)
        {
            return new TB_LoginLog_DAL().Update(tB_LoginLog);
        }
        

        public TB_LoginLog GetById(int id)
        {
            return new TB_LoginLog_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_LoginLog_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_LoginLog> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_LoginLog_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_LoginLog> GetAll()
		{
			return new TB_LoginLog_DAL().GetAll();
		}
    }
    }