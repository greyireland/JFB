using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_Account
{
public class TB_Account_BLL
    {
        public TB_Account Add(TB_Account tB_Account)
        {
            return new TB_Account_DAL().Add(tB_Account);
        }

        public int DeleteById(int id)
        {
            return new TB_Account_DAL().DeleteById(id);
        }

		public int Update(TB_Account tB_Account)
        {
            return new TB_Account_DAL().Update(tB_Account);
        }
        

        public TB_Account GetById(int id)
        {
            return new TB_Account_DAL().GetById(id);
        }
		public int GetTotalCount()
		{
			return new TB_Account_DAL().GetTotalCount();
		}
		
		public IEnumerable<TB_Account> GetPagedData(int minrownum,int maxrownum)
		{
			return new TB_Account_DAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<TB_Account> GetAll()
		{
			return new TB_Account_DAL().GetAll();
		}
    }
    }