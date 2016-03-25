using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_MyForum
{
public class TB_MyForum_BLL
    {
        public TB_MyForum Add(TB_MyForum tB_MyForum)
        {
            return new TB_MyForum_DAL().Add(tB_MyForum);
        }

        public int DeleteById(int id)
        {
            return new TB_MyForum_DAL().DeleteById(id);
        }

		public int Update(TB_MyForum tB_MyForum)
        {
            return new TB_MyForum_DAL().Update(tB_MyForum);
        }
        

        public TB_MyForum GetById(int id)
        {
            return new TB_MyForum_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_MyForum_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_MyForum> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_MyForum_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_MyForum> GetAll()
		{
			return new TB_MyForum_DAL().GetAll();
		}
    }
    }