using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_ForumsInfo
{
    public class TB_ForumsInfo_DAL
	{
        public TB_ForumsInfo Add
			(TB_ForumsInfo tB_ForumsInfo)
		{
				string sql ="INSERT INTO TB_ForumsInfo (ForumName, ForumAddress, UnitPrice, CreditInc, OverdraftInc, ForumManageAccount, ForumManagePwd)  output inserted.Id VALUES (@ForumName, @ForumAddress, @UnitPrice, @CreditInc, @OverdraftInc, @ForumManageAccount, @ForumManagePwd)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ForumName", ToDBValue(tB_ForumsInfo.ForumName)),
						new SqlParameter("@ForumAddress", ToDBValue(tB_ForumsInfo.ForumAddress)),
						new SqlParameter("@UnitPrice", ToDBValue(tB_ForumsInfo.UnitPrice)),
						new SqlParameter("@CreditInc", ToDBValue(tB_ForumsInfo.CreditInc)),
						new SqlParameter("@OverdraftInc", ToDBValue(tB_ForumsInfo.OverdraftInc)),
						new SqlParameter("@ForumManageAccount", ToDBValue(tB_ForumsInfo.ForumManageAccount)),
						new SqlParameter("@ForumManagePwd", ToDBValue(tB_ForumsInfo.ForumManagePwd)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_ForumsInfo WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_ForumsInfo tB_ForumsInfo)
        {
            string sql =
                "UPDATE TB_ForumsInfo " +
                "SET " +
			" ForumName = @ForumName" 
                +", ForumAddress = @ForumAddress" 
                +", UnitPrice = @UnitPrice" 
                +", CreditInc = @CreditInc" 
                +", OverdraftInc = @OverdraftInc" 
                +", ForumManageAccount = @ForumManageAccount" 
                +", ForumManagePwd = @ForumManagePwd" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_ForumsInfo.Id)
					,new SqlParameter("@ForumName", ToDBValue(tB_ForumsInfo.ForumName))
					,new SqlParameter("@ForumAddress", ToDBValue(tB_ForumsInfo.ForumAddress))
					,new SqlParameter("@UnitPrice", ToDBValue(tB_ForumsInfo.UnitPrice))
					,new SqlParameter("@CreditInc", ToDBValue(tB_ForumsInfo.CreditInc))
					,new SqlParameter("@OverdraftInc", ToDBValue(tB_ForumsInfo.OverdraftInc))
					,new SqlParameter("@ForumManageAccount", ToDBValue(tB_ForumsInfo.ForumManageAccount))
					,new SqlParameter("@ForumManagePwd", ToDBValue(tB_ForumsInfo.ForumManagePwd))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_ForumsInfo GetById(int id)
        {
            string sql = "SELECT * FROM TB_ForumsInfo WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public TB_ForumsInfo ToModel(SqlDataReader reader)
		{
			TB_ForumsInfo tB_ForumsInfo = new TB_ForumsInfo();

			tB_ForumsInfo.Id = (int)ToModelValue(reader,"Id");
			tB_ForumsInfo.ForumName = (string)ToModelValue(reader,"ForumName");
			tB_ForumsInfo.ForumAddress = (string)ToModelValue(reader,"ForumAddress");
			tB_ForumsInfo.UnitPrice = (double?)ToModelValue(reader,"UnitPrice");
			tB_ForumsInfo.CreditInc = (double?)ToModelValue(reader,"CreditInc");
			tB_ForumsInfo.OverdraftInc = (double?)ToModelValue(reader,"OverdraftInc");
			tB_ForumsInfo.ForumManageAccount = (string)ToModelValue(reader,"ForumManageAccount");
			tB_ForumsInfo.ForumManagePwd = (string)ToModelValue(reader,"ForumManagePwd");
			return tB_ForumsInfo;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_ForumsInfo";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_ForumsInfo> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_ForumsInfo) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_ForumsInfo> GetAll()
		{
			string sql = "SELECT * FROM TB_ForumsInfo";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_ForumsInfo> ToModels(SqlDataReader reader)
		{
			List<TB_ForumsInfo> list = new List<TB_ForumsInfo>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
    }