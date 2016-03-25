using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_SystemMsg
{
public class TB_SystemMsg_BLL
    {
        public TB_SystemMsg Add(TB_SystemMsg tB_SystemMsg)
        {
            return new TB_SystemMsg_DAL().Add(tB_SystemMsg);
        }

        public int DeleteById(int id)
        {
            return new TB_SystemMsg_DAL().DeleteById(id);
        }

		public int Update(TB_SystemMsg tB_SystemMsg)
        {
            return new TB_SystemMsg_DAL().Update(tB_SystemMsg);
        }
        

        public TB_SystemMsg GetById(int id)
        {
            return new TB_SystemMsg_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_SystemMsg_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_SystemMsg> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_SystemMsg_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_SystemMsg> GetAll()
		{
			return new TB_SystemMsg_DAL().GetAll();
		}
    }
    }