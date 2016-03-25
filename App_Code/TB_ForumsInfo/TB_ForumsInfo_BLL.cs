using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_ForumsInfo
{
public class TB_ForumsInfo_BLL
    {
        public TB_ForumsInfo Add(TB_ForumsInfo tB_ForumsInfo)
        {
            return new TB_ForumsInfo_DAL().Add(tB_ForumsInfo);
        }

        public int DeleteById(int id)
        {
            return new TB_ForumsInfo_DAL().DeleteById(id);
        }

		public int Update(TB_ForumsInfo tB_ForumsInfo)
        {
            return new TB_ForumsInfo_DAL().Update(tB_ForumsInfo);
        }
        

        public TB_ForumsInfo GetById(int id)
        {
            return new TB_ForumsInfo_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_ForumsInfo_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_ForumsInfo> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_ForumsInfo_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_ForumsInfo> GetAll()
		{
			return new TB_ForumsInfo_DAL().GetAll();
		}
    }
    }