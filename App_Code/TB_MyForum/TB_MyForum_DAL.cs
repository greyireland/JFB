using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_MyForum
{
    public class TB_MyForum_DAL
	{
        public TB_MyForum Add
			(TB_MyForum tB_MyForum)
		{
				string sql ="INSERT INTO TB_MyForum (ForumId, AccountId, ForumAccount, ForumPwd)  output inserted.Id VALUES (@ForumId, @AccountId, @ForumAccount, @ForumPwd)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ForumId", ToDBValue(tB_MyForum.ForumId)),
						new SqlParameter("@AccountId", ToDBValue(tB_MyForum.AccountId)),
						new SqlParameter("@ForumAccount", ToDBValue(tB_MyForum.ForumAccount)),
						new SqlParameter("@ForumPwd", ToDBValue(tB_MyForum.ForumPwd)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_MyForum WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_MyForum tB_MyForum)
        {
            string sql =
                "UPDATE TB_MyForum " +
                "SET " +
			" ForumId = @ForumId" 
                +", AccountId = @AccountId" 
                +", ForumAccount = @ForumAccount" 
                +", ForumPwd = @ForumPwd" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_MyForum.Id)
					,new SqlParameter("@ForumId", ToDBValue(tB_MyForum.ForumId))
					,new SqlParameter("@AccountId", ToDBValue(tB_MyForum.AccountId))
					,new SqlParameter("@ForumAccount", ToDBValue(tB_MyForum.ForumAccount))
					,new SqlParameter("@ForumPwd", ToDBValue(tB_MyForum.ForumPwd))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_MyForum GetById(int id)
        {
            string sql = "SELECT * FROM TB_MyForum WHERE Id = @Id";
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
		
		public TB_MyForum ToModel(SqlDataReader reader)
		{
			TB_MyForum tB_MyForum = new TB_MyForum();

			tB_MyForum.Id = (int)ToModelValue(reader,"Id");
			tB_MyForum.ForumId = (int)ToModelValue(reader,"ForumId");
			tB_MyForum.AccountId = (int)ToModelValue(reader,"AccountId");
			tB_MyForum.ForumAccount = (string)ToModelValue(reader,"ForumAccount");
			tB_MyForum.ForumPwd = (string)ToModelValue(reader,"ForumPwd");
			return tB_MyForum;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_MyForum";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_MyForum> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_MyForum) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_MyForum> GetAll()
		{
			string sql = "SELECT * FROM TB_MyForum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_MyForum> ToModels(SqlDataReader reader)
		{
			List<TB_MyForum> list = new List<TB_MyForum>();
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